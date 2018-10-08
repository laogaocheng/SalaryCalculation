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
using System.Linq;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.Utils;
using System.Text;
using System.Threading;
using Hwagain.SalaryCalculation.Components.Models;
using Hwagain.SaleManageSystem.Components.Reports;
using DevExpress.XtraPrinting.Preview;
using DevExpress.XtraPrinting.Control;
using DevExpress.XtraReports.UI;
using Aspose.Cells;
using DevExpress.XtraPrinting;

namespace Hwagain.SalaryCalculation
{
    public partial class PrivateSalaryPayItemsForm : XtraForm
    {
        PrivateSalaryPayItems report = new PrivateSalaryPayItems();
        ZhongXinBankPrivateSalaryPayItems zx_report = new ZhongXinBankPrivateSalaryPayItems();

        string 当前期间 = "";
        string 当前账号 = "";
        public PrivateSalaryPayItemsForm()
        {
            // This call is required by the Windows Form Designer.
            InitializeComponent();

            // TODO: Add any initialization after the InitializeComponent call
        }

        #region Init

        void Init()
        {
            DateTime prevMonth = DateTime.Today.AddMonths(-1);
            year.Value = prevMonth.Year;
            month.EditValue = prevMonth.Month;

            ccb发放单位.Properties.Items.Clear();
            foreach (string company in PsHelper.GetCompanyList())
            {
                ImageComboBoxItem item = new ImageComboBoxItem((string)company, (string)company);
                ccb发放单位.Properties.Items.Add(item);
            }

            ccb银行.Properties.Items.Clear();
            foreach (string bank in PsHelper.GetBankTable().Keys)
            {
                ImageComboBoxItem item = new ImageComboBoxItem((string)bank, (string)bank);
                ccb银行.Properties.Items.Add(item);
            }
        }
        #endregion

        #region CreateWaitDialog

        WaitDialogForm dlg = null;
        public void CreateWaitDialog()
        {
            CreateWaitDialog("正在启动...", "请稍等");
        }
        public void CreateWaitDialog(string caption, string title, Size size)
        {
            CloseWaitDialog();
            dlg = new DevExpress.Utils.WaitDialogForm(caption, title, size);
        }
        public void CreateWaitDialog(string caption, string title)
        {
            CloseWaitDialog();
            dlg = new DevExpress.Utils.WaitDialogForm(caption, title);
        }
        public void SetWaitDialogCaption(string fCaption)
        {
            if (dlg != null)
                dlg.Caption = fCaption;
        }
        public void CloseWaitDialog()
        {
            if (dlg != null)
                dlg.Close();
        }
        #endregion

        #region PrivateSalaryPayItemsForm_Load

        private void PrivateSalaryPayItemsForm_Load(object sender, EventArgs e)
        {
            Init();

            documentViewer1.PrintingSystem = report.PrintingSystem;
            report.CreateDocument(true);

            SetButtonEnabled();
        }
        #endregion

        #region 加载数据

        protected void LoadData()
        {            
            CreateWaitDialog("正在查询...", "请稍等");

            List<PrivateSalary> rows = new List<PrivateSalary>();

            foreach (PayGroup payGroup in AccessController.我管理的薪资组)
            {
                rows.AddRange(PrivateSalary.GetPrivateSalarys(Convert.ToInt32(year.Value), Convert.ToInt32(month.Text), ccb发放单位.Text, payGroup.英文名));
            }
            //过滤
            rows = rows.FindAll(a => a.封闭工资账号.银行名称 == ccb银行.Text).ToList();
            //排序
            rows = rows.OrderBy(a => a.基础工资表.财务公司).ThenBy(a => a.基础工资表.财务部门序号).ThenBy(a => a.基础工资表.员工序号).ToList();

            int currOrder = 1;
            foreach (PrivateSalary item in rows)
            {
                item.序号 = currOrder++;
            }

            CreateWaitDialog("正在加载...", "请稍等");

            if (ccb银行.Text == "中信银行")
            {
                documentViewer1.PrintingSystem = zx_report.PrintingSystem;
                zx_report.银行名称 = ccb银行.Text;
                zx_report.工资表 = rows;
                zx_report.BindData();
                zx_report.CreateDocument(false);
            }
            else
            {
                documentViewer1.PrintingSystem = report.PrintingSystem;
                report.银行名称 = ccb银行.Text;
                report.工资表 = rows;
                report.BindData();
                report.CreateDocument(false);
            }
            CloseWaitDialog();

            当前期间 = String.Format("{0}年{1}", year.Value, month.Text) + "月";
        }

        #endregion

        #region SetButtonEnabled

        void SetButtonEnabled()
        {
            SetButtonEnabledByRight();
        }
        #endregion

        #region SetButtonEnabledByRight

        void SetButtonEnabledByRight()
        {
            //btn另存为.Enabled = AccessController.CheckDownloadReport();
        }
        #endregion

        #region btn另存为_Click

        private void btn另存为_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = String.Format("{0}职工封闭工资发放清单", 当前期间, 当前账号).Replace("账号", "");
            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                XlsExportOptions options = new XlsExportOptions(TextExportMode.Text);
                string filename = saveFileDialog1.FileName;
                if (ccb银行.Text == "中信银行")
                {
                    zx_report.ExportToXls(filename, options);
                }
                else
                    report.ExportToXls(filename, options);
            }
        }
        #endregion

        #region btn打印_Click

        private void btn打印_Click(object sender, EventArgs e)
        {
            if (ccb银行.Text == "中信银行")
            {
                ReportPrintTool tool = new ReportPrintTool(zx_report);
                tool.PrintDialog();
            }
            else
            {
                ReportPrintTool tool = new ReportPrintTool(report);
                tool.PrintDialog();
            }
        }
        #endregion

        #region 按发放单位查询

        private void btn按发放单位查询_Click(object sender, EventArgs e)
        {
            btn按发放单位查询.Enabled = false;
            LoadData();
            btn按发放单位查询.Enabled = true;
        }
        #endregion
    }

}

