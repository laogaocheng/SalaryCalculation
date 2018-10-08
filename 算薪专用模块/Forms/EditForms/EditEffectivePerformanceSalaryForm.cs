using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

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
    public partial class EditEffectivePerformanceSalaryForm : XtraForm
    {
        protected bool isCheckInput = false; //是否验证录入
        protected List<EffectivePerformanceSalaryInput> currInputRows = new List<EffectivePerformanceSalaryInput>();
        protected EffectivePerformanceSalaryInput currEffectivePerformanceSalary = null;//当前记录

        public EditEffectivePerformanceSalaryForm(bool isCheck) 
            : this()
        {
            isCheckInput = isCheck;
        }

        public EditEffectivePerformanceSalaryForm()
        {
            // This call is required by the Windows Form Designer.
            InitializeComponent();

            // TODO: Add any initialization after the InitializeComponent call
        }

        private void EditEffectivePerformanceSalaryForm_Load(object sender, EventArgs e)
        {
            this.Text = "员工本月执行绩效工资合计录入 - " + (this.是验证录入 ? "验证录入" : "初次录入");

            DateTime prevMonth = DateTime.Today.AddMonths(-1);
            year.EditValue = prevMonth.Year;
            month.EditValue = prevMonth.Month;

            LoadData();
        }

        #region 加载数据

        protected void LoadData()
        {
            //清除原来的数据
            currInputRows = EffectivePerformanceSalaryInput.GetEditingRows(Convert.ToInt32(year.EditValue), Convert.ToInt32(month.EditValue), this.是验证录入);
            gridControl1.DataSource = currInputRows;
            gridControl1.RefreshDataSource();
        }        

        #endregion
        
        #region BecomeEffective

        private void BecomeEffective(EffectivePerformanceSalaryInput input)
        {
            EffectivePerformanceSalary m = new EffectivePerformanceSalary();
            EffectivePerformanceSalary found = EffectivePerformanceSalary.GetEffectivePerformanceSalary(input.员工编号, input.年, input.月);
            if (found != null)
            {
                m = found;
            }
            
            input.CopyWatchMember(m);

            EffectivePerformanceSalaryInput opposite = input.另一人录入的记录 as EffectivePerformanceSalaryInput;
            //更新生效标记
            if (!input.已生效)
            {
                input.生效时间 = DateTime.Now;
                input.双人录入结果 = "两人录入完全一致";
                input.Save();

                opposite.生效时间 = DateTime.Now;
                opposite.双人录入结果 = "两人录入完全一致";
                opposite.Save();
            }
            
            m.录入人 = input.录入人 + " " + opposite.录入人;
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
                bool isSameEditor = false;

                //检查是否录入完成
                foreach (EffectivePerformanceSalaryInput row in currInputRows)
                {
                    if (row.实得工资 == 0)
                    {
                        MessageBox.Show("请全部录入完成以后再提交");
                        return;
                    }
                }

                //检查是否同一人录入
                foreach (EffectivePerformanceSalaryInput row in currInputRows)
                {
                    if (row.另一人录入的记录 != null)
                    {
                        string editor = AccessController.CurrentUser.姓名;
                        string editor_opposite = row.另一人录入的记录.录入人.Trim();
                        if (editor == editor_opposite && editor_opposite != "")
                        {
                            isSameEditor = true;
                            break;
                        }
                    }
                    row.录入人 = AccessController.CurrentUser.姓名;
                    row.录入时间 = DateTime.Now;
                    row.Save();
                }
                gridControl1.Refresh();

                if (isSameEditor)
                {
                    MessageBox.Show("两次录入不能是同一个人");
                    return;
                }

                foreach (EffectivePerformanceSalaryInput item in currInputRows)
                {
                    //手动比较录入的内容
                    item.CompareInputContent();
                }
                
                List<EffectivePerformanceSalaryInput> list = EffectivePerformanceSalaryInput.GetEditingRows(Convert.ToInt32(year.EditValue), Convert.ToInt32(month.EditValue), false);
                List<EffectivePerformanceSalaryInput> list_opposite = EffectivePerformanceSalaryInput.GetEditingRows(Convert.ToInt32(year.EditValue), Convert.ToInt32(month.EditValue), true);

                //检查差异
                bool all_same = true;
                if (list.Count != list.Count)
                {
                    all_same = false;
                }
                else
                {
                    foreach (EffectivePerformanceSalaryInput item in currInputRows)
                    {
                        if (!item.另一人已录入 || item.内容不同的字段.Count > 0)
                        {
                            all_same = false;
                            break;
                        }
                    }
                }
                if (all_same)
                {
                    //转成正式
                    foreach (EffectivePerformanceSalaryInput item in currInputRows)
                    {
                        BecomeEffective(item);
                    }

                    MessageBox.Show("双人录入成功");

                    this.DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    //显示差异
                    gridControl1.DataSource = currInputRows;
                    gridControl1.Refresh();
                    MessageBox.Show("双人录入失败：双人录入不一致或者另外一个人还没有录入");
                }
            }
            MyHelper.WriteLog(LogType.信息, "录入员工实得绩效工资记录", null);
        }
        #endregion

        #region btn添加_Click

        private void btn添加_Click(object sender, EventArgs e)
        {
            List<EmployeeInfo> list = new List<EmployeeInfo>();
            List<SalaryStructure> ssList = SalaryStructure.GetHasPerformanceSalaryEmployees();
            foreach (SalaryStructure ss in ssList)
            {
                EmployeeInfo emp = ss.员工信息;
                if (list.Find(a => a.员工编号 == emp.员工编号) == null)
                    list.Add(emp);
            }
            EmployeePickerForm form = new EmployeePickerForm(list);
            form.OnSelected += OnEmployeeSelectd;
            form.ShowDialog();
        }

        private void OnEmployeeSelectd(object sender, EmployeeInfo emp)
        {
            EffectivePerformanceSalaryInput item = EffectivePerformanceSalaryInput.GetEditing(emp.员工编号, Convert.ToInt32(year.Value), Convert.ToInt32(month.Text), !this.是验证录入);
            if (item == null)
                item = new EffectivePerformanceSalaryInput();
            else
                item = EffectivePerformanceSalaryInput.AddEffectivePerformanceSalaryInput(item.编号, item.员工编号, this.是验证录入);

            item.是验证录入 = this.是验证录入;
            item.员工编号 = emp.员工编号;
            item.姓名 = emp.姓名;
            item.年 = Convert.ToInt32(year.Value);
            item.月 = Convert.ToInt32(month.Text);
            item.录入人 = AccessController.CurrentUser.姓名;
            item.录入时间 = DateTime.Now;
            item.双人录入结果 = null;
            item.Save();
            currInputRows.Add(item);
            gridControl1.RefreshDataSource();
            gridView1.FocusedRowHandle = gridView1.RowCount - 1;

            MyHelper.WriteLog(LogType.信息, "新增员工执行绩效工资录入记录", item.ToString<EffectivePerformanceSalaryInput>());
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
                    EffectivePerformanceSalaryInput currentItem = (EffectivePerformanceSalaryInput)colView.GetFocusedRow();
                    currInputRows.Remove(currentItem);
                    MyHelper.WriteLog(LogType.信息, "删除员工执行绩效工资录入记录", currentItem.ToString<EffectivePerformanceSalaryInput>());
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
            MessageBox.Show("查询成功！");
        }
        #endregion

        #region gridView1_InvalidRowException

        private void gridView1_InvalidRowException(object sender, InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.ThrowException;
        }
        #endregion

        #region gridView1_CustomDrawCell

        private void gridView1_CustomDrawCell(object sender, RowCellCustomDrawEventArgs e)
        {
            e.Appearance.ForeColor = Color.Black;
            e.Appearance.BackColor = Color.Transparent;

            EffectivePerformanceSalaryInput row = gridView1.GetRow(e.RowHandle) as EffectivePerformanceSalaryInput;
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
            EffectivePerformanceSalaryInput row = gridView1.GetRow(e.PrevFocusedRowHandle) as EffectivePerformanceSalaryInput;
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

