using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
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
    public partial class RoleLevelSettingsForm : UserControl
    {
        List<Role> roleList = new List<Role>();
        List<CompanyInfo> companyList = new List<CompanyInfo>();

        public RoleLevelSettingsForm()
        {
            InitializeComponent();
        }
        private void RoleLevelSettingsForm_Load(object sender, System.EventArgs e)
        {
            roleList = Role.GetAll();
            gridControl1.DataSource = roleList;

            //初始化公司列表
            companyList = CompanyInfo.GetAll();
            gridControl2.DataSource = companyList;
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
                    //初始化职务等级列表
                    职务等级 管培生, 副总经理以上;
                    管培生.编码 = "管培生"; 管培生.名称 = "管培生";
                    副总经理以上.编码 = "副总经理以上"; 副总经理以上.名称 = "副总经理以上";

                    List<职务等级> lvlList = new List<职务等级>();
                    lvlList.Add(管培生);
                    lvlList.Add(副总经理以上);
                    foreach (DictionaryEntry entry in PsHelper.GetSupvLvls())
                    {
                        职务等级 lvl = new 职务等级 { 编码 = (string)entry.Value, 名称 = (string)entry.Key };
                        lvlList.Add(lvl);
                    }
                    lvlList = lvlList.OrderBy(a => a.编码).ToList();
                    foreach (职务等级 lvl in lvlList)
                    {
                        CheckedListBoxItem item = new CheckedListBoxItem(lvl, false);
                        checkedListBoxControl1.Items.Add(item);
                    }
                }

                checkedListBoxControl1.BeginUpdate();

                if (CurrentCompany != null)
                {
                    List<RoleLevel> groups = RoleLevel.GetRoleLevels(this.CurrentRole.Name).FindAll(a => a.公司编码 == CurrentCompany.公司编码);
                    foreach (CheckedListBoxItem item in checkedListBoxControl1.Items)
                    {
                        职务等级 grade = (职务等级)item.Value;
                        bool isChecked = groups.Find(a => a.职务等级 == grade.编码) != null;
                        item.CheckState = isChecked ? CheckState.Checked : CheckState.Unchecked;
                    }
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

        #region CurrentCompany

        public CompanyInfo CurrentCompany
        {
            get
            {
                ColumnView colView = (ColumnView)gridControl2.MainView;
                if (colView != null)
                {
                    CompanyInfo currentCompanyInfo = (CompanyInfo)colView.GetFocusedRow();
                    return currentCompanyInfo;
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
            职务等级 职务等级 = (职务等级)currItem.Value;
            string rolename = this.CurrentRole.Name;
            //如果选中
            if (e.State == CheckState.Checked)
            {
                RoleLevel rLevel = RoleLevel.GetRoleLevel(rolename, CurrentCompany.公司编码, 职务等级.编码);
                if (rLevel == null)
                {
                    rLevel = new RoleLevel();
                    rLevel.角色 = rolename;
                    rLevel.公司编码 = CurrentCompany.公司编码;
                    rLevel.职务等级 = 职务等级.编码;
                    rLevel.Save();
                }
            }
            //如果没有选中
            if (e.State == CheckState.Unchecked)
            {
                RoleLevel rLevel = RoleLevel.GetRoleLevel(rolename, CurrentCompany.公司编码, 职务等级.编码);
                if (rLevel != null)
                {
                    rLevel.Delete();
                }
            }
        }

        private void gridView2_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            InitListBox();
        }
    }

}

