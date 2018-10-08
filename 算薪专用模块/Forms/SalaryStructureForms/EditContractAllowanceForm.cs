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
    public partial class EditContractAllowanceForm : XtraForm
    {
        ContractAllowanceEntry currContractAllowanceEntry = null;
        public EditContractAllowanceForm(ContractAllowanceEntry entry)
        {
            // This call is required by the Windows Form Designer.
            InitializeComponent();

            // TODO: Add any initialization after the InitializeComponent call
            this.currContractAllowanceEntry = entry;
        }

        private void EditContractAllowanceForm_Load(object sender, EventArgs e)
        {
            this.Text = "录入员工契约津贴标准 - " + currContractAllowanceEntry.员工编号 + " - " + (currContractAllowanceEntry.是验证录入 ? "验证录入" : "初次录入");
            LoadData();
        }

        #region 加载数据

        protected void LoadData()
        {
            lbl用户.Text = currContractAllowanceEntry.员工信息.姓名;
            lbl员工编号.Text = currContractAllowanceEntry.员工编号;
            dateEdit开始时间.EditValue = currContractAllowanceEntry.开始时间;
            dateEdit结束时间.EditValue = currContractAllowanceEntry.结束时间;
            spinEdit约定年限.EditValue = currContractAllowanceEntry.约定年限;
            spinEdit月津贴额度.EditValue = currContractAllowanceEntry.月津贴额度;
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
            currContractAllowanceEntry.开始时间 = dateEdit开始时间.DateTime;
            currContractAllowanceEntry.结束时间 = dateEdit结束时间.DateTime;
            currContractAllowanceEntry.约定年限 = spinEdit约定年限.Value;
            currContractAllowanceEntry.月津贴额度 = spinEdit月津贴额度.Value;
            currContractAllowanceEntry.录入人 = AccessController.CurrentUser.姓名;
            currContractAllowanceEntry.录入时间 = DateTime.Now;
            currContractAllowanceEntry.Save();

            Close();
        }
        #endregion

    }

}

