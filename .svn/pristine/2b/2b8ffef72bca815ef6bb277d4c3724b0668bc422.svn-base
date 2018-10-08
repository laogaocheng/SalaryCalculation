using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data.OleDb;

namespace Hwagain.SalaryCalculation.Components.Models
{
    //工资计算器
    public class PersonPayCounter
    {
        PayCounter 工资计算器 = null;
        EmployeeInfo 员工信息 = null;

        public string 员工编号 { get; set; }
        public string 姓名 { get; set; }
        public string 薪资组 { get; set; }
        public string 日历组 { get; set; }
        public int 年 { get; set; }
        public int 月 { get; set; }
        
        public string 职务名称 { get; set; }
        
        public SalaryResult 上表工资表 { get; set; }

        public int 封闭薪等 { get; set; }
        public int 封闭薪级 { get; set; }

        public int 薪等_月初 { get; set; }
        public int 薪级_月初 { get; set; }
        public int 薪等_月底 { get; set; }
        public int 薪级_月底 { get; set; }

        public string 薪酬体系 { get; set; }
        public string 薪酬体系名称 { get; set; }
        public string 薪等名称 { get; set; }
        public string 薪级名称 { get; set; }

        public string 班别 = "";
        public decimal 职级工资 = 0;
        public decimal 其它奖项 = 0;
        public decimal 其它扣项 = 0;
        public decimal 工资降级 = 0;
        public decimal 其它代垫费用 = 0;
        public decimal 工资系数 = 1;
        public decimal 挂考勤的工资 = 0;
        public decimal 封闭出勤工资计算标准 = 0;
        public decimal 本次发放标准 = 0;
        public decimal 封闭出勤工资 = 0;
        public decimal 排班天数 = 0;
        public decimal 实际出勤天数 = 0;
        public decimal 出勤工资 = 0;
        public decimal 综合考核工资 = 0;
        public decimal 年休假工资 = 0;
        public decimal 满勤奖 = 0;
        public decimal 特殊社保的基准工资 = 0;
        public decimal 基数等级与基准工资差额 = 0;
        public decimal 津贴补助 = 0;
        public decimal 封闭奖扣合计 = 0;
        public decimal 封闭工资合计 = 0;
        public decimal 社保缴纳金额 = 0;
        public decimal 总应税工资 = 0;
        public decimal 个人所得税 = 0;
        public decimal 代垫费用 = 0;
        public decimal 实发工资 = 0;
        public decimal 工资发放总额 = 0;

        public decimal 本月剩余月薪额 = 0;
        public decimal 提前借工资本月还款额 = 0;
        public decimal 个人专用车费用本月还款额 = 0;
        public decimal 月租房报销费用本月实际报销额 = 0;
        public decimal 探亲飞机票本月实际报销额 = 0;
        public decimal 本月执行绩效工资额 = 0;
        public decimal 本月实得绩效工资额 = 0;


        PrivateSalary pSal = null;

        public PersonPayCounter(PayCounter payCounter, SalaryResult salaryResult)
        {
            this.工资计算器 = payCounter;
            this.上表工资表 = salaryResult;

            this.员工编号 = salaryResult.员工编号;
            this.姓名 = salaryResult.姓名;
            this.年 = salaryResult.年度;
            this.月 = salaryResult.月份;
            this.薪资组 = salaryResult.薪资组;
            this.日历组 = salaryResult.日历组;
            this.薪酬体系 = salaryResult.薪酬体系编号;

            Calculate();
        }

        #region Error

        public void Error(string errMsg)
        {
            //删除工资
            PrivateSalary.ClearPrivateSalary(日历组, 薪资组);
            //删除计算时间
            SalaryAuditingResult 审核情况表 = this.工资计算器.审核情况表;
            审核情况表.工资计算时间 = DateTime.MinValue;
            审核情况表.Save();

            throw new Exception(errMsg);
        }
        #endregion

        #region Calculate

