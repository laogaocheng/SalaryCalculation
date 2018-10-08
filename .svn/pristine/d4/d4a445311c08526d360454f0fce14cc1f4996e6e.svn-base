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
    public partial class PayCheckForm : XtraForm
    {
        protected List<PrivateSalary> currRows = new List<PrivateSalary>();

        //我的日历组
        protected List<CalRunInfo> myCalRunList = new List<CalRunInfo>();
        //我的薪资组
        protected List<PayGroup> myPayGroupList = new List<PayGroup>();

        public PayCheckForm()
        {
            // This call is required by the Windows Form Designer.
            InitializeComponent();

            // TODO: Add any initialization after the InitializeComponent call
        }

        public string 薪资组 { get; set; }
        public string 日历组 { get; set; }
        
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
            
            cbb日历组.EditValue = 日历组;
            cb薪资组.EditValue = 薪资组;

            LoadData();

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

        public void LoadData()
        {
            LoadData(false);
        }
        public void LoadData(bool onlyPayGroup)
        {
            currRows.Clear();
            
            CreateWaitDialog("正在查询...", "请稍等");
            //清除原来的数据
            List<PayCheckRecord> items = PayCheckRecord.GetPayCheckRecordList(null, 日历组);
            
            if (items.Count == 0)
            {
                MessageBox.Show("没有找不到任何记录, 请生成工资表后重试。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CloseWaitDialog();
                return;
            }

            //获取工资记录集合
            List<PrivateSalary> rows = new List<PrivateSalary>();
            foreach (PayCheckRecord item in items)
            {
                if (item.工资记录 != null) rows.Add(item.工资记录);
            }
            //只显示有权看的
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

            bandedGridView1.ExpandAllGroups();
            gridControl1.Refresh();
        }

        #endregion

        #region SetButtonEnabled

        void SetButtonEnabled()
        {
            SalaryAuditingResult auditingResult = SalaryAuditingResult.GetSalaryAuditingResult((string)cb薪资组.EditValue, (string)cbb日历组.EditValue);
            btn审核.Enabled = auditingResult != null && auditingResult.上表工资已审核;
            SetButtonEnabledByRight();
        }
        #endregion

        #region SetButtonEnabledByRight

        void SetButtonEnabledByRight()
        {
            if (btn审核.Enabled) btn审核.Enabled = AccessController.CheckDoAuditingPublicPay();
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
            薪资组 = cb薪资组.EditValue as string;
            SetButtonEnabled();
        }
        #endregion

        #region imageComboBoxEdit1_SelectedValueChanged

        private void imageComboBoxEdit1_SelectedValueChanged(object sender, EventArgs e)
        {
            日历组 = cbb日历组.EditValue as string;            
            SetButtonEnabled();
        }
        #endregion

        #region btn审核_Click

        private void btn审核_Click(object sender, EventArgs e)
        {
            //必须审核完抽查的记录才能正式审核
            ColumnView colView = (ColumnView)gridControl1.MainView;
            if (colView != null)
            {
                PrivateSalary currentItem = (PrivateSalary)colView.GetFocusedRow();
                if (currentItem != null)
                {
                    PayCheckRecord pcr = PayCheckRecord.GetPayCheckRecord(currentItem.标识);
                    if (pcr != null)
                    {
                        if (MessageBox.Show(currentItem.姓名 + " 的工资经核实无误吗？", "询问", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, 0, false) == DialogResult.Yes)
                        {
                            if (MessageBox.Show(currentItem.姓名 + " 的工资经核实无误吗？", "再次确认", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button2, 0, false) == DialogResult.Yes)
                            {
                                pcr.DoAuditing(AccessController.CurrentUser.姓名);

                                MyHelper.WriteLog(LogType.信息, "审核抽查的工资记录", pcr.ToString<PayCheckRecord>());

                                MessageBox.Show("当前记录已审核成功");
                            }
                        }
                    }
                    else
                        MessageBox.Show("审核失败：找不到记录, 请重新打开后重试。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show("审核失败：找不到工资记录, 请重新打开后重试。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        #region cbb日历组_SelectedIndexChanged

        private void cbb日历组_SelectedIndexChanged(object sender, EventArgs e)
        {
            cb薪资组.Properties.Items.Clear();
            CalRunInfo cal = CalRunInfo.Get((string)cbb日历组.EditValue);
            if (cal != null)
            {
                日历组 = cal.日历组编号;
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

        private void btn按日历组查询_Click(object sender, EventArgs e)
        {
            LoadData();
        }

    }

}

