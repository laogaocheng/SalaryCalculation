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
    public partial class EmpPayRate
    {
        static readonly ILog log = LogManager.GetLogger(typeof(EmpPayRate));

        #region GetEmpPayRate
        /// <summary>
        /// 通过 Id 获取线路
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static EmpPayRate GetEmpPayRate(int id)
        {
            EmpPayRate obj = (EmpPayRate)Session.DefaultSession.GetObjectByKey(typeof(EmpPayRate), id);
            return obj;
        }

        public static EmpPayRate GetEmpPayRate(string empNo, int year, int month)
        {
            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                       new BinaryOperator("员工编号", empNo, BinaryOperatorType.Equal),
                       new BinaryOperator("年", year, BinaryOperatorType.Equal),
                       new BinaryOperator("月", month, BinaryOperatorType.Equal));

            XPCollection objset = new XPCollection(typeof(EmpPayRate), criteria, new SortProperty("录入时间", SortingDirection.Ascending));

            if (objset.Count > 0)
            {
                return (EmpPayRate)objset[0];
            }
            else
                return null;
        }

        #endregion

        #region GetEmpPayRateList

        //获取工资系数列表
        public static List<EmpPayRate> GetEmpPayRateList(int year, int month)
        {
            List<EmpPayRate> list = new List<EmpPayRate>();

            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                       new BinaryOperator("年", year, BinaryOperatorType.Equal),
                       new BinaryOperator("月", month, BinaryOperatorType.Equal));

            XPCollection objset = null;

            objset = new XPCollection(typeof(EmpPayRate), criteria, new SortProperty("录入时间", SortingDirection.Ascending));

            foreach (EmpPayRate item in objset)
            {
                list.Add(item);
            }
            return list;
        }
        #endregion

        #region OnSaving

        protected override void OnSaving()
        {
            if (string.IsNullOrEmpty(this.姓名)) throw new Exception("姓名不能为空.");
            if (this.录入时间 == DateTime.MinValue) this.录入时间 = DateTime.Now;
            //判断已经审核的薪资组不能修改
            SalaryResult salResult = SalaryResult.GetFromCache(this.员工编号, this.年, this.月);
            if (salResult == null)
                throw new Exception("未发现" + this.姓名 + "的工资记录.");
            else
            {
                SalaryAuditingResult auditingResult = SalaryAuditingResult.GetSalaryAuditingResult(salResult.薪资组, this.年, this.月);
                if(auditingResult == null)
                    throw new Exception("未发现" + this.姓名 + "的工资审核情况表");
                else
                {
                    if (auditingResult.已审核) throw new Exception( this.姓名 + "的工资已经审核，不能添加或修改。");
                }
            }

            EmpPayRate found = GetEmpPayRate(this.员工编号, this.年, this.月);
            if (found != null && found.标识 != this.标识)
                throw new Exception("每个员工每月只有一个工资系数.");
            else
                base.OnSaving();
        }
        #endregion

        #region AddEmpPayRate

        public static EmpPayRate AddEmpPayRate(string empNo, string name, int year, int month)
        {
            EmpPayRate item = GetEmpPayRate(empNo, year, month);
            if (item == null)
            {
                item = new EmpPayRate();

                item.标识 = Guid.NewGuid();
                item.员工编号 = empNo;
                item.姓名 = name;
                item.年 = year;
                item.月 = month;

                item.Save();
            }
            return item;
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
