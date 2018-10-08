﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Hwagain.SalaryCalculation.Components.Forms
{
    public partial class ManageDeptSystem : DevExpress.XtraEditors.XtraForm
    {
        List<DeptSystem> list = new List<DeptSystem>();
        public ManageDeptSystem()
        {
            InitializeComponent();
        }

        private void gridControl1_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            //自动创建体系记录
            AutoGenerateDeptSystem();
            list = DeptSystem.GetAll();
            list = list.FindAll(a => a.部门信息 != null && a.部门信息.有效).OrderBy(a => a.部门编号).ToList();
            gridControl1.DataSource = list;
            gridControl1.RefreshDataSource();
        }

        #region AutoGenerateDeptSystem

        private void AutoGenerateDeptSystem()
        {
            List<DeptInfo> depts = DeptInfo.组织机构表.FindAll(a => a.公司 != null && (a.部门层级 == 20 || a.部门层级 == 40) && a.公司.部门编号 == "11000");
            foreach (DeptInfo dept in depts)
            {
                try
                {
                    if (DeptSystem.GetDeptSystem(dept.部门编号) == null)
                    {
                        DeptSystem ds = new DeptSystem();
                        ds.标识 = Guid.NewGuid();
                        ds.部门编号 = dept.部门编号;
                        ds.部门名称 = dept.部门名称;
                        ds.Save();
                    }
                }
                catch { }
            }
        }
        #endregion
    }
}