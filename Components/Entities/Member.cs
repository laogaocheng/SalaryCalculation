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
    public partial class Member
    {
        static readonly ILog log = LogManager.GetLogger(typeof(Member));

        #region GetMember
        /// <summary>
        /// 通过 Id 获取线路
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Member GetMember(Guid id)
        {
            Member obj = (Member)MyHelper.XpoSession.GetObjectByKey(typeof(Member), id);
            return obj;
        }

        public static Member GetMember(string name)
        {
            List<Member> list = new List<Member>();

            XPCollection objset = null;

            objset = new XPCollection(typeof(Member),
                 new BinaryOperator("姓名", name, BinaryOperatorType.Equal),
                 new SortProperty("创建时间", SortingDirection.Descending));

            if (objset.Count > 0)
            {
                return (Member)objset[0];
            }
            else
                return null;
        }

        #endregion

        #region GetAll

        //获取所有用户
        public static List<Member> GetAll()
        {
            List<Member> list = new List<Member>();

            XPCollection objset = new XPCollection(typeof(Member));

            foreach (Member Member in objset)
            {
                list.Add(Member);
            }
            return list;
        }
        #endregion

        public static List<Member> GetMemberList(string userType)
        {
            List<Member> list = new List<Member>();

            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                       new BinaryOperator("用户类型", userType, BinaryOperatorType.Equal));
            
            XPCollection objset = new XPCollection(typeof(Member), criteria, new SortProperty("员工编号", SortingDirection.Ascending));

            foreach (Member member in objset)
            {
                list.Add(member);
            }
            return list;
        }
        #region OnSaving

        protected override void OnSaving()
        {
            if (string.IsNullOrEmpty(this.姓名) || string.IsNullOrEmpty(this.身份证号码) || string.IsNullOrEmpty(this.员工编号))
                throw new Exception("姓名、身份证号码和员工编号不能为空");

            if(EmployeeInfo.GetEmployeeInfoByCID(this.身份证号码) == null)
                throw new Exception("指定的身份证号码不正确，公司没有这个身份证号的员工");

            Member found = GetMember(this.姓名);
            if (found != null && found.标识 != this.标识)
                throw new Exception(String.Format("已经存在姓名为{0}的用户，用户名称不能重复，请换一个名称后再试。", this.姓名));
            else
            {                
                base.OnSaving();
            }
        }
        #endregion

        #region OnDeleting

        protected override void OnDeleting()
        {
            if (this.用户类型 == "系统管理员") throw new Exception("不能删除系统管理员账号");
            //清空该员工的权限
            MemberDept.ClearMemberDept(this.员工编号);
            MemberGrade.ClearMemberGrade(this.员工编号);
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
                SetDefaultPassword();
            }
            base.OnSaved();
        }
        #endregion

        #region AddMember

        public static Member AddMember(string emplid, string name, string cid, string memberType)
        {
            Member item = GetMember(name);
            if (item == null)
            {
                item = new Member();
                item.标识 = Guid.NewGuid();
                item.员工编号 = emplid;
                item.姓名 = name;
                item.身份证号码 = cid;
                item.创建时间 = DateTime.Now;

                PasswordGenerator pg = new PasswordGenerator();
                pg.ExcludeSymbols = true;
                item.盐 = pg.Generate();
                item.密码 = MyHelper.SHA1HashEncode("zxcvbnm,./" + item.盐);
            }

            item.用户类型 = memberType;
            item.Save();

            return item;
        }
        #endregion

        #region Login

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="Membername"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool Login(string password)
        {
            string pwdSHA1 = MyHelper.SHA1HashEncode(password + this.盐);
            if (this.密码 == pwdSHA1)
            {
                Hwagain.Components.Log.WriteLog(YiKang.LogType.成功审核, "登录成功", this.姓名, this.员工编号);
                return true;
            }
            else
            {
                Hwagain.Components.Log.WriteLog(YiKang.LogType.失败审核, "登录失败", this.姓名, this.员工编号);
                return false;
            }
        }
        #endregion
        
        #region ResetPassword

        public void ResetPassword()
        {
            SetDefaultPassword();
            Hwagain.Components.Log.WriteLog(LogType.信息, String.Format("重置{0}的密码", this.姓名), null);
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

        #region 员工信息

        EmployeeInfo empInfo = null;
        [NonPersistent]
        public EmployeeInfo 员工信息
        {
            get
            {
                if (empInfo == null) empInfo = EmployeeInfo.GetEmployeeInfoByCID(this.身份证号码);
                return empInfo;
            }
            set { empInfo = value; }
        }
        #endregion
    }

    public enum MemberType
    {
        普通用户 = 0,
        经理级以下部门主管 = 1,
        副总以上领导 = 2,
        算薪人员 = 88,
        权限管理员 = 90,
        系统管理员 = 99
    }
}
