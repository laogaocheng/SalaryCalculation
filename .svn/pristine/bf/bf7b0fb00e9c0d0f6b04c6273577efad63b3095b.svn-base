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
using System.Deployment.Application;

namespace Hwagain.SalaryCalculation
{
    public partial class TraineeSalaryPlanForm : XtraForm
    {        
        string division = null;
        string grade = null;
        string type = null;

        Worksheet sheet;
        ColumnCollection columns;
        RowCollection rows;
        CellCollection cells;

        List<ManagementTraineeSalaryPlan> plan_list_a;
        List<ManagementTraineeSalaryPlan> plan_list_b;
        List<ManagementTraineeSalaryPlan> plan_list_c;

        public TraineeSalaryPlanForm(string division, string grade, string type)
            : this()
        {
            this.division = division;
            this.grade = grade;
            this.type = type;
        }

        public TraineeSalaryPlanForm()
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

            plan_list_a = ManagementTraineeSalaryPlan.GeneratePlanList(division, grade, type, "A");
            plan_list_b = ManagementTraineeSalaryPlan.GeneratePlanList(division, grade, type, "B");
            plan_list_c = ManagementTraineeSalaryPlan.GeneratePlanList(division, grade, type, "C");

            string years = "五";
            if (plan_list_a.Count == 24) years = "六";
            if (plan_list_a.Count == 28) years = "七";

            UpStepType ust = ManagementTraineePayStandard.GetUpStepType(division, grade, type);
            string p = "";
            switch (ust)
            {
                case UpStepType.五年两段三类:
                    p = "52"; break;
                case UpStepType.五年两段四类:
                    p = "51"; break;
                case UpStepType.五年三段四类:
                    p = "53"; break;
                case UpStepType.七年两段五类:
                    p = "71"; break;
                case UpStepType.七年三段五类:
                    p = "72"; break;
            }

            lbl标题.Text = division + " 届定职人员（" + grade + "）【" + type + "】" + years + "年薪酬计划表";
            //加载模板
            string filename = Path.Combine(Application.StartupPath, "ReportTemplates\\" + p + "YearSalaryPlan.tab");
            spreadsheetControl1.LoadDocument(filename);

            sheet = spreadsheetControl1.ActiveWorksheet;
            columns = sheet.Columns;
            rows = sheet.Rows;
            cells = sheet.Cells;

            SetWaitDialogCaption("正在加载数据...");

            FillTable();

            sheet.ScrollToColumn(0);//焦点切回开始位置

            CloseWaitDialog();    
        }

        #endregion        

        private void AdjustMonthlySalaryForm_Load(object sender, EventArgs e)
        {
            LoadData();
            this.WindowState = FormWindowState.Maximized;
        }

        private void FillTable()
        {
            FillTableRows(plan_list_a, 0);
            FillTableRows(plan_list_b, 1);
            FillTableRows(plan_list_c, 2);
        }

