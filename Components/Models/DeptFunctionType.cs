using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Collections;

namespace Hwagain.SalaryCalculation.Components
{
    //部门职能类型
    public class DeptFunctionType
    {
        public string 公司编号 { get; set; }
        public string 部门编号 { get; set; }
        public string 类型编号 { get; set; }
        public string 类型名称 { get; set; }

        #region 部门职能表

        static List<DeptFunctionType> deptList = null;

        public static List<DeptFunctionType> 部门职能表
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
        public static List<DeptFunctionType> GetAll()
        {
            List<DeptFunctionType> list = new List<DeptFunctionType>();
            OleDbConnection conn = new OleDbConnection(MyHelper.GetPsConnectionString());
            using (conn)
            {
                OleDbDataReader rs = null;
                try
                {
                    conn.Open();
                    using (OleDbCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "SELECT COMPANY, DEPTID, C_HR_AREA FROM SYSADM.PS_C_DEPT_AREA_TBL A WHERE A.EFFDT=(SELECT MAX(B.EFFDT) FROM SYSADM.PS_C_DEPT_AREA_TBL B WHERE A.COMPANY=B.COMPANY AND A.DEPTID=B.DEPTID AND B.EFFDT<=SYSDATE)AND A.C_SIGN_TIMES=2";
                        rs = cmd.ExecuteReader();
                        while (rs.Read())
                        {
                            DeptFunctionType dept = new DeptFunctionType();

                            dept.公司编号 = (string)rs["COMPANY"];
                            dept.部门编号 = (string)rs["DEPTID"];
                            dept.类型编号 = (string)rs["C_HR_AREA"];

                            dept.类型名称 = PsHelper.GetDeptFunctionType(dept.类型编号);

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

        public static DeptFunctionType Get(string deptid)
        {
            return 部门职能表.Find(a => a.部门编号 == deptid);
        }

        #endregion

    }
}
