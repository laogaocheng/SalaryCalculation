using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using Hwagain.Components;

namespace Hwagain.SalaryCalculation.Components
{
    public class EmployeePayData
    {
        EmployeeInfo employeeInfo = null;

        private bool isRealtime = false;

        public int 序号 { get; set; }
        public int 公司序号 { get; set; }

        public int 封闭薪等 { get; set; }
        public int 封闭薪级 { get; set; }

        public int 薪等_月初 { get; set; }
        public int 薪级_月初 { get; set; }
        public int 薪等_月底 { get; set; }
        public int 薪级_月底 { get; set; }

        public int 年 { get; set; }
        public int 月 { get; set; }

        public DateTime 期间_开始 { get; set; }
        public DateTime 期间_结束 { get; set; }
        public DateTime 开始执行日期 { get; set; }
        public DateTime 截止执行日期 { get; set; }
        public DateTime 上次调整时间 { get; set; }

        public DateTime 开始执行日期_月初 { get; set; }
        public DateTime 开始执行日期_月底 { get; set; }

        public decimal 职务工资 { get; set; }
        public decimal 职级工资 { get; set; }
        public decimal 津贴补助 { get; set; }
        public decimal 满勤奖金额 { get; set; }
        public decimal 年休假工资 { get; set; }
        public decimal 上表工资标准 { get; set; }
        
        public string 公司编码 { get; set; }
        public string 职务等级 { get; set; }
        public string 工资职级 { get; set; }
        public string 职务 { get; set; }
        public string 职级 { get; set; }

        public decimal 职等 { get; set; }        

        public decimal 工龄 { get; set; }
        public string 华劲工龄 { get; set; }
        public string 任职时间 { get; set; }
        public string 职级名称 { get; set; } 

        public string 薪等 { get; set; }
        public string 薪级 { get; set; }

        public StepPayRate 当前职级 { get; set; }
        public StepPayRate 上次职级 { get; set; }
        public bool 是标准职务工资 { get; set; }
        
        static List<StepPayRate> 标准职务工资表 = null;
        static List<PersonPayRate> 个人职务工资表 = null;

        public List<EmployeePayData> 工资调整明细 { get; set; }
        public string 记录类型 { get; set; }  //当前执行  历史记录

        public bool 是主管 { get; set; }

        public EmployeePayData(EmployeeInfo employee, DateTime date, bool realtime)
        {
            this.employeeInfo = employee;
            this.isRealtime = realtime;

            公司序号 = employee.公司序号;
            职务 = employee.职务名称;
            职级名称 = PsHelper.GetSupvsrLvDescr(employee.职务等级);
            工龄 = employee.工龄 / (decimal)12.0;
            华劲工龄 = employee.华劲工龄;
            任职时间 = employee.任职时间;
            是主管 = employee.职务名称 != null &&
                (employee.职务名称.IndexOf("部门主管") != -1 || employee.职务名称.IndexOf("厂长") != -1 || employee.职务名称.IndexOf("场长") != -1);

            LevelInfo level = LevelInfo.职务等级表.Find(a => a.编码 == employee.职务等级);
            if (level != null) 职等 = level.级别;    
    
            年 = date.Year;
            月 = date.Month;

            期间_开始 = new DateTime(年, 月, 1);
            if (isRealtime) 期间_开始 = 期间_开始.AddMonths(-1);
            期间_结束 = 期间_开始.AddMonths(1).AddDays(-1);

            if (标准职务工资表 == null) 标准职务工资表 = StepPayRate.GetEffectives(期间_开始);
            if (个人职务工资表 == null) 个人职务工资表 = PersonPayRate.GetEffectives(期间_开始);
        }

        #region 员工信息

        public EmployeeInfo 员工信息
        {
            get { return employeeInfo; }
        }
        #endregion

        #region Calculate

