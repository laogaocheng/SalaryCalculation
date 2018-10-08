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
    public partial class RankSalaryStandardInput : IRankSalary
    {
        static readonly ILog log = LogManager.GetLogger(typeof(RankSalaryStandardInput));
        public static ICache<string, RankSalaryStandardInput> RANK_SALARY_STANDARD_INPUT_CACHE = MemoryCache<string, RankSalaryStandardInput>.Instance;

        #region GetRankSalaryStandardInput

        public static RankSalaryStandardInput GetRankSalaryStandardInput(Guid id)
        {
            RankSalaryStandardInput obj = (RankSalaryStandardInput)Session.DefaultSession.GetObjectByKey(typeof(RankSalaryStandardInput), id);
            return obj;
        }

        public static RankSalaryStandardInput GetRankSalaryStandardInput(string salaryPlan, string grade, string rank, int period, bool isVerify)
        {
            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                       new BinaryOperator("薪酬体系", salaryPlan, BinaryOperatorType.Equal),
                       new BinaryOperator("职等", grade, BinaryOperatorType.Equal),
                       new BinaryOperator("职级", rank, BinaryOperatorType.Equal),
                       new BinaryOperator("期号", period, BinaryOperatorType.Equal),
                       new BinaryOperator("是验证录入", isVerify, BinaryOperatorType.Equal));

            XPCollection objset = new XPCollection(typeof(RankSalaryStandardInput), criteria, new SortProperty("开始执行日期", SortingDirection.Ascending));

            if (objset.Count > 0)
            {
                return (RankSalaryStandardInput)objset[0];
            }
            else
                return null;
        }

        #endregion

        #region GetRankSalaryStandardInputs

        //获取XXX年X半年薪酬执行标准
        public static List<RankSalaryStandardInput> GetRankSalaryStandardInputs(string salaryPlan, string grade, int period, bool isVerify)
        {
            List<RankSalaryStandardInput> list = new List<RankSalaryStandardInput>();

            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                       new BinaryOperator("薪酬体系", salaryPlan, BinaryOperatorType.Equal),
                       new BinaryOperator("期号", period, BinaryOperatorType.Equal),
                       new BinaryOperator("是验证录入", isVerify, BinaryOperatorType.Equal));

            if (!string.IsNullOrEmpty(grade)) criteria.Operands.Add(new BinaryOperator("职等", grade, BinaryOperatorType.Equal));

            XPCollection objset = new XPCollection(typeof(RankSalaryStandardInput), criteria, new SortProperty("月薪", SortingDirection.Descending));

            foreach (RankSalaryStandardInput rss in objset)
            {
                list.Add(rss);                
            }
            return list;
        }
        #endregion
        
        #region GetPreviousPeriodStandards

        //获取上一期的标准
        public static List<RankSalaryStandard> GetPreviousPeriodStandards(string salaryPlan, string grade, int period)
        {
            return RankSalaryStandard.GetPreviousPeriodStandards(salaryPlan, grade, period);
        }
        #endregion

        #region GetFromCache

        public static RankSalaryStandardInput GetFromCache(string salaryPlan, string grade, string rank, int period, bool isVerify)
        {
            string key = salaryPlan + "$$" + grade + "$$" + rank + "$$" + period + "$$" + isVerify;
            return RANK_SALARY_STANDARD_INPUT_CACHE.Get(key, () => GetRankSalaryStandardInput(salaryPlan, grade, rank, period, isVerify), TimeSpan.FromHours(1));
        }
        #endregion

        #region GetEditingRows

        /// <summary>
        /// 获取正在录入的记录
        /// </summary>
        /// <param name="stepId"></param>
        /// <param name="isVerify"></param>
        /// <returns></returns>
        public static List<RankSalaryStandardInput> GetEditingRows(string salaryPlan, int period, bool isVerify)
        {
            List<RankSalaryStandardInput> rows = new List<RankSalaryStandardInput>();

            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                       new BinaryOperator("薪酬体系", salaryPlan, BinaryOperatorType.Equal),
                       new BinaryOperator("期号", period, BinaryOperatorType.Equal),
                       new BinaryOperator("是验证录入", isVerify, BinaryOperatorType.Equal));

            XPCollection objset = new XPCollection(MyHelper.XpoSession, typeof(RankSalaryStandardInput), criteria, new SortProperty("月薪", SortingDirection.Descending));

            foreach (RankSalaryStandardInput input in objset)
            {
                rows.Add(input);
            }
            return rows;
        }
        #endregion

        #region AddRankSalaryStandardInput

        public static RankSalaryStandardInput AddRankSalaryStandardInput(string salaryPlan, string grade, string rank, int period, int order, bool isVerify)
        {
            RankSalaryStandardInput item = GetRankSalaryStandardInput(salaryPlan, grade, rank, period, isVerify);
            if (item == null)
            {
                item = new RankSalaryStandardInput();
                item.标识 = Guid.NewGuid();
                item.薪酬体系 = salaryPlan;
                item.职等 = grade;
                item.职级 = rank;
                item.期号 = period;
                item.序号 = order;
                item.是验证录入 = isVerify;
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
            if (this.内容不同的字段.Count > 0) return;

            RankSalaryStandard m = RankSalaryStandard.GetRankSalaryStandard(this.薪酬体系, this.职等, this.职级, this.期号);
            if (m == null)
            {
                m = new RankSalaryStandard();
                m.标识 = Guid.NewGuid();
            }
            this.CopyWatchMember(m);
            m.Save();

            //更新生效标记
            if (!this.已生效)
            {
                this.生效时间 = DateTime.Now;
                this.Save();

                RankSalaryStandardInput opposite = 另一人录入的记录;
                opposite.生效时间 = DateTime.Now;
                opposite.Save();
            }
        }
        #endregion

        #region OnSaving

        protected override void OnSaving()
        {            
            if (string.IsNullOrEmpty(this.薪酬体系)) throw new Exception("薪酬体系不能为空");
            if (string.IsNullOrEmpty(this.职等)) throw new Exception("职等不能为空");
            if (string.IsNullOrEmpty(this.职级)) throw new Exception("职级不能为空");
            if (this.期号 == 0) throw new Exception("期号不能为空");

            RankSalaryStandardInput found = GetRankSalaryStandardInput(this.薪酬体系, this.职等, this.职级, this.期号, this.是验证录入);
            if (found != null && found.标识 != this.标识)
                throw new Exception("本期已存在同职级的标准，不能创建。");
            else
                base.OnSaving();

            contentDifferentFields = null;
            RANK_SALARY_STANDARD_INPUT_CACHE.Set(CacheKey, this, TimeSpan.FromHours(1));
        }
        #endregion

        #region OnDeleted
        
        protected override void OnDeleted()
        {
            base.OnDeleted();
            RANK_SALARY_STANDARD_INPUT_CACHE.Remove(CacheKey);            
        }
        #endregion

        #region OnSaved

        protected override void OnSaved()
        {
            //自动建立另一人的记录
            //AddRankSalaryStandardInput(this.薪酬体系, this.职等, this.职级, this.期号, this.序号, !this.是验证录入);
        }
        #endregion

        #region OnLoaded

        protected override void OnLoaded()
        {
            //缓存
            RANK_SALARY_STANDARD_INPUT_CACHE.Set(this.CacheKey, this, TimeSpan.FromHours(1));
            base.OnLoaded();
        }
        #endregion

        #region OnChanged

        protected override void OnChanged(string propertyName, object oldValue, object newValue)
        {
            //如果序号改变
            if (propertyName == "序号")
            {
                JobRank rank = this.JobRank;
                if (rank != null)
                {
                    rank.序号 = this.序号;
                    rank.Save();
                }
            }
        }

        #endregion

        #region GetModifiyFields

        public void GetModifiyFields()
        {
            if (contentDifferentFields == null)
            {
                contentDifferentFields = new List<ModifyField>();

                if (另一人录入的记录 != null)
                {
                    contentDifferentFields = MyHelper.GetModifyFields(this, 另一人录入的记录);
                }

            }                
        }
        #endregion

        #region 上期标准

        public RankSalaryStandard 上期标准
        {
            get
            {
                //获取上一期的期号
                int prevPeriod = RankSalaryStandard.GetPreviousPeriod(this.薪酬体系, this.期号);
                return RankSalaryStandard.GetFromCache(this.薪酬体系, this.职等, this.职级, prevPeriod);
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

        RankSalaryStandardInput anotherInput = null;
        [Browsable(false)]
        public RankSalaryStandardInput 另一人录入的记录
        {
            get
            {
                if (anotherInput == null)
                {
                    anotherInput = GetRankSalaryStandardInput(this.薪酬体系, this.职等, this.职级, this.期号, !this.是验证录入);
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

        #region JobGrade

        JobGrade grade = null;
        [NonPersistent]
        public JobGrade JobGrade
        {
            get
            {
                if (grade == null) grade = JobGrade.GetJobGrade(this.薪酬体系, this.职等);
                return grade;
            }
        }
        #endregion

        #region JobRank

        JobRank rank = null;
        [NonPersistent]
        public JobRank JobRank
        {
            get
            {
                if (rank == null && JobGrade != null) rank = JobRank.GetJobRank(JobGrade.标识, this.职级);
                return rank;
            }
        }
        #endregion

        #region CacheKey

        string CacheKey
        {
            get { return this.薪酬体系 + "$$" + this.职等 + "$$" + this.职级 + "$$" + this.期号 + "$$" + this.是验证录入; }
        }

        #endregion
    }
}
