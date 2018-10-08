using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace Hwagain.SalaryCalculation.Components.Reports
{
    public partial class WageLoanVoucher : DevExpress.XtraReports.UI.XtraReport
    {
        public WageLoanVoucher(MonthlyWageLoanItem item)
        {
            InitializeComponent();

            借款记录 = item;

            xr公司.Text = 借款记录.发放单位;
            xr大写金额.Text = 借款记录.税后实发金额_大写;
            xr小写金额.Text = "￥" + 借款记录.税后实发金额.ToString("0.00");
        }

        public MonthlyWageLoanItem 借款记录 { get; set; }
    }
}
