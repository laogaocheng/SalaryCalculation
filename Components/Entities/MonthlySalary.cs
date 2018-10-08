using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using DevExpress.Xpo.DB;
using log4net;
using Hwagain.Components;
using System.Data.SqlClient;

namespace Hwagain.SalaryCalculation.Components
{
    public partial class MonthlySalary
    {
        //说明：期号 统一调整用 年份 + 一个数字（20171），单独调整用100001 起始编号
        static readonly ILog log = LogManager.GetLogger(typeof(MonthlySalary));
        public static ICache<string, MonthlySalary> MONTHLY_SALARY_CACHE = MemoryCache<string, MonthlySalary>.Instance;

        #region GetMonthlySalary

        public static MonthlySalary GetMonthlySalary(Guid id)
        {
            MonthlySalary obj = (MonthlySalary)Session.DefaultSession.GetObjectByKey(typeof(MonthlySalary), id);
            return obj;
        }

        public static MonthlySalary GetMonthlySalary(string emplid, DateTime startDate)
        {
            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                       new BinaryOperator("员工编号", emplid, BinaryOperatorType.Equal),
                       new BinaryOperator("开始执行日期", startDate, BinaryOperatorType.Equal));

            XPCollection objset = new XPCollection(typeof(MonthlySalary), criteria, new SortProperty("开始执行日期", SortingDirection.Ascending));

            if (objset.Count > 0)
            {
                return (MonthlySalary)objset[0];
            }
            else
                return null;
        }

        #endregion

        #region GetFromCache

        public static MonthlySalary GetFromCache(string emplid, DateTime startDate)
        {
            string key = emplid + "$$" + startDate;
            return MONTHLY_SALARY_CACHE.Get(key, () => GetMonthlySalary(emplid, startDate), TimeSpan.FromHours(1));                
        }
        #endregion
        
        #region GetMonthlySalarys

        public static List<MonthlySalary> GetMonthlySalarys(string salaryPlan, string group, int period)
        {
            List<MonthlySalary> list = new List<MonthlySalary>();

            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                       new BinaryOperator("薪酬体系", salaryPlan, BinaryOperatorType.Equal),                       
                       new BinaryOperator("期号", period, BinaryOperatorType.Equal));

            if (!string.IsNullOrEmpty(group)) criteria.Operands.Add(new BinaryOperator("群组", group, BinaryOperatorType.Equal));

            XPCollection objset = new XPCollection(typeof(MonthlySalary), criteria, new SortProperty("序号", SortingDirection.Ascending), new SortProperty("执行_月薪", SortingDirection.Descending));

