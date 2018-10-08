using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using log4net;
using DevExpress.Data.Filtering;
using Hwagain.Components;

namespace Hwagain.SalaryCalculation.Components
{
    /// <summary>
    /// 绩效工资
    /// </summary>
    public partial class PerformanceSalary
    {
        static readonly ILog log = LogManager.GetLogger(typeof(PerformanceSalary));

        #region GetPerformanceSalary
        /// <summary>
        /// 通过 Id 获取
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static PerformanceSalary GetPerformanceSalary(Guid id)
        {
            PerformanceSalary obj = (PerformanceSalary)MyHelper.XpoSession.GetObjectByKey(typeof(PerformanceSalary), id);
            return obj;
        }
        //按生效日期查找个人绩效工资额
        public static PerformanceSalary GetPerformanceSalary(string empNo, DateTime effDt)
        {
            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                       new BinaryOperator("员工编号", empNo, BinaryOperatorType.Equal),
                       new BinaryOperator("生效日期", effDt, BinaryOperatorType.Equal)
                       );

            XPCollection objset = new XPCollection(MyHelper.XpoSession, typeof(PerformanceSalary), criteria, new SortProperty("生效日期", SortingDirection.Descending));

            if (objset.Count > 0)
            {
                return (PerformanceSalary)objset[0];
            }
            else
                return null;
        }
        //获取有效的个人绩效工资额
        public static PerformanceSalary GetEffective(string empNo, DateTime date)
        {
            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                       new BinaryOperator("员工编号", empNo, BinaryOperatorType.Equal),
                       new BinaryOperator("有效", true, BinaryOperatorType.Equal),
                       new BinaryOperator("生效日期", date, BinaryOperatorType.LessOrEqual)
                       );

            XPCollection objset = new XPCollection(MyHelper.XpoSession, typeof(PerformanceSalary), criteria, new SortProperty("生效日期", SortingDirection.Descending));

            if (objset.Count > 0)
            {
                return (PerformanceSalary)objset[0];
            }
            else
                return null;
        }

        #endregion

        #region GetEffectives

        //按有效的
        public static List<PerformanceSalary> GetEffectives(DateTime date)
        {
            List<PerformanceSalary> list = new List<PerformanceSalary>();

            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                       new BinaryOperator("生效日期", date, BinaryOperatorType.LessOrEqual),
                       new BinaryOperator("有效", true, BinaryOperatorType.Equal)
                       );

            XPCollection objset = new XPCollection(MyHelper.XpoSession, typeof(PerformanceSalary), criteria, new SortProperty("生效日期", SortingDirection.Descending));

            foreach (PerformanceSalary item in objset)
            {
                list.Add(item);
            }
            return list;
        }
        #endregion

        #region GetAll

        public static List<PerformanceSalary> GetAll()
        {
            List<PerformanceSalary> list = new List<PerformanceSalary>();

            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                       new BinaryOperator("有效", true, BinaryOperatorType.Equal)
                       );

            XPCollection objset = new XPCollection(MyHelper.XpoSession, typeof(PerformanceSalary), criteria, new SortProperty("生效日期", SortingDirection.Descending));

            foreach (PerformanceSalary order in objset)
            {
                list.Add(order);
            }
            return list;
        }
        #endregion

        #region AddPerformanceSalary

        public static PerformanceSalary AddPerformanceSalary(string empNo, DateTime effDt)
        {
            PerformanceSalary item = GetPerformanceSalary(empNo, effDt);
            if (item == null)
            {
                item = new PerformanceSalary();
                item.标识 = Guid.NewGuid();
                item.员工编号 = empNo;
                item.生效日期 = effDt;
                item.Save();
            }           
            return item;
        }
        #endregion

        #region OnSaving

        protected override void OnSaving()
        {
            if (this.生效日期 == DateTime.MinValue) this.生效日期 = new DateTime(1993, 1, 1);
        }
        #endregion

        #region 员工信息

        EmployeeInfo empInfo = null;
        public EmployeeInfo 员工信息
        {
            get
            {
                if (empInfo == null) empInfo = EmployeeInfo.GetEmployeeInfo(this.员工编号);
                return empInfo;
            }
        }
        #endregion

        #region 职务

        string job = null;
        public string 职务
        {
            get
            {
                if (job == null)
                {
                    List<KeyValue> list = KeyValue.GetList(PsHelper.职务代码);
                    KeyValue kv = list.Find(a => a.键 == this.员工信息.职务代码);
                    if (kv != null) job = kv.值;
                }
                return job;
            }
        }
        #endregion

        #region 年

        public decimal 年
        {
            get
            {
                return this.每月金额 * 12;
            }
        }
        #endregion

        [NonPersistent]
        public decimal 职级工资 { get; set; }
        public decimal 占比
        {
            get
            {
                if (职级工资 > 0) return this.每月金额 / 职级工资;
                return 0;
            }
        }
    }
}