using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Xpo;
using System.Configuration;
using log4net;
using System.Data.SqlClient;
using System.IO;
using System.Web.UI;
using System.Data.Odbc;
using System.Web;
using DevExpress.Xpo.DB;
using Hwagain.Components;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Drawing;
using DevExpress.Xpo.Metadata;
using System.Collections;
using System.Data.OleDb;
using Hwagain.SalaryCalculation.Components;

namespace Hwagain
{
    public class PsHelper
    {
        static readonly ILog log = LogManager.GetLogger(typeof(PsHelper));

        static Hashtable keyValues = new Hashtable();
        static ICache<string, string> JOB_CACHE = MemoryCache<string, string>.Instance;
        static ICache<string, decimal> FULLATTENDANCEPAY_CACHE = MemoryCache<string, decimal>.Instance;
        static ICache<string, decimal> VAC_PAY_CACHE = MemoryCache<string, decimal>.Instance;

        #region 值列表

        static Hashtable 值列表
        {
            get
            {
                return keyValues;
            }
        }
        #endregion

        #region GetDeptFunctionType

        public static string GetDeptFunctionType(string val)
        {
            foreach (DictionaryEntry entry in 部门职能分类)
            {
                if ((string)entry.Value == val) return (string)entry.Key;
            }
            return null;
        }

        #endregion

        #region GetMonitorLevelName

        public static string GetMonitorLevelName(string val)
        {
            foreach (DictionaryEntry entry in 班长岗位级别)
            {
                if ((string)entry.Value == val) return (string)entry.Key;
            }
            return null;
        }

        #endregion

        #region GetKeyValues

        //获取指定名称的值列表
        static Hashtable GetKeyValues(string name)
        {
            if (!keyValues.ContainsKey(name))
            {
                switch (name.ToUpper())
                {
                    case "SEX":
                    case "MAR_STATUS":
                    case "HIGHEST_EDUC_LVL":
                    case "C_BIRTH_PLACE_TYPE":
                    case "C_BLOOD_TYPE":
                    case "POLITICAL_STA_CHN":
                    case "C_EMPLOY_PLACE":
                    case "C_APPLYJOB_BY":
                    case "C_APPLYJOB_WEB":
                    case "C_TRAIN_TYPE":
                    case "C_PRORES_PRD":
                    case "RELATIONSHIP":     
                    case "EXAM_TYPE_CD":
                    case "C_EXAM_RESULT":
                    case "REFERRAL":
                    case "C_DISABLE_GRADE":
                    case "C_DISABLE_TYPE":
                    case "C_SI_TYPE":
                    case "C_RND_RULE_COM":
                    case "C_HR_AREA":
                    case "C_MONITOR_LVL":
                        keyValues[name] = GetXlatItems(name);
                        break;
                    case "BIRTHSTATE":
                        keyValues[name] = GetBirthStates();
                        break;
                    case "ETHNIC_GRP_CD":
                        keyValues[name] = GetEthnicGrpCDs();
                        break;
                    case "RELIGION_CD":
                        keyValues[name] = GetReligions();
                        break;
                    case "HU_KOU":
                        keyValues[name] = GetHuKous();
                        break;
                    case "CONTRIB_AREA_CHN":
                        keyValues[name] = GetContribAreas();
                        break;
                    case "ACTION":
                        keyValues[name] = GetActions();
                        break;
                    case "SUPV_LVL_ID":
                        keyValues[name] = GetSupvLvls();
                        break;
                    case "EMPL_CLASS":
                        keyValues[name] = GetEmplClasses();
                        break;
                    case "POSITION_NBR":
                        keyValues[name] = GetPositions();
                        break;
                    case "EDU_RATING":
                        keyValues[name] = GetRevwRatings("EDU");
                        break;
                    case "DRIVER_LICENSE_TYPE":
                        keyValues[name] = GetDriverLicenseTypes();
                        break;         
                    case "JOBCODE":
                        keyValues[name] = GetJobCodes();
                        break;
                    default:
                        return new Hashtable();
                }
            }
            return (Hashtable)keyValues[name];
        }

        #endregion

        #region GetDriverLicenseTypes

        private static Hashtable GetDriverLicenseTypes()
        {
            Hashtable keyValues = new Hashtable();
            OleDbConnection conn = new OleDbConnection(MyHelper.GetPsConnectionString());
            using (conn)
            {
                OleDbDataReader rs = null;
                try
                {
                    conn.Open();
                    using (OleDbCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "SELECT LICENSE_TYPE, DESCR FROM PS_DRIVER_LTYP_TBL WHERE EFF_STATUS='A' ORDER BY LICENSE_TYPE";
                        rs = cmd.ExecuteReader();
                        while (rs.Read())
                        {
                            string key = (string)rs["DESCR"];
                            string val = (string)rs["LICENSE_TYPE"];
                            keyValues[key] = val;
                        }
                        rs.Close();
                    }

                }
                finally
                {
                    conn.Close();
                }
            }
            return keyValues;
        }
        #endregion

        #region 关系

        public static Hashtable 关系
        {
            get
            {
                return GetKeyValues("RELATIONSHIP");
            }
        }
        #endregion

        #region 部门职能分类

        public static Hashtable 部门职能分类
        {
            get
            {
                return GetKeyValues("C_HR_AREA");
            }
        }
        #endregion

        #region 班长岗位级别

        public static Hashtable 班长岗位级别
        {
            get
            {
                return GetKeyValues("C_MONITOR_LVL");
            }
        }
        #endregion

        #region 性别

        public static Hashtable 性别
        {
            get
            {
                return GetKeyValues("SEX");
            }
        }
        #endregion

        #region 社保类型

        public static Hashtable 社保类型
        {
            get
            {
                return GetKeyValues("C_SI_TYPE");
            }
        }
        #endregion
        
        #region 婚姻状况

        public static Hashtable 婚姻状况
        {
            get
            {
                return GetKeyValues("MAR_STATUS");
            }
        }
        #endregion

        #region 省份

        public static Hashtable 省份
        {
            get
            {
                return GetKeyValues("BIRTHSTATE");
            }
        }
        #endregion

        #region 学历

        public static Hashtable 学历
        {
            get
            {
                return GetKeyValues("HIGHEST_EDUC_LVL");
            }
        }
        #endregion

        #region 学位

        public static Hashtable 学位
        {
            get
            {
                return GetKeyValues("EDU_RATING");
            }
        }
        #endregion

        #region 出生地类型

        public static Hashtable 出生地类型
        {
            get
            {
                return GetKeyValues("C_BIRTH_PLACE_TYPE");
            }
        }
        #endregion

        #region 驾驶证类型

        public static Hashtable 驾驶证类型
        {
            get
            {
                return GetKeyValues("DRIVER_LICENSE_TYPE");
            }
        }
        #endregion

        #region 后续安排

        public static Hashtable 后续安排
        {
            get
            {
                return GetKeyValues("REFERRAL");
            }
        }
        #endregion
        
        #region 体检类型

        public static Hashtable 体检类型
        {
            get
            {
                return GetKeyValues("EXAM_TYPE_CD");
            }
        }
        #endregion        
        
        #region 体检结果

        public static Hashtable 体检结果
        {
            get
            {
                return GetKeyValues("C_EXAM_RESULT");
            }
        }
        #endregion        

        #region 残障等级

        public static Hashtable 残障等级
        {
            get
            {
                return GetKeyValues("C_DISABLE_GRADE");
            }
        }
        #endregion        

        #region 残疾类型

        public static Hashtable 残疾类型
        {
            get
            {
                return GetKeyValues("C_DISABLE_TYPE");
            }
        }
        #endregion        
        
