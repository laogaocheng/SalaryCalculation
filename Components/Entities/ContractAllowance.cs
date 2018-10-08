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
    public partial class ContractAllowance
    {
        static readonly ILog log = LogManager.GetLogger(typeof(ContractAllowance));
        public static ICache<string, ContractAllowance> CONTRACT_ALLOWANCE_CACHE = MemoryCache<string, ContractAllowance>.Instance;

        #region GetContractAllowance

        public static ContractAllowance GetContractAllowance(Guid id)
        {
            ContractAllowance obj = (ContractAllowance)Session.DefaultSession.GetObjectByKey(typeof(ContractAllowance), id);
            return obj;
        }

        public static ContractAllowance GetContractAllowance(string emplid, DateTime effDate)
        {
            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                       new BinaryOperator("员工编号", emplid, BinaryOperatorType.Equal),
                       new BinaryOperator("开始时间", effDate, BinaryOperatorType.Equal)
                       );

            XPCollection objset = new XPCollection(typeof(ContractAllowance), criteria, new SortProperty("开始时间", SortingDirection.Descending));

            if (objset.Count > 0)
            {
                return (ContractAllowance)objset[0];
            }
            else
                return null;
        }

        #endregion

        #region GetFromCache

        public static ContractAllowance GetFromCache(string emplid, DateTime effDate)
        {
            string key = emplid + "$$" + effDate;
            return CONTRACT_ALLOWANCE_CACHE.Get(key, () => GetContractAllowance(emplid, effDate), TimeSpan.FromHours(1));
        }
        #endregion

        #region GetEffective

        //获取指定员工指定时间执行的标准
        public static ContractAllowance GetEffective(string emplid, DateTime date)
        {
            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                       new BinaryOperator("员工编号", emplid, BinaryOperatorType.Equal),
                       new BinaryOperator("开始时间", date.Date, BinaryOperatorType.LessOrEqual),
                       new BinaryOperator("结束时间", date.Date, BinaryOperatorType.GreaterOrEqual)
                       );

            XPCollection objset = new XPCollection(MyHelper.XpoSession, typeof(ContractAllowance), criteria, new SortProperty("开始时间", SortingDirection.Descending));

            if (objset.Count > 0)
            {
                return (ContractAllowance)objset[0];
            }
            else
                return null;
        }

        #endregion

        #region GetEffectiveContractAllowances
        public static List<ContractAllowance> GetEffectiveContractAllowances()
        {
            return GetContractAllowances(null, false);
        }

        #endregion

        #region GetContractAllowances

        public static List<ContractAllowance> GetContractAllowances(string emplid, bool includeHistory)
        {
            List<ContractAllowance> list = new List<ContractAllowance>();

            GroupOperator criteria = new GroupOperator(GroupOperatorType.And);

            if (!string.IsNullOrEmpty(emplid)) criteria.Operands.Add(new BinaryOperator("员工编号", emplid, BinaryOperatorType.Equal));
            if (includeHistory == false)
            {
                criteria.Operands.Add(new BinaryOperator("结束时间", DateTime.Today, BinaryOperatorType.GreaterOrEqual));
            }

            XPCollection objset = new XPCollection(typeof(ContractAllowance), criteria, new SortProperty("开始时间", SortingDirection.Ascending));

            foreach (ContractAllowance ms in objset)
            {
                list.Add(ms);
            }
            return list;
        }
        //获取区间内执行的标准
        public static List<ContractAllowance> GetContractAllowances(int year, int month)
        {
            DateTime start = new DateTime(year, month, 1);
            DateTime end = start.AddMonths(1).AddDays(-1);
            List<ContractAllowance> list = new List<ContractAllowance>();

            GroupOperator criteria = new GroupOperator(GroupOperatorType.And);
            criteria.Operands.Add(new BinaryOperator("开始时间", end.Date, BinaryOperatorType.LessOrEqual));
            criteria.Operands.Add(new BinaryOperator("结束时间", start.Date, BinaryOperatorType.GreaterOrEqual));

            XPCollection objset = new XPCollection(typeof(ContractAllowance), criteria, new SortProperty("开始时间", SortingDirection.Ascending));

            foreach (ContractAllowance ms in objset)
            {
                list.Add(ms);
            }
            return list;
        }

        #endregion

        #region AutoGenerateMonthlyContractAllowanceItems

        //自动创建契约津贴发放记录
        public static List<MonthlyContractAllowanceItem> AutoGenerateMonthlyContractAllowanceItems(int year, int month)
        {
            List<MonthlyContractAllowanceItem> list = new List<MonthlyContractAllowanceItem>();
            //获取正在执行的借款标准
            List<ContractAllowance> ContractAllowanceList = GetContractAllowances(year, month);
            foreach (ContractAllowance wa in ContractAllowanceList)
            {
                SalaryResult sr = SalaryResult.GetFromCache(wa.员工编号, year, month);
                //如果已经发上表工资
                if (sr != null)
                {
                    if (sr.企业排班天数 == 0) continue;

                    MonthlyContractAllowanceItem item = MonthlyContractAllowanceItem.AddMonthlyContractAllowanceItem(wa.员工编号, year, month);
                    item.姓名 = sr.姓名;
                    item.月津贴标准 = wa.月津贴额度;
                    item.应出勤天数 = sr.企业排班天数;
                    item.实际出勤天数 = sr.实际出勤天数;
                    item.实际发放金额 = Math.Round(wa.月津贴额度 * (sr.实际出勤天数 / sr.企业排班天数), 2);
                    item.Save();

                    list.Add(item);
                }
            }
            return list;
        }
        #endregion

        #region AddContractAllowance

        public static ContractAllowance AddContractAllowance(string emplid, DateTime effDate)
        {
            ContractAllowance item = GetContractAllowance(emplid, effDate);
            if (item == null)
            {
                item = new ContractAllowance();
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
            ContractAllowance found = GetContractAllowance(this.员工编号, this.开始时间);
            if (found != null && found.标识 != this.标识)
                throw new Exception("已存在该员工相同的契约津贴记录，不能重复创建。");
            else
                base.OnSaving();

            CONTRACT_ALLOWANCE_CACHE.Set(CacheKey, this, TimeSpan.FromHours(1));
        }
        #endregion

        #region OnDeleting

        protected override void OnDeleting()
        {
            base.OnDeleting();
            CONTRACT_ALLOWANCE_CACHE.Remove(CacheKey);
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
            CONTRACT_ALLOWANCE_CACHE.Set(this.CacheKey, this, TimeSpan.FromHours(1));
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

        #region 发放明细表
        List<MonthlyContractAllowanceItem> items = null;
        public List<MonthlyContractAllowanceItem> 发放明细表
        {
            get
            {
                if (items == null)
                {
                    items = MonthlyContractAllowanceItem.GetMonthlyContractAllowanceItems(员工编号);
                    items = items.FindAll(a => a.期间开始 >= 开始时间 && a.期间开始 < 结束时间);
                    items = items.OrderBy(a => a.期间开始).ToList();
                }
                return items;
            }
        }
        #endregion

        #region 累计实际发放金额

        public decimal 累计实际发放金额
        {
            get
            {
                return 发放明细表.Sum(a => a.实际发放金额);
            }
        }
        #endregion

        #region 已执行年限

        public int 已执行年限
        {
            get
            {
                return 发放明细表.Count;
            }
        }
        #endregion

        #region 月均实际借款金额

        public decimal 月均实际借款金额
        {
            get
            {
                if (已执行年限 > 0)
                    return 累计实际发放金额 / 已执行年限;
                else
                    return 0;
            }
        }

        #endregion

        #region 查看明细按钮文字
        public string 查看明细按钮文字
        {
            get { return "查看明细"; }
        }
        #endregion
    }
}
