using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using DevExpress.Xpo.DB;
using log4net;
using System.Web.Security;
using System.Windows.Forms;
using YiKang;

namespace Hwagain.SalaryCalculation.Components
{
    public partial class User
    {
        static readonly ILog log = LogManager.GetLogger(typeof(User));

        #region GetUser
        /// <summary>
        /// 通过 Id 获取线路
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static User GetUser(Guid id)
        {
            User obj = (User)MyHelper.XpoSession.GetObjectByKey(typeof(User), id);
            return obj;
        }

        public static User GetUser(string name)
        {
            List<User> list = new List<User>();

            XPCollection objset = null;

            objset = new XPCollection(typeof(User),
                 new BinaryOperator("用户名", name, BinaryOperatorType.Equal),
                 new SortProperty("创建时间", SortingDirection.Descending));

            if (objset.Count > 0)
            {
                return (User)objset[0];
            }
            else
                return null;
        }

        #endregion

        public static User GetUserByCID(string cid)
        {
            List<User> list = new List<User>();

            XPCollection objset = null;

            objset = new XPCollection(typeof(User),
                 new BinaryOperator("身份证号码", cid, BinaryOperatorType.Equal),
                 new SortProperty("创建时间", SortingDirection.Descending));

            if (objset.Count > 0)
            {
                return (User)objset[0];
            }
            else
                return null;
        }

        #region GetAll

        //获取所有用户
        public static List<User> GetAll()
        {
            List<User> list = new List<User>();

            XPCollection objset = new XPCollection(typeof(User));

            foreach (User User in objset)
            {
                list.Add(User);
            }
            return list;
        }
        #endregion

        #region OnSaving

        protected override void OnSaving()
        {
            if (string.IsNullOrEmpty(this.用户名) || string.IsNullOrEmpty(this.身份证号码) || string.IsNullOrEmpty(this.邮箱地址))
                throw new Exception("用户名、身份证号码和邮箱地址不能为空");

            User found = GetUser(this.用户名);
            if (found != null && found.标识 != this.标识)
                throw new Exception(String.Format("已经存在名为{0}的用户，用户名称不能重复，请换一个名称后再试。", this.用户名));
            else
                base.OnSaving();
        }
        #endregion

        #region OnDeleting

        protected override void OnDeleting()
        {
            if (this.用户名 == "管理员") throw new Exception("不能删除管理员账号");
            base.OnDeleting();
        }
        #endregion

        #region OnSaved

        protected override void OnSaved()
        {
            TimeSpan ts = DateTime.Now - this.创建时间;
            //刚建立的
            if (ts.TotalMinutes < 10 && string.IsNullOrEmpty(this.密码))
            {
                InitPassword();
            }
            base.OnSaved();
        }
        #endregion

        #region Login

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool Login(string password)
        {
            string pwdSHA1 = MyHelper.SHA1HashEncode(password + this.盐);
            if (this.密码 == pwdSHA1)
            {
                Hwagain.Components.Log.WriteLog(YiKang.LogType.成功审核, "登录成功", this.用户名, this.用户名);
                return true;
            }
            else
            {
                Hwagain.Components.Log.WriteLog(YiKang.LogType.失败审核, "登录失败", this.用户名, this.用户名);
                return false;
            }
        }
        #endregion

        #region InitPassword

        public void InitPassword()
        {
            CreatePassword(true);
        }
        #endregion
        
        #region ResetPassword

        public void ResetPassword()
        {
            CreatePassword(false);
            Hwagain.Components.Log.WriteLog(LogType.信息, String.Format("重置{0}的密码", this.用户名), null);
        }
        #endregion

        #region SetPassword

        /// <summary>
        /// 重置密码
        /// </summary>
        private void CreatePassword(bool isNew)
        {
            string oldPassword = this.密码;
            string oldSalt = this.盐;
            try
            {
                PasswordGenerator pg = new PasswordGenerator();
                pg.ExcludeSymbols = true;
                string newPassword = pg.Generate();
                if (isNew) this.盐 = pg.Generate();
                this.密码 = MyHelper.SHA1HashEncode(newPassword + this.盐);
                this.Save();

                jmail.Message mail = new jmail.Message();
                mail.FromName = "专用算薪系统";
                mail.From = "system@hwagain.com";
                mail.MailDomain = "hwagain.com";
                mail.MailServerUserName = "system";
                mail.MailServerPassWord = "book]!256";
                mail.Encoding = "base64";
                mail.Charset = "gb2312";

                string address = this.邮箱地址;
                if (address != null) address = address.Trim();
                if (string.IsNullOrEmpty(address)) return;
                if (address.IndexOf('@') == -1) address += "@hwagain.com";
                mail.AddRecipient(address);
                mail.Subject = isNew ? "用户密码" : "重置密码成功";
                mail.Body = String.Format("{0}，您好,您的密码是：{1}", this.用户名, newPassword);
                mail.Send("192.168.79.18:26");
            }
            catch (Exception e)
            {
                if (!isNew)
                {
                    //恢复
                    this.盐 = oldSalt;
                    this.密码 = oldPassword;
                    this.Save();
                    MessageBox.Show("重置密码失败：" + e.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("初始化密码失败：" + e.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        #region ChangePassword

        public void ChangePassword(string newPassword)
        {
            PasswordGenerator pg = new PasswordGenerator();
            pg.ExcludeSymbols = true;
            this.盐 = pg.Generate();
            this.密码 = MyHelper.SHA1HashEncode(newPassword + this.盐);
            this.Save();

            Hwagain.Components.Log.WriteLog(LogType.信息, "修改密码", "");
        }
        #endregion

        #region SetDefaultPassword

        public void SetDefaultPassword()
        {
            ChangePassword("zxcvbnm,./");
        }

        #endregion
    }
}
