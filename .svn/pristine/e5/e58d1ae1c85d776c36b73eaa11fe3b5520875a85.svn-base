using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using DevExpress.Xpo.DB;
using log4net;
using System.Data.SqlClient;

namespace Hwagain.SalaryCalculation.Components
{
    public partial class RolePayGroup
    {
        static readonly ILog log = LogManager.GetLogger(typeof(RolePayGroup));

        #region GetRolePayGroup
        /// <summary>
        /// 通过 Id 获取线路
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static RolePayGroup GetRolePayGroup(int id)
        {
            RolePayGroup obj = (RolePayGroup)Session.DefaultSession.GetObjectByKey(typeof(RolePayGroup), id);
            return obj;
        }

        public static RolePayGroup GetRolePayGroup(string payGroup, string role)
        {
            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                       new BinaryOperator("薪资组", payGroup, BinaryOperatorType.Equal),
                       new BinaryOperator("角色", role, BinaryOperatorType.Equal));

            XPCollection objset = new XPCollection(typeof(RolePayGroup), criteria, new SortProperty("薪资组", SortingDirection.Ascending));

            if (objset.Count > 0)
            {
                return (RolePayGroup)objset[0];
            }
            else
                return null;
        }

        #endregion

        #region GetPayGroups

        //获取所有薪资组
        public static List<RolePayGroup> GetPayGroups(string role)
        {
            List<RolePayGroup> list = new List<RolePayGroup>();

            XPCollection objset = null;

            objset = new XPCollection(typeof(RolePayGroup),
                 new BinaryOperator("角色", role, BinaryOperatorType.Equal),
                 new SortProperty("薪资组", SortingDirection.Descending));

            foreach (RolePayGroup uir in objset)
            {
                list.Add(uir);
            }
            return list;
        }
        #endregion

        #region GetAll

        //获取所有角色-薪资组
        public static List<RolePayGroup> GetAll()
        {
            List<RolePayGroup> list = new List<RolePayGroup>();

            XPCollection objset = new XPCollection(typeof(RolePayGroup));

            foreach (RolePayGroup group in objset)
            {
                list.Add(group);
            }
            return list;
        }
        #endregion

        #region OnSaving

        protected override void OnSaving()
        {
            RolePayGroup found = GetRolePayGroup(this.角色, this.薪资组);
            if (found != null && found.标识 != this.标识)
                throw new Exception("角色已具备这个薪资组的权限，不能重复设置.");
            else
                base.OnSaving();
        }
        #endregion

        #region Del

        public void Del()
        {
            string sql = "DELETE FROM 角色_薪资组 WHERE (薪资组 = '" + 薪资组 + "') AND (角色 = '" + 角色 + "')";
            using (SqlConnection connection = new SqlConnection(MyHelper.GetConnectionString()))
            {
                YiKang.Data.SqlHelper.ExecuteNonQuery(connection, System.Data.CommandType.Text, sql);
            }
        }
        #endregion
    }
}
