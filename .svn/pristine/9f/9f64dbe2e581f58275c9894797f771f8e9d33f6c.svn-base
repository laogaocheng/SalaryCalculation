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
using Hwagain.SalaryCalculation.Components.Forms.IndexForms;

namespace Hwagain.SalaryCalculation.Components.Forms
{
    public partial class SelectTraineeTypeForm : DevExpress.XtraEditors.XtraForm
    {
        string command = "";

        string division;
        string grade;
        string type;

        public SelectTraineeTypeForm(string cmd)
        {
            this.command = cmd;
            InitializeComponent();

            if (cmd == "专业属性确认" ||
                cmd == "录入管培生基本信息" ||
                cmd == "录入综合能力评定结果" ||
                cmd == "个人年度评定结果及提资表" ||
                cmd == "年薪计算表" ||
                cmd == "月薪计算表" ||
                cmd == "月薪明细表" ||
                cmd == "录入个人提资表")
            {
                this.Text = "请选择届别";
                if (cmd != "专业属性确认") this.Text = "请选择届别和岗位级别";
                listBoxControl类别.Visible = false;
                cb岗位级别.Enabled = cmd != "专业属性确认";
                this.Size = new Size(this.Size.Width, this.Size.Height - 360);
                btn确定.Location = new Point(btn确定.Location.X, btn确定.Location.Y - 360);
                btn取消.Location = new Point(btn取消.Location.X, btn取消.Location.Y - 360);
            }
        }

        private void SelectTraineeTypeForm_Shown(object sender, EventArgs e)
        {
            if (this.Owner != null && this.Owner.Visible) this.Owner.Hide();
        }

