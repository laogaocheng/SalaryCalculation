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
using Hwagain.SalaryCalculation.Components.Forms.IndexForms;

namespace Hwagain.SalaryCalculation
{
    public partial class TraineePersonalSalaryPlanForm : XtraForm
    {
        ManagementTraineeInfo trainee; //管培生
        int year_count = 7;
        string division;
        string grade;
        string type;

        Worksheet sheet;
        ColumnCollection columns;
        RowCollection rows;
        CellCollection cells;

        List<ManagementTraineePayStandard> salary_standard_items = new List<ManagementTraineePayStandard>();
        
        public TraineePersonalSalaryPlanForm(ManagementTraineeInfo trainee)
            : this()
        {
            this.trainee = trainee;
        }

        public TraineePersonalSalaryPlanForm()
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

            salary_standard_items = ManagementTraineePayStandard.GetManagementTraineePayStandards(trainee.员工编号);

            division = trainee.届别;
            grade = trainee.岗位级别;
            type = trainee.岗位级别 == "一级" ? trainee.岗位类型 : trainee.专业属性;

            lbl姓名.Text = "姓名：" + trainee.姓名;
            lbl届别.Text = "届别：" + trainee.届别;
            lbl类别.Text = trainee.岗位级别 == "一级" ? "岗位类型：" + type : "专业属性：" + type;

            UpStepType ust = ManagementTraineePayStandard.GetUpStepType(division, grade, type);
            switch (ust)
            {
                case UpStepType.五年两段三类:
                case UpStepType.五年两段四类:
                    year_count = 5; break;
                case UpStepType.五年三段四类:
                    year_count = 6; break;
                case UpStepType.七年两段五类:
                case UpStepType.七年三段五类:
                    year_count = 7; break;
            }

            lbl标题.Text = "定职人员（" + grade + "）【" + type + "】" + trainee.姓名 + "个人年度评定结果及提资表";
            //加载模板
            string filename = Path.Combine(Application.StartupPath, "ReportTemplates\\" + year_count + "-YearSalaryList.tab");
            spreadsheetControl1.LoadDocument(filename);

            sheet = spreadsheetControl1.ActiveWorksheet;
            columns = sheet.Columns;
            rows = sheet.Rows;
            cells = sheet.Cells;

            SetWaitDialogCaption("正在加载数据...");

            FillTable();

            sheet.ScrollToColumn(0); //焦点切回开始位置

            CloseWaitDialog();    
        }        

        #endregion       

        private void AdjustMonthlySalaryForm_Load(object sender, EventArgs e)
        {
            LoadData();
            this.WindowState = FormWindowState.Maximized;
        }

        #region FillTable

        private void FillTable()
        {
            if (salary_standard_items == null || salary_standard_items.Count == 0) return;
            //最后一次评定
            ManagementTraineeAbility last_ability = ManagementTraineeAbility.GetLastAbility(trainee.员工编号);
                        
            //倒序，从大到小找
            salary_standard_items = salary_standard_items.OrderByDescending(a => a.开始执行时间).ToList();
            int 第一年 = Convert.ToInt32(trainee.届别);
            DateTime start_date = new DateTime(第一年, 7, 1);

            decimal year_salary = 0;
            for (int i = 0; i <= year_count * 4; i++) //注：多算一次，否则得不到年薪
            {
                int offset = i / 4;

                if (i >= year_count * 4) break;
                if (last_ability == null && i >= 4) break;

                //填第三行，年度
                cells[2, 2 + i + offset].Value = start_date.Year;

                ManagementTraineePayStandard standard = salary_standard_items.Find(a => a.开始执行时间 <= start_date);
                if (standard == null) break;

                cells[5, 2 + i + offset].Value = standard.年薪.ToString("#0.##");
                year_salary += standard.年薪;

                if (standard.开始执行时间 == start_date && standard.增幅 > 0)
                    cells[6, 2 + i + offset].Value = standard.增幅.ToString("#0.##") + "%";

                //下一个开始时间
                start_date = start_date.AddMonths(3);

                //统计年薪
                if (i % 4 == 3)
                {
                    //获取年度评定
                    ManagementTraineeAbility ability = ManagementTraineeAbility.GetManagementTraineeAbility(trainee.员工编号, start_date.Year);
                    if (ability != null && i < (year_count - 1) * 4) //最后一年不需要填入评审结果
                    {
                        //退一格
                        cells[4, 2 + i + offset + 1].Value = ability.能力级别;
                    }
                    //计算上一年的年薪
                    cells[4, 2 + i + offset - 3].Value = (year_salary / (decimal)4.0).ToString("#0.##");
                    year_salary = 0;
                }
                //超过最后一次评定12个月
                if (last_ability != null)
                {
                    int m = start_date.Year - last_ability.年度;
                    int n = start_date.Month - 6;
                    if (m * 12 + n > 12)
                    {
                        break;
                    }
                }
            }
        }
        
        #endregion

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

        private void btn修改_Click(object sender, EventArgs e)
        {
            if (trainee.入职时间.Year == DateTime.Today.Year)
            {
                MessageBox.Show("错误：新入职的定职人员不能手工录入");
                return;
            }

            ManagementTraineePayRiseStandard standard = ManagementTraineePayRiseStandard.GetManagementTraineePayRiseStandard(trainee.届别, trainee.岗位级别, type, "A", 1);
            if (standard == null)
            {
                MessageBox.Show("错误：请录入提幅标准表后再试（入职半年内自动根据标准提资）");
                return;
            }
            ManagementTraineePayStandard prevStandard = ManagementTraineePayStandard.GetLatestBeforeOneday(trainee.员工编号, new DateTime(DateTime.Today.Year, 7, 1));

            if (prevStandard == null)
            {
                MessageBox.Show("错误：找不到上期年薪");
                return;
            }

            SelectInputTypeDialog stt_dialog = new SelectInputTypeDialog();
            if (stt_dialog.ShowDialog() == DialogResult.OK)
            {
                bool isCheck = stt_dialog.是验证录入;

                TraineeSalaryStandardInputForm form = new TraineeSalaryStandardInputForm(trainee, isCheck);
                form.Owner = this;
                form.ShowDialog();
            }
        }
    }

}

