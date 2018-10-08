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
    public partial class RankSalaryStandard : IRankSalary
    {
        static readonly ILog log = LogManager.GetLogger(typeof(RankSalaryStandard));
        public static ICache<string, RankSalaryStandard> RANK_SALARY_STANDARD_CACHE = MemoryCache<string, RankSalaryStandard>.Instance;

        #region GetRankSalaryStandard

        public static RankSalaryStandard GetRankSalaryStandard(Guid id)
        {
            RankSalaryStandard obj = (RankSalaryStandard)Session.DefaultSession.GetObjectByKey(typeof(RankSalaryStandard), id);
            return obj;
        }

        public static RankSalaryStandard GetRankSalaryStandard(string salaryPlan, string grade, string rank, int period)
        {
            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                       new BinaryOperator("薪酬体系", salaryPlan, BinaryOperatorType.Equal),
                       new BinaryOperator("职等", grade, BinaryOperatorType.Equal),
                       new BinaryOperator("职级", rank, BinaryOperatorType.Equal),
                       new BinaryOperator("期号", period, BinaryOperatorType.Equal));

            XPCollection objset = new XPCollection(typeof(RankSalaryStandard), criteria, new SortProperty("开始执行日期", SortingDirection.Ascending));

            if (objset.Count > 0)
            {
                return (RankSalaryStandard)objset[0];
            }
            else
                return null;
        }

        #endregion

        #region GetFromCache

        public static RankSalaryStandard GetFromCache(string salaryPlan, string grade, string rank, int period)
        {
            string key = salaryPlan + "$$" + grade + "$$" + rank + "$$" + period;
            return RANK_SALARY_STANDARD_CACHE.Get(key, () => GetRankSalaryStandard(salaryPlan, grade, rank, period), TimeSpan.FromHours(1));                
        }
        #endregion

        #region GetEffectRankSalaryStandard

        //获取执行的标准
        public static RankSalaryStandard GetEffectRankSalaryStandard(string salaryPlan, string grade, string rank, DateTime date)
        {
            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                       new BinaryOperator("薪酬体系", salaryPlan, BinaryOperatorType.Equal),
                       new BinaryOperator("职等", grade, BinaryOperatorType.Equal),
                       new BinaryOperator("职级", rank, BinaryOperatorType.Equal),
                       new BinaryOperator("开始执行日期", date.Date.AddDays(1), BinaryOperatorType.Less));

            XPCollection objset = new XPCollection(typeof(RankSalaryStandard), criteria, new SortProperty("开始执行日期", SortingDirection.Descending));

            if (objset.Count > 0)
            {
                return (RankSalaryStandard)objset[0];
            }
            else
                return null;
        }
        #endregion

        #region GetRankSalaryStandards

        //获取XXX年X半年薪酬执行标准
        public static List<RankSalaryStandard> GetRankSalaryStandards(string salaryPlan, string grade, int period)
        {
            List<RankSalaryStandard> list = new List<RankSalaryStandard>();

            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                       new BinaryOperator("薪酬体系", salaryPlan, BinaryOperatorType.Equal),
                       new BinaryOperator("期号", period, BinaryOperatorType.Equal));

            if (!string.IsNullOrEmpty(grade)) criteria.Operands.Add(new BinaryOperator("职等", grade, BinaryOperatorType.Equal));

            XPCollection objset = new XPCollection(typeof(RankSalaryStandard), criteria, new SortProperty("职等", SortingDirection.Ascending), new SortProperty("序号", SortingDirection.Ascending));

            foreach (RankSalaryStandard rss in objset)
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
            //获取上一期的期号
            int prevPeriod = GetPreviousPeriod(salaryPlan, period);
            return GetRankSalaryStandards(salaryPlan, grade, prevPeriod);
        }
        #endregion

        #region GetPreviousPeriod

        public static int GetPreviousPeriod(string salary_plan, int period)
        {
            string sql = "SELECT DISTINCT TOP (1) 期号 FROM  职级工资标准 WHERE (薪酬体系 = '" + salary_plan + "' AND 期号 < " + period + ") ORDER BY 期号 DESC";
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

        #region GetNextPeriod
        //获取下一期的期号
        public static int GetNextPeriod(string salary_plan, int period)
        {
            string sql = "SELECT DISTINCT TOP (1) 期号 FROM  职级工资标准 WHERE (薪酬体系 = '" + salary_plan + "' AND 期号 > " + period + ") ORDER BY 期号";
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

        #region AddRankSalaryStandard

        public static RankSalaryStandard AddRankSalaryStandard(string salaryPlan, string grade, string rank, int period)
        {
            RankSalaryStandard item = GetRankSalaryStandard(salaryPlan, grade, rank, period);
            if (item == null)
            {
                item = new RankSalaryStandard();
                item.标识 = Guid.NewGuid();
                item.薪酬体系 = salaryPlan;
                item.职等 = grade;
                item.职级 = rank;
                item.期号 = period;

                item.Save();
            }
            return item;
        }
        #endregion

        #region GetGrades

        //获取职等列表
        public static  List<string> GetGrades(List<RankSalaryStandard> rssList)
        {
            List<string> gradeList = new List<string>();

            var grades = from p in rssList
                        group p by p.职等 into g
                        select g;

            foreach (var grade in grades)
            {
                string name = grade.Key;
                gradeList.Add(name);
            }
            return gradeList;
        }
        #endregion

        #region OnSaving

        protected override void OnSaving()
        {
            RankSalaryStandard found = GetRankSalaryStandard(this.薪酬体系, this.职等, this.职级, this.期号);
            if (found != null && found.标识 != this.标识)
                throw new Exception("本期已存在同职级的标准，不能创建。");
            else
                base.OnSaving();

            RANK_SALARY_STANDARD_CACHE.Set(CacheKey, this, TimeSpan.FromHours(1));
        }
        #endregion

        #region OnDeleting

        protected override void OnDeleting()
        {
            base.OnDeleting();
            RANK_SALARY_STANDARD_CACHE.Remove(CacheKey);
        }
        #endregion

        #region OnLoaded

        protected override void OnLoaded()
        {
            AutoSaveOnEndEdit = false; //关闭自动保存的开关
            //缓存
            RANK_SALARY_STANDARD_CACHE.Set(this.CacheKey, this, TimeSpan.FromHours(1));
            base.OnLoaded();
        }
        #endregion

        #region 上期标准

        public RankSalaryStandard 上期标准
        {
            get
            {
                //获取上一期的期号
                int prevPeriod = GetPreviousPeriod(this.薪酬体系, this.期号);
                return GetFromCache(this.薪酬体系, this.职等, this.职级, prevPeriod);
            }
        }
        #endregion

        #region CacheKey

        string CacheKey
        {
            get { return this.薪酬体系 + "$$" + this.职等 + "$$" + this.职级 + "$$" + this.期号; }
        }

        #endregion
    }

    public interface IRankSalary
    {
        string 薪酬体系 { get; set; }
        string 职等 { get; set; }
        string 职级 { get; set; }
        int 期号 { get; set; }
        DateTime 开始执行日期 { get; set; }
        int 月薪 { get; set; }
    }
}
