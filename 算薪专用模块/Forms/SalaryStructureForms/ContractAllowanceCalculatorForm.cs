﻿using System;
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
using Hwagain.SalaryCalculation.Components.Reports;
using DevExpress.XtraReports.UI;

namespace Hwagain.SalaryCalculation
{
    public partial class ContractAllowanceCalculatorForm : XtraForm
    {
        protected List<MonthlyContractAllowanceItem> all_rows = new List<MonthlyContractAllowanceItem>();

        public ContractAllowanceCalculatorForm()
        {
            // This call is required by the Windows Form Designer.
            InitializeComponent();

            // TODO: Add any initialization after the InitializeComponent call
            DateTime prevMonth = DateTime.Today.AddMonths(-1);
            year.EditValue = prevMonth.Year;
            month.EditValue = prevMonth.Month;
        }

        private void EditContractAllowanceForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        #region 加载数据

        protected void LoadData()
        {
            all_rows = MonthlyContractAllowanceItem.GetMonthlyContractAllowanceItems(Convert.ToInt32(year.Value), Convert.ToInt32(month.EditValue));
            all_rows = all_rows.OrderByDescending(a => a.月津贴标准).ThenBy(a => a.部门).ThenBy(a => a.职务).ToList();
            gridControl1.DataSource = all_rows;
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
            ContractAllowance row = bandedGridView1.GetRow(e.PrevFocusedRowHandle) as ContractAllowance;
            if (row != null)
            {                
                
            }
        }
        #endregion

        #region bandedGridView1_CellValueChanging

        private void bandedGridView1_CellValueChanging(object sender, CellValueChangedEventArgs e)
        {
            ContractAllowance row = bandedGridView1.GetRow(e.RowHandle) as ContractAllowance;

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
            ShowPrintDialog();
        }

        #endregion

        #region bandedGridView1_RowCellClick

        private void bandedGridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (e.Column.Caption == "打印") ShowPrintDialog();
        }

        #endregion

        private void textEdit关键字_EditValueChanged(object sender, EventArgs e)
        {

        }
        private void bandedGridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
                e.Info.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            }
        }

        private void ShowPrintDialog()
        {
            MessageBox.Show("待开发");
        }

        private void year_EditValueChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void month_EditValueChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btn计算_Click(object sender, EventArgs e)
        {
            ContractAllowance.AutoGenerateMonthlyContractAllowanceItems(Convert.ToInt32(year.Value), Convert.ToInt32(month.EditValue));
            LoadData();
        }
    }

}

