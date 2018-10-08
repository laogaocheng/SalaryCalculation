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
    public partial class SalaryStep
    {
        static readonly ILog log = LogManager.GetLogger(typeof(SalaryStep));

        internal static List<SalaryStep> allItems = null; //薪级表

        #region 薪级表

        public static List<SalaryStep> 薪级表
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

        #region Get

        public static SalaryStep Get(string setid, string salPlan, string gradeCode, int stepNumber)
        {
            return 薪级表.Find(a => a.集合 == setid && a.薪酬体系 == salPlan && a.薪等编号 == gradeCode && a.薪级编号 == stepNumber);
        }
        #endregion

        #region GetName

        public static string GetName(string setid, string salPlan, string gradeCode, int stepNumber)
        {
            SalaryStep stpe = 薪级表.Find(a => a.集合 == setid && a.薪酬体系 == salPlan && a.薪等编号 == gradeCode && a.薪级编号 == stepNumber);
            if (stpe == null)
                return "";
            else
                return stpe.薪级名称;
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

        #region GetSalaryStep
        /// <summary>
        /// 通过 Id 获取
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static SalaryStep GetSalaryStep(Guid id)
        {
            SalaryStep obj = (SalaryStep)MyHelper.XpoSession.GetObjectByKey(typeof(SalaryStep), id);
            return obj;
        }

        public static SalaryStep GetSalaryStep(Guid gradeId, int step, DateTime effDate)
        {
            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                       new BinaryOperator("薪等标识", gradeId, BinaryOperatorType.Equal),
                       new BinaryOperator("薪级编号", step, BinaryOperatorType.Equal),
                       new BinaryOperator("生效日期", effDate, BinaryOperatorType.Equal)
                       );

            XPCollection objset = new XPCollection(MyHelper.XpoSession, typeof(SalaryStep), criteria, new SortProperty("生效日期", SortingDirection.Ascending));

            if (objset.Count > 0)
            {
                return (SalaryStep)objset[0];
            }
            else
                return null;
        }

        public static SalaryStep GetEffectiveSalaryStep(Guid gradeId, int step, DateTime date)
        {
            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                       new BinaryOperator("薪等标识", gradeId, BinaryOperatorType.Equal),
                       new BinaryOperator("薪级编号", step, BinaryOperatorType.Equal),
                       new BinaryOperator("生效日期", date, BinaryOperatorType.LessOrEqual)
                       );

            XPCollection objset = new XPCollection(MyHelper.XpoSession, typeof(SalaryStep), criteria, new SortProperty("生效日期", SortingDirection.Descending));

            if (objset.Count > 0)
            {
                return (SalaryStep)objset[0];
            }
            else
                return null;
        }

        #endregion

        #region GetLastEffectiveSalaryStep

        public static SalaryStep GetLastEffectiveSalaryStep(SalaryStep step)
        {
            return GetEffectiveSalaryStep(step.薪等.标识, step.薪级编号, DateTime.Today);
        }
        #endregion

        #region GetAll

        public static List<SalaryStep> GetAll()
        {
            List<SalaryStep> list = new List<SalaryStep>();

            XPCollection objset = new XPCollection(MyHelper.XpoSession, typeof(SalaryStep), null, new SortProperty("薪级编号", SortingDirection.Ascending), new SortProperty("生效日期", SortingDirection.Descending));

            foreach (SalaryStep step in objset)
            {
                list.Add(step);
            }
            return list;
        }

        #endregion

        #region GetEffectedSteps

        //获取所有有效的薪级
        public static List<SalaryStep> GetEffectedSteps(DateTime date)
        {
            List<SalaryGrade> effectedGrade = SalaryGrade.GetEffectedGrades(date);
            return GetEffectedSteps(date, effectedGrade);
        }

        //获取所有有效的薪级
        public static List<SalaryStep> GetEffectedSteps(DateTime date, List<SalaryGrade> effectedGrade)
        {
            List<SalaryStep> list = new List<SalaryStep>();

            XPCollection objset = new XPCollection(MyHelper.XpoSession, typeof(SalaryStep), null, new SortProperty("薪级编号", SortingDirection.Ascending), new SortProperty("生效日期", SortingDirection.Descending));

            foreach (SalaryStep step in objset)
            {
                //只取出有效薪等的薪级
                if (effectedGrade.Find(a => a.标识 == step.薪等标识) != null)
                {
                    list.Add(step);
                }
            }
            return list;
        }
        #endregion

        #region AddSalaryStep

        public static SalaryStep AddSalaryStep(string setid, string salPlan, string grade, int step, DateTime effDate)
        {
            SalaryGrade salGrade = SalaryGrade.GetSalaryGrade(setid, salPlan, grade, effDate);
            if (salGrade != null)
            {
                SalaryStep plan = GetSalaryStep(salGrade.标识, step, effDate);
                if (plan == null)
                {
                    plan = new SalaryStep();
                    plan.标识 = Guid.NewGuid();
                    plan.薪等标识 = salGrade.标识;
                    plan.薪级编号 = step;
                    plan.生效日期 = effDate;
                    plan.创建时间 = DateTime.Now;
                    plan.Save();
                }
                return plan;
            }
            else
                return null;
        }
        #endregion

        #region SychSalaryStep

        public static void SychSalaryStep()
        {
            foreach (SalStep ss in SalStep.GetAll())
            {
                SalaryStep salStep = AddSalaryStep(ss.集合, ss.薪酬体系, ss.薪等编号, ss.薪级编号, ss.生效日期);
                if (salStep == null) continue;

                salStep.薪级名称 = ss.薪级名称;

                salStep.上次同步时间 = DateTime.Now;

                salStep.Save();
            }
            //冲突处理：有VS无 / 有VS变 / 无VS有
            foreach (SalaryStep step in GetAll())
            {
                SalStep found = SalStep.GetAll().Find(a => a.集合 == step.集合 && a.薪酬体系 == step.薪酬体系 && a.薪等编号 == step.薪等编号 && a.生效日期 == step.生效日期);
                if (found == null) step.Delete();
            }
        }
        #endregion

        #region 薪等

        SalaryGrade grade = null;
        public SalaryGrade 薪等
        {
            get
            {
                if (grade == null) grade = SalaryGrade.GetSalaryGrade(this.薪等标识);
                return grade;
            }
        }
        #endregion

        #region 薪酬体系

        public string 薪酬体系
        {
            get
            {
                if (this.薪等 == null)
                    return "";
                else
                    return this.薪等.薪酬体系;
            }
        }
        #endregion

        #region 集合

        public string 集合
        {
            get
            {
                if (this.薪等 == null)
                    return "";
                else
                    return this.薪等.集合;
            }
        }
        #endregion

        #region 薪酬体系名称

        public string 薪酬体系名称
        {
            get
            {
                if (this.薪等 == null)
                    return "";
                else
                    return this.薪等.薪酬体系名称;
            }
        }
        #endregion

        #region 薪等编号

        public string 薪等编号
        {
            get
            {
                if (this.薪等 == null)
                    return "";
                else
                    return this.薪等.薪等编号;
            }
        }
        #endregion

        #region 薪等名称

        public string 薪等名称
        {
            get
            {
                if (this.薪等 == null)
                    return "";
                else
                    return this.薪等.薪等名称;
            }
        }
        #endregion

    }
}