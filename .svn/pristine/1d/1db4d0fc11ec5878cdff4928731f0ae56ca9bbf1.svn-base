using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.IO;

namespace Hwagain.SalaryCalculation.Components.Common
{
    public partial class FormChangePassword : DevExpress.XtraEditors.XtraForm
    {
        public FormChangePassword()
        {
            InitializeComponent();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            bool loginSucess = AccessController.CurrentUser.Login(txt原密码.Text.Trim());
            if (loginSucess)
            {
                string password = textEdit1.Text.Trim();
                if (password == textEdit2.Text.Trim())
                {
                    if (!YiKang.Common.IsStrongPassword(password, null))
                    {
                        MessageBox.Show("修改失败：新密码太弱了，请换一个（密码 8 个字符以上，或者 6个字符以上含数字、字母、符号）。");
                    }
                    else
                    {
                        AccessController.CurrentUser.ChangePassword(textEdit1.Text.Trim());
                        MessageBox.Show("密码已经修改。");
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("修改失败：两次输入的密码不一致，请重新输入后再试。");
                }
            }
            else
            {
                MessageBox.Show("修改失败：原密码不正确，请重新输入后再试。");
            }
        }
    }
}