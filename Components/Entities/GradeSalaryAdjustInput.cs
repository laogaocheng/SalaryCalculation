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
using System.Reflection;

namespace Hwagain.SalaryCalculation.Components
{
    public partial class GradeSalaryAdjustInput
    {
        static readonly ILog log = LogManager.GetLogger(typeof(GradeSalaryAdjustInput));
        public static ICache<string, GradeSalaryAdjustInput> GRADE_SALARY_ADJUST_INPUT_CACHE = MemoryCache<string, GradeSalaryAdjustInput>.Instance;

        public GradeSalaryAdjustInput(string rankNames)
        {
            AutoSaveOnEndEdit = false;
            is_separator = true;
            string[] names = rankNames.Split(new char[] { ':' });
            for (int i = 0; i < names.Length; i++)
            {
                //赋值
                string propertyName = "B" + (i + 1).ToString();
                PropertyInfo property = this.GetType().GetProperty(propertyName);
                if (property != null) property.SetValue(this, names[i], null);
            }
        }

        #region GetGradeSalaryAdjustInput

        public static GradeSalaryAdjustInput GetGradeSalaryAdjustInput(Guid id)
        {
            GradeSalaryAdjustInput obj = (GradeSalaryAdjustInput)Session.DefaultSession.GetObjectByKey(typeof(GradeSalaryAdjustInput), id);
            return obj;
        }

        public static GradeSalaryAdjustInput GetGradeSalaryAdjustInput(string salaryPlan, string grade, int period, bool isVerify)
        {
            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                       new BinaryOperator("薪酬体系", salaryPlan, BinaryOperatorType.Equal),
                       new BinaryOperator("职等", grade, BinaryOperatorType.Equal),
                       new BinaryOperator("期号", period, BinaryOperatorType.Equal),
                       new BinaryOperator("是验证录入", isVerify, BinaryOperatorType.Equal));

            XPCollection objset = new XPCollection(typeof(GradeSalaryAdjustInput), criteria, new SortProperty("期号", SortingDirection.Ascending));

            if (objset.Count > 0)
            {
                return (GradeSalaryAdjustInput)objset[0];
            }
            else
                return null;
        }

        #endregion

        #region GetGradeSalaryAdjustInputs

        public static List<GradeSalaryAdjustInput> GetGradeSalaryAdjustInputs(string salaryPlan, int period, bool isVerify)
        {
            List<GradeSalaryAdjustInput> list = new List<GradeSalaryAdjustInput>();

            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                       new BinaryOperator("薪酬体系", salaryPlan, BinaryOperatorType.Equal),
                       new BinaryOperator("期号", period, BinaryOperatorType.Equal),
                       new BinaryOperator("是验证录入", isVerify, BinaryOperatorType.Equal));

            XPCollection objset = new XPCollection(typeof(GradeSalaryAdjustInput), criteria, new SortProperty("序号", SortingDirection.Ascending));

