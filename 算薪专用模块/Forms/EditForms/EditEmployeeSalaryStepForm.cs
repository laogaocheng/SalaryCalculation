using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using YiKang.RBACS.DataObjects;
using System.Collections.Generic;
using DevExpress.XtraGrid.Views.Base;
using Hwagain.Components;
using Hwagain.SalaryCalculation.Components;
using YiKang;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;


namespace Hwagain.SalaryCalculation
{
    public partial class EditEmployeeSalaryStepForm : XtraForm
    {
        protected bool isCheckInput = false; //是否验证录入
        protected List<EmpSalaryStepInput> currInputRows = new List<EmpSalaryStepInput>();
        protected EmpSalaryStepInput currEmpSalaryStep = null;//当前记录

        public EditEmployeeSalaryStepForm(bool isCheck) 
            : this()
        {
            isCheckInput = isCheck;
        }

        public EditEmployeeSalaryStepForm()
        {
            // This call is required by the Windows Form Designer.
            InitializeComponent();

            // TODO: Add any initialization after the InitializeComponent call
        }

        private void EditEmployeeSalaryStepForm_Load(object sender, EventArgs e)
        {
            this.Text = "员工工资职级录入 - " + (this.是验证录入 ? "验证录入" : "初次录入");

            List<SalaryNode> allGrade = SalaryNode.工资等级表.FindAll(a => a.类型 == (int)节点类型.薪等);
            foreach (SalaryNode grade in allGrade)
            {
                //如果有这个薪等的权限
                if (AccessController.CheckGrade(grade.标识))
                {
                    ImageComboBoxItem item = new ImageComboBoxItem();
                    item.Description = grade.名称;
                    item.Value = grade.标识;
                    repositoryItemImageComboBox1.Items.Add(item);
                }
            }
            LoadData();
        }

        #region 加载数据

        protected void LoadData()
        {
            //清除原来的数据
            currInputRows = EmpSalaryStepInput.GetEditingRows(this.是验证录入);
            //根据权限过滤
            currInputRows = currInputRows.FindAll(a => a.员工信息 != null && AccessController.CheckPayGroup(a.员工信息.薪资组));
            currInputRows = currInputRows.OrderBy(a => a.录入时间).ToList();

            gridControl1.DataSource = currInputRows;
            gridControl1.RefreshDataSource();
        }        

        #endregion
        
        #region BecomeEffective

        private void BecomeEffective(EmpSalaryStepInput input)
        {
            EmpSalaryStep m = new EmpSalaryStep();
            EmpSalaryStep found = EmpSalaryStep.GetEmpSalaryStep(input.员工编号, input.执行日期);
            if (found != null)
            {
                m = found;
            }
            EmployeeInfo emp = EmployeeInfo.GetEmployeeInfo(input.员工编号);
            m.薪资组 = emp.薪资组;
            input.CopyWatchMember(m);

            EmpSalaryStepInput anotherInput = input.另一人录入的记录 as EmpSalaryStepInput;

            m.录入人 = !input.是验证录入 ? input.录入人 : anotherInput.录入人;
            m.录入时间 = !input.是验证录入 ? input.录入时间 : anotherInput.录入时间;
            m.验证人 = input.是验证录入 ? input.录入人 : anotherInput.录入人;
            m.验证时间 = input.是验证录入 ? input.录入时间 : anotherInput.录入时间;
            m.Save();
        }
        #endregion

        #region 是验证录入

        public bool 是验证录入
        {
            get
            {
                return isCheckInput;
            }
            set
            {
                isCheckInput = value;
            }
        }
        #endregion

        #region btn保存_Click

        private void btn保存_Click(object sender, EventArgs e)
        {
            ColumnView colView = (ColumnView)gridControl1.MainView;
            if (colView != null)
            {
                EmpSalaryStepInput currentItem = (EmpSalaryStepInput)colView.GetFocusedRow();
                if (currentItem != null) currentItem.Save();
                //遍历
                foreach(EmpSalaryStepInput row in currInputRows)
                {
                    if (row.薪级标识 == 0) continue;
                    row.UpdateCompareResult();
                    //如果完全相同，转为正式
                    if (row.内容不同的字段.Count == 0 && row.另一人已录入) BecomeEffective(row);
                }
                MessageBox.Show("保存成功！");
                LoadData();
            }
            MyHelper.WriteLog(LogType.信息, "修改个人职级工资记录", null);
        }
        #endregion

        #region btn添加_Click

        private void btn添加_Click(object sender, EventArgs e)
        {
            SearchEmployeeInfoForm form = new SearchEmployeeInfoForm();
            form.OnSelected += OnEmployeeSelectd;
            form.ShowDialog();
        }

        private void OnEmployeeSelectd(object sender, EmployeeInfo emp)
        {
            EmpSalaryStepInput item = EmpSalaryStepInput.GetEditing(emp.员工编号, this.是验证录入);
            if (item == null)
            {
                item = new EmpSalaryStepInput();
                item.执行日期 = MyHelper.GetPrevMonth1Day();
                item.是验证录入 = this.是验证录入;
                item.员工编号 = emp.员工编号;
                item.姓名 = emp.姓名;
            }
            item.录入人 = AccessController.CurrentUser.姓名;
            item.录入时间 = DateTime.Now;
            currInputRows.Add(item);
            gridControl1.RefreshDataSource();
            gridView1.FocusedRowHandle = gridView1.RowCount - 1;

            MyHelper.WriteLog(LogType.信息, "新增员工工资职级录入记录", item.ToString<EmpSalaryStepInput>());
        }
        #endregion