        public void Calculate()
        {
            decimal 标准职务工资, 个人职务工资;

            是标准职务工资 = true;
            满勤奖_显示 = "—";
            年休假_显示 = "—";
            津贴补助_显示 = "—";

            //获取薪酬信息
            GetPayInfo();

            //获取上表工资标准
            SalaryBaseInfo sbi = PsHelper.GetSalaryGrade(员工编号, 期间_开始);
            if (sbi != null)
            {
                上表工资标准 = sbi.上表工资标准;
                年休假工资 = sbi.年休假工资;
                满勤奖金额 = sbi.满勤奖金额;

                满勤奖_显示 = 满勤奖金额 > 0 ? 满勤奖金额.ToString("#0.##") : "—";
                年休假_显示 = 年休假工资 > 0 ? 年休假工资.ToString("#0.##") : "—"; ;
            }

            #region 计算职务工资

            StepPayRate stepPayRate = null;
            List<StepPayRate> rates = 标准职务工资表.FindAll(a => a.薪级标识 == 薪级_月初).OrderByDescending(a => a.执行日期).ToList();
            if (rates.Count > 0)
            {
                stepPayRate = rates[0];
                开始执行日期 = 开始执行日期_月初;
            }
            //月底职级
            List<StepPayRate> rates_月底 = 标准职务工资表.FindAll(a => a.薪级标识 == 薪级_月底).OrderByDescending(a => a.执行日期).ToList();
            if (rates.Count > 0)
            {
                StepPayRate stepPayRate_月底 = rates[0];
                //如果月底职级改变，去工资低的
                if (stepPayRate_月底.标识 != stepPayRate.标识)
                {
                    stepPayRate = stepPayRate.工资额 < stepPayRate_月底.工资额 ? stepPayRate : stepPayRate_月底;
                    开始执行日期 = 开始执行日期_月底;
                }
            }            

            PersonPayRate personPayRate = null;
            List<PersonPayRate> pRates = 个人职务工资表.FindAll(a => a.生效日期 == 期间_开始 && a.员工编号 == this.员工编号).OrderByDescending(a => a.生效日期).ToList();
            if (isRealtime) pRates = 个人职务工资表.FindAll(a => a.有效 && a.员工编号 == this.员工编号).OrderByDescending(a => a.生效日期).ToList();
            if (pRates.Count > 0)
            {
                personPayRate = pRates[0];
                开始执行日期 = personPayRate.生效日期;
                //津贴补助
                津贴补助 = personPayRate.津贴1金额 + personPayRate.津贴2金额;
                津贴补助_显示 = 津贴补助 > 0 ? 津贴补助.ToString("#0.##") : "—";
            }
            标准职务工资 = stepPayRate == null ? 0 : stepPayRate.工资额;
            个人职务工资 = personPayRate == null ? 0 : personPayRate.月薪;
            职务工资 = 个人职务工资 == 0 ? 标准职务工资 : 个人职务工资;
            是标准职务工资 = 个人职务工资 == 0;
            //2017-7-23 加上年休假工资
            职级工资 = 职务工资 + 年休假工资;

            //重新计算有效的薪等薪级
            工资职级 = " - ";
            if (stepPayRate != null && 是标准职务工资)
            {
                封闭薪等 = stepPayRate.薪等标识;
                封闭薪级 = stepPayRate.薪级标识;

                SalaryNode grade = SalaryNode.工资等级表.Find(a => a.标识 == 封闭薪等);
                if (grade != null) 薪等 = grade.名称;

                grade = SalaryNode.工资等级表.Find(a => a.标识 == 封闭薪级);
                if (grade != null) 薪级 = grade.名称;

                工资职级 = 薪等 + 薪级;
            }

            #endregion

            SalaryResult sr = SalaryResult.GetFromCache(员工编号, 年, 月);
            公司编码 = sr == null ? employeeInfo.公司 : sr.公司编号;
            职务等级 = sr == null ? employeeInfo.职务等级 : sr.职务等级;
            职级 = PsHelper.GetSupvsrLvDescr(职务等级);
        }
        #endregion

