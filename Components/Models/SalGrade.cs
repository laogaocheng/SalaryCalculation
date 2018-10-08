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
    public class SalGrade
    {
        public string 集合 { get; set; }
        public string 薪酬体系 { get; set; }
        public string 薪等编号 { get; set; }
        public string 薪等名称 { get; set; }
        public DateTime 生效日期 { get; set; }
        public string 状态 { get; set; }

        public decimal 基准工资标准 { get; set; }
        public decimal 上表工资标准 { get; set; }
        public decimal 设定工资标准 { get; set; }
        public decimal 年休假工资 { get; set; }

        public decimal 养老保险缴纳基数 { get; set; }
        public decimal 医疗保险缴纳基数 { get; set; }
        public decimal 生育保险缴纳基数 { get; set; }
        public decimal 失业保险缴纳基数 { get; set; }
        public decimal 工伤保险缴纳基数 { get; set; }

        public decimal 公积金基数 { get; set; }

        static List<SalGrade> salPlanList = null;

        public static List<SalGrade> 薪酬等级表
        {
            get
            {
                if (salPlanList == null) salPlanList = GetAll();
                return salPlanList;
            }
        }
       
        #region GetAll

        //获取值列表
        public static List<SalGrade> GetAll()
        {
            List<SalGrade> list = new List<SalGrade>();
            OleDbConnection conn = new OleDbConnection(MyHelper.GetPsConnectionString());
            using (conn)
            {
                OleDbDataReader rs = null;
                try
                {
                    conn.Open();
                    using (OleDbCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "select setid, g.sal_admin_plan, g.grade, g.effdt, g.eff_status, g.descr, g.c_open_pay, g.c_gp_set_pay, g.c_anul_leav_pay, g.c_basic_pay, g.c_accum_fund, g.c_pension_fund, g.c_medical_fund,g.c_birth_fund, g.c_lose_job_fund, g.c_injury_fund  from SYSADM.ps_SAL_GRADE_TBL g";
                        rs = cmd.ExecuteReader();
                        while (rs.Read())
                        {
                            SalGrade salPlan = new SalGrade();

                            salPlan.集合 = (string)rs["setid"];
                            salPlan.薪酬体系 = (string)rs["sal_admin_plan"];
                            salPlan.薪等编号 = (string)rs["grade"];
                            salPlan.薪等名称 = (string)rs["descr"];
                            salPlan.生效日期 = Convert.ToDateTime(rs["effdt"]);
                            salPlan.状态 = ((string)rs["eff_status"]).Trim();

                            salPlan.基准工资标准 = Convert.ToDecimal(rs["C_BASIC_PAY"]);
                            salPlan.上表工资标准 = Convert.ToDecimal(rs["C_OPEN_PAY"]);
                            salPlan.设定工资标准 = Convert.ToDecimal(rs["C_GP_SET_PAY"]);
                            salPlan.年休假工资 = Convert.ToDecimal(rs["C_ANUL_LEAV_PAY"]);

                            salPlan.养老保险缴纳基数 = Convert.ToDecimal(rs["C_PENSION_FUND"]);
                            salPlan.医疗保险缴纳基数 = Convert.ToDecimal(rs["C_MEDICAL_FUND"]);
                            salPlan.生育保险缴纳基数 = Convert.ToDecimal(rs["C_BIRTH_FUND"]);
                            salPlan.失业保险缴纳基数 = Convert.ToDecimal(rs["C_LOSE_JOB_FUND"]);
                            salPlan.工伤保险缴纳基数 = Convert.ToDecimal(rs["C_INJURY_FUND"]);

                            salPlan.公积金基数 = Convert.ToDecimal(rs["C_ACCUM_FUND"]);
                            

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
