using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using System.IO;

namespace Hwagain.SalaryCalculation.Components.UserControls
{
    public partial class ReportBase : DevExpress.XtraEditors.XtraUserControl
    {
        public ReportBase()
        {
            InitializeComponent();
        }
        protected XtraReport fReport;
		protected string fileName = "";

				
		public virtual XtraReport Report { 
			get { return fReport; } 
			set { fReport = value; }
		}	
			
		public virtual void Activate() {
            System.ComponentModel.DXDisplayNameAttribute.UseResourceManager = true;
			Report = CreateReport();
            Report.FillDataSource();
			File.Delete(fileName);
		}
		protected virtual XtraReport CreateReport() {
			return null;
		}
    }
}
