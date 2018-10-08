using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Hwagain.Common;
using Hwagain.SalaryCalculation.Components;
using DevExpress.XtraEditors;
using DevExpress.Utils;

namespace Hwagain.SalaryCalculation.Modules
{
    public partial class SalaryStandardTreeList : XtraForm
    {
        public SalaryStandardTreeList()
        {
            InitializeComponent();
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

        private void SalaryStandardTreeList_Load(object sender, EventArgs e)
        {
            CreateWaitDialog("正在加载数据...", "请稍等");

            treeList1.ParentFieldName = "父节点标识";
            treeList1.DataSource = PayRate.GetAll();
            treeList1.ExpandAll();

            CloseWaitDialog();
        }
    }
}
