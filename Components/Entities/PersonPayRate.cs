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
    /// 个人职级工资（标准）
    /// </summary>
    public partial class PersonPayRate
    {
        static readonly ILog log = LogManager.GetLogger(typeof(PersonPayRate));

        #region GetPersonPayRate
        /// <summary>
        /// 通过 Id 获取
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static PersonPayRate GetPersonPayRate(Guid id)
        {
            PersonPayRate obj = (PersonPayRate)MyHelper.XpoSession.GetObjectByKey(typeof(PersonPayRate), id);
            return obj;
        }
        //按执行日期查找个人职级工资标准
        public static PersonPayRate GetPersonPayRate(string empNo, DateTime effDt)
        {
            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                       new BinaryOperator("员工编号", empNo, BinaryOperatorType.Equal),
                       new BinaryOperator("生效日期", effDt, BinaryOperatorType.Equal)
                       );

            XPCollection objset = new XPCollection(MyHelper.XpoSession, typeof(PersonPayRate), criteria, new SortProperty("生效日期", SortingDirection.Descending));

            if (objset.Count > 0)
            {
                return (PersonPayRate)objset[0];
            }
            else
                return null;
        }
        //按有效的个人职级的执行标准
        public static PersonPayRate GetEffective(string empNo, DateTime date)
        {
            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                       new BinaryOperator("员工编号", empNo, BinaryOperatorType.Equal),
                       new BinaryOperator("生效日期", date, BinaryOperatorType.LessOrEqual)
                       );

            XPCollection objset = new XPCollection(MyHelper.XpoSession, typeof(PersonPayRate), criteria, new SortProperty("生效日期", SortingDirection.Descending));

            if (objset.Count > 0)
            {
                return (PersonPayRate)objset[0];
            }
            else
                return null;
        }

        #endregion

        #region GetEffectives

        //按有效的个人职级的执行标准
        public static List<PersonPayRate> GetEffectives(DateTime date)
        {
            List<PersonPayRate> list = new List<PersonPayRate>();

            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                       new BinaryOperator("生效日期", date, BinaryOperatorType.LessOrEqual)
                       );

            XPCollection objset = new XPCollection(MyHelper.XpoSession, typeof(PersonPayRate), criteria, new SortProperty("生效日期", SortingDirection.Descending));

            foreach (PersonPayRate item in objset)
            {
                list.Add(item);
            }
            return list;
        }
        #endregion

        #region GetAll

        public static List<PersonPayRate> GetAll(string empNo)
        {
            List<PersonPayRate> list = new List<PersonPayRate>();

            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                       new BinaryOperator("员工编号", empNo, BinaryOperatorType.Equal)
                       );

            XPCollection objset = new XPCollection(MyHelper.XpoSession, typeof(PersonPayRate), criteria, new SortProperty("序号", SortingDirection.Ascending));

            foreach (PersonPayRate order in objset)
            {
                list.Add(order);
            }
            return list;
        }
        /// <summary>
        /// 获取所有个人职级工资
        /// </summary>
        /// <param name="onlyIsValid">仅获取有效的记录</param>
        /// <returns></returns>
        public static List<PersonPayRate> GetAll(bool onlyIsValid)
        {
            List<PersonPayRate> list = new List<PersonPayRate>();

            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                       new BinaryOperator("有效", true, BinaryOperatorType.Equal)
                       );

            if (onlyIsValid == false) criteria = null;

            XPCollection objset = new XPCollection(MyHelper.XpoSession, typeof(PersonPayRate), criteria, new SortProperty("序号", SortingDirection.Ascending));

            foreach (PersonPayRate order in objset)
            {
                list.Add(order);
            }
            return list;
        }
        #endregion

        #region AddPersonPayRate

        public static PersonPayRate AddPersonPayRate(string empNo, DateTime effDt)
        {
            PersonPayRate payRate = GetPersonPayRate(empNo, effDt);
            if (payRate == null)
            {
                payRate = new PersonPayRate();
                payRate.标识 = Guid.NewGuid();
                payRate.员工编号 = empNo;
                payRate.生效日期 = effDt;
                payRate.Save();
            }           
            return payRate;
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

        #region 姓名

        string name = null;
        public string 姓名
        {
            get
            {
                if (name == null) name = this.员工信息.姓名;
                return name;
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

        #region 年薪

        public decimal 年薪
        {
            get
            {
                return 月薪 * 12;
            }
        }
        #endregion

    }
}