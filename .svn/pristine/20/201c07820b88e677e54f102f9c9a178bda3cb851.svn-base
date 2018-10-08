using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using DevExpress.Xpo.DB;
using log4net;
using System.Data.SqlClient;

namespace Hwagain.SalaryCalculation.Components
{
    public partial class PayCheckRecord
    {
        static readonly ILog log = LogManager.GetLogger(typeof(PayCheckRecord));

        #region GetPayCheckRecord
        /// <summary>
        /// 通过 Id 获取线路
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static PayCheckRecord GetPayCheckRecord(Guid id)
        {
            PayCheckRecord obj = (PayCheckRecord)MyHelper.XpoSession.GetObjectByKey(typeof(PayCheckRecord), id);
            return obj;
        }        

        #endregion

        #region GetPayCheckRecordList

        //获取指定薪资组的抽查记录
        public static List<PayCheckRecord> GetPayCheckRecordList(string payGroup, string calRunId)
        {
            List<PayCheckRecord> list = new List<PayCheckRecord>();

            GroupOperator criteria = new GroupOperator(GroupOperatorType.And);
            if (payGroup != null) criteria.Operands.Add(new BinaryOperator("薪资组", payGroup, BinaryOperatorType.Equal));
            if (calRunId != null) criteria.Operands.Add(new BinaryOperator("日历组", calRunId, BinaryOperatorType.Equal));

            XPCollection objset = null;

            objset = new XPCollection(MyHelper.XpoSession, typeof(PayCheckRecord), criteria, new SortProperty("抽取时间", SortingDirection.Ascending));

            foreach (PayCheckRecord item in objset)
            {
                list.Add(item);
            }
            return list;
        }
        #endregion

        #region OnSaving

        protected override void OnSaving()
        {
            base.OnSaving();
        }
        #endregion

        #region ClearPayCheckRecord

        //删除
        public static void ClearPayCheckRecord(string calRunId, string payGroup)
        {
            string condition = "";
            if (string.IsNullOrEmpty(payGroup) == false) condition = String.Format(" AND 薪资组='{0}'", payGroup);

            string sql = String.Format("DELETE FROM 工资抽查记录 WHERE 日历组 = '{0}' {1}", calRunId, condition);

            using (SqlConnection connection = new SqlConnection(MyHelper.GetConnectionString()))
            {
                YiKang.Data.SqlHelper.ExecuteNonQuery(connection, System.Data.CommandType.Text, sql);
            }
        }
        #endregion

        #region AddPayCheckRecord

        public static PayCheckRecord AddPayCheckRecord(Guid payId)
        {
            PayCheckRecord item = GetPayCheckRecord(payId);
            if (item == null)
            {
                item = new PayCheckRecord();

                item.标识 = payId;  
                item.Save();
            }
            return item;
        }
        #endregion

        #region DoAuditing
        //审核
        public void DoAuditing(string auditor)
        {
            this.审核人 = auditor;
            this.审核确认时间 = DateTime.Now;
            this.Save();
        }
        #endregion

        #region UndoAuditing
        //反审
        public void UndoAuditing()
        {
            this.审核人 = "";
            this.审核确认时间 = DateTime.MinValue;
            this.Save();
        }
        #endregion

        #region 工资记录

        PrivateSalary pSalary = null;
        public PrivateSalary 工资记录
        {
            get
            {
                if (pSalary == null) pSalary = PrivateSalary.GetPrivateSalary(this.标识);
                return pSalary;
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
    }
}
