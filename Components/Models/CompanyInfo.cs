using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;

namespace Hwagain.SalaryCalculation.Components
{
    public class CompanyInfo
    {
        public string 公司编码 { get; set; }
        public string 公司名称 { get; set; }
        public string 公司简称 { get; set; }

        static List<CompanyInfo> companys = null;

        public static List<CompanyInfo> 公司表
        {
            get
            {
                if (companys == null) companys = GetAll();
                return companys;
            }
        }

        #region Get

        public static CompanyInfo Get(string id)
        {
            CompanyInfo item = 公司表.Find(a => a.公司编码 == id);
            return item;
        }
        #endregion
       
        #region GetAll

        //获取值列表
        public static List<CompanyInfo> GetAll()
        {
            List<CompanyInfo> list = new List<CompanyInfo>();
            OleDbConnection conn = new OleDbConnection(MyHelper.GetPsConnectionString());
            using (conn)
            {
                OleDbDataReader rs = null;
                try
                {
                    conn.Open();
                    using (OleDbCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "select company, descr, descrshort, address1 from SYSADM.ps_COMPANY_TBL where eff_status='A' order by company";
                        rs = cmd.ExecuteReader();
                        while (rs.Read())
                        {
                            CompanyInfo company = new CompanyInfo();
                            company.公司编码 = (string)rs["company"];
                            company.公司名称 = (string)rs["DESCR"];
                            company.公司简称 = (string)rs["descrshort"];
                            list.Add(company);

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
