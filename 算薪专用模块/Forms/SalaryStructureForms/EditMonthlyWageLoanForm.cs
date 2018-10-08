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
    public partial class EditMonthlyWageLoanItemForm : XtraForm
    {
        MonthlyWageLoanItemEntry currMonthlyWageLoanItemEntry = null;
        public EditMonthlyWageLoanItemForm(MonthlyWageLoanItemEntry entry)
        {
            // This call is required by the Windows Form Designer.
            InitializeComponent();

            // TODO: Add any initialization after the InitializeComponent call
            this.currMonthlyWageLoanItemEntry = entry;
        }

        private void EditMonthlyWageLoanItemForm_Load(object sender, EventArgs e)
        {
            this.Text = "员工每月工资借款录入 - " + currMonthlyWageLoanItemEntry.员工编号 + " - " + (currMonthlyWageLoanItemEntry.是验证录入 ? "验证录入" : "初次录入");

            if(currMonthlyWageLoanItemEntry.执行标准 == null)
            {
                MessageBox.Show("没有找到该员工的借款标准，请录入后再试！");
                Close();
            }
            else
            {
                spinEdit约定税率.EditValue = currMonthlyWageLoanItemEntry.执行标准.约定税率;
                spinEdit月借款标准.EditValue = currMonthlyWageLoanItemEntry.执行标准.月借款额度;
            }
            //获取上表工资
            SalaryResult sr = SalaryResult.GetSalaryResult(currMonthlyWageLoanItemEntry.员工编号, currMonthlyWageLoanItemEntry.年, currMonthlyWageLoanItemEntry.月);
            if(sr != null)
            {
                spinEdit应出勤天数.EditValue = sr.企业排班天数;
                spinEdit实际出勤天数.EditValue = sr.实际出勤天数;

                spinEdit应出勤天数.Enabled = false;
                spinEdit实际出勤天数.Enabled = false;
            }
            else
            {
                spinEdit应出勤天数.Enabled = true;
                spinEdit实际出勤天数.Enabled = true;

                MessageBox.Show("员工的上表工资尚未计算，出勤情况请手工录入！");
            }
            LoadData();
        }

        #region 加载数据

        protected void LoadData()
        {
            lbl用户.Text = currMonthlyWageLoanItemEntry.员工信息.姓名;
            lbl员工编号.Text = currMonthlyWageLoanItemEntry.员工编号;
            lbl报账时间.Text = string.Format("借款时间：{0}年 {1}月", currMonthlyWageLoanItemEntry.年, currMonthlyWageLoanItemEntry.月);

            if (spinEdit应出勤天数.Enabled)
            {
                spinEdit应出勤天数.EditValue = currMonthlyWageLoanItemEntry.应出勤天数;
                spinEdit实际出勤天数.EditValue = currMonthlyWageLoanItemEntry.实际出勤天数;
            }
            spinEdit实际借款金额.EditValue = currMonthlyWageLoanItemEntry.实际借款金额;
            spinEdit代缴个税.EditValue = currMonthlyWageLoanItemEntry.代缴个税;
            spinEdit税后实发金额.EditValue = currMonthlyWageLoanItemEntry.税后实发金额;
        }        

        #endregion

        #region btn保存_Click

        private void btn保存_Click(object sender, EventArgs e)
        {
            currMonthlyWageLoanItemEntry.约定税率 = spinEdit约定税率.Value;
            currMonthlyWageLoanItemEntry.月借款标准 = spinEdit月借款标准.Value;
            currMonthlyWageLoanItemEntry.应出勤天数 = spinEdit应出勤天数.Value;
            currMonthlyWageLoanItemEntry.实际出勤天数 = spinEdit实际出勤天数.Value;
            currMonthlyWageLoanItemEntry.实际借款金额 = spinEdit实际借款金额.Value;
            currMonthlyWageLoanItemEntry.代缴个税 = spinEdit代缴个税.Value;
            currMonthlyWageLoanItemEntry.税后实发金额 = spinEdit税后实发金额.Value;

            currMonthlyWageLoanItemEntry.录入人 = AccessController.CurrentUser.姓名;
            currMonthlyWageLoanItemEntry.录入时间 = DateTime.Now;
            currMonthlyWageLoanItemEntry.Save();

            Close();
        }
        #endregion

    }

}

