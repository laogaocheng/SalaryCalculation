using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Xml;
using Hwagain.SalaryCalculation;
using YiKang.RBACS;
using Hwagain.Components;
using YiKang;
using DevExpress.Utils;
using Hwagain.SalaryCalculation.Components;

namespace Hwagain.Common
{
    public partial class FormLogin : XtraForm
    {
        List<string> loginUserList = new List<string>();
        Timer timer = new Timer();
        public FormLogin()
        {
            InitializeComponent();
        }

        #region OnLoad

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            CloseWaitDialog();
        }
        #endregion

        #region btnClose_Click

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.None;
            this.Close();
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

        #region btnLogin_Click

        private void btnLogin_Click(object sender, EventArgs e)
        {            
            //清空缓存登陆信息
            AccessController.ClearLoginInfo();
            
            CreateWaitDialog("正在验证用户...", "请稍等...", new Size(180, 50));

            timer.Start(); //初始化合同资源管理器

            this.DialogResult = DialogResult.None;

            User user = User.GetUser(txt姓名.Text.Trim());
            if (user == null)
            {
                MessageBox.Show("登录失败：用户名不正确！");
            }
            else
            {
                bool loginSucess = user.Login(txt密码.Text.Trim());
                if (loginSucess)
                {
                    CloseWaitDialog();
                    //调试用，正式发布以后需注释掉
                    //user = User.GetUser("王淑云");

#if(DEBUG)
                    if(IsNormalNetwork())
                        Login(user); 
                    else
                        LoginByIDCard(user);
#else
                    LoginByIDCard(user);
#endif
                }
                else
                {
                    MessageBox.Show("登录失败：密码不正确");
                }
            }
            
            CloseWaitDialog();
        }

        bool IsNormalNetwork()
        {
            foreach(string ip in MyHelper.GetLocalIp())
            {
                if (ip.StartsWith("192.168.")) return true;
            }
            return false;
        }

        private void LoginByIDCard(User user)
        {
            IdReaderForm idForm = new IdReaderForm();
            idForm.user = user;
            if (idForm.ShowDialog() == DialogResult.OK)
            {
                Login(user);
            }
            else
                MessageBox.Show("登录失败：无法读取身份证信息或者身份证号码与用户不匹配。");
        }

        private void Login(User user)
        {
            AccessController.CurrentUser = user;
            AccessController.CurrentRoles = GetRoles(user.标识);
            this.DialogResult = DialogResult.OK;
            //保存登陆的时间
            user.最后登录时间 = DateTime.Now;
            user.Save();
        }

        private string[] GetRoles(Guid userId)
        {
            List<UserInRole> roleList = UserInRole.GetRoles(userId);
            string[] roles = new string[roleList.Count + 2];
            int i = 0;
            foreach (UserInRole role in roleList)
            {
                roles[i++] = role.Role;
            }
            if (AccessController.CurrentUser != null)
                roles[i++] = "管理人员";
            else
                roles[i++] = "公共用户";

            return roles;
        }
        #endregion

        #region txt密码_KeyUp
        private void txt密码_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnLogin_Click(sender, e);
        }
        #endregion

        #region CheckPermission

        //检查权限
        bool CheckPermission()
        {
            //初始化访问控制表
            AccessService.aclDoc = AccessService.CreateAccessImpowerTableXmlDocument(AccessController.CurrentRoles);
            if (AccessService.aclDoc == null)
            {
                return false;
            }
            else
            {
                return AccessService.aclDoc.InnerXml.IndexOf("Watermark") != -1 || AccessService.aclDoc.InnerXml.IndexOf("Category") != -1 || AccessService.aclDoc.InnerXml.IndexOf("Sample") != -1 || AccessService.aclDoc.InnerXml.IndexOf("Template") != -1 || AccessService.aclDoc.InnerXml.IndexOf("System") != -1;
            }
        }
        #endregion

        #region FrmLogin_Load

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            btnOK.Enabled = false;
            btnExist.Enabled = false;
            if (AccessController.CurrentUser == null)
            {
                btnOK.Enabled = true;
            }
            else
                btnExist.Enabled = true;

            timer.Interval = 1000;
            timer.Tick += new EventHandler(timer_Tick);
        }
        #endregion

        #region timer_Tick

        private void timer_Tick(object sender, EventArgs e)
        {
        }
        #endregion

        #region btnExist_Click

        private void btnExist_Click(object sender, EventArgs e)
        {
            if (AccessController.CurrentUser != null)
            {
                Hwagain.Components.Log.WriteLog(YiKang.LogType.成功审核, "退出系统", AccessController.CurrentUser.用户名);

                //清空缓存登陆信息
                AccessController.ClearLoginInfo();

                MainForm.CloseAlWindow();
            }
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;            
        }
        #endregion

        #region FormLogin_Shown

        private void FormLogin_Shown(object sender, EventArgs e)
        {
        }
        #endregion

        #region simpleButton1_Click

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            txt姓名.Text = "公共用户";
            txt密码.Text = "123456";
            btnLogin_Click(sender, e);
        }
        #endregion

        public MainForm MainForm { get; set; }
    }
}