        #region 血型

        public static Hashtable 血型
        {
            get
            {
                return GetKeyValues("C_BLOOD_TYPE");
            }
        }
        #endregion

        #region 民族

        public static Hashtable 民族
        {
            get
            {
                return GetKeyValues("ETHNIC_GRP_CD");
            }
        }
        #endregion

        #region 宗教信仰

        public static Hashtable 宗教信仰
        {
            get
            {
                return GetKeyValues("RELIGION_CD");
            }
        }
        #endregion

        #region 户口类型

        public static Hashtable 户口类型
        {
            get
            {
                return GetKeyValues("HU_KOU");
            }
        }
        #endregion

        #region 户口所在地

        public static Hashtable 户口所在地
        {
            get
            {
                return GetKeyValues("CONTRIB_AREA_CHN");
            }
        }
        #endregion

        #region 政治面貌

        public static Hashtable 政治面貌
        {
            get
            {
                return GetKeyValues("POLITICAL_STA_CHN");
            }
        }
        #endregion

        #region 招聘来源地

        public static Hashtable 招聘来源地
        {
            get
            {
                return GetKeyValues("C_EMPLOY_PLACE");
            }
        }
        #endregion

        #region 求职途径

        public static Hashtable 求职途径
        {
            get
            {
                return GetKeyValues("C_APPLYJOB_BY");
            }
        }
        #endregion
        
        #region 求职网站

        public static Hashtable 求职网站
        {
            get
            {
                return GetKeyValues("C_APPLYJOB_WEB");
            }
        }
        #endregion        
        
        #region 培养类别

        public static Hashtable 培养类别
        {
            get
            {
                return GetKeyValues("C_TRAIN_TYPE");
            }
        }
        #endregion        
        
        #region 操作

        public static Hashtable 操作
        {
            get
            {
                return GetKeyValues("ACTION");
            }
        }
        #endregion        
        
        #region 职务等级

        public static Hashtable 职务等级
        {
            get
            {
                return GetKeyValues("SUPV_LVL_ID");
            }
        }
        #endregion        
        
        #region 员工类别

        public static Hashtable 员工类别
        {
            get
            {
                return GetKeyValues("EMPL_CLASS");
            }
        }
        #endregion        

        #region 试用期限

        public static Hashtable 试用期限
        {
            get
            {
                return GetKeyValues("C_PRORES_PRD");
            }
        }
        #endregion        

        #region 职位

        public static Hashtable 职位
        {
            get
            {
                return GetKeyValues("POSITION_NBR");
            }
        }
        #endregion        
        
        #region 职务代码

        public static Hashtable 职务代码
        {
            get
            {
                return GetKeyValues("JOBCODE");
            }
        }
        #endregion        

        #region 业务单位

        public static Hashtable 业务单位
        {
            get
            {
                return GetHrBusinessUnitTable();
            }
        }
        #endregion        

        #region 取整规则

        public static Hashtable 取整规则
        {
            get
            {
                return GetKeyValues("C_RND_RULE_COM");
            }
        }
        #endregion        

        #region 项目类型
        /// <summary>
        /// 薪资元素的类型：收入、扣减
        /// </summary>
        public static Hashtable 项目类型
        {
            get
            {
                return GetEntryTypeTable();
            }
        }
        #endregion        

        #region 收入元素

        public static Hashtable 收入元素
        {
            get
            {
                return GetElements("ER");
            }
        }

        #endregion        

        #region 扣减元素

        public static Hashtable 扣减元素
        {
            get
            {
                return GetElements("DD");
            }
        }
        #endregion        

        #region 薪资元素

        public static Hashtable 薪资元素
        {
            get
            {
                return GetElements(null);
            }
        }
        #endregion        

        #region GetTotalAttdDay

        //获取总考勤天数
        public static int GetTotalAttdDay(string emplid, string year_month)
        {
            OleDbConnection conn = new OleDbConnection(MyHelper.GetPsConnectionString());
            using (conn)
            {
                OleDbDataReader rs = null;
                try
                {
                    conn.Open();
                    using (OleDbCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = String.Format("SELECT EMPLID, C_TOTAL_ATTD_DAY FROM PS_C_EMPL_ABS_HDR A WHERE EMPLID='{0}' AND C_YEAR_MONTH = '{1}'", emplid, year_month);
                        rs = cmd.ExecuteReader();
                        if (rs.Read())
                        {
                            return Convert.ToInt32(rs["C_TOTAL_ATTD_DAY"]);
                        }
                    }

                }
                finally
                {
                    if (rs != null) rs.Close();
                    conn.Close();
                }
                return -1;
            }
        }
        #endregion

        #region GetAttendanceDay

        //获取员工出勤天数
        public static decimal GetAttendanceDay(string emplid, string year_month)
        {
            OleDbConnection conn = new OleDbConnection(MyHelper.GetPsConnectionString());
            using (conn)
            {
                OleDbDataReader rs = null;
                try
                {

                    conn.Open();
                    using (OleDbCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = String.Format("SELECT EMPLID, C_TOTAL_ATTD_DAY FROM PS_C_EMPL_ABS_HDR A WHERE EMPLID='{0}' AND C_YEAR_MONTH = '{1}'", emplid, year_month);
                        rs = cmd.ExecuteReader();
                        if (rs.Read())
                        {
                            return Convert.ToDecimal(rs["C_TOTAL_ATTD_DAY"]);
                        }
                    }

                }
                finally
                {
                    if (rs != null) rs.Close();
                    conn.Close();
                }
                return 0;
            }
        }
        #endregion

        #region GetEmplSupvLv

        //获取员工的职级
        public static string GetEmplSupvLv(string emplid, DateTime date)
        {
            OleDbConnection conn = new OleDbConnection(MyHelper.GetPsConnectionString());
            using (conn)
            {
                OleDbDataReader rs = null;                
                try
                {
                    conn.Open();
                    using (OleDbCommand cmd = conn.CreateCommand())
                    {
                        string sql = "SELECT SUPV_LVL_ID FROM SYSADM.PS_JOB P WHERE P.EMPLID = '" + emplid + "' AND P.EMPL_RCD = 0 "
                         + " AND P.EFFDT = (SELECT MAX(PE.EFFDT) FROM SYSADM.PS_JOB PE WHERE PE.EMPLID = P.EMPLID "
                         + " AND PE.EMPL_RCD = P.EMPL_RCD"
                         + " AND PE.EFFDT <= Date'" + date.Date.ToString("yyyy-M-d") + "')"
                         + " AND P.EFFSEQ = (SELECT MAX(PE.EFFSEQ)"
                         + " FROM SYSADM.PS_JOB PE"
                         + " WHERE PE.EMPLID = P.EMPLID"
                         + " AND PE.EMPL_RCD = P.EMPL_RCD"
                         + " AND PE.EFFDT = P.EFFDT)";

                        cmd.CommandText = sql;
                        rs = cmd.ExecuteReader();
                        if (rs.Read())
                        {
                            return Convert.ToString(rs["SUPV_LVL_ID"]);
                        }
                    }
                }
                finally
                {
                    if (rs != null) rs.Close();
                    conn.Close();
                }
                return null;
            }
        }
        #endregion

        #region GetSupvsrLvDescr