        #region GetPayInfo

        void GetPayInfo()
        {
            //取月初薪等薪级
            DateTime date = new DateTime(期间_开始.Year, 期间_开始.Month, 15);
            EmpSalaryStep 月初职级 = EmpSalaryStep.GetEffective(员工编号, date);
            EmpSalaryStep 月底职级 = EmpSalaryStep.GetEffective(员工编号, 期间_结束);

            if (月初职级 != null)
            {
                薪等_月初 = 月初职级.薪等标识;
                薪级_月初 = 月初职级.薪级标识;
                开始执行日期_月初 = 月初职级.执行日期;                
            }
            if (月底职级 != null)
            {
                薪等_月底 = 月底职级.薪等标识;
                薪级_月底 = 月底职级.薪级标识;
                开始执行日期_月底 = 月底职级.执行日期;      
            }
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
                return this.所属部门.部门序号;
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
                if (职务工资 == 0) Calculate();
                return 职级工资;
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

        #region 月收入

        public decimal 月收入
        {
            get
            {
                return 职级工资 + 满勤奖金额 + 津贴补助;
            }
        }
        #endregion

        #region 年总收入

        public decimal 年总收入
        {
            get
            {
                return 月收入 * 12;
            }
        }
        #endregion

        #region 距上次调整间隔

        public double 距上次调整间隔
        {
            get
            {
                if (this.上次调整 == null)
                    return 0;
                else
                {
                    TimeSpan ts = this.开始执行日期 - 上次调整.开始执行日期;
                    double x = ts.TotalDays / 365;
                    if (x > 100) return 0;
                    return x;
                }
            }
        }
        #endregion

        #region 距今天间隔

        public double 距今天间隔
        {
            get
            {
                if (this.开始执行日期.Year < 1993)
                    return 0;
                else
                {
                    TimeSpan ts = DateTime.Today - this.开始执行日期;
                    double x = ts.TotalDays / 365;
                    return x;
                }
            }
        }
        #endregion

        #region 已执行年限

        public double 已执行年限
        {
            get
            {
                if (this.开始执行日期.Year < 1993)
                    return 0;
                else
                {
                    TimeSpan ts = DateTime.Today - this.开始执行日期;
                    if (下次调整 != null && this.开始执行日期.Year > 1993) ts = 下次调整.开始执行日期 - this.开始执行日期;
                    double x = ts.TotalDays / 365;
                    return x;
                }
            }
        }
        #endregion

        #region 调整金额

        public decimal 调整金额
        {
            get
            {
                if (上次调整 == null)
                    return 0;
                else
                    return this.月收入 - 上次调整.月收入;
            }
        }
        #endregion

        #region 调整幅度

        public decimal 调整幅度
        {
            get
            {
                if (上次调整 == null)
                    return 0;
                else
                {
                    decimal x = (this.月收入 - 上次调整.月收入) / 上次调整.月收入;
                    return x;
                }
            }
        }
        #endregion

        #region 查看调整明细
        
        public string 查看调整明细
        {
            get
            {
                return "点击查看";
            }
        }
        #endregion

        public string 职务工资_显示 { get; set; }
        public string 职级工资_显示 { get; set; }
        public string 月薪_显示 { get; set; }
        public string 年薪_显示 { get; set; }
        public string 满勤奖_显示 { get; set; }
        public string 年休假_显示 { get; set; }
        public string 津贴补助_显示 { get; set; }
        public string 月收入_显示 { get; set; }
        public string 年总收入_显示 { get; set; }
        public string 调整金额_显示 { get; set; }
        public string 调整幅度_显示 { get; set; }
        public string 距上次调整间隔_显示 { get; set; }

        public EmployeePayData 上次调整 { get; set; }
        public EmployeePayData 下次调整 { get; set; }
        
    }
}
