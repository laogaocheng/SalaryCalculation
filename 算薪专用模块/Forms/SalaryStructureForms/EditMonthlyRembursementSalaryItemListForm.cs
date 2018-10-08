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
    public partial class EditMonthlyRembursementSalaryItemListForm : XtraForm
    {
        bool showDifferent = false;
        bool isCheck = false;
        int year;
        int month;
        protected List<MonthlyRembursementSalaryItemEntry> currEntryRows = new List<MonthlyRembursementSalaryItemEntry>();
        protected MonthlyRembursementSalaryItemEntry currMonthlyRembursementSalaryItemEntry = null;//当前记录

        public EditMonthlyRembursementSalaryItemListForm(bool isCheck)
        {
            // This call is required by the Windows Form Designer.
            InitializeComponent();

            // TODO: Add any initialization after the InitializeComponent call
            this.isCheck = isCheck;
            //获取最后一次上表工资的日期
            DateTime date = SalaryResult.GetLastSalaryDate(null);
            year = date.Year;
            month = date.Month;

            comboBoxEdit年.Properties.Items.Add(year);
            comboBoxEdit年.Properties.Items.Add(year - 1);

            comboBoxEdit年.EditValue = year;
            comboBoxEdit月.EditValue = month;
        }

        private void EditMonthlyRembursementSalaryItemForm_Load(object sender, EventArgs e)
        {
            this.Text = "员工每月报账工资录入 - " + (isCheck  ? "验证录入" : "初次录入");
            showDifferent = false;
            LoadData();
        }

        #region 加载数据

        protected void LoadData()
        {
            showDifferent = false;
            //清除原来的数据
            currEntryRows = MonthlyRembursementSalaryItemEntry.GetEditingRows(year, month, isCheck);
            currEntryRows = currEntryRows.OrderBy(a=>a.录入时间).ThenBy(a => a.员工编号).ToList();
            gridControl1.DataSource = currEntryRows;
            gridControl1.RefreshDataSource();
            gridControl1.Refresh();
        }

        #endregion

        #region Submit

        private void Submit()
        {
            bool isSameEditor = false;
            List<MonthlyRembursementSalaryItemEntry> ssList = MonthlyRembursementSalaryItemEntry.GetEditingRows(year, month, false);
            List<MonthlyRembursementSalaryItemEntry> ssList_opposite = MonthlyRembursementSalaryItemEntry.GetEditingRows(year, month, true);
            //检查是否录入完成
            foreach (MonthlyRembursementSalaryItemEntry mrs in ssList)
            {
                if(mrs.实际报账金额 == 0)
                {
                    MessageBox.Show("请全部录入完成以后再提交");
                    return;
                }
            }
            //检查是否同一人录入
            foreach (MonthlyRembursementSalaryItemEntry mrs in ssList)
            {
                if (mrs.另一人录入的记录 != null)
                {
                    mrs.CompareInputContent();
                    string editor = mrs.录入人;
                    string editor_opposite = mrs.另一人录入的记录.录入人.Trim();
                    if (editor == editor_opposite && editor_opposite != "")
                    {
                        isSameEditor = true;
                        break;
                    }
                }
            }

            gridControl1.Refresh();

            if (isSameEditor)
            {
                MessageBox.Show("两次录入不能是同一个人");
                return;
            }

            //检查差异
            bool all_same = true;
            if (ssList.Count != ssList_opposite.Count)
            {
                all_same = false;
            }
            else
            {
                foreach (MonthlyRembursementSalaryItemEntry wle in ssList)
                {
                    if (!wle.另一人已录入 || wle.内容不同的字段.Count > 0)
                    {
                        all_same = false;
                        break;
                    }
                }
            }
            if (all_same)
            {
                //转成正式
                foreach (MonthlyRembursementSalaryItemEntry wle in ssList)
                {
                    wle.UpdateToFormalTable();
                }

                MessageBox.Show("双人录入成功");

                this.DialogResult = DialogResult.OK;
                LoadData();
                Close();
            }
            else
            {
                MessageBox.Show("双人录入失败：双人录入不一致或者另外一个人还没有录入");
            }
        }
        #endregion

        #region btn保存_Click

        private void btn保存_Click(object sender, EventArgs e)
        {
            showDifferent = true;
            Submit();            
        }
        #endregion

        #region btn添加_Click

        private void btn添加_Click(object sender, EventArgs e)
        {
            List<EmployeeInfo> list = new List<EmployeeInfo>();
            //获取正在执行的报账工资标准
            List<RembursementSalary> rsList = RembursementSalary.GetEffectiveRembursementSalarys();
            foreach(RembursementSalary rs in rsList)
            {
                EmployeeInfo emp = rs.员工信息;
                if (list.Find(a => a.员工编号 == emp.员工编号) == null)
                    list.Add(emp);
            }
            EmployeePickerForm form = new EmployeePickerForm(list);
            form.OnSelected += OnEmployeeSelectd;
            form.ShowDialog();
        }

        private void OnEmployeeSelectd(object sender, EmployeeInfo emp)
        {
            if (currEntryRows.Find(a => a.员工编号 == emp.员工编号) == null)
            {
                MonthlyRembursementSalaryItemEntry item = MonthlyRembursementSalaryItemEntry.AddMonthlyRembursementSalaryItemEntry(emp.员工编号, emp.姓名, year, month, isCheck);
                //如果记录已生效，清除生效标记
                if(item.已生效)
                {
                    item.生效时间 = DateTime.MinValue;
                    item.Save();

                    MonthlyRembursementSalaryItemEntry opposite = item.另一人录入的记录;
                    if (opposite != null)
                    {
                        opposite.生效时间 = DateTime.MinValue;
                        opposite.Save();
                    }
                }
                //更新上月剩余金额
                MonthlyRembursementSalaryItem lastMonthItem = item.上月发放记录;
                if (lastMonthItem != null)
                {
                    item.上月剩余金额 = lastMonthItem.本月剩余可报账金额;                    
                    //如果上个月是1月
                    if (lastMonthItem.月 == 12)
                    {
                        item.上年剩余金额 = lastMonthItem.本年剩余可报账金额;
                    }
                    else
                    {
                        item.上年剩余金额 = lastMonthItem.上年剩余可报账金额;
                    }
                    item.Save();
                    //更新对向
                    MonthlyRembursementSalaryItemEntry opposite = item.另一人录入的记录;
                    if (opposite != null)
                    {
                        opposite.上月剩余金额 = item.上月剩余金额;
                        opposite.上年剩余金额 = item.上年剩余金额;
                        opposite.Save();
                    }
                }
                currEntryRows.Add(item);
                gridControl1.RefreshDataSource();
                bandedGridView1.FocusedRowHandle = bandedGridView1.RowCount - 1;

                MyHelper.WriteLog(LogType.信息, "新增员工每月报账工资录入记录", item.ToString<MonthlyRembursementSalaryItemEntry>());
            }
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
                    MonthlyRembursementSalaryItemEntry currentItem = (MonthlyRembursementSalaryItemEntry)colView.GetFocusedRow();
                    currEntryRows.Remove(currentItem);
                    MyHelper.WriteLog(LogType.信息, "删除员工每月报账工资录入记录", currentItem.ToString<MonthlyRembursementSalaryItemEntry>());
                    gridControl1.RefreshDataSource();

                    MonthlyRembursementSalaryItemEntry.ClearMonthlyRembursementSalaryItemEntry(currentItem.员工编号, year, month);

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

        #region bandedGridView1_InvalidRowException

        private void bandedGridView1_InvalidRowException(object sender, InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.ThrowException;
        }
        #endregion

        #region bandedGridView1_CellValueChanged

        private void bandedGridView1_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            
        }
        #endregion

        #region bandedGridView1_CustomDrawCell

        private void bandedGridView1_CustomDrawCell(object sender, RowCellCustomDrawEventArgs e)
        {
            if (showDifferent == false) return;

            e.Appearance.ForeColor = Color.Black;
            e.Appearance.BackColor = Color.Transparent;

            MonthlyRembursementSalaryItemEntry row = bandedGridView1.GetRow(e.RowHandle) as MonthlyRembursementSalaryItemEntry;
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

        #region bandedGridView1_FocusedRowChanged

        private void bandedGridView1_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            MonthlyRembursementSalaryItemEntry row = bandedGridView1.GetRow(e.PrevFocusedRowHandle) as MonthlyRembursementSalaryItemEntry;
            if (row != null)
            {                
                row.GetModifiyFields();
            }
        }
        #endregion

        #region bandedGridView1_CellValueChanging

        private void bandedGridView1_CellValueChanging(object sender, CellValueChangedEventArgs e)
        {
            MonthlyRembursementSalaryItemEntry row = bandedGridView1.GetRow(e.RowHandle) as MonthlyRembursementSalaryItemEntry;

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
                BaseEdit editor = bandedGridView1.ActiveEditor;
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

        #region bandedGridView1_CustomRowCellEditForEditing

        private void bandedGridView1_CustomRowCellEditForEditing(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {            
        }

        private void comboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            BaseEdit editor = bandedGridView1.ActiveEditor as BaseEdit;
        }
        #endregion

        #region bandedGridView1_DoubleClick

        private void bandedGridView1_DoubleClick(object sender, EventArgs e)
        {
            MonthlyRembursementSalaryItemEntry item = bandedGridView1.GetRow(bandedGridView1.FocusedRowHandle) as MonthlyRembursementSalaryItemEntry;
            if (item != null) Edit(item);
        }
        #endregion

        #region bandedGridView1_RowCellClick

        private void bandedGridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            MonthlyRembursementSalaryItemEntry item = bandedGridView1.GetRow(bandedGridView1.FocusedRowHandle) as MonthlyRembursementSalaryItemEntry;
            if (item != null && e.Column.Caption == "录入") Edit(item);
        }

        private void Edit(MonthlyRembursementSalaryItemEntry item)
        {
            EditMonthlyRembursementSalaryItemForm form = new EditMonthlyRembursementSalaryItemForm(item);
            //如果录入成功
            if (form.ShowDialog() == DialogResult.OK) LoadData();
        }

        #endregion

        private void comboBoxEdit年_SelectedValueChanged(object sender, EventArgs e)
        {
            year = Convert.ToInt32(comboBoxEdit年.EditValue);
            LoadData();
        }

        private void comboBoxEdit月_SelectedValueChanged(object sender, EventArgs e)
        {
            month = Convert.ToInt32(comboBoxEdit月.EditValue);
            LoadData();
        }
    }

}