        public void Calculate()
        {
            try
            {
                decimal 标准职级工资, 个人职级工资;
                bool 是标准职级工资 = true;
                bool 有工资系数 = false;

                //获取薪酬信息
                GetPayInfo();

                #region 计算职级工资

                StepPayRate stepPayRate = null;
                List<StepPayRate> rates = 工资计算器.标准职级工资表.FindAll(a => a.薪级标识 == 薪级_月初).OrderByDescending(a => a.执行日期).ToList();
                if (rates.Count > 0) stepPayRate = rates[0];
                //月底职级
                List<StepPayRate> rates_月底 = 工资计算器.标准职级工资表.FindAll(a => a.薪级标识 == 薪级_月底).OrderByDescending(a => a.执行日期).ToList();
                if (rates.Count > 0)
                {
                    StepPayRate stepPayRate_月底 = rates[0];
                    //如果月底职级改变，去工资低的
                    if (stepPayRate_月底.标识 != stepPayRate.标识)
                    {
                        stepPayRate = stepPayRate.工资额 < stepPayRate_月底.工资额 ? stepPayRate : stepPayRate_月底;
                    }
                }
                //重新计算有效的薪等薪级
                if (stepPayRate != null)
                {
                    封闭薪等 = stepPayRate.薪等标识;
                    封闭薪级 = stepPayRate.薪级标识;
                }

                PersonPayRate personPayRate = null;
                List<PersonPayRate> pRates = 工资计算器.个人职级工资表.FindAll(a => a.有效 && a.员工编号 == this.员工编号).OrderByDescending(a => a.生效日期).ToList();
                if (pRates.Count > 0)
                {
                    personPayRate = pRates[0];
                    //津贴补助
                    津贴补助 = personPayRate.津贴1金额 + personPayRate.津贴2金额;
                }
                标准职级工资 = stepPayRate == null ? 0 : stepPayRate.工资额;
                个人职级工资 = personPayRate == null ? 0 : personPayRate.月薪;
                职级工资 = 个人职级工资 == 0 ? 标准职级工资 : 个人职级工资;
                是标准职级工资 = 个人职级工资 == 0;

                #endregion

                #region 获取薪等薪级名称

                薪等名称 = SalaryNode.GetName(封闭薪等);
                薪级名称 = SalaryNode.GetName(封闭薪级);

                #endregion

                #region 计算其它奖扣项

                //计算其它奖项
                List<OtherMoney> myOtherMoneyItems = 工资计算器.其它奖扣项.FindAll(a => a.员工编号 == this.员工编号 && a.类型 == "其它奖项");
                其它奖项 = myOtherMoneyItems.Sum(a => a.金额);

                //计算其它扣项
                myOtherMoneyItems = 工资计算器.其它奖扣项.FindAll(a => a.员工编号 == this.员工编号 && a.类型 == "其它扣项");
                其它扣项 = myOtherMoneyItems.Sum(a => a.金额);

                //计算工资降级
                myOtherMoneyItems = 工资计算器.其它奖扣项.FindAll(a => a.员工编号 == this.员工编号 && a.类型 == "工资降级");
                工资降级 = myOtherMoneyItems.Sum(a => a.金额);
                工资降级 += 上表工资表.工资降级;

                //计算代垫费用
                myOtherMoneyItems = 工资计算器.其它奖扣项.FindAll(a => a.员工编号 == this.员工编号 && a.类型 == "代垫费用");
                其它代垫费用 = myOtherMoneyItems.Sum(a => a.金额);
                代垫费用 = 上表工资表.代垫费用 + 其它代垫费用;
                #endregion

                #region 获取工资系数

                //获取工资系数
                EmpPayRate epRate = 工资计算器.工资系数表.Find(a => a.员工编号 == this.员工编号);
                if (epRate != null)
                {
                    工资系数 = epRate.系数;
                    有工资系数 = true;
                }

                #endregion

                //有封闭工资的人才需要计算
                if (职级工资 > 0 || 其它奖项 != 0 || 其它扣项 != 0 || 工资降级 != 0 || 其它代垫费用 != 0)
                {
                    //2017.10.22 如果封闭工资没有设置职级工资，职级工资就是上表工资的工资标准
                    //主要针对没有封闭职级工资，但是有比较大的奖项在封闭工资系统发放的情况
                    if (职级工资 == 0) 职级工资 = 上表工资表.上表工资 + 工资降级;

                    #region 计算封闭出勤工资

                    //年休假工资
                    年休假工资 = 上表工资表.未休年休假工资;

                    //清除老的还款记录
                    PersonRepayment.Clear(this.员工编号, this.年, this.月);

                    #region 自动创建还款记录

                    //自动创建还款记录
                    List<PersonBorrow> personBorrowList = PersonBorrow.GetMyBorrows(this.员工编号, this.年, this.月);
                    foreach (PersonBorrow borrowItem in personBorrowList)
                    {
                        //如果还有未还清的款
                        if (borrowItem.余额 > 0)
                        {
                            PersonRepayment pRepayment = PersonRepayment.AddPersonRepayment(borrowItem, this.年, this.月);
                            pRepayment.还款金额 = borrowItem.余额 > borrowItem.每月扣还 ? borrowItem.每月扣还 : borrowItem.余额;
                            pRepayment.员工编号 = this.员工编号;
                            pRepayment.创建人 = AccessController.CurrentUser.姓名;
                            pRepayment.创建时间 = DateTime.Now;
                            pRepayment.Save();
                        }
                    }
                    #endregion

                    #region 获取还款记录

                    List<PersonRepayment> prList = PersonRepayment.GetPersonRepayments(this.员工编号, this.年, this.月);
                    if (prList.Count > 0)
                    {
                        PersonRepayment 还款_提前借工资 = prList.Find(a => a.项目 == "提前借工资");
                        if (还款_提前借工资 != null)
                        {
                            提前借工资本月还款额 = 还款_提前借工资.还款金额;
                        }

                        PersonRepayment 还款_个人专用车费用 = prList.Find(a => a.项目 == "个人专用车费用");
                        if (还款_个人专用车费用 != null)
                        {
                            个人专用车费用本月还款额 = 还款_个人专用车费用.还款金额;
                        }
                    }

                    #endregion

                    #region 获取报销记录

                    List<PersonReimbursement> rbList = PersonReimbursement.GetPersonReimbursements(this.员工编号, this.年, this.月);
                    if (rbList.Count > 0)
                    {
                        PersonReimbursement 报销_月租房报销 = rbList.Find(a => a.项目 == "月租房报销");
                        if (报销_月租房报销 != null) 月租房报销费用本月实际报销额 = 报销_月租房报销.报销金额;

                        PersonReimbursement 报销_探亲飞机票 = rbList.Find(a => a.项目 == "探亲飞机票");
                        if (报销_探亲飞机票 != null) 探亲飞机票本月实际报销额 = 报销_探亲飞机票.报销金额;
                    }

                    #endregion

                    #region 获取绩效工资

                    EffectivePerformanceSalary 绩效考核 = EffectivePerformanceSalary.GetEffective(this.员工编号, this.年, this.月);
                    if (绩效考核 != null)
                    {
                        本月执行绩效工资额 = 绩效考核.绩效工资;
                        本月实得绩效工资额 = 绩效考核.实得工资;
                    }

                    #endregion

                    if (有工资系数)
                        本月剩余月薪额 = (职级工资 + 上表工资表.未休年休假工资) * 工资系数;

                    else
                        本月剩余月薪额 = 职级工资;
                    
                    //2016.6.6 调整，将减掉的部分移到后面
                    //本月剩余月薪额 = 本月剩余月薪额 - 提前借工资本月还款额 - 个人专用车费用本月还款额 - 月租房报销费用本月实际报销额 - 探亲飞机票本月实际报销额 - 本月执行绩效工资额;
                    
                    //计算挂考勤的工资
                    挂考勤的工资 = 本月剩余月薪额;

                    //排班天数
                    排班天数 = 上表工资表.企业排班天数;

                    //出勤天数
                    实际出勤天数 = 上表工资表.实际出勤天数;

                    //封闭出勤工资基准
                    封闭出勤工资计算标准 = 挂考勤的工资 - 工资降级 - 上表工资表.上表工资;
                    if (有工资系数) 封闭出勤工资计算标准 = 封闭出勤工资计算标准 - 上表工资表.未休年休假工资;
                    //剔除考核工资个人部分
                    封闭出勤工资计算标准 -= 本月执行绩效工资额;
                    //本次发放标准
                    本次发放标准 = 封闭出勤工资计算标准;
                    
                    //出勤天数
                    班别 = 上表工资表.班别.Trim();

                    decimal attDays = 实际出勤天数;
                    //封闭出勤工资中， 行政班出勤天数不能大于排班天数
                    if (班别 == "6") //行政班
                        attDays = 实际出勤天数 > 排班天数 ? 排班天数 : 实际出勤天数;

                    if (班别 == "6") //行政班
                    {
                        if (实际出勤天数 > 10)
                            封闭出勤工资 = 封闭出勤工资计算标准 - 封闭出勤工资计算标准 / (decimal)21.75 * (排班天数 - attDays);
                        else
                            封闭出勤工资 = (封闭出勤工资计算标准 / (decimal)21.75) * attDays;
                    }
                    else
                    {
                        if (班别 == "8") //特殊+业务代表+司机
                            封闭出勤工资 = (封闭出勤工资计算标准 / 排班天数) * attDays;
                        else
                            封闭出勤工资 = (封闭出勤工资计算标准 / 26) * attDays;
                    }
                    
                    #endregion
                    
                    //封闭奖扣合计
                    封闭奖扣合计 = 其它奖项 - 其它扣项;

                    //工资合计
                    //2016.6.6 调整 与上面对应  
                    //原来  封闭工资合计 = 封闭出勤工资 + 封闭奖扣合计 + 津贴补助 + 本月实得绩效工资额;
                    封闭工资合计 = 封闭出勤工资 + 封闭奖扣合计 + 津贴补助 + 本月实得绩效工资额 - 提前借工资本月还款额 - 个人专用车费用本月还款额 - 月租房报销费用本月实际报销额 - 探亲飞机票本月实际报销额;                    
                    封闭工资合计 = Math.Round(封闭工资合计, 2, MidpointRounding.AwayFromZero);

                    //总应税工资
                    总应税工资 = 上表工资表.合计应税工资额 + 封闭工资合计; //上表税前应税工资（含年休假工资）加上封闭部分的工资

                    //工资发放总额
                    工资发放总额 = 上表工资表.上表工资总额 + 上表工资表.未休年休假工资 + 封闭工资合计; //上表工资总额不含年休假

                    //个税（总个税）
                    个人所得税 = GetTax(总应税工资);

                    //实发（含封闭和上表）
                    实发工资 = 总应税工资 - 个人所得税 - 代垫费用;
                    实发工资 = Math.Round(实发工资, 2, MidpointRounding.AwayFromZero);

                    #region 保存计算结果

                    //保存计算结果
                    pSal = PrivateSalary.AddPrivateSalary(this.员工编号, this.年, this.月, this.薪资组, this.日历组);

                    pSal.姓名 = 姓名;

                    pSal.职级工资 = 职级工资;
                    pSal.本次发放标准 = 本次发放标准;
                    pSal.是标准职级工资 = 是标准职级工资;
                    pSal.其它奖项 = 其它奖项;
                    pSal.其它扣项 = 其它扣项;
                    pSal.工资降级 = 工资降级;
                    pSal.其它代垫费用 = 其它代垫费用;
                    pSal.津贴补助 = 津贴补助;
                    pSal.工资系数 = 工资系数;
                    pSal.封闭出勤工资 = 封闭出勤工资;
                    pSal.封闭工资合计 = 封闭工资合计;
                    pSal.个人所得税 = 个人所得税;
                    pSal.总应税工资 = 总应税工资;
                    pSal.工资发放总额 = 工资发放总额;
                    pSal.实发工资 = 实发工资;

                    if (是标准职级工资)
                    {
                        pSal.薪等 = 封闭薪等;
                        pSal.薪级 = 封闭薪级;
                        pSal.薪等名称 = 薪等名称;
                        pSal.薪级名称 = 薪级名称;
                    }

                    pSal.职务名称 = PsHelper.GetValue(PsHelper.职务代码, this.上表工资表.职务代码);

                    pSal.本月剩余月薪额 = 本月剩余月薪额;
                    pSal.提前借工资本月还款额 = 提前借工资本月还款额;
                    pSal.个人专用车费用本月还款额 = 个人专用车费用本月还款额;
                    pSal.月租房报销费用本月实际报销额 = 月租房报销费用本月实际报销额;
                    pSal.探亲飞机票本月实际报销额 = 探亲飞机票本月实际报销额;
                    pSal.本月执行绩效工资额 = 本月执行绩效工资额;
                    pSal.本月实得绩效工资额 = 本月实得绩效工资额;

                    pSal.Save();
                    #endregion
                }
            }
            catch (Exception e)
            {
                Error(e.Message);
            }
        }
        #endregion

