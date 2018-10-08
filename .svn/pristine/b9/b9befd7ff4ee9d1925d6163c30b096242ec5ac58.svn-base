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
    public partial class EditReimbursementStandardForm : XtraForm
    {
        protected bool isCheckInput = false; //是否验证录入
        protected List<ReimbursementStandardInput> currInputRows = new List<ReimbursementStandardInput>();
        protected ReimbursementStandardInput currReimbursementStandard = null;//当前记录

        public EditReimbursementStandardForm(bool isCheck) 
            : this()
        {
            isCheckInput = isCheck;
        }

        public EditReimbursementStandardForm()
        {
            // This call is required by the Windows Form Designer.
            InitializeComponent();

            // TODO: Add any initialization after the InitializeComponent call
        }

        private void EditReimbursementStandardForm_Load(object sender, EventArgs e)
        {
            this.Text = "员工报销标准录入 - " + (this.是验证录入 ? "验证录入" : "初次录入");
            LoadData();
        }

        #region 加载数据

        protected void LoadData()
        {
            //清除原来的数据
            currInputRows = ReimbursementStandardInput.GetEditingRows(this.是验证录入);
            currInputRows = currInputRows.FindAll(a => a.员工信息 != null && AccessController.CheckPayGroup(a.员工信息.薪资组));
            currInputRows = currInputRows.OrderBy(a => a.编号).ToList();
            gridControl1.DataSource = currInputRows;
            gridControl1.RefreshDataSource();
        }        

        #endregion
        
        #region BecomeEffective

        private void BecomeEffective(ReimbursementStandardInput input)
        {
            ReimbursementStandard m = new ReimbursementStandard();
            ReimbursementStandard found = ReimbursementStandard.GetReimbursementStandard(input.员工编号, input.项目, input.生效日期);
            if (found != null)
            {
                m = found;
            }
            
            input.CopyWatchMember(m);
            m.有效 = true;

            ReimbursementStandardInput anotherInput = input.另一人录入的记录 as ReimbursementStandardInput;

            m.录入人 = input.录入人 + " " + anotherInput.录入人;
            m.录入时间 = input.生效时间;

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
                ReimbursementStandardInput currentItem = (ReimbursementStandardInput)colView.GetFocusedRow();
                if (currentItem != null)
                {
                    currentItem.录入人 = AccessController.CurrentUser.姓名;
                    currentItem.录入时间 = DateTime.Now;
                    currentItem.Save();
                }
                //遍历
                foreach(ReimbursementStandardInput row in currInputRows)
                {
                    row.UpdateCompareResult();
                    //如果完全相同，转为正式
                    if (row.内容不同的字段.Count == 0 && row.另一人已录入) BecomeEffective(row);
                }
                MessageBox.Show("保存成功！");
                LoadData();
            }
            MyHelper.WriteLog(LogType.信息, "修改员工报销标准", null);
        }
        #endregion

        #region btn添加_Click

        private void btn添加_Click(object sender, EventArgs e)
        {
            SearchEmployeeInfoForm form = new SearchEmployeeInfoForm();
            form.OnSelected += OnEmployeeSelectd;
            form.单选 = true; 
            form.ShowDialog();
        }

        private void OnEmployeeSelectd(object sender, EmployeeInfo emp)
        {
            ReimbursementStandardInput item = new ReimbursementStandardInput();

            item.生效日期 = MyHelper.GetPrevMonth1Day();
            item.是验证录入 = this.是验证录入;
            item.员工编号 = emp.员工编号;
            item.姓名 = emp.姓名;
            item.录入人 = AccessController.CurrentUser.姓名;
            item.录入时间 = DateTime.Now;
            currInputRows.Add(item);
            gridControl1.RefreshDataSource();
            gridView1.FocusedRowHandle = gridView1.RowCount - 1;

            MyHelper.WriteLog(LogType.信息, "新增员工报销标准录入记录", item.ToString<ReimbursementStandardInput>());
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
                    ReimbursementStandardInput currentItem = (ReimbursementStandardInput)colView.GetFocusedRow();
                    currInputRows.Remove(currentItem);
                    MyHelper.WriteLog(LogType.信息, "删除员工报销标准录入记录", currentItem.ToString<ReimbursementStandardInput>());
                    gridControl1.RefreshDataSource();
                    currentItem.Delete();
                    MessageBox.Show("删除成功。", "删除提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        #endregion

        #region btn刷新_Click

        private void btn刷新_Click(object sender, EventArgs e)
        {
            LoadData();
            MessageBox.Show("刷新成功！");
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
            ReimbursementStandardInput row = gridView1.GetRow(e.RowHandle) as ReimbursementStandardInput;

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
                            throw new Exception("您没有权限录入这个员工的报销标准");
                    }
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

            ReimbursementStandardInput row = gridView1.GetRow(e.RowHandle) as ReimbursementStandardInput;
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
            ReimbursementStandardInput row = gridView1.GetRow(e.PrevFocusedRowHandle) as ReimbursementStandardInput;
            if (row != null)
            {                
                row.GetModifiyFields();
            }
        }
        #endregion

        #region gridView1_CellValueChanging

        private void gridView1_CellValueChanging(object sender, CellValueChangedEventArgs e)
        {
            ReimbursementStandardInput row = gridView1.GetRow(e.RowHandle) as ReimbursementStandardInput;

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
        }

        private void comboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            BaseEdit editor = gridView1.ActiveEditor as BaseEdit;
        }
        #endregion

        #region gridView1_DoubleClick

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {

        }
        #endregion

    }

}

