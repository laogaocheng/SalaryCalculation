using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;

namespace Hwagain.SalaryCalculation.Components
{
    /// <summary>
    /// 日历组信息
    /// </summary>
    public class CalRunInfo
    {
        public string 日历组编号 { get; set; }
        public string 日历组名称 { get; set; }
        public int 年度 { get; set; }
        public int 月份 { get; set; }
        public string 期间 { get; set; }
        public DateTime 开始日期 { get; set; }
        public DateTime 结束日期 { get; set; }

        public List<string> 薪资组列表
        {
            get
            {
                return GetPayGroupList();
            }
        }

        public bool 已完成 { get; set; }

        #region Get

        //获取指定的日历组
        public static CalRunInfo Get(string cal_run_id)
        {
            List<CalRunInfo> list = new List<CalRunInfo>();
            OleDbConnection conn = new OleDbConnection(MyHelper.GetPsConnectionString());
            using (conn)
            {
                OleDbDataReader rs = null;
                try
                {
                    conn.Open();
                    using (OleDbCommand cmd = conn.CreateCommand())
                    {
                        string sql = String.Format("SELECT DISTINCT A.CAL_RUN_ID,A.DESCR, RUN_FINALIZED_IND, B.CAL_PRD_ID, C.PRD_BGN_DT, C.PRD_END_DT FROM SYSADM.PS_GP_CAL_RUN A LEFT JOIN SYSADM.PS_GP_CAL_RUN_DTL B ON A.CAL_RUN_ID = B.CAL_RUN_ID  LEFT JOIN SYSADM.PS_GP_CAL_PRD C ON C.CAL_PRD_ID = B.CAL_PRD_ID WHERE A.CAL_RUN_ID='{0}'", cal_run_id);
                        cmd.CommandText = sql;
                        rs = cmd.ExecuteReader();
                        if (rs.Read())
                        {
                            CalRunInfo item = new CalRunInfo();

                            item.日历组编号 = (string)rs["CAL_RUN_ID"];
                            item.日历组名称 = (string)rs["DESCR"];
                            item.期间 = (string)rs["CAL_PRD_ID"];
                            item.开始日期 = Convert.ToDateTime(rs["PRD_BGN_DT"]);
                            item.结束日期 = Convert.ToDateTime(rs["PRD_END_DT"]);

                            item.年度 = item.开始日期.Year;
                            item.月份 = item.开始日期.Month;

                            return item;
                        }
                    }
                }
                finally
                {
                    if (rs != null) rs.Close();
                    conn.Close();
                }
            }
            return null;
        }
        #endregion

        #region GetList

        //获取指定年份的日历组
        public static List<CalRunInfo> GetList(DateTime start, DateTime end)
        {            
            List<CalRunInfo> list = new List<CalRunInfo>();
            OleDbConnection conn = new OleDbConnection(MyHelper.GetPsConnectionString());
            using (conn)
            {
                OleDbDataReader rs = null;
                try
                {
                    conn.Open();
                    using (OleDbCommand cmd = conn.CreateCommand())
                    {
                        string sql = String.Format("SELECT DISTINCT A.CAL_RUN_ID,A.DESCR, RUN_FINALIZED_IND, B.CAL_PRD_ID, C.PRD_BGN_DT, C.PRD_END_DT FROM SYSADM.PS_GP_CAL_RUN A LEFT JOIN SYSADM.PS_GP_CAL_RUN_DTL B ON A.CAL_RUN_ID = B.CAL_RUN_ID  LEFT JOIN SYSADM.PS_GP_CAL_PRD C ON C.CAL_PRD_ID = B.CAL_PRD_ID WHERE C.PRD_BGN_DT >= date'{0:yyyy-M-d}' AND C.PRD_END_DT < date'{1:yyyy-M-d}' order by C.PRD_BGN_DT desc", start, end);
                        cmd.CommandText = sql;
                        rs = cmd.ExecuteReader();
                        while (rs.Read())
                        {
                            CalRunInfo item = new CalRunInfo();

                            item.日历组编号 = (string)rs["CAL_RUN_ID"];
                            item.日历组名称 = (string)rs["DESCR"];
                            item.期间 = (string)rs["CAL_PRD_ID"];
                            item.开始日期 = Convert.ToDateTime(rs["PRD_BGN_DT"]);
                            item.结束日期 = Convert.ToDateTime(rs["PRD_END_DT"]);

                            item.年度 = item.开始日期.Year;
                            item.月份 = item.开始日期.Month;
                            
                            list.Add(item);
                        }
                    }
                }
                finally
                {
                    if (rs != null) rs.Close();
                    conn.Close();
                }
            }
            return list;
        }
        #endregion

        #region GetPayGroupList

        //获取日历组下的薪资组
        List<string> GetPayGroupList()
        {
            List<string> list = new List<string>();
            OleDbConnection conn = new OleDbConnection(MyHelper.GetPsConnectionString());
            using (conn)
            {
                OleDbDataReader rs = null;
                try
                {
                    conn.Open();
                    using (OleDbCommand cmd = conn.CreateCommand())
                    {
                        string sql = "select gp_paygroup from SYSADM.PS_GP_CAL_RUN_DTL where cal_run_id='" + this.日历组编号 + "'";
                        cmd.CommandText = sql;
                        rs = cmd.ExecuteReader();
                        while (rs.Read())
                        {
                            string paygroup = (string)rs["gp_paygroup"];
                            list.Add(paygroup);
                        }
                    }
                }
                finally
                {
                    if (rs != null) rs.Close();
                    conn.Close();
                }
            }
            return list;
        }
        #endregion
    }
}
