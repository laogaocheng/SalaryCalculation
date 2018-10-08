using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;

namespace Hwagain.SalaryCalculation.Components
{
    //管培生信息表
    public class TraineeInfo
    {
        public string 员工编号 { get; set; }
        public string 姓名 { get; set; }
        public DateTime 毕业时间 { get; set; }
        public string 毕业学校 { get; set; }
        public string 学习专业 { get; set; }
        public string 岗位级别 { get; set; }
        public string 学历 { get; set; }
        public string 届别 { get; set; }
        public DateTime 入职时间 { get; set; }

        #region GetAll

        public static List<TraineeInfo> GetAll()
        {
            List<TraineeInfo> list = new List<TraineeInfo>();

            OleDbConnection conn = new OleDbConnection(MyHelper.GetPsConnectionString());
            using (conn)
            {
                OleDbDataReader rs = null;
                try
                {
                    conn.Open();
                    //获取管培生配置
                    using (OleDbCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "SELECT EMPLID FROM PS_C_EMP_APPLYJOB WHERE C_CAMPUSRECRUIT_YN='Y'";
                        rs = cmd.ExecuteReader();
                        while (rs.Read())
                        {
                            string emplid = (string)rs["EMPLID"];
                            TraineeInfo t = Get(emplid);
                            list.Add(t);
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
        public static TraineeInfo Get(string emplid)
        {
            TraineeInfo item = null;
            OleDbConnection conn = new OleDbConnection(MyHelper.GetPsConnectionString());
            using (conn)
            {
                OleDbDataReader rs = null;
                try
                {
                    conn.Open();
                    //获取管培生配置
                    using (OleDbCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "SELECT EMPLID, C_CAMPUSRECRUIT_L FROM PS_C_EMP_APPLYJOB WHERE C_CAMPUSRECRUIT_YN='Y' AND EMPLID='" + emplid + "'";
                        rs = cmd.ExecuteReader();
                        if (rs.Read())
                        {
                            string grade = (string)rs["C_CAMPUSRECRUIT_L"];
                            if (grade == "A") grade = "一级";
                            if (grade == "B") grade = "二级";
                            if (grade == "C") grade = "三级";

                            item = new TraineeInfo();
                            item.员工编号 = emplid;
                            item.岗位级别 = grade;
                        }
                        rs.Close();
                    }
                    //获取学历信息
                    if (item != null)
                    {
                        using (OleDbCommand cmd = conn.CreateCommand())
                        {
                            cmd.CommandText = "SELECT emplid,c.descrshort, descr,f.effdt,school_descr, major_descr FROM sysadm.PS_JPM_PROFILE A, sysadm.PS_JPM_JP_ITEMS F LEFT JOIN SYSADM.PS_JPM_CAT_ITEMS C ON F.JPM_CAT_ITEM_ID = C.JPM_CAT_ITEM_ID WHERE A.JPM_PROFILE_ID = F.JPM_PROFILE_ID AND F.JPM_CAT_TYPE = 'EDLVLACHV' AND F.EFFDT = (SELECT MAX(BF.EFFDT) FROM sysadm.PS_JPM_PROFILE BE, sysadm.PS_JPM_JP_ITEMS BF WHERE BE.JPM_PROFILE_ID = BF.JPM_PROFILE_ID AND BE.EMPLID = A.EMPLID AND BF.JPM_CAT_TYPE = 'EDLVLACHV' AND BF.EFFDT <= SYSDATE AND BF.JPM_YN_1 = 'Y') AND F.JPM_YN_1 = 'Y' AND a.emplid='" + emplid + "'";
                            rs = cmd.ExecuteReader();
                            if (rs.Read())
                            {
                                item.姓名 = (string)rs["descr"];
                                item.毕业时间 = Convert.ToDateTime(rs["effdt"]);
                                item.毕业学校 = (string)rs["school_descr"];
                                item.学习专业 = (string)rs["major_descr"];
                                item.学历 = (string)rs["descrshort"];
                                item.届别 = item.毕业时间.Year.ToString();
                            }
                            rs.Close();
                        }
                        //获取入职时间
                        using (OleDbCommand cmd = conn.CreateCommand())
                        {
                            cmd.CommandText = "select hire_dt from ps_job where emplid='" + emplid + "' and rownum=1 order by last_hire_dt desc";
                            rs = cmd.ExecuteReader();
                            if (rs.Read())
                            {
                                item.入职时间 = Convert.ToDateTime(rs["hire_dt"]);                                
                            }
                            rs.Close();
                        }
                    }

                    return item;
                }
                finally
                {
                    if (rs != null) rs.Close();
                    conn.Close();
                }
            }
        }
        #endregion

    }
}
