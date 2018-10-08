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


namespace Hwagain.SalaryCalculation
{
    public partial class PayDeptReportForm : XtraForm
    {
        //我的日历组
        protected List<CalRunInfo> myCalRunList = new List<CalRunInfo>();
        //我的薪资组
        protected List<PayGroup> myPayGroupList = new List<PayGroup>();


        protected List<PrivateSalary> currRows = new List<PrivateSalary>();
        string 当前期间 = "";
        string 当前账号 = "";
        public PayDeptReportForm()
        {
            // This call is required by the Windows Form Designer.
            InitializeComponent();
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

        #region PayDeptReportForm_Load

        private void PayDeptReportForm_Load(object sender, EventArgs e)
        {
            Init();

            foreach (CalRunInfo group in myCalRunList)
            {
                ImageComboBoxItem item = new ImageComboBoxItem((string)group.日历组名称, group.日历组编号);
                cbb日历组.Properties.Items.Add(item);
            }
        }
        #endregion

        #region 加载数据

        protected void LoadData()
        {
            string accType = cb账户类型.EditValue as string;
            string calRunId = cbb日历组.EditValue as string;

            CreateWaitDialog("正在查询...", "请稍等");
            
            List<PrivateSalary> rows = new List<PrivateSalary>();

            string errMsg = "";
            foreach (PayGroup payGroup in myPayGroupList)
            {
                SalaryAuditingResult checkInfo = SalaryAuditingResult.GetSalaryAuditingResult(payGroup.英文名, calRunId);
                if (checkInfo != null)
                {
                    if (checkInfo.已审核)
                    {
                        rows.AddRange(PrivateSalary.GetPrivateSalarys(payGroup.英文名, calRunId));
                        continue;
                    }
                    else
                    {
                        errMsg = String.Format("薪资组【{0}】的工资表未审核\n", payGroup.中文名);
                    }
                }
            }

            if (errMsg != "")
            {
                CloseWaitDialog();
                MessageBox.Show(errMsg, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //生成报盘记录
            currRows = rows;
            //排序
            currRows = currRows.OrderBy(a => a.基础工资表.财务公司).ThenBy(a => a.基础工资表.财务部门序号).ThenBy(a => a.基础工资表.员工序号).ToList();

            CreateWaitDialog("正在加载...", "请稍等");

            pivotGridControl1.DataSource = currRows;

            CloseWaitDialog();

            CalRunInfo cal = CalRunInfo.Get(calRunId);
            当前期间 = String.Format("{0}年{1}", cal.年度, cal.月份) + "月";
            当前账号 = cb账户类型.Text;
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

        #region btn查询_Click

        private void btn查询_Click(object sender, EventArgs e)
        {
            LoadData();
        }
        #endregion

        #region cb薪资组_SelectedValueChanged

        private void cb薪资组_SelectedValueChanged(object sender, EventArgs e)
        {
            SetButtonEnabled();
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
            saveFileDialog1.FileName = String.Format("{0}{1}部门汇总表", 当前期间, 当前账号).Replace("账号", "");
            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string filename = saveFileDialog1.FileName;
                pivotGridControl1.ExportToXls(filename);
            }
        }
        #endregion

        #region chk显示筛选面板_CheckedChanged

        private void chk显示筛选面板_CheckedChanged(object sender, EventArgs e)
        {
            pivotGridControl1.OptionsView.ShowFilterHeaders = chk显示筛选面板.Checked;
        }
        #endregion

    }

}

