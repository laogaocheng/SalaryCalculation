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
using Hwagain.SalaryCalculation.Components.Forms.ListForms;
using Hwagain.SalaryCalculation.Components.Forms.Dialogs;

namespace Hwagain.SalaryCalculation
{
    public partial class PayReportForm : XtraForm
    {
        protected List<PrivateSalary> currRows = new List<PrivateSalary>();

        //我的日历组
        protected List<CalRunInfo> myCalRunList = new List<CalRunInfo>();
        //我的薪资组
        protected List<PayGroup> myPayGroupList = new List<PayGroup>();

        public PayReportForm()
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

            //2018-5-24 设置序号
            int currOrder = 1;
            string lastCalDept = null; //上一个人的计算部门
            foreach (PrivateSalary item in currRows)
            {
                if (lastCalDept != item.基础工资表.财务部门)
                    currOrder = 1;

                item.序号 = currOrder++;
                lastCalDept = item.基础工资表.财务部门;
            }

            CreateWaitDialog("正在加载...", "请稍等");

            gridControl1.DataSource = currRows;
            gridControl1.RefreshDataSource();

            CloseWaitDialog();

            #region 显示审核信息

            if (onlyPayGroup)
            {
                lbl审核人.Text = "审核人: ";
                lbl审核时间.Text = "审核时间: ";

                SalaryAuditingResult checkInfo = SalaryAuditingResult.GetSalaryAuditingResult((string)cb薪资组.EditValue, (string)cbb日历组.EditValue);
                if (checkInfo != null)
                {
                    lbl审核人.Text = "审核人: " + checkInfo.上表审核人;
                    lbl审核时间.Text = "审核时间: " + checkInfo.上表审核时间.ToString();
                }
            }
            #endregion

            SetButtonEnabled();

            bandedGridView1.ExpandAllGroups();
        }

        #endregion

        #region SetButtonEnabled

        void SetButtonEnabled()
        {
            SalaryAuditingResult auditingResult = SalaryAuditingResult.GetSalaryAuditingResult((string)cb薪资组.EditValue, (string)cbb日历组.EditValue);
            //btn审核.Enabled = auditingResult != null && auditingResult.上表工资已审核 && auditingResult.已审核 == false && auditingResult.已冻结 == false;
            //2017.4.19 调整 只要没审核没冻结都可用，但点击后根据实际情况提示不能够进行的操作
            btn审核.Enabled = auditingResult == null || (auditingResult.已审核 == false && auditingResult.已冻结 == false);
            btn冻结.Enabled = auditingResult != null && auditingResult.已审核 && auditingResult.已冻结 == false;
            btn重新计算.Enabled = auditingResult != null && auditingResult.已冻结 == false;

            SetButtonEnabledByRight();
        }
        #endregion

        #region SetButtonEnabledByRight