        #region GetTax

        private decimal GetTax(decimal amount)
        {
            decimal taxIncome = amount - 工资计算器.个税起征点;
            if (taxIncome > 0)
            {
                TaxInfo tax = TaxInfo.Get(taxIncome);
                decimal taxAmount =  taxIncome * tax.税率 - tax.速算扣除数;
                return Math.Round(taxAmount, 2, MidpointRounding.AwayFromZero);
            }
            else
                return 0;
        }

        #endregion

        #region 工资记录

        public PrivateSalary 工资记录
        {
            get
            {
                return pSal;
            }
        }
        #endregion

        #region GetPayInfo

        void GetPayInfo()
        {
            //取月初薪等薪级
            DateTime date = new DateTime(工资计算器.期间_开始.Year, 工资计算器.期间_开始.Month, 15);
            EmpSalaryStep 月初职级 = EmpSalaryStep.GetEffective(员工编号, date);
            EmpSalaryStep 月底职级 = EmpSalaryStep.GetEffective(员工编号, 工资计算器.期间_结束);

            if (月初职级 != null)
            {
                薪等_月初 = 月初职级.薪等标识;
                薪级_月初 = 月初职级.薪级标识;
            }
            if (月底职级 != null)
            {
                薪等_月底 = 月底职级.薪等标识;
                薪级_月底 = 月底职级.薪级标识;
            }
        }
        #endregion

    }
}