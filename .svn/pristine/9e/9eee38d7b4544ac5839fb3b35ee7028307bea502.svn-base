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
    public partial class GradeSalaryAdjust
    {
        static readonly ILog log = LogManager.GetLogger(typeof(GradeSalaryAdjust));
        public static ICache<string, GradeSalaryAdjust> GRADE_SALARY_COUNTER_CACHE = MemoryCache<string, GradeSalaryAdjust>.Instance;

        #region GetGradeSalaryAdjust

        public static GradeSalaryAdjust GetGradeSalaryAdjust(Guid id)
        {
            GradeSalaryAdjust obj = (GradeSalaryAdjust)Session.DefaultSession.GetObjectByKey(typeof(GradeSalaryAdjust), id);
            return obj;
        }

        public static GradeSalaryAdjust GetGradeSalaryAdjust(string salaryPlan, string grade, int period, int type)
        {
            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                       new BinaryOperator("薪酬体系", salaryPlan, BinaryOperatorType.Equal),
                       new BinaryOperator("职等", grade, BinaryOperatorType.Equal),
                       new BinaryOperator("期号", period, BinaryOperatorType.Equal),
                       new BinaryOperator("类型", type, BinaryOperatorType.Equal));

            XPCollection objset = new XPCollection(typeof(GradeSalaryAdjust), criteria, new SortProperty("期号", SortingDirection.Ascending));

            if (objset.Count > 0)
            {
                return (GradeSalaryAdjust)objset[0];
            }
            else
                return null;
        }

        #endregion

        #region GetFromCache

        public static GradeSalaryAdjust GetFromCache(string salaryPlan, string grade, int period, int type)
        {
            string key = salaryPlan + "$$" + grade + "$$" + period + "$$" + type;
            return GRADE_SALARY_COUNTER_CACHE.Get(key, () => GetGradeSalaryAdjust(salaryPlan, grade, period, type), TimeSpan.FromHours(4));                
        }
        #endregion

        #region GetGradeSalaryAdjusts

        public static List<GradeSalaryAdjust> GetGradeSalaryAdjusts(string salaryPlan, int period, int type)
        {
            List<GradeSalaryAdjust> list = new List<GradeSalaryAdjust>();

            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                       new BinaryOperator("薪酬体系", salaryPlan, BinaryOperatorType.Equal),
                       new BinaryOperator("期号", period, BinaryOperatorType.Equal),
                       new BinaryOperator("类型", type, BinaryOperatorType.Equal));

            XPCollection objset = new XPCollection(typeof(GradeSalaryAdjust), criteria, new SortProperty("期号", SortingDirection.Ascending));

            foreach (GradeSalaryAdjust grade in objset)
            {
                list.Add(grade);                
            }
            return list;
        }
        #endregion

        #region GetGradeSalaryAdjusts
        //获取最近几年执行标准
        public static List<GradeSalaryAdjust> GetGradeSalaryAdjusts(string salaryPlan, string grade, int startYear)
        {
            int startPeriod = startYear * 10;
            List<GradeSalaryAdjust> list = new List<GradeSalaryAdjust>();

            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                       new BinaryOperator("薪酬体系", salaryPlan, BinaryOperatorType.Equal),
                       new BinaryOperator("职等", grade, BinaryOperatorType.Equal),
                       new BinaryOperator("期号", startPeriod, BinaryOperatorType.GreaterOrEqual),
                       new BinaryOperator("类型", 0, BinaryOperatorType.Equal));

            XPCollection objset = new XPCollection(typeof(GradeSalaryAdjust), criteria, new SortProperty("期号", SortingDirection.Descending));

            foreach (GradeSalaryAdjust item in objset)
            {
                list.Add(item);
            }
            return list;
        }
        #endregion

        #region AddGradeSalaryAdjust

        public static GradeSalaryAdjust AddGradeSalaryAdjust(string salaryPlan, string grade, int period, int type)
        {
            GradeSalaryAdjust item = GetGradeSalaryAdjust(salaryPlan, grade, period, type);
            if (item == null)
            {
                item = new GradeSalaryAdjust();
                item.标识 = Guid.NewGuid();
                item.薪酬体系 = salaryPlan;
                item.职等 = grade;
                item.期号 = period;
                item.类型 = type;

                JobGrade jobGrade = JobGrade.GetJobGrade(salaryPlan, grade);
                if (jobGrade != null)
                {
                    item.职等数 = jobGrade.职等数;
                    item.对比的职等 = jobGrade.对比的职等;
                    item.序号 = jobGrade.序号;
                }
                item.Save();
            }
            return item;
        }
        #endregion

        #region Calculate

        //重新统计
        public void Calculate()
        {
            int differential = 0;
            double total = 0;
            int avg = 0;
            double yearAdjustRate = 1;
            int max = 0;
            int min = 0;

            List<IRankSalary> rss_list = new List<IRankSalary>();

            if (类型 == 0)
            {
                foreach (IRankSalary irs in RankSalaryStandard.GetRankSalaryStandards(this.薪酬体系, this.职等, this.期号))
                    rss_list.Add(irs);
            }
            else
            {
                foreach (IRankSalary irs in RankSalaryStandardInput.GetRankSalaryStandardInputs(this.薪酬体系, this.职等, this.期号, this.类型 == 2))
                    rss_list.Add(irs);
            }

            rss_list = rss_list.FindAll(a => a.月薪 > 0).ToList(); //过滤掉没有设置月薪的记录

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

            this.每年调资额 = Convert.ToInt32(this.半年调资额 * 1.5);

            int previous_period = RankSalaryStandard.GetPreviousPeriod(this.薪酬体系, this.期号);
            GradeSalaryAdjust previous_gsh = GradeSalaryAdjust.GetGradeSalaryAdjust(this.薪酬体系, this.职等, previous_period, 0);
            //如果找到上期数据（通取正式数据）
            if (previous_gsh != null)
            {
                int avg_previous = previous_gsh.平均工资;
                if (avg_previous > 0)
                {
                    yearAdjustRate = (double)每年调资额 / avg_previous;
                }
            }
            else //首次标准
            {
                if (avg != 0) yearAdjustRate = (double)每年调资额 / avg;
            }

            #endregion

            this.级差 = differential;
            this.年调率 = yearAdjustRate;
            this.平均工资 = avg;
            this.最低工资 = min;
            this.最高工资 = max;            

            #region 计算职等差

            //获取对比的职等
            GradeSalaryAdjust contrast = GradeSalaryAdjust.GetFromCache(this.薪酬体系, this.对比的职等, this.期号, this.类型);
            if (contrast != null)
            {
                this.职等差 = contrast.最低工资 - this.最高工资;
            }

            #endregion

            this.Save();
        }
        #endregion

        #region DeleteGradeSalaryAdjust

        public static void DeleteGradeSalaryAdjust(string salaryPlan, string grade, int period, int type)
        {
            string sql = "DELETE FROM 职级工资调整 WHERE 薪酬体系 = '" + salaryPlan + "' AND 职等 = '" + grade + "' AND 期号 = " + period + " AND 类型 = " + type + "";
            using (SqlConnection connection = new SqlConnection(MyHelper.GetConnectionString()))
            {
                YiKang.Data.SqlHelper.ExecuteNonQuery(connection, System.Data.CommandType.Text, sql);
            }
        }
        #endregion

        #region UpdateToFormalRecord
        //更新正式调整记录
        public void UpdateToFormalRecord()
        {
            GradeSalaryAdjust gsa = GetGradeSalaryAdjust(this.薪酬体系, this.职等, this.期号, 0);
            if (gsa == null)
            {
                gsa = AddGradeSalaryAdjust(this.薪酬体系, this.职等, this.期号, 0);
            }
            this.CopyWatchMember(gsa);
            gsa.Save();
        }
        #endregion

        #region OnSaving

        protected override void OnSaving()
        {
            GradeSalaryAdjust found = GetGradeSalaryAdjust(this.薪酬体系, this.职等, this.期号, this.类型);
            if (found != null && found.标识 != this.标识)
                throw new Exception("本期已存在同职等的记录，不能创建。");
            else
                base.OnSaving();

            GRADE_SALARY_COUNTER_CACHE.Set(CacheKey, this, TimeSpan.FromHours(4));
        }
        #endregion

        #region OnDeleting

        protected override void OnDeleting()
        {
            base.OnDeleting();
            GRADE_SALARY_COUNTER_CACHE.Remove(CacheKey);
        }
        #endregion

        #region OnLoaded

        protected override void OnLoaded()
        {
            //缓存
            GRADE_SALARY_COUNTER_CACHE.Set(this.CacheKey, this, TimeSpan.FromHours(4));
            base.OnLoaded();
        }
        #endregion

        #region CacheKey

        string CacheKey
        {
            get { return this.薪酬体系 + "$$" + this.职等 + "$$" + this.期号 + "$$" + this.类型; }
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
    }
}
