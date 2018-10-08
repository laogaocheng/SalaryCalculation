using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using DevExpress.Xpo.DB;
using log4net;

namespace Hwagain.Components
{
    public partial class UserInRole
    {
        static readonly ILog log = LogManager.GetLogger(typeof(UserInRole));

        #region GetUserInRole
        /// <summary>
        /// 通过 Id 获取线路
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static UserInRole GetUserInRole(int id)
        {
            UserInRole obj = (UserInRole)Session.DefaultSession.GetObjectByKey(typeof(UserInRole), id);
            return obj;
        }

        public static UserInRole GetUserInRole(Guid userId, string role)
        {
            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                       new BinaryOperator("UserId", userId, BinaryOperatorType.Equal),
                       new BinaryOperator("Role", role, BinaryOperatorType.Equal));

            XPCollection objset = new XPCollection(typeof(UserInRole), criteria, new SortProperty("Id", SortingDirection.Ascending));

            if (objset.Count > 0)
            {
                return (UserInRole)objset[0];
            }
            else
                return null;
        }

        #endregion

        #region GetRoles

        //获取所有角色
        public static List<UserInRole> GetRoles(Guid userId)
        {
            List<UserInRole> list = new List<UserInRole>();

            XPCollection objset = null;

            objset = new XPCollection(typeof(UserInRole),
                 new BinaryOperator("UserId", userId, BinaryOperatorType.Equal),
                 new SortProperty("Id", SortingDirection.Descending));

            foreach (UserInRole uir in objset)
            {
                list.Add(uir);
            }
            return list;
        }
        #endregion

        #region IsRole

        bool IsRole(string role)
        {
            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                       new BinaryOperator("UserId", this.UserId, BinaryOperatorType.Equal),
                       new BinaryOperator("Role", role, BinaryOperatorType.Equal));

            XPCollection objset = new XPCollection(typeof(UserInRole), criteria, new SortProperty("Id", SortingDirection.Ascending));

            return objset.Count > 0;
        }
        #endregion

        #region OnSaving

        protected override void OnSaving()
        {
            UserInRole found = GetUserInRole(this.UserId, this.Role);
            if (found != null && found.Id != this.Id)
                throw new Exception("用户角色不能重复设置.");
            else
                base.OnSaving();
        }
        #endregion
    }
}
