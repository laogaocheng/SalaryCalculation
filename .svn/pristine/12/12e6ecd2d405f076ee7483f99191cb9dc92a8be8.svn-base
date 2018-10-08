using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using DevExpress.Xpo.DB;
using log4net;
using Hwagain.Components;
using System.Data.SqlClient;

namespace Hwagain.SalaryCalculation.Components
{
    public partial class MonthlySalaryHistory
    {
        //说明：期号 统一调整用 年份 + 一个数字（20171），单独调整用年份 + 两位数字（201711）
        static readonly ILog log = LogManager.GetLogger(typeof(MonthlySalaryHistory));
        
        #region GetMonthlySalaryHistory

        public static MonthlySalaryHistory GetMonthlySalaryHistory(Guid id)
        {
            MonthlySalaryHistory obj = (MonthlySalaryHistory)Session.DefaultSession.GetObjectByKey(typeof(MonthlySalaryHistory), id);
            return obj;
        }

        public static MonthlySalaryHistory GetMonthlySalaryHistory(string emplid, int period)
        {
            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                       new BinaryOperator("员工编号", emplid, BinaryOperatorType.Equal),
                       new BinaryOperator("期号", period, BinaryOperatorType.Equal));

            XPCollection objset = new XPCollection(typeof(MonthlySalaryHistory), criteria, new SortProperty("开始执行日期", SortingDirection.Ascending));

            if (objset.Count > 0)
            {
                return (MonthlySalaryHistory)objset[0];
            }
            else
                return null;
        }

        #endregion
        
        #region GetMonthlySalaryHistorys

        public static List<MonthlySalaryHistory> GetMonthlySalaryHistorys(string salaryPlan, int period)
        {
            List<MonthlySalaryHistory> list = new List<MonthlySalaryHistory>();

            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                       new BinaryOperator("薪酬体系", salaryPlan, BinaryOperatorType.Equal),
                       new BinaryOperator("期号", period, BinaryOperatorType.Equal));

            XPCollection objset = new XPCollection(typeof(MonthlySalaryHistory), criteria, new SortProperty("月薪", SortingDirection.Ascending));

            foreach (MonthlySalaryHistory grade in objset)
            {
                list.Add(grade);                
            }
            return list;
        }
        #endregion

        #region AddMonthlySalaryHistory

        public static MonthlySalaryHistory AddMonthlySalaryHistory(string emplid, int period)
        {
            MonthlySalaryHistory item = GetMonthlySalaryHistory(emplid, period);
            if (item == null)
            {
                item = new MonthlySalaryHistory();
                item.标识 = Guid.NewGuid();
                item.员工编号 = emplid;
                item.期号 = period;

                item.Save();
            }
            return item;
        }
        #endregion
    }
}
