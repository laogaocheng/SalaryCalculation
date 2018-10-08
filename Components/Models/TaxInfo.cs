using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;

namespace Hwagain.SalaryCalculation.Components
{
    public class TaxInfo
    {
        public int 序号 { get; set; }
        public decimal 金额 { get; set; }
        public decimal 税率 { get; set; }
        public decimal 速算扣除数 { get; set; }

        #region 税率表

        static List<TaxInfo> taxList = null;

        public static List<TaxInfo> 税率表
        {
            get
            {
                if (taxList == null) taxList = GetAll();
                return taxList;
            }
        }
        #endregion
       
        #region GetAll

        //获取值列表
        public static List<TaxInfo> GetAll()
        {
            List<TaxInfo> list = new List<TaxInfo>();
            OleDbConnection conn = new OleDbConnection(MyHelper.GetPsConnectionString());
            using (conn)
            {
                OleDbDataReader rs = null;
                try
                {
                    conn.Open();
                    using (OleDbCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "select seq_num5, data_key1_dec, data_val2_dec,data_val3_dec from SYSADM.ps_GP_BRACKET_DTL A left join SYSADM.PS_GP_PIN B On a.pin_num=B.pin_num where pin_nm='C BR TAX RATE' order by seq_num5";
                        rs = cmd.ExecuteReader();
                        while (rs.Read())
                        {
                            TaxInfo tax = new TaxInfo();

                            tax.序号 = Convert.ToInt32(rs["seq_num5"]);
                            tax.金额 = Convert.ToDecimal(rs["data_key1_dec"]);
                            tax.税率 = Convert.ToDecimal(rs["data_val2_dec"]);
                            tax.速算扣除数 = Convert.ToDecimal(rs["data_val3_dec"]);
                            list.Add(tax);

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

        public static TaxInfo Get(decimal pay)
        {
            if (pay < 0) pay = 0;
            List<TaxInfo> taxInfos = 税率表.FindAll(a => a.金额 <= pay).OrderByDescending(a => a.金额).ToList();
            return taxInfos[0];
        }

        #endregion
    }
}
