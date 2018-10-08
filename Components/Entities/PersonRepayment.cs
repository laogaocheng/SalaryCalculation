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
    /// 个人还款记录
    /// </summary>
    public partial class PersonRepayment
    {
        static readonly ILog log = LogManager.GetLogger(typeof(PersonRepayment));

        #region GetPersonRepayment
        /// <summary>
        /// 通过 Id 获取
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static PersonRepayment GetPersonRepayment(Guid id)
        {
            PersonRepayment obj = (PersonRepayment)MyHelper.XpoSession.GetObjectByKey(typeof(PersonRepayment), id);
            return obj;
        }
        //按创建时间查找个人报销记录
        public static PersonRepayment GetPersonRepayment(Guid borrowId, int year, int month)
        {
            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                       new BinaryOperator("借款记录标识", borrowId, BinaryOperatorType.Equal),
                       new BinaryOperator("年", year, BinaryOperatorType.Equal),
                       new BinaryOperator("月", month, BinaryOperatorType.Equal)
                       );

            XPCollection objset = new XPCollection(MyHelper.XpoSession, typeof(PersonRepayment), criteria, new SortProperty("创建时间", SortingDirection.Ascending));

            if (objset.Count > 0)
            {
                return (PersonRepayment)objset[0];
            }
            else
                return null;
        }
        #endregion

        #region Clear

        public static void Clear(string empLid, int year, int month)
        {
            List<PersonRepayment> list = GetPersonRepayments(empLid, year, month);
            foreach (PersonRepayment item in list)
            {
                item.Delete();
            }
        }
        #endregion

        #region GetPersonRepayments

        public static List<PersonRepayment> GetPersonRepayments(string empLid, int year, int month)
        {
            List<PersonRepayment> list = new List<PersonRepayment>();

            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                       new BinaryOperator("员工编号", empLid, BinaryOperatorType.Equal),
                       new BinaryOperator("年", year, BinaryOperatorType.Equal),
                       new BinaryOperator("月", month, BinaryOperatorType.Equal)
                       );

            XPCollection objset = new XPCollection(MyHelper.XpoSession, typeof(PersonRepayment), criteria, new SortProperty("创建时间", SortingDirection.Ascending));

            foreach (PersonRepayment order in objset)
            {
                list.Add(order);
            }
            return list;
        }
        #endregion

        #region AddPersonRepayment

        public static PersonRepayment AddPersonRepayment(PersonBorrow borrow, int year, int month)
        {
            PersonRepayment item = GetPersonRepayment(borrow.标识, year, month);
            if (item == null)
            {
                item = new PersonRepayment();
                item.标识 = Guid.NewGuid();
                item.借款记录标识 = borrow.标识;
                item.项目 = borrow.项目;
                item.年 = year;
                item.月 = month;
                item.姓名 = borrow.姓名;
                item.员工编号 = borrow.员工编号;
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

        public static List<PersonRepayment> GetAll(DateTime start, DateTime end)
        {
            List<PersonRepayment> list = new List<PersonRepayment>();

            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                       new BinaryOperator("创建时间", start, BinaryOperatorType.GreaterOrEqual),
                       new BinaryOperator("创建时间", end, BinaryOperatorType.LessOrEqual)
                       );

            XPCollection objset = new XPCollection(MyHelper.XpoSession, typeof(PersonRepayment), criteria, new SortProperty("创建时间", SortingDirection.Ascending));

            foreach (PersonRepayment order in objset)
            {
                list.Add(order);
            }
            return list;
        }

        public static List<PersonRepayment> GetAll(Guid borrowId)
        {
            List<PersonRepayment> list = new List<PersonRepayment>();

            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                       new BinaryOperator("借款记录标识", borrowId, BinaryOperatorType.Equal)
                       );

            XPCollection objset = new XPCollection(MyHelper.XpoSession, typeof(PersonRepayment), criteria, new SortProperty("创建时间", SortingDirection.Ascending));

            foreach (PersonRepayment order in objset)
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