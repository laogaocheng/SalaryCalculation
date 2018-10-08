using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;

namespace Hwagain.SalaryCalculation.Components
{
    public class Position
    {
        public string 职位号码 { get; set; }
        public string 职位名称 { get; set; }
        public string 职位描述 { get; set; }

        static List<Position> position_data = null;

        public static List<Position> 职位表
        {
            get
            {
                if (position_data == null) position_data = GetAll();
                return position_data;
            }
        }
       
        #region GetAll

        //获取值列表
        public static List<Position> GetAll()
        {
            List<Position> list = new List<Position>();
            OleDbConnection conn = new OleDbConnection(MyHelper.GetPsConnectionString());
            using (conn)
            {
                try
                {
                    conn.Open();
                    using (OleDbCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "SELECT DISTINCT POSITION_NBR,DESCR FROM SYSADM.PS_C_POS_SRCH_A WHERE POSN_STATUS='A'";
                        OleDbDataReader rs = cmd.ExecuteReader();
                        while (rs.Read())
                        {
                            string nbr = (string)rs["POSITION_NBR"];
                            string descr = (string)rs["DESCR"];
                            Position position = new Position();
                            position.职位号码 = nbr;
                            position.职位名称 = descr;
                            position.职位描述 = descr;
                            list.Add(position);

                        }
                        rs.Close();
                    }

                }
                finally
                {
                    conn.Close();
                }
            }
            return list;
        }
        #endregion
    }
}
