using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using log4net;
using DevExpress.Data.Filtering;

namespace Hwagain.SalaryCalculation.Components
{
    public partial class SalaryPlan
    {
        static readonly ILog log = LogManager.GetLogger(typeof(SalaryPlan));

        internal static List<SalaryPlan> allItems = null; //薪酬体系

        #region 所有薪酬体系

        public static List<SalaryPlan> 所有薪酬体系
        {
            get
            {
                if (allItems == null || allItems.Count == 0) 
                {
                    allItems = GetAll();
                }
                return allItems;
            }
        }
        #endregion

        #region 薪酬体系表

        public static List<SalaryPlan> 薪酬体系表
        {
            get
            {
                return 所有薪酬体系.FindAll(a => a.状态 == "A"); ;
            }
        }
        #endregion

        #region Get

        public static SalaryPlan Get(string setid, string salPlan)
        {
            return 所有薪酬体系.Find(a => a.集合 == setid && a.英文名 == salPlan);
        }

        #endregion

        public static SalaryPlan GetByCompany(string company)
        {
            return 所有薪酬体系.Find(a => a.集合 == "SHARE" && a.中文名 == company + "薪资体系");
        }

        #region GetName

        public static string GetName(string setid, string salPlan)
        {
            SalaryPlan sal = 薪酬体系表.Find(a => a.集合 == setid && a.英文名 == salPlan);
            if (sal == null)
                return "";
            else
                return sal.中文名;
        }
        #endregion

        #region OnSaved

        protected override void OnSaved()
        {
            allItems = null;
            base.OnSaved();
        }
        #endregion

        #region OnDeleted

        protected override void OnDeleted()
        {
            allItems = null;
            base.OnDeleted();
        }
        #endregion

        #region GetSalaryPlan
        /// <summary>
        /// 通过 Id 获取
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static SalaryPlan GetSalaryPlan(Guid id)
        {
            SalaryPlan obj = (SalaryPlan)MyHelper.XpoSession.GetObjectByKey(typeof(SalaryPlan), id);
            return obj;
        }

        public static SalaryPlan GetSalaryPlan(string setid, string enName)
        {
            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                       new BinaryOperator("集合", setid, BinaryOperatorType.Equal),
                       new BinaryOperator("英文名", enName, BinaryOperatorType.Equal)
                       );

            XPCollection objset = new XPCollection(MyHelper.XpoSession, typeof(SalaryPlan), criteria, new SortProperty("英文名", SortingDirection.Descending));

            if (objset.Count > 0)
            {
                return (SalaryPlan)objset[0];
            }
            else
                return null;
        }

        #endregion

        #region GetAll

        public static List<SalaryPlan> GetAll()
        {
            List<SalaryPlan> list = new List<SalaryPlan>();
            XPCollection objset = new XPCollection(MyHelper.XpoSession, typeof(SalaryPlan), null, new SortProperty("英文名", SortingDirection.Ascending));

            foreach (SalaryPlan order in objset)
            {
                list.Add(order);
            }
            return list;
        }
        #endregion
        
        #region AddSalaryPlan

        public static SalaryPlan AddSalaryPlan(string setid, string enName, string cnName, string status)
        {
            SalaryPlan plan = GetSalaryPlan(setid, enName);
            if (plan == null)
            {
                plan = new SalaryPlan();
                plan.标识 = Guid.NewGuid();
                plan.集合 = setid;
                plan.英文名 = enName;
            }
            plan.中文名 = cnName;
            plan.状态 = status;
            plan.Save();
            return plan;
        }
        #endregion

        #region SychSalaryPlan
        /// <summary>
        /// 同步薪酬体系
        /// </summary>
        public static void SychSalaryPlan()
        {
            //添加所有PS中存在的记录
            foreach (SalPlan sp in SalPlan.薪酬体系)
            {
                AddSalaryPlan(sp.集合, sp.英文名, sp.中文名, sp.状态);
            }
            //冲突处理：有VS无 / 有VS变 / 无VS有
            List<SalaryPlan> all = GetAll();
            foreach (SalaryPlan plan in all)
            {
                SalPlan sp = SalPlan.薪酬体系.Find(a => a.集合 == plan.集合 && a.英文名 == plan.英文名);
                if (sp == null) plan.Delete();
            }
        }
        #endregion
    }
}