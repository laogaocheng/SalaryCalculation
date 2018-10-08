using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;

namespace Hwagain.SalaryCalculation.Components
{
    public class ElementInfo
    {
        public string 元素类型 { get; set; }
        public string 元素名称 { get; set; }
        public string 元素编码 { get; set; }
        public string 描述 { get; set; }

        static List<ElementInfo> elements = null;

        public static List<ElementInfo> 薪资元素表
        {
            get
            {
                if (elements == null) elements = GetAll();
                return elements;
            }
        }

        #region GetElementName

        public static string GetElementName(string name)
        {
            ElementInfo el = Get(name);
            if (el == null)
                return "";
            else
                return el.描述;
        }
        #endregion

        #region Get

        public static ElementInfo Get(string name)
        {
            ElementInfo el = 薪资元素表.Find(a => a.元素编码 == name || a.元素名称 == name);
            return el;
        }
        #endregion

        #region GetAll

        //获取值列表
        public static List<ElementInfo> GetAll()
        {
            List<ElementInfo> list = new List<ElementInfo>();
            OleDbConnection conn = new OleDbConnection(MyHelper.GetPsConnectionString());
            using (conn)
            {
                OleDbDataReader rs = null;
                try
                {
                    conn.Open();
                    using (OleDbCommand cmd = conn.CreateCommand())
                    {
                        //扣减元素
                        cmd.CommandText = "select pin_num, pin_nm, descr, pin_type  from ps_C_GP_ERN_SRCH";
                        rs = cmd.ExecuteReader();
                        while (rs.Read())
                        {
                            ElementInfo eInfo = new ElementInfo();
                            eInfo.元素类型 = (string)rs["pin_type"];
                            eInfo.元素名称 = (string)rs["pin_nm"];
                            eInfo.元素编码 = Convert.ToString(rs["pin_num"]);
                            eInfo.描述 = (string)rs["descr"];
                            list.Add(eInfo);
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
