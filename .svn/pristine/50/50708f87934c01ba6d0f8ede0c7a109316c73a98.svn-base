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
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.Utils;
using System.Text;
using System.Linq;
using System.Threading;
using Hwagain.SalaryCalculation.Components.Models;
using log4net;
using Hwagain.SalaryCalculation.Components.Forms.ListForms;


namespace Hwagain.SalaryCalculation
{
    public partial class PublicPayReportForm : XtraForm
    {        
        protected List<SalaryResult> currRows = new List<SalaryResult>();
        //我的日历组
        protected List<CalRunInfo> myCalRunList = new List<CalRunInfo>();
        //我的薪资组
        protected List<PayGroup> myPayGroupList = new List<PayGroup>();

        public PublicPayReportForm()
        {
            // This call is required by the Windows Form Designer.
            InitializeComponent();

            // TODO: Add any initialization after the InitializeComponent call
        }

        #region CreateWaitDialog

        WaitDialogForm dlg = null;
        public void CreateWaitDialog()
        {
            CreateWaitDialog("正在启动...", "请稍等...");
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
            List<SalaryResult>  rows = SalaryResult.GetSalaryResults((string)cbb日历组.EditValue);
            foreach (SalaryResult row in rows)
            {
                if (myPayGroupList.Find(a => a.英文名 == row.薪资组.Trim()) != null) currRows.Add(row);
            }
            if (onlyPayGroup)
            {
                currRows = currRows.FindAll(a => a.薪资组 == (string)ccb薪资组.EditValue);
                SetButtonEnabled();
            }
            currRows = currRows.OrderBy(a => a.财务公司).ThenBy(a => a.财务部门序号).ThenBy(a => a.员工序号).ToList();

            CreateWaitDialog("正在加载...", "请稍等");

            gridControl1.DataSource = currRows;
            gridControl1.RefreshDataSource();

            CloseWaitDialog();
            
        }

        #endregion

        #region SetButtonEnabled

        void SetButtonEnabled()
        {
            SalaryAuditingResult auditingResult = SalaryAuditingResult.GetSalaryAuditingResult((string)ccb薪资组.EditValue, (string)cbb日历组.EditValue);

            btn审核.Enabled = auditingResult == null || auditingResult.上表工资已审核 == false;
            btn生成工资表.Enabled = auditingResult != null && auditingResult.已审核 == false && auditingResult.已冻结 == false;
            btn重新同步.Enabled = auditingResult == null || auditingResult.已审核 == false;
            
            SetButtonEnabledByRight();
        }
        #endregion

        #region SetButtonEnabledByRight

        void SetButtonEnabledByRight()
        {
            if (btn审核.Enabled) btn审核.Enabled = AccessController.CheckDoAuditingPublicPay();
            if (btn重新同步.Enabled) btn重新同步.Enabled = AccessController.CheckSyncPsData();
        }
        #endregion

        #region btn查询_Click

        private void btn查询_Click(object sender, EventArgs e)
        {
            LoadData();
            gridView1.ExpandAllGroups();
        }
        #endregion

        #region btn重新同步_Click

        private void btn重新同步_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("重新同步后需重新审核，确实重新同步吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2, 0, false) == DialogResult.Yes)
            {
                Thread.Sleep(200);

                CreateWaitDialog("正在同步...", "请耐心等待");
                //删除历史数据
                SalaryAuditingResult.ClearAuditingResult((string)cbb日历组.EditValue, (string)ccb薪资组.EditValue);
                //删除工资表
                PrivateSalary.ClearPrivateSalary((string)cbb日历组.EditValue, (string)ccb薪资组.EditValue);
                //清除旧的抽查记录
                PayCheckRecord.ClearPayCheckRecord((string)cbb日历组.EditValue, (string)ccb薪资组.EditValue);
                //同步基础工资
                StringBuilder sb = SalaryResult.SychSalaryResult((string)cbb日历组.EditValue, (string)ccb薪资组.EditValue);
                //同步工资明细
                StringBuilder sbItem = SalaryResultItem.SychSalaryResultItem((string)cbb日历组.EditValue, (string)ccb薪资组.EditValue);
                sb.Append(sbItem.ToString());
                
                CloseWaitDialog();

                MyHelper.WriteLog(LogType.信息, "重新同步上表工资", String.Format("日历组：{0}, {1}   薪资组： {2}, {3}", (string)cbb日历组.EditValue, cbb日历组.Text, (string)ccb薪资组.EditValue, ccb薪资组.Text));

                string msg = sb.ToString();
                if (string.IsNullOrEmpty(msg))
                    LoadData(true);
                else
                {
                    MessageBox.Show(msg);
                }
            }
            SetButtonEnabled();
        }
        #endregion

