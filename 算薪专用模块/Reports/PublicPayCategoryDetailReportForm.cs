using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

using System.Windows.Forms;
using YiKang.RBACS.DataObjects;
using System.Collections.Generic;
using DevExpress.XtraGrid.Views.Base;
using Hwagain.Components;
using Hwagain.SalaryCalculation.Components;
using YiKang;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.Utils;
using System.Text;
using DevExpress.XtraGrid.Views.Grid;


namespace Hwagain.SalaryCalculation
{
    public partial class PublicPayCategoryDetailReportForm : XtraForm
    {        
        public PublicPayCategoryDetailReportForm()
        {
            // This call is required by the Windows Form Designer.
            InitializeComponent();

            // TODO: Add any initialization after the InitializeComponent call
        }

        #region CreateWaitDialog

        WaitDialogForm dlg = null;
        public void CreateWaitDialog()
        {
            CreateWaitDialog("正在启动...", "请稍等...");
        }
        public void CreateWaitDialog(string caption, string title, Size size)
        {
            CloseWaitDialog();
            dlg = new DevExpress.Utils.WaitDialogForm(caption, title, size);
        }
        public void CreateWaitDialog(string caption, string title)
        {
            CloseWaitDialog();
            dlg = new DevExpress.Utils.WaitDialogForm(caption, title);
        }
        public void SetWaitDialogCaption(string fCaption)
        {
            if (dlg != null)
                dlg.Caption = fCaption;
        }
        public void CloseWaitDialog()
        {
            if (dlg != null)
                dlg.Close();
        }
        #endregion

        #region PublicPayCategoryDetailReportForm_Load

        private void PublicPayCategoryDetailReportForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        #endregion

        #region 加载数据

        public void LoadData()
        {
            SalaryResult row = View.GetRow(View.FocusedRowHandle) as SalaryResult;
            if (row != null)
            {
                lbl姓名.Text = row.姓名;
                txt员工编号.Text = row.员工编号;
                txt期间.Text = row.期间;

                List<SalaryResultItem> list = SalaryResultItem.GetSalaryResultItems(row.员工编号, row.日历组);
                list = list.FindAll(a => a.金额 != 0);
                gridControl1.DataSource = list;
                gridControl1.RefreshDataSource();
                gridView1.ExpandAllGroups();
            }
        }

        #endregion

        public GridView View { get; set; }

        private void btn最前_Click(object sender, EventArgs e)
        {
            this.View.MoveFirst();
            LoadData();
        }

        private void btn向前_Click(object sender, EventArgs e)
        {
            this.View.MovePrev();
            LoadData();
        }

        private void btn向后_Click(object sender, EventArgs e)
        {
            this.View.MoveNext();
            LoadData();
        }

        private void btn最后_Click(object sender, EventArgs e)
        {
            this.View.MoveLast();
            LoadData();
        }

    }

}

