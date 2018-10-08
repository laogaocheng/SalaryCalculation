using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;

namespace Hwagain.SalaryCalculation.Components
{
    /// <summary>
    /// 工资计算结果
    /// </summary>
    public class SalResultItem
    {
        public string 日历组 { get; set; }
        public string 日历 { get; set; }
        public string 薪资组 { get; set; }
        public int 年度 { get; set; }
        public int 月份 { get; set; }
        public string 员工编号 { get; set; }
        public decimal 元素编号 { get; set; }
        public string 英文名称 { get; set; }
        public string 中文名称 { get; set; }
        public decimal 金额 { get; set; }

        #region GetList

        //获取所有工资项
        public static List<SalResultItem> GetList(string calRunId, string payGroup)
        {
            List<SalResultItem> list = new List<SalResultItem>();
            
            CalRunInfo calRun = CalRunInfo.Get(calRunId);
            if (calRun == null) return list;

            OleDbConnection conn = new OleDbConnection(MyHelper.GetPsConnectionString());
            using (conn)
            {
                OleDbDataReader rs = null;
                try
                {
                    conn.Open();
                    using (OleDbCommand cmd = conn.CreateCommand())
                    {
                        string condition = "";
                        if (string.IsNullOrEmpty(payGroup) == false) condition = " AND gp_paygroup='" + payGroup + "'";
            
                        cmd.CommandText = String.Format("SELECT A.EMPLID, A.cal_run_id,a.gp_paygroup, cal_id, A.PIN_NUM, P.PIN_NM, P.DESCR, A.CALC_RSLT_VAL FROM SYSADM.PS_GP_RSLT_ERN_DED A LEFT JOIN SYSADM.PS_GP_PIN P ON A.PIN_NUM = P.PIN_NUM WHERE A.cal_run_id = '{0}' {1} ORDER BY A.EMPLID", calRunId,  condition);
                        rs = cmd.ExecuteReader();
                        while (rs.Read())
                        {
                            SalResultItem item = new SalResultItem();

                            item.年度 = calRun.年度;
                            item.月份 = calRun.月份;
                            item.日历组 = (string)rs["cal_run_id"];
                            item.日历 = (string)rs["cal_id"];
                            item.薪资组 = ((string)rs["gp_paygroup"]).Trim();
                            item.员工编号 = (string)rs["EMPLID"];
                            item.元素编号 = Convert.ToDecimal(rs["PIN_NUM"]);
                            item.英文名称 = (string)rs["PIN_NM"];
                            item.中文名称 = (string)rs["DESCR"];
                            item.金额 = Convert.ToDecimal(rs["CALC_RSLT_VAL"]);

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
    }
}
