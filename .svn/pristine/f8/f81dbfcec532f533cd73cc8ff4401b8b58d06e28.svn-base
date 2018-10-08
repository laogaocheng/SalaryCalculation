using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;

namespace Hwagain.SalaryCalculation.Components.Forms.IndexForms
{
    public partial class SelectJobGradeForm : DevExpress.XtraEditors.XtraForm
    {
        string command = "";
        string company = "";
        string company_code = "";
        string salary_plan = null;

        int year;
        SemiannualType semiannual;
        string group;
        int period;

        public SelectJobGradeForm(string company, string cmd)
        {
            this.company = company;
            this.command = cmd;
            this.salary_plan = company;
            //获取公司代码
            company_code = PsHelper.GetCompanyCode(salary_plan);
            
            InitializeComponent();

            if (cmd == "录入职级及职级工资" || cmd == "查看各职等职级月薪执行标准" || cmd == "调整各职等月薪执行标准")
            {
                this.Text = "请选择年度";
                listBoxControl职级.Visible = false;
                this.Size = new Size(this.Size.Width, this.Size.Height - 480);
                btn确定.Location = new Point(btn确定.Location.X, btn确定.Location.Y - 480);
                btn取消.Location = new Point(btn取消.Location.X, btn取消.Location.Y - 480);
            }

            if (cmd == "录入异动人员薪酬执行明细" ||
                cmd == "查看各职等人员薪酬发放明细表" ||
                cmd == "查看各职等管理人员薪酬执行明细" || 
                cmd == "查看各职等人员薪酬结构明细表")
            {
                this.Text = "请选择职等";
                spin年度.Visible = false;
                cbSemiannual.Visible = false;
                listBoxControl职级.Location = new Point(spin年度.Location.X, spin年度.Location.Y);
                listBoxControl职级.Size = new Size(listBoxControl职级.Size.Width, listBoxControl职级.Size.Height + spin年度.Size.Height);
            }
        }

        private void SelectJobGradeForm_Shown(object sender, EventArgs e)
        {
            if (this.Owner != null) this.Owner.Hide();
        }

