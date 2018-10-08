using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

using System.Windows.Forms;
using YiKang.RBACS.DataObjects;
using System.Collections.Generic;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraEditors;
using Hwagain.SalaryCalculation.Components;
using Hwagain.Components;


namespace Hwagain.SalaryCalculation
{
    public partial class ManagePayGroupImpowers : UserControl
    {
        List<RolePayGroup> impowerList = new List<RolePayGroup>();
        public ManagePayGroupImpowers()
        {
            // This call is required by the Windows Form Designer.
            InitializeComponent();

            // TODO: Add any initialization after the InitializeComponent call
        }
        private void ManagePayGroupImpowers_Load(object sender, System.EventArgs e)
        {
            //初始化
            repositoryItemLookUpEdit1.DataSource = PayGroup.薪资组集合;
            List<Role> allRoles = Role.GetAll();
            foreach (Role role in allRoles)
            {
                repositoryItemComboBox1.Items.Add(role.Name);
            }
            impowerList = RolePayGroup.GetAll();
            gridControl1.DataSource = impowerList;
        }

        private void gridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            RolePayGroup imp = new RolePayGroup();
            imp.标识 = Guid.NewGuid();
            impowerList.Add(imp);
            gridControl1.RefreshDataSource();
            gridView1.FocusedRowHandle = gridView1.RowCount - 1;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            ColumnView colView = (ColumnView)gridControl1.MainView;
            if (colView != null)
            {
                if (MessageBox.Show("确实删除当前记录吗？", "删除提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2, 0, false) == DialogResult.Yes)
                {
                    RolePayGroup currentRolePayGroup = (RolePayGroup)colView.GetFocusedRow();
                    if (currentRolePayGroup != null)
                    {
                        impowerList.Remove(currentRolePayGroup);
                        currentRolePayGroup.Delete();
                        gridControl1.RefreshDataSource();
                        MessageBox.Show("删除成功。", "删除提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void gridControl1_Load(object sender, EventArgs e)
        {
            
        }
    }

}

