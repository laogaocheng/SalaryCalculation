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
    public partial class SalaryCaluReportForm : XtraForm
    {
        protected List<PrivateSalary> currRows = new List<PrivateSalary>();

        //我的日历组
        protected List<CalRunInfo> myCalRunList = new List<CalRunInfo>();
        //我的薪资组
        protected List<PayGroup> myPayGroupList = new List<PayGroup>();

        public SalaryCaluReportForm()
        {
            // This call is required by the Windows Form Designer.
            InitializeComponent();

            // TODO: Add any initialization after the InitializeComponent call
        }

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

        #region EditPersonPayRateForm_Load

        private void EditPersonPayRateForm_Load(object sender, EventArgs e)
        {
            Init();

            foreach (CalRunInfo group in myCalRunList)
            {
                ImageComboBoxItem item = new ImageComboBoxItem((string)group.日历组名称, group.日历组编号);
                cbb日历组.Properties.Items.Add(item);
            }
        }
        #endregion

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
        
        #region 加载数据

        protected void LoadData()
        {
            LoadData(false);
        }

        protected void LoadData(bool onlyPayGroup)
        {  
            currRows.Clear();

            CreateWaitDialog("正在查询...", "请稍等");
            //清除原来的数据
            List<PrivateSalary> rows = PrivateSalary.GetPrivateSalarys(null, (string)cbb日历组.EditValue);
            foreach (PrivateSalary row in rows)
            {
                if (myPayGroupList.Find(a => a.英文名 == row.薪资组.Trim()) != null) currRows.Add(row);
            }
            if (onlyPayGroup)
            {
                currRows = currRows.FindAll(a => a.薪资组 == (string)cb薪资组.EditValue);
                SetButtonEnabled();
            }
            //排序
            currRows = currRows.OrderBy(a => a.基础工资表.财务公司).ThenBy(a => a.基础工资表.财务部门序号).ThenBy(a => a.基础工资表.员工序号).ToList();

            CreateWaitDialog("正在加载...", "请稍等");

            gridControl1.DataSource = currRows;
            gridControl1.RefreshDataSource();

            CloseWaitDialog();

            SetButtonEnabled();

            gridView1.ExpandAllGroups();
        }

        #endregion

        #region SetButtonEnabled

        void SetButtonEnabled()
        {
            SalaryAuditingResult auditingResult = SalaryAuditingResult.GetSalaryAuditingResult((string)cb薪资组.EditValue, (string)cbb日历组.EditValue);
           
            SetButtonEnabledByRight();
        }
        #endregion

        #region SetButtonEnabledByRight

        void SetButtonEnabledByRight()
        {
            
        }
        #endregion

        #region btn按薪资组查询_Click

        private void btn按薪资组查询_Click(object sender, EventArgs e)
        {
            LoadData(true);
        }
        #endregion

        #region cb薪资组_SelectedValueChanged

        private void cb薪资组_SelectedValueChanged(object sender, EventArgs e)
        {
            SetButtonEnabled();
        }
        #endregion

        #region cbb日历组_SelectedValueChanged

        private void cbb日历组_SelectedValueChanged(object sender, EventArgs e)
        {
            SetButtonEnabled();
        }
        #endregion

        #region gridView1_DoubleClick

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            SalaryResult row = gridView1.GetRow(gridView1.FocusedRowHandle) as SalaryResult;
            if (row != null)
            {
                //显示分类明细
                PublicPayCategoryDetailReportForm form = new PublicPayCategoryDetailReportForm();
                form.View = gridView1;

                form.ShowDialog();
            }
        }
        #endregion

        #region cbb日历组_SelectedIndexChanged

        private void cbb日历组_SelectedIndexChanged(object sender, EventArgs e)
        {
            cb薪资组.Properties.Items.Clear();
            CalRunInfo cal = CalRunInfo.Get((string)cbb日历组.EditValue);
            if (cal != null)
            {
                foreach (string groupId in cal.薪资组列表)
                {
                    bool enabled = AccessController.CheckPayGroup(groupId);
                    if (enabled)
                    {
                        PayGroup pg = PayGroup.Get(groupId);
                        if (pg != null)
                        {
                            ImageComboBoxItem item = new ImageComboBoxItem(pg.中文名, groupId);
                            cb薪资组.Properties.Items.Add(item);
                        }
                    }
                }
            }
        }
        #endregion

        #region btn按日历组查询_Click

        private void btn按日历组查询_Click(object sender, EventArgs e)
        {
            LoadData();
        }
        #endregion
    }

}

