using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using log4net;
using DevExpress.Data.Filtering;
using System.Data.SqlClient;
using Hwagain;
using YiKang;
using System.Data.OleDb;
using Hwagain.Components;

namespace Hwagain.SalaryCalculation.Components
{
    public partial class SalaryResult
    {
        static readonly ILog log = LogManager.GetLogger(typeof(SalaryResult));

        public static ICache<string, SalaryResult> SALARY_RESULT_CACHE = MemoryCache<string, SalaryResult>.Instance;

        #region GetSalaryResult
        /// <summary>
        /// 通过 Id 获取
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static SalaryResult GetSalaryResult(Guid id)
        {
            SalaryResult obj = (SalaryResult)MyHelper.XpoSession.GetObjectByKey(typeof(SalaryResult), id);
            return obj;
        }
        /// <summary>
        /// 每个员工每月只有一条工资条
        /// </summary>
        /// <param name="empNo"></param>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        public static SalaryResult GetSalaryResult(string empNo, int year, int month)
        {
            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                       new BinaryOperator("员工编号", empNo, BinaryOperatorType.Equal),
                       new BinaryOperator("年度", year, BinaryOperatorType.Equal),
                       new BinaryOperator("月份", month, BinaryOperatorType.Equal)
                       );

            XPCollection objset = new XPCollection(MyHelper.XpoSession, typeof(SalaryResult), criteria, new SortProperty("上次同步时间", SortingDirection.Descending));

            if (objset.Count > 0)
            {
                return (SalaryResult)objset[0];
            }
            else
                return null;
        }
        #endregion

        #region GetFromCache

        public static SalaryResult GetFromCache(string empNo, int year, int month)
        {
            string key = empNo + "$$" + year + "$$" + month;
            return SALARY_RESULT_CACHE.Get(key, () => GetSalaryResult(empNo, year, month), TimeSpan.FromHours(8));

        }
        #endregion

        #region AddSalaryResult

        public static SalaryResult AddSalaryResult(string empNo, int year, int month)
        {
            SalaryResult sr = GetFromCache(empNo, year, month);
            if (sr == null)
            {
                sr = new SalaryResult();
                sr.标识 = Guid.NewGuid();
                sr.员工编号 = empNo;
                sr.年度 = year;
                sr.月份 = month;
                sr.Save();
            }
            return sr;
        }
        #endregion

        #region GetSalaryResults

        public static List<SalaryResult> GetSalaryResults(string calId)
        {
            List<SalaryResult> list = new List<SalaryResult>();

            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                       new BinaryOperator("日历组", calId, BinaryOperatorType.Equal)
                       );

            XPCollection objset = new XPCollection(MyHelper.XpoSession, typeof(SalaryResult), criteria, new SortProperty("公司编号", SortingDirection.Ascending), new SortProperty("部门编号", SortingDirection.Ascending), new SortProperty("薪等编号", SortingDirection.Ascending));

