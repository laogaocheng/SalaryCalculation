using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;

namespace Hwagain.SalaryCalculation.Components
{
    public class KpiInfo
    {
        public string KPI_ID { get; set; }
        public string 名称 { get; set; }
        public string 公司 { get; set; }
        public string 字段1名称 { get; set; }
        public string 字段2名称 { get; set; }
        public string 字段3名称 { get; set; }
        public string 字段4名称 { get; set; }
        public string 字段5名称 { get; set; }
        public string 字段6名称 { get; set; }
        public string 字段7名称 { get; set; }
        public string 字段8名称 { get; set; }
        public string 字段9名称 { get; set; }
        public string 字段10名称 { get; set; }

        static List<KpiInfo> kpis = null;

        public static List<KpiInfo> 考核项目表
        {
            get
            {
                if (kpis == null) kpis = GetAll();
                return kpis;
            }
        }

        #region GetAll

        //获取值列表
        public static List<KpiInfo> GetAll()
        {
            List<KpiInfo> list = new List<KpiInfo>();
            OleDbConnection conn = new OleDbConnection(MyHelper.GetPsConnectionString());
            using (conn)
            {
                OleDbDataReader rs = null;
                try
                {
                    conn.Open();
                    using (OleDbCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "SELECT * FROM PS_C_GP_KPI_TBL  WHERE ENABLED='Y'";
                        rs = cmd.ExecuteReader();
                        while (rs.Read())
                        {
                            KpiInfo kpi = new KpiInfo();
                            kpi.KPI_ID = (string)rs["c_Gp_Kpi_Id"];
                            kpi.名称 = (string)rs["DESCR"];
                            kpi.公司 = (string)rs["c_Company_Short"];                            
                            kpi.字段1名称 = (string)rs["c_chr001"];
                            kpi.字段2名称 = (string)rs["c_chr002"];
                            kpi.字段3名称 = (string)rs["c_chr003"];
                            kpi.字段4名称 = (string)rs["c_chr004"];
                            kpi.字段5名称 = (string)rs["c_chr005"];
                            kpi.字段6名称 = (string)rs["c_chr006"];
                            kpi.字段7名称 = (string)rs["c_chr007"];
                            kpi.字段8名称 = (string)rs["c_chr008"];
                            kpi.字段9名称 = (string)rs["c_chr009"];
                            kpi.字段10名称 = (string)rs["c_chr010"];

                            list.Add(kpi);
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
