using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;

namespace Hwagain.SalaryCalculation.Components
{
    /// <summary>
    /// 获取薪等
    /// </summary>
    public class SalStep
    {
        public string 集合 { get; set; }
        public string 薪酬体系 { get; set; }
        public string 薪等编号 { get; set; }
        public int 薪级编号 { get; set; }
        public string 薪级名称 { get; set; }
        public DateTime 生效日期 { get; set; }

        #region GetAll

        //获取值列表
        public static List<SalStep> GetAll()
        {
            List<SalStep> list = new List<SalStep>();
            OleDbConnection conn = new OleDbConnection(MyHelper.GetPsConnectionString());
            using (conn)
            {
                OleDbDataReader rs = null;
                try
                {
                    conn.Open();
                    using (OleDbCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "select SETID, SAL_ADMIN_PLAN, GRADE, EFFDT, STEP, STEP_DESCR from SYSADM.ps_SAL_STEP_TBL";
                        rs = cmd.ExecuteReader();
                        while (rs.Read())
                        {
                            SalStep salStep = new SalStep();

                            salStep.集合 = (string)rs["setid"];
                            salStep.薪酬体系 = (string)rs["sal_admin_plan"];
                            salStep.薪等编号 = (string)rs["grade"];
                            salStep.生效日期 = Convert.ToDateTime(rs["effdt"]);
                            salStep.薪级编号 = Convert.ToInt32(rs["STEP"]);
                            salStep.薪级名称 = ((string)rs["STEP_DESCR"]).Trim();

                            list.Add(salStep);
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
