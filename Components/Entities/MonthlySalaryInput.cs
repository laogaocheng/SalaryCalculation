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
using System.ComponentModel;

namespace Hwagain.SalaryCalculation.Components
{
    public partial class MonthlySalaryInput
    {
        static readonly ILog log = LogManager.GetLogger(typeof(MonthlySalaryInput));
        public static ICache<string, RankSalaryStandard> MONTHLY_SALARY_INPUT_CACHE = MemoryCache<string, RankSalaryStandard>.Instance;

        #region GetMonthlySalaryInput

        public static MonthlySalaryInput GetMonthlySalaryInput(Guid id)
        {
            MonthlySalaryInput obj = (MonthlySalaryInput)Session.DefaultSession.GetObjectByKey(typeof(MonthlySalaryInput), id);
            return obj;
        }

        public static MonthlySalaryInput GetMonthlySalaryInput(string emplid, int period, bool isVerify)
        {
            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                       new BinaryOperator("员工编号", emplid, BinaryOperatorType.Equal),
                       new BinaryOperator("期号", period, BinaryOperatorType.Equal),
                       new BinaryOperator("是验证录入", isVerify, BinaryOperatorType.Equal));

            XPCollection objset = new XPCollection(typeof(MonthlySalaryInput), criteria, new SortProperty("开始执行日期", SortingDirection.Ascending));

            if (objset.Count > 0)
            {
                return (MonthlySalaryInput)objset[0];
            }
            else
                return null;
        }

        #endregion

        #region GetMonthlySalaryInputs

        //获取XXX年X半年薪酬执行标准
        public static List<MonthlySalaryInput> GetMonthlySalaryInputs(string salaryPlan, string group, int period, bool isVerify)
        {
            List<MonthlySalaryInput> list = new List<MonthlySalaryInput>();

            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                       new BinaryOperator("薪酬体系", salaryPlan, BinaryOperatorType.Equal),
                       new BinaryOperator("期号", period, BinaryOperatorType.Equal),
                       new BinaryOperator("是验证录入", isVerify, BinaryOperatorType.Equal));

            if (!string.IsNullOrEmpty(group)) criteria.Operands.Add(new BinaryOperator("群组", group, BinaryOperatorType.Equal));

            XPCollection objset = new XPCollection(typeof(MonthlySalaryInput), criteria, new SortProperty("执行_月薪", SortingDirection.Descending));

