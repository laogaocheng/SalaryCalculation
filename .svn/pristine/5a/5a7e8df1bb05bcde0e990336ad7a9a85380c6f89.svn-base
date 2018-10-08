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
    public partial class PayStepReportForm : XtraForm
    {
        //我的日历组
        protected List<CalRunInfo> myCalRunList = new List<CalRunInfo>();
        //我的薪资组
        protected List<PayGroup> myPayGroupList = new List<PayGroup>();


        protected List<PrivateSalary> currRows = new List<PrivateSalary>();
        string 当前期间 = "";
        string 当前账号 = "";

        public PayStepReportForm()
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
        }
        #endregion

        #region 加载数据

        protected void LoadData()
        {            
            CreateWaitDialog("正在查询...", "请稍等");
            
            

            CreateWaitDialog("正在加载...", "请稍等");

            pivotGrid各职级收入汇总表.DataSource = currRows;

            CloseWaitDialog();
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
                pivotGrid各职级收入汇总表.ExportToXls(filename);
            }
        }
        #endregion

    }

}

