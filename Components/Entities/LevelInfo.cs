using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using DevExpress.Xpo.DB;
using log4net;
using System.Collections;

namespace Hwagain.SalaryCalculation.Components
{
    public partial class LevelInfo
    {
        static readonly ILog log = LogManager.GetLogger(typeof(LevelInfo));

        internal static List<LevelInfo> levelSet = null;
        public static List<string> 副总以上领导 = new List<string> { "董事长", "副董事长", "总裁", "副总裁", "总经理", "副总经理" };

        #region 职务等级表

        public static List<LevelInfo> 职务等级表
        {
            get
            {
                if (levelSet == null || levelSet.Count == 0) levelSet = GetAll();
                return levelSet;
            }
        }
        #endregion

        #region 副经理以下管理人员职等

        public static List<string> 副经理以下管理人员职等
        {
            get
            {
                LevelInfo fjlLevel = LevelInfo.GetLevelInfoByName("副经理级");
                List<LevelInfo> list = 职务等级表.FindAll(a => a.级别 >= fjlLevel.级别 && a.名称 != "岗位工级");
                List<JobGrade> grades = JobGrade.GetAll();
                List<string> l = new List<string>();
                foreach(LevelInfo li in list)
                {
                    string base_grade = li.名称.Replace("级", "");
                    foreach (JobGrade g in grades)
                    {
                        if (g.薪酬体系.StartsWith("HJ")) continue; //历史数据，已取消
                        if(g.名称.EndsWith(base_grade) && !l.Contains(g.名称))
                            l.Add(g.名称);
                    }
                }
                return l;
            }
        }
        #endregion

        #region GetLevelConfig
        /// <summary>
        /// 通过 Id 获取
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static LevelInfo GetLevelInfo(Guid id)
        {
            LevelInfo obj = (LevelInfo)Session.DefaultSession.GetObjectByKey(typeof(LevelInfo), id);
            return obj;
        }

        public static LevelInfo GetLevelInfo(string levelNumber)
        {
            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                       new BinaryOperator("编码", levelNumber, BinaryOperatorType.Equal));

            XPCollection objset = new XPCollection(typeof(LevelInfo), criteria, new SortProperty("级别", SortingDirection.Ascending));

            if (objset.Count > 0)
            {
                return (LevelInfo)objset[0];
            }
            else
                return null;
        }

        #endregion

        #region GetLevelInfoByName

        public static LevelInfo GetLevelInfoByName(string name)
        {
            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                       new BinaryOperator("名称", name, BinaryOperatorType.Equal));

            XPCollection objset = new XPCollection(typeof(LevelInfo), criteria, new SortProperty("级别", SortingDirection.Ascending));

            if (objset.Count > 0)
            {
                return (LevelInfo)objset[0];
            }
            else
                return null;
        }

        #endregion

        #region GetAll

        //获取所有职等
        public static List<LevelInfo> GetAll()
        {
            List<LevelInfo> list = new List<LevelInfo>();

            XPCollection objset = new XPCollection(typeof(LevelInfo), null, new SortProperty("级别", SortingDirection.Ascending));

            foreach (LevelInfo lc in objset)
            {
                list.Add(lc);
            }
            return list;
        }
        #endregion

        #region AddLevelInfo

        public static LevelInfo AddLevelInfo(string levelNumber, string levelName)
        {
            LevelInfo level = GetLevelInfo(levelNumber);
            if (level == null)
            {
                level = new LevelInfo();

                level.标识 = Guid.NewGuid();
                level.编码 = levelNumber;
                level.名称 = levelName;

                level.Save();
            }

            return level;
        }
        #endregion

        #region Reset

        public static void Reset()
        {
            List<LevelInfo> oldList = GetAll();
            List<LevelInfo> newList = new List<LevelInfo>(); //新增的
            foreach (DictionaryEntry entry in PsHelper.GetSupvLvls())
            {
                LevelInfo level = LevelInfo.AddLevelInfo((string)entry.Value, (string)entry.Key);
                newList.Add(level);
            }
            //清理被删除的级别
            foreach (LevelInfo lv in oldList)
            {
                LevelInfo find = newList.Find(a => a.编码 == lv.编码);
                if (find == null) lv.Delete();
            }
        }

        #endregion

        #region OnSaving

        protected override void OnSaving()
        {
            LevelInfo found = GetLevelInfo(this.编码);
            if (found != null && found.标识 != this.标识)
                throw new Exception("角色已具备这个职等信息，不能重复设置.");
            else
                base.OnSaving();
        }
        #endregion

        protected override void OnLoaded()
        {
            this.级别 = Convert.ToInt32(this.级别);
            base.OnLoaded();
        }

        #region 最高工资额

        public decimal 最高工资额
        {
            get
            {
                List<LevelInfo> list = 职等信息表.FindAll(a => a.级别 < this.级别);
                if (list.Count > 0)
                    return list.Min(a => a.最低工资额) - 1;
                else
                    return 99999999;
            }
        }
        #endregion

        #region 职等信息表

        static List<LevelInfo> liTable = null;
        public static List<LevelInfo> 职等信息表
        {
            get
            {
                if (liTable == null) liTable = GetAll();
                return liTable;
            }
        }
        #endregion
    }
}
