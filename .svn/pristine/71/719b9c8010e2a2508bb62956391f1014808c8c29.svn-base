using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;

using YiKang.RBACS.DataObjects;
using DevExpress.XtraGrid.Views.Base;
using Hwagain.Components;
using Hwagain.SalaryCalculation.Components;
using YiKang;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;


namespace Hwagain.SalaryCalculation
{
    public partial class PerformanceSalaryList : XtraForm
    {
        public PerformanceSalaryList()
        {
            // This call is required by the Windows Form Designer.
            InitializeComponent();

            // TODO: Add any initialization after the InitializeComponent call
        }

        #region EditEmployeeSalaryStepForm_Load

        private void EditEmployeeSalaryStepForm_Load(object sender, EventArgs e)
        {            
            LoadData();
        }
        #endregion

        #region 加载数据

        protected void LoadData()
        {
            LoadData(null);
        }

        protected void LoadData(string key)
        {
            List<PerformanceSalary> list = PerformanceSalary.GetAll();
            //根据权限过滤
            list = list.FindAll(a => a.员工信息 != null && AccessController.CheckPayGroup(a.员工信息.薪资组));
            list = list.OrderBy(a => a.员工信息.员工序号).ToList();
            if (string.IsNullOrEmpty(key) == false) list = list.FindAll(a => a.姓名.Contains(key));
            //如果不显示历史记录
            if (chk显示历史记录.Checked == false)
            {
                List<PerformanceSalary> tempList = new List<PerformanceSalary>();
                foreach (PerformanceSalary item in list)
                {
                    //只需要最后生效的记录
                    DateTime date = list.FindAll(a=>a.有效).Max(a=>a.生效日期);
                    if (item.生效日期 == date) tempList.Add(item);
                }
                list = tempList;
            }
            gridControl1.DataSource = list;
            gridControl1.RefreshDataSource();
            gridView1.ExpandAllGroups();
        }        

        #endregion       

        #region btn查询_Click

        private void btn查询_Click(object sender, EventArgs e)
        {
            LoadData(searchKey.Text);
        }
        #endregion

        #region btn刷新_Click

        private void btn刷新_Click(object sender, EventArgs e)
        {
            LoadData(searchKey.Text);
        }
        #endregion

        #region searchKey_KeyUp

        private void searchKey_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                LoadData(searchKey.Text);
        }
        #endregion
    }

}

