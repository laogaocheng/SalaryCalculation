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
    public partial class EditSalaryStructureListForm : XtraForm
    {
        bool showDifferent = false;
        bool isCheck = false;
        protected List<SalaryStructureEntry> currEntryRows = new List<SalaryStructureEntry>();
        protected SalaryStructureEntry currSalaryStructureEntry = null;//当前记录

        public EditSalaryStructureListForm(bool isCheck)
        {
            // This call is required by the Windows Form Designer.
            InitializeComponent();

            // TODO: Add any initialization after the InitializeComponent call
            this.isCheck = isCheck;
        }

        private void EditSalaryStructureForm_Load(object sender, EventArgs e)
        {
            this.Text = "员工薪酬结构录入 - " + (isCheck  ? "验证录入" : "初次录入");
            showDifferent = false;
            LoadData();
        }

        #region 加载数据

        protected void LoadData()
        {
            showDifferent = false;
            //清除原来的数据
            currEntryRows = SalaryStructureEntry.GetEditingRows(isCheck);
            currEntryRows = currEntryRows.OrderBy(a => a.录入时间).ThenBy(a => a.员工编号).ToList();
            gridControl1.DataSource = currEntryRows;
            gridControl1.RefreshDataSource();
            gridControl1.Refresh();
        }

        #endregion

        #region Submit

        private void Submit()
        {
            bool isSameEditor = false;
            List<SalaryStructureEntry> ssList = SalaryStructureEntry.GetEditingRows(false);
            List<SalaryStructureEntry> ssList_opposite = SalaryStructureEntry.GetEditingRows(true);
            //检查是否录入完成
            foreach (SalaryStructureEntry sse in ssList)
            {
                if (sse.开始执行日期 == DateTime.MinValue)
                {
                    MessageBox.Show("请全部录入完成以后再提交");
                    return;
                }
            }
            //检查是否同一人录入
            foreach (SalaryStructureEntry sse in ssList)
            {
                if (sse.另一人录入的记录 != null)
                {
                    sse.CompareInputContent();
                    string editor = sse.录入人;
                    string editor_opposite = sse.另一人录入的记录.录入人.Trim();
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
                foreach (SalaryStructureEntry sse in ssList)
                {
                    if (!sse.另一人已录入 || sse.内容不同的字段.Count > 0)
                    {
                        all_same = false;
                        break;
                    }
                }
            }
            if (all_same)
            {
                //转成正式
                foreach (SalaryStructureEntry sse in ssList)
                {
                    sse.UpdateToFormalTable();
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
            SearchEmployeeInfoForm form = new SearchEmployeeInfoForm();
            form.OnSelected += OnEmployeeSelectd;
            form.单选 = false; 
            form.ShowDialog();
        }

        private void OnEmployeeSelectd(object sender, EmployeeInfo emp)
        {
            SalaryStructureEntry item = new SalaryStructureEntry();

            item.标识 = Guid.NewGuid();
            item.员工编号 = emp.员工编号;
            item.是验证录入 = false;
            
            item.Save();

            currEntryRows.Add(item);

            gridControl1.RefreshDataSource();
            bandedGridView1.FocusedRowHandle = bandedGridView1.RowCount - 1;

            MyHelper.WriteLog(LogType.信息, "新增员工薪酬结构录入记录", item.ToString<SalaryStructureEntry>());
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
                    SalaryStructureEntry currentItem = (SalaryStructureEntry)colView.GetFocusedRow();
                    currEntryRows.Remove(currentItem);
                    MyHelper.WriteLog(LogType.信息, "删除员工薪酬结构录入记录", currentItem.ToString<SalaryStructureEntry>());
                    gridControl1.RefreshDataSource();

                    SalaryStructureEntry.ClearSalaryStructureEntry(currentItem.员工编号);

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

            SalaryStructureEntry row = bandedGridView1.GetRow(e.RowHandle) as SalaryStructureEntry;
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
            SalaryStructureEntry row = bandedGridView1.GetRow(e.PrevFocusedRowHandle) as SalaryStructureEntry;
            if (row != null)
            {                
                row.GetModifiyFields();
            }
        }
        #endregion

        #region bandedGridView1_CellValueChanging

        private void bandedGridView1_CellValueChanging(object sender, CellValueChangedEventArgs e)
        {
            SalaryStructureEntry row = bandedGridView1.GetRow(e.RowHandle) as SalaryStructureEntry;

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
            SalaryStructureEntry item = bandedGridView1.GetRow(bandedGridView1.FocusedRowHandle) as SalaryStructureEntry;
            if (item != null) Edit(item);
        }
        #endregion

        #region bandedGridView1_RowCellClick

        private void bandedGridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            SalaryStructureEntry item = bandedGridView1.GetRow(bandedGridView1.FocusedRowHandle) as SalaryStructureEntry;
            if (item != null && e.Column.Caption == "录入") Edit(item);
        }

        private void Edit(SalaryStructureEntry item)
        {
            EditSalaryStructureForm form = new EditSalaryStructureForm(item);
            //如果录入成功
            if (form.ShowDialog() == DialogResult.OK) LoadData();
        }

        #endregion
    }

}

