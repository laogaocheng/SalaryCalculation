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
    /// 个人借款
    /// </summary>
    public partial class PersonBorrow
    {
        static readonly ILog log = LogManager.GetLogger(typeof(PersonBorrow));

        #region GetPersonBorrow
        /// <summary>
        /// 通过 Id 获取
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static PersonBorrow GetPersonBorrow(Guid id)
        {
            PersonBorrow obj = (PersonBorrow)MyHelper.XpoSession.GetObjectByKey(typeof(PersonBorrow), id);
            return obj;
        }
        //按执行日期查找个人借款记录
        public static PersonBorrow GetPersonBorrow(string empNo, string itemName, DateTime effDt)
        {
            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                       new BinaryOperator("员工编号", empNo, BinaryOperatorType.Equal),
                       new BinaryOperator("项目", itemName, BinaryOperatorType.Equal),
                       new BinaryOperator("生效日期", effDt, BinaryOperatorType.Equal)
                       );

            XPCollection objset = new XPCollection(MyHelper.XpoSession, typeof(PersonBorrow), criteria, new SortProperty("生效日期", SortingDirection.Descending));

            if (objset.Count > 0)
            {
                return (PersonBorrow)objset[0];
            }
            else
                return null;
        }
        //按有效的个人借款记录
        public static PersonBorrow GetEffective(string empNo, string itemName, DateTime date)
        {
            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                       new BinaryOperator("员工编号", empNo, BinaryOperatorType.Equal),
                       new BinaryOperator("有效", true, BinaryOperatorType.Equal),
                       new BinaryOperator("项目", itemName, BinaryOperatorType.Equal),
                       new BinaryOperator("生效日期", date, BinaryOperatorType.LessOrEqual)
                       );

            XPCollection objset = new XPCollection(MyHelper.XpoSession, typeof(PersonBorrow), criteria, new SortProperty("生效日期", SortingDirection.Descending));

            if (objset.Count > 0)
            {
                return (PersonBorrow)objset[0];
            }
            else
                return null;
        }

        #endregion

        #region GetAll

        public static List<PersonBorrow> GetAll()
        {
            List<PersonBorrow> list = new List<PersonBorrow>();
            XPCollection objset = new XPCollection(MyHelper.XpoSession, typeof(PersonBorrow), null, new SortProperty("录入时间", SortingDirection.Descending));

            foreach (PersonBorrow order in objset)
            {
                list.Add(order);
            }
            return list;
        }
        #endregion

        #region GetMyBorrows
        /// <summary>
        /// 获取员工的借款单
        /// </summary>
        /// <param name="emplid"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public static List<PersonBorrow> GetMyBorrows(string emplid, int year, int month)
        {
            List<PersonBorrow> list = new List<PersonBorrow>();

            DateTime date = new DateTime(year, month, 1);

            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                       new BinaryOperator("员工编号", emplid, BinaryOperatorType.Equal),
                       new BinaryOperator("已还清", false, BinaryOperatorType.Equal),
                       new BinaryOperator("生效日期", date, BinaryOperatorType.LessOrEqual)
                       );

            XPCollection objset = new XPCollection(MyHelper.XpoSession, typeof(PersonBorrow), criteria, new SortProperty("录入时间", SortingDirection.Descending));

            foreach (PersonBorrow order in objset)
            {
                list.Add(order);
            }
            return list;
        }
        #endregion

        #region AddPersonBorrow

        public static PersonBorrow AddPersonBorrow(string empNo, string itemName, DateTime effDt)
        {
            PersonBorrow item = GetPersonBorrow(empNo, itemName, effDt);
            if (item == null)
            {
                item = new PersonBorrow();
                item.标识 = Guid.NewGuid();
                item.员工编号 = empNo;
                item.项目 = itemName;
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

        #region 还款记录

        public List<PersonRepayment> 还款记录
        {
            get
            {
                List<PersonRepayment> list = PersonRepayment.GetAll(this.标识);
                return list;
            }
        }
        #endregion

        #region 累计已还

        public decimal 累计已还
        {
            get
            {
                return this.还款记录.Sum(a => a.还款金额);
            }
        }
        #endregion

        #region 余额

        public decimal 余额
        {
            get
            {
                return this.金额 - this.累计已还;
            }
        }
        #endregion
    }
}