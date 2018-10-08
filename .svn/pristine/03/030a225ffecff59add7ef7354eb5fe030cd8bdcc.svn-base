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
    public partial class CompanySalaryJobCounterForm : XtraForm
    {

        public CompanySalaryJobCounterForm()
        {
            // This call is required by the Windows Form Designer.
            InitializeComponent();

            // TODO: Add any initialization after the InitializeComponent call
        }

        #region Init

        void Init()
        {           
            DateTime prevMonth = DateTime.Today.AddMonths(-1);
            startYear.Value = prevMonth.Year;
            startMonth.EditValue = prevMonth.Month;

            endYear.Value = prevMonth.Year;
            endMonth.EditValue = prevMonth.Month;

            ccb公司名称.Properties.Items.Clear();
            List<DeptInfo> companyList = DeptInfo.组织机构表.FindAll(a => a.部门层级 == 15);
            foreach (DeptInfo dept in companyList)
            {
                ImageComboBoxItem item = new ImageComboBoxItem((string)dept.部门名称, (string)dept.部门编号);
                ccb公司名称.Properties.Items.Add(item);
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

        #region CompanySalaryJobCounterForm_Load

        private void CompanySalaryJobCounterForm_Load(object sender, EventArgs e)
        {
            Init();

            SetButtonEnabled();
        }
        #endregion

        #region 加载数据

        protected void LoadData()
        {
            DateTime start = new DateTime(Convert.ToInt32(startYear.Value), Convert.ToInt32(startMonth.Text), 1);
            DateTime end = new DateTime(Convert.ToInt32(endYear.Value), Convert.ToInt32(endMonth.Text), 1);

            if (end < start) throw new Exception("结束时间不能小于开始时间");

            CreateWaitDialog("正在查询...", "请稍等");

            List<EmployeeSalary> rows = EmployeeSalary.GetEmployeeSalarys(start, end, (string)ccb公司名称.EditValue);
            
            CreateWaitDialog("正在统计...", "请稍等");

            pivotGridControl1.DataSource = rows;

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

        #region btn另存为_Click

        private void btn另存为_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = "各公司部门薪酬统计表";
            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string filename = saveFileDialog1.FileName;
                pivotGridControl1.ExportToXls(filename);
            }
        }
        #endregion

        #region btn查询_Click

        private void btn查询_Click(object sender, EventArgs e)
        {
            btn查询.Enabled = false;
            LoadData();
            btn查询.Enabled = true;
        }

        #endregion

        #region pivotGridControl1_CellDoubleClick

        private void pivotGridControl1_CellDoubleClick(object sender, DevExpress.XtraPivotGrid.PivotCellEventArgs e)
        {
            if (!AccessController.CheckOpenTaxReport()) return;

            try
            {
                ShowDrillDown(e.CreateDrillDownDataSource());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region ShowDrillDown

        private void ShowDrillDown(DevExpress.XtraPivotGrid.PivotDrillDownDataSource pivotDrillDownDataSource)
        {
            DrillDownItemsForm form = new DrillDownItemsForm(pivotDrillDownDataSource);
            form.ShowDialog();
        }
        #endregion

    }

}

