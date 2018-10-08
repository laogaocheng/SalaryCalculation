using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

using System.Windows.Forms;
using YiKang.RBACS.DataObjects;
using System.Collections.Generic;
using DevExpress.XtraGrid.Views.Base;
using Hwagain.Components;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors;
using Hwagain.SalaryCalculation.Components;

namespace Hwagain.SalaryCalculation
{
    public partial class ManageUserInRole : UserControl
    {
        List<Role> roleList = new List<Role>();
        List<User> userList = new List<User>();
        public ManageUserInRole()
        {
            // This call is required by the Windows Form Designer.
            InitializeComponent();

            // TODO: Add any initialization after the InitializeComponent call
        }
        private void ManageUserInRole_Load(object sender, System.EventArgs e)
        {
            roleList = Role.GetAll();
            List<User> users = User.GetAll();
            gridControl1.DataSource = users;
        }

        private void gridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Role role = new Role();
            roleList.Add(role);
            gridControl1.RefreshDataSource();
            gridView1.FocusedRowHandle = gridView1.RowCount - 1;
        }

        private void gridView1_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            InitListBox();
        }

        private void InitListBox()
        {
            User currUser = this.CurrentUser;
            if (currUser != null)
            {
                checkedListBoxControl1.Items.Clear();
                List<UserInRole> roles = UserInRole.GetRoles((Guid)currUser.标识);
                foreach (Role role in roleList)
                {
                    bool isChecked = roles.Find(delegate(UserInRole uir)
                    {
                        return uir.Role == role.Name;
                    }) != null;
                    checkedListBoxControl1.Items.Add(role.Name, isChecked);
                }
            }
        }

        #region CurrentUser

        public User CurrentUser
        {
            get
            {
                ColumnView colView = (ColumnView)gridControl1.MainView;
                if (colView != null)
                {
                    User currentUser = (User)colView.GetFocusedRow();
                    return currentUser;
                }
                else
                    return null;
            }
        }
        #endregion

        private void checkedListBoxControl1_SelectedValueChanged(object sender, EventArgs e)
        {
        }

        private void checkedListBoxControl1_ItemCheck(object sender, DevExpress.XtraEditors.Controls.ItemCheckEventArgs e)
        {
            CheckedListBoxItem currItem = (CheckedListBoxItem)checkedListBoxControl1.GetItem(e.Index);
            string rolename = (string)currItem.Value;
            Guid userId = (Guid)this.CurrentUser.标识;
            //如果选中
            if (e.State == CheckState.Checked)
            {
                UserInRole uir = new UserInRole();
                uir.UserId = userId;
                uir.Role = rolename;
                uir.Save();
            }
            //如果没有选中
            if (e.State == CheckState.Unchecked)
            {
                UserInRole uir = UserInRole.GetUserInRole(userId, rolename);
                if (uir != null)
                {
                    uir.Delete();
                }
            }
        }

    }

}