            foreach (SalaryResult order in objset)
            {
                list.Add(order);
            }
            return list;
        }
        public static List<SalaryResult> GetSalaryResults(string payGroup, string calRunId)
        {
            List<SalaryResult> list = new List<SalaryResult>();

            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                       new BinaryOperator("薪资组", payGroup, BinaryOperatorType.Equal),
                       new BinaryOperator("日历组", calRunId, BinaryOperatorType.Equal)
                       );

            XPCollection objset = new XPCollection(MyHelper.XpoSession, typeof(SalaryResult), criteria, new SortProperty("薪等编号", SortingDirection.Ascending));

            foreach (SalaryResult order in objset)
            {
                list.Add(order);
            }
            return list;
        }

        public static List<SalaryResult> GetSalaryResults(int year, int month, string company, string payGroup)
        {
            List<SalaryResult> list = new List<SalaryResult>();

            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                       new BinaryOperator("年度", year, BinaryOperatorType.Equal),
                       new BinaryOperator("月份", month, BinaryOperatorType.Equal)
                       );

            if (payGroup != null) criteria.Operands.Add(new BinaryOperator("薪资组", payGroup, BinaryOperatorType.Equal));

            XPCollection objset = new XPCollection(MyHelper.XpoSession, typeof(SalaryResult), criteria, new SortProperty("员工序号", SortingDirection.Ascending));

            foreach (SalaryResult item in objset)
            {
                if (company != null)
                {
                    if (item.财务公司 == company) list.Add(item);
                }
                else
                    list.Add(item);
            }

            return list;
        }

        public static List<SalaryResult> GetSalaryResults(int year, int month, string companyCode)
        {
            List<SalaryResult> list = new List<SalaryResult>();

            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                       new BinaryOperator("年度", year, BinaryOperatorType.Equal),
                       new BinaryOperator("月份", month, BinaryOperatorType.Equal)
                       );
            
            XPCollection objset = new XPCollection(MyHelper.XpoSession, typeof(SalaryResult), criteria, new SortProperty("员工序号", SortingDirection.Ascending));

            foreach (SalaryResult item in objset)
            {
                if (companyCode != null)
                {
                    if (item.所在部门 != null && item.所在部门.公司 != null && 
                        item.所在部门.公司.部门编号 == companyCode) 
                        list.Add(item);
                }
                else
                    list.Add(item);
            }

            return list;
        }
        #endregion
        
        #region GetEmployeeList

        public static List<EmployeeInfo> GetEmployeeList(int year, int month, string company_code, string grade, bool onlyOnJob)
        {
            List<EmployeeInfo> list = new List<EmployeeInfo>();

            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                      new BinaryOperator("年度", year, BinaryOperatorType.Equal),
                      new BinaryOperator("月份", month, BinaryOperatorType.Equal)
                      );

            if (company_code != null) criteria.Operands.Add(new BinaryOperator("公司编号", company_code, BinaryOperatorType.Equal));
            if (grade != null) criteria.Operands.Add(new BinaryOperator("工资职等", grade, BinaryOperatorType.Equal));

            XPCollection objset = new XPCollection(typeof(SalaryResult), criteria, new SortProperty("部门编号", SortingDirection.Ascending), new SortProperty("职务等级", SortingDirection.Ascending), new SortProperty("员工序号", SortingDirection.Ascending));

            foreach (SalaryResult item in objset)
            {
                EmployeeInfo emp = item.员工信息;
                //只要在职员工
                if (onlyOnJob)
                {
                    if(emp.状态 == "A") list.Add(emp);
                }
                else
                    list.Add(emp);
            }
            return list;
        }
        #endregion

        #region GetTrainees

        //获取管培生名单
        public static List<EmployeeInfo> GetTrainees(int year, int month, bool onlyOnJob)
        {
            List<EmployeeInfo> list = new List<EmployeeInfo>();

            XPQuery<SalaryResult> salaryResults = MyHelper.XpoSession.Query<SalaryResult>();
            XPQuery<EmployeeInfo> employees = MyHelper.XpoSession.Query<EmployeeInfo>();

            var l = from s in salaryResults
                    join e in employees on s.员工编号 equals e.员工编号
                    where (s.年度 == year && s.月份 == month && e.是管培生)
                    select e;

            foreach (EmployeeInfo emp in l)
            {
                //只要在职员工
                if (onlyOnJob)
                {
                    if (emp.状态 == "A") list.Add(emp);
                }
                else
                    list.Add(emp);
            }
            return list;
        }

        #endregion

        #region DeleteAll

        //删除指定月份的工资表
        static bool DeleteAll(int year, int month)
        {
            try
            {
                string sql = String.Format("DELETE FROM 基础工资表 WHERE 年度={0} AND 月份={1}", year, month);
                using (SqlConnection connection = new SqlConnection(MyHelper.GetConnectionString()))
                {
                    YiKang.Data.SqlHelper.ExecuteNonQuery(connection, System.Data.CommandType.Text, sql);
                    connection.Close();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region OnLoaded

        protected override void OnLoaded()
        {
            bool changed = false;

            if (string.IsNullOrEmpty(this.公司名称))
            {
                CompanyInfo company = CompanyInfo.Get(this.公司编号);
                if (company != null)
                {
                    this.公司名称 = company.公司名称;
                    changed = true;
                }
            }

            if (string.IsNullOrEmpty(this.薪等名称))
            {
                SalaryGrade grade = SalaryGrade.Get(this.薪资集合, this.薪酬体系编号, this.薪等编号, new DateTime(this.年度, this.月份, 1));
                if (grade != null)
                {
                    this.薪等名称 = grade.薪等名称;
                    changed = true;
                }
            }
            if (string.IsNullOrEmpty(this.薪资组名称))
            {
                PayGroup group = PayGroup.Get(this.薪资组);
                if (group != null)
                {
                    this.薪资组名称 = group.中文名;
                    changed = true;
                }
            }
            //2018-2-11
            if (string.IsNullOrEmpty(this.工资职等))
            {
                this.工资职等 = GetGrade(this);
                changed = true;
            }
            if (changed) this.Save();
            base.OnLoaded();

            SALARY_RESULT_CACHE.Set(CacheKey, this, TimeSpan.FromHours(8));
        }
        #endregion

        #region OnSaved

        protected override void OnSaved()
        {            
            base.OnSaved();
            SALARY_RESULT_CACHE.Set(CacheKey, this, TimeSpan.FromHours(8));
        }
        #endregion

        #region CheckCalRunFinalized

        /// <summary>
        /// 检查日历组是否已经算薪完成
        /// </summary>
        /// <param name="calRunId"></param>
        /// <returns></returns>
        public static bool CheckCalRunFinalized(string calRunId)
        {
            bool ret = false;

            OleDbConnection conn = new OleDbConnection(MyHelper.GetPsConnectionString());
            using (conn)
            {
                OleDbDataReader rs = null;
                try
                {
                    conn.Open();
                    using (OleDbCommand cmd = conn.CreateCommand())
                    {
                        string sql = String.Format("select CAL_RUN_ID, RUN_FINALIZED_IND from SYSADM.ps_GP_CAL_RUN where CAL_RUN_ID='{0}' AND RUN_FINALIZED_IND='Y'", calRunId);
                        cmd.CommandText = sql;
                        rs = cmd.ExecuteReader();
                        if (rs.Read())
                        {
                            ret = true;
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

        #region SychSalaryResult

        /// <summary>
        /// 同步上月工资明细
        /// </summary>
        /// <returns></returns>
        public static StringBuilder SychSalaryResult()
        {
            List<CalRunInfo> cals = new List<CalRunInfo>();
            StringBuilder sb = new StringBuilder();

            DateTime prevMonth = DateTime.Now.AddMonths(-1);
            DateTime prd_begin = new DateTime(prevMonth.Year, prevMonth.Month, 1);
            OleDbConnection conn = new OleDbConnection(MyHelper.GetPsConnectionString());
            using (conn)
            {
                OleDbDataReader rs = null;
                try
                {
                    conn.Open();
                    using (OleDbCommand cmd = conn.CreateCommand())
                    {
                        string sql = String.Format("select distinct A.CAL_RUN_ID,A.DESCR, RUN_FINALIZED_IND, B.CAL_PRD_ID, C.PRD_BGN_DT, C.PRD_END_DT from SYSADM.ps_GP_CAL_RUN A left join SYSADM.ps_GP_CAL_RUN_DTL B ON A.cal_run_id = B.cal_run_id  left join SYSADM.ps_GP_CAL_PRD C ON C.cal_prd_id = B.CAL_PRD_ID where C.PRD_BGN_DT = date'{0:yyyy-M-d}'", prd_begin);
                        cmd.CommandText = sql;
                        rs = cmd.ExecuteReader();
                        while (rs.Read())
                        {
                            bool finalized = (string)rs["RUN_FINALIZED_IND"] == "Y";
                            if (finalized)
                            {
                                string cal_run_id = (string)rs["CAL_RUN_ID"];

                                CalRunInfo cal = CalRunInfo.Get(cal_run_id);
                                if (cal != null)
                                {
                                    cals.Add(cal);
                                    WageLoan.AutoGenerateMonthlyWageLoanItems(cal.年度, cal.月份);                                    
                                }
                            }
                        }

                        rs.Close();

                        foreach (CalRunInfo cal in cals)
                        {
                            string cal_run_id = cal.日历组编号;

                            foreach (string groupId in cal.薪资组列表)
                            {

#if (DEBUG)
                                StringBuilder msgBuilder = SychSalaryResult(cal_run_id, groupId);
                                sb.Append(msgBuilder.ToString());

                                StringBuilder msgBuilderItem = SalaryResultItem.SychSalaryResultItem(cal_run_id, groupId);
                                sb.Append(msgBuilderItem.ToString());
#else

                                SalaryAuditingResult sar = SalaryAuditingResult.AddSalaryAuditingResult(groupId, cal_run_id);

                                if (sar.上表工资已审核) continue;

                                if (sar.已审核 || sar.已冻结)
                                {
                                    sb.Append(String.Format("薪资组{0}, 日历组（{0}）的工资已审核或者已冻结，不能重新同步。", groupId, cal_run_id));
                                    return sb;
                                }
                                else
                                {
                                    StringBuilder msgBuilder = SychSalaryResult(cal_run_id, groupId);
                                    sb.Append(msgBuilder.ToString());

                                    StringBuilder msgBuilderItem = SalaryResultItem.SychSalaryResultItem(cal_run_id, groupId);
                                    sb.Append(msgBuilderItem.ToString());

                                }
#endif
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
            return sb;
        }

        public static StringBuilder SychSalaryResult(string calRunId, string payGroup)
        {
            StringBuilder sb = new StringBuilder();

            CalRunInfo calRun = CalRunInfo.Get(calRunId);
            if (calRun == null)
            {
                sb.Append(String.Format("指定的日历组（{0}）不存在，无法同步。", calRunId));
                return sb;
            }

            if (CheckCalRunFinalized(calRunId) == false)
            {
                sb.Append(String.Format("日历组（{0}）的上表工资计算未完成，不能同步。", calRunId));
                return sb;
            }           

            List<SalResult> list = SalResult.GetList(calRunId, payGroup);
            //删除历史数据
            SalaryAuditingResult.ClearAuditingResult(calRunId, payGroup);
            
            #region 保存PS系统的上表工资数据

            foreach (SalResult sr in list)
            {
                if (!SychSalaryResult(sr))
                {
                    //删除历史数据
                    SalaryAuditingResult.ClearAuditingResult(calRunId, payGroup);
                    sb.Append("同步工资结果失败:" + sr.ToString<SalResult>());
                    break;
                }
            }
            #endregion

            return sb;
        }

        #region SychSalaryResult

        private static bool SychSalaryResult(SalResult sr)
        {
            try
            {

                SalaryResult item = AddSalaryResult(sr.员工编号, sr.年度, sr.月份);

                #region 日历信息

                item.日历组 = sr.日历组;
                item.期间 = sr.期间;

                #endregion

                item.姓名 = sr.姓名;
                item.员工类型 = sr.员工类型;
                item.身份证号 = sr.身份证号;

                #region 所属机构

                item.公司编号 = sr.公司编号;
                item.机构编号 = sr.机构编号;
                item.部门编号 = sr.部门编号;
                item.公司名称 = sr.公司名称;
                item.部门名称 = sr.部门名称;
                
                #endregion

                #region 财务信息

                item.银行账号 = sr.银行账号;
                item.帐户名称 = sr.帐户名称;

                GetSeq(sr, item);

                #endregion

                #region 薪酬体系

                item.薪资组 = sr.薪资组.Trim();
                item.薪资集合 = sr.薪资集合;
                item.薪酬体系编号 = sr.薪酬体系编号;
                item.薪等编号 = sr.薪等编号;
                item.薪级编号 = sr.薪级编号;

                SalaryGrade grade = SalaryGrade.Get(item.薪资集合, item.薪酬体系编号, item.薪等编号, new DateTime(item.年度, item.月份, 1));
                if (grade != null)
                {
                    item.薪等名称 = grade.薪等名称;
                }

                PayGroup group = PayGroup.Get(item.薪资组);
                if (group != null)
                {
                    item.薪资组名称 = group.中文名;
                }

                #endregion

                #region 职务数据

                item.职务代码 = sr.职务代码;
                item.职务等级 = sr.职务等级;
                item.职位编号 = sr.职位编号;
                item.班别 = sr.班别;

                #endregion

                #region 出勤情况

                item.企业排班天数 = sr.企业排班天数;
                item.法定工作日天数 = sr.法定工作日天数;
                item.实际出勤天数 = sr.实际出勤天数;
                item.法定工作日出勤天数 = sr.法定工作日出勤天数;
                item.法定节假日出勤天数 = sr.法定节假日出勤天数;
                item.休息日出勤天数 = sr.休息日出勤天数;
                item.月综合出勤天数 = sr.月综合出勤天数;
                item.工作日延长出勤小时数 = sr.工作日延长出勤小时数;

                #endregion

                #region 出勤工资

                item.法定工作日出勤工资 = sr.法定工作日出勤工资;
                item.法定节假日出勤工资 = sr.法定节假日出勤工资;
                item.休息日出勤工资 = sr.休息日出勤工资;
                item.月综合出勤工资 = sr.月综合出勤工资;
                item.工作日延长工作出勤工资 = sr.工作日延长工作出勤工资;

                #endregion

                item.未休年休假工资 = sr.未休年休假工资;
                item.特殊社保的基准工资 = sr.特殊社保的基准工资;
                item.基数等级与基准工资差额 = sr.基数等级与基准工资差额;
                item.交通餐饮补助 = sr.交通餐饮补助;

                #region 社保缴纳

                item.养老保险个人缴纳金额 = sr.养老保险个人缴纳金额;
                item.医疗保险个人缴纳金额 = sr.医疗保险个人缴纳金额;
                item.失业保险个人缴纳金额 = sr.失业保险个人缴纳金额;
                item.住房公积金个人缴纳金额 = sr.住房公积金个人缴纳金额;
                item.大病医疗个人缴纳金额 = sr.大病医疗个人缴纳金额;
                //社保合计
                item.社保个人缴纳金额 = sr.社保个人缴纳金额;
                item.社保公司缴纳金额 = sr.社保公司缴纳金额;

                #endregion

                #region 累加器

                item.出勤工资 = sr.出勤工资;
                item.津贴补助 = sr.津贴补助;
                item.综合考核工资 = sr.综合考核工资;
                item.奖项 = sr.奖项;
                item.扣项 = sr.扣项;

                #endregion

                #region 按工资类别小计

                item.挂钩效益工资 = sr.挂钩效益工资;
                item.其他所得 = sr.其他所得;
                item.其他扣款 = sr.其他扣款;
                item.预留风险金 = sr.预留风险金;
                item.实得满勤奖 = sr.实得满勤奖;
                item.应得满勤奖 = sr.应得满勤奖;
                item.上表工资 = sr.上表工资;
                item.设定工资 = sr.设定工资;
                item.基准工资 = sr.基准工资;
                item.工资降级 = sr.工资降级;
                item.代垫费用 = sr.代垫费用;
                item.个人所得税金额 = sr.个人所得税金额;
                item.上表工资总额 = sr.上表工资总额;
                item.应税工资额 = sr.应税工资额;
                item.合计应税工资额 = sr.合计应税工资额;
                item.实发工资总额 = sr.实发工资总额;

                #endregion

                item.工资职等 = GetGrade(item);

                item.上次同步时间 = DateTime.Now;

                item.Save();

                return true;
            }
            catch (Exception e)
            {
                YiKang.Common.WriteToEventLog("同步工资失败：" + e.ToString());
                return false;
            }
        }

        #region GetGrade

        public static string GetGrade(SalaryResult sr)
        {
            //"003": //广西华劲竹林发展有限公司
            //"005": //赣州华劲竹林发展有限公司                
            if (sr.公司编号 == "003" || sr.公司编号 == "005")
                return GetGrade2(sr);
            else
                return GetGrade1(sr);
        }

        public static string GetGrade1(SalaryResult sr)
        {
            //有二级分类的职务等级
            string JOB_HAS_SECONDARY = "主任|副主任|工程师|班长|";
            try
            {
                if (sr.职等名称 == null) return null;

                //职等默认等于职务等级
                string grade = GetGrade(sr.职等名称);

                if (JOB_HAS_SECONDARY.IndexOf(grade + "|") == -1)
                    return grade;
                else
                {
                    DeptInfo dept = sr.所在机构.部门;
                    //如果找不到部门
                    if (dept == null) return grade;

                    //获取部门板块属性
                    string fun = dept.职能类型;

                    //获取班长岗位级别
                    string level = "";
                    if (sr.所在机构.车间 != null)
                    {
                        MonitorLevel mv = MonitorLevel.Get(sr.所在机构.车间.部门编号, sr.职务代码);
                        if (mv != null) level = mv.级别名称;
                    }

                    if (level == "")
                        return fun + grade;
                    else
                        return level + grade;
                }
            }
            catch (Exception err)
            {
                Common.WriteLog(Environment.CurrentDirectory + "\\LogFiles\\Error.log", err.ToString());
            }
            return null;
        }

        public static string GetGrade(string s)
        {
            //string grade = sr.职等名称.Replace("级", "");
            int pos = s.LastIndexOf("级");
            if (pos < s.Length - 1)
                return s;
            else
            {
                return s.Substring(0, pos);
            }
        }

        public static string GetGrade2(SalaryResult sr)
        {
            //有二级分类的职务等级
            string JOB_HAS_SECONDARY = "经理|副经理|科员|";
            try
            {
                if (sr.职等名称 == null) return null;

                //职等默认等于职务等级
                string grade = GetGrade(sr.职等名称);

                if (JOB_HAS_SECONDARY.IndexOf(grade + "|") == -1)
                    return grade;
                else
                {
                    DeptInfo dept = sr.所在机构.部门;
                    //如果找不到部门
                    if (dept == null) return grade;

                    //获取部门板块属性
                    string fun = dept.职能类型;


                    if (fun == "部门")
                        return "部门" + grade;
                    else
                    {
                        if (grade == "科员")
                            return "林场科员";
                        else
                            return "经营区" + grade;
                    }
                }
            }
            catch (Exception err)
            {
                Common.WriteLog(Environment.CurrentDirectory + "\\LogFiles\\Error.log", err.ToString());
            }
            return null;
        }

        #endregion

        #region 职等名称

        public string 职等名称
        {
            get
            {
                return PsHelper.GetSupvsrLvDescr(this.职务等级);
            }
        }
        #endregion        

        private static void GetSeq(SalResult sr, SalaryResult item)
        {
            OleDbConnection conn = null;
            try
            {
                conn = new OleDbConnection(MyHelper.GetPsConnectionString());
                conn.Open();
                using (OleDbCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = String.Format("SELECT B.SEQ_NBR AS DEPT_SEQ, A.COMPANY, A.C_GP_DEPT, A.SEQ_NBR AS EMP_SEQ FROM SYSADM.PS_C_GP_DEPT_EMP_C A left join SYSADM.PS_C_GP_DEPT B on A.Company = B.Company AND A.c_gp_dept = B.c_gp_dept where EMPLID='{0}'  and a.effdt < date'{1}' and rownum=1 order by a.effdt desc", sr.员工编号, (new DateTime(sr.年度, sr.月份, 1)).AddMonths(1).ToString("yyyy-M-d"));
                    OleDbDataReader rs = cmd.ExecuteReader();
                    if (rs.Read())
                    {
                        CompanyInfo company = CompanyInfo.Get((string)rs["COMPANY"]);
                        if (company != null) item.财务公司 = company.公司名称;
                        item.财务部门 = (string)rs["C_GP_DEPT"];
                        item.财务部门序号 = Convert.ToInt32(rs["DEPT_SEQ"]);
                        item.员工序号 = Convert.ToInt32(rs["EMP_SEQ"]);
                    }
                    rs.Close();
                }
            }
            finally
            {
                if (conn != null) conn.Close();
            }
        }

        #endregion

        #endregion

        #region GetLastestDate
        public static DateTime GetLastSalaryDate()
        {
            return GetLastSalaryDate(null);
        }

        public static DateTime GetLastSalaryDate(string group)
        {
            DateTime lastSalaryDate = GetLastestDate(group);
                        
            if (lastSalaryDate == DateTime.MinValue)
                lastSalaryDate = GetLastestDateByGrade("经理");

            if (lastSalaryDate == DateTime.MinValue)
                lastSalaryDate = GetLastestDateByGrade("副经理");

            if (lastSalaryDate == DateTime.MinValue)
                lastSalaryDate = GetLastestDateByGrade("厂长");

            if (lastSalaryDate == DateTime.MinValue)
                lastSalaryDate = GetLastestDateByGrade("副场长");

            if (lastSalaryDate == DateTime.MinValue)
                lastSalaryDate = GetLastestDateByGrade("主任");

            if (lastSalaryDate == DateTime.MinValue)
                lastSalaryDate = GetLastestDateByGrade("岗位工");

            if (lastSalaryDate == DateTime.MinValue)
                lastSalaryDate = MyHelper.GetPrevMonth1Day();

            return lastSalaryDate;
        }

        //获取最近发放的日期
        public static DateTime GetLastestDateByGrade(string grade)
        {
            string sql = "SELECT TOP 1 年度, 月份  FROM 基础工资表 WHERE 工资职等='" + grade + "'  ORDER BY 年度 DESC, 月份 DESC";
            if(grade == null) sql = "SELECT TOP 1 年度, 月份  FROM 基础工资表 ORDER BY 年度 DESC, 月份 DESC";
            SqlConnection conn = new SqlConnection(MyHelper.GetConnectionString());
            using (conn)
            {
                SqlDataReader rs = null;
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = sql;
                        rs = cmd.ExecuteReader();
                        if (rs.Read())
                        {
                            int year = Convert.ToInt32(rs["年度"]);
                            int month = Convert.ToInt32(rs["月份"]);
                            return new DateTime(year, month, 1);
                        }
                    }
                }
                finally
                {
                    if (rs != null) rs.Close();
                    conn.Close();
                }

                return DateTime.MinValue;
            }
        }        
        //获取最近发放的日期
        public static DateTime GetLastestDate(string emplid)
        {
            string sql = "SELECT TOP 1 年度, 月份  FROM 基础工资表 WHERE 员工编号='" + emplid + "'  ORDER BY 年度 DESC, 月份 DESC";
            SqlConnection conn = new SqlConnection(MyHelper.GetConnectionString());
            using (conn)
            {
                SqlDataReader rs = null;
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = sql;
                        rs = cmd.ExecuteReader();
                        if (rs.Read())
                        {
                            int year = Convert.ToInt32(rs["年度"]);
                            int month = Convert.ToInt32(rs["月份"]);
                            return new DateTime(year, month, 1);
                        }
                    }
                }
                finally
                {
                    if (rs != null) rs.Close();
                    conn.Close();
                }

                return DateTime.MinValue;
            }
        }
        #endregion

        #region GetLastestSalaryGrade
        //获取最近的工资职等
        public static string GetLastestSalaryGrade(string emplid)
        {
            string sql = "SELECT TOP 1 工资职等 FROM 基础工资表 WHERE 员工编号='" + emplid + "' ORDER BY 期间 DESC";
            SqlConnection conn = new SqlConnection(MyHelper.GetConnectionString());
            using (conn)
            {
                SqlDataReader rs = null;
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = sql;
                        rs = cmd.ExecuteReader();
                        if (rs.Read())
                        {
                            return (string)rs["工资职等"];
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

        #region 所在部门

        public DeptInfo 所在部门
        {
            get
            {
                return DeptInfo.Get(this.部门编号);
            }
        }
        #endregion

        #region 所在机构

        public DeptInfo 所在机构
        {
            get
            {
                return DeptInfo.Get(this.机构编号);
            }
        }
        #endregion

        #region 职等

        public 职等 职等
        {
            get
            {
                string level = "";
                if (this.职务等级 != null) level = this.职务等级.Trim();

                switch (level)
                {
                    case "0001":
                    case "0002":
                    case "0003":
                    case "0004":
                    case "0005":
                    case "0006":
                    case "0007":
                        return 职等.副总经理以上;
                    case "0009":
                        return 职等.经理;
                    case "0010":
                        return 职等.副经理;
                    case "0011":
                        return 职等.主任;
                    case "0012":
                    case "0020":
                        return 职等.副主任;
                    case "0013":
                    case "0019":
                        return 职等.工程师;
                    case "0014":
                        return 职等.班长;
                    case "0015":
                        return 职等.科员;
                    case "0016":
                        return 职等.组长;
                    case "0017":
                        return 职等.岗位工;
                    default:
                        return 职等.岗位工;
                }
            }
        }
        #endregion

        #region 养老保险个人补缴

        public decimal 养老保险个人补缴
        {
            get
            {
                SalaryResultItem item = SalaryResultItem.GetSalaryResultItem(this.员工编号, this.年度, this.月份, "C DD PEN E C");
                if (item == null)
                    return 0;
                else
                    return item.金额;
            }
        }
        #endregion

        #region 基本医疗个人补缴

        public decimal 基本医疗个人补缴
        {
            get
            {
                SalaryResultItem item = SalaryResultItem.GetSalaryResultItem(this.员工编号, this.年度, this.月份, "C DD MED E C");
                if (item == null)
                    return 0;
                else
                    return item.金额;
            }
        }
        #endregion

        #region 失业保险个人补缴

        public decimal 失业保险个人补缴
        {
            get
            {
                SalaryResultItem item = SalaryResultItem.GetSalaryResultItem(this.员工编号, this.年度, this.月份, "C DD UNE E C");
                if (item == null)
                    return 0;
                else
                    return item.金额;
            }
        }
        #endregion

        #region 住房公积金个人补缴

        public decimal 住房公积金个人补缴
        {
            get
            {
                SalaryResultItem item = SalaryResultItem.GetSalaryResultItem(this.员工编号, this.年度, this.月份, "C DD HOU E C");
                if (item == null)
                    return 0;
                else
                    return item.金额;
            }
        }
        #endregion

        #region 养老保险个人缴纳

        public decimal 养老保险个人缴纳
        {
            get
            {
                return this.养老保险个人缴纳金额 + this.养老保险个人补缴;
            }
        }
        #endregion

        #region 基本医疗个人缴纳

        public decimal 基本医疗个人缴纳
        {
            get
            {
                return this.医疗保险个人缴纳金额 + this.基本医疗个人补缴;
            }
        }
        #endregion

        #region 失业保险个人缴纳

        public decimal 失业保险个人缴纳
        {
            get
            {
                return this.失业保险个人缴纳金额 + this.失业保险个人补缴;
            }
        }
        #endregion

        #region 住房公积金个人缴纳

        public decimal 住房公积金个人缴纳
        {
            get
            {
                return this.住房公积金个人缴纳金额 + this.住房公积金个人补缴;
            }
        }
        #endregion

        #region 员工信息

        EmployeeInfo empInfo = null;
        public EmployeeInfo 员工信息
        {
            get
            {
                if (empInfo == null) empInfo = EmployeeInfo.GetFromCache(this.员工编号);
                return empInfo;
            }
        }
        #endregion

        #region CacheKey

        string CacheKey
        {
            get { return this.员工编号 + "$$" + this.年度 + "$$" + this.月份; }
        }

        #endregion
    }
}