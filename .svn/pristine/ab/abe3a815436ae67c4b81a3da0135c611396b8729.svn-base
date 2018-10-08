using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;

namespace Hwagain.SalaryCalculation.Components
{
    /// <summary>
    /// 获取薪酬体系
    /// </summary>
    public class SalPlan
    {
        public string 集合 { get; set; }
        public string 中文名 { get; set; }
        public string 英文名 { get; set; }
        public string 状态 { get; set; }

        static List<SalPlan> salPlanList = null;

        public static List<SalPlan> 薪酬体系
        {
            get
            {
                if (salPlanList == null) salPlanList = GetAll();
                return salPlanList;
            }
        }
       
        #region GetAll

        //获取值列表
        public static List<SalPlan> GetAll()
        {
            List<SalPlan> list = new List<SalPlan>();
            OleDbConnection conn = new OleDbConnection(MyHelper.GetPsConnectionString());
            using (conn)
            {
                OleDbDataReader rs = null;
                try
                {
                    conn.Open();
                    using (OleDbCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "select setid, sal_admin_plan, descr, effdt, eff_status from SYSADM.PS_SAL_PLAN_TBL order by setid, sal_admin_plan";
                        rs = cmd.ExecuteReader();
                        while (rs.Read())
                        {
                            SalPlan salPlan = new SalPlan();
                            salPlan.集合 = (string)rs["setid"];
                            salPlan.英文名 = (string)rs["sal_admin_plan"];
                            salPlan.中文名 = (string)rs["descr"];
                            salPlan.状态 = ((string)rs["eff_status"]).Trim();
                            list.Add(salPlan);
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
