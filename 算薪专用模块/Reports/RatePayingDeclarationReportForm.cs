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


namespace Hwagain.SalaryCalculation
{
    public partial class RatePayingDeclarationReportForm : XtraForm
    {
        RatePayingDeclarationReport report = new RatePayingDeclarationReport();
        
        string 当前期间 = "";
        string 当前账号 = "";
        public RatePayingDeclarationReportForm()
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

        #region RatePayingDeclarationReportForm_Load

        private void RatePayingDeclarationReportForm_Load(object sender, EventArgs e)
        {
            Init();

            documentViewer1.PrintingSystem = report.PrintingSystem;
            report.CreateDocument(false);

            SetButtonEnabled();

        }
        #endregion

        #region 加载数据

        protected void LoadData()
        {
            CreateWaitDialog("正在查询...", "请稍等");

            List<PersonalTax> rows = PersonalTax.GetPersonalTaxList(Convert.ToInt32(year.Value), Convert.ToInt32(month.Text), (string)ccb发放单位.EditValue);
            //排序
            rows = rows.OrderBy(a => a.上表工资.财务公司).ThenBy(a => a.上表工资.财务部门序号).ThenBy(a => a.上表工资.员工序号).ToList();

            CreateWaitDialog("正在加载...", "请稍等");
            report.工资表 = rows;
            report.DataSource = rows;
            report.GetTotalTax();
            report.CreateDocument(false);

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
            saveFileDialog1.FileName = String.Format("{0}{1}纳税申报表", (string)ccb发放单位.EditValue, 当前期间);
            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string filename = saveFileDialog1.FileName;
                report.ExportToXls(filename);
            }
        }
        #endregion

        #region btn按发放单位查询_Click

        private void btn按发放单位查询_Click(object sender, EventArgs e)
        {
            btn按发放单位查询.Enabled = false;
            LoadData();
            btn按发放单位查询.Enabled = true;
        }
        #endregion

    }

}

