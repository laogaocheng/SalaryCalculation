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
    public partial class MonthlyContractAllowanceItem
    {
        static readonly ILog log = LogManager.GetLogger(typeof(MonthlyContractAllowanceItem));
        public static ICache<string, MonthlyContractAllowanceItem> MONTHLY_CONTRACT_ALLOWANCEITEM_CACHE = MemoryCache<string, MonthlyContractAllowanceItem>.Instance;

        #region GetMonthlyContractAllowanceItem

        public static MonthlyContractAllowanceItem GetMonthlyContractAllowanceItem(Guid id)
        {
            MonthlyContractAllowanceItem obj = (MonthlyContractAllowanceItem)Session.DefaultSession.GetObjectByKey(typeof(MonthlyContractAllowanceItem), id);
            return obj;
        }

        public static MonthlyContractAllowanceItem GetMonthlyContractAllowanceItem(string emplid, string period)
        {
            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                       new BinaryOperator("员工编号", emplid, BinaryOperatorType.Equal),
                       new BinaryOperator("期间", period, BinaryOperatorType.Equal)
                       );

            XPCollection objset = new XPCollection(typeof(MonthlyContractAllowanceItem), criteria, new SortProperty("创建时间", SortingDirection.Descending));

            if (objset.Count > 0)
            {
                return (MonthlyContractAllowanceItem)objset[0];
            }
            else
                return null;
        }

        public static MonthlyContractAllowanceItem GetMonthlyContractAllowanceItem(string emplid, int year, int month)
        {
            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                       new BinaryOperator("员工编号", emplid, BinaryOperatorType.Equal),
                       new BinaryOperator("年", year, BinaryOperatorType.Equal),
                       new BinaryOperator("月", month, BinaryOperatorType.Equal)
                       );

            XPCollection objset = new XPCollection(typeof(MonthlyContractAllowanceItem), criteria, new SortProperty("创建时间", SortingDirection.Descending));

            if (objset.Count > 0)
            {
                return (MonthlyContractAllowanceItem)objset[0];
            }
            else
                return null;
        }

        #endregion

        #region GetFromCache

        public static MonthlyContractAllowanceItem GetFromCache(string emplid, string period)
        {
            string key = emplid + "$$" + period;
            return MONTHLY_CONTRACT_ALLOWANCEITEM_CACHE.Get(key, () => GetMonthlyContractAllowanceItem(emplid, period), TimeSpan.FromHours(10));
        }
        #endregion

        #region GetMonthlyContractAllowanceItems

        public static List<MonthlyContractAllowanceItem> GetMonthlyContractAllowanceItems(string emplid)
        {
            return GetMonthlyContractAllowanceItems(emplid, -1);
        }

        public static List<MonthlyContractAllowanceItem> GetMonthlyContractAllowanceItems(string emplid, int year)
        {
            List<MonthlyContractAllowanceItem> list = new List<MonthlyContractAllowanceItem>();

            GroupOperator criteria = new GroupOperator(GroupOperatorType.And, new BinaryOperator("员工编号", emplid, BinaryOperatorType.Equal));

            if (year >= 2018) criteria.Operands.Add(new BinaryOperator("年", year, BinaryOperatorType.Equal));

            XPCollection objset = new XPCollection(typeof(MonthlyContractAllowanceItem), criteria, new SortProperty("期间", SortingDirection.Ascending));

            foreach (MonthlyContractAllowanceItem ms in objset)
            {
                list.Add(ms);
            }
            return list;
        }

        public static List<MonthlyContractAllowanceItem> GetMonthlyContractAllowanceItems(int year, int month)
        {
            List<MonthlyContractAllowanceItem> list = new List<MonthlyContractAllowanceItem>();

            GroupOperator criteria = new GroupOperator(GroupOperatorType.And);
            criteria.Operands.Add(new BinaryOperator("年", year, BinaryOperatorType.Equal));
            criteria.Operands.Add(new BinaryOperator("月", month, BinaryOperatorType.Equal));

            XPCollection objset = new XPCollection(typeof(MonthlyContractAllowanceItem), criteria, new SortProperty("创建时间", SortingDirection.Ascending));

            foreach (MonthlyContractAllowanceItem ms in objset)
            {
                list.Add(ms);
            }
            return list;
        }

        #endregion

        #region AddMonthlyContractAllowanceItem

        public static MonthlyContractAllowanceItem AddMonthlyContractAllowanceItem(string emplid, int year, int month)
        {
            MonthlyContractAllowanceItem item = GetMonthlyContractAllowanceItem(emplid, year, month);
            if (item == null)
            {
                item = new MonthlyContractAllowanceItem();
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

        #region GetPrevPeriod
        //获取上一期（上月）报账记录
        public static string GetPrevPeriod(string emplid, string period)
        {
            string sql = "SELECT TOP 1 期间  FROM 薪酬结构_契约津贴_发放明细 WHERE 员工编号 = '" + emplid + "' AND 期间 < '" + period + "' ORDER BY 期间 DESC";
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
                            return (string)rs["期间"];
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

        #region OnSaving

        protected override void OnSaving()
        {
            if(this.期间 == null) this.期间 = GetPeriod(年, 月);

            MonthlyContractAllowanceItem found = GetMonthlyContractAllowanceItem(this.员工编号, this.期间);
            if (found != null && found.标识 != this.标识)
                throw new Exception("已存在该员工的契约津贴发放记录，不能重复创建。");
            else
                base.OnSaving();

            MONTHLY_CONTRACT_ALLOWANCEITEM_CACHE.Set(CacheKey, this, TimeSpan.FromHours(10));
        }
        #endregion

        #region OnDeleting

        protected override void OnDeleting()
        {
            base.OnDeleting();
            MONTHLY_CONTRACT_ALLOWANCEITEM_CACHE.Remove(CacheKey);
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
            MONTHLY_CONTRACT_ALLOWANCEITEM_CACHE.Set(this.CacheKey, this, TimeSpan.FromHours(10));
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

        #region 发放月份
        public string 发放月份
        {
            get
            {
                return 年 + "年" + 月 + "月";
            }
        }
        #endregion

        #region 打印按钮文字
        public string 打印按钮文字
        {
            get { return "打印"; }
        }
        #endregion

        #region 上表工资
        SalaryResult sr = null;
        public SalaryResult 上表工资
        {
            get
            {
                if (sr == null) sr = SalaryResult.GetSalaryResult(员工编号, 年, 月);
                return sr;
            }
        }
        #endregion

        #region 发放单位
        public string 发放单位
        {
            get
            {
                if (上表工资 != null)
                    return 上表工资.财务公司;
                else
                    return 员工信息.财务公司;

            }
        }
        #endregion

        #region 实际发放金额_大写
        public string 实际发放金额_大写
        {
            get
            {
                return Common.CmycurD(this.实际发放金额);
            }
        }
        #endregion

        #region 执行标准
        ContractAllowance ContractAllowance = null;
        public ContractAllowance 执行标准
        {
            get
            {
                if (ContractAllowance == null) ContractAllowance = ContractAllowance.GetEffective(员工编号, 期间开始);
                return ContractAllowance;
            }
        }
        #endregion
    }
}