        //获取职级描述
        public static string GetSupvsrLvDescr(string supvsrLv)
        {
            OleDbConnection conn = new OleDbConnection(MyHelper.GetPsConnectionString());
            using (conn)
            {
                OleDbDataReader rs = null;                
                try
                {

                    conn.Open();
                    using (OleDbCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = String.Format("SELECT DESCRSHORT FROM SYSADM.PS_SUPVSR_LVL_TBL WHERE SUPV_LVL_ID='{0}' AND EFFDT<= DATE'{1}' ORDER BY EFFDT DESC", supvsrLv, DateTime.Today.ToString("yyyy-M-d"));
                        rs = cmd.ExecuteReader();
                        if (rs.Read())
                        {
                            return Convert.ToString(rs["DESCRSHORT"]);
                        }
                    }

                }
                finally
                {
                    if (rs != null) rs.Close();
                    conn.Close();
                }
                return null;
            }
        }
        #endregion

        #region GetEmplId

        //获取员工编号
        public static string GetEmplId(string name)
        {
            OleDbConnection conn = new OleDbConnection(MyHelper.GetPsConnectionString());
            using (conn)
            {
                OleDbDataReader rs = null;
                try
                {
                    conn.Open();
                    using (OleDbCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = String.Format("select EMPLID from sysadm.ps_personal_data where name='{0}'", name);                        
                        rs = cmd.ExecuteReader();
                        if (rs.Read())
                        {
                            return Convert.ToString(rs["EMPLID"]);
                        }
                    }

                }
                finally
                {
                    if (rs != null) rs.Close();
                    conn.Close();
                }
                return null;
            }
        }
        #endregion

        #region GetEmplName

        //获取员工姓名
        public static string GetEmplName(string emplid)
        {
            OleDbConnection conn = new OleDbConnection(MyHelper.GetPsConnectionString());
            using (conn)
            {
                OleDbDataReader rs = null;
                try
                {
                    conn.Open();
                    using (OleDbCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = String.Format("SELECT NAME FROM SYSADM.PS_PERSONAL_DATA WHERE EMPLID='{0}'", emplid);
                        rs = cmd.ExecuteReader();
                        if (rs.Read())
                        {
                            return Convert.ToString(rs["NAME"]);
                        }
                    }
                }
                finally
                {
                    if (rs != null) rs.Close();
                    conn.Close();
                }
                return null;
            }
        }
        #endregion

        #region GetEmpidByNID

        //通过身份证获取员工编号
        public static string GetEmpidByNID(string nid)
        {
            OleDbConnection conn = new OleDbConnection(MyHelper.GetPsConnectionString());
            using (conn)
            {
                OleDbDataReader rs = null;
                try
                {
                    conn.Open();
                    using (OleDbCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = String.Format("select emplid from ps_PERS_NID where national_id = '{0}' and national_id_type='CHN18'", nid);
                        rs = cmd.ExecuteReader();
                        if (rs.Read())
                        {
                            return Convert.ToString(rs["emplid"]);
                        }
                    }
                }
                finally
                {
                    if (rs != null) rs.Close();
                    conn.Close();
                }
                return null;
            }
        }
        #endregion

        #region GetPayDegrade

        //获取员工的工资降级
        public static decimal GetPayDegrade(string emplid, DateTime start)
        {
            OleDbConnection conn = new OleDbConnection(MyHelper.GetPsConnectionString());
            using (conn)
            {
                OleDbDataReader rs = null;
                try
                {
                    conn.Open();
                    using (OleDbCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = String.Format("SELECT C_AMT001 FROM SYSADM.PS_C_DEMOTION_VW WHERE EMPLID='{0}' AND DATE1=DATE'{1}'", emplid, start.ToString("yyyy-M-d"));
                        rs = cmd.ExecuteReader();
                        if (rs.Read())
                        {
                            return Convert.ToDecimal(rs["C_AMT001"]);
                        }
                    }
                }
                finally
                {
                    if (rs != null) rs.Close();
                    conn.Close();
                }
                return 0;
            }
        }
        #endregion

        #region GetCompany

        //获取员工所在公司的编号
        public static string GetCompany(string emplid)
        {
            OleDbConnection conn = new OleDbConnection(MyHelper.GetPsConnectionString());
            using (conn)
            {
                OleDbDataReader rs = null;
                try
                {
                    conn.Open();
                    using (OleDbCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = String.Format("SELECT c_person_job.get_company('{0}', 0, sysdate) company FROM DUAL", emplid);
                        rs = cmd.ExecuteReader();
                        if (rs.Read())
                        {
                            return Convert.ToString(rs["company"]);
                        }
                    }
                }
                finally
                {
                    if (rs != null) rs.Close();
                    conn.Close();
                }
                return null;
            }
        }
        #endregion

        #region GetXlatItems

        //获取值列表
        public static Hashtable GetXlatItems(string fieldName)
        {
            Hashtable keyValues = new Hashtable();
            OleDbConnection conn = new OleDbConnection(MyHelper.GetPsConnectionString());
            using (conn)
            {
                OleDbDataReader rs = null;
                try
                {
                    conn.Open();
                    using (OleDbCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = String.Format("SELECT FIELDVALUE, XLATSHORTNAME FROM PS_C_XLATITEM_VW WHERE EFF_STATUS='A' AND FIELDNAME='{0}' ORDER BY FIELDVALUE", fieldName);
                        rs = cmd.ExecuteReader();
                        while (rs.Read())
                        {
                            string key = (string)rs["XLATSHORTNAME"];
                            string val = (string)rs["FIELDVALUE"];
                            keyValues[key] = val;
                        }
                    }

                }
                finally
                {
                    if (rs != null) rs.Close();
                    conn.Close();
                }
            }
            return keyValues;
        }
        #endregion

        #region GetBirthStates

        //获取值列表
        public static Hashtable GetBirthStates()
        {
            Hashtable keyValues = new Hashtable();
            OleDbConnection conn = new OleDbConnection(MyHelper.GetPsConnectionString());
            using (conn)
            {
                OleDbDataReader rs = null;
                try
                {
                    conn.Open();
                    using (OleDbCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "SELECT STATE, DESCR FROM SYSADM.PS_BIRTHSTATE_VW WHERE BIRTHCOUNTRY='CHN'";
                        rs = cmd.ExecuteReader();
                        while (rs.Read())
                        {
                            string val = (string)rs["STATE"];
                            string key = (string)rs["DESCR"];
                            keyValues[key] = val;
                        }
                    }

                }
                finally
                {
                    if (rs != null) rs.Close();
                    conn.Close();
                }
            }
            return keyValues;
        }
        #endregion

        #region GetEthnicGrpCDs

        //获取民族值列表
        public static Hashtable GetEthnicGrpCDs()
        {
            Hashtable keyValues = new Hashtable();
            OleDbConnection conn = new OleDbConnection(MyHelper.GetPsConnectionString());
            using (conn)
            {
                OleDbDataReader rs = null;
                try
                {
                    conn.Open();
                    using (OleDbCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "SELECT ETHNIC_GRP_CD, DESCRSHORT FROM SYSADM.PS_ETHNIC_GRP_TBL WHERE EFF_STATUS='A'";
                        rs = cmd.ExecuteReader();
                        while (rs.Read())
                        {
                            string val = (string)rs["ETHNIC_GRP_CD"];
                            string key = (string)rs["DESCRSHORT"];
                            keyValues[key] = val;
                        }
                    }

                }
                finally
                {
                    if (rs != null) rs.Close();
                    conn.Close();
                }
            }
            return keyValues;
        }
        #endregion

        #region GetReligions

