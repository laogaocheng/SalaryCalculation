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
    public partial class ManageRoles : UserControl
    {
        List<Role> roleList = new List<Role>();
        public ManageRoles()
        {
            // This call is required by the Windows Form Designer.
            InitializeComponent();

            // TODO: Add any initialization after the InitializeComponent call
        }
        private void ManageRoles_Load(object sender, System.EventArgs e)
        {
            roleList = Role.GetAll();
            gridControl1.DataSource = roleList;
        }

        private void gridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Role role = new Role();
            roleList.Add(role);
            gridControl1.RefreshDataSource();
            gridView1.FocusedRowHandle = gridView1.RowCount - 1;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            ColumnView colView = (ColumnView)gridControl1.MainView;
            if (colView != null)
            {
                if (MessageBox.Show("确实删除当前角色吗？", "删除提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2, 0, false) == DialogResult.Yes)
                {
                    Role currentRole = (Role)colView.GetFocusedRow();
                    roleList.Remove(currentRole);
                    currentRole.Delete();
                    gridControl1.RefreshDataSource();
                    MessageBox.Show("删除成功。", "删除提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

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
    }

}

