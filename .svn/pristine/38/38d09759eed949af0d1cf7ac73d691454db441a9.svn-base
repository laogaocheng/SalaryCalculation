using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;

namespace Hwagain.SalaryCalculation.Components
{
    /// <summary>
    /// 获取薪资组
    /// </summary>
    public class PayGroup
    {
        public string 中文名 { get; set; }
        public string 英文名 { get; set; }
        public string 支付实体 { get; set; }

        static List<PayGroup> payGroupList = null;

        public static List<PayGroup> 薪资组集合
        {
            get
            {
                if (payGroupList == null) payGroupList = GetAll();
                return payGroupList;
            }
        }

        #region Get

        public static PayGroup Get(string groupId)
        {
            return 薪资组集合.Find(a => a.英文名 == groupId);
        }

        #endregion
       
        #region GetAll

        //获取值列表
        public static List<PayGroup> GetAll()
        {
            List<PayGroup> list = new List<PayGroup>();
            OleDbConnection conn = new OleDbConnection(MyHelper.GetPsConnectionString());
            using (conn)
            {
                OleDbDataReader rs = null;
                try
                {
                    conn.Open();
                    using (OleDbCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "select * from SYSADM.ps_GP_PYGRP order by GP_PAYGROUP";
                        rs = cmd.ExecuteReader();
                        while (rs.Read())
                        {
                            PayGroup pGroup = new PayGroup();
                            pGroup.英文名 = ((string)rs["GP_PAYGROUP"]).Trim();
                            pGroup.中文名 = ((string)rs["DESCR"]).Trim();
                            pGroup.支付实体 = (string)rs["PAY_ENTITY"];

                            list.Add(pGroup);
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

        public override string ToString()
        {
            return this.中文名;
        }
    }
}
