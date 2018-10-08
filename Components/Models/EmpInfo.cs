using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;

namespace Hwagain.SalaryCalculation.Components
{
    public class EmpInfo
    {
        public string 员工编号 { get; set; }
        public string 姓名 { get; set; }
        public string 性别 { get; set; }
        public string 身份证号 { get; set; }
        public string 公司 { get; set; }
        public string 部门 { get; set; }
        public string 状态 { get; set; }
        public string 职位代码 { get; set; }
        public string 职务代码 { get; set; }
        public string 职务等级 { get; set; }
        public string 族群代码 { get; set; }
        public string 集合 { get; set; }
        public string 薪资体系 { get; set; }
        public string 薪等 { get; set; }
        public int 薪级 { get; set; }
        public string 薪资组 { get; set; }
        public string 银行账号 { get; set; }
        public string 帐户名称 { get; set; }
        public string 财务公司 { get; set; }
        public string 财务部门 { get; set; }
        public int 财务部门序号 { get; set; }
        public int 员工序号 { get; set; }
        public DateTime 出生日期 { get; set; }
        public string 上个月薪资组 { get; set; }

        public string 级别 { get; set; }
        public string 学历 { get; set; }
        public string 籍贯 { get; set; }
        public DateTime 离职时间 { get; set; }

        #region 员工表

        static List<EmpInfo> empList = null;

        public static List<EmpInfo> 员工表
        {
            get
            {
                if (empList == null) empList = GetAll();
                return empList;
            }
        }
        #endregion

        #region Get

        public static EmpInfo Get(string empNo)
        {
            return 员工表.Find(a => a.员工编号 == empNo);
        }
        #endregion

        #region GetAll

