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
    public partial class EmpSalaryStep
    {
        static readonly ILog log = LogManager.GetLogger(typeof(EmpSalaryStep));

        #region GetEmpSalaryStep
        /// <summary>
        /// 通过 Id 获取线路
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static EmpSalaryStep GetEmpSalaryStep(Guid id)
        {
            EmpSalaryStep obj = (EmpSalaryStep)Session.DefaultSession.GetObjectByKey(typeof(EmpSalaryStep), id);
            return obj;
        }

        public static EmpSalaryStep GetEmpSalaryStep(string empNo, DateTime effDate)
        {
            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                       new BinaryOperator("员工编号", empNo, BinaryOperatorType.Equal),
                       new BinaryOperator("执行日期", effDate, BinaryOperatorType.Equal));

            XPCollection objset = new XPCollection(typeof(EmpSalaryStep), criteria, new SortProperty("执行日期", SortingDirection.Ascending));

            if (objset.Count > 0)
            {
                return (EmpSalaryStep)objset[0];
            }
            else
                return null;
        }

        #endregion

        #region OnSaving

        protected override void OnSaving()
        {
            if (string.IsNullOrEmpty(this.姓名)) throw new Exception("姓名不能为空.");
            if (this.录入时间 == DateTime.MinValue) this.录入时间 = DateTime.Now;

            EmpSalaryStep found = GetEmpSalaryStep(this.员工编号, this.执行日期);
            if (found != null && found.标识 != this.标识)
                throw new Exception("同一员工同一日期只能存在一条记录，不能重复.");
            else
                base.OnSaving();
        }
        #endregion

        #region AddEmpSalaryStep

        public static EmpSalaryStep AddEmpSalaryStep(string empNo, string name, DateTime effDate)
        {
            EmpSalaryStep item = GetEmpSalaryStep(empNo, effDate);
            if (item == null)
            {
                item = new EmpSalaryStep();

                item.标识 = Guid.NewGuid();
                item.员工编号 = empNo;
                item.姓名 = name;
                item.执行日期 = effDate;
                item.Save();
            }
            return item;
        }
        #endregion

        #region GetEffective

        public static EmpSalaryStep GetEffective(string empNo, DateTime date)
        {
            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                       new BinaryOperator("员工编号", empNo, BinaryOperatorType.Equal),
                       new BinaryOperator("执行日期", date, BinaryOperatorType.LessOrEqual)
                       );

            XPCollection objset = new XPCollection(MyHelper.XpoSession, typeof(EmpSalaryStep), criteria, new SortProperty("执行日期", SortingDirection.Descending));

            if (objset.Count > 0)
            {
                EmpSalaryStep item = (EmpSalaryStep)objset[0];
                if (item.截止日期 == DateTime.MinValue || item.截止日期 >= date)
                    return item;
                else
                    return null;
            }
            else
                return null;
        }
        #endregion

        #region GetAll

        public static List<EmpSalaryStep> GetAll(string empNo)
        {
            List<EmpSalaryStep> list = new List<EmpSalaryStep>();

            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                       new BinaryOperator("员工编号", empNo, BinaryOperatorType.Equal)
                       );

            XPCollection objset = new XPCollection(MyHelper.XpoSession, typeof(EmpSalaryStep), criteria, new SortProperty("执行日期", SortingDirection.Descending));

            foreach (EmpSalaryStep order in objset)
            {
                list.Add(order);
            }
            return list;
        }

        public static List<EmpSalaryStep> GetAll()
        {
            List<EmpSalaryStep> list = new List<EmpSalaryStep>();

            XPCollection objset = new XPCollection(MyHelper.XpoSession, typeof(EmpSalaryStep), null, new SortProperty("姓名", SortingDirection.Ascending));

            foreach (EmpSalaryStep order in objset)
            {
                list.Add(order);
            }
            return list;
        }

        #endregion

        #region GetLatest

        public static EmpSalaryStep GetLatest(string empNo)
        {
            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                       new BinaryOperator("员工编号", empNo, BinaryOperatorType.Equal)
                       );

            XPCollection objset = new XPCollection(MyHelper.XpoSession, typeof(EmpSalaryStep), criteria, new SortProperty("执行日期", SortingDirection.Descending));

            if (objset.Count > 0)
            {
                return (EmpSalaryStep)objset[0];
            }
            else
                return null;
        }
        #endregion

        #region 薪级名称
        [NonPersistent]
        string stepName = null;
        [WatchMember]
        public string 薪级名称
        {
            get
            {
                if (stepName == null)
                {
                    stepName = SalaryNode.GetName(this.薪级标识);
                }
                return stepName;
            }
        }
        #endregion

        #region 薪资组名称

        public string 薪资组名称
        {
            get
            {
                PayGroup group = PayGroup.Get(this.薪资组);
                if (group != null)
                    return group.中文名;
                else
                    return "";

            }
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
    }
}
