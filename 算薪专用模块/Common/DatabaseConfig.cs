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

namespace Hwagain.Common.Components
{
    public partial class DatabaseConfig : DevExpress.XtraEditors.XtraForm
    {
        public DatabaseConfig()
        {
            InitializeComponent();
        }

        #region btn确定_Click

        private void btn确定_Click(object sender, EventArgs e)
        {
            string connectString = "server=" + text服务器.Text + ";database=" + text数据库.Text + ";uid=" + text用户.Text + ";pwd=" + text密码.Text + ";Max Pool Size=10000";
            ConnectionString = connectString;
            try
            {
                MyHelper.SaveConnectString(connectString);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch
            {
                MessageBox.Show("连接失败，没有保存。");
            }
        }

        
        #endregion

        #region btn取消_Click

        private void btn取消_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
        #endregion

        #region btn测试连接_Click

        private void btn测试连接_Click(object sender, EventArgs e)
        {
            string connectString = "server=" + text服务器.Text + ";database=" + text数据库.Text + ";uid=" + text用户.Text + ";pwd=" + text密码.Text + ";Max Pool Size=10000";

            if (MyHelper.TryConnectDatabase(connectString))
                MessageBox.Show("连接成功！");
            else
                MessageBox.Show("连接失败，请重新输入后重试。");
        }

        #endregion

        #region DatabaseConfig_Load

        private void DatabaseConfig_Load(object sender, EventArgs e)
        {
            string connString = MyHelper.GetConnectionString();
            if (!string.IsNullOrEmpty(connString))
            {
                SqlConnection conn = new SqlConnection(connString);

                text服务器.Text = conn.DataSource;
                text数据库.Text = conn.Database;
            }
        }
        #endregion

        public string ConnectionString { get; set; }
    }
}