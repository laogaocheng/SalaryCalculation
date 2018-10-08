using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using YiKang.RBACS.DataObjects;
using System.Collections.Generic;
using DevExpress.XtraGrid.Views.Base;
using Hwagain.Components;
using Hwagain.SalaryCalculation.Components;
using YiKang;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;


namespace Hwagain.SalaryCalculation
{
    public partial class EditSalaryStructureForm : XtraForm
    {
        SalaryStructureEntry currSalaryStructureEntry = null;

        EmployeeInfo emp;
        MonthlySalary ms;
        decimal 满勤奖标准;
        decimal 未休年休假工资;
        decimal 交通餐饮补助标准;

        public EditSalaryStructureForm(SalaryStructureEntry entry)
        {
            // This call is required by the Windows Form Designer.
            InitializeComponent();

            // TODO: Add any initialization after the InitializeComponent call
            this.currSalaryStructureEntry = entry;
        }

        private void EditSalaryStructureForm_Load(object sender, EventArgs e)
        {
            this.Text = "员工薪酬结构录入 - " + currSalaryStructureEntry.员工编号 + " - " + (currSalaryStructureEntry.是验证录入 ? "验证录入" : "初次录入");

            emp = currSalaryStructureEntry.员工信息;
            ms = MonthlySalary.GetEffective(emp.员工编号, DateTime.Today);

            if (ms == null)
            {
                MessageBox.Show("找不到该员工的执行月薪标准，请录入标准后再试");
                Close();
            }

            满勤奖标准 = PsHelper.GetFullAttendancePayFromCache(emp.薪资体系, emp.薪等, new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1));
            未休年休假工资 = PsHelper.GetVacPayFromCache(emp.薪资体系, emp.薪等, new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1));
            交通餐饮补助标准 = PsHelper.GetTrafficSubsidies(emp.员工编号, new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1));

            lbl用户.Text = currSalaryStructureEntry.员工信息.姓名;
            lbl员工编号.Text = currSalaryStructureEntry.员工编号;
            comboBoxEdit结构类型.EditValue = currSalaryStructureEntry.类型;

            LoadData();
        }

        #region 加载数据

        protected void LoadData()
        {
            dateEdit开始执行日期.EditValue = currSalaryStructureEntry.开始执行日期;
            spinEdit合计.EditValue = currSalaryStructureEntry.年薪_合计;
            spinEdit年薪资奖励.EditValue = currSalaryStructureEntry.年薪_奖励;
            spinEdit12个月月薪.EditValue = currSalaryStructureEntry.年薪_12个月;
            spinEdit年休假.EditValue = currSalaryStructureEntry.月薪项目_年休假;
            spinEdit满勤奖.EditValue = currSalaryStructureEntry.月薪项目_满勤奖;
            spinEdit交通餐饮补贴.EditValue = currSalaryStructureEntry.月薪项目_交通餐饮补贴;
            spinEdit月工资.EditValue = currSalaryStructureEntry.月薪项目_月工资;
            spinEdit小计.EditValue = currSalaryStructureEntry.月薪项目_小计;
            spinEdit绩效工资.EditValue = currSalaryStructureEntry.月薪项目_减项_绩效工资;
            spinEdit年绩效工资.EditValue = currSalaryStructureEntry.年薪_绩效工资;
        }        

        #endregion

        #region btn保存_Click

        private void btn保存_Click(object sender, EventArgs e)
        {
            if (comboBoxEdit结构类型.Text == "")
            {
                MessageBox.Show("类型不能为空");
                return;
            }
            if (dateEdit开始执行日期.DateTime == DateTime.MinValue)
            {
                MessageBox.Show("开始执行日期不能为空");
                return;
            }
            currSalaryStructureEntry.类型 = comboBoxEdit结构类型.Text;
            currSalaryStructureEntry.开始执行日期 = dateEdit开始执行日期.DateTime;
            currSalaryStructureEntry.年薪_合计 = spinEdit合计.Value;
            currSalaryStructureEntry.年薪_奖励 = spinEdit年薪资奖励.Value;
            currSalaryStructureEntry.年薪_12个月 = spinEdit12个月月薪.Value;
            currSalaryStructureEntry.月薪项目_年休假 = spinEdit年休假.Value;
            currSalaryStructureEntry.月薪项目_满勤奖 = spinEdit满勤奖.Value;
            currSalaryStructureEntry.月薪项目_交通餐饮补贴 = spinEdit交通餐饮补贴.Value;
            currSalaryStructureEntry.月薪项目_月工资 = spinEdit月工资.Value;
            currSalaryStructureEntry.月薪项目_小计 = spinEdit小计.Value;
            currSalaryStructureEntry.月薪项目_减项_绩效工资 = spinEdit绩效工资.Value;

            currSalaryStructureEntry.年薪_绩效工资 = spinEdit年绩效工资.Value;

            currSalaryStructureEntry.录入人 = AccessController.CurrentUser.姓名;
            currSalaryStructureEntry.录入时间 = DateTime.Now;
            currSalaryStructureEntry.Save();

            Close();
        }
        #endregion

        private void comboBoxEdit结构类型_SelectedValueChanged(object sender, EventArgs e)
        {
            groupControl1.Enabled = comboBoxEdit结构类型.Text != "标准";
            groupControl2.Enabled = comboBoxEdit结构类型.Text != "标准";
            groupControl3.Enabled = comboBoxEdit结构类型.Text != "标准";

            Calulate();
        }

        private void Calulate()
        {
            spinEdit年休假.EditValue = 未休年休假工资;
            spinEdit满勤奖.EditValue = 满勤奖标准;
            spinEdit交通餐饮补贴.EditValue = 交通餐饮补助标准;

            spinEdit合计.Value = ms.执行_月薪 * 12;

            if (comboBoxEdit结构类型.Text == "标准")
            {
                spinEdit年薪资奖励.Value = 0;
                spinEdit绩效工资.Value = 0;
                spinEdit年绩效工资.Value = 0;
            }

            spinEdit合计.Value = ms.执行_月薪 * 12;
            spinEdit12个月月薪.Value = spinEdit合计.Value - spinEdit年薪资奖励.Value - spinEdit年绩效工资.Value;

            decimal 月薪 = spinEdit12个月月薪.Value / 12;
            spinEdit小计.Value = 月薪;

            spinEdit月工资.Value = 月薪 - 满勤奖标准 - 未休年休假工资 - 交通餐饮补助标准;
        }

        private void spinEdit年薪资奖励_EditValueChanged(object sender, EventArgs e)
        {
            Calulate();
        }

        private void spinEdit年绩效工资_EditValueChanged(object sender, EventArgs e)
        {
            Calulate();
        }
    }

}

