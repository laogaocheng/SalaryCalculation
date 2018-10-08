using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;

using YiKang.RBACS.DataObjects;
using DevExpress.XtraGrid.Views.Base;
using Hwagain.Components;
using Hwagain.SalaryCalculation.Components;
using YiKang;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.Utils;
using DevExpress.XtraPrinting;
using System.Data;
using System.IO;
using DevExpress.Spreadsheet;

namespace Hwagain.SalaryCalculation
{
    public partial class SalaryDetailForm : XtraForm
    {
        PrivateSalary mySalary;

        Worksheet sheet;
        ColumnCollection columns;
        RowCollection rows;
        CellCollection cells;

        public SalaryDetailForm(PrivateSalary salary)
            : this()
        {
            this.mySalary = salary;
        }

        public SalaryDetailForm()
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

        #region 加载数据

        protected void LoadData()
        { 
            CreateWaitDialog("正在查询...", "请稍等");
            //加载模板
            string filename = Path.Combine(Application.StartupPath, "ReportTemplates\\MonthlySalaryDetail.tab");
            spreadsheetControl1.LoadDocument(filename);

            sheet = spreadsheetControl1.ActiveWorksheet;
            columns = sheet.Columns;
            rows = sheet.Rows;
            cells = sheet.Cells;

            SetWaitDialogCaption("正在加载数据...");

            FillTable();

            sheet.ScrollToRow(3);//焦点切回开始位置

            CloseWaitDialog();    
        }        

        #endregion       

        private void AdjustMonthlySalaryForm_Load(object sender, EventArgs e)
        {
            lbl标题.Text = "个人月薪发放明细表";
            lbl姓名.Text = "姓名：" + mySalary.姓名;
            lbl部门.Text = "厂/部门：" + mySalary.员工信息.部门名称;
            lbl职务.Text = "职务：" + mySalary.员工信息.职务名称;
            lbl职等.Text = "职等：" + mySalary.员工信息.职等;
            lbl月份.Text = "月份：" + mySalary.年度 + "年" + mySalary.月份 + "月";

            LoadData();
            this.WindowState = FormWindowState.Maximized;
        }

        private void FillTable()
        {
            if (mySalary == null) return;

            DateTime 期间开始 = new DateTime(mySalary.年度, mySalary.月份, 1);
            DateTime 期间结束 = 期间开始.AddMonths(1).AddDays(-1);

            EmployeeSalaryStructure 薪酬结构 = mySalary.薪酬结构;
            SalaryResult 上表工资 = mySalary.基础工资表;
            PrivateSalary 封闭工资 = mySalary;
            WageLoan 工资借款 = WageLoan.GetEffective(mySalary.员工编号, 期间开始);
            ContractAllowance 契约津贴 = ContractAllowance.GetEffective(mySalary.员工编号, 期间开始);

            decimal 月薪剩余 = 0;
            #region 薪酬结构
            if (薪酬结构 != null)
            {
                cells["G3"].Value = (薪酬结构.年薪_合计 / 10000).ToString("#0.####");
                cells["G4"].Value = (薪酬结构.年薪_奖励 / 10000).ToString("#0.####");
                cells["G5"].Value = (薪酬结构.年薪_12个月 / 10000).ToString("#0.####");
            }
            else
            {
                cells["G3"].Value = (封闭工资.职级工资 * 12 / 10000).ToString("#0.####");
                cells["G5"].Value = 封闭工资.职级工资.ToString("#0.##");
            }

            cells["G6"].Value = 封闭工资.职级工资.ToString("#0.##");
            月薪剩余 = 封闭工资.职级工资;

            if (工资借款 != null)
            {
                List<MonthlyWageLoanItem> items = MonthlyWageLoanItem.GetMonthlyWageLoanItems(mySalary.员工编号);
                items = items.FindAll(a => a.期间开始 >= 工资借款.开始时间 && a.期间开始 <= 期间结束);

                cells["G7"].Value = 工资借款.月借款额度.ToString("#0.##");
                cells["G8"].Value = items.Sum(a => a.月借款标准).ToString("#0.##");

                月薪剩余 -= 工资借款.月借款额度;
            }

            if (契约津贴 != null)
            {
                List<MonthlyContractAllowanceItem> items = MonthlyContractAllowanceItem.GetMonthlyContractAllowanceItems(mySalary.员工编号);
                items = items.FindAll(a => a.期间开始 >= 契约津贴.开始时间 && a.期间开始 <= 期间结束);

                cells["G7"].Value = 契约津贴.月津贴额度.ToString("#0.##");
                cells["G8"].Value = items.Sum(a => a.月津贴标准).ToString("#0.##");

                月薪剩余 -= 契约津贴.月津贴额度;
            }

            月薪剩余 -= 封闭工资.本月执行绩效工资额;

            cells["G16"].Value = 封闭工资.本月执行绩效工资额.ToString("#0.##");
            cells["G17"].Value = 月薪剩余.ToString("#0.##");
            #endregion

            //工资发放
            #region 工资发放

            cells["G18"].Value = 上表工资.企业排班天数.ToString("#0.##");
            cells["G19"].Value = 上表工资.实际出勤天数.ToString("#0.##");
            cells["G20"].Value = 封闭工资.总出勤工资.ToString("#0.##");

            cells["G21"].Value = 上表工资.未休年休假工资.ToString("#0.##");
            cells["G22"].Value = 上表工资.实得满勤奖.ToString("#0.##");
            cells["G23"].Value = 封闭工资.总补助工资.ToString("#0.##");

            decimal 加班工资 = 上表工资.法定节假日出勤工资 + 上表工资.休息日出勤工资 + 上表工资.月综合出勤工资 + 上表工资.工作日延长工作出勤工资;
            cells["G24"].Value = 加班工资.ToString("#0.##");
            cells["G25"].Value = 上表工资.综合考核工资.ToString("#0.##");
            cells["G28"].Value = 封闭工资.奖项_不含满勤奖.ToString("#0.##");
            cells["G29"].Value = 封闭工资.扣项.ToString("#0.##");

            cells["G30"].Value = 封闭工资.工资发放总额.ToString("#0.##");
            //社保缴纳
            cells["G33"].Value = 上表工资.住房公积金个人缴纳金额.ToString("#0.##");
            cells["G34"].Value = 上表工资.养老保险个人缴纳金额.ToString("#0.##");
            cells["G35"].Value = 上表工资.大病医疗个人缴纳金额.ToString("#0.##");
            cells["G36"].Value = 上表工资.医疗保险个人缴纳金额.ToString("#0.##");
            cells["G37"].Value = 上表工资.失业保险个人缴纳金额.ToString("#0.##");
            cells["G38"].Value = 0; //生育
            cells["G39"].Value = 0; //工伤
            cells["G40"].Value = 上表工资.社保个人缴纳金额.ToString("#0.##");
            //预留工资作奖金
            //税后工资
            cells["G43"].Value = 封闭工资.总应税工资.ToString("#0.##");
            cells["G44"].Value = 封闭工资.个人所得税.ToString("#0.##");
            cells["G45"].Value = 封闭工资.总代垫费用.ToString("#0.##");
            cells["G46"].Value = 封闭工资.实发工资.ToString("#0.##");
            //年薪资奖励
            //预留工资作奖金
            //税后奖金

            #endregion
        }

        private void AdjustMonthlySalaryForm_Shown(object sender, EventArgs e)
        {
            if (this.Owner != null && this.Owner.Visible) this.Owner.Hide();
        }

        private void AdjustMonthlySalaryForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.Owner != null) this.Owner.Show();
        }

        private void btn返回目录_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }

}

