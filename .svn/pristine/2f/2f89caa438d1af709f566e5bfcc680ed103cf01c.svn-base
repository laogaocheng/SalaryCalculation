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
using Hwagain.SalaryCalculation.Components.Reports;
using DevExpress.XtraReports.UI;
using DevExpress.XtraPrinting;
using Aspose.Cells;

namespace Hwagain.SalaryCalculation
{
    public partial class MyRembursementSalaryListForm : XtraForm
    {
        protected RembursementSalary currRembursementSalary = null;

        public MyRembursementSalaryListForm(RembursementSalary rs)
        {
            // This call is required by the Windows Form Designer.
            InitializeComponent();

            // TODO: Add any initialization after the InitializeComponent call
            currRembursementSalary = rs;
        }

        private void EditRembursementSalaryForm_Load(object sender, EventArgs e)
        {            
            LoadData();
        }

        #region 加载数据

        protected void LoadData()
        {
            lbl姓名.Text = "姓名：" + currRembursementSalary.姓名;
            lbl部门.Text = "部门：" + currRembursementSalary.部门;
            lbl职务.Text = "职务：" + currRembursementSalary.职务;
            lbl职等.Text = "职等：" + currRembursementSalary.职等;

            gridControl1.DataSource = currRembursementSalary.发放明细表;
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
            MonthlyRembursementSalaryItem item = bandedGridView1.GetRow(bandedGridView1.FocusedRowHandle) as MonthlyRembursementSalaryItem;
            if (item != null && e.Column.Caption == "打印")
            {
                RembursementSalaryVoucher report = new RembursementSalaryVoucher(item);
                ReportPrintTool tool = new ReportPrintTool(report);
                tool.PrintDialog();
            }
        }

        private void btn导出_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = "【报账工资】个人实际发放明细表";
            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string filename = saveFileDialog1.FileName;
                XlsExportOptions options = new XlsExportOptions();
                options.SheetName = "【报账工资】个人实际发放明细表";
                options.RawDataMode = false;
                bandedGridView1.ExportToXls(filename, options);

                Aspose.Cells.Workbook workbook = new Aspose.Cells.Workbook(filename);
                Worksheet sheet = workbook.Worksheets[0];
                sheet.AutoFitColumns();
                workbook.Save(filename);
            }
        }
    }

}

