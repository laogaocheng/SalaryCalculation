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
    public partial class RolePaygroupSettingsForm : UserControl
    {
        List<Role> roleList = new List<Role>();
        public RolePaygroupSettingsForm()
        {
            InitializeComponent();
        }
        private void RolePaygroupSettingsForm_Load(object sender, System.EventArgs e)
        {
            roleList = Role.GetAll();
            gridControl1.DataSource = roleList;
        }

        private void gridView1_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            InitListBox();
        }

        private void InitListBox()
        {
            if (this.CurrentRole != null)
            {
                if (checkedListBoxControl1.Items.Count == 0)
                {
                    foreach (PayGroup pg in PayGroup.薪资组集合)
                    {
                        checkedListBoxControl1.Items.Add(pg, false);
                    }
                }

                checkedListBoxControl1.BeginUpdate();

                List<RolePayGroup> groups = RolePayGroup.GetPayGroups(this.CurrentRole.Name);
                foreach (CheckedListBoxItem item in checkedListBoxControl1.Items)
                {
                    PayGroup paygroup = (PayGroup)item.Value;
                    bool isChecked = groups.Find(a => a.薪资组 == paygroup.英文名) != null;
                    item.CheckState = isChecked ? CheckState.Checked : CheckState.Unchecked;
                }

                checkedListBoxControl1.EndUpdate();
            }
        }

        #region CurrentRole

        public Role CurrentRole
        {
            get
            {
                ColumnView colView = (ColumnView)gridControl1.MainView;
                if (colView != null)
                {
                    Role currentRole = (Role)colView.GetFocusedRow();
                    return currentRole;
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
            PayGroup paygroup = (PayGroup)currItem.Value;
            string rolename = this.CurrentRole.Name;
            //如果选中
            if (e.State == CheckState.Checked)
            {
                RolePayGroup rpg = new RolePayGroup();
                rpg.角色 = rolename;
                rpg.薪资组 = paygroup.英文名;
                rpg.Save();
            }
            //如果没有选中
            if (e.State == CheckState.Unchecked)
            {
                RolePayGroup rpg = RolePayGroup.GetRolePayGroup(paygroup.英文名, rolename);
                if (rpg != null)
                {
                    rpg.Del();
                }
            }
        }

    }

}

