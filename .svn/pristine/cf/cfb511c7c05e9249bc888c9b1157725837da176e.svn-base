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
using DevExpress.XtraEditors.Controls;


namespace Hwagain.SalaryCalculation
{
    public partial class ManageGradeImpowers : UserControl
    {
        List<RoleGrade> impowerList = new List<RoleGrade>();
        public ManageGradeImpowers()
        {
            // This call is required by the Windows Form Designer.
            InitializeComponent();

            // TODO: Add any initialization after the InitializeComponent call
        }
        private void ManageGrade_Load(object sender, System.EventArgs e)
        {
            //初始化权限列表
            List<SalaryNode> allGrade = SalaryNode.工资等级表.FindAll(a => a.类型 == (int)节点类型.薪等);
            foreach (SalaryNode grade in allGrade)
            {
                ImageComboBoxItem item = new ImageComboBoxItem();
                item.Description = grade.名称;
                item.Value = grade.标识;
                repositoryItemImageComboBox1.Items.Add(item);
            }
            List<Role> allRoles = Role.GetAll();
            foreach (Role role in allRoles)
            {
                repositoryItemComboBox1.Items.Add(role.Name);
            }
            //只显示当前薪等表里的权限，历史记录隐藏
            impowerList.Clear();
            foreach(RoleGrade rg in RoleGrade.GetAll())
            {
                if (SalaryNode.工资等级表.Find(a => a.标识 == rg.薪等标识) != null)
                    impowerList.Add(rg);
            }
            gridControl1.DataSource = impowerList;
        }

        private void gridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            RoleGrade imp = new RoleGrade();
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
                    RoleGrade currentSalaryGrade = (RoleGrade)colView.GetFocusedRow();
                    if (currentSalaryGrade != null)
                    {
                        impowerList.Remove(currentSalaryGrade);
                        currentSalaryGrade.Delete();
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

