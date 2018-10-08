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
    public partial class EditMonthlyRembursementSalaryItemForm : XtraForm
    {
        MonthlyRembursementSalaryItemEntry currMonthlyRembursementSalaryItemEntry = null;
        public EditMonthlyRembursementSalaryItemForm(MonthlyRembursementSalaryItemEntry entry)
        {
            // This call is required by the Windows Form Designer.
            InitializeComponent();

            // TODO: Add any initialization after the InitializeComponent call
            this.currMonthlyRembursementSalaryItemEntry = entry;
        }

        private void EditMonthlyRembursementSalaryItemForm_Load(object sender, EventArgs e)
        {
            this.Text = "员工报账金额录入 - " + currMonthlyRembursementSalaryItemEntry.员工编号 + " - " + (currMonthlyRembursementSalaryItemEntry.是验证录入 ? "验证录入" : "初次录入");

            MonthlyRembursementSalaryItem lastMonthItem = currMonthlyRembursementSalaryItemEntry.上月发放记录;

            groupControl期初数据.Visible = lastMonthItem == null;
            if(groupControl期初数据.Visible == false)
            {
                this.Size = new Size(this.Size.Width, this.Size.Height - 60);
            }

            if (lastMonthItem == null)
            {
                spinEdit上年剩余金额.Enabled = true;
                spinEdit上月剩余金额.Enabled = true;
                spinEdit本月可报账金额.Value = currMonthlyRembursementSalaryItemEntry.本月报账工资标准;
            }
            else
            {
                spinEdit上年剩余金额.Enabled = false;
                spinEdit上月剩余金额.Enabled = false;

                spinEdit上月剩余金额.Value = lastMonthItem.本月剩余可报账金额;
                
                //如果上个月是1月
                if (lastMonthItem.月 == 12)
                {
                    spinEdit上年剩余金额.Value = lastMonthItem.本年剩余可报账金额;
                }
                else
                {
                    spinEdit上年剩余金额.Value = lastMonthItem.上年剩余可报账金额;
                }
                spinEdit本月可报账金额.Value = currMonthlyRembursementSalaryItemEntry.本月报账工资标准 + lastMonthItem.本月剩余可报账金额;
            }

            LoadData();
        }

        #region 加载数据

        protected void LoadData()
        {
            lbl用户.Text = currMonthlyRembursementSalaryItemEntry.员工信息.姓名;
            lbl员工编号.Text = currMonthlyRembursementSalaryItemEntry.员工编号;
            lbl报账时间.Text = string.Format("报账时间：{0}年 {1}月", currMonthlyRembursementSalaryItemEntry.年, currMonthlyRembursementSalaryItemEntry.月);
            spinEdit实际报账金额.EditValue = currMonthlyRembursementSalaryItemEntry.实际报账金额;
        }        

        #endregion

        #region btn保存_Click

        private void btn保存_Click(object sender, EventArgs e)
        {
            currMonthlyRembursementSalaryItemEntry.上月剩余金额 = spinEdit上月剩余金额.Value;
            currMonthlyRembursementSalaryItemEntry.上年剩余金额 = spinEdit上年剩余金额.Value;
            currMonthlyRembursementSalaryItemEntry.实际报账金额 = spinEdit实际报账金额.Value;
            currMonthlyRembursementSalaryItemEntry.录入人 = AccessController.CurrentUser.姓名;
            currMonthlyRembursementSalaryItemEntry.录入时间 = DateTime.Now;
            currMonthlyRembursementSalaryItemEntry.Save();

            Close();
        }
        #endregion

        private void spinEdit上月剩余金额_EditValueChanged(object sender, EventArgs e)
        {
            spinEdit本月可报账金额.Value = currMonthlyRembursementSalaryItemEntry.本月报账工资标准 + spinEdit上月剩余金额.Value;
        }
    }

}

