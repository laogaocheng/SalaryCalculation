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
    public partial class ManagementTraineePayStandard
    {
        static readonly ILog log = LogManager.GetLogger(typeof(ManagementTraineePayStandard));
        public static ICache<string, ManagementTraineePayStandard> MANAGEMENT_TRAINEE_PAY_STANDARD_CACHE = MemoryCache<string, ManagementTraineePayStandard>.Instance;

        #region GetManagementTraineePayStandard

        public static ManagementTraineePayStandard GetManagementTraineePayStandard(Guid id)
        {
            ManagementTraineePayStandard obj = (ManagementTraineePayStandard)Session.DefaultSession.GetObjectByKey(typeof(ManagementTraineePayStandard), id);
            return obj;
        }

        public static ManagementTraineePayStandard GetManagementTraineePayStandard(string emplid, int time)
        {
            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                       new BinaryOperator("员工编号", emplid, BinaryOperatorType.Equal),
                       new BinaryOperator("提资序数", time, BinaryOperatorType.Equal));

            XPCollection objset = new XPCollection(typeof(ManagementTraineePayStandard), criteria, new SortProperty("创建时间", SortingDirection.Ascending));

            if (objset.Count > 0)
            {
                return (ManagementTraineePayStandard)objset[0];
            }
            else
                return null;
        }
        public static ManagementTraineePayStandard GetManagementTraineePayStandard(string emplid, int year, int quarter)
        {
            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                       new BinaryOperator("员工编号", emplid, BinaryOperatorType.Equal),
                       new BinaryOperator("年份", year, BinaryOperatorType.Equal),
                       new BinaryOperator("季度", quarter, BinaryOperatorType.Equal));

            XPCollection objset = new XPCollection(typeof(ManagementTraineePayStandard), criteria, new SortProperty("开始执行时间", SortingDirection.Ascending));

            if (objset.Count > 0)
            {
                return (ManagementTraineePayStandard)objset[0];
            }
            else
                return null;
        }

        #endregion

        #region GetFromCache

        public static ManagementTraineePayStandard GetFromCache(string emplid, int time)
        {
            string key = emplid + "$$" + time;
            return MANAGEMENT_TRAINEE_PAY_STANDARD_CACHE.Get(key, () => GetManagementTraineePayStandard(emplid, time), TimeSpan.FromHours(1));
        }
        #endregion

        #region GetManagementTraineePayStandards

        //获取指定员工所有的提资记录
        public static List<ManagementTraineePayStandard> GetManagementTraineePayStandards(string emplid)
        {
            List<ManagementTraineePayStandard> list = new List<ManagementTraineePayStandard>();

            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                       new BinaryOperator("员工编号", emplid, BinaryOperatorType.Equal));
            
            XPCollection objset = new XPCollection(typeof(ManagementTraineePayStandard), criteria, new SortProperty("开始执行时间", SortingDirection.Ascending));

            foreach (ManagementTraineePayStandard ps in objset)
            {
                list.Add(ps);
            }
            return list;
        }

        #endregion

        #region AddManagementTraineePayStandard

        public static ManagementTraineePayStandard AddManagementTraineePayStandard(string emplid, string name, int year, int quarter, int time)
        {
            ManagementTraineePayStandard item = GetManagementTraineePayStandard(emplid, year, quarter);
            if (item == null)
            {
                item = new ManagementTraineePayStandard();
                item.标识 = Guid.NewGuid();
                item.员工编号 = emplid;
                item.姓名 = name;
                item.年份 = year;
                item.季度 = quarter;
                item.提资序数 = time;
                item.创建人 = AccessController.CurrentUser.姓名;
                item.创建时间 = DateTime.Now;
                item.Save();
            }
            return item;
        }
        #endregion

        #region GetLatestRise

        //获取指定日期前的最后一次提资记录（增幅大于0的）
        public static ManagementTraineePayStandard GetLatestRise(string emplid, DateTime date)
        {
            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                       new BinaryOperator("员工编号", emplid, BinaryOperatorType.Equal),
                       new BinaryOperator("开始执行时间", date, BinaryOperatorType.Less),
                       new BinaryOperator("增幅", 0, BinaryOperatorType.Greater));

            XPCollection objset = new XPCollection(typeof(ManagementTraineePayStandard), criteria, new SortProperty("开始执行时间", SortingDirection.Descending));

            if (objset.Count > 0)
            {
                return (ManagementTraineePayStandard)objset[0];
            }
            else
                return null;
        }

        #endregion

        #region GetLatestBeforeOneday

        //获取指定日期前的最后一次提资记录
        public static ManagementTraineePayStandard GetLatestBeforeOneday(string emplid, DateTime date)
        {
            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                       new BinaryOperator("员工编号", emplid, BinaryOperatorType.Equal),
                       new BinaryOperator("开始执行时间", date, BinaryOperatorType.Less));

            XPCollection objset = new XPCollection(typeof(ManagementTraineePayStandard), criteria, new SortProperty("开始执行时间", SortingDirection.Descending));

            if (objset.Count > 0)
            {
                return (ManagementTraineePayStandard)objset[0];
            }
            else
                return null;
        }

        #endregion

        //计算季度差
        int GetQuarterInterval(ManagementTraineePayStandard item)
        {
            int x = this.年份 - item.年份;
            int y = this.季度 - item.季度;
            return x * 4 + y;
        }

        #region CreatePayStandards

        public static List<ManagementTraineePayStandard> CreatePayStandards(string emplid, int year)
        {
            EmployeeInfo employee = EmployeeInfo.GetFromCache(emplid);
            if (employee == null) return null;

            //获取管培生基本信息
            ManagementTraineeInfo traineeInfo = ManagementTraineeInfo.GetManagementTraineeInfo(emplid);
            if (traineeInfo == null) return null;

            DateTime start = new DateTime(year, 7, 1);
            ManagementTraineePayStandard first = CreateFirstStandard(emplid);
            //获取本年度评定前最后一次提资记录（增幅 > 0）
            ManagementTraineePayStandard latest = GetLatestRise(emplid, start);
            //如果没有找到提资记录，自动创建第一年的提资记录
            if (latest == null)
            {
                //第一年，已第一条记录为基准
                if (year == traineeInfo.入职时间.Year)
                {
                    latest = first;
                }
                else
                {
                    //创建入职当年的工资标准
                    CreatePayStandards(emplid, traineeInfo.入职时间.Year);
                    latest = GetLatestRise(emplid, start);
                }
            }
            if (latest == null) return null; //如果找不到上一期提资记录，没法继续创建提资记录

            //获取年度评定
            ManagementTraineeAbility ability = ManagementTraineeAbility.GetManagementTraineeAbility(emplid, year);
            string level = "A";
            string type = traineeInfo.岗位级别 == "一级" ? traineeInfo.岗位类型 : traineeInfo.专业属性;
            //每年评定后自动产生后面四个季度的提资记录
            List<ManagementTraineePayStandard> list = new List<ManagementTraineePayStandard>();
            for (int i = 0; i < 4; i++)
            {
                decimal rise_rate = 0;
                decimal year_salary = latest.年薪;
                int month_salary = latest.月薪;
                int time = -999; //如果次数是 -999 表示此季度不提资

                int quarter = (i + 2) % 4 + 1;
                int the_year = quarter <= 2 ? year + 1 : year;

                int m = the_year - first.年份;
                int n = quarter - first.季度;
                int q = m * 4 + n; //距离起薪季度数

                int x = the_year - latest.年份;
                int y = quarter - latest.季度;
                int quarterInterval = x * 4 + y; //距离最后一次提资季度数
                DateTime excuteStartTime = latest.开始执行时间.AddMonths(3 * quarterInterval);

                //获取提资序数
                //（第一年每半年固定提资）
                if (q <= 4)
                {
                    if (q == 2) //第一次提资
                    {
                        time = 1;
                    }
                    if (q == 4) //第二次提资
                    {
                        time = 2;
                    }
                }
                else
                {
                    if (ability == null) continue; //如果还没有评定

                    level = ability.能力级别;
                    //默认本次提资序数=上一次提资序数+1
                    switch (level)
                    {
                        case "A":
                            if (quarterInterval >= 2) time = latest.提资序数 + 1;
                            break;
                        case "B":
                            if (quarterInterval >= 3) time = latest.提资序数 + 1;
                            break;
                        case "C":
                            if (quarterInterval >= 4) time = latest.提资序数 + 1;
                            break;
                    }
                    //升阶（满足升阶条件，先升阶，每阶+100, 满阶是 10000）
                    double step = GetStep(traineeInfo.届别, traineeInfo.岗位级别, type, q);
                    if (step == 0) time = 10000;
                    //2018-9-21 进入二阶段以后，达到也要达到提资时间间隔才能提资
                    if (step >= 2 && time > 0 && time < 100) time = 100;
                }

                if (time == -999) continue;

                ManagementTraineePayRiseStandard standard = ManagementTraineePayRiseStandard.GetManagementTraineePayRiseStandard(traineeInfo.届别, traineeInfo.岗位级别, type, level, time);
                if (standard == null) continue; //找不到提资标准

                //获取增幅、年薪和月薪
                if (standard.提资方式 == (int)RiseType.金额)
                {
                    year_salary = standard.年薪;
                    rise_rate = 100 * ((decimal)(year_salary - latest.年薪) / (decimal)latest.年薪);
                    rise_rate = Math.Round(rise_rate, 1, MidpointRounding.AwayFromZero);
                }
                else
                {
                    rise_rate = standard.增幅;
                    year_salary = Math.Round(latest.年薪 * (100 + rise_rate) * (decimal)0.01, 1, MidpointRounding.AwayFromZero);
                }

                month_salary = Convert.ToInt32((year_salary * (decimal)10000.0) / (decimal)12.0);

                ManagementTraineePayStandard new_item = AddManagementTraineePayStandard(emplid, employee.姓名, the_year, quarter, time);
                if (new_item != null)
                {
                    new_item.季度 = quarter;
                    new_item.年份 = the_year;
                    new_item.增幅 = rise_rate;
                    new_item.年薪 = year_salary;
                    new_item.月薪 = month_salary;
                    new_item.开始执行时间 = excuteStartTime;
                    new_item.Save();

                    list.Add(new_item);
                    latest = new_item;

                }
                if (time == 10000) break; //已经满阶，退出
            }
            return list;
        }
        /// <summary>
        /// 获取现在处于那个阶段
        /// </summary>
        /// <param name="division">届别</param>
        /// <param name="grade">岗位级别</param>
        /// <param name="type">类别</param>
        /// <param name="quarter">季度（基于0），从开始到现在是第几个季度</param>
        /// <returns>返回阶段值，-1 满阶 1 一阶 2 二阶 -1 错误，小数点后面的步</returns>
        public static double GetStep(string division, string grade, string type, int quarter)
        {
            UpStepType usType = GetUpStepType(division, grade, type);
            switch (usType)
            {
                case UpStepType.五年两段三类:
                case UpStepType.五年两段四类:
                    if (quarter >= 4 * 4)       //第五年进入满阶
                        return ((double)quarter - 4 * 4) * 0.01;
                    else
                        return 1 + ((double)quarter) * 0.01;
                case UpStepType.五年三段四类:
                    if (quarter >= 4 * 4)       //第五年进入满阶
                        return ((double)quarter - 4 * 4) * 0.01;
                    else
                    {
                        if (quarter >= 3 * 4)   //第四年进入二阶
                            return 2 + ((double)quarter - 3 * 4) * 0.01;
                        else
                            return 1 + ((double)quarter) * 0.01;
                    }
                case UpStepType.七年两段五类:
                    if (quarter >= 6 * 4)       //第七年进入满阶
                        return ((double)quarter - 6 * 4) * 0.01;
                    else
                        return 1 + ((double)quarter) * 0.01;
                case UpStepType.七年三段五类:
                    if (quarter >= 6 * 4)       //第七年进入满阶
                        return ((double)quarter - 6 * 4) * 0.01;
                    else
                    {
                        if (quarter >= 4 * 4)   //第五年进入二阶
                            return 2 + ((double)quarter - 4 * 4) * 0.01;
                        else
                            return 1 + ((double)quarter) * 0.01;
                    }
            }
            return -1;
        }

        #endregion

        #region GetStepStartYear
        public static int GetStepStartYear(string division, string grade, string type, int step)
        {
            UpStepType usType = GetUpStepType(division, grade, type);
            return GetStepStartYear(usType, step);
        }
        /// <summary>
        /// 获取各阶开始于第几年
        /// </summary>
        /// <param name="usType">升阶类型</param>
        /// <param name="step">第几阶，-1 代表满阶</param>
        /// <returns>返回开始的年数，错误返回 -1 </returns>
        public static int GetStepStartYear(UpStepType usType, int step)
        {
            switch(usType)
            {
                case UpStepType.五年两段三类:
                case UpStepType.五年两段四类:
                    return step == -1 ? 5 : 1;
                case UpStepType.五年三段四类:
                    if (step == -1) return 5;
                    return step == 1 ? 1 : 4;
                case UpStepType.七年两段五类:
                    return step == -1 ? 7 : 1;
                case UpStepType.七年三段五类:
                    if (step == -1) return 7;
                    return step == 1 ? 1 : 5;
            }
            return -1;
        }

        #region GetUpStepType

        public static UpStepType GetUpStepType(string division, string grade, string type)
        {
            if (Convert.ToInt32(division) <= 2017)
            {
                if (grade == "一级")
                {
                    return UpStepType.五年三段四类;
                }
                if (grade == "二级")
                {
                    return UpStepType.五年两段四类;
                }
                if (grade == "三级")
                {
                    if (type == "营林本" || type == "营林硕")
                    {
                        return UpStepType.七年三段五类;
                    }
                    else
                    {
                        return UpStepType.七年两段五类;
                    }
                }
            }
            else
            {
                if (grade == "一级")
                {
                    return UpStepType.五年三段四类;
                }
                if (grade == "二级")
                {
                    return UpStepType.五年两段四类;
                }
                if (grade == "三级")
                {
                    return UpStepType.七年三段五类;
                }
            }
            return UpStepType.七年三段五类;
        }
        #endregion

        #region CreateFirstStandard

        public static ManagementTraineePayStandard CreateFirstStandard(string emplid)
        {
            EmployeeInfo employee = EmployeeInfo.GetFromCache(emplid);
            if (employee == null) return null;

            ManagementTraineePayStandard item = GetManagementTraineePayStandard(emplid, 0);
            if (item == null)
            {
                //获取管培生基本信息
                ManagementTraineeInfo traineeInfo = ManagementTraineeInfo.GetManagementTraineeInfo(emplid);
                if (traineeInfo != null)
                {
                    int year = Convert.ToInt32(traineeInfo.届别);
                    item = AddManagementTraineePayStandard(emplid, employee.姓名, year, 3, 0);

                    item.年份 = year;
                    item.季度 = 3;
                    item.增幅 = 0;
                    item.年薪 = traineeInfo.年薪;
                    item.月薪 = Convert.ToInt32((item.年薪 * (decimal)10000.0) / (decimal)12.0);
                    item.开始执行时间 = new DateTime(item.年份, 7, 1);

                    item.Save();
                }
            }
            return item;
        }
        #endregion

        #endregion

        #region OnSaving

        protected override void OnSaving()
        {
            ManagementTraineePayStandard found = GetManagementTraineePayStandard(this.员工编号, this.年份, this.季度);
            if (found != null && found.标识 != this.标识)
                throw new Exception("本期已存在该员工的第 " + 提资序数 + " 次的提资标准，不能重复创建。");
            else
                base.OnSaving();

            MANAGEMENT_TRAINEE_PAY_STANDARD_CACHE.Set(CacheKey, this, TimeSpan.FromHours(1));
        }
        #endregion

        #region OnDeleting

        protected override void OnDeleting()
        {
            base.OnDeleting();
            MANAGEMENT_TRAINEE_PAY_STANDARD_CACHE.Remove(CacheKey);
        }
        #endregion

        #region GetEffective

        public static ManagementTraineePayStandard GetEffective(string empNo, DateTime date)
        {
            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                       new BinaryOperator("员工编号", empNo, BinaryOperatorType.Equal),
                       new BinaryOperator("开始执行时间", date, BinaryOperatorType.LessOrEqual)
                       );

            XPCollection objset = new XPCollection(MyHelper.XpoSession, typeof(ManagementTraineePayStandard), criteria, new SortProperty("开始执行时间", SortingDirection.Descending));

            if (objset.Count > 0)
            {
                ManagementTraineePayStandard item = (ManagementTraineePayStandard)objset[0];
                return item;
            }
            else
                return null;
        }
        #endregion

        #region OnLoaded

        protected override void OnLoaded()
        {
            AutoSaveOnEndEdit = false; //关闭自动保存的开关
            //缓存
            MANAGEMENT_TRAINEE_PAY_STANDARD_CACHE.Set(this.CacheKey, this, TimeSpan.FromHours(1));
            base.OnLoaded();
        }
        #endregion

        #region 上期标准

        public ManagementTraineePayStandard 上期标准
        {
            get
            {
                return GetEffective(this.员工编号, this.开始执行时间.AddDays(-1));
            }
        }
        #endregion

        #region CacheKey

        string CacheKey
        {
            get { return this.员工编号 + "$$" + this.提资序数; }
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