        #region btn删除_Click

        private void btn删除_Click(object sender, EventArgs e)
        {
            ColumnView colView = (ColumnView)gridControl1.MainView;
            if (colView != null)
            {
                if (MessageBox.Show("确实删除当前记录吗？", "删除提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2, 0, false) == DialogResult.Yes)
                {
                    EmpSalaryStepInput currentItem = (EmpSalaryStepInput)colView.GetFocusedRow();
                    currInputRows.Remove(currentItem);
                    currentItem.Delete();

                    MyHelper.WriteLog(LogType.信息, "删除个人职级工资", currentItem.ToString<EmpSalaryStepInput>());

                    gridControl1.RefreshDataSource();
                    MessageBox.Show("删除成功。", "删除提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        #endregion

        #region btn刷新_Click

        private void btn刷新_Click(object sender, EventArgs e)
        {
            LoadData();
        }
        #endregion

        #region gridView1_InvalidRowException

        private void gridView1_InvalidRowException(object sender, InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.ThrowException;
        }
        #endregion

        #region gridView1_CellValueChanged

        private void gridView1_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            EmpSalaryStepInput row = gridView1.GetRow(e.RowHandle) as EmpSalaryStepInput;

            if (row != null)
            {
                if (e.Column.FieldName == "员工编号")
                {
                    EmployeeInfo pInfo = EmployeeInfo.GetEmployeeInfo(row.员工编号);
                    if (pInfo == null)
                    {
                        throw new Exception("找不到指定编号的员工");
                    }
                    else
                    {
                        if (AccessController.CheckPayGroup(pInfo.薪资组))
                        {
                            row.姓名 = pInfo.姓名;
                            gridControl1.RefreshDataSource();
                        }
                        else
                            throw new Exception("您没有权限录入这个员工的工资职级");
                    }
                }
                if (e.Column.FieldName == "薪等标识")
                {
                    row.薪级标识 = 0;
                    row.薪级名称 = "";
                }
                row.GetModifiyFields();
            }
        }
        #endregion

        #region gridView1_CustomDrawCell

        private void gridView1_CustomDrawCell(object sender, RowCellCustomDrawEventArgs e)
        {
            e.Appearance.ForeColor = Color.Black;
            e.Appearance.BackColor = Color.Transparent;

            EmpSalaryStepInput row = gridView1.GetRow(e.RowHandle) as EmpSalaryStepInput;
            if (row != null)
            {
                foreach (ModifyField field in row.内容不同的字段)
                {
                    if (field.名称 == e.Column.FieldName)
                    {
                        e.Appearance.ForeColor = Color.Yellow;
                        e.Appearance.BackColor = Color.Red;
                    }
                }
            }
        }
        #endregion

        #region gridView1_FocusedRowChanged

        private void gridView1_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            EmpSalaryStepInput row = gridView1.GetRow(e.PrevFocusedRowHandle) as EmpSalaryStepInput;
            if (row != null)
            {                
                row.GetModifiyFields();
            }
        }
        #endregion

        #region gridView1_CellValueChanging

        private void gridView1_CellValueChanging(object sender, CellValueChangedEventArgs e)
        {
            EmpSalaryStepInput row = gridView1.GetRow(e.RowHandle) as EmpSalaryStepInput;

            if (row != null)
            {
                
            }
        }
        #endregion

        #region ProcessCmdKey

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                BaseEdit editor = gridView1.ActiveEditor;
                if (editor != null && string.IsNullOrEmpty(editor.ErrorText) == false)
                {
                    editor.EditValue = editor.OldEditValue;
                    return true;
                }
                else
                    return base.ProcessCmdKey(ref msg, keyData);
            }
            else
                return base.ProcessCmdKey(ref msg, keyData);
        }
        #endregion

        #region gridView1_CustomRowCellEditForEditing

        private void gridView1_CustomRowCellEditForEditing(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            if (e.Column.FieldName == "薪级名称")
            {
                RepositoryItemImageComboBox comboBox = new RepositoryItemImageComboBox();
                comboBox.SelectedValueChanged += comboBox_SelectedValueChanged;
                EmpSalaryStepInput row = gridView1.GetRow(e.RowHandle) as EmpSalaryStepInput;
                SalaryNode grade = SalaryNode.GetSalaryNode(row.薪等标识);
                if (grade != null)
                {
                    foreach (SalaryNode step in grade.子节点)
                    {
                        ImageComboBoxItem item = new ImageComboBoxItem();
                        item.Description = step.名称;
                        item.Value = step.标识;
                        comboBox.Items.Add(item);
                    }
                    e.RepositoryItem = comboBox;
                }
            }
        }

        private void comboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            BaseEdit editor = gridView1.ActiveEditor as BaseEdit;
            gridView1.SetFocusedRowCellValue("薪级标识", editor.EditValue);
        }
        #endregion

        #region gridView1_DoubleClick

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {

        }
        #endregion

        #region repositoryItemImageComboBox1_SelectedValueChanged

        private void repositoryItemImageComboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            gridView1.SetFocusedRowCellValue("薪级标识", 0);
            gridView1.SetFocusedRowCellValue("薪级名称", "");
        }
        #endregion
    }

}

