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
    public partial class RembursementSalary
    {
        static readonly ILog log = LogManager.GetLogger(typeof(RembursementSalary));
        public static ICache<string, RembursementSalary> REMBURSEMENT_SALARY_CACHE = MemoryCache<string, RembursementSalary>.Instance;

        #region GetRembursementSalary

        public static RembursementSalary GetRembursementSalary(Guid id)
        {
            RembursementSalary obj = (RembursementSalary)Session.DefaultSession.GetObjectByKey(typeof(RembursementSalary), id);
            return obj;
        }

        public static RembursementSalary GetRembursementSalary(string emplid, DateTime effDate)
        {
            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                       new BinaryOperator("员工编号", emplid, BinaryOperatorType.Equal),
                       new BinaryOperator("开始时间", effDate, BinaryOperatorType.Equal)
                       );

            XPCollection objset = new XPCollection(typeof(RembursementSalary), criteria, new SortProperty("开始时间", SortingDirection.Descending));

            if (objset.Count > 0)
            {
                return (RembursementSalary)objset[0];
            }
            else
                return null;
        }

        #endregion

        #region GetFromCache

        public static RembursementSalary GetFromCache(string emplid, DateTime effDate)
        {
            string key = emplid + "$$" + effDate;
            return REMBURSEMENT_SALARY_CACHE.Get(key, () => GetRembursementSalary(emplid, effDate), TimeSpan.FromHours(1));                
        }
        #endregion

        #region GetEffective

        //获取指定员工指定时间执行的标准
        public static RembursementSalary GetEffective(string emplid, DateTime date)
        {
            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                       new BinaryOperator("员工编号", emplid, BinaryOperatorType.Equal),
                       new BinaryOperator("开始时间", date.Date, BinaryOperatorType.LessOrEqual),
                       new BinaryOperator("结束时间", date.Date, BinaryOperatorType.GreaterOrEqual)
                       );

            XPCollection objset = new XPCollection(MyHelper.XpoSession, typeof(RembursementSalary), criteria, new SortProperty("开始时间", SortingDirection.Descending));

            if (objset.Count > 0)
            {
                return (RembursementSalary)objset[0];
            }
            else
                return null;
        }

        #endregion

        #region GetEffectiveRembursementSalary

        public static RembursementSalary GetEffectiveRembursementSalary(string emplid, DateTime date)
        {
            List<RembursementSalary> list = new List<RembursementSalary>();

            GroupOperator criteria = new GroupOperator(GroupOperatorType.And);
            criteria.Operands.Add(new BinaryOperator("员工编号", emplid, BinaryOperatorType.Equal));
            criteria.Operands.Add(new BinaryOperator("开始时间", date.Date, BinaryOperatorType.LessOrEqual));
            criteria.Operands.Add(new BinaryOperator("结束时间", date.Date.AddDays(1), BinaryOperatorType.Greater));

            XPCollection objset = new XPCollection(typeof(RembursementSalary), criteria, new SortProperty("开始时间", SortingDirection.Descending));
            
            if (objset.Count > 0)
                return (RembursementSalary)objset[0];
            else
                return null;
        }

        #endregion

        #region GetEffectiveRembursementSalarys
        public static List<RembursementSalary> GetEffectiveRembursementSalarys()
        {
            return GetRembursementSalarys(null, false);
        }

        #endregion

        #region GetRembursementSalarys

        public static List<RembursementSalary> GetRembursementSalarys(string emplid, bool includeHistory)
        {
            List<RembursementSalary> list = new List<RembursementSalary>();

            GroupOperator criteria = new GroupOperator(GroupOperatorType.And);

            if (!string.IsNullOrEmpty(emplid)) criteria.Operands.Add(new BinaryOperator("员工编号", emplid, BinaryOperatorType.Equal));
            if (includeHistory == false)
            {
                criteria.Operands.Add(new BinaryOperator("结束时间", DateTime.Today, BinaryOperatorType.GreaterOrEqual));
            }
            XPCollection objset = new XPCollection(typeof(RembursementSalary), criteria, new SortProperty("开始时间", SortingDirection.Descending));

            foreach (RembursementSalary ms in objset)
            {
                list.Add(ms);                
            }
            return list;
        }

        #endregion

        #region AddRembursementSalary

        public static RembursementSalary AddRembursementSalary(string emplid, DateTime effDate)
        {
            RembursementSalary item = GetRembursementSalary(emplid, effDate);
            if (item == null)
            {
                item = new RembursementSalary();
                item.标识 = Guid.NewGuid();
                item.员工编号 = emplid;
                item.开始时间 = effDate;
                item.创建人 = AccessController.CurrentUser.姓名;
                item.创建时间 = DateTime.Now;
                item.Save();
            }
            return item;
        }
        #endregion

        #region OnSaving

        protected override void OnSaving()
        {
            RembursementSalary found = GetRembursementSalary(this.员工编号, this.开始时间);
            if (found != null && found.标识 != this.标识)
                throw new Exception("已存在该员工的相同借款记录，不能重复创建。");
            else
                base.OnSaving();

            REMBURSEMENT_SALARY_CACHE.Set(CacheKey, this, TimeSpan.FromHours(1));
        }
        #endregion

        #region OnDeleting

        protected override void OnDeleting()
        {
            base.OnDeleting();
            REMBURSEMENT_SALARY_CACHE.Remove(CacheKey);
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
            REMBURSEMENT_SALARY_CACHE.Set(this.CacheKey, this, TimeSpan.FromHours(1));
            base.OnLoaded();
        }
        #endregion

        #region CacheKey

        string CacheKey
        {
            get { return this.员工编号 + "$$" + this.开始时间; }
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

        #region 上年剩余可报账金额

        object lastYearSurplus = null;
        public decimal 上年剩余可报账金额
        {
            get
            {
                if (lastYearSurplus == null) lastYearSurplus = MonthlyRembursementSalaryItem.GetLastYearSurplus(员工编号, DateTime.Today.Year);
                return Convert.ToDecimal(lastYearSurplus);

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

        #region 本年累计实际报账金额
        [NonPersistent]
        public decimal 本年累计实际报账金额
        {
            get
            {
                List<MonthlyRembursementSalaryItem> list = 本年所有报账记录;
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
                if (thisYearItems == null) thisYearItems = MonthlyRembursementSalaryItem.GetMonthlyRembursementSalaryItems(员工编号, DateTime.Today.Year);
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
                return 本年可报账金额 - 本年累计实际报账金额;
            }
        }
        #endregion

        #region 执行状态

        public string 执行状态
        {
            get
            {
                if (DateTime.Today < 开始时间)
                    return "未生效";
                else
                {
                    if (DateTime.Today > 结束时间)
                        return "已失效";
                    else
                        return "执行中";
                }
            }
        }
        #endregion

        #region 查看明细按钮文字
        public string 查看明细按钮文字
        {
            get { return "查看明细"; }
        }
        #endregion

        #region 发放明细表
        List<MonthlyRembursementSalaryItem> items = null;
        public List<MonthlyRembursementSalaryItem> 发放明细表
        {
            get
            {
                if (items == null)
                {
                    items = MonthlyRembursementSalaryItem.GetMonthlyRembursementSalaryItems(员工编号);
                    items = items.FindAll(a => a.期间开始 >= 开始时间 && a.期间开始 < 结束时间);
                    items = items.OrderBy(a => a.期间开始).ToList();
                }
                return items;
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
                if (开始时间.Year == DateTime.Today.Year) 生效之前的额度 = 月度可报账标准_税后 * (开始时间.Month - 1);
                return 年度可报账标准_税后 - 生效之前的额度;
            }
        }
        #endregion
    }
}
