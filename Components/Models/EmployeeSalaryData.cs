using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using Hwagain.Components;

namespace Hwagain.SalaryCalculation.Components
{
    public class EmployeeSalaryData
    {
        EmployeeInfo employeeInfo = null;
        PrivateSalary privateSalary = null;
        SalaryResult publicSalary  = null;

        public int 序号 { get; set; }
        public int 公司序号 { get; set; }
        public decimal 职级工资 { get; set; }
        public decimal 津贴补助 { get; set; }
        public decimal 满勤奖金额 { get; set; }
        public decimal 年休假工资 { get; set; }
        public decimal 上表工资标准 { get; set; }
        public decimal 总工资 { get; set; }
        public string 公司编码 { get; set; }
        public string 部门编码 { get; set; }
        public string 职务等级 { get; set; }
        public string 工资职级 { get; set; }
        public string 职务 { get; set; }
        public string 职级 { get; set; }
        public decimal 职等 { get; set; } 
        public decimal 工龄 { get; set; }
        public string 华劲工龄 { get; set; }
        public string 任职时间 { get; set; }
        public string 职级名称 { get; set; }
        public string 薪等名称 { get; set; }
        public string 薪级名称 { get; set; }
        public int 薪等 { get; set; }
        public int 薪级 { get; set; }
        public bool 是主管 { get; set; }
        public bool 是管培生 { get; set; }
        public string 职等名称 { get; set; }
        public string 月薪类型 { get; set; }
        public string 期间 { get; set; }

        public decimal 职务工资 { get; set; }
        public string 执行职级 { get; set; }

        public int 年龄 { get; set; }
        public string 学历 { get; set; }
        public string 籍贯 { get; set; }
        public string 岗位级别 { get; set; }
        public string 工资职等 { get; set; }
        public List<PrivateSalary> 工资调整记录 { get; set; }

        public static ICache<string, PrivateSalary> PrivateSalaryCache = MemoryCache<string, PrivateSalary>.Instance;
        public static ICache<string, SalaryResult> SalaryResultCache = MemoryCache<string, SalaryResult>.Instance;
        public static ICache<string, string> LvDescrCache = MemoryCache<string, string>.Instance;
        public static ICache<string, LevelInfo> LevelInfoCache = MemoryCache<string, LevelInfo>.Instance;

        public EmployeeSalaryData(PrivateSalary salary)
        {
            InitData(salary);
        }

        private void InitData(PrivateSalary salary)
        {
            this.employeeInfo = salary.员工信息;
            this.privateSalary = salary;
            this.publicSalary = salary.基础工资表;

            期间 = salary.年度 + "年" + salary.月份 + "月";
            公司序号 = employeeInfo.公司序号;
            职务 = employeeInfo.职务名称;
            职级名称 = LvDescrCache.Get(employeeInfo.职务等级, () => GetLvDescr(employeeInfo.职务等级), TimeSpan.FromHours(18));
            工龄 = employeeInfo.工龄 / (decimal)12.0;
            年龄 = employeeInfo.年龄;
            学历 = employeeInfo.学历;
            籍贯 = employeeInfo.籍贯;
            华劲工龄 = employeeInfo.华劲工龄;
            任职时间 = employeeInfo.任职时间;
            月薪类型 = salary.月薪类型;
            岗位级别 = salary.管培生级别;
            是管培生 = employeeInfo.是管培生;
            是主管 = employeeInfo.职务名称 != null &&
                (employeeInfo.职务名称.IndexOf("部门主管") != -1 || employeeInfo.职务名称.IndexOf("厂长") != -1 || employeeInfo.职务名称.IndexOf("场长") != -1);

            LevelInfo level = LevelInfoCache.Get(employeeInfo.职务等级, () => GetLevelInfo(employeeInfo.职务等级), TimeSpan.FromHours(18));
            if (level != null) 职等 = level.级别;


            满勤奖_显示 = "—";
            年休假_显示 = "—";
            津贴补助_显示 = "—";

            公司编码 = publicSalary.公司编号;
            部门编码 = publicSalary.部门编号;
            职务等级 = publicSalary.职务等级;
            工资职等 = publicSalary.工资职等;

            if (privateSalary != null)
            {
                上表工资标准 = this.publicSalary.上表工资 + this.publicSalary.工资降级;
                年休假工资 = this.publicSalary.未休年休假工资;
                满勤奖金额 = this.publicSalary.应得满勤奖;
                if (privateSalary.年度 < 2018)
                {
                    职务工资 = this.privateSalary.职级工资 - 满勤奖金额;
                    职级工资 = 职务工资 + 满勤奖金额 + 年休假工资;
                }
                else
                {
                    职务工资 = this.privateSalary.职务工资;
                    职级工资 = this.privateSalary.职级工资;
                }
                总工资 = this.privateSalary.总工资;
                薪等 = this.privateSalary.薪等;
                薪级 = this.privateSalary.薪级;
                职等名称 = this.privateSalary.评定职等;
                执行职级 = this.privateSalary.执行职级;

                SalaryResult sr = publicSalary;
                公司编码 = sr == null ? employeeInfo.公司 : sr.公司编号;
                职务等级 = sr == null ? employeeInfo.职务等级 : sr.职务等级;
                工资职级 = this.privateSalary.薪等名称 + this.privateSalary.薪级名称;
                薪等名称 = this.privateSalary.薪等名称;
                薪级名称 = this.privateSalary.薪级名称;
            }

            职级 = LvDescrCache.Get(职务等级, () => GetLvDescr(职务等级), TimeSpan.FromHours(18));

            月薪_显示 = 月薪.ToString("#0.##");
            年薪_显示 = 年薪.ToString("#0.##");
            职务工资_显示 = 职务工资.ToString("#0.##");
            满勤奖_显示 = 满勤奖金额 > 0 ? 满勤奖金额.ToString("#0.##") : "—";
            年休假_显示 = 年休假工资 > 0 ? 年休假工资.ToString("#0.##") : "—";
        }

