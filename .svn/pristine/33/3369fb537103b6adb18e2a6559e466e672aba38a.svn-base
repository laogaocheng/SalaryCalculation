using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Hwagain.SalaryCalculation.Components.Forms.IndexForms
{
    public partial class FunctionForm : DevExpress.XtraEditors.XtraForm
    {
        string company;
        
        public FunctionForm(string company)
        {
            this.company = company;
            InitializeComponent();
            SetButtonEnableByRight();
        }

        #region SetButtonEnableByRight

        private void SetButtonEnableByRight()
        {
            btn各职等职级月薪执行标准表.Enabled = AccessController.CheckInputEmpPayRate() || AccessController.CheckLookupStepPayRate();
            btn录入职级及职级工资.Enabled = AccessController.CheckInputEmpPayRate();
            btn各职等管理人员薪酬执行明细.Enabled = AccessController.CheckInputPersonPayRate();
            btn录入各职等薪酬执行明细.Enabled = AccessController.CheckInputPersonPayRate();
            btn录入异动人员薪酬执行明细.Enabled = AccessController.CheckInputPersonPayRate();
            btn各职等人员薪酬结构明细表.Enabled = AccessController.CheckInputPersonPayRate();
            btn调整各职等月薪执行标准.Enabled = AccessController.CheckInputPersonPayRate();
            btn各职等人员薪酬发放明细表.Enabled = AccessController.CheckInputPersonPayRate();
        }

        #endregion

        private void FunctionForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.Owner != null) this.Owner.Show();
        }

        private void FunctionForm_Shown(object sender, EventArgs e)
        {
            if (this.Owner != null) this.Owner.Hide();
        }

        private void btn各职等职级月薪执行标准表_Click(object sender, EventArgs e)
        {
            OpenWindow("查看各职等职级月薪执行标准");
        }

        private void btn录入职级及职级工资_Click(object sender, EventArgs e)
        {
            OpenWindow("录入职级及职级工资");
        }

        private void btn各职等管理人员薪酬执行明细_Click(object sender, EventArgs e)
        {
            OpenWindow("查看各职等管理人员薪酬执行明细");
        }

        private void btn录入各职等薪酬执行明细_Click(object sender, EventArgs e)
        {
            OpenWindow("录入各职等等管理人员薪酬执行明细");
        }

        void OpenWindow(string command)
        {
            SelectJobGradeForm form = new SelectJobGradeForm(company, command);
            form.Owner = this;
            form.ShowDialog();
        }

        private void btn录入异动人员薪酬执行明细_Click(object sender, EventArgs e)
        {
            OpenWindow("录入异动人员薪酬执行明细");
        }

        private void btn各职等人员薪酬结构明细表_Click(object sender, EventArgs e)
        {
            OpenWindow("查看各职等人员薪酬结构明细表");
        }

        private void btn各职等人员薪酬发放明细表_Click(object sender, EventArgs e)
        {
            OpenWindow("查看各职等人员薪酬发放明细表"); 
        }

        private void btn调整各职等月薪执行标准_Click(object sender, EventArgs e)
        {
            OpenWindow("调整各职等月薪执行标准");
        }
    }
}