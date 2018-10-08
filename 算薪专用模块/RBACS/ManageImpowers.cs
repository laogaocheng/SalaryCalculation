using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

using System.Windows.Forms;
using YiKang.RBACS.DataObjects;
using System.Collections.Generic;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraEditors;
using Hwagain.Components;


namespace Hwagain.SalaryCalculation
{
    public partial class ManageImpowers : UserControl
    {
        Resources res = new Resources();
        List<Impower> impowerList = new List<Impower>();
        public ManageImpowers()
        {
            // This call is required by the Windows Form Designer.
            InitializeComponent();

            // TODO: Add any initialization after the InitializeComponent call
        }
        private void ManageImpowers_Load(object sender, System.EventArgs e)
        {
            List<Role> allRoles = Role.GetAll();
            foreach (Role role in allRoles)
            {
                repositoryItemComboBox1.Items.Add(role.Name);
            }
            //初始化权限列表
            Privileges privileges = new Privileges();
            repositoryItemLookUpEdit1.DisplayMember = "Name";
            repositoryItemLookUpEdit1.ValueMember = "Id";
            repositoryItemLookUpEdit1.DataSource = privileges.LoadAll();

            Impowers ps = new Impowers();
            impowerList = ps.LoadAll();
            gridControl1.DataSource = impowerList;
        }

        private void gridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Impower imp = new Impower();
            imp.PowerFlags = 1;
            imp.Enabled = true;
            imp.CreateDate = DateTime.Now;
            imp.ExpireTime = DateTime.Now.AddYears(15);
            impowerList.Add(imp);
            gridControl1.RefreshDataSource();
            gridView1.FocusedRowHandle = gridView1.RowCount - 1;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            ColumnView colView = (ColumnView)gridControl1.MainView;
            if (colView != null)
            {
                if (MessageBox.Show("确实删除当前资源吗？", "删除提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2, 0, false) == DialogResult.Yes)
                {
                    Impower currentImpower = (Impower)colView.GetFocusedRow();
                    impowerList.Remove(currentImpower);
                    currentImpower.Delete();
                    gridControl1.RefreshDataSource();
                    MessageBox.Show("删除成功。", "删除提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void gridControl1_Load(object sender, EventArgs e)
        {
            
        }
    }

}