        public EmployeeSalaryData(EmployeeInfo employee, DateTime date)
        {
            PrivateSalary salary = PrivateSalaryCache.Get(employee.员工编号, () => GetPrivateSalary(employee.员工编号, date), TimeSpan.FromHours(1));
            InitData(salary);
        }

        LevelInfo GetLevelInfo(string lv)
        {
            LevelInfo level = LevelInfo.职务等级表.Find(a => a.编码 == lv);
            return level;
        }
        string GetLvDescr(string lv)
        {
            string s = PsHelper.GetSupvsrLvDescr(lv);
            return s;
        }
        private PrivateSalary GetPrivateSalary(string emplid, DateTime date)
        {
            PrivateSalary salary = PrivateSalary.GetPrivateSalary(emplid, date.Year, date.Month);
            if (salary != null) PrivateSalaryCache.Set(emplid, salary, TimeSpan.FromHours(4));
            return salary;
        }
        private SalaryResult GetSalaryResult(string emplid, DateTime date)
        {
            SalaryResult salary = SalaryResult.GetFromCache(emplid, date.Year, date.Month);
            if (salary != null) PrivateSalaryCache.Set(emplid, salary, TimeSpan.FromHours(4));
            return salary;
        }

        #region 员工信息

        public EmployeeInfo 员工信息
        {
            get { return employeeInfo; }
        }
        #endregion
        
        #region 员工编号

        public string 员工编号
        {
            get
            {
                return this.员工信息.员工编号;
            }
        }
        #endregion

        #region 姓名

        public string 姓名
        {
            get
            {
                return this.员工信息.姓名;
            }
        }
        #endregion

        #region 性别

        public string 性别
        {
            get
            {
                return this.员工信息.性别;
            }
        }
        #endregion

        #region 员工序号

        public int 员工序号
        {
            get
            {
                return this.员工信息.员工序号;
            }
        }
        #endregion
       
        #region 所属部门

        DeptInfo dept = null;
        public DeptInfo 所属部门
        {
            get
            {
                if (dept == null) dept = DeptInfo.Get(this.员工信息.部门);
                return dept;
            }
        }
        #endregion

        #region 部门序号

        public int 部门序号
        {
            get
            {
                return this.员工信息.部门序号;
            }
        }
        #endregion

        #region 公司名称

        public string 公司名称
        {
            get
            {
                if (this.员工信息 != null)
                {
                    return this.员工信息.公司名称;
                }
                else
                    return "";
            }
        }
        #endregion

        #region 部门名称

        public string 部门名称
        {
            get
            {
                if (this.员工信息 != null)
                {
                    return this.员工信息.部门名称;
                }
                else
                    return "";
            }
        }
        #endregion

        #region 月薪

        public decimal 月薪
        {
            get
            {
                return 总工资;
            }
        }
        #endregion

        #region 年薪

        public decimal 年薪
        {
            get
            {
                return this.月薪 * 12;
            }
        }
        #endregion

        #region 最近一次调整距离当前时间
        public string 最近一次调整距离当前时间
        {
            get
            {
                if (工资调整记录 != null && 工资调整记录.Count > 0)
                {
                    PrivateSalary latest = 工资调整记录[0];
                    TimeSpan ts = DateTime.Now - new DateTime(latest.年度, latest.月份, 1);
                    decimal months = (decimal)ts.TotalDays / (decimal)30.5;
                    return MyHelper.ConvertMonthToChinese(Convert.ToInt32(Math.Truncate(months)));
                }
                else
                    return "";                
            }
        }
        #endregion

        #region 最近一次调整调整额度
        public string 最近一次调整调整额度
        {
            get
            {
                if (工资调整记录 != null && 工资调整记录.Count > 1)
                {
                    PrivateSalary latest = 工资调整记录[0];
                    PrivateSalary latest_prev = 工资调整记录[1];
                    return (latest.职级工资 - latest_prev.职级工资).ToString("#0.##");
                }
                else
                    return "";
            }
        }
        #endregion

        #region 历史调资明细

        public string 历史调资明细
        {
            get
            {
                return "点击查看";
            }
        }
        #endregion

        public string 月薪_显示 { get; set; }
        public string 年薪_显示 { get; set; }
        public string 满勤奖_显示 { get; set; }
        public string 年休假_显示 { get; set; }
        public string 津贴补助_显示 { get; set; }
        public string 月收入_显示 { get; set; }
        public string 年总收入_显示 { get; set; }
        public string 职务工资_显示 { get; set; }
    }
}
