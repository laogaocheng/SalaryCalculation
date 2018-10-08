using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Hwagain.Common
{
    public partial class MessageForm : DevExpress.XtraEditors.XtraForm
    {
        public MessageForm()
        {
            InitializeComponent();
        }

        #region 标题

        string title = "错误";
        public string 标题
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
                this.Text = title;
                lbl标题.Text = title;
            }
        }
        #endregion

        #region 消息

        string message = "";
        public string 消息
        {
            get
            {
                return message;
            }
            set
            {
                message = value;
                msg.Text = message;
            }
        }
        #endregion

        #region MessageForm_FormClosing

        private void MessageForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }
        #endregion

        #region MessageForm_Shown

        private void MessageForm_Shown(object sender, EventArgs e)
        {
            this.Activate();
        }
        #endregion

        #region btn确定_Click

        private void btn确定_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        #endregion

        private void MessageForm_Load(object sender, EventArgs e)
        {

        }

        private void msg_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}
