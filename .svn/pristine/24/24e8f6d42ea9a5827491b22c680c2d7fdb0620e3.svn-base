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
using YiKang;

namespace Hwagain.SalaryCalculation.Components
{
    public partial class MonthlyRembursementSalaryItem
    {
        static readonly ILog log = LogManager.GetLogger(typeof(MonthlyRembursementSalaryItem));
        public static ICache<string, MonthlyRembursementSalaryItem> MONTHLY_REMBURSEMENT_SALARYITEM_CACHE = MemoryCache<string, MonthlyRembursementSalaryItem>.Instance;

        #region GetMonthlyRembursementSalaryItem

        public static MonthlyRembursementSalaryItem GetMonthlyRembursementSalaryItem(Guid id)
        {
            MonthlyRembursementSalaryItem obj = (MonthlyRembursementSalaryItem)Session.DefaultSession.GetObjectByKey(typeof(MonthlyRembursementSalaryItem), id);
            return obj;
        }

        public static MonthlyRembursementSalaryItem GetMonthlyRembursementSalaryItem(string emplid, string period)
        {
            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                       new BinaryOperator("员工编号", emplid, BinaryOperatorType.Equal),
                       new BinaryOperator("期间", period, BinaryOperatorType.Equal)
                       );

            XPCollection objset = new XPCollection(typeof(MonthlyRembursementSalaryItem), criteria, new SortProperty("创建时间", SortingDirection.Descending));

            if (objset.Count > 0)
            {
                return (MonthlyRembursementSalaryItem)objset[0];
            }
            else
                return null;
        }

        public static MonthlyRembursementSalaryItem GetMonthlyRembursementSalaryItem(string emplid, int year, int month)
        {
            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                       new BinaryOperator("员工编号", emplid, BinaryOperatorType.Equal),
                       new BinaryOperator("年", year, BinaryOperatorType.Equal),
                       new BinaryOperator("月", month, BinaryOperatorType.Equal)
                       );

            XPCollection objset = new XPCollection(typeof(MonthlyRembursementSalaryItem), criteria, new SortProperty("创建时间", SortingDirection.Descending));

