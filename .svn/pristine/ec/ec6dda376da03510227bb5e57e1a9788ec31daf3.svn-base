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
    /// 执行的绩效工资
    /// </summary>
    public partial class EffectivePerformanceSalary
    {
        static readonly ILog log = LogManager.GetLogger(typeof(EffectivePerformanceSalary));

        #region GetEffectivePerformanceSalary
        /// <summary>
        /// 通过 Id 获取
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static EffectivePerformanceSalary GetEffectivePerformanceSalary(Guid id)
        {
            EffectivePerformanceSalary obj = (EffectivePerformanceSalary)MyHelper.XpoSession.GetObjectByKey(typeof(EffectivePerformanceSalary), id);
            return obj;
        }
        //按执行日期查找执行的绩效工资
        public static EffectivePerformanceSalary GetEffectivePerformanceSalary(string empNo, int year, int month)
        {
            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                       new BinaryOperator("员工编号", empNo, BinaryOperatorType.Equal),
                       new BinaryOperator("年", year, BinaryOperatorType.Equal),
                       new BinaryOperator("月", month, BinaryOperatorType.Equal)
                       );

            XPCollection objset = new XPCollection(MyHelper.XpoSession, typeof(EffectivePerformanceSalary), criteria, new SortProperty("录入时间", SortingDirection.Descending));

            if (objset.Count > 0)
            {
                return (EffectivePerformanceSalary)objset[0];
            }
            else
                return null;
        }
        //按有效的执行的绩效工资
        public static EffectivePerformanceSalary GetEffective(string empNo, int year, int month)
        {
            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                       new BinaryOperator("员工编号", empNo, BinaryOperatorType.Equal),
                       new BinaryOperator("年", year, BinaryOperatorType.Equal),
                       new BinaryOperator("月", month, BinaryOperatorType.Equal)
                       );

            XPCollection objset = new XPCollection(MyHelper.XpoSession, typeof(EffectivePerformanceSalary), criteria, new SortProperty("录入时间", SortingDirection.Descending));

            if (objset.Count > 0)
            {
                return (EffectivePerformanceSalary)objset[0];
            }
            else
                return null;
        }

        #endregion

        #region AddEffectivePerformanceSalary

        public static EffectivePerformanceSalary AddEffectivePerformanceSalary(string empNo, int year, int month)
        {
            EffectivePerformanceSalary item = GetEffectivePerformanceSalary(empNo, year, month);
            if (item == null)
            {
                item = new EffectivePerformanceSalary();
                item.标识 = Guid.NewGuid();
                item.员工编号 = empNo;
                item.年 = year;
                item.月 = month;
                item.Save();
            }           
            return item;
        }
        #endregion

        #region OnSaving

        protected override void OnSaving()
        {
            base.OnSaving();
        }
        #endregion

        #region GetAll

        public static List<EffectivePerformanceSalary> GetAll(int year, int month)
        {
            List<EffectivePerformanceSalary> list = new List<EffectivePerformanceSalary>();

            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                       new BinaryOperator("年", year, BinaryOperatorType.Equal),
                       new BinaryOperator("月", month, BinaryOperatorType.Equal)
                       );

            XPCollection objset = new XPCollection(MyHelper.XpoSession, typeof(EffectivePerformanceSalary), criteria, new SortProperty("录入时间", SortingDirection.Ascending));

            foreach (EffectivePerformanceSalary order in objset)
            {
                list.Add(order);
            }
            return list;
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

    }
}