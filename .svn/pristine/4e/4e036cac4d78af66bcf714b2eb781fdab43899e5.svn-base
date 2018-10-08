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
using DevExpress.XtraReports.UI;
using Hwagain.SalaryCalculation.Components.Reports;

namespace Hwagain.SalaryCalculation
{
    public partial class MyMonthlyWageLoanItemListForm : XtraForm
    {
        
        protected WageLoan currWageLoan = null;

        public MyMonthlyWageLoanItemListForm(WageLoan wageLoan)
        {
            // This call is required by the Windows Form Designer.
            InitializeComponent();

            // TODO: Add any initialization after the InitializeComponent call
            this.currWageLoan = wageLoan;
        }

        private void EditMonthlyWageLoanItemForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        #region 加载数据

        protected void LoadData()
        {
            lbl姓名.Text = "姓名：" + currWageLoan.姓名;
            lbl部门.Text = "部门：" + currWageLoan.部门;
            lbl职务.Text = "职务：" + currWageLoan.职务;
            lbl职等.Text = "职等：" + currWageLoan.职等;

            gridControl1.DataSource = currWageLoan.发放明细表;
            gridControl1.RefreshDataSource();
            gridControl1.Refresh();
        }

        #endregion

        private void bandedGridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
                e.Info.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            }
        }

        private void bandedGridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            MonthlyWageLoanItem item = bandedGridView1.GetRow(bandedGridView1.FocusedRowHandle) as MonthlyWageLoanItem;
            if (item != null && e.Column.Caption == "打印")
            {
                WageLoanVoucher report = new WageLoanVoucher(item);
                ReportPrintTool tool = new ReportPrintTool(report);
                tool.PrintDialog();
            }
        }
    }
}

