using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using DevExpress.Xpo.DB;
using log4net;
using YiKang.SSO.Components;
using System.Web.Security;

namespace Hwagain.Components
{
    public partial class Role
    {
        static readonly ILog log = LogManager.GetLogger(typeof(Role));

        #region GetRole
        /// <summary>
        /// 通过 Id 获取线路
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Role GetRole(int id)
        {
            Role obj = (Role)Session.DefaultSession.GetObjectByKey(typeof(Role), id);
            return obj;
        }

        public static Role GetRole(string name)
        {
            List<Role> list = new List<Role>();

            XPCollection objset = null;

            objset = new XPCollection(typeof(Role),
                 new BinaryOperator("Name", name, BinaryOperatorType.Equal),
                 new SortProperty("Id", SortingDirection.Descending));

            if (objset.Count > 0)
            {
                return (Role)objset[0];
            }
            else
                return null;
        }

        #endregion

        #region GetAll

        //获取所有角色
        public static List<Role> GetAll()
        {
            List<Role> list = new List<Role>();

            XPCollection objset = new XPCollection(typeof(Role));

            foreach (Role role in objset)
            {
                list.Add(role);
            }
            return list;
        }
        #endregion

        #region GetUsers

        public List<UserInRole> GetUsers(string role)
        {
            List<UserInRole> list = new List<UserInRole>();

            XPCollection objset = null;

            objset = new XPCollection(typeof(UserInRole),
                 new BinaryOperator("Role", role, BinaryOperatorType.Equal),
                 new SortProperty("Id", SortingDirection.Descending));

            foreach (UserInRole uir in objset)
            {
                list.Add(uir);
            }
            return list;
        }
        #endregion

        #region OnSaving

        protected override void OnSaving()
        {
            if (string.IsNullOrEmpty(Name)) throw new Exception("角色名称不能为空");

            Role found = GetRole(this.Name);
            if (found != null && found.Id != this.Id)
                throw new Exception(String.Format("已经存在名为{0}的角色，角色名称不能重复.", this.Name));
            else
                base.OnSaving();
        }
        #endregion

        #region Users

        [NonPersistent]
        public List<UserInRole> Users
        {
            get
            {
                return GetUsers(this.Name);
            }
        }
        #endregion
    }
}
