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
using Aspose.Cells;
using System.IO;


namespace Hwagain.SalaryCalculation
{
    public partial class SalaryAdjustDetail : XtraForm
    {
        protected List<SalaryAdjustItem> rows = new List<SalaryAdjustItem>();

        int year; int month; string payGroup;
        bool showCommandButton = false;

        public SalaryAdjustDetail(int year, int month, string payGroup, string payGroupName, bool showButton)
        {
            // This call is required by the Windows Form Designer.
            InitializeComponent();

            this.year = year;
            this.month = month;
            this.payGroup = payGroup;
            this.showCommandButton = showButton;

            lbl标题.Text = String.Format("{0}年{1}月{2}工资调整情况表", year, month, payGroupName);
        }

        private void SalaryAdjustDetail_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        #region LoadData

        private void LoadData()
        {
            rows = SalaryAdjustItem.GetAdjustItems(year, month, payGroup);
            rows = rows.OrderBy(a=>a.已调整工资).ThenBy(a => a.员工信息.员工序号).ToList();

            gridControl1.DataSource = rows;
            gridControl1.RefreshDataSource();
            gridView1.ExpandAllGroups();
        }
        #endregion

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }

}

