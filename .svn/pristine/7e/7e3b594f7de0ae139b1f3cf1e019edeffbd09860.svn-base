using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Hwagain.SalaryCalculation.Modules;

namespace Hwagain.SalaryCalculation.Forms
{
    public partial class BaseDataManageForm : DevExpress.XtraEditors.XtraForm
    {
        public BaseDataManageForm()
        {
            InitializeComponent();
        }

        private void BaseDataManageForm_Load(object sender, EventArgs e)
        {
            BaseDataModule mod = new BaseDataModule();
            mod.Dock = DockStyle.Fill;
            this.Controls.Add(mod);
        }
    }
}