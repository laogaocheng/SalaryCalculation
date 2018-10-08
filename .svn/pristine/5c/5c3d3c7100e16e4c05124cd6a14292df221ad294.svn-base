using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;

namespace Hwagain.SalaryCalculation.Components
{
    //放弃年休假资料
    public class WaiveAnnualVacation
    {
        public string 员工编号 { get; set; }
        public int 年度 { get; set; }
        public int 月份 { get; set; }
        public decimal 放弃天数 { get; set; }

        #region GetAll

        //获取值列表
        public static List<WaiveAnnualVacation> GetAll(int year, int month)
        {
            List<WaiveAnnualVacation> list = new List<WaiveAnnualVacation>();
            OleDbConnection conn = new OleDbConnection(MyHelper.GetPsConnectionString());
            using (conn)
            {
                OleDbDataReader rs = null;
                try
                {
                    conn.Open();
                    using (OleDbCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "SELECT * FROM SYSADM.C_INF_WAIVEANNUALVACATION WHERE PERIOD_YEAR=" + year + " AND PERIOD_MONTH=" + month;
                        rs = cmd.ExecuteReader();
                        while (rs.Read())
                        {
                            WaiveAnnualVacation wav = new WaiveAnnualVacation();
                            wav.员工编号 = (string)rs["emplid"];
                            wav.年度 = Convert.ToInt32(rs["PERIOD_YEAR"]);
                            wav.月份 = Convert.ToInt32(rs["PERIOD_MONTH"]);
                            wav.放弃天数 = Convert.ToDecimal(rs["DAYS"]);
                            list.Add(wav);
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
