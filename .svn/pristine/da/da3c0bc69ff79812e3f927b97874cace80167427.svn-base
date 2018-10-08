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
    public partial class StepPayRate
    {
        static readonly ILog log = LogManager.GetLogger(typeof(StepPayRate));

        #region GetStepPayRate
        /// <summary>
        /// 通过 Id 获取
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static StepPayRate GetStepPayRate(Guid id)
        {
            StepPayRate obj = (StepPayRate)Session.DefaultSession.GetObjectByKey(typeof(StepPayRate), id);
            return obj;
        }

        public static StepPayRate GetStepPayRate(int stepId, DateTime effDt)
        {
            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                       new BinaryOperator("薪级标识", stepId, BinaryOperatorType.Equal),
                       new BinaryOperator("执行日期", effDt, BinaryOperatorType.Equal));

            XPCollection objset = new XPCollection(typeof(StepPayRate), criteria, new SortProperty("执行日期", SortingDirection.Descending));

            if (objset.Count > 0)
            {
                return (StepPayRate)objset[0];
            }
            else
                return null;
        }

        #endregion

        #region GetEffective

        //获取有效的职级工资
        public static StepPayRate GetEffective(int stepId, DateTime date)
        {
            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                       new BinaryOperator("薪级标识", stepId, BinaryOperatorType.Equal),
                       new BinaryOperator("执行日期", date, BinaryOperatorType.LessOrEqual)
                       );

            XPCollection objset = new XPCollection(MyHelper.XpoSession, typeof(StepPayRate), criteria, new SortProperty("执行日期", SortingDirection.Descending));

            if (objset.Count > 0)
            {
                return (StepPayRate)objset[0];
            }
            else
                return null;
        }
        #endregion

        #region GetEffectives

        //获取有效的职级工资
        public static List<StepPayRate> GetEffectives(DateTime date)
        {
            List<StepPayRate> list = new List<StepPayRate>();

            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                       new BinaryOperator("执行日期", date, BinaryOperatorType.LessOrEqual)
                       );

            XPCollection objset = new XPCollection(MyHelper.XpoSession, typeof(StepPayRate), criteria, new SortProperty("执行日期", SortingDirection.Descending));

            foreach (StepPayRate item in objset)
            {
                list.Add(item);
            }
            return list;
        }
        #endregion

        #region AddStepPayRate

        public static StepPayRate AddStepPayRate(int gradeId, int stepId, DateTime effDt)
        {
            StepPayRate rec = GetStepPayRate(stepId, effDt);
            if (rec == null)
            {
                rec = new StepPayRate();
                rec.标识 = Guid.NewGuid();
                rec.薪等标识 = gradeId;
                rec.薪级标识 = stepId;
                rec.执行日期 = effDt;
                rec.Save();
            }
            return rec;
        }
        #endregion
        
        #region OnSaving

        protected override void OnSaving()
        {
            StepPayRate found = GetStepPayRate(薪级标识, 执行日期);
            if (found != null && found.标识 != this.标识)
                throw new Exception("不能重复设置职级工资");
            else
                base.OnSaving();
        }
        #endregion

        #region GetAll

        public static List<StepPayRate> GetAll()
        {
            List<StepPayRate> list = new List<StepPayRate>();

            XPCollection objset = new XPCollection(MyHelper.XpoSession, typeof(StepPayRate), null, new SortProperty("薪等标识", SortingDirection.Ascending), new SortProperty("薪级标识", SortingDirection.Ascending), new SortProperty("执行日期", SortingDirection.Descending));

            foreach (StepPayRate step in objset)
            {
                list.Add(step);
            }
            return list;
        }

        #endregion
    }
}
