using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using log4net;
using DevExpress.Data.Filtering;
using System.Data.SqlClient;
using Hwagain;
using YiKang;
using System.Data.OleDb;

namespace Hwagain.SalaryCalculation.Components
{
    public partial class SalaryResultItem
    {
        static readonly ILog log = LogManager.GetLogger(typeof(SalaryResultItem));

        #region GetSalaryResultItem
        /// <summary>
        /// 通过 Id 获取
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static SalaryResultItem GetSalaryResultItem(Guid id)
        {
            SalaryResultItem obj = (SalaryResultItem)MyHelper.XpoSession.GetObjectByKey(typeof(SalaryResultItem), id);
            return obj;
        }
        #endregion

        #region GetSalaryResultItem

        public static SalaryResultItem GetSalaryResultItem(string emplid, int year, int month, string elementName)
        {
            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                       new BinaryOperator("员工编号", emplid, BinaryOperatorType.Equal),
                       new BinaryOperator("年度", year, BinaryOperatorType.Equal),
                       new BinaryOperator("月份", month, BinaryOperatorType.Equal),
                       new BinaryOperator("英文名称", elementName, BinaryOperatorType.Equal)
                       );

            XPCollection objset = new XPCollection(MyHelper.XpoSession, typeof(SalaryResultItem), criteria, new SortProperty("元素编号", SortingDirection.Ascending));

            if (objset.Count > 0)
            {
                return (SalaryResultItem)objset[0];
            }
            else
                return null;
        }
        #endregion

        #region GetSalaryResultItems

        public static List<SalaryResultItem> GetSalaryResultItems(string emplid, string calRunId)
        {
            List<SalaryResultItem> list = new List<SalaryResultItem>();

            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                       new BinaryOperator("员工编号", emplid, BinaryOperatorType.Equal),
                       new BinaryOperator("日历组", calRunId, BinaryOperatorType.Equal)
                       );

            XPCollection objset = new XPCollection(MyHelper.XpoSession, typeof(SalaryResultItem), criteria, new SortProperty("元素编号", SortingDirection.Ascending));

            foreach (SalaryResultItem order in objset)
            {
                list.Add(order);
            }
            return list;
        }

        public static List<SalaryResultItem> GetSalaryResultItems(string emplid, int year, int month)
        {
            List<SalaryResultItem> list = new List<SalaryResultItem>();

            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                       new BinaryOperator("员工编号", emplid, BinaryOperatorType.Equal),
                       new BinaryOperator("年度", year, BinaryOperatorType.Equal),
                       new BinaryOperator("月份", month, BinaryOperatorType.Equal)
                       );

            XPCollection objset = new XPCollection(MyHelper.XpoSession, typeof(SalaryResultItem), criteria, new SortProperty("元素编号", SortingDirection.Ascending));

            foreach (SalaryResultItem order in objset)
            {
                list.Add(order);
            }
            return list;
        }
        #endregion

        #region OnLoaded

        protected override void OnLoaded()
        {
            base.OnLoaded();
        }

        #endregion

        #region DeleteAll

        //删除指定日历组的工资明细
        static bool DeleteAll(string calRunId, string payGroup)
        {
            try
            {
                string condition = "";
                if (string.IsNullOrEmpty(payGroup) == false) condition = String.Format(" AND 薪资组='{0}'", payGroup);
                string sql = String.Format("DELETE FROM 工资明细 WHERE 日历组='{0}' {1}", calRunId, condition);
                using (SqlConnection connection = new SqlConnection(MyHelper.GetConnectionString()))
                {
                    YiKang.Data.SqlHelper.ExecuteNonQuery(connection, System.Data.CommandType.Text, sql);
                    connection.Close();
                }
                return true;
            }
            catch(Exception err)
            {
                Common.WriteLog(Environment.CurrentDirectory + "\\LogFiles\\Error.log", err.ToString());
                return false;
            }
        }
        #endregion

        #region GetCategory

        private string GetCategory()
        {
            OleDbConnection conn = new OleDbConnection(MyHelper.GetPsConnectionString());
            using (conn)
            {
                OleDbDataReader rs = null;
                try
                {
                    conn.Open();
                    using (OleDbCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = String.Format("select DESCR from SYSADM.ps_GP_ACM_MBR A left join SYSADM.PS_GP_PIN B ON A.PIN_NUM = B.PIN_NUM where A.PIN_MBR_NUM='{0}'", this.元素编号);
                        rs = cmd.ExecuteReader();
                        if (rs.Read())
                        {
                            return (string)rs["DESCR"];
                        }
                    }
                }
                finally
                {
                    if (rs != null) rs.Close();
                    conn.Close();
                }
                return " 未分类";
            }
        }

        #endregion

        #region SychSalaryResultItem
                

        public static StringBuilder SychSalaryResultItem(string calRunId, string payGroup)
        {
            StringBuilder sb = new StringBuilder();
            
            CalRunInfo calRun = CalRunInfo.Get(calRunId);
            if (calRun == null) return sb;

            if (DeleteAll(calRunId, payGroup))
            {
                List<SalResultItem> list = SalResultItem.GetList(calRunId, payGroup);
                foreach (SalResultItem sri in list)
                {
                    try
                    {
                        SalaryResultItem item = new SalaryResultItem();

                        item.年度 = calRun.年度;
                        item.月份 = calRun.月份;
                        item.日历组 = sri.日历组;
                        item.日历 = sri.日历;
                        item.薪资组 = sri.薪资组;
                        item.员工编号 = sri.员工编号;
                        item.元素编号 = sri.元素编号;
                        item.英文名称 = sri.英文名称;
                        item.中文名称 = sri.中文名称;
                        item.金额 = sri.金额;
                        item.类别 = item.GetCategory();
                        item.上次同步时间 = DateTime.Now;

                        item.Save();
                    }
                    catch
                    {
                        sb.Append("同步工资明细失败:" + sri);
                    }
                }
            }
            else
            {
                sb.Append("删除上次同步的数据失败");
            }
            return sb;
        }
        #endregion

    }
}