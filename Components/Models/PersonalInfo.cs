using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;

namespace Hwagain.SalaryCalculation.Components
{
    public class PersonalInfo
    {
        public string 员工编号 { get; set; }
        public string 姓名 { get; set; }
        public DateTime 入职时间 { get; set; }
        public string 公司编号 { get; set; }
        public string 公司名称 { get; set; }
        public string 职务 { get; set; }

        public static PersonalInfo Get(string empNo)
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
                        cmd.CommandText = "SELECT A.emplid AS EMPLID ,A.name , descr1, effdt , B.Company  FROM ps_c_emp_base_vw A LEFT JOIN ps_c_emp_job_vw B ON B.emplid = A.emplid LEFT JOIN ps_PERS_WRKLIF_CHN C ON C.emplid = A.emplid  WHERE B.empl_rcd=0 and HR_STATUS = 'A' AND A.EmpLid='" + empNo + "'";
                        rs = cmd.ExecuteReader();
                        if (rs.Read())
                        {
                            PersonalInfo personalData = new PersonalInfo();

                            personalData.员工编号 = (string)rs["emplid"];
                            personalData.姓名 = (string)rs["name"];
                            personalData.公司编号 = (string)rs["company"];
                            personalData.职务 = (string)rs["descr1"];

                            if (rs["effdt"] != DBNull.Value) personalData.入职时间 = Convert.ToDateTime(rs["effdt"]);

                            CompanyInfo company = CompanyInfo.公司表.Find(a => a.公司编码 == personalData.公司编号);
                            if (company != null)
                                personalData.公司名称 = company.公司简称;

                            return personalData;

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

        #region GetAll

        //获取所有在职人员
        public static List<PersonalInfo> GetAll(string companyId)
        {
            List<PersonalInfo> list = new List<PersonalInfo>();
            OleDbConnection conn = new OleDbConnection(MyHelper.GetPsConnectionString());
            using (conn)
            {
                OleDbDataReader rs = null;
                try
                {
                    conn.Open();
                    using (OleDbCommand cmd = conn.CreateCommand())
                    {
                        string c = "";
                        if (!string.IsNullOrEmpty(companyId)) c = String.Format(" AND company = '{0}'", companyId);
                        cmd.CommandText = "SELECT A.emplid AS EMPLID ,A.name , descr1, effdt , B.Company  FROM ps_c_emp_base_vw A LEFT JOIN ps_c_emp_job_vw B ON B.emplid = A.emplid LEFT JOIN ps_PERS_WRKLIF_CHN C ON C.emplid = A.emplid  WHERE B.empl_rcd=0 and HR_STATUS = 'A'" + c;
                        rs = cmd.ExecuteReader();
                        while (rs.Read())
                        {
                            PersonalInfo personalData = new PersonalInfo();

                            personalData.员工编号 = (string)rs["emplid"];
                            personalData.姓名 = (string)rs["name"];
                            personalData.公司编号 = (string)rs["company"];
                            personalData.职务 = (string)rs["descr1"];

                            if (rs["effdt"] != DBNull.Value) personalData.入职时间 = Convert.ToDateTime(rs["effdt"]);

                            CompanyInfo company = CompanyInfo.公司表.Find(a => a.公司编码 == personalData.公司编号);
                            if (company != null)
                                personalData.公司名称 = company.公司简称;

                            list.Add(personalData);

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