            foreach (MonthlySalary ms in objset)
            {
                list.Add(ms);                
            }
            return list;
        }
        //获取指定员工所有的月薪记录
        public static List<MonthlySalary> GetMonthlySalarys(string emplid)
        {
            List<MonthlySalary> list = new List<MonthlySalary>();

            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                       new BinaryOperator("员工编号", emplid, BinaryOperatorType.Equal));

            XPCollection objset = new XPCollection(typeof(MonthlySalary), criteria, new SortProperty("开始执行日期", SortingDirection.Descending));

            foreach (MonthlySalary grade in objset)
            {
                list.Add(grade);
            }
            return list;
        }

        #endregion       

        #region GetPrevious

        public MonthlySalary GetPrevious()
        {
            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                       new BinaryOperator("员工编号", 员工编号, BinaryOperatorType.Equal),
                       new BinaryOperator("开始执行日期", 开始执行日期, BinaryOperatorType.Less)
                       );

            XPCollection objset = new XPCollection(MyHelper.XpoSession, typeof(MonthlySalary), criteria, new SortProperty("开始执行日期", SortingDirection.Ascending));

            if (objset.Count > 0)
            {
                MonthlySalary item = (MonthlySalary)objset[0];
                return item;
            }
            else
                return null;
        }
        #endregion

        #region GetNext
        /// <summary>
        /// 获取下一条执行标准
        /// </summary>
        /// <returns></returns>
        public MonthlySalary GetNext()
        {
            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                       new BinaryOperator("员工编号", 员工编号, BinaryOperatorType.Equal),
                       new BinaryOperator("开始执行日期", 开始执行日期, BinaryOperatorType.Greater)
                       );

            XPCollection objset = new XPCollection(MyHelper.XpoSession, typeof(MonthlySalary), criteria, new SortProperty("开始执行日期", SortingDirection.Ascending));

            if (objset.Count > 0)
            {
                MonthlySalary item = (MonthlySalary)objset[0];
                return item;
            }
            else
                return null;
        }
        #endregion

        #region GetEmployeePreviousDate

        public static DateTime GetEmployeePreviousDate(string emplid, DateTime date)
        {
            DateTime start_date = DateTime.MinValue;
            string sql = "SELECT DISTINCT TOP (1) 开始执行日期 FROM  薪酬执行明细 WHERE (员工编号 = '" + emplid + "' AND 开始执行日期 < " + date + ") ORDER BY 开始执行日期 DESC";
            using (SqlConnection connection = new SqlConnection(MyHelper.GetConnectionString()))
            {
                SqlDataReader dr = YiKang.Data.SqlHelper.ExecuteReader(connection, System.Data.CommandType.Text, sql);
                if (dr.Read())
                {
                    start_date = Convert.ToDateTime(dr[0]);
                }
                dr.Close();
                return start_date;
            }
        }
        #endregion

        #region AddMonthlySalary

        public static MonthlySalary AddMonthlySalary(string emplid, DateTime startDate)
        {
            MonthlySalary item = GetMonthlySalary(emplid, startDate);
            if (item == null)
            {
                item = new MonthlySalary();
                item.标识 = Guid.NewGuid();
                item.员工编号 = emplid;
                item.开始执行日期 = startDate;

                item.Save();
            }
            return item;
        }
        #endregion

        #region OnSaving

        protected override void OnSaving()
        {
            MonthlySalary found = GetMonthlySalary(this.员工编号, this.开始执行日期);
            if (found != null && found.标识 != this.标识)
                throw new Exception("本期已存在该员工的标准，不能创建。");
            else
                base.OnSaving();

            MONTHLY_SALARY_CACHE.Set(CacheKey, this, TimeSpan.FromHours(1));
        }
        #endregion

        #region OnDeleting

        protected override void OnDeleting()
        {
            base.OnDeleting();
            MONTHLY_SALARY_CACHE.Remove(CacheKey);
            //复制到历史表
            MonthlySalaryHistory m = MonthlySalaryHistory.AddMonthlySalaryHistory(this.员工编号, this.期号);
            this.CopyWatchMember(m);
            m.Save();
        }
        #endregion

        #region GetEffective

        public static MonthlySalary GetEffective(string empNo, DateTime date)
        {
            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                       new BinaryOperator("员工编号", empNo, BinaryOperatorType.Equal),
                       new BinaryOperator("开始执行日期", date.Date, BinaryOperatorType.LessOrEqual)
                       );

            XPCollection objset = new XPCollection(MyHelper.XpoSession, typeof(MonthlySalary), criteria, new SortProperty("开始执行日期", SortingDirection.Descending));

            if (objset.Count > 0)
            {
                MonthlySalary item = (MonthlySalary)objset[0];
                if (item.截止日期 == DateTime.MinValue || item.截止日期 >= date.Date)
                    return item;
                else
                    return null;
            }
            else
                return null;
        }
        #endregion

        #region ClearInvalidRecord
        //清理无效的记录
        public static List<EmployeeInfo> ClearInvalidRecord()
        {            
            List<EmployeeInfo> empListChanged = new List<EmployeeInfo>();
            List<EmployeeInfo> empList = EmployeeInfo.GetHasPayEmployeeList();
            //最近一次发工资的日期
            DateTime lastSalaryDate = SalaryResult.GetLastSalaryDate();
            if (lastSalaryDate == DateTime.MinValue) return empListChanged;

            //上月最后一天（相当于该员工有工资的最后一个月，这里是相对的概念）
            DateTime preMonthLastDayDate = new DateTime(lastSalaryDate.Year, lastSalaryDate.Month, 1).AddMonths(1).AddDays(-1);
            //上上月
            DateTime prePreMonthLastDayDate = preMonthLastDayDate.AddMonths(-1);
            DateTime expiredDate = prePreMonthLastDayDate;

            foreach (EmployeeInfo emp in empList)
            {
                //2018-7-24   管培生薪酬体系特殊，不随公司与职务等级变化，不设异动判断
                if (emp.是管培生) continue;

                MonthlySalary ms = GetEffective(emp.员工编号, lastSalaryDate);
                if (ms != null)
                {
                    SalaryResult sr = SalaryResult.GetFromCache(emp.员工编号, lastSalaryDate.Year, lastSalaryDate.Month);
                    if (sr != null)
                    {
                        SalaryResult prev_sr = SalaryResult.GetFromCache(emp.员工编号, prePreMonthLastDayDate.Year, prePreMonthLastDayDate.Month);
                        //如果公司、职等都没变
                        if (prev_sr == null || (prev_sr.公司编号 == sr.公司编号 && ms.职等 == sr.工资职等))
                        {
                            continue;
                        }
                        expiredDate = new DateTime(sr.年度, sr.月份, 1).AddDays(-1);
                    }
                    else
                    {
                        continue;
                    }

                    if (ms.截止日期 < ms.开始执行日期) continue;

                    //截止日期为上上月最后一天                    
                    ms.截止日期 = expiredDate;
                    ms.Save();

                    empListChanged.Add(emp);
                }
            }
            return empListChanged;
        }
        #endregion

        #region OnLoaded

        protected override void OnLoaded()
        {
            AutoSaveOnEndEdit = false; //关闭自动保存的开关
            //缓存
            MONTHLY_SALARY_CACHE.Set(this.CacheKey, this, TimeSpan.FromHours(1));
            base.OnLoaded();
        }
        #endregion

        #region GetLastestPeriodNonYear
        /// <summary>
        /// 获取指定群组非年度调整的最近的期号
        /// </summary>
        /// <param name="salary_plan">公司</param>
        /// <param name="group">群组</param>
        /// <returns></returns>
        public static int GetLastestPeriodNonYear(string salary_plan, string group)
        {
            string sql = "SELECT DISTINCT TOP (1) 期号 FROM  薪酬执行明细 WHERE (期号 > 100000 AND 薪酬体系 = '" + salary_plan + "' AND 群组 = '" + group + "') ORDER BY 期号 DESC";
            using (SqlConnection connection = new SqlConnection(MyHelper.GetConnectionString()))
            {
                int number = -1;
                SqlDataReader dr = YiKang.Data.SqlHelper.ExecuteReader(connection, System.Data.CommandType.Text, sql);
                if (dr.Read())
                {
                    number = Convert.ToInt32(dr[0]);
                }
                dr.Close();
                return number;
            }
        }

        #endregion

        #region 上期标准

        public MonthlySalary 上期标准
        {
            get
            {
                return GetPrevious();
            }
        }
        #endregion

        #region CacheKey

        string CacheKey
        {
            get { return this.员工编号 + "$$" + this.开始执行日期; }
        }

        #endregion

        #region 员工信息

        EmployeeInfo empInfo = null;
        [NonPersistent]
        public EmployeeInfo 员工信息
        {
            get
            {
                if (empInfo == null) empInfo = EmployeeInfo.GetEmployeeInfo(this.员工编号);
                return empInfo;
            }
            set { empInfo = value; }
        }
        #endregion

        #region 部门

        public string 部门
        {
            get
            {
                if (员工信息 != null)
                {
                    return 员工信息.机构名称;
                }
                return null;
            }
        }

        #endregion

        #region 姓名

        public string 姓名
        {
            get
            {
                if (员工信息 != null)
                {
                    return 员工信息.姓名;
                }
                return null;
            }
        }

        #endregion

        #region 性别

        public string 性别
        {
            get
            {
                if (员工信息 != null)
                {
                    return 员工信息.性别;
                }
                return null;
            }
        }

        #endregion

        #region 职务

        public string 职务
        {
            get
            {
                if (员工信息 != null)
                {
                    return 员工信息.职务名称;
                }
                return null;
            }
        }

        #endregion

        #region 备注

        string demo = "";
        public string 备注
        {
            get
            {
                if (this.调整类型 != null) demo = this.调整类型.IndexOf("年度评定") == -1 ? this.调整类型 : "";
                return demo;
            }
            set
            {
                demo = value;
            }
        }
        #endregion
    }
}
