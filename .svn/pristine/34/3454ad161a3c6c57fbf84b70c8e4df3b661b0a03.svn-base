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
    public partial class SelectCompanyForm : DevExpress.XtraEditors.XtraForm
    {
        string command = null;
        
        public SelectCompanyForm()
        {
            InitializeComponent();
        }

        public SelectCompanyForm(string cmd) : this()
        {
            this.command = cmd;
        }

        void OpenWindow(string company)
        {
            if (command == null)
            {
                FunctionForm form = new FunctionForm(company);
                form.Owner = this;
                form.ShowDialog();
            }
            else
            {
                switch (command)
                {
                    case "职等管理":
                        EditJobGradeForm jobGradeForm = new EditJobGradeForm(company);
                        jobGradeForm.Owner = this;
                        jobGradeForm.ShowDialog();
                        break;
                    default:
                        SelectJobGradeForm form = new SelectJobGradeForm(company, command);
                        form.Owner = this;
                        form.ShowDialog();

                        break;
                }
            }
        }

        private void btn集团总部_Click(object sender, EventArgs e)
        {
            OpenWindow("集团总部");
        }

        private void btn销售公司_Click(object sender, EventArgs e)
        {
            OpenWindow("销售公司");
        }

        private void btn赣州纸业_Click(object sender, EventArgs e)
        {
            OpenWindow("赣州纸业");
        }

        private void btn赣州纸品_Click(object sender, EventArgs e)
        {
            OpenWindow("赣州纸品");
        }

        private void btn广西竹林_Click(object sender, EventArgs e)
        {
            OpenWindow("广西竹林");
        }

        private void btn赣州竹林_Click(object sender, EventArgs e)
        {
            OpenWindow("赣州竹林");
        }

        private void btn南宁纸业_Click(object sender, EventArgs e)
        {
            OpenWindow("南宁纸业");
        }

        private void btn华劲人纸品_Click(object sender, EventArgs e)
        {
            OpenWindow("华劲人纸品");
        }

        private void btn软件开发_Click(object sender, EventArgs e)
        {
            OpenWindow("软件开发");
        }
    }
}