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
    /// 个人报销
    /// </summary>
    public partial class PersonReimbursement
    {
        static readonly ILog log = LogManager.GetLogger(typeof(PersonReimbursement));

        #region GetPersonReimbursement
        /// <summary>
        /// 通过 Id 获取
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static PersonReimbursement GetPersonReimbursement(Guid id)
        {
            PersonReimbursement obj = (PersonReimbursement)MyHelper.XpoSession.GetObjectByKey(typeof(PersonReimbursement), id);
            return obj;
        }
        //按报销日期查找个人报销记录
        public static PersonReimbursement GetPersonReimbursement(string empNo, string item, int year, int month)
        {
            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                       new BinaryOperator("员工编号", empNo, BinaryOperatorType.Equal),
                       new BinaryOperator("项目", item, BinaryOperatorType.Equal),
                       new BinaryOperator("年", year, BinaryOperatorType.Equal),
                       new BinaryOperator("月", month, BinaryOperatorType.Equal)
                       );

            XPCollection objset = new XPCollection(MyHelper.XpoSession, typeof(PersonReimbursement), criteria, new SortProperty("录入时间", SortingDirection.Descending));

            if (objset.Count > 0)
            {
                return (PersonReimbursement)objset[0];
            }
            else
                return null;
        }
        //按个人报销记录
        public static PersonReimbursement GetEffective(string empNo, string item, int year, int month)
        {
            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                       new BinaryOperator("员工编号", empNo, BinaryOperatorType.Equal),
                       new BinaryOperator("项目", item, BinaryOperatorType.Equal),
                       new BinaryOperator("年", year, BinaryOperatorType.Equal),
                       new BinaryOperator("月", month, BinaryOperatorType.Equal)
                       );

            XPCollection objset = new XPCollection(MyHelper.XpoSession, typeof(PersonReimbursement), criteria, new SortProperty("录入时间", SortingDirection.Descending));

            if (objset.Count > 0)
            {
                return (PersonReimbursement)objset[0];
            }
            else
                return null;
        }

        #endregion

        #region GetPersonReimbursements

        public static List<PersonReimbursement> GetPersonReimbursements(string empLid, int year, int month)
        {            
            List<PersonReimbursement> list = new List<PersonReimbursement>();

            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                       new BinaryOperator("员工编号", empLid, BinaryOperatorType.Equal),
                       new BinaryOperator("年", year, BinaryOperatorType.Equal),
                       new BinaryOperator("月", month, BinaryOperatorType.Equal)
                       );

            XPCollection objset = new XPCollection(MyHelper.XpoSession, typeof(PersonReimbursement), criteria, new SortProperty("录入时间", SortingDirection.Ascending));

            foreach (PersonReimbursement order in objset)
            {
                list.Add(order);
            }
            return list;
        }
        #endregion

        #region AddPersonReimbursement

        public static PersonReimbursement AddPersonReimbursement(string empNo, string itemName, int year, int month)
        {
            PersonReimbursement item = GetPersonReimbursement(empNo, itemName, year, month);
            if (item == null)
            {
                item = new PersonReimbursement();
                item.标识 = Guid.NewGuid();
                item.员工编号 = empNo;
                item.项目 = itemName;
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

        public static List<PersonReimbursement> GetAll(int year, int month)
        {
            List<PersonReimbursement> list = new List<PersonReimbursement>();

            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                       new BinaryOperator("年", year, BinaryOperatorType.Equal),
                       new BinaryOperator("月", month, BinaryOperatorType.Equal)
                       );

            XPCollection objset = new XPCollection(MyHelper.XpoSession, typeof(PersonReimbursement), criteria, new SortProperty("项目", SortingDirection.Ascending), new SortProperty("录入时间", SortingDirection.Ascending));

            foreach (PersonReimbursement order in objset)
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

        #region 报销标准

        ReimbursementStandard standard = null;
        public ReimbursementStandard 报销标准
        {
            get
            {
                if (standard == null) standard = ReimbursementStandard.GetEffective(this.员工编号, this.项目, new DateTime(this.年, this.月, 1));
                return standard;
            }
        }
        #endregion

        #region 剩余

        public decimal 剩余
        {
            get
            {
                if (this.报销标准 == null)
                    return 0;
                else
                    return this.报销标准.报销金额 - this.报销金额;
            }
        }
        #endregion
    }
}