using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Hwagain.SalaryCalculation.Components.Forms.ListForms
{
    public partial class ErrorDialog : DevExpress.XtraEditors.XtraForm
    {
        List<ErrorLine> errors = new List<ErrorLine>();

        public ErrorDialog(List<string> err_list)
        {
            int x = 1;
            foreach (string error in err_list)
            {
                ErrorLine error_line = new ErrorLine();
                error_line.序号 = x;
                error_line.描述 = error;
                errors.Add(error_line);

                x++;
            }
            InitializeComponent();
        }

        private void ErrorDialog_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = errors;
            gridControl1.RefreshDataSource();
        }
    }

    class ErrorLine
    {
        public int 序号 { get; set; }
        public string 描述 { get; set; }
    }
}