        //获取值列表
        public static Hashtable GetReligions()
        {
            Hashtable keyValues = new Hashtable();
            OleDbConnection conn = new OleDbConnection(MyHelper.GetPsConnectionString());
            using (conn)
            {
                OleDbDataReader rs = null;
                try
                {
                    conn.Open();
                    using (OleDbCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "SELECT RELIGION_CD, DESCR FROM SYSADM.PS_RELIGION_TBL WHERE EFF_STATUS='A'";
                        rs = cmd.ExecuteReader();
                        while (rs.Read())
                        {
                            string val = (string)rs["RELIGION_CD"];
                            string key = (string)rs["DESCR"];
                            keyValues[key] = val;
                        }
                    }

                }
                finally
                {
                    if (rs != null) rs.Close();
                    conn.Close();
                }
            }
            return keyValues;
        }
        #endregion

        #region GetHuKous

        //获取值列表
        public static Hashtable GetHuKous()
        {
            Hashtable keyValues = new Hashtable();
            OleDbConnection conn = new OleDbConnection(MyHelper.GetPsConnectionString());
            using (conn)
            {
                OleDbDataReader rs = null;
                try
                {
                    conn.Open();
                    using (OleDbCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "SELECT HUKOU_TYPE_CHN, DESCR FROM SYSADM.PS_HUKOU_T_DTL_CHN";
                        rs = cmd.ExecuteReader();
                        while (rs.Read())
                        {
                            string val = (string)rs["HUKOU_TYPE_CHN"];
                            string key = (string)rs["DESCR"];
                            keyValues[key] = val;
                        }
                    }

                }
                finally
                {
                    if (rs != null) rs.Close();
                    conn.Close();
                }
            }
            return keyValues;
        }
        #endregion

        #region GetContribAreas

        //获取值列表
        public static Hashtable GetContribAreas()
        {
            Hashtable keyValues = new Hashtable();
            OleDbConnection conn = new OleDbConnection(MyHelper.GetPsConnectionString());
            using (conn)
            {
                OleDbDataReader rs = null;
                try
                {
                    conn.Open();
                    using (OleDbCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "SELECT CONTRIB_AREA_CHN,DESCR FROM SYSADM.PS_HUKOU_L_DTL_CHN";
                        rs = cmd.ExecuteReader();
                        while (rs.Read())
                        {
                            string val = (string)rs["CONTRIB_AREA_CHN"];
                            string key = (string)rs["DESCR"];
                            keyValues[key] = val;
                        }
                    }

                }
                finally
                {
                    if (rs != null) rs.Close();
                    conn.Close();
                }
            }
            return keyValues;
        }
        #endregion

        #region GetActions

        //获取值列表
        public static Hashtable GetActions()
        {
            Hashtable keyValues = new Hashtable();
            OleDbConnection conn = new OleDbConnection(MyHelper.GetPsConnectionString());
            using (conn)
            {
                OleDbDataReader rs = null;
                try
                {
                    conn.Open();
                    using (OleDbCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "SELECT ACTION, ACTION_DESCR FROM SYSADM.PS_ACTION_TBL WHERE EFF_STATUS='A'";
                        rs = cmd.ExecuteReader();
                        while (rs.Read())
                        {
                            string val = (string)rs["ACTION"];
                            string key = (string)rs["ACTION_DESCR"];
                            keyValues[key] = val;
                        }
                    }

                }
                finally
                {
                    if (rs != null) rs.Close();
                    conn.Close();
                }
            }
            return keyValues;
        }
        #endregion

        #region GetJobCodes

        //获取职务代码表
        public static Hashtable GetJobCodes()
        {
            Hashtable keyValues = new Hashtable();
            OleDbConnection conn = new OleDbConnection(MyHelper.GetPsConnectionString());
            using (conn)
            {
                OleDbDataReader rs = null;
                try
                {
                    conn.Open();
                    using (OleDbCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "SELECT JOBCODE, DESCR FROM PS_JOBCODE_TBL";
                        rs = cmd.ExecuteReader();
                        while (rs.Read())
                        {
                            try
                            {
                                string key = (string)rs["JOBCODE"];
                                string val = (string)rs["DESCR"];
                                keyValues[key] = val;
                            }
                            catch
                            {
                                continue;
                            }
                        }
                    }
                }
                finally
                {
                    if (rs != null) rs.Close();
                    conn.Close();
                }
            }
            return keyValues;
        }
        #endregion

        #region GetJobName

        //获取职务名称
        public static string GetJobNameFromCache(string code)
        {
            return JOB_CACHE.Get(code, () => GetJobName(code), TimeSpan.FromHours(8));

        }
        public static string GetJobName(string code)
        {
            if (code == null) return null;

            code = code.Trim(); //PS 过来的数据有空格

            OleDbConnection conn = new OleDbConnection(MyHelper.GetPsConnectionString());
            using (conn)
            {
                OleDbDataReader rs = null;
                try
                {
                    conn.Open();
                    using (OleDbCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "SELECT JOBCODE, DESCR FROM PS_JOBCODE_TBL where JOBCODE='" + code + "'";
                        rs = cmd.ExecuteReader();
                        if (rs.Read())
                        {
                            string desc = (string)rs["DESCR"];
                            JOB_CACHE.Set(code, desc, TimeSpan.FromHours(8));
                            return desc;
                        }
                    }
                }
                finally
                {
                    if (rs != null) rs.Close();
                    conn.Close();
                }
            }
            return "";
        }
        #endregion

        #region CheckIsGuanPeiSheng

        //检查是否管培生
        public static bool CheckIsGuanPeiSheng(string emplid)
        {            
            OleDbConnection conn = new OleDbConnection(MyHelper.GetPsConnectionString());
            using (conn)
            {
                OleDbDataReader rs = null;
                try
                {
                    conn.Open();
                    using (OleDbCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "SELECT EMPLID FROM PS_C_EMP_APPLYJOB WHERE C_CAMPUSRECRUIT_YN='Y' AND EMPLID='" + emplid + "'";
                        rs = cmd.ExecuteReader();
                        if(rs.Read())
                        {
                            return true;
                        }
                    }
                }
                finally
                {
                    if (rs != null) rs.Close();
                    conn.Close();
                }
            }
            return false;
        }
        #endregion

        #region GetJobEntryDate

        //获取职务开始日期
        public static DateTime GetJobEntryDate(string emplid, string jobcode)
        {
            OleDbConnection conn = new OleDbConnection(MyHelper.GetPsConnectionString());
            using (conn)
            {
                OleDbDataReader rs = null;
                try
                {
                    conn.Open();
                    using (OleDbCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = string.Format("SELECT JOBCODE, JOB_ENTRY_DT,EFFDT FROM PS_JOB WHERE ROWNUM=1 AND EMPLID='{0}' AND EMPL_RCD=0 AND JOBCODE='{1}'ORDER BY EFFDT DESC", emplid, jobcode);
                        rs = cmd.ExecuteReader();
                        if (rs.Read())
                        {
                            return (DateTime)rs["JOB_ENTRY_DT"];
                        }
                    }
                }
                finally
                {
                    if (rs != null) rs.Close();
                    conn.Close();
                }
            }
            return DateTime.MinValue;
        }
        #endregion

        #region GetJobLvlEntryDate

        //获取职务等级开始日期
        public static DateTime GetJobLvlEntryDate(string emplid, string lvl, out DateTime end)
        {
            DateTime ret = DateTime.MinValue;
            end = DateTime.Today;
            OleDbConnection conn = new OleDbConnection(MyHelper.GetPsConnectionString());
            using (conn)
            {
                OleDbDataReader rs = null;
                try
                {
                    conn.Open();
                    using (OleDbCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = string.Format("SELECT EFFDT, SUPV_LVL_ID FROM PS_JOB WHERE EMPLID='{0}' AND EMPL_RCD=0 ORDER BY EFFDT DESC", emplid);
                        rs = cmd.ExecuteReader();
                        while (rs.Read())
                        {
                            DateTime dt = (DateTime)rs["EFFDT"];
                            string lvlId = (string)rs["SUPV_LVL_ID"];
                            if (lvl == lvlId)
                                ret = dt;
                            else
                            {
                                if (ret != DateTime.MinValue)
                                    break;
                                else
                                {
                                    end = dt.AddDays(-1);
                                }
                            }
                        }
                    }
                }
                finally
                {
                    if (rs != null) rs.Close();
                    conn.Close();
                }
            }
            return ret;
        }
        #endregion

