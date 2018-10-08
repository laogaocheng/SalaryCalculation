using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hwagain.SalaryCalculation.Components.Forms.Dialogs
{
    public partial class SalaryDecuctionInfoForm : XtraForm
    {
        PrivateSalary ps = null;
        public SalaryDecuctionInfoForm(PrivateSalary ps)
        {
            InitializeComponent();
            this.ps = ps;

            textEdit契约津贴标准.Text = ps.契约津贴标准.ToString("#0.00");
            textEdit工资借款标准.Text = ps.工资借款标准.ToString("#0.00");
            textEdit福利借款标准.Text = ps.福利借款标准.ToString("#0.00");
            textEdit报账工资标准.Text = ps.报账工资标准.ToString("#0.00");
            textEdit工资借款标准.Text = ps.工资借款标准.ToString("#0.00");
            textEdit薪资奖励每月分摊金额.Text = ps.薪资奖励_月摊.ToString("#0.00");
            textEdit本月执行绩效工资额.Text = ps.本月执行绩效工资额.ToString("#0.00");
            textEdit合计.Text = ps.职级工资减项.ToString("#0.00");

            textEdit年薪资奖励.Text = (ps.薪资奖励_月摊 * 12).ToString("#0.00");
            textEdit年绩效工资.Text = (ps.年绩效工资_月摊 * 12).ToString("#0.00");
            textEdit年绩效工资每月分摊.Text = ps.年绩效工资_月摊.ToString("#0.00");
        }

        private void btn确定_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SalaryDecuctionInfoForm_Leave(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
