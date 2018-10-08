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
    public partial class SalaryStructure
    {
        static readonly ILog log = LogManager.GetLogger(typeof(SalaryStructure));
        public static ICache<string, SalaryStructure> SALARY_STRUCTURE_CACHE = MemoryCache<string, SalaryStructure>.Instance;

        #region GetSalaryStructure

        public static SalaryStructure GetSalaryStructure(Guid id)
        {
            SalaryStructure obj = (SalaryStructure)Session.DefaultSession.GetObjectByKey(typeof(SalaryStructure), id);
            return obj;
        }

        public static SalaryStructure GetSalaryStructure(string emplid, DateTime effDate)
        {
            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                       new BinaryOperator("员工编号", emplid, BinaryOperatorType.Equal),
                       new BinaryOperator("开始执行日期", effDate, BinaryOperatorType.Equal)
                       );

            XPCollection objset = new XPCollection(typeof(SalaryStructure), criteria, new SortProperty("创建时间", SortingDirection.Descending));

            if (objset.Count > 0)
            {
                return (SalaryStructure)objset[0];
            }
            else
                return null;
        }

        #endregion

        #region GetFromCache

        public static SalaryStructure GetFromCache(string emplid, DateTime effDate)
        {
            string key = emplid + "$$" + effDate;
            return SALARY_STRUCTURE_CACHE.Get(key, () => GetSalaryStructure(emplid, effDate), TimeSpan.FromHours(1));                
        }
        #endregion

        #region GetEffective

        //获取指定员工指定时间执行的标准
        public static SalaryStructure GetEffective(string emplid, DateTime date)
        {
            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                       new BinaryOperator("员工编号", emplid, BinaryOperatorType.Equal),
                       new BinaryOperator("开始执行日期", date.Date, BinaryOperatorType.LessOrEqual)
                       );

            XPCollection objset = new XPCollection(MyHelper.XpoSession, typeof(SalaryStructure), criteria, new SortProperty("开始执行日期", SortingDirection.Descending));

            if (objset.Count > 0)
            {
                SalaryStructure item = (SalaryStructure)objset[0];
                if (item.截止日期 == DateTime.MinValue || item.截止日期 >= date.Date)
                    return item;
                else
                    return null;
            }
            else
                return null;
        }

        #endregion

        #region GetEffectiveSalaryStructures
        public static List<SalaryStructure> GetEffectiveSalaryStructures()
        {
            return GetSalaryStructures(null, false);
        }

        #endregion

        #region GetSalaryStructures

        public static List<SalaryStructure> GetSalaryStructures(string emplid, bool includeHistory)
        {
            List<SalaryStructure> list = new List<SalaryStructure>();

            GroupOperator criteria = new GroupOperator(GroupOperatorType.And);

            if (!string.IsNullOrEmpty(emplid)) criteria.Operands.Add(new BinaryOperator("员工编号", emplid, BinaryOperatorType.Equal));
            if (includeHistory == false)
            {
                criteria.Operands.Add(new NullOperator("截止日期"));
            }

            XPCollection objset = new XPCollection(typeof(SalaryStructure), criteria, new SortProperty("开始执行日期", SortingDirection.Ascending));

            foreach (SalaryStructure ms in objset)
            {
                list.Add(ms);                
            }
            return list;
        }

        #endregion

        #region AddSalaryStructure

        public static SalaryStructure AddSalaryStructure(string emplid, DateTime effDate)
        {
            SalaryStructure item = GetSalaryStructure(emplid, effDate);
            if (item == null)
            {
                item = new SalaryStructure();
                item.标识 = Guid.NewGuid();
                item.员工编号 = emplid;
                item.开始执行日期 = effDate;
                item.创建人 = AccessController.CurrentUser.姓名;
                item.创建时间 = DateTime.Now;
                item.Save();
            }
            return item;
        }
        /// <summary>
        /// 获取有绩效工资的薪酬结构
        /// </summary>
        /// <returns></returns>
        public static List<SalaryStructure> GetHasPerformanceSalaryEmployees()
        {
            List<SalaryStructure> list = new List<SalaryStructure>();

            GroupOperator criteria = new GroupOperator(GroupOperatorType.And);

            criteria.Operands.Add(new BinaryOperator("月薪项目_减项_绩效工资", 0, BinaryOperatorType.Greater));
            criteria.Operands.Add(new NullOperator("截止日期"));
            
            XPCollection objset = new XPCollection(typeof(SalaryStructure), criteria, new SortProperty("开始执行日期", SortingDirection.Ascending));

            foreach (SalaryStructure ms in objset)
            {
                list.Add(ms);
            }
            return list;
        }
        #endregion

        #region OnSaving

        protected override void OnSaving()
        {
            SalaryStructure found = GetSalaryStructure(this.员工编号, this.开始执行日期);
            if (found != null && found.标识 != this.标识)
                throw new Exception("已存在该员工的相同薪酬结构记录，不能重复创建。");
            else
                base.OnSaving();

            SALARY_STRUCTURE_CACHE.Set(CacheKey, this, TimeSpan.FromHours(1));
        }
        #endregion

        #region OnDeleting

        protected override void OnDeleting()
        {
            base.OnDeleting();
            SALARY_STRUCTURE_CACHE.Remove(CacheKey);
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
            SALARY_STRUCTURE_CACHE.Set(this.CacheKey, this, TimeSpan.FromHours(1));
            base.OnLoaded();
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

        #region 公司

        public string 公司
        {
            get
            {
                if (员工信息 != null)
                {
                    return 员工信息.公司;
                }
                return null;
            }
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

    }
}