        #region GetActionReasons

        //获取值列表
        public static Hashtable GetActionReasons(string action)
        {
            Hashtable keyValues = new Hashtable();
            OleDbConnection conn = new OleDbConnection(MyHelper.GetPsConnectionString());
            using (conn)
            {
                OleDbDataReader rs = null;
                try
                {
                    conn.Open();
                    using (OleDbCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = String.Format("SELECT ACTION_REASON, DESCR FROM SYSADM.PS_ACTN_REASON_TBL WHERE  EFF_STATUS='A' AND ACTION = '{0}'", action);
                        rs = cmd.ExecuteReader();
                        while (rs.Read())
                        {
                            string val = (string)rs["ACTION_REASON"];
                            string key = (string)rs["DESCR"];
                            keyValues[key] = val;
                        }
                    }
                }
                finally
                {
                    if (rs != null) rs.Close();
                    conn.Close();
                }
            }
            return keyValues;
        }
        #endregion

        #region GetSupvLvls

        //获取值列表
        public static Hashtable GetSupvLvls()
        {
            Hashtable keyValues = new Hashtable();
            OleDbConnection conn = new OleDbConnection(MyHelper.GetPsConnectionString());
            using (conn)
            {
                OleDbDataReader rs = null;
                try
                {
                    conn.Open();
                    using (OleDbCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "SELECT SUPV_LVL_ID, DESCR, SEQNBR FROM SYSADM.PS_SUPVSR_LVL_TBL WHERE EFF_STATUS='A' ORDER BY SUPV_LVL_ID DESC";
                        rs = cmd.ExecuteReader();
                        while (rs.Read())
                        {
                            string val= (string)rs["SUPV_LVL_ID"];
                            string key = (string)rs["DESCR"];
                            keyValues[key] = val;
                        }
                    }

                }
                finally
                {
                    if (rs != null) rs.Close();
                    conn.Close();
                }
            }
            return keyValues;
        }
        #endregion

        #region GetEmployeeSupvLvl
        public static string GetEmployeeSupvLvl(string emplid, int year, int month)
        {
            Hashtable keyValues = new Hashtable();
            OleDbConnection conn = new OleDbConnection(MyHelper.GetPsConnectionString());
            using (conn)
            {
                OleDbDataReader rs = null;
                try
                {
                    conn.Open();
                    using (OleDbCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "SELECT SUPV_LVL_ID  FROM PS_JOB  WHERE EMPLID='" + emplid + "'AND EFFDT <=DATE'" + year +"-" + month + "-15' AND ROWNUM=1 ORDER BY EFFDT DESC";
                        rs = cmd.ExecuteReader();
                        if (rs.Read())
                        {
                            return (string)rs["SUPV_LVL_ID"];
                        }
                    }
                }
                finally
                {
                    if (rs != null) rs.Close();
                    conn.Close();
                }
            }
            return null;
        }
        #endregion

        #region GetEmplClasses

        //获取值列表
        public static Hashtable GetEmplClasses()
        {
            Hashtable keyValues = new Hashtable();
            OleDbConnection conn = new OleDbConnection(MyHelper.GetPsConnectionString());
            using (conn)
            {
                OleDbDataReader rs = null;
                try
                {
                    conn.Open();
                    using (OleDbCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "SELECT EMPL_CLASS, DESCR FROM SYSADM.PS_EMPL_CLASS_TBL WHERE SETID='CHN' AND EFF_STATUS='A'";
                        rs = cmd.ExecuteReader();
                        while (rs.Read())
                        {
                            string val = (string)rs["EMPL_CLASS"];
                            string key = (string)rs["DESCR"];
                            keyValues[key] = val;
                        }
                    }
                }
                finally
                {
                    if (rs != null) rs.Close();
                    conn.Close();
                }
            }
            return keyValues;
        }
        #endregion

        #region GetTechJobcodes

        //获取值列表
        public static Hashtable GetTechJobcodes(string supv_lvl_id)
        {
            Hashtable keyValues = new Hashtable();
            OleDbConnection conn = new OleDbConnection(MyHelper.GetPsConnectionString());
            using (conn)
            {
                OleDbDataReader rs = null;
                try
                {
                    conn.Open();
                    using (OleDbCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = String.Format("SELECT C_TECH_JOBCODE, DESCR  FROM SYSADM.PS_C_SUPV_TJOB_VW WHERE SUPV_LVL_ID='{0}' ORDER BY SUPV_LVL_ID,C_TECH_JOBCODE", supv_lvl_id);
                        rs = cmd.ExecuteReader();
                        while (rs.Read())
                        {
                            string val = (string)rs["C_TECH_JOBCODE"];
                            string key = (string)rs["DESCR"];
                            keyValues[key] = val;
                        }
                    }
                }
                finally
                {
                    if (rs != null) rs.Close();
                    conn.Close();
                }
            }
            return keyValues;
        }
        #endregion

        #region GetPositions

        //获取值列表
        public static Hashtable GetPositions()
        {
            Hashtable keyValues = new Hashtable();

            foreach (Position p in Position.职位表)
            {
                string val = p.职位号码;
                string key = p.职位描述;
                keyValues[key] = val;
            }

            return keyValues;
        }
                
        #endregion

        #region GetRevwRatings

        //获取评等值列表
        public static Hashtable GetRevwRatings(string ratingModel)
        {
            Hashtable keyValues = new Hashtable();
            OleDbConnection conn = new OleDbConnection(MyHelper.GetPsConnectionString());
            using (conn)
            {
                OleDbDataReader rs = null;
                try
                {
                    conn.Open();
                    using (OleDbCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = String.Format("SELECT REVIEW_RATING, DESCR FROM PS_REVW_RATING_TBL WHERE RATING_MODEL = '{0}' ORDER BY REVIEW_RATING", ratingModel);
                        rs = cmd.ExecuteReader();
                        while (rs.Read())
                        {
                            string key = (string)rs["DESCR"];
                            string val = (string)rs["REVIEW_RATING"];
                            keyValues[key] = val;
                        }
                    }
                }
                finally
                {
                    if (rs != null) rs.Close();
                    conn.Close();
                }
            }
            return keyValues;
        }
        #endregion

        #region GetAddressType

        public static Hashtable GetAddressType(string emplid)
        {
            Hashtable keyValues = new Hashtable();
            OleDbConnection conn = new OleDbConnection(MyHelper.GetPsConnectionString());
            using (conn)
            {
                OleDbDataReader rs = null;
                try
                {
                    conn.Open();
                    using (OleDbCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = String.Format("SELECT ADDRESS_TYPE, ADDR_TYPE_DESCR FROM PS_PERSON_ADDRESS WHERE EMPLID = '{0}'", emplid);
                        rs = cmd.ExecuteReader();
                        while (rs.Read())
                        {
                            string key = (string)rs["ADDR_TYPE_DESCR"];
                            string val = (string)rs["ADDRESS_TYPE"];
                            keyValues[key] = val;
                        }
                    }
                }
                finally
                {
                    if (rs != null) rs.Close();
                    conn.Close();
                }
            }
            return keyValues;
        }
        #endregion
        
