using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using Hwagain.SalaryCalculation.Components;
using System.Collections.Generic;

namespace Hwagain.SaleManageSystem.Components.Reports
{
    public partial class AuditingPayByDeptReport : DevExpress.XtraReports.UI.XtraReport
    {
        public AuditingPayByDeptReport()
        {
            InitializeComponent();
            this.DataSource = 工资表;
        }
        public List<PrivateSalary> 工资表 { get; set; }
    }
}
