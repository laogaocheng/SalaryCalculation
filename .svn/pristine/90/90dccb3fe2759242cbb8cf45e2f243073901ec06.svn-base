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


namespace Hwagain.SalaryCalculation
{
    public partial class AuditingPayDeptReportForm : XtraForm
    {
        AuditingPayByDeptReport report = new AuditingPayByDeptReport();

        //我的日历组
        protected List<CalRunInfo> myCalRunList = new List<CalRunInfo>();
        //我的薪资组
        protected List<PayGroup> myPayGroupList = new List<PayGroup>();
        
        string 当前期间 = "";
        string 当前账号 = "";
        public AuditingPayDeptReportForm()
        {
            // This call is required by the Windows Form Designer.
            InitializeComponent();

            // TODO: Add any initialization after the InitializeComponent call
        }

        #region Init

        void Init()
        {
            myPayGroupList.Clear();
            myCalRunList.Clear();

            DateTime end = DateTime.Today;
            DateTime start = end.AddMonths(-MyHelper.LatestMonths); //最近三个月

            foreach (CalRunInfo cal in CalRunInfo.GetList(start, end))
            {
                foreach (string groupId in cal.薪资组列表)
                {
                    bool enabled = AccessController.CheckPayGroup(groupId);
                    if (enabled)
                    {
                        PayGroup pg = PayGroup.Get(groupId);
                        if (pg != null)
                        {
                            if (myPayGroupList.Find(a => a.英文名 == pg.英文名) == null) myPayGroupList.Add(pg);
                            if (myCalRunList.Find(a => a.日历组编号 == cal.日历组编号) == null) myCalRunList.Add(cal);
                        }
                    }
                }
            }
            ccb发放单位.Properties.Items.Clear();
            foreach (DictionaryEntry entry in PsHelper.GetCompanyTable())
            {
                ImageComboBoxItem item = new ImageComboBoxItem((string)entry.Key, (string)entry.Key);
                ccb发放单位.Properties.Items.Add(item);
            }
            ccb所属公司.Properties.Items.Clear();
            foreach (DictionaryEntry entry in PsHelper.GetCompanyTable())
            {
                ImageComboBoxItem item = new ImageComboBoxItem((string)entry.Key, (string)entry.Key);
                ccb所属公司.Properties.Items.Add(item);
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

        #region AuditingPayDeptReportForm_Load

        private void AuditingPayDeptReportForm_Load(object sender, EventArgs e)
        {
            Init();

            foreach (CalRunInfo group in myCalRunList)
            {
                ImageComboBoxItem item = new ImageComboBoxItem((string)group.日历组名称, group.日历组编号);
                cbb日历组.Properties.Items.Add(item);
            }
            documentViewer1.PrintingSystem = report.PrintingSystem;
            report.CreateDocument(true);
        }
        #endregion

        #region 加载数据

        protected void LoadData(string searchScope)
        {
            string calRunId = cbb日历组.EditValue as string;

            CreateWaitDialog("正在查询...", "请稍等");

            List<PrivateSalary> rows = new List<PrivateSalary>();

            foreach (PayGroup payGroup in AccessController.我管理的薪资组)
            {
                SalaryAuditingResult checkInfo = SalaryAuditingResult.GetSalaryAuditingResult(payGroup.英文名, calRunId);
                if (checkInfo != null)
                {
                    rows.AddRange(PrivateSalary.GetPrivateSalarys(payGroup.英文名, calRunId));
                }
            }
            switch (searchScope)
            {
                case "按发放单位":
                    rows = rows.FindAll(a => a.基础工资表.财务公司 == (string)ccb发放单位.EditValue);
                    break;
                case "按所属公司":
                    rows = rows.FindAll(a => a.基础工资表.财务公司 == (string)ccb发放单位.EditValue && a.基础工资表.公司名称 == (string)ccb所属公司.EditValue);
                    break;
                default:
                    break;
            }
            //排序
            rows = rows.OrderBy(a => a.基础工资表.财务公司).ThenBy(a => a.基础工资表.财务部门序号).ThenBy(a => a.基础工资表.员工序号).ToList();

            CreateWaitDialog("正在加载...", "请稍等");

            report.DataSource = rows ;
            report.CreateDocument(true);
            
            CloseWaitDialog();

            CalRunInfo cal = CalRunInfo.Get(calRunId);
            当前期间 = String.Format("{0}年{1}", cal.年度, cal.月份) + "月";
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
            btn另存为.Enabled = AccessController.CheckDownloadReport();
        }
        #endregion

        #region btn按日历组查询_Click

        private void btn按日历组查询_Click(object sender, EventArgs e)
        {
            LoadData("按日历组");
        }
        #endregion

        #region imageComboBoxEdit1_SelectedValueChanged

        private void imageComboBoxEdit1_SelectedValueChanged(object sender, EventArgs e)
        {
            SetButtonEnabled();
        }
        #endregion

        #region btn另存为_Click

        private void btn另存为_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = String.Format("{0}工资发放表", 当前期间, 当前账号).Replace("账号", "");
            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string filename = saveFileDialog1.FileName;
                report.ExportToXls(filename);
            }
        }
        #endregion

        #region btn打印_Click

        private void btn打印_Click(object sender, EventArgs e)
        {
            ReportPrintTool tool = new ReportPrintTool(report);
            tool.PrintDialog();
        }
        #endregion

        private void btn按发放单位查询_Click(object sender, EventArgs e)
        {
            LoadData("按发放单位");
        }

        private void btn按公司查询_Click(object sender, EventArgs e)
        {
            LoadData("按所属公司");
        }

    }

}