        #region GetHrBusinessUnitTable
        /// <summary>
        /// 获取HR业务单位表
        /// </summary>
        /// <returns></returns>
        public static Hashtable GetHrBusinessUnitTable()
        {
            Hashtable keyValues = new Hashtable();
            OleDbConnection conn = new OleDbConnection(MyHelper.GetPsConnectionString());
            using (conn)
            {
                OleDbDataReader rs = null;
                try
                {
                    conn.Open();
                    using (OleDbCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "select A.Business_Unit, A.Descrshort from ps_BUS_UNIT_TBL_HR A where A.Active_Inactive = 'A'";
                        rs = cmd.ExecuteReader();
                        while (rs.Read())
                        {
                            string key = (string)rs["Descrshort"];
                            string val = (string)rs["Business_Unit"];
                            keyValues[key] = val;
                        }
                    }
                }
                finally
                {
                    if (rs != null) rs.Close();
                    conn.Close();
                }
            }
            return keyValues;
        }
        #endregion

        #region GetSILTable
        /// <summary>
        /// 获取指定业务单位的社保缴纳地编码表
        /// </summary>
        /// <param name="emplid"></param>
        /// <returns></returns>
        public static Hashtable GetSILTable(string businessUnit)
        {
            Hashtable keyValues = new Hashtable();
            OleDbConnection conn = new OleDbConnection(MyHelper.GetPsConnectionString());
            using (conn)
            {
                OleDbDataReader rs = null;
                try
                {
                    conn.Open();
                    using (OleDbCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = String.Format("select A.C_SIL_CD, A.C_SIL_DESCR from ps_C_SIL_TBL A where A.BUSINESS_UNIT = '{0}'", businessUnit);
                        rs = cmd.ExecuteReader();
                        while (rs.Read())
                        {
                            string key = (string)rs["C_SIL_DESCR"];
                            string val = (string)rs["C_SIL_CD"];
                            keyValues[key] = val;
                        }
                    }
                }
                finally
                {
                    if (rs != null) rs.Close();
                    conn.Close();
                }
            }
            return keyValues;
        }
        #endregion

        #region GetSIRTable
        /// <summary>
        /// 获取指定业务单位指定社保缴纳地的规则编码表
        /// </summary>
        /// <param name="emplid"></param>
        /// <returns></returns>
        public static Hashtable GetSIRTable(string businessUnit, string sil)
        {
            Hashtable keyValues = new Hashtable();
            OleDbConnection conn = new OleDbConnection(MyHelper.GetPsConnectionString());
            using (conn)
            {
                OleDbDataReader rs = null;
                try
                {
                    conn.Open();
                    using (OleDbCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = String.Format("select C_SIR_CD, C_SIR_DESCR from ps_C_SIR_SRCH_VW A where A.BUSINESS_UNIT = '{0}' AND C_SIL_CD='{1}'", businessUnit, sil);
                        rs = cmd.ExecuteReader();
                        while (rs.Read())
                        {
                            string key = (string)rs["C_SIR_DESCR"];
                            string val = (string)rs["C_SIR_CD"];
                            keyValues[key] = val;
                        }
                    }
                }
                finally
                {
                    if (rs != null) rs.Close();
                    conn.Close();
                }
            }
            return keyValues;
        }
        #endregion

        #region GetCompanyCode

        public static string GetCompanyCode(string name)
        {
            OleDbConnection conn = new OleDbConnection(MyHelper.GetPsConnectionString());
            using (conn)
            {
                OleDbDataReader rs = null;
                try
                {
                    conn.Open();
                    using (OleDbCommand cmd = conn.CreateCommand())
                    {

                        cmd.CommandText = "select company, descrshort from sysadm.ps_COMPANY_TBL where eff_status = 'A' and descrshort='" + name + "' order by company";
                        rs = cmd.ExecuteReader();
                        if (rs.Read())
                        {
                          return (string)rs["company"];
                        }
                    }
                }
                finally
                {
                    if (rs != null) rs.Close();
                    conn.Close();
                }
            }
            return null;
        }

        #endregion

        #region GetCompanyTable
        /// <summary>
        /// 获取公司表
        /// </summary>
        /// <returns></returns>
        public static Hashtable GetCompanyTable()
        {
            Hashtable keyValues = new Hashtable();
            OleDbConnection conn = new OleDbConnection(MyHelper.GetPsConnectionString());
            using (conn)
            {
                OleDbDataReader rs = null;
                try
                {
                    conn.Open();
                    using (OleDbCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "select company, descrshort from sysadm.ps_COMPANY_TBL where eff_status = 'A' order by company";
                        rs = cmd.ExecuteReader();
                        while (rs.Read())
                        {
                            string key = (string)rs["descrshort"];
                            string val = (string)rs["company"];
                            keyValues[key] = val;
                        }
                    }
                }
                finally
                {
                    if (rs != null) rs.Close();
                    conn.Close();
                }
            }
            return keyValues;
        }
        #endregion

