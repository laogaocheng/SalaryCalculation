using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.Utils;

namespace Hwagain.SalaryCalculation
{
    public partial class FormSystemManage : DevExpress.XtraEditors.XtraForm
    {
        #region FormSystemManage

        public FormSystemManage()
        {
            CreateWaitDialog("正在启动系统管理器...", "请稍等...", new Size(220, 50));
            InitializeComponent();
        }
        #endregion

        #region FormSystemManage_Load

        private void FormSystemManage_Load(object sender, EventArgs e)
        {
            //根据权限设置页签的可见性
            SetButtonEnableByRight();
        }
        #endregion

        #region SetButtonEnableByRight

        private void SetButtonEnableByRight()
        {
            //管理用户
            tp用户管理.PageVisible = AccessController.CheckManageUser();
            //管理权限
            tp角色分配.PageVisible = AccessController.CheckManagePermission();
            tp薪等权限.PageVisible = AccessController.CheckManagePermission();
            tp薪资组权限.PageVisible = AccessController.CheckManagePermission();
            tp角色设置.PageVisible = AccessController.CheckManagePermission();
            tp权限分配.PageVisible = AccessController.CheckManagePermission();
            //管理系统
            tp查看日志.PageVisible = AccessController.CheckConfig() || AccessController.CheckManageUser() || AccessController.CheckManagePermission();
            tp操作设置.PageVisible = AccessController.CheckConfig();
            tp权限设置.PageVisible = AccessController.CheckConfig();
            tp资源设置.PageVisible = AccessController.CheckConfig();

            //2018-1-30 薪等权限已停用
            tp薪等权限.PageVisible = false;
        }
        #endregion

        #region OnLoad

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            CloseWaitDialog();
        }
        #endregion

        #region FormSystemManage_FormClosing

        private void FormSystemManage_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }
        #endregion

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

        #region FormSystemManage_Deactivate

        private void FormSystemManage_Deactivate(object sender, EventArgs e)
        {
            this.Hide();
        }
        #endregion
    }
}
