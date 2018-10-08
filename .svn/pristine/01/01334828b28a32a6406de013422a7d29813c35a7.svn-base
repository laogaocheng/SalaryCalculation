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
    public partial class QueryLevel
    {
        static readonly ILog log = LogManager.GetLogger(typeof(QueryLevel));

        #region GetQueryLevel
        /// <summary>
        /// 通过 Id 获取线路
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static QueryLevel GetQueryLevel(Guid id)
        {
            QueryLevel obj = (QueryLevel)Session.DefaultSession.GetObjectByKey(typeof(QueryLevel), id);
            return obj;
        }

        public static QueryLevel GetQueryLevel(string name, string company, string level)
        {
            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                       new BinaryOperator("姓名", name, BinaryOperatorType.Equal),
                       new BinaryOperator("公司编码", company, BinaryOperatorType.Equal),
                       new BinaryOperator("职务等级", level, BinaryOperatorType.Equal));

            XPCollection objset = new XPCollection(typeof(QueryLevel), criteria, new SortProperty("职务等级", SortingDirection.Ascending));

            if (objset.Count > 0)
            {
                return (QueryLevel)objset[0];
            }
            else
                return null;
        }

        #endregion

        #region GetQueryLevels

        //获取所有查询权限
        public static List<QueryLevel> GetQueryLevels(string name)
        {
            List<QueryLevel> list = new List<QueryLevel>();

            XPCollection objset = null;

            objset = new XPCollection(typeof(QueryLevel),
                 new BinaryOperator("姓名", name, BinaryOperatorType.Equal),
                 new SortProperty("姓名", SortingDirection.Descending));

            foreach (QueryLevel Level in objset)
            {
                list.Add(Level);
            }
            return list;
        }
        #endregion

        #region GetAll

        //获取所有查询权限
        public static List<QueryLevel> GetAll()
        {
            List<QueryLevel> list = new List<QueryLevel>();

            XPCollection objset = new XPCollection(typeof(QueryLevel));

            foreach (QueryLevel group in objset)
            {
                list.Add(group);
            }
            return list;
        }
        #endregion

        #region OnSaving

        protected override void OnSaving()
        {
            QueryLevel found = GetQueryLevel(this.姓名, this.公司编码, this.职务等级);
            if (found != null && found.标识 != this.标识)
                throw new Exception("用户已具备这个职等的权限，不能重复设置.");
            else
                base.OnSaving();
        }
        #endregion

        #region 职等信息

        LevelInfo levelInfo = null;
        public LevelInfo 职等信息
        {
            get
            {
                if (levelInfo == null)
                {
                    levelInfo = LevelInfo.GetLevelInfo(this.职务等级);
                }
                return levelInfo;
            }
        }
        #endregion

        #region 可查阅的最高工资额

        [NonPersistent]
        public decimal 可查阅的最高工资额
        {
            get
            {
                if (this.职等信息 == null)
                    return 0;
                else
                    return this.职等信息.最高工资额;
            }
        }
        #endregion
    }
}