        #region GetCompanyList
        /// <summary>
        /// 获取公司表
        /// </summary>
        /// <returns></returns>
        public static List<string> GetCompanyList()
        {
            List<string> list = new List<string>();
            OleDbConnection conn = new OleDbConnection(MyHelper.GetPsConnectionString());
            using (conn)
            {
                OleDbDataReader rs = null;
                try
                {
                    conn.Open();
                    using (OleDbCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "select company, descr from sysadm.ps_COMPANY_TBL where eff_status = 'A' order by company";
                        rs = cmd.ExecuteReader();
                        while (rs.Read())
                        {
                            list.Add((string)rs["descr"]);
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

        #region GetEntryTypeTable

        public static Hashtable GetEntryTypeTable()
        {
            Hashtable keyValues = new Hashtable();
            OleDbConnection conn = new OleDbConnection(MyHelper.GetPsConnectionString());
            using (conn)
            {
                OleDbDataReader rs = null;
                try
                {
                    conn.Open();
                    using (OleDbCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "select ENTRY_TYPE_ID, DESCR from sysadm.ps_GP_ENT_OVRD4_VW";
                        rs = cmd.ExecuteReader();
                        while (rs.Read())
                        {
                            string key = (string)rs["DESCR"];
                            string val = (string)rs["ENTRY_TYPE_ID"];
                            keyValues[key] = val;
                        }
                    }
                }
                finally
                {
                    if (rs != null) rs.Close();
                    conn.Close();
                }
            }
            return keyValues;
        }
        #endregion

        #region GetElements

        public static Hashtable GetElements(string type)
        {
            return GetElements(type, null);
        }

        public static Hashtable GetElements(string type, string valueType)
        {
            Hashtable keyValues = new Hashtable();
            List<ElementInfo> list = ElementInfo.薪资元素表;
            if (!string.IsNullOrEmpty(type)) list = ElementInfo.薪资元素表.FindAll(a => a.元素类型 == type);
            foreach (ElementInfo el in list)
            {
                string key = el.描述;
                keyValues[key] = valueType == "名称" ? el.元素名称 : el.元素编码;
            }
            return keyValues;
        }
        #endregion

        #region GetValue

        public static string GetValue(Hashtable table, string key)
        {
            if (key == null) return "";
            List<KeyValue> list = KeyValue.GetList(table);
            KeyValue kv = list.Find(a => a.键 == key.Trim());
            if (kv != null)
                return kv.值;
            else
                return "";
        }
        #endregion

        #region GetKey

        public static string GetKey(Hashtable table, string val)
        {
            if (val == null) return "";
            List<KeyValue> list = KeyValue.GetList(table);
            KeyValue kv = list.Find(a => a.值 == val.Trim());
            if (kv != null)
                return kv.键;
            else
                return "";
        }
        #endregion

        #region GetKpiList

        public static Hashtable GetKpiList(string company)
        {
            Hashtable keyValues = new Hashtable();
            List<KpiInfo> list = KpiInfo.考核项目表;
            if (!string.IsNullOrEmpty(company)) list = list.FindAll(a => a.公司 == company);
            foreach (KpiInfo el in list)
            {
                string key = el.名称;
                keyValues[key] = el.KPI_ID;
            }
            return keyValues;
        }
        #endregion

        #region GetGpCalRunTable
        /// <summary>
        /// 获取日历组清单
        /// </summary>
        /// <param name="emplid"></param>
        /// <returns></returns>
        public static Hashtable GetGpCalRunTable()
        {
            Hashtable keyValues = new Hashtable();
            OleDbConnection conn = new OleDbConnection(MyHelper.GetPsConnectionString());
            using (conn)
            {
                OleDbDataReader rs = null;
                try
                {
                    conn.Open();
                    using (OleDbCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "select distinct substr(A.cal_run_id,9, 6) as idx, A.CAL_RUN_ID,A.DESCR, B.CAL_PRD_ID, C.PRD_BGN_DT, C.PRD_END_DT from SYSADM.ps_GP_CAL_RUN A left join SYSADM.ps_GP_CAL_RUN_DTL B ON A.cal_run_id = B.cal_run_id  left join SYSADM.ps_GP_CAL_PRD C ON C.cal_prd_id = B.CAL_PRD_ID where RUN_FINALIZED_IND='Y' AND C.PRD_BGN_DT <= sysdate  order by idx desc";
                        rs = cmd.ExecuteReader();
                        while (rs.Read())
                        {
                            string key = (string)rs["DESCR"];
                            string val = (string)rs["CAL_RUN_ID"];
                            keyValues[key] = val;
                        }
                    }
                }
                finally
                {
                    if (rs != null) rs.Close();
                    conn.Close();
                }
            }
            return keyValues;
        }
        #endregion

        #region GetPersonTaxPoint

        //获取个税起征点
        public static decimal GetPersonTaxPoint(DateTime date)
        {
            OleDbConnection conn = new OleDbConnection(MyHelper.GetPsConnectionString());
            using (conn)
            {
                OleDbDataReader rs = null;
                try
                {
                    conn.Open();
                    using (OleDbCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "SELECT data_val1_dec FROM sysadm.ps_GP_BRACKET_DTL A WHERE  DATA_KEY1='LOC' and effdt = (SELECT  max(effdt) FROM sysadm.ps_GP_BRACKET_DTL B where DATA_KEY1='LOC' AND B.effdt < date'" + date.ToString("yyyy-M-d") + "')";
                        rs = cmd.ExecuteReader();
                        if (rs.Read())
                        {
                            return Convert.ToDecimal(rs["data_val1_dec"]);
                        }
                    }
                }
                finally
                {
                    if (rs != null) rs.Close();
                    conn.Close();
                }
                return 0;
            }
        }
        #endregion

        #region GetEmpDept

        //获取员工所在部门编号
        public static string GetEmpDept(string emplid, DateTime date)
        {
            OleDbConnection conn = new OleDbConnection(MyHelper.GetPsConnectionString());
            using (conn)
            {
                OleDbDataReader rs = null;
                try
                {
                    conn.Open();
                    using (OleDbCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = String.Format("SELECT DEPTID FROM PS_JOB WHERE EMPLID='{0}' AND EFFDT <= DATE'{1}' AND ROWNUM = 1 ORDER BY EFFDT DESC", emplid, date.ToString("yyyy-M-d"));
                        rs = cmd.ExecuteReader();
                        if (rs.Read())
                        {
                            return Convert.ToString(rs["DEPTID"]);
                        }
                    }

                }
                finally
                {
                    if (rs != null) rs.Close();
                    conn.Close();
                }
                return null;
            }
        }
        #endregion

        #region GetSalaryGrades

        //获取工资基础信息
        public static SalaryBaseInfo GetSalaryGrade(string emplid, DateTime date)
        {
            OleDbConnection conn = new OleDbConnection(MyHelper.GetPsConnectionString());
            using (conn)
            {
                OleDbDataReader rs = null;
                try
                {
                    conn.Open();
                    using (OleDbCommand cmd = conn.CreateCommand())
                    {

                        string sql = "SELECT SETID_SALARY, SAL_ADMIN_PLAN,GRADE FROM SYSADM.PS_JOB P WHERE P.EMPLID = '" + emplid + "' AND P.EMPL_RCD = 0 "
                         + " AND P.EFFDT = (SELECT MAX(PE.EFFDT) FROM SYSADM.PS_JOB PE WHERE PE.EMPLID = P.EMPLID "
                         + " AND PE.EMPL_RCD = P.EMPL_RCD"
                         + " AND PE.EFFDT <= Date'" + date.Date.ToString("yyyy-M-d") + "')"
                         + " AND P.EFFSEQ = (SELECT MAX(PE.EFFSEQ)"
                         + " FROM SYSADM.PS_JOB PE"
                         + " WHERE PE.EMPLID = P.EMPLID"
                         + " AND PE.EMPL_RCD = P.EMPL_RCD"
                         + " AND PE.EFFDT = P.EFFDT)";

                        cmd.CommandText = sql;
                        rs = cmd.ExecuteReader();
                        if (rs.Read())
                        {
                            string setid = Convert.ToString(rs["SETID_SALARY"]);
                            string sal_admin_plan = Convert.ToString(rs["SAL_ADMIN_PLAN"]);
                            string grade = Convert.ToString(rs["GRADE"]);

                            rs.Close();

                            sql = String.Format("select * from (select * from SYSADM.PS_SAL_GRADE_TBL where setid='{0}' and sal_admin_plan='{1}' and grade='{2}' and eff_status='A' order by effdt desc) where rownum = 1", setid, sal_admin_plan, grade);
                            cmd.CommandText = sql;
                            rs = cmd.ExecuteReader();
                            if (rs.Read())
                            {
                                SalaryBaseInfo sg = new SalaryBaseInfo();

                                sg.员工编号 = emplid;
                                sg.基准工资 = Convert.ToDecimal(rs["C_BASIC_PAY"]);
                                sg.年休假工资 = Convert.ToDecimal(rs["C_ANUL_LEAV_PAY"]);
                                sg.上表工资标准 = Convert.ToDecimal(rs["C_OPEN_PAY"]);
                                sg.设定工资 = Convert.ToDecimal(rs["C_GP_SET_PAY"]);
                                sg.满勤奖金额 = GetFullAttendancePayFromCache(sal_admin_plan, grade, date);

                                return sg;
                            }
                        }

                    }
                }
                finally
                {
                    if (rs != null) rs.Close();
                    conn.Close();
                }
            }
            return null;
        }
        #endregion

        #region 获取未年休假加班工资

        //获取未年休假加班工资
        public static decimal GetVacPayFromCache(string salplan, string grade, DateTime date)
        {
            string key = salplan + "$$" + grade + "$$" + date.ToString("yyyy-M-d");
            return VAC_PAY_CACHE.Get(key, () => GetVacPay(salplan, grade, date), TimeSpan.FromHours(8));
        }

        public static decimal GetVacPay(string salplan, string grade, DateTime date)
        {
            OleDbConnection conn = new OleDbConnection(MyHelper.GetPsConnectionString());
            using (conn)
            {
                OleDbDataReader rs = null;
                try
                {

                    conn.Open();
                    using (OleDbCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = String.Format("SELECT C_ANUL_LEAV_PAY FROM sysadm.PS_SAL_GRADE_TBL WHERE rownum=1 and SETID= 'SHARE' AND SAL_ADMIN_PLAN='{0}' AND GRADE= '{1}'AND EFFDT<= date'{2}' order by effdt desc", salplan, grade, date.ToString("yyyy-M-d"));
                        rs = cmd.ExecuteReader();
                        if (rs.Read())
                        {
                            string key = salplan + "$$" + grade + "$$" + date.ToString("yyyy-M-d");
                            decimal value = Convert.ToDecimal(rs["C_ANUL_LEAV_PAY"]);
                            //缓存
                            VAC_PAY_CACHE.Set(key, value, TimeSpan.FromHours(8));
                            return value;
                        }
                    }

                }
                finally
                {
                    if (rs != null) rs.Close();
                    conn.Close();
                }
                return 0;
            }
        }

        #endregion

        #region GetFullAttendancePay

        public static decimal GetFullAttendancePayFromCache(string salplan, string grade, DateTime date)
        {
            string key = salplan + "$$" + grade + "$$" + date.ToString("yyyy-M-d");
            return FULLATTENDANCEPAY_CACHE.Get(key, () => GetFullAttendancePay(salplan, grade, date), TimeSpan.FromHours(8));
        }
        //获取满勤奖
        public static decimal GetFullAttendancePay(string salplan, string grade, DateTime date)
        {
            OleDbConnection conn = new OleDbConnection(MyHelper.GetPsConnectionString());
            using (conn)
            {
                OleDbDataReader rs = null;
                try
                {

                    conn.Open();
                    using (OleDbCommand cmd = conn.CreateCommand())
                    {
                        //cmd.CommandText = String.Format("SELECT DATA_VAL1_DEC FROM SYSADM.PS_GP_BRACKET_DTL WHERE PIN_NUM='250608' AND EFFDT=(SELECT MAX(EFFDT) FROM SYSADM.PS_GP_BRACKET_DTL WHERE PIN_NUM='250608' AND DATA_KEY1='{0}' AND DATA_KEY2='{1}') AND DATA_KEY1='{0}' AND DATA_KEY2='{1}'", salplan, grade);
                        cmd.CommandText = String.Format("SELECT DATA_VAL1_DEC, DATA_VAL2_DEC, DATA_KEY1 SAL_ADMIN_PLAN,DATA_KEY2 GRADE FROM sysadm.PS_GP_BRACKET_DTL C  WHERE C.EFFDT = (SELECT MAX(CA.EFFDT) FROM sysadm.PS_GP_BRACKET_DTL CA WHERE CA.PIN_NUM = C.PIN_NUM AND CA.EFFDT <= date'{0}') AND C.PIN_NUM = 250608  AND DATA_KEY1='{1}' AND DATA_KEY2='{2}'", date.ToString("yyyy-M-d"), salplan, grade);
                        rs = cmd.ExecuteReader();
                        if (rs.Read())
                        {
                            string key = salplan + "$$" + grade + "$$" + date.ToString("yyyy-M-d");
                            decimal value = Convert.ToDecimal(rs["DATA_VAL2_DEC"]);
                            //缓存
                            FULLATTENDANCEPAY_CACHE.Set(key, value, TimeSpan.FromHours(8));
                            return value;
                        }
                    }

                }
                finally
                {
                    if (rs != null) rs.Close();
                    conn.Close();
                }
                return 0;
            }
        }
        #endregion

        #region GetWorkAge

        //SELECT SERVICE_AMOUNT FROM PS_C_PER_WKLIF_TBL WHERE EMPLID='A013519' AND PRD_BGN_DT=DATE'2017-02-01'
        //获取工龄
        public static decimal GetWorkAge(string number, DateTime date)
        {
            OleDbConnection conn = new OleDbConnection(MyHelper.GetPsConnectionString());
            using (conn)
            {
                OleDbDataReader rs = null;
                try
                {

                    conn.Open();
                    using (OleDbCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = String.Format("SELECT SERVICE_AMOUNT FROM PS_C_PER_WKLIF_TBL WHERE EMPLID='{0}' AND PRD_BGN_DT<=DATE'{1}' AND ROWNUM=1 ORDER BY PRD_BGN_DT DESC ", number, date.ToString("yyyy-MM-dd"));
                        rs = cmd.ExecuteReader();
                        if (rs.Read())
                        {
                            return Convert.ToDecimal(rs["SERVICE_AMOUNT"]);
                        }
                    }
                }
                finally
                {
                    if (rs != null) rs.Close();
                    conn.Close();
                }
                return 0;
            }
        }
        #endregion

        #region GetTrafficSubsidies

        //获取员工交通补助餐饮补助
        public static decimal GetTrafficSubsidies(string emplid, DateTime date)
        {
            OleDbConnection conn = new OleDbConnection(MyHelper.GetPsConnectionString());
            using (conn)
            {
                OleDbDataReader rs = null;
                try
                {
                    conn.Open();
                    using (OleDbCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = String.Format("SELECT GP_AMT FROM SYSADM.PS_GP_PYE_OVRD WHERE PIN_NUM='251234' AND EMPLID= '{0}' AND BGN_DT<=DATE'{1}' AND ROWNUM = 1  ORDER BY BGN_DT DESC", emplid, date.ToString("yyyy-M-d"));
                        rs = cmd.ExecuteReader();
                        if (rs.Read())
                        {
                            return Convert.ToDecimal(rs["GP_AMT"]);
                        }
                    }

                }
                finally
                {
                    if (rs != null) rs.Close();
                    conn.Close();
                }
                return 0;
            }
        }
        #endregion

        #region GetBankTable
        /// <summary>
        /// 获取公司表
        /// </summary>
        /// <returns></returns>
        public static Hashtable GetBankTable()
        {
            Hashtable keyValues = new Hashtable();
            OleDbConnection conn = new OleDbConnection(MyHelper.GetPsConnectionString());
            using (conn)
            {
                OleDbDataReader rs = null;
                try
                {
                    conn.Open();
                    using (OleDbCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "select BANK_CD, BANK_NM from sysadm.ps_BANK_EC_TBL where EFF_STATUS='A' order by BANK_CD";
                        rs = cmd.ExecuteReader();
                        while (rs.Read())
                        {
                            string key = (string)rs["BANK_NM"];
                            string val = (string)rs["BANK_CD"];
                            keyValues[key] = val;
                        }
                    }
                }
                finally
                {
                    if (rs != null) rs.Close();
                    conn.Close();
                }
            }
            return keyValues;
        }
        #endregion

        #region GetBankBranchTable
        /// <summary>
        /// 获取银行分行明细
        /// </summary>
        /// <returns></returns>
        public static Hashtable GetBankBranchTable(string bank)
        {
            Hashtable keyValues = new Hashtable();
            OleDbConnection conn = new OleDbConnection(MyHelper.GetPsConnectionString());
            using (conn)
            {
                OleDbDataReader rs = null;
                try
                {
                    conn.Open();
                    using (OleDbCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = String.Format("select branch_ec_cd, descrshort from sysadm.ps_BANK_BRANCH_TBL where BANK_CD='{0}' and EFF_STATUS='A'", bank);
                        rs = cmd.ExecuteReader();
                        while (rs.Read())
                        {
                            string key = (string)rs["descrshort"];
                            string val = (string)rs["branch_ec_cd"];
                            keyValues[key] = val;
                        }
                    }
                }
                finally
                {
                    if (rs != null) rs.Close();
                    conn.Close();
                }
            }
            return keyValues;
        }
        #endregion
    }
}
