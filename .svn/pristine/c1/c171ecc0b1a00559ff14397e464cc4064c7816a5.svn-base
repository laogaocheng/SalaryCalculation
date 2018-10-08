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
using Hwagain.SalaryCalculation.Components;
using YiKang;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;


namespace Hwagain.SalaryCalculation
{
    public partial class EditEmployeeQueryPowerList : XtraForm
    {
        protected bool isCheckInput = false; //是否验证录入
        protected List<QueryLevel> currRows = new List<QueryLevel>();


        public EditEmployeeQueryPowerList()
        {
            // This call is required by the Windows Form Designer.
            InitializeComponent();

            // TODO: Add any initialization after the InitializeComponent call
        }

        private void EditEmployeeQueryPowerList_Load(object sender, EventArgs e)
        {
            this.Text = "查询权限列表";

            repositoryItemImageComboBox1.Items.Clear();
            foreach (DictionaryEntry entry in PsHelper.GetCompanyTable())
            {
                ImageComboBoxItem item = new ImageComboBoxItem();
                item.Description = (string)entry.Key;
                item.Value = (string)entry.Value;
                repositoryItemImageComboBox1.Items.Add(item);
            }

            repositoryItemImageComboBox2.Items.Clear();
            foreach (DictionaryEntry entry in PsHelper.GetSupvLvls())
            {
                ImageComboBoxItem item = new ImageComboBoxItem();
                item.Description = (string)entry.Key;
                item.Value = (string)entry.Value;
                repositoryItemImageComboBox2.Items.Add(item);
            }
            LoadData();
        }

        #region 加载数据

        protected void LoadData()
        {
            //清除原来的数据
            currRows = QueryLevel.GetAll();
            currRows = currRows.OrderBy(a => a.录入时间).ToList();

            gridControl1.DataSource = currRows;
            gridControl1.RefreshDataSource();
        }        

        #endregion
        
        #region btn刷新_Click

        private void btn刷新_Click(object sender, EventArgs e)
        {
            LoadData();
        }
        #endregion

        #region btn删除_Click

        private void btn删除_Click(object sender, EventArgs e)
        {
            ColumnView colView = (ColumnView)gridControl1.MainView;
            if (colView != null)
            {
                if (MessageBox.Show("确实删除当前记录吗？", "删除提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2, 0, false) == DialogResult.Yes)
                {
                    QueryLevel currentItem = (QueryLevel)colView.GetFocusedRow();
                    currRows.Remove(currentItem);
                    currentItem.Delete();

                    MyHelper.WriteLog(LogType.信息, "删除查询权限记录", currentItem.ToString<QueryLevel>());

                    gridControl1.RefreshDataSource();
                    MessageBox.Show("删除成功。", "删除提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        #endregion

    }
}

