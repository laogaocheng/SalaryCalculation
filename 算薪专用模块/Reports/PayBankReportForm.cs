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
    public partial class PayBankReportForm : XtraForm
    {        

        protected List<ToBankReportItem> currRows = new List<ToBankReportItem>();
        string 当前期间 = "";
        string 当前账号 = "";
        public PayBankReportForm()
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

        #region PayBankReportForm_Load

        private void PayBankReportForm_Load(object sender, EventArgs e)
        {
            Init();
        }
        #endregion

        #region 加载数据

        protected void LoadData()
        {
            string accType = cb账户类型.EditValue as string;

            CreateWaitDialog("正在查询...", "请稍等");

            //生成报盘记录
            currRows.Clear();

            switch (accType)
            {
                case "A":
                case "D":
                    List<SalaryResult> salaryList = new List<SalaryResult>();
                    //获取上表工资清单
                    foreach (PayGroup payGroup in AccessController.我管理的薪资组)
                    {
                        salaryList.AddRange(SalaryResult.GetSalaryResults(Convert.ToInt32(year.Value), Convert.ToInt32(month.Text), ccb发放单位.Text, payGroup.英文名));
                    }
                    foreach (SalaryResult row in salaryList)
                    {
                        ToBankReportItem item = new ToBankReportItem();

                        item.账户类型 = accType;
                        item.员工编号 = row.员工编号;
                        item.员工姓名 = row.姓名;
                        item.员工序号 = row.员工序号;
                        item.部门序号 = row.财务部门序号;
                        SetBankInfo(row.员工编号, accType, item);

                        if (accType == "A") //上表
                        {
                            item.金额 = row.实发工资总额;
                            currRows.Add(item);
                        }
                        if (accType == "D" && row.未休年休假工资 > 0) //年休假
                        {
                            item.金额 = row.未休年休假工资;
                            currRows.Add(item);
                        }
                    }
                    break;
                case "B":
                    List<PrivateSalary> rows = new List<PrivateSalary>();
                    foreach (PayGroup payGroup in AccessController.我管理的薪资组)
                    {
                        rows.AddRange(PrivateSalary.GetPrivateSalarys(Convert.ToInt32(year.Value), Convert.ToInt32(month.Text), ccb发放单位.Text, payGroup.英文名));
                    }
                    foreach (PrivateSalary row in rows)
                    {
                        ToBankReportItem item = new ToBankReportItem();

                        item.账户类型 = accType;
                        item.员工编号 = row.员工编号;
                        item.员工姓名 = row.姓名;
                        item.部门序号 = row.基础工资表.财务部门序号;
                        item.员工序号 = row.基础工资表.员工序号;
                        item.金额 = row.本次实发工资;
                        SetBankInfo(row.员工编号, accType, item);

                        currRows.Add(item);
                    }
                    break;
            }

            //排序
            currRows = currRows.OrderBy(a => a.部门序号).ThenBy(a => a.员工序号).ToList();

            CreateWaitDialog("正在加载...", "请稍等");

            gridControl1.DataSource = currRows;
            gridView1.ExpandAllGroups();

            CloseWaitDialog();

            当前期间 = String.Format("{0}年{1}", year.Value, month.Text) + "月";
            当前账号 = cb账户类型.Text;
        }

        #region SetBankInfo

        private static void SetBankInfo(string empNo, string accType, ToBankReportItem item)
        {
            PersonBankInfo bankInfo = PersonBankInfo.Get(empNo, accType);
            if (bankInfo == null && accType != "A") bankInfo = PersonBankInfo.Get(empNo, "A"); //没有帐号自动取上表工资帐号
            if (bankInfo != null)
            {
                item.银行编号 = bankInfo.银行编号;
                item.银行名称 = bankInfo.银行名称;
                item.银行账户 = bankInfo.银行账户;
                item.账户名称 = bankInfo.账户名称;
            }
        }
        #endregion

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

        #region cb账户类型_SelectedValueChanged

        private void cb账户类型_SelectedValueChanged(object sender, EventArgs e)
        {
            SetButtonEnabled();
        }
        #endregion

        #region btn另存为_Click

        private void btn另存为_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = String.Format("{0}{1}银行报盘表", 当前期间, 当前账号).Replace("账号", "");
            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string filename = saveFileDialog1.FileName;            
                gridControl1.ExportToXls(filename);
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

