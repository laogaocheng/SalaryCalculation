using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;

namespace Hwagain.SalaryCalculation.Components
{
    //班长岗位级别
    public class MonitorLevel
    {
        public string 公司编号 { get; set; }
        public string 部门编号 { get; set; }
        public string 职务代码 { get; set; }
        public string 级别编号 { get; set; }
        public string 级别名称 { get; set; }

        #region 班长岗位级别表

        static List<MonitorLevel> deptList = null;

        public static List<MonitorLevel> 班长岗位级别表
        {
            get
            {
                if (deptList == null) deptList = GetAll();
                return deptList;
            }
        }
        #endregion
       
        #region GetAll

        //获取值列表
        public static List<MonitorLevel> GetAll()
        {
            List<MonitorLevel> list = new List<MonitorLevel>();
            OleDbConnection conn = new OleDbConnection(MyHelper.GetPsConnectionString());
            using (conn)
            {
                OleDbDataReader rs = null;
                try
                {
                    conn.Open();
                    using (OleDbCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "SELECT COMPANY, DEPTID, JOBCODE, C_MONITOR_LVL FROM SYSADM.PS_C_MNT_LVL_TBL A WHERE A.EFFDT=(SELECT MAX(B.EFFDT) FROM SYSADM.PS_C_MNT_LVL_TBL B WHERE A.COMPANY=B.COMPANY AND A.DEPTID=B.DEPTID AND A.JOBCODE=B.JOBCODE AND B.EFFDT<=SYSDATE )AND A.C_SIGN_TIMES=2";
                        rs = cmd.ExecuteReader();
                        while (rs.Read())
                        {
                            MonitorLevel dept = new MonitorLevel();

                            dept.公司编号 = (string)rs["COMPANY"];
                            dept.部门编号 = (string)rs["DEPTID"];
                            dept.职务代码 = (string)rs["JOBCODE"];
                            dept.级别编号 = (string)rs["C_MONITOR_LVL"];
                            dept.级别名称 = PsHelper.GetMonitorLevelName(dept.级别编号);

                            list.Add(dept);

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

        public static MonitorLevel Get(string deptid, string jobcode)
        {
            return 班长岗位级别表.Find(a => a.部门编号 == deptid && a.职务代码 == jobcode);
        }

        #endregion
    }
}
