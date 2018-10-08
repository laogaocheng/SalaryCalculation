using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace Hwagain.SalaryCalculation.Components.Models
{
    //工资计算器
    public class PayCounter
    {
        public SalaryAuditingResult 审核情况表 = null;
        
        public string 薪资组 { get; set; }
        public string 日历组 { get; set; }
        public int 年 { get; set; }
        public int 月 { get; set; }

        public DateTime 期间_开始 { get; set; }
        public DateTime 期间_结束 { get; set; }
        public decimal 个税起征点 { get; set; }
        public List<StepPayRate> 标准职级工资表 = new List<StepPayRate>();
        public List<PersonPayRate> 个人职级工资表 = new List<PersonPayRate>();
        public List<SalaryResult> 上表工资表 = new List<SalaryResult>();
        public List<OtherMoney> 其它奖扣项 = new List<OtherMoney>();
        public List<EmpPayRate> 工资系数表 = new List<EmpPayRate>();

        public List<SalaryCalculator> 员工工资计算器列表 = new List<SalaryCalculator>();
        public List<string> 错误列表 = new List<string>();

        public List<WaiveAnnualVacation> 放弃年休假记录表 = new List<WaiveAnnualVacation>();

        public PayCounter(SalaryAuditingResult sar)
        {
            this.审核情况表 = sar;

            this.薪资组 = sar.薪资组;
            this.日历组 = sar.日历组;

            CalRunInfo cal = CalRunInfo.Get(sar.日历组);

            this.年 = cal.年度;
            this.月 = cal.月份;
            this.期间_开始 = cal.开始日期;
            this.期间_结束 = cal.结束日期;
            this.放弃年休假记录表 = WaiveAnnualVacation.GetAll(this.年, this.月);
        }

        #region Calculate

        public bool Calculate()
        {
            Init();

            bool has_error = false;
            员工工资计算器列表.Clear();
            foreach (SalaryResult sr in 上表工资表)
            {
                SalaryCalculator counter = new SalaryCalculator(this, sr);
                if (counter.Calculate())
                    员工工资计算器列表.Add(counter);
                else
                {
                    if (counter.计算错误描述 != null)
                    {
                        错误列表.Add(counter.计算错误描述);
                        has_error = true;
                    }
                }
            }
            //如果计算有错误
            if (has_error) return false;

            //自动按照规则形成抽查记录
            //GenerateCheckRecords();
            //保存计算时间
            this.审核情况表.工资计算时间 = DateTime.Now;
            this.审核情况表.制表人 = AccessController.CurrentUser.姓名;
            this.审核情况表.制表时间 = DateTime.Now;                   
            this.审核情况表.Save();
            this.审核情况表.UnLock();

            return true;
        }
 
        #endregion

        #region GenerateCheckRecords
        //产生抽查记录
        private void GenerateCheckRecords()
        {
            int 最少抽查数 = (int)(员工工资计算器列表.Count * 0.1 + 0.9);
            var 薪等集合 = from p in 员工工资计算器列表
                       group p by p.评定职等 into g
                        select g;

            List<PrivateSalary> 候选的记录 = GetWaiting();
            List<PrivateSalary> 抽中的记录 = new List<PrivateSalary>();

            //每个薪资组选择一条记录
            foreach(var grade in 薪等集合)
            {
                List<PrivateSalary> items = 候选的记录.FindAll(a => a.评定职等 == grade.Key);
                if (items.Count > 0)
                {
                    Random rdm = new Random(unchecked((int)DateTime.Now.Ticks));
                    int x = (int)rdm.Next(0, items.Count);
                    PrivateSalary selectedItem = items[x];
                    抽中的记录.Add(selectedItem);
                    //把选择的记录从候选表删除
                    候选的记录.Remove(selectedItem);
                }
            }
            //如果小于最少抽查数，继续抽查
            while (抽中的记录.Count < 最少抽查数 && 候选的记录.Count > 0)
            {
                Random rdm = new Random(unchecked((int)DateTime.Now.Ticks));
                int x = (int)rdm.Next(0, 候选的记录.Count);
                PrivateSalary selectedItem = 候选的记录[x];
                抽中的记录.Add(selectedItem);
                //把选择的记录从候选表删除
                候选的记录.Remove(selectedItem);
            }
            //清除旧的抽查记录
            PayCheckRecord.ClearPayCheckRecord(日历组, 薪资组);
            //保存选中的记录
            foreach (PrivateSalary item in 抽中的记录)
            {
                PayCheckRecord rec = PayCheckRecord.AddPayCheckRecord(item.标识);
                rec.抽取时间 = DateTime.Now;
                rec.薪资组 = item.薪资组;
                rec.日历组 = item.日历组;
                rec.Save();
            }
        }

        private List<PrivateSalary> GetWaiting()
        {
            List<PrivateSalary> list = new List<PrivateSalary>();

            foreach (SalaryCalculator pCounter in 员工工资计算器列表)
            {
                if (pCounter.工资记录 != null) list.Add(pCounter.工资记录);
            }
            return list;
        }

        #endregion

        #region Init

        private void Init()
        {
            个税起征点 = PsHelper.GetPersonTaxPoint(期间_开始);
            标准职级工资表 = StepPayRate.GetEffectives(期间_开始);
            个人职级工资表 = PersonPayRate.GetEffectives(期间_开始);
            上表工资表 = SalaryResult.GetSalaryResults(薪资组, 日历组);
            其它奖扣项 = OtherMoney.GetOtherMoneyList(年, 月);
            工资系数表 = EmpPayRate.GetEmpPayRateList(年, 月);
        }
        #endregion
    }
}