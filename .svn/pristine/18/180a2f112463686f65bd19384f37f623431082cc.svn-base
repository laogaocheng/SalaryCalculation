using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

using System.Windows.Forms;
using YiKang.RBACS.DataObjects;
using System.Collections.Generic;
using DevExpress.XtraGrid.Views.Base;
using Hwagain.Components;
using Hwagain.SalaryCalculation.Components;
using YiKang;
using DevExpress.XtraEditors;


namespace Hwagain.SalaryCalculation
{
    public partial class ViewLog : UserControl
    {
        List<Log> logList = new List<Log>();
        public ViewLog()
        {
            // This call is required by the Windows Form Designer.
            InitializeComponent();

            // TODO: Add any initialization after the InitializeComponent call
        }
        private void ViewLog_Load(object sender, System.EventArgs e)
        {
            logList = Log.GetLog(DateTime.Now.AddDays(-60), DateTime.Now);
            gridControl1.DataSource = logList;
        }

        private void gridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
        }

        private void gridView1_CustomColumnDisplayText(object sender, CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.Caption == "类型")
            {
                e.DisplayText = Enum.GetName(typeof(LogType), e.Value);
            }
        }

        private void gridView1_HiddenEditor(object sender, EventArgs e)
        {
            this.Show();
        }
    }

}