        void SetButtonEnabledByRight()
        {
            if (btn审核.Enabled) btn审核.Enabled = AccessController.CheckDoAuditingPay();
            if (btn冻结.Enabled) btn冻结.Enabled = AccessController.CheckLockPay();
            if (btn重新计算.Enabled) btn重新计算.Enabled = AccessController.CheckDoAuditingPay();
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

        #region btn审核_Click

        private void btn审核_Click(object sender, EventArgs e)
        {
            SalaryAuditingResult checkInfo = SalaryAuditingResult.GetSalaryAuditingResult((string)cb薪资组.EditValue, (string)cbb日历组.EditValue);
            if (checkInfo != null && checkInfo.已计算)
            {
                if (checkInfo.上表工资已审核)
                {
                    //if (!CheckAdjustItemPassed(checkInfo)) return;

                    if (MessageBox.Show("当前薪资组工资确实审核无误了吗？", "询问", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2, 0, false) == DialogResult.Yes)
                    {
                        checkInfo.DoAuditing(AccessController.CurrentUser.姓名);

                        MyHelper.WriteLog(LogType.信息, "审核工资表", checkInfo.ToString<SalaryAuditingResult>());

                        SetButtonEnabled();
                        MessageBox.Show("审核成功。", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                    MessageBox.Show("审核失败：流程不对，请先审核上表工资，确认上表工资数据同步正确和完整。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("审核失败：数据错误，请重新生成工资表后再试。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        #endregion

        #region CheckAdjustItemPassed
        //如果调整通过
        private bool CheckAdjustItemPassed(SalaryAuditingResult checkInfo)
        {
            //2017.4.19 增加检查调整工资的逻辑
            List<SalaryAdjustItem> adjustItems = SalaryAdjustItem.GetAdjustItems(checkInfo.年, checkInfo.月, checkInfo.薪资组);
            int noAdjustItemCount = adjustItems.Count(a => a.已调整工资 == false);
            //如果还有没有调整的记录，显示列表
            if (noAdjustItemCount > 0)
            {
                SalaryAdjustDetail adjustForm = new SalaryAdjustDetail(checkInfo.年, checkInfo.月, checkInfo.薪资组, cb薪资组.Text, true);
                if (adjustForm.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                    return false;
            }
            return true;
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

        #region btn重新计算_Click

        private void btn重新计算_Click(object sender, EventArgs e)
        {
            SalaryAuditingResult checkInfo = SalaryAuditingResult.GetSalaryAuditingResult((string)cb薪资组.EditValue, (string)cbb日历组.EditValue);
            if (checkInfo != null)
            {
                if (checkInfo.已冻结 == false)
                {
                    if (MessageBox.Show("重新计算后系统自动重建抽查记录，您确定要重新计算吗？", "询问", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2, 0, false) == DialogResult.Yes)
                    {
                        CreateWaitDialog("正在计算工资...", "请稍等");

                        //清空已有的工资表
                        PrivateSalary.ClearPrivateSalary(checkInfo.日历组, checkInfo.薪资组);
                        checkInfo.UndoAuditing();
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

                            //显示错误列表
                            if (payCounter.错误列表.Count > 0)
                            {
                                ErrorDialog form = new ErrorDialog(payCounter.错误列表);
                                form.ShowDialog();
                            }
                            MyHelper.WriteLog(LogType.信息, "重新计算工资", checkInfo.ToString<SalaryAuditingResult>());
                        }
                        else
                        {
                            CloseWaitDialog();
                            MessageBox.Show("重新计算失败，详细原因点击确定后显示", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            //显示错误列表
                            ErrorDialog form = new ErrorDialog(payCounter.错误列表);
                            form.ShowDialog();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("重新计算失败：已冻结的工资表不能反审重新计算。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("重新计算失败：数据错误，请重新生成工资表后再试。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        #endregion

        #region btn冻结_Click

        private void btn冻结_Click(object sender, EventArgs e)
        {
            SalaryAuditingResult checkInfo = SalaryAuditingResult.GetSalaryAuditingResult((string)cb薪资组.EditValue, (string)cbb日历组.EditValue);
            if (checkInfo != null)
            {
                if (checkInfo.已审核)
                {
                    if (!CheckAdjustItemPassed(checkInfo)) return;

                    if (MessageBox.Show("工资冻结以后将不能再进行修改，切实要冻结当前薪资组的工资吗？", "询问", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2, 0, false) == DialogResult.Yes)
                    {
                        checkInfo.Lock(AccessController.CurrentUser.姓名);

                        MyHelper.WriteLog(LogType.信息, "冻结工资表", checkInfo.ToString<SalaryAuditingResult>());

                        SetButtonEnabled();
                        MessageBox.Show("冻结成功", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                    MessageBox.Show("审核失败：工资表未经审核不能冻结。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("审核失败：数据错误，请重新生成工资表后再试。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        #endregion

        #region btn抽查_Click

        private void btn抽查_Click(object sender, EventArgs e)
        {
            string payGroup = cb薪资组.EditValue as string;
            string calRunId = (string)cbb日历组.EditValue;

            if (payGroup == "" || calRunId == "")
            {
                MessageBox.Show("请选择要查看的薪资组和日历组。");
            }
            else
            {
                PayCheckForm form = new PayCheckForm();
                form.薪资组 = payGroup;
                form.日历组 = calRunId;
                form.MdiParent = this.MdiParent;
                form.Show();
                form.LoadData(true);
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

        #region cb薪资组_Properties_EditValueChanged

        private void cb薪资组_Properties_EditValueChanged(object sender, EventArgs e)
        {
            LoadData(true);
        }
        #endregion

        #region btn与上月对比_Click

        private void btn与上月对比_Click(object sender, EventArgs e)
        {
            if (cb薪资组.SelectedItem != null)
            {
                CalRunInfo cal = CalRunInfo.Get((string)cbb日历组.EditValue);
                if (cal != null)
                {

                    SalaryChangedList form = new SalaryChangedList(cal.年度, cal.月份, (string)cb薪资组.EditValue, cb薪资组.Text);
                    form.ShowDialog();
                }
                else
                    MessageBox.Show("指定的日历组不存在。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("请选择要对比的薪资组。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region btn计算表对比_Click

        private void btn计算表对比_Click(object sender, EventArgs e)
        {
            if (cb薪资组.SelectedItem != null)
            {
                CalRunInfo cal = CalRunInfo.Get((string)cbb日历组.EditValue);
                if (cal != null)
                {

                    PayChangedList form = new PayChangedList(cal.年度, cal.月份, (string)cb薪资组.EditValue, cb薪资组.Text);
                    form.ShowDialog();
                }
                else
                    MessageBox.Show("指定的日历组不存在。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("请选择要对比的薪资组。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        private void bandedGridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            PrivateSalary item = bandedGridView1.GetRow(bandedGridView1.FocusedRowHandle) as PrivateSalary;
            if (item != null && item.职级工资减项 > 0 && e.Column.FieldName == "职级工资减项")
            {
                SalaryDecuctionInfoForm form = new SalaryDecuctionInfoForm(item);
                form.Show();
            }
        }

        private void bandedGridView1_CustomColumnDisplayText(object sender, CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.Name == "财务部门")
            {
                PrivateSalary item = bandedGridView1.GetRow(e.ListSourceRowIndex) as PrivateSalary;
                e.DisplayText = item.基础工资表.财务部门;
            }
        }
    }

}

