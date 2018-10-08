using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using Hwagain.SalaryCalculation.Components;
using System.Collections.Generic;

namespace Hwagain.SaleManageSystem.Components.Reports
{
    public partial class PrivateSalaryPayItems : DevExpress.XtraReports.UI.XtraReport
    {
        public PrivateSalaryPayItems()
        {
            InitializeComponent();
        }
        public void BindData()
        {
            lbl银行名称.Text = 银行名称;
            this.DataSource = 工资表;
        }

        public List<PrivateSalary> 工资表 { get; set; }
        public string 制表人 { get; set; }
        public string 银行名称 { get; set; }

    }

}
