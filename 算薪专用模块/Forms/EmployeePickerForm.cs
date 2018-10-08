using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using YiKang.RBACS.DataObjects;
using DevExpress.XtraGrid.Views.Base;
using Hwagain.Components;
using Hwagain.SalaryCalculation.Components;
using YiKang;
using DevExpress.XtraEditors;
using DevExpress.Utils;
using DevExpress.XtraEditors.Controls;


namespace Hwagain.SalaryCalculation
{
    public partial class EmployeePickerForm : XtraForm
    {
        List<EmployeeInfo> list = new List<EmployeeInfo>();
        public delegate void SelectEmployeeHandle(object sender, EmployeeInfo employee);
        public event SelectEmployeeHandle OnSelected;
        static bool singleOne = false;

        public EmployeePickerForm(List<EmployeeInfo> list)
        {
            // This call is required by the Windows Form Designer.
            InitializeComponent();
            // TODO: Add any initialization after the InitializeComponent call
            this.list = list;
        }

        private void SelectEmployeeForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        #region CreateWaitDialog

        WaitDialogForm dlg = null;
        public void CreateWaitDialog()
        {
            CreateWaitDialog("正在启动...", "请稍等");
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

        void LoadData()
        {            
            gridControl1.DataSource = list;
            gridView1.ExpandAllGroups();
        }

        #region gridView1_DoubleClick

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            if (OnSelected != null)
            {
                EmployeeInfo currentItem = (EmployeeInfo)gridView1.GetFocusedRow();
                if (currentItem != null) OnSelected(sender, currentItem);
            }
        }
        #endregion

    }

}

