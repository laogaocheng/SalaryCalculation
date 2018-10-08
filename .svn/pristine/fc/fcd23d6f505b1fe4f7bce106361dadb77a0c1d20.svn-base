using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;

namespace Hwagain.SalaryCalculation.Components
{
    public class PersonBankInfo
    {
        public string 银行名称 { get; set; }
        public string 银行编号 { get; set; }
        public string 员工编号 { get; set; }
        public string 银行账户 { get; set; }
        public string 账户名称 { get; set; }
        public string 账户类型 { get; set; }
        
        #region 银行账户资料表

        static List<PersonBankInfo> list = null;

        public static List<PersonBankInfo> 银行账户资料表
        {
            get
            {
                if (list == null) list = GetAll();
                return list;
            }
        }
        #endregion
       
        #region GetAll

        //获取
        public static List<PersonBankInfo> GetAll()
        {
            List<PersonBankInfo> list = new List<PersonBankInfo>();
            OleDbConnection conn = new OleDbConnection(MyHelper.GetPsConnectionString());
            using (conn)
            {
                OleDbDataReader rs = null;
                try
                {
                    conn.Open();
                    using (OleDbCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "SELECT  A.EMPLID, ACCOUNT_TYPE_PYE, B.BANK_NM, ACCOUNT_NAME, A.BANK_CD, ACCOUNT_EC_ID FROM SYSADM.PS_PYE_BANKACCT A left join SYSADM.PS_BANK_EC_TBL B ON A.BANK_CD = B.BANK_CD  WHERE A.EFF_STATUS = 'A'";
                        rs = cmd.ExecuteReader();
                        while (rs.Read())
                        {
                            PersonBankInfo pbi = new PersonBankInfo();

                            pbi.银行名称 = ((string)rs["BANK_NM"]).Trim();
                            pbi.银行编号 = ((string)rs["BANK_CD"]).Trim();
                            pbi.员工编号 = ((string)rs["EMPLID"]).Trim();
                            pbi.银行账户 = ((string)rs["ACCOUNT_EC_ID"]).Trim();
                            pbi.账户类型 = ((string)rs["ACCOUNT_TYPE_PYE"]).Trim();
                            pbi.账户名称 = ((string)rs["ACCOUNT_NAME"]).Trim();
                            
                            list.Add(pbi);

                        }
                        rs.Close();
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

        #region Get

        public static PersonBankInfo Get(string empNo, string accType)
        {
            return 银行账户资料表.Find(a => a.员工编号 == empNo && a.账户类型 == accType);
        }

        #endregion

    }
}
