using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using DevExpress.Xpo.DB;
using log4net;

namespace Hwagain.SalaryCalculation.Components
{
    public partial class RoleGrade
    {
        static readonly ILog log = LogManager.GetLogger(typeof(RoleGrade));

        #region GetRoleGrade
        /// <summary>
        /// 通过 Id 获取线路
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static RoleGrade GetRoleGrade(int id)
        {
            RoleGrade obj = (RoleGrade)Session.DefaultSession.GetObjectByKey(typeof(RoleGrade), id);
            return obj;
        }

        public static RoleGrade GetRoleGrade(string role, int gradeId)
        {
            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                       new BinaryOperator("薪等标识", gradeId, BinaryOperatorType.Equal),
                       new BinaryOperator("角色", role, BinaryOperatorType.Equal));

            XPCollection objset = new XPCollection(typeof(RoleGrade), criteria, new SortProperty("角色", SortingDirection.Ascending));

            if (objset.Count > 0)
            {
                return (RoleGrade)objset[0];
            }
            else
                return null;
        }

        #endregion

        #region GetRoleGrades

        //获取所有薪等
        public static List<RoleGrade> GetRoleGrades(string role)
        {
            List<RoleGrade> list = new List<RoleGrade>();

            XPCollection objset = null;

            objset = new XPCollection(typeof(RoleGrade),
                 new BinaryOperator("角色", role, BinaryOperatorType.Equal),
                 new SortProperty("角色", SortingDirection.Descending));

            foreach (RoleGrade grade in objset)
            {
                list.Add(grade);
            }
            return list;
        }
        #endregion

        #region GetAll

        //获取所有角色-薪等
        public static List<RoleGrade> GetAll()
        {
            List<RoleGrade> list = new List<RoleGrade>();

            XPCollection objset = new XPCollection(typeof(RoleGrade));

            foreach (RoleGrade group in objset)
            {
                list.Add(group);
            }
            return list;
        }
        #endregion

        #region OnSaving

        protected override void OnSaving()
        {
            RoleGrade found = GetRoleGrade(this.角色, this.薪等标识);
            if (found != null && found.标识 != this.标识)
                throw new Exception("角色已具备这个薪等的权限，不能重复设置.");
            else
                base.OnSaving();
        }
        #endregion
    }
}
