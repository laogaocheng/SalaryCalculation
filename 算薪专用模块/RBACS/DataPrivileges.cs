using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

using System.Windows.Forms;
using YiKang.RBACS.DataObjects;
using System.Collections.Generic;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraEditors;


namespace Hwagain.SalaryCalculation
{
    public partial class DataPrivileges : UserControl
    {
        List<Privilege> pList = new List<Privilege>();
        public DataPrivileges()
        {
            // This call is required by the Windows Form Designer.
            InitializeComponent();

            // TODO: Add any initialization after the InitializeComponent call
        }
        private void DataPrivileges_Load(object sender, System.EventArgs e)
        {
            //初始化资源列表
            Resources res = new Resources();
            repositoryItemLookUpEdit1.DisplayMember = "Name";
            repositoryItemLookUpEdit1.ValueMember = "ResId";
            repositoryItemLookUpEdit1.DataSource = res.LoadAll();

            // //初始化动作列表
            Actions acts = new Actions();
            repositoryItemLookUpEdit2.DisplayMember = "Name";
            repositoryItemLookUpEdit2.ValueMember = "ActionId";
            repositoryItemLookUpEdit2.DataSource = acts.LoadAll();

            Privileges ps = new Privileges();
            pList = ps.LoadAll();
            gridControl1.DataSource = pList;
        }

        private void gridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Privilege p = new Privilege();
            pList.Add(p);
            gridControl1.RefreshDataSource();
            gridView1.FocusedRowHandle = gridView1.RowCount - 1;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Privilege currentPrivilege = this.CurrentPrivilege;
            if (currentPrivilege != null)
            {
                if (MessageBox.Show("确实删除当前权限吗？", "删除提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2, 0, false) == DialogResult.Yes)
                {
                    pList.Remove(currentPrivilege);
                    currentPrivilege.Delete();
                    gridControl1.RefreshDataSource();
                    MessageBox.Show("删除成功。", "删除提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void repositoryItemLookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
        }

        private void repositoryItemLookUpEdit1_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
        }

        Privilege CurrentPrivilege
        {
            get
            {
                ColumnView colView = (ColumnView)gridControl1.MainView;
                if (colView != null)
                    return (Privilege)colView.GetFocusedRow();
                return null;
            }
        }

        private void gridView1_FocusedColumnChanged(object sender, FocusedColumnChangedEventArgs e)
        {
            RefreshActionList();
        }

        private void gridView1_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            RefreshActionList();
        }
        void RefreshActionList()
        {
            Privilege currentPrivilege = this.CurrentPrivilege;
            if (currentPrivilege != null)
            {
            }
        }

        private void repositoryItemLookUpEdit2_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            Privilege currentPrivilege = this.CurrentPrivilege;
            if (currentPrivilege != null)
            {
                Action act = Action.GetAction((Guid)e.NewValue);
                if (act.ResId != currentPrivilege.ResId)
                {
                    e.NewValue = e.OldValue;
                    MessageBox.Show("请选择对应资源的动作。");
                }
            }
        }
    }

}

