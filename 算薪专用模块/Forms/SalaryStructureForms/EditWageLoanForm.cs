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
    public partial class EditWageLoanForm : XtraForm
    {
        WageLoanEntry currWageLoanEntry = null;
        public EditWageLoanForm(WageLoanEntry entry)
        {
            // This call is required by the Windows Form Designer.
            InitializeComponent();

            // TODO: Add any initialization after the InitializeComponent call
            this.currWageLoanEntry = entry;
        }

        private void EditWageLoanForm_Load(object sender, EventArgs e)
        {
            this.Text = "员工工资借款录入 - " + currWageLoanEntry.员工编号 + " - " + (currWageLoanEntry.是验证录入 ? "验证录入" : "初次录入");
            LoadData();
        }

        #region 加载数据

        protected void LoadData()
        {
            lbl用户.Text = currWageLoanEntry.员工信息.姓名;
            lbl员工编号.Text = currWageLoanEntry.员工编号;
            dateEdit开始时间.EditValue = currWageLoanEntry.开始时间;
            dateEdit结束时间.EditValue = currWageLoanEntry.结束时间;
            spinEdit约定年限.EditValue = currWageLoanEntry.约定年限;
            spinEdit约定税率.EditValue = currWageLoanEntry.约定税率;
            spinEdit月借款额度.EditValue = currWageLoanEntry.月借款额度;
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
            currWageLoanEntry.开始时间 = dateEdit开始时间.DateTime;
            currWageLoanEntry.结束时间 = dateEdit结束时间.DateTime;
            currWageLoanEntry.约定年限 = spinEdit约定年限.Value;
            currWageLoanEntry.约定税率 = spinEdit约定税率.Value;
            currWageLoanEntry.月借款额度 = spinEdit月借款额度.Value;
            currWageLoanEntry.录入人 = AccessController.CurrentUser.姓名;
            currWageLoanEntry.录入时间 = DateTime.Now;
            currWageLoanEntry.Save();

            Close();
        }
        #endregion

    }

}

