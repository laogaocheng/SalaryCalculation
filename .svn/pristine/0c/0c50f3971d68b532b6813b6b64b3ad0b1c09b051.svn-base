using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using Hwagain.SalaryCalculation.Components;
using System.Collections.Generic;

namespace Hwagain.SaleManageSystem.Components.Reports
{
    public partial class SalaryCalculateReport : DevExpress.XtraReports.UI.XtraReport
    {
        public SalaryCalculateReport()
        {
            InitializeComponent();
            this.DataSource = 工资表;
            this.lbl制表人.Text = "制表人: " + AccessController.CurrentUser.姓名; 
        }
        public List<PrivateSalary> 工资表 { get; set; }
        public string 制表人 { get; set; }
        public string 审核人 { get; set; }
    }
}
