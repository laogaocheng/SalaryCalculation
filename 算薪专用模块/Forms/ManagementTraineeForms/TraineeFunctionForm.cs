using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Hwagain.SalaryCalculation.Components.Forms
{
    public partial class TraineeFunctionForm : DevExpress.XtraEditors.XtraForm
    {
        public TraineeFunctionForm()
        {
            InitializeComponent();
            SetButtonEnableByRight();
        }

        #region SetButtonEnableByRight

        private void SetButtonEnableByRight()
        {
            btn专业属性确认.Enabled = AccessController.CheckInputEmpPayRate() || AccessController.CheckLookupStepPayRate();
            btn录入管培生基本信息.Enabled = AccessController.CheckInputEmpPayRate();
            btn录入综合能力评定结果.Enabled = AccessController.CheckInputEmpPayRate();
            btn录入提资及增幅计划.Enabled = AccessController.CheckInputEmpPayRate();

            btn各次提幅标准表.Enabled = AccessController.CheckInputEmpPayRate();
            btn薪酬计划表.Enabled = AccessController.CheckInputEmpPayRate();
            btn个人年度评定结果及提资表.Enabled = AccessController.CheckInputEmpPayRate();
            btn年薪计算表.Enabled = AccessController.CheckInputEmpPayRate();
            btn月薪计算表.Enabled = AccessController.CheckInputEmpPayRate();
            btn月薪明细表.Enabled = AccessController.CheckInputEmpPayRate();
        }

        #endregion

        private void TraineeFunctionForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.Owner != null) this.Owner.Show();
        }

        private void TraineeFunctionForm_Shown(object sender, EventArgs e)
        {
            if (this.Owner != null && this.Owner.Visible) this.Owner.Hide();
        }

        private void btn各职等职级月薪执行标准表_Click(object sender, EventArgs e)
        {
            OpenWindow("专业属性确认");
        }

        private void btn录入职级及职级工资_Click(object sender, EventArgs e)
        {
            OpenWindow("录入管培生基本信息");
        }

        private void btn各职等管理人员薪酬执行明细_Click(object sender, EventArgs e)
        {
            OpenWindow("录入提资及增幅计划");
        }

        private void btn录入各职等薪酬执行明细_Click(object sender, EventArgs e)
        {
            OpenWindow("薪酬计划表");
        }

        void OpenWindow(string command)
        {
            IndexForm form = new IndexForm(command);
            form.Owner = this;
            form.ShowDialog();
        }

        private void btn录入综合能力评定结果_Click(object sender, EventArgs e)
        {
            OpenWindow("录入综合能力评定结果");
        }

        private void btn各次提幅标准表_Click(object sender, EventArgs e)
        {
            OpenWindow("年薪提资周期及各次提幅标准表");
        }

        private void btn个人年度评定结果及提资表_Click(object sender, EventArgs e)
        {
            OpenWindow("个人年度评定结果及提资表");
        }

        private void btn年薪计算表_Click(object sender, EventArgs e)
        {
            OpenWindow("年薪计算表");
        }

        private void btn月薪计算表_Click(object sender, EventArgs e)
        {
            OpenWindow("月薪计算表");
        }

        private void btn月薪明细表_Click(object sender, EventArgs e)
        {
            OpenWindow("月薪明细表");
        }
    }
}