        private void SelectJobGradeForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.Owner != null) this.Owner.Show();
        }

        void OpenWindow()
        {
            year = Convert.ToInt32(spin年度.Value);

            if (!string.IsNullOrEmpty(cbSemiannual.Text)) semiannual = (SemiannualType)Enum.Parse(typeof(SemiannualType), cbSemiannual.Text);

            group = (string)listBoxControl职级.SelectedItem;
            period = year * 10 + (byte)semiannual;

            switch (command)
            {
                case "录入职级及职级工资":
                    int next_period = RankSalaryStandard.GetNextPeriod(salary_plan, period);
                    if (next_period != -1)
                    {
                        MessageBox.Show("不能录入" + year + cbSemiannual.Text + "的月薪执行标准，因为已经有新的标准");
                    }
                    else
                    {
                        int max_period = (DateTime.Today.Year + 1) * 10 + 1;
                        if (DateTime.Today.Month < 6) max_period = DateTime.Today.Year * 10 + 2;

                        if (period > max_period)
                        {
                            MessageBox.Show("不能录入" + year + cbSemiannual.Text + "的月薪执行标准，有点早了");
                        }
                        else
                        {
                            SelectInputTypeDialog sdialog = new SelectInputTypeDialog();
                            sdialog.OnSelected += sdialog_OnSelected;
                            sdialog.ShowDialog();
                        }
                    }
                    break;
                case "查看各职等职级月薪执行标准":
                    GradeSalaryStandardForm gForm = new GradeSalaryStandardForm(salary_plan, year, semiannual);
                    gForm.Owner = this;
                    gForm.ShowDialog();
                    break;
                case "查看各职等管理人员薪酬执行明细":
                    if (listBoxControl职级.SelectedIndex == -1)
                        MessageBox.Show("请选择职等");
                    else
                    {
                        MonthlySalaryForm msForm = new MonthlySalaryForm(salary_plan, group);
                        msForm.Owner = this;
                        msForm.ShowDialog();
                    }
                    break;
                case "录入各职等等管理人员薪酬执行明细":
                    if (listBoxControl职级.SelectedIndex == -1)
                        MessageBox.Show("请选择职等");
                    else
                    {
                        next_period = RankSalaryStandard.GetNextPeriod(salary_plan, period);
                        if (next_period != -1)
                        {
                            MessageBox.Show("不能录入" + year + cbSemiannual.Text + "的薪酬执行明细，因为已经有新的标准");
                        }
                        else
                        {
                            int max_period = (DateTime.Today.Year + 1) * 10 + 1;
                            if (DateTime.Today.Month < 6) max_period = DateTime.Today.Year * 10 + 2;

                            if (period > max_period)
                            {
                                MessageBox.Show("不能录入" + year + cbSemiannual.Text + "的薪酬执行明细，有点早了");
                            }
                            else
                            {
                                SelectInputTypeDialog ams_sdialog = new SelectInputTypeDialog();
                                ams_sdialog.OnSelected += ams_sdialog_OnSelected;
                                ams_sdialog.ShowDialog();
                            }
                        }
                    }
                    break;
                case "录入异动人员薪酬执行明细":
                    if (listBoxControl职级.SelectedIndex == -1)
                        MessageBox.Show("请选择职等");
                    else
                    {
                        SelectInputTypeDialog iams_sdialog = new SelectInputTypeDialog();
                        iams_sdialog.OnSelected += iams_sdialog_OnSelected;
                        iams_sdialog.ShowDialog();
                    }
                    break;
                case "查看各职等人员薪酬结构明细表":
                    if (listBoxControl职级.SelectedIndex == -1)
                        MessageBox.Show("请选择职等");
                    else
                    {
                        SalaryStructureListForm ssForm = new SalaryStructureListForm(salary_plan, group);
                        ssForm.Owner = this;
                        ssForm.ShowDialog();
                    }
                    break;
                case "查看各职等人员薪酬发放明细表":
                    if (listBoxControl职级.SelectedIndex == -1)
                        MessageBox.Show("请选择职等");
                    else
                    {
                        SalaryDetailListForm ssForm = new SalaryDetailListForm(salary_plan, group);
                        ssForm.Owner = this;
                        ssForm.ShowDialog();
                    }
                    break;
                case "调整各职等月薪执行标准":
                    next_period = RankSalaryStandard.GetNextPeriod(salary_plan, period);
                    if (next_period != -1)
                    {
                        MessageBox.Show("不能调整" + year + cbSemiannual.Text + "的月薪执行标准，因为已经有新的标准在用");
                    }
                    else
                    {
                        int max_period = (DateTime.Today.Year + 1) * 10 + 1;
                        if (DateTime.Today.Month < 6) max_period = DateTime.Today.Year * 10 + 2;

                        if (period > max_period)
                        {
                            MessageBox.Show("不能调整" + year + cbSemiannual.Text + "的月薪执行标准，有点早了");
                        }
                        else
                        {
                            SelectInputTypeDialog sdialog = new SelectInputTypeDialog();
                            sdialog.OnSelected += s_adsi_dialog_OnSelected;
                            sdialog.ShowDialog();
                        }
                    }
                    break;
            }
        }
        private void s_adsi_dialog_OnSelected(object sender, bool isCheck)
        {
            ShowAdjustGradeSalaryStandardByIncreaseForm(isCheck);
        }
        private void ShowAdjustGradeSalaryStandardByIncreaseForm(bool isCheck)
        {
            AdjustGradeSalaryStandardByIncreaseForm aForm = new AdjustGradeSalaryStandardByIncreaseForm(salary_plan, year, semiannual, isCheck);
            aForm.Owner = this;
            aForm.ShowDialog();
        }

        private void ams_sdialog_OnSelected(object sender, bool isCheck)
        {
            ShowAdjustMonthlySalaryForm(isCheck);
        }

        private void iams_sdialog_OnSelected(object sender, bool isCheck)
        {
            ShowIndividualAdjustMonthlySalaryForm(isCheck);
        }

        private void sdialog_OnSelected(object sender, bool isCheck)
        {
            ShowAdjustGradeSalaryStandardForm(isCheck);
        }

        private void ShowAdjustGradeSalaryStandardForm(bool isCheck)
        {
            AdjustGradeSalaryStandardForm aForm = new AdjustGradeSalaryStandardForm(salary_plan, year, semiannual, isCheck);
            aForm.Owner = this;
            aForm.ShowDialog();
        }

        private void ShowAdjustMonthlySalaryForm(bool isCheck)
        {
            AdjustMonthlySalaryForm amsForm = new AdjustMonthlySalaryForm(salary_plan, group, year, semiannual, isCheck);
            amsForm.Owner = this;
            amsForm.ShowDialog();
        }

        private void ShowIndividualAdjustMonthlySalaryForm(bool isCheck)
        {
            IndividualAdjustMonthlySalaryForm iamsForm = new IndividualAdjustMonthlySalaryForm(salary_plan, group, isCheck);
            iamsForm.Owner = this;
            iamsForm.ShowDialog();
        }

        private void SelectJobGradeForm_Load(object sender, EventArgs e)
        {   
            List<JobGrade> grades = JobGrade.GetJobGrades(salary_plan);
            
            listBoxControl职级.Items.Clear();

            //可查看的级别
            List<RoleLevel> lvList = AccessController.我管理的职等.FindAll(a => a.公司编码 == company_code);

            if (command == "查看各职等管理人员薪酬执行明细" ||
                command == "查看各职等人员薪酬结构明细表" ||
                command == "录入各职等等管理人员薪酬执行明细" ||
                command == "录入异动人员薪酬执行明细")
            {
                if (company != "软件开发")
                {
                    if (lvList.Find(a => a.职等名称 == "副总经理以上") != null)
                        listBoxControl职级.Items.Add("副总经理以上");

                    if (lvList.Find(a => a.职等名称 == "管培生") != null)
                        listBoxControl职级.Items.Add("管培生");
                }
            }
            foreach (JobGrade grade in grades)
            {
                bool allow = false;
                if (lvList.Find(a => BelongToGrade(grade.名称, a.职等名称)) != null) allow = true;
                if (company == "软件开发") allow = true;
                if (allow) listBoxControl职级.Items.Add(grade.名称);
            }

            spin年度.Properties.MaxValue = DateTime.Today.Year + 1;
            spin年度.EditValue = DateTime.Today.Year;

            if(company == "软件开发")
            {
                cbSemiannual.Properties.Items.Clear();
                cbSemiannual.Properties.Items.Add("年");
                cbSemiannual.SelectedIndex = 0;
            }
        }

        //解析职等
        bool BelongToGrade(string 工资职等, string 职务等级)
        {
            string 职等 = 职务等级.Replace("级", "");
            bool 是副职等 = 职等.StartsWith("副");
            if(是副职等)
            {
                return 工资职等.EndsWith(职等);
            }
            else
            {
                string 子职等 = 工资职等.Replace(职等, "");
                return 工资职等.EndsWith(职等) && !子职等.EndsWith("副");
            }
        }

        private void btn取消_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn确定_Click(object sender, EventArgs e)
        {
            if (cbSemiannual.Visible && cbSemiannual.Text == "")
                MessageBox.Show("请选择是上半年还是下半年");
            else
            {
                OpenWindow();
            }
        }
    }
}