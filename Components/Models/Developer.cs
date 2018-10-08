using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data;
using System.Data.SqlClient;

namespace Hwagain.SalaryCalculation.Components
{
    /// <summary>
    /// 开发人员
    /// </summary>
    public class Developer
    {
        public List<string> 开发人员名单
        {
            get
            {
                return GetDeveloperList();
            }
        }

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

        #region GetDeveloperList

        //获取开发人员名单
        public static List<string> GetDeveloperList()
        {
            List<string> list = new List<string>();
            SqlConnection conn = new SqlConnection(MyHelper.GetConnectionString());
            using (conn)
            {
                IDataReader rs = null;
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "SELECT 姓名 FROM 软件开发人员 ORDER BY ID";
                        rs = cmd.ExecuteReader();
                        while (rs.Read())
                        {
                            string name = (string)rs["姓名"];
                            list.Add(name);
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

        #region SetDeveloperList
        public static void SetDeveloperList(string developers)
        {
            Clear();
            string[] arr_developers = developers.Split(new char[] { ',', '，', '|', '、', '\t', ' ', '　' });
            for(int i=0; i < arr_developers.Length; i++)
            {
                Add(arr_developers[i]);
            }
        }
        #endregion

        #region Clear

        //清空
        static void Clear()
        {
            string sql = "DELETE FROM 软件开发人员";
            using (SqlConnection connection = new SqlConnection(MyHelper.GetConnectionString()))
            {
                YiKang.Data.SqlHelper.ExecuteNonQuery(connection, System.Data.CommandType.Text, sql);

            }
        }
        #endregion

        #region Add
        //新增
        static void Add(string name)
        {
            if (string.IsNullOrEmpty(name)) return;

            try
            {
                string sql = "INSERT INTO 软件开发人员 VALUES('" + name + "')";
                using (SqlConnection connection = new SqlConnection(MyHelper.GetConnectionString()))
                {
                    YiKang.Data.SqlHelper.ExecuteNonQuery(connection, System.Data.CommandType.Text, sql);
                }
            }
            catch { }
        }
        #endregion
    }
}
