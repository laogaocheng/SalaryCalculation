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


namespace Hwagain.SalaryCalculation
{
    public partial class EditRembursementSalaryForm : XtraForm
    {
        RembursementSalaryEntry currRembursementSalaryEntry = null;
        public EditRembursementSalaryForm(RembursementSalaryEntry entry)
        {
            // This call is required by the Windows Form Designer.
            InitializeComponent();

            // TODO: Add any initialization after the InitializeComponent call
            this.currRembursementSalaryEntry = entry;
        }

        private void EditRembursementSalaryForm_Load(object sender, EventArgs e)
        {
            this.Text = "员工工资借款录入 - " + currRembursementSalaryEntry.员工编号 + " - " + (currRembursementSalaryEntry.是验证录入 ? "验证录入" : "初次录入");
            LoadData();
        }

        #region 加载数据

        protected void LoadData()
        {
            lbl用户.Text = currRembursementSalaryEntry.员工信息.姓名;
            lbl员工编号.Text = currRembursementSalaryEntry.员工编号;
            dateEdit开始时间.EditValue = currRembursementSalaryEntry.开始时间;
            dateEdit结束时间.EditValue = currRembursementSalaryEntry.结束时间;
            spinEdit月度可报账标准_税前.EditValue = currRembursementSalaryEntry.月度可报账标准_税前;
            spinEdit年度可报账标准_税前.EditValue = currRembursementSalaryEntry.年度可报账标准_税前;
            spinEdit月度可报账标准_税后.EditValue = currRembursementSalaryEntry.月度可报账标准_税后;
            spinEdit年度可报账标准_税后.EditValue = currRembursementSalaryEntry.年度可报账标准_税后;
        }        

        #endregion

        #region btn保存_Click

        private void btn保存_Click(object sender, EventArgs e)
        {            
            if (dateEdit开始时间.DateTime == DateTime.MinValue)
            {
                MessageBox.Show("开始时间不能为空");
                return;
            }
            if (dateEdit结束时间.DateTime == DateTime.MinValue)
            {
                MessageBox.Show("结束时间不能为空");
                return;
            }
            currRembursementSalaryEntry.开始时间 = dateEdit开始时间.DateTime;
            currRembursementSalaryEntry.结束时间 = dateEdit结束时间.DateTime;
            currRembursementSalaryEntry.月度可报账标准_税前 = spinEdit月度可报账标准_税前.Value;
            currRembursementSalaryEntry.年度可报账标准_税前 = spinEdit年度可报账标准_税前.Value;
            currRembursementSalaryEntry.月度可报账标准_税后 = spinEdit月度可报账标准_税后.Value;
            currRembursementSalaryEntry.年度可报账标准_税后 = spinEdit年度可报账标准_税后.Value;
            currRembursementSalaryEntry.录入人 = AccessController.CurrentUser.姓名;
            currRembursementSalaryEntry.录入时间 = DateTime.Now;
            currRembursementSalaryEntry.Save();

            Close();
        }
        #endregion

    }

}

