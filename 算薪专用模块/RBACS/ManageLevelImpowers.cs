using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Linq;

using System.Windows.Forms;
using YiKang.RBACS.DataObjects;
using System.Collections.Generic;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraEditors;
using Hwagain.SalaryCalculation.Components;
using Hwagain.Components;
using DevExpress.XtraEditors.Controls;


namespace Hwagain.SalaryCalculation
{
    public partial class ManageLevelImpowers : UserControl
    {
        List<RoleLevel> impowerList = new List<RoleLevel>();
        public ManageLevelImpowers()
        {
            // This call is required by the Windows Form Designer.
            InitializeComponent();

            // TODO: Add any initialization after the InitializeComponent call
        }
        private void ManageLevel_Load(object sender, System.EventArgs e)
        {
            Init();
        }

        private void Init()
        {
            //初始化公司列表
            repositoryItemCompany.Items.Clear();
            foreach (CompanyInfo c in CompanyInfo.GetAll())
            {
                ImageComboBoxItem item = new ImageComboBoxItem(c.公司简称, c.公司编码);
                repositoryItemCompany.Items.Add(item);            
            }
            //初始化职务等级列表
            repositoryItemGrade.Items.Clear();
            repositoryItemGrade.Items.Add(new ImageComboBoxItem("管培生", "管培生"));
            repositoryItemGrade.Items.Add(new ImageComboBoxItem("副总经理以上", "副总经理以上"));
            List<职务等级> lvlList = new List<职务等级>();
            foreach (DictionaryEntry entry in PsHelper.GetSupvLvls())
            {
                职务等级 lvl = new 职务等级 { 编码 = (string)entry.Value, 名称 = (string)entry.Key };
                lvlList.Add(lvl);
            }
            lvlList = lvlList.OrderBy(a => a.编码).ToList();
            foreach (职务等级 lvl in lvlList)
            {
                ImageComboBoxItem item = new ImageComboBoxItem(lvl.名称, lvl.编码);
                repositoryItemGrade.Items.Add(item);
            }
            //初始化角色列表
            List<Role> allRoles = Role.GetAll();
            foreach (Role role in allRoles)
            {
                repositoryItemRole.Items.Add(role.Name);
            }
            //只显示当前薪等表里的权限，历史记录隐藏
            impowerList.Clear();
            foreach (RoleLevel rg in RoleLevel.GetAll())
            {
                impowerList.Add(rg);
            }
            gridControl1.DataSource = impowerList;
        }

        private void gridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            RoleLevel imp = new RoleLevel();
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
                    RoleLevel currentSalaryLevel = (RoleLevel)colView.GetFocusedRow();
                    if (currentSalaryLevel != null)
                    {
                        impowerList.Remove(currentSalaryLevel);
                        currentSalaryLevel.Delete();
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