        private void SelectTraineeTypeForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.Owner != null) this.Owner.Show();
        }

        void OpenWindow()
        {
            division = Convert.ToString(spin年度.Value);
            grade = cb岗位级别.Text;
            type = (string)listBoxControl类别.SelectedItem;

            switch (command)
            {
                case "录入管培生基本信息":
                    if (listBoxControl类别.SelectedIndex == -1)
                        MessageBox.Show("请选择专业属性或岗位类别");
                    else
                    {
                        SelectInputTypeDialog i_t_dialog = new SelectInputTypeDialog();
                        i_t_dialog.OnSelected += i_t_dialog_OnSelected;
                        i_t_dialog.ShowDialog();
                    }
                    break;
                case "专业属性确认":
                    SelectInputTypeDialog s_p_dialog = new SelectInputTypeDialog();
                    s_p_dialog.OnSelected += s_p_dialog_OnSelected;
                    s_p_dialog.ShowDialog();
                    break;
                case "录入提资及增幅计划":
                    SelectInputTypeDialog r_r_dialog = new SelectInputTypeDialog();
                    r_r_dialog.OnSelected += r_r_dialog_OnSelected;
                    r_r_dialog.ShowDialog();
                    break;
                case "薪酬计划表":
                    ShowTraineeSalaryPlanForm();
                    break;
                case "录入综合能力评定结果":
                    SelectInputTypeDialog taa_dialog = new SelectInputTypeDialog();
                    taa_dialog.OnSelected += taa_dialog_OnSelected;
                    taa_dialog.ShowDialog();
                    break;
                case "录入个人提资表":
                    TraineePersonalAbilityListForm trainee_list_dialog = new TraineePersonalAbilityListForm(division, grade);
                    trainee_list_dialog.OnSelected += trainee_list_dialog_OnSelected;
                    trainee_list_dialog.ShowDialog();
                    break;
                case "年薪提资周期及各次提幅标准表":
                    ShowRiseRateForm();
                    break;
                case "个人年度评定结果及提资表":
                    TraineePersonalAbilityListForm trainee_list_4_show_dialog = new TraineePersonalAbilityListForm(division, grade);
                    trainee_list_4_show_dialog.OnSelected += trainee_list_4_show_dialog_OnSelected;
                    trainee_list_4_show_dialog.ShowDialog();
                    break;
                case "年薪计算表":
                    TraineeYearlySalaryCalculatorForm trsc_form = new TraineeYearlySalaryCalculatorForm(division, grade, DateTime.Today.Year);
                    trsc_form.Owner = this;
                    trsc_form.ShowDialog();
                    break;
                case "月薪计算表":
                    TraineeMonthlySalaryCalculatorForm msc_form = new TraineeMonthlySalaryCalculatorForm(division, grade, DateTime.Today.Year);
                    msc_form.Owner = this;
                    msc_form.ShowDialog();
                    break;
                case "月薪明细表":
                    TraineeMonthlySalaryItemsForm msci_form = new TraineeMonthlySalaryItemsForm(division, grade, DateTime.Today.Year);
                    msci_form.Owner = this;
                    msci_form.ShowDialog();
                    break;
            }
        }

        private void trainee_list_4_show_dialog_OnSelected(object sender, ManagementTraineeInfo trainee)
        {
            TraineePersonalSalaryPlanForm form = new TraineePersonalSalaryPlanForm(trainee);
            form.Owner = this;
            form.ShowDialog();
        }

        private void trainee_list_dialog_OnSelected(object sender, ManagementTraineeInfo trainee)
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
            stt_dialog.ShowDialog();
            bool isCheck = stt_dialog.是验证录入;

            TraineeSalaryStandardInputForm form = new TraineeSalaryStandardInputForm(trainee, isCheck);
            form.Owner = this;
            form.ShowDialog();
        }

        private void taa_dialog_OnSelected(object sender, bool isCheck)
        {
            ShowTraineeAnnualAssessmentForm(isCheck);
        }

        private void ShowTraineeAnnualAssessmentForm(bool isCheck)
        {
            TraineeAnnualAssessmentForm form = new TraineeAnnualAssessmentForm(division, grade, DateTime.Today.Year, isCheck);
            form.Owner = this;
            form.ShowDialog();
        }

        private void ShowTraineeSalaryPlanForm()
        {
            TraineeSalaryPlanForm traineeSalaryPlanForm = new TraineeSalaryPlanForm(division, grade, type);
            traineeSalaryPlanForm.Owner = this;
            traineeSalaryPlanForm.ShowDialog();
        }

        private void r_r_dialog_OnSelected(object sender, bool isCheck)
        {
            ShowRiseRateInputForm(isCheck);
        }

        private void s_p_dialog_OnSelected(object sender, bool isCheck)
        {
            ShowSpecialtyPropertyForm(isCheck);
        }

        private void i_t_dialog_OnSelected(object sender, bool isCheck)
        {
            ShowTraineeInfoForm(isCheck);
        }
        private void ShowTraineeInfoForm(bool isCheck)
        {
            TraineeInfoForm traineeInfoForm = new TraineeInfoForm(division, grade, isCheck);
            traineeInfoForm.Owner = this;
            traineeInfoForm.ShowDialog();
        }

        private void ShowSpecialtyPropertyForm(bool isCheck)
        {
            SpecialtyPropertyForm specialtyPropertyForm = new SpecialtyPropertyForm(division, isCheck);
            specialtyPropertyForm.Owner = this;
            specialtyPropertyForm.ShowDialog();
        }
        private void ShowRiseRateForm()
        {
            UpStepType ust = ManagementTraineePayStandard.GetUpStepType(division, grade, type);
            switch (ust)
            {
                case UpStepType.五年两段三类:
                    RiseRate52Form riseRate52Form = new RiseRate52Form(division, grade, type);
                    riseRate52Form.Owner = this;
                    riseRate52Form.ShowDialog();
                    break;
                case UpStepType.五年两段四类:
                    RiseRate51Form riseRate51Form = new RiseRate51Form(division, grade, type);
                    riseRate51Form.Owner = this;
                    riseRate51Form.ShowDialog();
                    break;
                case UpStepType.五年三段四类:
                    RiseRate53Form riseRate62Form = new RiseRate53Form(division, grade, type);
                    riseRate62Form.Owner = this;
                    riseRate62Form.ShowDialog();
                    break;
                case UpStepType.七年两段五类:
                    RiseRate71Form riseRate71Form = new RiseRate71Form(division, grade, type);
                    riseRate71Form.Owner = this;
                    riseRate71Form.ShowDialog();
                    break;
                case UpStepType.七年三段五类:
                    RiseRate72Form riseRate72Form = new RiseRate72Form(division, grade, type);
                    riseRate72Form.Owner = this;
                    riseRate72Form.ShowDialog();
                    break;
            }
        }
        private void ShowRiseRateInputForm(bool isCheck)
        {
            UpStepType ust = ManagementTraineePayStandard.GetUpStepType(division, grade, type);
            switch(ust)
            {
                case UpStepType.五年两段三类:
                    RiseRate52InputForm riseRate52InputForm = new RiseRate52InputForm(division, grade, type, isCheck);
                    riseRate52InputForm.Owner = this;
                    riseRate52InputForm.ShowDialog();
                    break;
                case UpStepType.五年两段四类:
                    RiseRate51InputForm riseRate51InputForm = new RiseRate51InputForm(division, grade, type, isCheck);
                    riseRate51InputForm.Owner = this;
                    riseRate51InputForm.ShowDialog();
                    break;
                case UpStepType.五年三段四类:
                    RiseRate53InputForm riseRate62InputForm = new RiseRate53InputForm(division, grade, type, isCheck);
                    riseRate62InputForm.Owner = this;
                    riseRate62InputForm.ShowDialog();
                    break;
                case UpStepType.七年两段五类:
                    RiseRate71InputForm riseRate71InputForm = new RiseRate71InputForm(division, grade, type, isCheck);
                    riseRate71InputForm.Owner = this;
                    riseRate71InputForm.ShowDialog();
                    break;
                case UpStepType.七年三段五类:
                    RiseRate72InputForm riseRate72InputForm = new RiseRate72InputForm(division, grade, type, isCheck);
                    riseRate72InputForm.Owner = this;
                    riseRate72InputForm.ShowDialog();
                    break;
            }  
        }

        private void SelectTraineeTypeForm_Load(object sender, EventArgs e)
        {
            spin年度.Properties.MaxValue = DateTime.Today.Year + 1;
            spin年度.EditValue = DateTime.Today.Year;

            InitTypeList();
        }

        private void InitTypeList()
        {
            string[] types_1_2017 = new string[] { "本科", "硕士" };
            string[] types_2_2017 = new string[] { "专硕", "专本", "普硕", "普本" };
            string[] types_3_2017 = new string[] { "专硕", "专本", "普硕", "普本", "营林硕", "营林本" };
            string[] types_1_2018 = new string[] { "本科", "硕士" };
            string[] types_2_2018 = new string[] { "专硕", "专本", "普硕", "普本" };
            string[] types_3_2018 = new string[] { "专硕", "专本", "普硕", "普本", "计算机硕", "计算机本", "营林硕", "营林本" };

            switch (grade)
            {
                case "一级":
                    if(Convert.ToInt32(division) <=2017)
                        BindItems(types_1_2017);
                    else
                        BindItems(types_1_2018);
                    break;
                case "二级":
                    if (Convert.ToInt32(division) <= 2017)
                        BindItems(types_2_2017);
                    else
                        BindItems(types_2_2018);
                    break;
                case "三级":
                    if (Convert.ToInt32(division) <= 2017)
                        BindItems(types_2_2017);
                    else
                        BindItems(types_2_2018);
                    break;
            }
        }

        void BindItems(string[] arr)
        {
            listBoxControl类别.Items.Clear();
            for(int i=0; i < arr.Length; i++)
            {
                listBoxControl类别.Items.Add(arr[i]);
            }
        }

        private void btn取消_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn确定_Click(object sender, EventArgs e)
        {
            if (cb岗位级别.Visible && cb岗位级别.Enabled && cb岗位级别.Text == "")
                MessageBox.Show("请选择岗位级别");
            else
            {
                OpenWindow();
            }
        }

        private void cb岗位级别_SelectedIndexChanged(object sender, EventArgs e)
        {
            grade = cb岗位级别.Text;
            InitTypeList();
        }
    }
}