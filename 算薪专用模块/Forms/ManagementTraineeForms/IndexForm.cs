using DevExpress.XtraEditors;
using Hwagain.Common;
using Hwagain.Common.Components;
using Hwagain.SalaryCalculation.Components.Common;
using Hwagain.SalaryCalculation.Components.Forms.IndexForms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace Hwagain.SalaryCalculation.Components
{
    public partial class IndexForm : XtraForm
    {
        string command = ""; //命令

        public IndexForm(string cmd)
        {
            command = cmd;
            InitializeComponent();
            Init();
        }

        void Init()
        {
            InitTreeView();
        }

        #region InitTreeView

        private void InitTreeView()
        {
            int division_start = 2015;
            int division_end = DateTime.Today.Year;

            //构造第二层目录
            foreach (TreeNode node in treeView1.Nodes)
            {
                string grade = node.Name;

                for (int division = division_start; division <= division_end; division++)
                {
                    TreeNode division_node = new TreeNode(division.ToString() + " 届");

                    if (CheckUseType())
                    {
                        //类别
                        string[] type_arr = GetTypeList(division, grade);
                        for (int i = 0; i < type_arr.Length; i++)
                        {
                            string type = type_arr[i];
                            FormParameters fp = new FormParameters();
                            fp.Parameters = new object[] { division.ToString(), grade, type };
                            fp.Name = command;
                            fp.Description = command;

                            TreeNode type_node = new TreeNode(type);
                            type_node.Tag = fp;
                            //如果是薪酬计划，先判断是否已经录入了，如果没有录入，不显示
                            if (command == "薪酬计划表" || command == "年薪提资周期及各次提幅标准表")
                            {
                                int count = ManagementTraineePayRiseStandard.Count(division.ToString(), grade, type);
                                if(count > 0)
                                    division_node.Nodes.Add(type_node);
                            }
                            else
                                division_node.Nodes.Add(type_node);
                        }
                    }
                    else
                    {
                        FormParameters fp = new FormParameters();
                        fp.Parameters = new object[] { division.ToString(), grade };
                        fp.Name = command;
                        fp.Description = command;

                        division_node.Tag = fp;
                    }
                    node.Nodes.Add(division_node);
                    node.Expand();
                }
            }
        }

        #endregion

        #region CheckUseType

        //检查是否需要类别参数
        private bool CheckUseType()
        {
            List<string> cmd_no_use_type_list = new List<string>();
            
            cmd_no_use_type_list.Add("专业属性确认");
            cmd_no_use_type_list.Add("月薪明细表");
            cmd_no_use_type_list.Add("录入管培生基本信息");
            cmd_no_use_type_list.Add("录入综合能力评定结果");
            cmd_no_use_type_list.Add("个人年度评定结果及提资表");
            cmd_no_use_type_list.Add("年薪计算表");
            cmd_no_use_type_list.Add("月薪计算表");
            cmd_no_use_type_list.Add("月薪明细表");
            cmd_no_use_type_list.Add("录入个人提资表");

            return !cmd_no_use_type_list.Contains(command);
        }
        #endregion

        #region GetTypeList

        private string[] GetTypeList(int division, string grade)
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
                    if (division <= 2017)
                        return types_1_2017;
                    else
                        return types_1_2018;
                case "二级":
                    if (division <= 2017)
                        return types_2_2017;
                    else
                        return types_2_2018;
                case "三级":
                    if (division <= 2017)
                        return types_3_2017;
                    else
                        return types_3_2018;
            }
            return null;
        }

        #endregion

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Goto(e.Node);
        }

        private void Goto(TreeNode node)
        {
            if (node.Tag != null)
            {
                FormParameters formParams = node.Tag as FormParameters;
                if (formParams != null) //有参数
                {
                    ShowWindow(formParams);
                }
                else //无参数
                {
                    string tag = node.Tag as string;
                    switch (tag)
                    {
                        case "数据库配置":
                            DatabaseConfig dbConfig = new DatabaseConfig();
                            dbConfig.ShowDialog(); break;
                        case "修改密码":
                            using (FormChangePassword pwdForm = new FormChangePassword())
                            {
                                pwdForm.ShowDialog();
                            }
                            break;
                    }
                }
            }
        }

        #region ShowWindow

        //显示窗口
        

        #endregion

        private void IndexForm_Load(object sender, EventArgs e)
        {

        }

        private void treeView1_DoubleClick(object sender, EventArgs e)
        {
            Goto(treeView1.SelectedNode);
        }

        private void IndexForm_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        #region ShowWindow

        public void ShowWindow(FormParameters formParams)
        {
            string division = (string)formParams.Parameters[0];
            string grade = (string)formParams.Parameters[1];

            switch (formParams.Name)
            {
                case "录入管培生基本信息":
                    SelectInputTypeDialog i_t_dialog = new SelectInputTypeDialog();
                    if (i_t_dialog.ShowDialog() == DialogResult.OK)
                    {
                        TraineeInfoForm traineeInfoForm = new TraineeInfoForm(division, grade, i_t_dialog.是验证录入);
                        traineeInfoForm.Owner = this;
                        traineeInfoForm.ShowDialog();
                    }
                    break;
                case "专业属性确认":
                    SelectInputTypeDialog s_p_dialog = new SelectInputTypeDialog();
                    if(s_p_dialog.ShowDialog() == DialogResult.OK)
                    {
                        SpecialtyPropertyForm specialtyPropertyForm = new SpecialtyPropertyForm(division, s_p_dialog.是验证录入);
                        specialtyPropertyForm.Owner = this;
                        specialtyPropertyForm.ShowDialog();
                    }
                    break;
                case "录入提资及增幅计划":
                    SelectInputTypeDialog r_r_dialog = new SelectInputTypeDialog();
                    if(r_r_dialog.ShowDialog() == DialogResult.OK)
                    {
                        ShowRiseRateInputForm(formParams, r_r_dialog.是验证录入);
                    }
                    break;
                case "录入综合能力评定结果":
                    SelectInputTypeDialog taa_dialog = new SelectInputTypeDialog();
                    if(taa_dialog.ShowDialog() == DialogResult.OK)
                    {                        
                        TraineeAnnualAssessmentForm form = new TraineeAnnualAssessmentForm(division, grade, DateTime.Today.Year, taa_dialog.是验证录入);
                        form.Owner = this;
                        form.ShowDialog();
                    }
                    break; 
                case "录入个人提资表":                
                case "个人年度评定结果及提资表":
                    TraineePersonalAbilityListForm trainee_list_4_show_dialog = new TraineePersonalAbilityListForm(division, grade);
                    trainee_list_4_show_dialog.Owner = this;
                    trainee_list_4_show_dialog.ShowDialog();
                    break;
                case "年薪提资周期及各次提幅标准表":
                    ShowRiseRateForm(formParams);
                    break;
                case "薪酬计划表":
                    ShowWindow(typeof(TraineeSalaryPlanForm), formParams.Parameters );
                    break;
                case "年薪计算表":
                    ShowWindow(typeof(TraineeYearlySalaryCalculatorForm), new object[] { division, grade, DateTime.Today.Year });
                    break;
                case "月薪计算表":
                    ShowWindow(typeof(TraineeMonthlySalaryCalculatorForm), new object[] { division, grade, DateTime.Today.Year });
                    break;
                case "月薪明细表":
                    ShowWindow(typeof(TraineeMonthlySalaryItemsForm), new object[] { division, grade, DateTime.Today.Year });
                    break;
            }
        }

        #region ShowRiseRateInputForm

        private void ShowRiseRateInputForm(FormParameters formParams, bool isCheck)
        {
            string division = (string)formParams.Parameters[0];
            string grade = (string)formParams.Parameters[1];
            string type = (string)formParams.Parameters[2];

            UpStepType ust = ManagementTraineePayStandard.GetUpStepType(division, grade, type);
            switch (ust)
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
        #endregion

        #region ShowRiseRateForm

        private void ShowRiseRateForm(FormParameters formParams)
        {
            string division = (string)formParams.Parameters[0];
            string grade = (string)formParams.Parameters[1];
            string type = (string)formParams.Parameters[2];

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
        #endregion

        #region ShowWindow

        public void ShowWindow(Type windowType, object[] parameters)
        {
            Type[] types = Type.EmptyTypes;
            if (parameters != null)
            {
                types = new Type[parameters.Length];
                for (int i = 0; i < parameters.Length; i++)
                {
                    types[i] = parameters[i].GetType();
                }
            }
            ConstructorInfo constructorInfoObj = windowType.GetConstructor(types);
            if (constructorInfoObj == null)
                MessageBox.Show(windowType.FullName + "指定参数的构造器");
            else
            {
                Form form = constructorInfoObj.Invoke(parameters) as Form;
                form.Tag = parameters;
                form.Owner = this;
                form.ShowDialog();
            }
        }
        #endregion

        #endregion

        private void IndexForm_Shown(object sender, EventArgs e)
        {
            if (this.Owner != null && this.Owner.Visible) this.Owner.Hide();
        }

        private void IndexForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.Owner != null) this.Owner.Show();
        }
    }
}
