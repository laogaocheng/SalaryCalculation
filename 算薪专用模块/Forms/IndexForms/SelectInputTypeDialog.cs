using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Hwagain.SalaryCalculation.Components.Forms.IndexForms
{
    public partial class SelectInputTypeDialog : DevExpress.XtraEditors.XtraForm
    {
        public delegate void SelectInputTypeHandle(object sender, bool isCheck);
        public event SelectInputTypeHandle OnSelected;
        
        public SelectInputTypeDialog()
        {
            InitializeComponent();
        }

        private void btn初次录入_Click(object sender, EventArgs e)
        {
            是验证录入 = false;
            if (OnSelected != null)
            {
                OnSelected(sender, false);
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btn验证录入_Click(object sender, EventArgs e)
        {
            是验证录入 = true;
            if (OnSelected != null)
            {
                OnSelected(sender, true);                
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void SelectInputTypeDialog_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        public bool 是验证录入 { get; set; }
    }
}