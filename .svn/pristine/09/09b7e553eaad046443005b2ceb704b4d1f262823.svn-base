using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using DevExpress.Xpo.DB;
using log4net;
using Hwagain.Components;

namespace Hwagain.SalaryCalculation.Components
{
    public partial class JobRank
    {
        static readonly ILog log = LogManager.GetLogger(typeof(JobRank));

        #region GetJobRank

        public static JobRank GetJobRank(Guid id)
        {
            JobRank obj = (JobRank)Session.DefaultSession.GetObjectByKey(typeof(JobRank), id);
            return obj;
        }

        public static JobRank GetJobRank(Guid gradeId, string name)
        {
            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                       new BinaryOperator("职等标识", gradeId, BinaryOperatorType.Equal),
                       new BinaryOperator("名称", name, BinaryOperatorType.Equal));

            XPCollection objset = new XPCollection(typeof(JobRank), criteria, new SortProperty("名称", SortingDirection.Ascending));

            if (objset.Count > 0)
            {
                return (JobRank)objset[0];
            }
            else
                return null;
        }

        #endregion

        #region GetJobRanks

        //获取指定职等下所有职级
        public static List<JobRank> GetJobRanks(Guid gradeId)
        {
            List<JobRank> list = new List<JobRank>();

            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                new BinaryOperator("职等标识", gradeId, BinaryOperatorType.Equal));

            XPCollection objset = new XPCollection(typeof(JobRank), criteria, new SortProperty("序号", SortingDirection.Ascending));

            foreach (JobRank grade in objset)
            {
                list.Add(grade);
            }
            return list;
        }
        #endregion

        #region AddJobRank

        public static JobRank AddJobRank(Guid gradeId, string name, int order)
        {
            JobRank item = GetJobRank(gradeId, name);
            if (item == null)
            {
                item = new JobRank();

                item.职等标识 = gradeId;
                item.名称 = name;
                item.序号 = order;
                item.创建人 = AccessController.CurrentUser.姓名;
                item.创建时间 = DateTime.Now;
                item.Save();
            }
            return item;
        }
        #endregion

        #region GetAll

        //获取所有职级
        public static List<JobRank> GetAll()
        {
            List<JobRank> list = new List<JobRank>();
            
            XPCollection objset = new XPCollection(typeof(JobRank), null, new SortProperty("职等标识", SortingDirection.Ascending), new SortProperty("序号", SortingDirection.Ascending));
            
            foreach (JobRank group in objset)
            {
                list.Add(group);
            }
            return list;
        }
        #endregion

        #region OnSaving

        protected override void OnSaving()
        {
            JobRank found = GetJobRank(this.职等标识, this.名称);
            if (found != null && found.标识 != this.标识)
                throw new Exception("同一职等下，名称不能重复。");
            else
                base.OnSaving();
        }
        #endregion

        #region 职等

        public JobGrade 职等
        {
            get { return JobGrade.GetFromCache(this.职等标识); }
        }

        #endregion
    }
}
