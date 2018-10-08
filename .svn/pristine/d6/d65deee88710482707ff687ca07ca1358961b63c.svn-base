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
    public partial class SalaryGrade
    {
        static readonly ILog log = LogManager.GetLogger(typeof(SalaryGrade));

        internal static List<SalaryGrade> allItems = null; //薪等表
        internal static List<SalaryGrade> currentGrades = null; //当前薪等表
        

        #region 薪等表

        public static List<SalaryGrade> 薪等表
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

        #region 当前薪等表

        public static List<SalaryGrade> 当前薪等表
        {
            get
            {
                if (currentGrades == null || currentGrades.Count == 0)
                {
                    currentGrades = SalaryGrade.GetEffectedGrades(DateTime.Today);
                }
                return currentGrades;
            }
        }
        #endregion

        #region Get

        public static SalaryGrade Get(string setid, string salPlan, string gradeCode)
        {
            return 薪等表.Find(a => a.集合 == setid && a.薪酬体系 == salPlan && a.薪等编号 == gradeCode);
        }
        #endregion

        #region GetName

        public static string GetName(string setid, string salPlan, string gradeCode)
        {
            SalaryGrade grade = 薪等表.Find(a => a.集合 == setid && a.薪酬体系 == salPlan && a.薪等编号 == gradeCode);
            if (grade == null)
                return "";
            else
                return grade.薪等名称;
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

        #region GetSalaryGrade
        /// <summary>
        /// 通过 Id 获取
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static SalaryGrade GetSalaryGrade(Guid id)
        {
            SalaryGrade obj = (SalaryGrade)MyHelper.XpoSession.GetObjectByKey(typeof(SalaryGrade), id);
            return obj;
        }

        public static SalaryGrade GetSalaryGrade(string setid, string salPlan, string grade, DateTime effDate)
        {
            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                       new BinaryOperator("集合", setid, BinaryOperatorType.Equal),
                       new BinaryOperator("薪酬体系", salPlan, BinaryOperatorType.Equal),
                       new BinaryOperator("薪等编号", grade, BinaryOperatorType.Equal),
                       new BinaryOperator("生效日期", effDate, BinaryOperatorType.Equal)
                       );

            XPCollection objset = new XPCollection(MyHelper.XpoSession, typeof(SalaryGrade), criteria, new SortProperty("生效日期", SortingDirection.Ascending));

            if (objset.Count > 0)
            {
                return (SalaryGrade)objset[0];
            }
            else
                return null;
        }

        //获取最后生效的薪等
        public static SalaryGrade GetEffectiveSalaryGrade(string setid, string salPlan, string grade, DateTime date)
        {
            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                       new BinaryOperator("集合", setid, BinaryOperatorType.Equal),
                       new BinaryOperator("薪酬体系", salPlan, BinaryOperatorType.Equal),
                       new BinaryOperator("薪等编号", grade, BinaryOperatorType.Equal),
                       new BinaryOperator("生效日期", date, BinaryOperatorType.LessOrEqual)
                       );

            XPCollection objset = new XPCollection(MyHelper.XpoSession, typeof(SalaryGrade), criteria, new SortProperty("生效日期", SortingDirection.Descending));

            if (objset.Count > 0)
            {
                return (SalaryGrade)objset[0];
            }
            else
                return null;
        }
        #endregion

        #region CheckEffected

        //检查当前薪等在指定的日期是否有效
        public bool CheckEffected(DateTime date)
        {
            if (this.状态 != "A") return false;
            //如果薪酬体系无效
            if (SalaryPlan.薪酬体系表.Find(a => a.集合 == this.集合 && a.英文名 == this.薪酬体系) == null) return false;
            //获取有效的薪等
            SalaryGrade latestEffect = SalaryGrade.GetEffectiveSalaryGrade(this.集合, this.薪酬体系, this.薪等编号, date);
            if (latestEffect == null) return false;
            return latestEffect.标识 == this.标识;
        }
        #endregion

        #region GetAll

        public static List<SalaryGrade> GetAll()
        {
            List<SalaryGrade> list = new List<SalaryGrade>();

            XPCollection objset = new XPCollection(MyHelper.XpoSession, typeof(SalaryGrade), null, new SortProperty("薪等编号", SortingDirection.Ascending), new SortProperty("生效日期", SortingDirection.Descending));

            foreach (SalaryGrade grade in objset)
            {
                list.Add(grade);
            } 
            return list;
        }
        #endregion

        #region GetEffectedGrades

        public static List<SalaryGrade> GetEffectedGrades(DateTime date)
        {
            List<SalaryGrade> list = new List<SalaryGrade>();

            XPCollection objset = new XPCollection(MyHelper.XpoSession, typeof(SalaryGrade), null, new SortProperty("薪酬体系", SortingDirection.Ascending), new SortProperty("薪等编号", SortingDirection.Ascending), new SortProperty("生效日期", SortingDirection.Descending));

            foreach (SalaryGrade grade in objset)
            {
                //只取出有效的
                if (grade.CheckEffected(date))
                {
                    list.Add(grade);
                }
            }
            return list;
        }
        #endregion

        #region GetGrades

        public static List<SalaryGrade> GetGrades(string salary_plan)
        {
            List<SalaryGrade> list = new List<SalaryGrade>();

            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                       new BinaryOperator("集合", "SHARE", BinaryOperatorType.Equal),
                       new BinaryOperator("薪酬体系", salary_plan, BinaryOperatorType.Equal),
                       new BinaryOperator("状态", "A", BinaryOperatorType.Equal)
                       );

            XPCollection objset = new XPCollection(MyHelper.XpoSession, typeof(SalaryGrade), criteria, new SortProperty("薪酬体系", SortingDirection.Ascending), new SortProperty("医疗保险缴纳基数", SortingDirection.Descending), new SortProperty("薪等编号", SortingDirection.Ascending), new SortProperty("生效日期", SortingDirection.Descending));

            foreach (SalaryGrade grade in objset)
            {
                SalaryGrade found = list.Find(a => a.薪等名称 == grade.薪等名称);
                if (found == null) list.Add(grade);
            }
            return list;
        }
        #endregion

        #region SalaryGrade

        public static SalaryGrade Get(string setid, string salAdmin, string gradeCode, DateTime date)
        {
            List<SalaryGrade> list = 薪等表.FindAll(a => a.集合 == setid && a.薪酬体系 == salAdmin && a.薪等编号 == gradeCode && a.生效日期 <= date).OrderByDescending(a => a.生效日期).ToList();
            if (list.Count > 0)
                return list[0];
            else
                return null;
        }
        #endregion

        #region AddSalaryGrade

        public static SalaryGrade AddSalaryGrade(string setid, string salPlan, string grade, DateTime effDate)
        {
            SalaryGrade plan = GetSalaryGrade(setid, salPlan, grade, effDate);
            if (plan == null)
            {
                plan = new SalaryGrade();
                plan.标识 = Guid.NewGuid();
                plan.集合 = setid;
                plan.薪酬体系 = salPlan;
                plan.薪等编号 = grade;
                plan.生效日期 = effDate;
                plan.创建时间 = DateTime.Now;
                plan.Save();
            }
            return plan;
        }
        #endregion

        #region SychSalaryGrade

        public static void SychSalaryGrade()
        {
            foreach (SalGrade sg in SalGrade.薪酬等级表)
            {
                SalaryGrade salPlan = AddSalaryGrade(sg.集合, sg.薪酬体系, sg.薪等编号, sg.生效日期);

                salPlan.薪等名称 = sg.薪等名称;
                salPlan.状态 = sg.状态;

                salPlan.基准工资标准 = sg.基准工资标准;
                salPlan.上表工资标准 = sg.上表工资标准;
                salPlan.设定工资标准 = sg.设定工资标准;
                salPlan.年休假工资 = sg.年休假工资;

                salPlan.养老保险缴纳基数 = sg.养老保险缴纳基数;
                salPlan.医疗保险缴纳基数 = sg.医疗保险缴纳基数;
                salPlan.生育保险缴纳基数 = sg.生育保险缴纳基数;
                salPlan.失业保险缴纳基数 = sg.失业保险缴纳基数;
                salPlan.工伤保险缴纳基数 = sg.工伤保险缴纳基数;

                salPlan.公积金基数 = sg.公积金基数;

                salPlan.上次同步时间 = DateTime.Now;

                salPlan.Save();
            }
            //冲突处理：有VS无 / 有VS变 / 无VS有
            foreach (SalaryGrade grade in GetAll())
            {
                SalGrade found = SalGrade.薪酬等级表.Find(a => a.集合 == grade.集合 && a.薪酬体系 == grade.薪酬体系 && a.薪等编号 == grade.薪等编号 && a.生效日期 == grade.生效日期);
                if (found == null) grade.Delete();
            }
        }
        #endregion

        #region GetLastMonthEffectiveSalaryGrade

        /// <summary>
        /// 上月执行的标准
        /// </summary>
        /// <param name="setid"></param>
        /// <param name="salPlan"></param>
        /// <param name="grade"></param>
        /// <returns></returns>
        public static SalaryGrade GetLastMonthEffectiveSalaryGrade(SalaryGrade grade)
        {
            DateTime date = new DateTime(DateTime.Today.AddMonths(-1).Year, DateTime.Today.AddMonths(-1).Month, 1);
            return GetEffectiveSalaryGrade(grade.集合, grade.薪酬体系, grade.薪等编号, date);
        }
        #endregion

        #region 全称

        public string 全称
        {
            get
            {
                return String.Format("{0}/{1}/{2}", this.集合, this.薪酬体系名称, this.薪等名称);
            }
        }
        #endregion

        #region 薪酬体系名称

        public string 薪酬体系名称
        {
            get
            {
                SalaryPlan plan = SalaryPlan.所有薪酬体系.Find(a=>a.集合 == this.集合 && a.英文名 == this.薪酬体系);
                if (plan != null)
                    return plan.中文名;
                else
                    return "";
            }
        }
        #endregion

        #region 上月执行的标准

        public SalaryGrade 上月执行的标准
        {
            get
            {
                SalaryGrade prevMonthEffective = GetLastMonthEffectiveSalaryGrade(this);
                return prevMonthEffective;
            }
        }
        #endregion
    }
}