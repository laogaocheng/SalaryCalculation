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
    public partial class PersonRepaymentList : XtraForm
    {
        public PersonRepaymentList()
        {
            // This call is required by the Windows Form Designer.
            InitializeComponent();

            // TODO: Add any initialization after the InitializeComponent call
        }

        #region EditEmployeeSalaryStepForm_Load

        private void EditEmployeeSalaryStepForm_Load(object sender, EventArgs e)
        {
            dateEdit1.DateTime = MyHelper.GetPrevMonth1Day();
            dateEdit2.DateTime = DateTime.Today;
            LoadData();
        }
        #endregion

        #region 加载数据

        protected void LoadData()
        {
            List<PersonRepayment> list = PersonRepayment.GetAll(dateEdit1.DateTime, dateEdit2.DateTime);
            //根据权限过滤
            list = list.FindAll(a => a.员工信息 != null && AccessController.CheckPayGroup(a.员工信息.薪资组));
            list = list.OrderBy(a => a.员工信息.员工序号).ThenBy(a=>a.创建时间).ToList();
            gridControl1.DataSource = list;
            gridControl1.RefreshDataSource();
            gridView1.ExpandAllGroups();
        }        

        #endregion       

        #region btn查询_Click

        private void btn查询_Click(object sender, EventArgs e)
        {
            LoadData();
        }
        #endregion

    }

}

