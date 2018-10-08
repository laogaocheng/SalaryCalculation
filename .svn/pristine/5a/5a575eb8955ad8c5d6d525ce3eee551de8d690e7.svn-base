using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Hwagain.SalaryCalculation.Components
{
    //员工薪酬结构
    public class EmployeeSalaryStructure
    {
        public int 序号 { get; set; }
        public string 员工编号 { get; set; }
        public string 姓名 { get; set; }
        public string 性别 { get; set; }
        public string 公司 { get; set; }
        public string 部门 { get; set; }

        public string 结构类型 { get; set; }

        public string 职务 { get; set; }
        public string 职等 { get; set; }

        public decimal 年薪_绩效工资 { get; set; }
        public decimal 年薪_奖励 { get; set; }
        public decimal 年薪_12个月 { get; set; }
        public decimal 年薪_合计 { get; set; }

        public decimal 月薪项目_月工资 { get; set; }
        public decimal 月薪项目_年休假 { get; set; }
        public decimal 月薪项目_满勤奖 { get; set; }
        public decimal 月薪项目_交通餐饮补贴 { get; set; }
        public decimal 月薪项目_小计 { get; set; }

        public decimal 月薪项目_减项_绩效工资 { get; set; }
        public decimal 月薪项目_减项_工资借款 { get; set; }
        public decimal 月薪项目_减项_契约津贴 { get; set; }
        public decimal 月薪项目_减项_福利借款 { get; set; }
        public decimal 月薪项目_减项_报账工资 { get; set; }
        public DateTime 开始执行日期 { get; set; }

        EmployeeInfo 员工信息 { get; set; }
        WageLoan 借款工资 { get; set; }
        SalaryStructure 薪酬结构 { get; set; }
        RembursementSalary 报账工资 { get; set; }
        MonthlySalary 月薪标准 { get; set; }

        #region 构造函数

        public EmployeeSalaryStructure(EmployeeInfo empInfo)
        {
            DateTime 期间开始 = DateTime.Today;

            员工信息 = empInfo;

            薪酬结构 = SalaryStructure.GetEffective(empInfo.员工编号, 期间开始);
            借款工资 = WageLoan.GetEffective(empInfo.员工编号, 期间开始);
            报账工资 = RembursementSalary.GetEffective(empInfo.员工编号, 期间开始);
            月薪标准 = MonthlySalary.GetEffective(empInfo.员工编号, 期间开始);

            //处理，获取相关数据
            this.员工编号 = empInfo.员工编号;
            this.姓名 = empInfo.姓名;
            this.性别 = empInfo.性别;
            this.职务 = empInfo.职务名称;
            this.公司 = empInfo.公司;
            this.部门 = empInfo.部门名称;
            this.职等 = empInfo.职等;

            if (月薪标准 != null)
            {
                this.开始执行日期 = 月薪标准.开始执行日期;
                this.年薪_12个月 = 月薪标准.执行_月薪 * 12;
                this.年薪_合计 = 月薪标准.执行_月薪 * 12;
                this.月薪项目_小计 = 月薪标准.执行_月薪;
            }
            if (薪酬结构 != null)
            {
                this.结构类型 = 薪酬结构.类型;
                this.年薪_奖励 = 薪酬结构.年薪_奖励;
                this.年薪_绩效工资 = 薪酬结构.年薪_绩效工资;
                this.年薪_12个月 = 薪酬结构.年薪_12个月;
                this.年薪_合计 = 薪酬结构.年薪_合计;

                this.月薪项目_月工资 = 薪酬结构.月薪项目_月工资;
                this.月薪项目_年休假 = 薪酬结构.月薪项目_年休假;
                this.月薪项目_满勤奖 = 薪酬结构.月薪项目_满勤奖;
                this.月薪项目_交通餐饮补贴 = 薪酬结构.月薪项目_交通餐饮补贴;
                this.月薪项目_小计 = 薪酬结构.月薪项目_小计;

                this.月薪项目_减项_绩效工资 = 薪酬结构.月薪项目_减项_绩效工资;
                this.开始执行日期 = 薪酬结构.开始执行日期;
            }
            else
            {
                this.结构类型 = "标准";
                this.年薪_奖励 = 0;

                this.月薪项目_交通餐饮补贴 = PsHelper.GetTrafficSubsidies(员工编号, 期间开始);
                this.月薪项目_满勤奖 = PsHelper.GetFullAttendancePayFromCache(empInfo.薪资体系, empInfo.薪等, 期间开始);
                this.月薪项目_年休假 = PsHelper.GetVacPayFromCache(empInfo.薪资体系, empInfo.薪等, 期间开始);
                this.月薪项目_月工资 = 月薪项目_小计 - 月薪项目_满勤奖 - 月薪项目_年休假 - 月薪项目_交通餐饮补贴;
            }
            if (借款工资 != null) 月薪项目_减项_工资借款 = 借款工资.月借款额度;
            if (报账工资 != null) 月薪项目_减项_报账工资 = 报账工资.月度可报账标准_税前;
        }

        #endregion

        public decimal 月薪项目_减项_小计
        {
            get
            {
                return 月薪项目_减项_绩效工资 + 月薪项目_减项_工资借款 + 月薪项目_减项_契约津贴 + 月薪项目_减项_福利借款 + 月薪项目_减项_报账工资;
            }
        }
        public decimal 月应发工资
        {
            get
            {
                return 月薪项目_小计 - 月薪项目_减项_小计;
            }
        }
        public string 查看明细按钮文字
        {
            get { return "查看"; }
        }

        public decimal 年薪_奖励_万元
        {
            get { return 年薪_奖励 / 10000; }
        }
        public decimal 年薪_12个月_万元
        {
            get { return 年薪_12个月 / 10000; }
        }
        public decimal 年薪_合计_万元
        {
            get { return 年薪_合计 / 10000; }
        }
        public decimal 年薪_绩效工资_万元
        {
            get { return 年薪_绩效工资 / 10000; }
        }
    }
}
