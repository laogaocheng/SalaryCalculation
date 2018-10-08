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
    public partial class SearchRembursementSalaryForm : XtraForm
    {
        protected List<RembursementSalary> all_rows = new List<RembursementSalary>();
        protected List<RembursementSalary> filter_rows = new List<RembursementSalary>();
        
        public SearchRembursementSalaryForm()
        {
            // This call is required by the Windows Form Designer.
            InitializeComponent();

            // TODO: Add any initialization after the InitializeComponent call
        }

        private void EditRembursementSalaryForm_Load(object sender, EventArgs e)
        {
            this.Text = "员工报账工资查询";
            all_rows = RembursementSalary.GetEffectiveRembursementSalarys();
            LoadData(null);
        }

        #region 加载数据

        protected void LoadData(string keyword)
        {
            if (string.IsNullOrEmpty(keyword))
                filter_rows = all_rows.OrderBy(a => a.创建时间).ThenBy(a => a.员工编号).ToList();
            else
            {
                filter_rows = all_rows.FindAll(a => a.姓名.IndexOf(keyword) != -1).OrderBy(a => a.创建时间).ThenBy(a => a.员工编号).ToList();
            }
            gridControl1.DataSource = filter_rows;
            gridControl1.RefreshDataSource();
            gridControl1.Refresh();
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

        }
        #endregion

        #region bandedGridView1_FocusedRowChanged

        private void bandedGridView1_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            RembursementSalary row = bandedGridView1.GetRow(e.PrevFocusedRowHandle) as RembursementSalary;
            if (row != null)
            {                
               
            }
        }
        #endregion

        #region bandedGridView1_CellValueChanging

        private void bandedGridView1_CellValueChanging(object sender, CellValueChangedEventArgs e)
        {
            RembursementSalary row = bandedGridView1.GetRow(e.RowHandle) as RembursementSalary;

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

        }
        #endregion

        #region bandedGridView1_RowCellClick

        private void bandedGridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {

        }
        #endregion

        private void btn查询_Click(object sender, EventArgs e)
        {
            LoadData(textEdit关键字.Text.Trim());
        }
    }

}

