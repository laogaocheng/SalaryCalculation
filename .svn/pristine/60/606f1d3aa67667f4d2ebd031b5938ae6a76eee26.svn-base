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
    /// 报销标准
    /// </summary>
    public partial class ReimbursementStandard
    {
        static readonly ILog log = LogManager.GetLogger(typeof(ReimbursementStandard));

        #region GetReimbursementStandard
        /// <summary>
        /// 通过 Id 获取
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static ReimbursementStandard GetReimbursementStandard(Guid id)
        {
            ReimbursementStandard obj = (ReimbursementStandard)MyHelper.XpoSession.GetObjectByKey(typeof(ReimbursementStandard), id);
            return obj;
        }
        //按执行日期查找个人报销标准
        public static ReimbursementStandard GetReimbursementStandard(string empNo, string itemName, DateTime effDt)
        {
            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                       new BinaryOperator("员工编号", empNo, BinaryOperatorType.Equal),
                       new BinaryOperator("项目", itemName, BinaryOperatorType.Equal),
                       new BinaryOperator("生效日期", effDt, BinaryOperatorType.Equal)
                       );

            XPCollection objset = new XPCollection(MyHelper.XpoSession, typeof(ReimbursementStandard), criteria, new SortProperty("生效日期", SortingDirection.Descending));

            if (objset.Count > 0)
            {
                return (ReimbursementStandard)objset[0];
            }
            else
                return null;
        }
        //按有效的个人报销标准
        public static ReimbursementStandard GetEffective(string empNo, string itemName, DateTime date)
        {
            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                       new BinaryOperator("员工编号", empNo, BinaryOperatorType.Equal),
                       new BinaryOperator("项目", itemName, BinaryOperatorType.Equal),
                       new BinaryOperator("有效", true, BinaryOperatorType.Equal),
                       new BinaryOperator("生效日期", date, BinaryOperatorType.LessOrEqual)
                       );

            XPCollection objset = new XPCollection(MyHelper.XpoSession, typeof(ReimbursementStandard), criteria, new SortProperty("生效日期", SortingDirection.Descending));

            if (objset.Count > 0)
            {
                return (ReimbursementStandard)objset[0];
            }
            else
                return null;
        }

        #endregion

        #region GetEffectives

        //按有效的个人报销标准
        public static List<ReimbursementStandard> GetEffectives(DateTime date)
        {
            List<ReimbursementStandard> list = new List<ReimbursementStandard>();

            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                       new BinaryOperator("生效日期", date, BinaryOperatorType.LessOrEqual),
                       new BinaryOperator("有效", true, BinaryOperatorType.Equal)
                       );

            XPCollection objset = new XPCollection(MyHelper.XpoSession, typeof(ReimbursementStandard), criteria, new SortProperty("生效日期", SortingDirection.Descending));

            foreach (ReimbursementStandard item in objset)
            {
                list.Add(item);
            }
            return list;
        }
        #endregion

        #region GetAll

        public static List<ReimbursementStandard> GetAll()
        {
            List<ReimbursementStandard> list = new List<ReimbursementStandard>();

            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                       new BinaryOperator("有效", true, BinaryOperatorType.Equal)
                       );

            XPCollection objset = new XPCollection(MyHelper.XpoSession, typeof(ReimbursementStandard), criteria, new SortProperty("生效日期", SortingDirection.Ascending));

            foreach (ReimbursementStandard order in objset)
            {
                list.Add(order);
            }
            return list;
        }
        #endregion

        #region AddReimbursementStandard

        public static ReimbursementStandard AddReimbursementStandard(string empNo, string itemName, DateTime effDt)
        {
            ReimbursementStandard item = GetReimbursementStandard(empNo, itemName, effDt);
            if (item == null)
            {
                item = new ReimbursementStandard();
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

    }
}