        #region cbb日历组_SelectedValueChanged

        private void cbb日历组_SelectedValueChanged(object sender, EventArgs e)
        {
            SetButtonEnabled();
        }
        #endregion

        #region btn审核_Click

        private void btn审核_Click(object sender, EventArgs e)
        {
            if (currRows.Count == 0)
            {
                MessageBox.Show("审核失败：没有找到上表工资数据。", "审核失败", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2, 0, false);
                return;
            }
            if (MessageBox.Show("审核的目的是确认所有基础工资都已同步成功。\n\n当前薪资组基础工资数据确实完整无缺了吗？", "询问", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2, 0, false) == DialogResult.Yes)
            {
                SalaryAuditingResult checkInfo = SalaryAuditingResult.AddSalaryAuditingResult((string)ccb薪资组.EditValue, (string)cbb日历组.EditValue);
                checkInfo.DoAuditingPublic(AccessController.CurrentUser.姓名);
                SetButtonEnabled();
                MyHelper.WriteLog(LogType.信息, "审核上表工资", checkInfo.ToString<SalaryAuditingResult>());
                MessageBox.Show("审核成功");
            }
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

        #region btn生成工资表_Click

        private void btn生成工资表_Click(object sender, EventArgs e)
        {
            SalaryAuditingResult checkInfo = SalaryAuditingResult.GetSalaryAuditingResult((string)ccb薪资组.EditValue, (string)cbb日历组.EditValue);
            if (checkInfo != null && checkInfo.上表工资已审核)
            {
                CreateWaitDialog("正在生成工资表...", "请稍等");

                //清空已有的工资表
                PrivateSalary.ClearPrivateSalary(checkInfo.日历组, checkInfo.薪资组);

                PayCounter payCounter = new PayCounter(checkInfo);
                //如果计算成功
                bool successed = payCounter.Calculate();

#if (DEBUG)
                //为了方便测试，在普通网使用不控制
                if (MyHelper.GetLocalIp()[0].StartsWith("192.168."))
                {
                    successed = true;
                    //保存计算时间
                    payCounter.审核情况表.工资计算时间 = DateTime.Now;
                    payCounter.审核情况表.制表人 = AccessController.CurrentUser.姓名;
                    payCounter.审核情况表.制表时间 = DateTime.Now;
                    payCounter.审核情况表.Save();
                    payCounter.审核情况表.UnLock();
                }
#endif

                if (successed)
                {
                    //保存工资表
                    foreach (SalaryCalculator cal in payCounter.员工工资计算器列表)
                    {
                        cal.Save();
                    }
                    SetWaitDialogCaption("正在加载数据...");
                    LoadData(true);
                    CloseWaitDialog();
                    MyHelper.WriteLog(LogType.信息, "生成工资表", checkInfo.ToString<SalaryAuditingResult>());
                }
                else
                {
                    CloseWaitDialog();
                    MessageBox.Show("生成工资表失败，详细原因点击确定后显示", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //显示错误列表
                    ErrorDialog form = new ErrorDialog(payCounter.错误列表);
                    form.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("生成工资表失败：基础工资表未审核。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region cbb日历组_SelectedIndexChanged

        private void cbb日历组_SelectedIndexChanged(object sender, EventArgs e)
        {
            ccb薪资组.Properties.Items.Clear();
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
                            ccb薪资组.Properties.Items.Add(item);
                        }
                    }
                }
            }
        }
        #endregion

        private void btn按薪资组查询_Click(object sender, EventArgs e)
        {
            LoadData(true);
        }

        private void ccb薪资组_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetButtonEnabled();
        }
    }

}

