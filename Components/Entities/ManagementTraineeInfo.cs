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
    public partial class ManagementTraineeInfo
    {
        static readonly ILog log = LogManager.GetLogger(typeof(ManagementTraineeInfo));
        public static ICache<string, ManagementTraineeInfo> MMANAGEMENTTRAINEEINFO_CACHE = MemoryCache<string, ManagementTraineeInfo>.Instance;

        #region GetManagementTraineeInfo

        public static ManagementTraineeInfo GetManagementTraineeInfo(Guid id)
        {
            ManagementTraineeInfo obj = (ManagementTraineeInfo)Session.DefaultSession.GetObjectByKey(typeof(ManagementTraineeInfo), id);
            return obj;
        }

        public static ManagementTraineeInfo GetManagementTraineeInfo(string empNo)
        {
            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                       new BinaryOperator("员工编号", empNo, BinaryOperatorType.Equal));

            XPCollection objset = new XPCollection(typeof(ManagementTraineeInfo), criteria, new SortProperty("更新时间", SortingDirection.Descending));

            if (objset.Count > 0)
            {
                return (ManagementTraineeInfo)objset[0];
            }
            else
                return null;
        }

        #endregion

        #region GetManagementTraineeInfoList
        
        public static List<ManagementTraineeInfo> GetManagementTraineeInfoList(string division, string grade)
        {
            List<ManagementTraineeInfo> list = new List<ManagementTraineeInfo>();

            GroupOperator criteria = new GroupOperator(GroupOperatorType.And);

            if (division != null) criteria.Operands.Add(new BinaryOperator("届别", division, BinaryOperatorType.Equal));
            if (grade != null) criteria.Operands.Add(new BinaryOperator("岗位级别", grade, BinaryOperatorType.Equal));
            if (division == null && grade == null) criteria = null;

             XPCollection objset = new XPCollection(typeof(ManagementTraineeInfo), criteria, new SortProperty("员工编号", SortingDirection.Ascending));

            foreach (ManagementTraineeInfo item in objset)
            {
                list.Add(item);
            }
            return list;
        }
        #endregion

        #region GetFromCache

        public static ManagementTraineeInfo GetFromCache(string emplid)
        {
            string key = emplid;
            return MMANAGEMENTTRAINEEINFO_CACHE.Get(key, () => GetManagementTraineeInfo(emplid), TimeSpan.FromHours(4));
        }
        #endregion

        #region OnSaving

        protected override void OnSaving()
        {
            if (string.IsNullOrEmpty(this.姓名)) throw new Exception("姓名不能为空");
            if (string.IsNullOrEmpty(this.员工编号)) throw new Exception("员工编号不能为空.");
            
            ManagementTraineeInfo found = GetManagementTraineeInfo(this.员工编号);
            if (found != null && found.标识 != this.标识)
                throw new Exception("已经存在该员工的管培生基本信息，不能重复创建");
            else
                base.OnSaving();

            MMANAGEMENTTRAINEEINFO_CACHE.Set(CacheKey, this, TimeSpan.FromHours(4));
        }
        #endregion

        #region OnDeleting

        protected override void OnDeleting()
        {
            base.OnDeleting();
            MMANAGEMENTTRAINEEINFO_CACHE.Remove(CacheKey);
        }
        #endregion

        #region OnLoaded

        protected override void OnLoaded()
        {
            //缓存
            MMANAGEMENTTRAINEEINFO_CACHE.Set(this.CacheKey, this, TimeSpan.FromHours(4));
            base.OnLoaded();
        }
        #endregion

        #region AddManagementTraineeInfo

        public static ManagementTraineeInfo AddManagementTraineeInfo(string empNo, string name)
        {
            ManagementTraineeInfo item = GetManagementTraineeInfo(empNo);
            if (item == null)
            {
                item = new ManagementTraineeInfo();

                item.标识 = Guid.NewGuid();
                item.员工编号 = empNo;
                item.姓名 = name;
                item.更新时间 = DateTime.Now;
                item.Save();
            }
            return item;
        }
        #endregion

        #region CheckSpecialtyValid

        public static bool CheckSpecialtyValid(int year, string grade, string xueli, string specialty)
        {
            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                       new BinaryOperator("届别", year, BinaryOperatorType.Equal),
                       new BinaryOperator("岗位级别", grade, BinaryOperatorType.Equal),
                       new BinaryOperator("学历", xueli, BinaryOperatorType.Equal),
                       new BinaryOperator("专业名称", specialty, BinaryOperatorType.Equal)
                       );

            XPCollection objset = new XPCollection(typeof(ManagementTraineeInfo), criteria, new SortProperty("更新时间", SortingDirection.Descending));
            return objset.Count > 0;
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

        #region 公司

        public string 公司
        {
            get { return 员工信息.公司名称; }
        }

        #endregion

        #region CacheKey

        string CacheKey
        {
            get { return this.员工编号; }
        }

        #endregion

        #region 今年评定结果

        ManagementTraineeAbility ability_this_year; //今年评定结果
        public ManagementTraineeAbility 今年评定结果
        {
            get
            {
                if(ability_this_year == null) ability_this_year = ManagementTraineeAbility.GetManagementTraineeAbility(this.员工编号, DateTime.Today.Year);
                return ability_this_year;
            }
        }
        #endregion

        #region 评定等级

        public string 评定等级
        {
            get
            {
                if (今年评定结果 == null)
                    return "";
                else
                    return 今年评定结果.能力级别;
            }
        }
        #endregion

        #region 当前年薪

        string current_year_salary = null; //当前年薪
        public string 当前年薪
        {
            get
            {
                if (current_year_salary == null)
                {
                    ManagementTraineePayStandard standard = ManagementTraineePayStandard.GetEffective(员工编号, DateTime.Today);
                    if (standard != null)
                        current_year_salary = standard.年薪.ToString("#0.#");
                    else
                        current_year_salary = "";
                }
                return current_year_salary;
            }
        }
        #endregion

        [NonPersistent]
        public int 序号 { get; set; }
    }
}
