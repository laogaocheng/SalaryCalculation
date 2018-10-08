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
using Hwagain.SalaryCalculation.Components;

namespace Hwagain.Common.Components
{
    public partial class DeveloperConfig : DevExpress.XtraEditors.XtraForm
    {
        string key = "Developers";

        public DeveloperConfig()
        {
            InitializeComponent();
        }

        #region btn确定_Click

        private void btn确定_Click(object sender, EventArgs e)
        {
            
            string developers = text开发人员名单.Text;

            Developer.SetDeveloperList(developers);

            this.DialogResult = DialogResult.OK;
            this.Close();

        }

        
        #endregion

        #region btn取消_Click

        private void btn取消_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
        #endregion

        #region DeveloperConfig_Load

        private void DeveloperConfig_Load(object sender, EventArgs e)
        {
            List<string> developers = Developer.GetDeveloperList();
            text开发人员名单.Text = string.Join("，", developers.ToArray());
        }
        #endregion

    }
}