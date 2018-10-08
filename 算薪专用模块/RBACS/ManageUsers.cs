using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

using System.Windows.Forms;
using YiKang.RBACS.DataObjects;
using System.Collections.Generic;
using DevExpress.XtraGrid.Views.Base;
using Hwagain.Components;
using DevExpress.XtraEditors;
using Hwagain.SalaryCalculation.Components;

namespace Hwagain.SalaryCalculation
{
    public partial class ManageUsers : UserControl
    {
        List<User> UserList = new List<User>();
        public ManageUsers()
        {
            // This call is required by the Windows Form Designer.
            InitializeComponent();

            // TODO: Add any initialization after the InitializeComponent call
        }
        private void ManageUsers_Load(object sender, System.EventArgs e)
        {
            UserList = User.GetAll();
            gridControl1.DataSource = UserList;
        }

        private void gridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            User user = new User();
            user.创建时间 = DateTime.Now;
            UserList.Add(user);
            gridControl1.RefreshDataSource();
            gridView1.FocusedRowHandle = gridView1.RowCount - 1;

            Hwagain.Components.Log.WriteLog(YiKang.LogType.信息, "创建用户：" + this.用户名, null);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            ColumnView colView = (ColumnView)gridControl1.MainView;
            if (colView != null)
            {
                if (MessageBox.Show("确实删除当前用户吗？", "删除提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2, 0, false) == DialogResult.Yes)
                {
                    User currentUser = (User)colView.GetFocusedRow();

                    if (AccessController.CurrentUser.用户名 == "ROOT")
                    {
                        MessageBox.Show("不能将根用户删除，这是系统内建的超级用户。", "删除提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        if (AccessController.CurrentUser.标识 == currentUser.标识)
                        {
                            MessageBox.Show("不能将自己删除。", "删除提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            UserList.Remove(currentUser);
                            string deletedUsername = currentUser.用户名;
                            currentUser.Delete();
                            gridControl1.RefreshDataSource();

                            Hwagain.Components.Log.WriteLog(YiKang.LogType.信息, "删除用户：" + deletedUsername, null);

                            MessageBox.Show("删除成功。", "删除提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
        }

        #region gridView2_CustomColumnDisplayText

        private void gridView2_CustomColumnDisplayText(object sender, CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "UserId")
            {
                if (e.Value != null)
                {
                    Guid val = (Guid)e.Value;
                    User user = User.GetUser((Guid)e.Value);
                    if (user != null)
                        e.DisplayText = user.用户名;
                    else
                        e.DisplayText = "";
                }
                else
                    e.DisplayText = "";
            }
        }
        #endregion

        #region btnChangePassword_Click

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            ColumnView colView = (ColumnView)gridControl1.MainView;
            if (colView != null)
            {
                if (MessageBox.Show("确实要重置当前用户的密码吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2, 0, false) == DialogResult.Yes)
                {
                    User currentUser = (User)colView.GetFocusedRow();
                    currentUser.ResetPassword();
                    MessageBox.Show(String.Format("重置成功，密码已发送至邮箱【{0}】。", currentUser.邮箱地址), "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        #endregion

        #region btn恢复为默认密码_Click

        private void btn恢复为默认密码_Click(object sender, EventArgs e)
        {
            ColumnView colView = (ColumnView)gridControl1.MainView;
            if (colView != null)
            {
                if (MessageBox.Show("确实要当前用户的默认密码吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2, 0, false) == DialogResult.Yes)
                {
                    User currentUser = (User)colView.GetFocusedRow();
                    currentUser.SetDefaultPassword();
                    MessageBox.Show("重置成功，请及时修改。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        #endregion
    }

}

