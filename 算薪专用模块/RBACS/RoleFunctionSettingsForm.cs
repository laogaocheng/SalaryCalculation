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
    public partial class RoleFunctionSettingsForm : UserControl
    {
        List<Role> roleList = new List<Role>();
        public RoleFunctionSettingsForm()
        {
            InitializeComponent();
        }
        private void RoleFunctionSettingsForm_Load(object sender, System.EventArgs e)
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
                    foreach (Privilege pg in Privilege.GetAllPrivileges())
                    {
                        checkedListBoxControl1.Items.Add(pg, false);
                    }
                }

                checkedListBoxControl1.BeginUpdate();

                List<Impower> myFunctions = Impower.GetRoleImpowers(this.CurrentRole.Name);
                foreach (CheckedListBoxItem item in checkedListBoxControl1.Items)
                {
                    Privilege privilege = (Privilege)item.Value;
                    bool isChecked = myFunctions.Find(a => a.Privilege == privilege) != null;
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
            Privilege privilege = (Privilege)currItem.Value;
            string rolename = this.CurrentRole.Name;
            //如果选中
            if (e.State == CheckState.Checked)
            {
                Impower imp = Impower.GetImpower(rolename, privilege.Id);
                if (imp == null)
                {
                    imp = new Impower();
                    imp.PowerFlags = 1;
                    imp.RoleName = rolename;
                    imp.PrivilegeId = privilege.Id;
                    imp.Enabled = true;
                    imp.CreateDate = DateTime.Now;
                    imp.ExpireTime = DateTime.Now.AddYears(15);
                    imp.Save();
                }
            }
            //如果没有选中
            if (e.State == CheckState.Unchecked)
            {
                Impower imp = Impower.GetImpower(rolename, privilege.Id); ;
                if (imp != null)
                {
                    imp.Delete();
                }
            }
        }

    }

}

