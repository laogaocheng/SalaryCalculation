using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace Hwagain.SalaryCalculation.Components.Reports
{
    public partial class RembursementSalaryVoucher : DevExpress.XtraReports.UI.XtraReport
    {
        public RembursementSalaryVoucher(MonthlyRembursementSalaryItem item)
        {
            InitializeComponent();

            报账记录 = item;

            xr标题.Text = string.Format("{0} 年 {1}月份支出单", 报账记录.年, 报账记录.月);
            xr实支金额.Text = 报账记录.实际报销金额_大写;
            xr复核金额.Text = "￥" + 报账记录.实际报账金额.ToString("0.00");
            xr核销金额.Text = "￥" + 报账记录.实际报账金额.ToString("0.00");
        }

        public MonthlyRembursementSalaryItem 报账记录 { get; set; }
    }
}