            foreach (GradeSalaryAdjustInput grade in objset)
            {
                list.Add(grade);                
            }
            return list;
        }
        #endregion

        #region GetFromCache

        public static GradeSalaryAdjustInput GetFromCache(string salaryPlan, string grade, int period, bool isVerify)
        {
            string key = salaryPlan + "$$" + grade + "$$" + period + "$$" + isVerify;
            return GRADE_SALARY_ADJUST_INPUT_CACHE.Get(key, () => GetGradeSalaryAdjustInput(salaryPlan, grade, period, isVerify), TimeSpan.FromHours(1));
        }
        #endregion

        #region GetEditingRows

        /// <summary>
        /// 获取正在录入的记录
        /// </summary>
        /// <param name="stepId"></param>
        /// <param name="isVerify"></param>
        /// <returns></returns>
        public static List<GradeSalaryAdjustInput> GetEditingRows(string salaryPlan, int period, bool isVerify)
        {
            List<GradeSalaryAdjustInput> rows = new List<GradeSalaryAdjustInput>();

            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                       new BinaryOperator("薪酬体系", salaryPlan, BinaryOperatorType.Equal),
                       new BinaryOperator("期号", period, BinaryOperatorType.Equal),
                       new BinaryOperator("是验证录入", isVerify, BinaryOperatorType.Equal));

            XPCollection objset = new XPCollection(MyHelper.XpoSession, typeof(GradeSalaryAdjustInput), criteria, new SortProperty("序号", SortingDirection.Ascending));

            foreach (GradeSalaryAdjustInput input in objset)
            {
                rows.Add(input);
            }
            return rows;
        }
        #endregion

        #region AddGradeSalaryAdjustInput

        public static GradeSalaryAdjustInput AddGradeSalaryAdjustInput(GradeSalaryAdjust prev_gsa, int period, bool isVerify)
        {
            GradeSalaryAdjustInput item = GetGradeSalaryAdjustInput(prev_gsa.薪酬体系, prev_gsa.职等, period, isVerify);
            if (item == null)
            {                
                item = new GradeSalaryAdjustInput();
                item.标识 = Guid.NewGuid();
                item.薪酬体系 = prev_gsa.薪酬体系;
                item.职等 = prev_gsa.职等;
                item.期号 = period;
                item.是验证录入 = isVerify;
                //复制上一期的数据
                item.职等数 = prev_gsa.职等数;
                item.对比的职等 = prev_gsa.对比的职等;
                item.序号 = prev_gsa.序号;
                item.级差 = prev_gsa.级差;
                item.半年调资额 = prev_gsa.半年调资额;
                item.每年调资额 = prev_gsa.每年调资额;
                item.Save();

                //自动创建职级工资记录
                List<RankSalaryStandardInput> rss_list = new List<RankSalaryStandardInput>();
                //获取上一期的职级工资列表
                List<RankSalaryStandard> prev_rss_lilst = RankSalaryStandard.GetRankSalaryStandards(prev_gsa.薪酬体系, prev_gsa.职等, prev_gsa.期号);
                foreach (RankSalaryStandard rss in prev_rss_lilst)
                {
                    //创建
                    RankSalaryStandardInput new_rss = RankSalaryStandardInput.AddRankSalaryStandardInput(rss.薪酬体系, rss.职等, rss.职级, period, rss.序号, isVerify);
                    //自动更新数据
                    new_rss.月薪 = rss.月薪 + item.半年调资额;
                    new_rss.录入人 = "系统";
                    new_rss.录入时间 = DateTime.Now;

                    new_rss.Save();

                    rss_list.Add(new_rss);
                }
                item.职级工资表 = rss_list;
            }
            return item;
        }
        #endregion

        #region UpdateToFormalTable
        //更新到正式表
        public void UpdateToFormalTable()
        {
            if (this.内容不同的字段.Count > 0) return;

            GradeSalaryAdjust m = GradeSalaryAdjust.GetGradeSalaryAdjust(this.薪酬体系, this.职等, this.期号, 0);
            if (m == null)
            {
                m = new GradeSalaryAdjust();
                m.标识 = Guid.NewGuid();
            }
            this.CopyWatchMember(m);
            m.Save();

            //更新生效标记
            if (!this.已生效)
            {
                this.生效时间 = DateTime.Now;
                this.Save();

                GradeSalaryAdjustInput opposite = 另一人录入的记录;
                opposite.生效时间 = DateTime.Now;
                opposite.Save();
            }
        }
        #endregion

        #region CreateGradeSalaryAdjustTable

        //新建职级工资调整表
        public static List<GradeSalaryAdjustInput> CreateGradeSalaryAdjustTable(string salary_plan, int period, bool isVerify)
        {
            List<GradeSalaryAdjustInput> list = new List<GradeSalaryAdjustInput>();

            int prev_period = RankSalaryStandard.GetPreviousPeriod(salary_plan, period);
            if (prev_period == -1) return null; //找不到上一期，无法生成新的记录   

            //获取上期的调整记录
            List<GradeSalaryAdjust> prev_list = GradeSalaryAdjust.GetGradeSalaryAdjusts(salary_plan, prev_period, 0);
            //逐个职等创建新记录
            foreach (GradeSalaryAdjust gsa in prev_list)
            {
                list.Add(AddGradeSalaryAdjustInput(gsa, period, isVerify));
            }

            return list;
        }
        #endregion

        #region Calculate

        //重新统计
        public void Calculate()
        {
            int differential = 0;
            int halfYearAdjust = 0; //半年调
            int yearAdjust = 0;
            double total = 0;
            int avg = 0;
            double yearAdjustRate = 0;
            int max = 0;
            int min = 0;

            List<RankSalaryStandardInput> rss_list = RankSalaryStandardInput.GetRankSalaryStandardInputs(this.薪酬体系, this.职等, this.期号, this.是验证录入);

            if (rss_list.Count > 0)
            {
                total = rss_list.Sum(a => a.月薪);
                avg = (int)(total / rss_list.Count);
                min = rss_list.Min(a => a.月薪);
                max = rss_list.Max(a => a.月薪);

                if (rss_list.Count >= 2)
                {
                    IRankSalary rss0 = rss_list[0];
                    IRankSalary rss1 = rss_list[1];
                    differential = rss0.月薪 - rss1.月薪;
                }
            }

            #region 计算年调率

            if (this.上期调整 != null)
            {
                int avg_previous = previous_gsh.平均工资;
                if (avg_previous > 0)
                {
                    halfYearAdjust = avg - previous_gsh.平均工资;
                    yearAdjust = halfYearAdjust * 2;                
                    yearAdjustRate = (double)yearAdjust / avg_previous;                    
                }
            }

            #endregion

            this.级差 = differential;
            this.半年调资额 = halfYearAdjust;
            this.每年调资额 = yearAdjust;
            this.年调率 = yearAdjustRate;
            this.平均工资 = avg;
            this.最低工资 = min;
            this.最高工资 = max;            

            #region 计算职等差

            //获取对比的职等
            GradeSalaryAdjustInput contrast = GradeSalaryAdjustInput.GetGradeSalaryAdjustInput(this.薪酬体系, this.对比的职等, this.期号, this.是验证录入);
            if (contrast != null)
            {
                this.职等差 = contrast.最低工资 - this.最高工资;
            }

            #endregion

            this.Save();
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

        #region DeleteGradeSalaryAdjustInput

        public static void DeleteGradeSalaryAdjustInput(string salaryPlan, string grade, int period, int type)
        {
            string sql = "DELETE FROM 职级工资调整 WHERE 薪酬体系 = '" + salaryPlan + "' AND 职等 = '" + grade + "' AND 期号 = " + period + " AND 类型 = " + type + "";
            using (SqlConnection connection = new SqlConnection(MyHelper.GetConnectionString()))
            {
                YiKang.Data.SqlHelper.ExecuteNonQuery(connection, System.Data.CommandType.Text, sql);
            }
        }
        #endregion

        #region OnSaving

        protected override void OnSaving()
        {
            if (is_separator)
            {
                throw new Exception("分隔行不能保存");
            }

            GradeSalaryAdjustInput found = GetGradeSalaryAdjustInput(this.薪酬体系, this.职等, this.期号, this.是验证录入);
            if (found != null && found.标识 != this.标识)
                throw new Exception("本期已存在同职等的调整记录，不能重复创建。");
            else
                base.OnSaving();

            contentDifferentFields = null;
            GRADE_SALARY_ADJUST_INPUT_CACHE.Set(CacheKey, this, TimeSpan.FromHours(1));
        }
        #endregion

        #region OnSaved
        
        //创建另一人的记录
        protected override void OnSaved()
        {
            AddGradeSalaryAdjustInput(this.上期调整, this.期号, !this.是验证录入);            
            base.OnSaved();
        }

        #endregion

        #region OnDeleting

        protected override void OnDeleting()
        {
            GRADE_SALARY_ADJUST_INPUT_CACHE.Remove(CacheKey);      
            base.OnDeleting();
        }
        #endregion

        #region OnLoaded

        protected override void OnLoaded()
        {
            LoadMonthlySalary();
            base.OnLoaded();
        }

        #endregion

        #region LoadMonthlySalary

        private void LoadMonthlySalary()
        {
            if (职级工资表 != null)
            {
                //设置字段值
                foreach (RankSalaryStandardInput rss in 职级工资表)
                {
                    //赋值
                    string propertyName = "B" + rss.序号;
                    string monthlySalary = rss.月薪.ToString();
                    PropertyInfo property = this.GetType().GetProperty(propertyName);
                    if (property != null) property.SetValue(this, monthlySalary, null);
                }
            }
            //缓存
            GRADE_SALARY_ADJUST_INPUT_CACHE.Set(this.CacheKey, this, TimeSpan.FromHours(1));
        }
        #endregion

        #region OnChanged

        //当年调发生改变时
        protected override void OnChanged(string propertyName, object oldValue, object newValue)
        {
            if (propertyName == "半年调资额")
            {
                //重新设定各个职级的月薪
                foreach (RankSalaryStandardInput rss in this.职级工资表)
                {
                    rss.月薪 = rss.上期标准.月薪 + this.半年调资额;
                    rss.Save();
                }
                //重新加载月薪
                LoadMonthlySalary();
                this.Calculate();
            }
            base.OnChanged(propertyName, oldValue, newValue);
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

        #region SetRankNames

        void SetRankNames()
        {
            RankNames = "";
            foreach (RankSalaryStandardInput rank in 职级工资表)
            {
                if (RankNames != "") RankNames += ":";
                RankNames += rank.职级;
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

        GradeSalaryAdjustInput anotherInput = null;
        [Browsable(false)]
        public GradeSalaryAdjustInput 另一人录入的记录
        {
            get
            {
                if (anotherInput == null)
                {
                    anotherInput = GetGradeSalaryAdjustInput(this.薪酬体系, this.职等, this.期号, !this.是验证录入);
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

        #region 上期调整

        GradeSalaryAdjust previous_gsh = null;
        public GradeSalaryAdjust 上期调整
        {
            get
            {
                if (previous_gsh == null)
                {
                    int previous_period = RankSalaryStandard.GetPreviousPeriod(this.薪酬体系, this.期号);
                    previous_gsh = GradeSalaryAdjust.GetGradeSalaryAdjust(this.薪酬体系, this.职等, previous_period, 0);
                }
                return previous_gsh;
            }
        }

        #endregion

        #region 职级工资表

        List<RankSalaryStandardInput> rankSalaryStandardInputList = null;
        [NonPersistent]
        public List<RankSalaryStandardInput> 职级工资表
        {
            get
            {
                if (rankSalaryStandardInputList == null)
                {
                    rankSalaryStandardInputList = RankSalaryStandardInput.GetRankSalaryStandardInputs(this.薪酬体系, this.职等, this.期号, this.是验证录入);
                    SetRankNames();
                }
                return rankSalaryStandardInputList;
            }
            set
            {
                rankSalaryStandardInputList = value;
                SetRankNames();
            }
        }
        #endregion

        #region CacheKey

        string CacheKey
        {
            get { return this.薪酬体系 + "$$" + this.职等 + "$$" + this.期号 + "$$" + this.是验证录入; }
        }

        #endregion

        [NonPersistent]
        public double 增减率 
        {
            get
            {
                if (上期调整 != null && 上期调整.年调率 != 0)
                    return (年调率 - 上期调整.年调率) / 上期调整.年调率;
                return 0;
            }
        }
        [NonPersistent]
        public string RankNames { get; set; }
        [NonPersistent]
        public bool is_separator { get; set; }
        [NonPersistent]
        public string B1 { get; set; }
        [NonPersistent]
        public string B2 { get; set; }
        [NonPersistent]
        public string B3 { get; set; }
        [NonPersistent]
        public string B4 { get; set; }
        [NonPersistent]
        public string B5 { get; set; }
        [NonPersistent]
        public string B6 { get; set; }
        [NonPersistent]
        public string B7 { get; set; }
        [NonPersistent]
        public string B8 { get; set; }
        [NonPersistent]
        public string B9 { get; set; }
        [NonPersistent]
        public string B10 { get; set; }
        [NonPersistent]
        public string B11 { get; set; }
        [NonPersistent]
        public string B12 { get; set; }
        [NonPersistent]
        public string B13 { get; set; }
        [NonPersistent]
        public string B14 { get; set; }
        [NonPersistent]
        public string B15 { get; set; }
        [NonPersistent]
        public string B16 { get; set; }
        [NonPersistent]
        public string B17 { get; set; }
        [NonPersistent]
        public string B18 { get; set; }
        [NonPersistent]
        public string B19 { get; set; }
        [NonPersistent]
        public string B20 { get; set; }
    }
}