            foreach (MonthlySalaryInput ms in objset)
            {
                list.Add(ms);                
            }
            return list;
        }
        #endregion
        
        #region GetPreviousPeriodStandards

        //获取上一期的标准
        public static List<RankSalaryStandard> GetPreviousPeriodStandards(string salaryPlan, string group, int period)
        {
            return RankSalaryStandard.GetPreviousPeriodStandards(salaryPlan, group, period);
        }
        #endregion

        #region GetEditingRows

        /// <summary>
        /// 获取正在录入的记录
        /// </summary>
        /// <param name="stepId"></param>
        /// <param name="isVerify"></param>
        /// <returns></returns>
        public static List<MonthlySalaryInput> GetEditingRows(string salaryPlan, string group, int period, bool isVerify)
        {
            List<MonthlySalaryInput> rows = new List<MonthlySalaryInput>();

            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                       new BinaryOperator("薪酬体系", salaryPlan, BinaryOperatorType.Equal),
                       new BinaryOperator("群组", group, BinaryOperatorType.Equal),
                       new BinaryOperator("期号", period, BinaryOperatorType.Equal),
                       new BinaryOperator("是验证录入", isVerify, BinaryOperatorType.Equal));

            XPCollection objset = new XPCollection(MyHelper.XpoSession, typeof(MonthlySalaryInput), criteria, new SortProperty("序号", SortingDirection.Ascending), new SortProperty("执行_月薪", SortingDirection.Descending));

            foreach (MonthlySalaryInput input in objset)
            {
                rows.Add(input);
            }
            return rows;
        }
        #endregion

        #region GetEditingRow

        /// <summary>
        /// 获取正在录入的单独调整员工执行_月薪的记录
        /// </summary>
        /// <param name="isVerify"></param>
        /// <returns></returns>
        public static MonthlySalaryInput GetEditingRow(string emplid, bool isVerify)
        {            
            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                       new BinaryOperator("员工编号", emplid, BinaryOperatorType.Equal),
                       new NullOperator("生效时间"),
                       new BinaryOperator("期号", 200000, BinaryOperatorType.Greater),    //个人单独调整的记录是6位数，如 201712                   
                       new BinaryOperator("是验证录入", isVerify, BinaryOperatorType.Equal));

            XPCollection objset = new XPCollection(MyHelper.XpoSession, typeof(MonthlySalaryInput), criteria, new SortProperty("执行_月薪", SortingDirection.Descending));

            if (objset.Count > 0)
            {
                return (MonthlySalaryInput)objset[0];
            }
            else
                return null;
        }
        #endregion

        #region ClearMonthlySalaryInput
        
        //清除指定期号的录入记录(只能清除未生效的记录)
        public static void ClearMonthlySalaryInput(string salaryPlan, string group, int period, bool isCheck)
        {
            string sql = "DELETE FROM 薪酬执行明细_录入 WHERE (薪酬体系 = '" + salaryPlan + "') AND (群组 = '" + group + "') AND 是验证录入=" + (isCheck ? 1 : 0) + " AND 生效时间 IS NULL";
            if (period > 0) sql += " AND 期号 = " + period;
            using (SqlConnection connection = new SqlConnection(MyHelper.GetConnectionString()))
            {
                YiKang.Data.SqlHelper.ExecuteNonQuery(connection, System.Data.CommandType.Text, sql);
                
            }
        }
        #endregion

        #region AddMonthlySalaryInput

        public static MonthlySalaryInput AddMonthlySalaryInput(string emplid, int period, bool isVerify)
        {
            return AddMonthlySalaryInput(emplid, period, isVerify, false);
        }

        public static MonthlySalaryInput AddMonthlySalaryInput(string emplid, int period, bool isVerify, bool copyEffective)
        {
            MonthlySalaryInput item = GetMonthlySalaryInput(emplid, period, isVerify);
            if (item == null)
            {
                item = new MonthlySalaryInput();

                if (copyEffective)
                {
                    //将当前执行的标准带过来
                    MonthlySalary effectiveMonthlySalary = MonthlySalary.GetEffective(emplid, DateTime.Today);
                    if (effectiveMonthlySalary != null)
                    {
                        item.CopyEffective = copyEffective;
                        effectiveMonthlySalary.CopyWatchMember(item);                        
                    }
                }

                item.标识 = Guid.NewGuid();
                item.员工编号 = emplid;
                item.期号 = period;
                item.是验证录入 = isVerify;
                item.薪酬体系 = "";
                item.录入人 = "   ";
                item.录入时间 = DateTime.Now;

                item.Save();                
            }            
            return item;
        }
        #endregion

        #region UpdateToFormalTable
        //更新到正式表
        public void UpdateToFormalTable()
        {
            MonthlySalary m = MonthlySalary.GetMonthlySalary(this.员工编号, this.开始执行日期);
            if (m == null)
            {
                m = new MonthlySalary();
                m.标识 = Guid.NewGuid();
            }
            this.CopyWatchMember(m);
            m.序号 = this.序号;
            m.备注 = m.调整类型;
            m.截止日期 = DateTime.MinValue;
            m.Save();

            //历史记录失效
            List<MonthlySalary> list = MonthlySalary.GetMonthlySalarys(this.员工编号);
            MonthlySalary prev = null;
            foreach (MonthlySalary item in list)
            {
                if (item.标识 == m.标识 || item.截止日期 != DateTime.MinValue || prev == null)
                {
                    prev = item;
                    continue;
                }
                item.截止日期 = prev.开始执行日期.AddDays(-1);
                item.Save();
                prev = item;
            }

            //更新生效标记
            if (!this.已生效)
            {
                this.生效时间 = DateTime.Now;
                this.Save();

                MonthlySalaryInput opposite = 另一人录入的记录;
                opposite.生效时间 = DateTime.Now;
                opposite.Save();
            }
        }
        #endregion

        #region OnSaving

        protected override void OnSaving()
        {
            if (string.IsNullOrEmpty(this.员工编号)) throw new Exception("员工编号不能为空");
            if (this.期号 == 0) throw new Exception("期号不能为空");

            MonthlySalaryInput found = GetMonthlySalaryInput(this.员工编号, this.期号, this.是验证录入);
            if (found != null && found.标识 != this.标识)
                throw new Exception("本期已存在该员工的月薪标准，不能创建。");
            else
                base.OnSaving();

            contentDifferentFields = null;
            MONTHLY_SALARY_INPUT_CACHE.Set(CacheKey, this, TimeSpan.FromHours(1));
        }
        #endregion        

        #region OnDeleting

        protected override void OnDeleting()
        {
            base.OnDeleting();
            MONTHLY_SALARY_INPUT_CACHE.Remove(CacheKey);   
        }
        #endregion

        #region OnLoaded

        protected override void OnLoaded()
        {
            AutoSaveOnEndEdit = false; //关闭自动保存的开关
            //缓存
            MONTHLY_SALARY_INPUT_CACHE.Set(CacheKey, this, TimeSpan.FromHours(1));
            base.OnLoaded();
        }
        #endregion

        #region CompareInputContent
        //比较录入的内容
        public void CompareInputContent()
        {
            contentDifferentFields = null;
            GetModifiyFields();
        }
        #endregion

        #region GetModifiyFields

        public void GetModifiyFields()
        {
            if (contentDifferentFields == null)
            {
                contentDifferentFields = new List<ModifyField>();
                //上月后才生效的或者另一人已录入
                if (this.开始执行日期 >= MyHelper.GetPrevMonth1Day() || 另一人录入的记录 != null)
                {
                    if (另一人录入的记录 != null) 另一人录入的记录.Reload();
                     contentDifferentFields = MyHelper.GetModifyFields(this, 另一人录入的记录);
                }

            }                
        }
        #endregion

        #region 上期标准

        public MonthlySalary 上期标准
        {
            get
            {
                //获取上一期的开始执行日期
                DateTime prevDate = MonthlySalary.GetEmployeePreviousDate(this.员工编号, this.开始执行日期);
                return MonthlySalary.GetFromCache(this.员工编号, prevDate);
            }
        }
        #endregion

        #region 内容不同的字段

        List<ModifyField> contentDifferentFields = null;
        [Browsable(false)]
        public List<ModifyField> 内容不同的字段
        {
            get
            {
                if (contentDifferentFields == null) GetModifiyFields();
                return contentDifferentFields;
            }
        }

        #endregion

        #region 另一人录入的记录

        MonthlySalaryInput anotherInput = null;
        [Browsable(false)]
        public MonthlySalaryInput 另一人录入的记录
        {
            get
            {
                if (anotherInput == null)
                {
                    anotherInput = GetMonthlySalaryInput(this.员工编号, this.期号, !this.是验证录入);
                }
                return anotherInput;
            }
        }
        #endregion

        #region 另一人已录入

        public bool 另一人已录入
        {
            get
            {
                return 另一人录入的记录 != null;
            }
        }
        #endregion

        #region 已生效

        public bool 已生效
        {
            get
            {
                return this.生效时间 != DateTime.MinValue;
            }
        }
        #endregion

        #region 是新表

        [Browsable(false)]
        public bool 是新表
        {
            get
            {
                return this.录入时间.Year < 2010;
            }
        }
        #endregion

        #region 员工信息

        EmployeeInfo empInfo = null;
        public EmployeeInfo 员工信息
        {
            get
            {
                if (empInfo == null) empInfo = EmployeeInfo.GetEmployeeInfo(this.员工编号);
                return empInfo;
            }
        }
        #endregion

        #region CacheKey

        string CacheKey
        {
            get { return this.员工编号 + "$$" + this.期号 + "$$" + this.是验证录入; }
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
                    DateTime lastSalaryDate = SalaryResult.GetLastestDate(员工信息.员工编号);
                    SalaryResult sr = SalaryResult.GetFromCache(员工信息.员工编号, lastSalaryDate.Year, lastSalaryDate.Month);
                    if (sr != null)
                        return PsHelper.GetJobNameFromCache(sr.职务代码);
                    else
                        return "";
                }
                return null;
            }
        }

        #endregion

        [NonPersistent]
        public bool CopyEffective { get; set; }
    }
}