        //获取值列表
        public static List<EmpInfo> GetAll()
        {
            List<EmpInfo> list = new List<EmpInfo>();
            OleDbConnection conn = new OleDbConnection(MyHelper.GetPsConnectionString());
            using (conn)
            {
                OleDbDataReader rs = null;
                try
                {
                    conn.Open();
                    using (OleDbCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "SELECT B.HIGHEST_EDUC_LVL, B.BIRTHPLACE, ACTION, EFFDT, B.EMPLID AS EMPLID, B.NAME, B.BIRTHDATE, CASE WHEN B.SEX = 'M' THEN '男' ELSE '女' END AS SEX, NATIONAL_ID AS NID,DEPTID,HR_STATUS,COMPANY,A.POSITION_NBR,A.JOBCODE,A.SUPV_LVL_ID  FROM PS_C_EMP_JOB_VW A LEFT JOIN PS_C_EMP_BASE_VW B ON B.EMPLID = A.EMPLID  LEFT JOIN PS_PERS_WRKLIF_CHN C ON C.EMPLID = A.EMPLID WHERE EMPL_RCD = 0";
                        rs = cmd.ExecuteReader();
                        while (rs.Read())
                        {
                            EmpInfo emp = new EmpInfo();

                            emp.员工编号 = (string)rs["EMPLID"];
                            emp.姓名 = (string)rs["NAME"];
                            if (rs["BIRTHDATE"] != DBNull.Value) emp.出生日期 = Convert.ToDateTime(rs["BIRTHDATE"]);
                            emp.性别 = (string)rs["SEX"];
                            emp.身份证号 = (string)rs["NID"];
                            emp.公司 = (string)rs["COMPANY"];
                            emp.部门 = (string)rs["DEPTID"];
                            emp.状态 = (string)rs["HR_STATUS"];
                            emp.职位代码 = (string)rs["POSITION_NBR"];
                            emp.职务代码 = (string)rs["JOBCODE"];
                            emp.职务等级 = (string)rs["SUPV_LVL_ID"];
                            emp.学历 = (string)rs["HIGHEST_EDUC_LVL"];
                            emp.籍贯 = (string)rs["BIRTHPLACE"];

                            if ((string)rs["ACTION"] == "TER")
                                emp.离职时间 = Convert.ToDateTime(rs["EFFDT"]);

                            list.Add(emp);

                        }
                        rs.Close();
                    }
                    using (OleDbCommand cmd = conn.CreateCommand())
                    {
                        foreach (EmpInfo emp in list)
                        {
                            cmd.CommandText = String.Format("SELECT A.SAL_ADMIN_PLAN, A.GRADE, A.STEP, A.GP_PAYGROUP,A.SETID_SALARY FROM PS_JOB A WHERE EMPLID='{0}' AND A.EMPL_RCD=0 AND A.EFFDT = (SELECT MAX(A_ED.EFFDT) FROM PS_JOB A_ED WHERE A.EMPLID = A_ED.EMPLID AND A.EMPL_RCD = A_ED.EMPL_RCD AND A_ED.EFFDT <= SYSDATE)  order by A.EFFDT desc", emp.员工编号);
                            rs = cmd.ExecuteReader();
                            if (rs.Read())
                            {
                                emp.集合 = (string)rs["SETID_SALARY"];
                                emp.薪资体系 = (string)rs["SAL_ADMIN_PLAN"];
                                emp.薪等 = (string)rs["GRADE"];
                                emp.薪级 = Convert.ToInt32(rs["STEP"]);
                                emp.薪资组 = (string)(rs["GP_PAYGROUP"]);
                            }
                            rs.Close();

                            cmd.CommandText = String.Format("SELECT A.GP_PAYGROUP FROM PS_JOB A WHERE A.EMPL_RCD=0 AND A.EFFDT = (SELECT MAX(A_ED.EFFDT) FROM PS_JOB A_ED WHERE EMPLID='{0}' and A.EMPLID = A_ED.EMPLID AND A.EMPL_RCD = A_ED.EMPL_RCD AND A_ED.EFFDT < date'{1}') order by A.EFFDT desc", emp.员工编号, MyHelper.GetPrevMonth1Day().ToString("yyyy-M-d"));
                            rs = cmd.ExecuteReader();
                            if (rs.Read())
                            {
                                emp.上个月薪资组 = (string)(rs["GP_PAYGROUP"]);
                            }
                            rs.Close();
                        
                            cmd.CommandText = String.Format("SELECT ACCOUNT_EC_ID, ACCOUNT_NAME FROM SYSADM.PS_PYE_BANKACCT WHERE EMPLID='{0}' AND ACCOUNT_TYPE_PYE='A'", emp.员工编号);
                            rs = cmd.ExecuteReader();
                            if (rs.Read())
                            {
                                emp.银行账号 = (string)rs["ACCOUNT_EC_ID"];
                                emp.帐户名称 = (string)rs["ACCOUNT_NAME"];
                            }
                            rs.Close();

                            cmd.CommandText = String.Format("SELECT B.SEQ_NBR AS DEPT_SEQ, A.COMPANY, A.C_GP_DEPT, A.SEQ_NBR AS EMP_SEQ FROM SYSADM.PS_C_GP_DEPT_EMP_C A, SYSADM.PS_C_GP_DEPT B where A.Company = B.Company AND A.c_gp_dept = B.c_gp_dept and EMPLID='{0}' and rownum=1 order by a.effdt desc", emp.员工编号);
                            rs = cmd.ExecuteReader();
                            if (rs.Read())
                            {
                                CompanyInfo company = CompanyInfo.Get((string)rs["COMPANY"]);
                                if (company != null) emp.财务公司 = company.公司名称;
                                emp.财务部门 = (string)rs["C_GP_DEPT"];
                                emp.财务部门序号 = Convert.ToInt32(rs["DEPT_SEQ"]);
                                emp.员工序号 = Convert.ToInt32(rs["EMP_SEQ"]);
                            }
                            rs.Close();
                        }
                    }
                }
                finally
                {
                    if (rs != null) rs.Close();
                    conn.Close();
                }
            }
            empList = list;
            return list;
        }
        #endregion

    }
}
