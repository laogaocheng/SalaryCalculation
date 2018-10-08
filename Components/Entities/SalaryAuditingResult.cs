using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using log4net;
using DevExpress.Data.Filtering;
using System.Data.SqlClient;

namespace Hwagain.SalaryCalculation.Components
{
    public partial class SalaryAuditingResult
    {
        static readonly ILog log = LogManager.GetLogger(typeof(SalaryAuditingResult));

        #region GetSalaryAuditingResult
        /// <summary>
        /// 通过 Id 获取
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static SalaryAuditingResult GetSalaryAuditingResult(Guid id)
        {
            SalaryAuditingResult obj = (SalaryAuditingResult)MyHelper.XpoSession.GetObjectByKey(typeof(SalaryAuditingResult), id);
            return obj;
        }

        public static SalaryAuditingResult GetSalaryAuditingResult(string payGroup, string calRunId)
        {
            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                       new BinaryOperator("日历组", calRunId, BinaryOperatorType.Equal),
                       new BinaryOperator("薪资组", payGroup, BinaryOperatorType.Equal)
                       );

            XPCollection objset = new XPCollection(MyHelper.XpoSession, typeof(SalaryAuditingResult), criteria, new SortProperty("薪资组", SortingDirection.Descending));

            if (objset.Count > 0)
            {
                return (SalaryAuditingResult)objset[0];
            }
            else
                return null;
        }

        public static SalaryAuditingResult GetSalaryAuditingResult(string payGroup, int year, int month)
        {
            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                       new BinaryOperator("年", year, BinaryOperatorType.Equal),
                       new BinaryOperator("月", month, BinaryOperatorType.Equal),
                       new BinaryOperator("薪资组", payGroup, BinaryOperatorType.Equal)
                       );

            XPCollection objset = new XPCollection(MyHelper.XpoSession, typeof(SalaryAuditingResult), criteria, new SortProperty("薪资组", SortingDirection.Descending));

            if (objset.Count > 0)
            {
                return (SalaryAuditingResult)objset[0];
            }
            else
                return null;
        }
        #endregion

        #region GetSalaryAuditingResultList

        public static List<SalaryAuditingResult> GetSalaryAuditingResultList(string calRunId)
        {
            List<SalaryAuditingResult> list = new List<SalaryAuditingResult>();

            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                       new BinaryOperator("日历组", calRunId, BinaryOperatorType.Equal)
                       );

            XPCollection objset = new XPCollection(MyHelper.XpoSession, typeof(SalaryAuditingResult), criteria, new SortProperty("薪资组", SortingDirection.Descending));

            foreach (SalaryAuditingResult item in objset)
            {
                list.Add(item);
            }

            return list;
        }
        #endregion

        #region AddSalaryAuditingResult

        public static SalaryAuditingResult AddSalaryAuditingResult(string payGroup, string calRunId)
        {
            SalaryAuditingResult result = GetSalaryAuditingResult(payGroup, calRunId);
            if (result == null)
            {
                CalRunInfo cal = CalRunInfo.Get(calRunId);
                result = new SalaryAuditingResult();
                
                result.标识 = Guid.NewGuid();
                result.薪资组 = payGroup;
                result.日历组 = calRunId;
                result.年 = cal.年度;
                result.月 = cal.月份;
                result.创建时间 = DateTime.Now;

                result.Save();
            }
            
            return result;
        }
        #endregion

        #region ClearAuditingResult

        //删除指定薪资组的审核审批情况表
        public static void ClearAuditingResult(string calRunId, string payGroup)
        {
            SalaryAuditingResult result = GetSalaryAuditingResult(payGroup, calRunId);
            if (result == null || result.已审核 || result.已冻结)
            {
                return;
            }

            string condition = "";
            if (string.IsNullOrEmpty(payGroup) == false) condition = String.Format(" AND 薪资组='{0}'", payGroup);
            string sql = String.Format("DELETE FROM 工资审核审批情况 WHERE 日历组 = '{0}' {1}", calRunId, condition);

            using (SqlConnection connection = new SqlConnection(MyHelper.GetConnectionString()))
            {
                YiKang.Data.SqlHelper.ExecuteNonQuery(connection, System.Data.CommandType.Text, sql);
            }
        }
        #endregion

        #region DoAuditingPublic
        //审核
        public void DoAuditingPublic(string auditor)
        {
            this.上表审核人 = auditor;
            this.上表审核时间 = DateTime.Now;
            this.Save();
        }
        #endregion

        #region UndoAuditingPublic
        //反审
        public void UndoAuditingPublic()
        {
            this.上表审核人 = "";
            this.上表审核时间 = DateTime.MinValue;
            this.Save();
        }
        #endregion

        #region DoAuditing
        //审核
        public void DoAuditing(string auditor)
        {
            this.审核人 = auditor;
            this.审核时间 = DateTime.Now;
            this.Save();
        }
        #endregion

        #region UndoAuditing
        //反审
        public void UndoAuditing()
        {
            this.审核人 = "";
            this.审核时间 = DateTime.MinValue;
            this.Save();
        }
        #endregion

        #region DoApproval
        //审批
        public void DoApproval(string auditor)
        {
            this.审批人 = auditor;
            this.审批时间 = DateTime.Now;
            this.Save();
        }
        #endregion

        #region UndoDoApproval
        //反审
        public void UndoDoApproval()
        {
            this.审批人 = "";
            this.审批时间 = DateTime.MinValue;
            this.Save();
        }
        #endregion

        #region Lock
        //锁定（冻结）
        public void Lock(string auditor)
        {
            this.冻结人 = auditor;
            this.冻结时间 = DateTime.Now;
            this.Save();
        }
        #endregion

        #region UnLock
        //解锁（解冻）
        public void UnLock()
        {
            this.冻结人 = "";
            this.冻结时间 = DateTime.MinValue;
            this.Save();
        }
        #endregion

        #region 上表工资已审核

        public bool 上表工资已审核
        {
            get
            {
                return string.IsNullOrEmpty(this.上表审核人) == false;
            }
        }
        #endregion      

        #region 已计算

        public bool 已计算
        {
            get
            {
                return 工资计算时间 != DateTime.MinValue;
            }
        }

        #endregion       

        #region 已审核

        public bool 已审核
        {
            get
            {
                return string.IsNullOrEmpty(this.审核人) == false;
            }
        }
        #endregion       

        #region 已审批

        public bool 已审批
        {
            get
            {
                return string.IsNullOrEmpty(this.审批人) == false;
            }
        }
        #endregion       

        #region 已冻结

        public bool 已冻结
        {
            get
            {
                return string.IsNullOrEmpty(this.冻结人) == false;
            }
        }
        #endregion       
    
        #region 所有抽查记录都已核实

        public bool 所有抽查记录都已核实
        {
            get
            {
                List<PayCheckRecord> items = PayCheckRecord.GetPayCheckRecordList(this.薪资组, this.日历组);
                foreach (PayCheckRecord item in items)
                {
                    if (item.已审核 == false) return false;
                }
                return true;
            }
        }
        #endregion

        #region 工资明细

        List<PrivateSalary> list = null;
        public List<PrivateSalary> 工资明细
        {
            get
            {
                if (list == null) list = PrivateSalary.GetPrivateSalarys(this.薪资组, this.日历组);
                return list;
            }
        }
        #endregion
    }
}