        private void FillTableRows(List<ManagementTraineeSalaryPlan> plan_list, int recIndex)
        {
            if (plan_list == null || plan_list.Count == 0) return;

            int rowIndex = 5 + recIndex * 3;
            //填第一行
            cells["E" + rowIndex].Value = plan_list[0 * 4].年薪.ToString("#0.##");
            cells["I" + rowIndex].Value = plan_list[1 * 4].年薪.ToString("#0.##");
            cells["M" + rowIndex].Value = plan_list[2 * 4].年薪.ToString("#0.##");
            cells["Q" + rowIndex].Value = plan_list[3 * 4].年薪.ToString("#0.##");
            cells["U" + rowIndex].Value = plan_list[4 * 4].年薪.ToString("#0.##");
            if (plan_list.Count >= 24)
            {
                cells["Y" + rowIndex].Value = plan_list[5 * 4].年薪.ToString("#0.##");
            }
            if (plan_list.Count >= 28)
            {
                cells["AC" + rowIndex].Value = plan_list[6 * 4].年薪.ToString("#0.##");
            }
            //填第二行
            //第一年
            cells["E" + (rowIndex + 1)].Value = plan_list[0].季度年薪.ToString("#0.##");
            cells["F" + (rowIndex + 1)].Value = plan_list[1].季度年薪.ToString("#0.##");
            cells["G" + (rowIndex + 1)].Value = plan_list[2].季度年薪.ToString("#0.##");
            cells["H" + (rowIndex + 1)].Value = plan_list[3].季度年薪.ToString("#0.##");
            //第二年
            cells["I" + (rowIndex + 1)].Value = plan_list[4].季度年薪.ToString("#0.##");
            cells["J" + (rowIndex + 1)].Value = plan_list[5].季度年薪.ToString("#0.##");
            cells["K" + (rowIndex + 1)].Value = plan_list[6].季度年薪.ToString("#0.##");
            cells["L" + (rowIndex + 1)].Value = plan_list[7].季度年薪.ToString("#0.##");
            //第三年
            cells["M" + (rowIndex + 1)].Value = plan_list[8].季度年薪.ToString("#0.##");
            cells["N" + (rowIndex + 1)].Value = plan_list[9].季度年薪.ToString("#0.##");
            cells["O" + (rowIndex + 1)].Value = plan_list[10].季度年薪.ToString("#0.##");
            cells["P" + (rowIndex + 1)].Value = plan_list[11].季度年薪.ToString("#0.##");
            //第四年
            cells["Q" + (rowIndex + 1)].Value = plan_list[12].季度年薪.ToString("#0.##");
            cells["R" + (rowIndex + 1)].Value = plan_list[13].季度年薪.ToString("#0.##");
            cells["S" + (rowIndex + 1)].Value = plan_list[14].季度年薪.ToString("#0.##");
            cells["T" + (rowIndex + 1)].Value = plan_list[15].季度年薪.ToString("#0.##");
            //第五年
            cells["U" + (rowIndex + 1)].Value = plan_list[16].季度年薪.ToString("#0.##");
            cells["V" + (rowIndex + 1)].Value = plan_list[17].季度年薪.ToString("#0.##");
            cells["W" + (rowIndex + 1)].Value = plan_list[18].季度年薪.ToString("#0.##");
            cells["X" + (rowIndex + 1)].Value = plan_list[19].季度年薪.ToString("#0.##");
            if (plan_list.Count >= 24)
            {
                //第六年
                cells["Y" + (rowIndex + 1)].Value = plan_list[20].季度年薪.ToString("#0.##");
                cells["Z" + (rowIndex + 1)].Value = plan_list[21].季度年薪.ToString("#0.##");
                cells["AA" + (rowIndex + 1)].Value = plan_list[22].季度年薪.ToString("#0.##");
                cells["AB" + (rowIndex + 1)].Value = plan_list[23].季度年薪.ToString("#0.##");
            }
            if (plan_list.Count >= 28)
            {
                //第六年
                cells["AC" + (rowIndex + 1)].Value = plan_list[24].季度年薪.ToString("#0.##");
                cells["AD" + (rowIndex + 1)].Value = plan_list[25].季度年薪.ToString("#0.##");
                cells["AE" + (rowIndex + 1)].Value = plan_list[26].季度年薪.ToString("#0.##");
                cells["AF" + (rowIndex + 1)].Value = plan_list[27].季度年薪.ToString("#0.##");
            }
            //填第三行
            //第一年
            cells["E" + (rowIndex + 2)].Value = plan_list[0].增幅;
            cells["F" + (rowIndex + 2)].Value = plan_list[1].增幅;
            cells["G" + (rowIndex + 2)].Value = plan_list[2].增幅;
            cells["H" + (rowIndex + 2)].Value = plan_list[3].增幅;
            //第二年
            cells["I" + (rowIndex + 2)].Value = plan_list[4].增幅;
            cells["J" + (rowIndex + 2)].Value = plan_list[5].增幅;
            cells["K" + (rowIndex + 2)].Value = plan_list[6].增幅;
            cells["L" + (rowIndex + 2)].Value = plan_list[7].增幅;
            //第三年
            cells["M" + (rowIndex + 2)].Value = plan_list[8].增幅;
            cells["N" + (rowIndex + 2)].Value = plan_list[9].增幅;
            cells["O" + (rowIndex + 2)].Value = plan_list[10].增幅;
            cells["P" + (rowIndex + 2)].Value = plan_list[11].增幅; ;
            //第四年
            cells["Q" + (rowIndex + 2)].Value = plan_list[12].增幅;
            cells["R" + (rowIndex + 2)].Value = plan_list[13].增幅;
            cells["S" + (rowIndex + 2)].Value = plan_list[14].增幅;
            cells["T" + (rowIndex + 2)].Value = plan_list[15].增幅;
            //第五年
            cells["U" + (rowIndex + 2)].Value = plan_list[16].增幅;
            cells["V" + (rowIndex + 2)].Value = plan_list[17].增幅;
            cells["W" + (rowIndex + 2)].Value = plan_list[18].增幅;
            cells["X" + (rowIndex + 2)].Value = plan_list[19].增幅;
            if (plan_list.Count >= 24)
            {
                //第六年
                cells["Y" + (rowIndex + 2)].Value = plan_list[20].增幅;
                cells["Z" + (rowIndex + 2)].Value = plan_list[21].增幅;
                cells["AA" + (rowIndex + 2)].Value = plan_list[22].增幅;
                cells["AB" + (rowIndex + 2)].Value = plan_list[23].增幅;
            }
            if (plan_list.Count >= 28)
            {
                //第六年
                cells["AC" + (rowIndex + 2)].Value = plan_list[24].增幅;
                cells["AD" + (rowIndex + 2)].Value = plan_list[25].增幅;
                cells["AE" + (rowIndex + 2)].Value = plan_list[26].增幅;
                cells["AF" + (rowIndex + 2)].Value = plan_list[27].增幅;
            }
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

