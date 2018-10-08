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
    public partial class JobGrade
    {
        static readonly ILog log = LogManager.GetLogger(typeof(JobGrade));
        static ICache<Guid, List<JobRank>> RANK_CACHE = MemoryCache<Guid, List<JobRank>>.Instance;
        static ICache<Guid, JobGrade> GRADE_CACHE = MemoryCache<Guid, JobGrade>.Instance;
        
        internal static List<JobGrade> gradeList = null;
        
        #region 职等表

        public static List<JobGrade> 职等表
        {
            get
            {
                if (gradeList == null || gradeList.Count == 0) gradeList = GetAll();
                return gradeList;
            }
        }
        #endregion

        #region GetJobGrade

        public static JobGrade GetJobGrade(Guid id)
        {
            JobGrade obj = (JobGrade)Session.DefaultSession.GetObjectByKey(typeof(JobGrade), id);
            return obj;
        }

        public static JobGrade GetJobGrade(string salaryPlan, string gradename)
        {
            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                       new BinaryOperator("薪酬体系", salaryPlan, BinaryOperatorType.Equal),
                       new BinaryOperator("名称", gradename, BinaryOperatorType.Equal));

            XPCollection objset = new XPCollection(typeof(JobGrade), criteria, new SortProperty("职等数", SortingDirection.Ascending));

            if (objset.Count > 0)
            {
                return (JobGrade)objset[0];
            }
            else
                return null;
        }

        #endregion

        #region GetJobGrades

        //获取指定体系下所有职等
        public static List<JobGrade> GetJobGrades(string salary_plan)
        {
            List<JobGrade> list = new List<JobGrade>();

            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                new BinaryOperator("薪酬体系", salary_plan, BinaryOperatorType.Equal));

            XPCollection objset = new XPCollection(typeof(JobGrade), criteria, new SortProperty("职等数", SortingDirection.Ascending), new SortProperty("序号", SortingDirection.Ascending));

            foreach (JobGrade grade in objset)
            {
                list.Add(grade);
            }
            return list;
        }
        #endregion

        #region GetFromCache

        public static JobGrade GetFromCache(Guid gradeId)
        {
            return GRADE_CACHE.Get(gradeId, () => GetJobGrade(gradeId), TimeSpan.FromHours(4));
        }
        #endregion

        #region AddJobGrade

        public static JobGrade AddJobGrade(string salary_plan, string name, int order)
        {
            JobGrade item = GetJobGrade(salary_plan, name);
            if (item == null)
            {
                item = new JobGrade();

                item.标识 = Guid.NewGuid();
                item.薪酬体系 = salary_plan;
                item.名称 = name;
                item.序号 = order;

                item.Save();
            }
            return item;
        }
        #endregion

        #region GetAll

        //获取所有职等
        public static List<JobGrade> GetAll()
        {
            List<JobGrade> list = new List<JobGrade>();
            XPCollection objset = new XPCollection(typeof(JobGrade), null, new SortProperty("薪酬体系", SortingDirection.Ascending), new SortProperty("职等数", SortingDirection.Ascending));
            
            foreach (JobGrade group in objset)
            {
                list.Add(group);
            }
            return list;
        }
        #endregion

        #region OnSaving

        protected override void OnSaving()
        {
            if (string.IsNullOrEmpty(this.名称)) throw new Exception("职级名称不能为空。");
            
            JobGrade found = GetJobGrade(this.薪酬体系, this.名称);
            if (found != null && found.标识 != this.标识) throw new Exception("同一薪酬体系内，职等名称不能重复。");

            base.OnSaving();

            GRADE_CACHE.Set(this.标识, this, TimeSpan.FromHours(4));
        }
        #endregion

        #region OnDeleting

        protected override void OnDeleting()
        {
            base.OnDeleting();
            GRADE_CACHE.Remove(this.标识);
        }
        #endregion

        #region OnLoaded

        protected override void OnLoaded()
        {
            //缓存
            GRADE_CACHE.Set(this.标识, this, TimeSpan.FromHours(4));
            base.OnLoaded();
        }
        #endregion

        #region ClearRanks
        
        //清除职级
        void ClearRanks()
        {
            string sql = "DELETE FROM 职级 WHERE 职等标识 = '" + this.标识 + "'";
            using (SqlConnection connection = new SqlConnection(MyHelper.GetConnectionString()))
            {
                YiKang.Data.SqlHelper.ExecuteNonQuery(connection, System.Data.CommandType.Text, sql);
            }
        }
        #endregion

        #region AppendRank

        public List<JobRank> AppendRanks(string names)
        {
            List<JobRank> list = new List<JobRank>();
            string[] rank_arr = names.Split(new char[] { ' ', ',', '　', '\t', '，' });
            int order = 职级表.Count + 1;
            for (int i = 0; i < rank_arr.Length; i++)
            {
                string name = rank_arr[i].Trim();
                if (name == "") continue;

                JobRank rank = JobRank.AddJobRank(this.标识, name, order);
                list.Add(rank);
                order++;
            }
            //删除缓存
            RANK_CACHE.Remove(this.标识);
            return list;
        }
        #endregion

        #region CreateRanks

        public List<JobRank> CreateRanks(string ranks)
        {
            ClearRanks();

            List<JobRank> rankList = new List<JobRank>();
            string[] rank_arr = ranks.Split(new char[] { ' ', ',','　','\t', '，'});
            int x = 1;
            for (int i = 0; i < rank_arr.Length; i++)
            {
                string name = rank_arr[i].Trim();
                if (name == "") continue;

                JobRank rank = new JobRank();
                rank.职等标识 = this.标识;
                rank.名称 = name;
                rank.序号 = x;
                rank.创建人 = AccessController.CurrentUser.姓名;
                rank.创建时间 = DateTime.Now;
                rank.Save();
                
                rankList.Add(rank);

                x++;                
            }
            RANK_CACHE.Remove(this.标识);
            return rankList;

        }
        #endregion

        #region 职级表

        public List<JobRank> 职级表
        {
            get
            {
                List<JobRank> rankList = RANK_CACHE.Get(this.标识, () => JobRank.GetJobRanks(this.标识), TimeSpan.FromHours(4));
                return rankList;
            }
        }

        #endregion
    }
}
