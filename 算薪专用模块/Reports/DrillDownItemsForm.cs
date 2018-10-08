using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using DevExpress.XtraPivotGrid;

namespace Hwagain.SalaryCalculation.Components
{
    public partial class DrillDownItemsForm : DevExpress.XtraEditors.XtraForm
    {
        PivotDrillDownDataSource ds = null;
        public DrillDownItemsForm(PivotDrillDownDataSource pivotDrillDownDataSource)
        {
            InitializeComponent();
            ds = pivotDrillDownDataSource;
        }

        #region DrillDownItems_Load

        private void DrillDownItems_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = ds;
        }
        #endregion

    }
}