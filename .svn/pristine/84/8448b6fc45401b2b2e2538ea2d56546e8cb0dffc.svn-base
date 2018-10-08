using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using DevExpress.Xpo.DB;
using log4net;
using YiKang;

namespace Hwagain.SalaryCalculation.Components
{
    public partial class RoleLevel
    {
        static readonly ILog log = LogManager.GetLogger(typeof(RoleLevel));

        #region GetRoleLevel
        /// <summary>
        /// 通过 Id 获取线路
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static RoleLevel GetRoleLevel(Guid id)
        {
            RoleLevel obj = (RoleLevel)Session.DefaultSession.GetObjectByKey(typeof(RoleLevel), id);
            return obj;
        }

        public static RoleLevel GetRoleLevel(string role, string company, string level)
        {
            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                       new BinaryOperator("角色", role, BinaryOperatorType.Equal),
                       new BinaryOperator("公司编码", company, BinaryOperatorType.Equal),
                       new BinaryOperator("职务等级", level, BinaryOperatorType.Equal));

            XPCollection objset = new XPCollection(typeof(RoleLevel), criteria, new SortProperty("职务等级", SortingDirection.Ascending));

            if (objset.Count > 0)
            {
                return (RoleLevel)objset[0];
            }
            else
                return null;
        }

        #endregion

        #region GetRoleLevels

        //获取所有职等
        public static List<RoleLevel> GetRoleLevels(string role)
        {
            List<RoleLevel> list = new List<RoleLevel>();

            XPCollection objset = null;

            objset = new XPCollection(typeof(RoleLevel),
                 new BinaryOperator("角色", role, BinaryOperatorType.Equal),
                 new SortProperty("角色", SortingDirection.Descending));

            foreach (RoleLevel Level in objset)
            {
                list.Add(Level);
            }
            return list;
        }
        #endregion

        #region GetAll

        //获取所有角色-职等
        public static List<RoleLevel> GetAll()
        {
            List<RoleLevel> list = new List<RoleLevel>();

            XPCollection objset = new XPCollection(typeof(RoleLevel));

            foreach (RoleLevel group in objset)
            {
                list.Add(group);
            }
            return list;
        }
        #endregion

        #region OnSaving

        protected override void OnSaving()
        {
            RoleLevel found = GetRoleLevel(this.角色, this.公司编码, this.职务等级);
            if (found != null && found.标识 != this.标识)
                throw new Exception("角色已具备这个职等的权限，不能重复设置.");
            else
                base.OnSaving();
        }
        #endregion

        #region 职等名称

        string grade_name = null;
        public string 职等名称
        {
            get
            {
                if (grade_name == null)
                {
                    if (Common.IsInteger(this.职务等级))
                        grade_name = PsHelper.GetSupvsrLvDescr(this.职务等级);
                    else
                        grade_name = this.职务等级;
                }
                return grade_name;
            }
        }
        #endregion
    }
}
