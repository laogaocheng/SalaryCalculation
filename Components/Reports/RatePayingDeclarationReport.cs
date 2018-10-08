using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using Hwagain.SalaryCalculation.Components;
using System.Collections.Generic;

namespace Hwagain.SaleManageSystem.Components.Reports
{
    public partial class RatePayingDeclarationReport : DevExpress.XtraReports.UI.XtraReport
    {
        public RatePayingDeclarationReport()
        {
            InitializeComponent();
            this.DataSource = 工资表;
        }
        public List<PersonalTax> 工资表 { get; set; }
        public string 制表人 { get; set; }

        public void GetTotalTax()
        {
            decimal totalTax = 0;
            foreach (PersonalTax pt in 工资表)
            {
                totalTax += pt.个人所得税;
            }
            lbl纳税总额.Text =  totalTax.ToString("#0.00");
        }
    }
}