            if (objset.Count > 0)
            {
                return (MonthlyRembursementSalaryItem)objset[0];
            }
            else
                return null;
        }

        #endregion

        #region GetFromCache

        public static MonthlyRembursementSalaryItem GetFromCache(string emplid, string period)
        {
            string key = emplid + "$$" + period;
            return MONTHLY_REMBURSEMENT_SALARYITEM_CACHE.Get(key, () => GetMonthlyRembursementSalaryItem(emplid, period), TimeSpan.FromHours(10));
        }
        #endregion

        #region GetMonthlyRembursementSalaryItems

        public static List<MonthlyRembursementSalaryItem> GetMonthlyRembursementSalaryItems(string emplid)
        {
            return GetMonthlyRembursementSalaryItems(emplid, -1);
        }

        public static List<MonthlyRembursementSalaryItem> GetMonthlyRembursementSalaryItems(string emplid, int year)
        {
            List<MonthlyRembursementSalaryItem> list = new List<MonthlyRembursementSalaryItem>();

            GroupOperator criteria = new GroupOperator(GroupOperatorType.And, new BinaryOperator("员工编号", emplid, BinaryOperatorType.Equal));

            if (year >= 2018) criteria.Operands.Add(new BinaryOperator("年", year, BinaryOperatorType.Equal));

            XPCollection objset = new XPCollection(typeof(MonthlyRembursementSalaryItem), criteria, new SortProperty("期间", SortingDirection.Ascending));

            foreach (MonthlyRembursementSalaryItem ms in objset)
            {
                list.Add(ms);
            }
            return list;
        }

        public static List<MonthlyRembursementSalaryItem> GetMonthlyWageLoanItems(int year, int month)
        {
            List<MonthlyRembursementSalaryItem> list = new List<MonthlyRembursementSalaryItem>();

            GroupOperator criteria = new GroupOperator(GroupOperatorType.And);
            criteria.Operands.Add(new BinaryOperator("年", year, BinaryOperatorType.Equal));
            criteria.Operands.Add(new BinaryOperator("月", month, BinaryOperatorType.Equal));

            XPCollection objset = new XPCollection(typeof(MonthlyRembursementSalaryItem), criteria, new SortProperty("创建时间", SortingDirection.Ascending));

            foreach (MonthlyRembursementSalaryItem ms in objset)
            {
                list.Add(ms);
            }
            return list;
        }

        #endregion

        #region AddMonthlyRembursementSalaryItem

        public static MonthlyRembursementSalaryItem AddMonthlyRembursementSalaryItem(string emplid, int year, int month)
        {
            MonthlyRembursementSalaryItem item = GetMonthlyRembursementSalaryItem(emplid, year, month);
            if (item == null)
            {
                item = new MonthlyRembursementSalaryItem();
                item.标识 = Guid.NewGuid();
                item.员工编号 = emplid;
                item.年 = year;
                item.月 = month;
                item.创建人 = AccessController.CurrentUser.姓名;
                item.创建时间 = DateTime.Now;
                item.Save();
            }
            return item;
        }
        #endregion

        #region GetLastMonthPeriod
        //获取上个月的期间
        public static string GetLastMonthPeriod(int year, int month)
        {
            if (month > 1)
                return Convert.ToString(year * 100 + month - 1);
            else
                return Convert.ToString((year - 1) * 100 + 12);
        }

        #endregion

        #region GetFirstMonth

        //获取指定年份第一条记录
        public static int GetFirstMonth(string emplid, int year)
        {
            string sql = "SELECT TOP 1 月  FROM 薪酬结构_报账工资_发放明细 WHERE 员工编号 = '" + emplid + "' AND 年 = '" + year + "' ORDER BY 月";
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
                            return (int)rs["月"];
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

        #region GetLastYearSurplus

        //获取上年剩余可报账金额
        public static decimal GetLastYearSurplus(string emplid, int year)
        {
            string sql = "SELECT TOP 1 上年剩余金额  FROM 薪酬结构_报账工资_发放明细 WHERE 员工编号 = '" + emplid + "' AND 年 = '" + year + "' ORDER BY 月";
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
                            return (decimal)rs["上年剩余金额"];
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
        
        #region OnSaving

        protected override void OnSaving()
        {
            if(this.期间 == null) this.期间 = GetPeriod(年, 月);

            MonthlyRembursementSalaryItem found = GetMonthlyRembursementSalaryItem(this.员工编号, this.期间);
            if (found != null && found.标识 != this.标识)
                throw new Exception("已存在该员工的报销记录，不能重复创建。");
            else
                base.OnSaving();

            MONTHLY_REMBURSEMENT_SALARYITEM_CACHE.Set(CacheKey, this, TimeSpan.FromHours(10));
        }
        #endregion

        #region OnDeleting

        protected override void OnDeleting()
        {
            base.OnDeleting();
            MONTHLY_REMBURSEMENT_SALARYITEM_CACHE.Remove(CacheKey);
        }
        #endregion

        #region OnDeleted
        protected override void OnDeleted()
        {
            base.OnDeleted();
        }
        #endregion

        #region OnLoaded

        protected override void OnLoaded()
        {
            AutoSaveOnEndEdit = false; //关闭自动保存的开关
            //缓存
            MONTHLY_REMBURSEMENT_SALARYITEM_CACHE.Set(this.CacheKey, this, TimeSpan.FromHours(10));
            base.OnLoaded();
        }
        #endregion

        #region GetPeriod
        public static string GetPeriod(int year, int month)
        {
            return Convert.ToString(year * 100 + month);
        }
        #endregion

        #region CacheKey

        string CacheKey
        {
            get { return this.员工编号 + "$$" + this.期间; }
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
                    return 员工信息.部门名称;
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

        #region 职等

        public string 职等
        {
            get
            {
                if (员工信息 != null)
                {
                    return 员工信息.职等;
                }
                return null;
            }
        }

        #endregion

        #region 发放月份
        public string 发放月份
        {
            get
            {
                return 年 + "年" + 月 + "月";
            }
        }
        #endregion

        #region 期间开始

        [NonPersistent]
        public DateTime 期间开始
        {
            get
            {
                return new DateTime(年, 月, 1);
            }
        }
        #endregion

        #region 报账标准

        RembursementSalary rs = null;
        [NonPersistent]
        public RembursementSalary 报账标准
        {
            get
            {
                if (rs == null) rs = RembursementSalary.GetEffectiveRembursementSalary(员工编号, new DateTime(年, 月, 1));
                return rs;
            }
        }
        #endregion

        #region 报账标准_税后_年
        public decimal 报账标准_税后_年
        {
            get
            {
                RembursementSalary rs = this.报账标准;
                if (rs == null)
                    return 0;
                else
                    return rs.年度可报账标准_税后;
            }
        }
        #endregion

        #region 报账标准_税后_月
        public decimal 报账标准_税后_月
        {
            get
            {
                RembursementSalary rs = this.报账标准;
                if (rs == null)
                    return 0;
                else
                    return rs.月度可报账标准_税后;
            }
        }
        #endregion

        #region 报账标准_税前_年
        public decimal 报账标准_税前_年
        {
            get
            {
                RembursementSalary rs = this.报账标准;
                if (rs == null)
                    return 0;
                else
                    return rs.年度可报账标准_税前;
            }
        }
        #endregion

        #region 报账标准_税前_月
        public decimal 报账标准_税前_月
        {
            get
            {
                RembursementSalary rs = this.报账标准;
                if (rs == null)
                    return 0;
                else
                    return rs.月度可报账标准_税前;
            }
        }
        #endregion

        #region 上月剩余可报账金额
        public decimal 上月剩余可报账金额
        {
            get
            {
                return 上月剩余金额;
            }
        }
        #endregion

        #region 本月报账工资标准
        public decimal 本月报账工资标准
        {
            get
            {
                return 报账标准_税后_月;
            }
        }
        #endregion

        #region 本年报账工资标准
        public decimal 本年报账工资标准
        {
            get
            {
                //算出开始月份之前的额度
                decimal 生效之前的额度 = 0;
                if(报账标准 != null && 年 == 报账标准.开始时间.Year) 生效之前的额度 = 报账标准_税后_月 * (报账标准.开始时间.Month - 1);
                return 报账标准_税后_年 - 生效之前的额度;
            }
        }
        #endregion

        #region 本月可报账金额
        public decimal 本月可报账金额
        {
            get
            {
                return 本月报账工资标准 + 上月剩余可报账金额;
            }
        }
        #endregion

        #region 本月剩余可报账金额
        public decimal 本月剩余可报账金额
        {
            get
            {
                return 本月可报账金额 - 实际报账金额;
            }
        }
        #endregion

        #region 上年剩余可报账金额
        public decimal 上年剩余可报账金额
        {
            get
            {
                return 上年剩余金额;
            }
        }
        #endregion

        #region 本年可报账金额
        public decimal 本年可报账金额
        {
            get
            {
                return 本年报账工资标准 + 上年剩余可报账金额;
            }
        }
        #endregion

        #region 本年实际报账金额
        [NonPersistent]
        public decimal 本年实际报账金额
        {
            get
            {
                List<MonthlyRembursementSalaryItem> list = 本年所有报账记录;
                list = list.FindAll(a => a.月 <= 月).ToList();
                return list.Sum(a => a.实际报账金额);
            }
        }
        #endregion

        #region 本年所有报账记录
        List<MonthlyRembursementSalaryItem> thisYearItems = null;
        [NonPersistent]
        public List<MonthlyRembursementSalaryItem> 本年所有报账记录
        {
            get
            {
                if(thisYearItems == null) thisYearItems = GetMonthlyRembursementSalaryItems(员工编号, 年);
                return thisYearItems;
            }
            set
            {
                thisYearItems = value;
            }
        }
        #endregion

        #region 本年剩余可报账金额
        public decimal 本年剩余可报账金额
        {
            get
            {
                return 本年可报账金额 - 本年实际报账金额;
            }
        }
        #endregion

        #region 打印按钮文字
        public string 打印按钮文字
        {
            get { return "打印"; }
        }
        #endregion

        #region 实际报销金额_大写
        public string 实际报销金额_大写
        {
            get
            {
                return Common.CmycurD(this.实际报账金额);
            }
        }
        #endregion

        #region 上月发放记录

        MonthlyRembursementSalaryItem lastMonthItem = null;
        public MonthlyRembursementSalaryItem 上月发放记录
        {
            get
            {
                if(lastMonthItem == null)
                {
                    string lastPeriod = GetLastMonthPeriod(年, 月);
                    lastMonthItem = GetMonthlyRembursementSalaryItem(员工编号, lastPeriod);
                }
                return lastMonthItem;
            }
        }

        #endregion
    }
}
