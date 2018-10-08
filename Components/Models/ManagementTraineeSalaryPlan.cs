using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;

namespace Hwagain.SalaryCalculation.Components
{
    //管培生薪酬计划（最小单位季度）
    public class ManagementTraineeSalaryPlan
    {
        public string 届别 { get; set; }
        public string 岗位级别 { get; set; }
        public string 能力级别 { get; set; }
        public string 专业属性 { get; set; }
        public decimal 年薪 { get; set; }
        public decimal 季度年薪 { get; set; }
        public string 增幅 { get; set; }
        public int 季度序数 { get; set; }
        public int 年度序数 { get; set; }

        #region GeneratePlanList

        public static List<ManagementTraineeSalaryPlan> GeneratePlanList(string division, string grade, string type, string level)
        {
            List<ManagementTraineeSalaryPlan> planList = new List<ManagementTraineeSalaryPlan>();

            int year_count = ManagementTraineePayStandard.GetStepStartYear(division, grade, type, -1);
            int quarter_total = year_count * 4;

            List<ManagementTraineePayRiseStandard> standards = ManagementTraineePayRiseStandard.GetManagementTraineePayRiseStandardList(division, grade, type, level);

            int[] rise_flag_a_arr = new int[] {
                0, 0, 1, 0, //第一年
                1, 0, 1, 0, //第二年
                1, 0, 1, 0, //第三年
                1, 0, 1, 0, //第四年
                1, 0, 1, 0, //第五年
                1, 0, 1, 0, //第六年
                1, 0, 0, 0  //第七年
            };
            int[] rise_flag_b_arr = new int[] {
                0, 0, 1, 0, //第一年
                1, 0, 0, 1, //第二年
                0, 0, 1, 0, //第三年
                0, 1, 0, 0, //第四年
                1, 0, 0, 1, //第五年
                0, 0, 1, 0, //第六年
                1, 0, 0, 0  //第七年
            };

            int[] rise_flag_c_arr = new int[] {
                0, 0, 1, 0, //第一年
                1, 0, 0, 0, //第二年
                1, 0, 0, 0, //第三年
                1, 0, 0, 0, //第四年
                1, 0, 0, 0, //第五年
                1, 0, 0, 0, //第六年
                1, 0, 0, 0  //第七年
            };

            int time = 0; //提资序数
            decimal last_year_salary = 0; //上一期年薪

            for (int i = 0; i < quarter_total; i++)
            {
                bool riseFlag = false; //提资标记
                //获取当前季度所处的节点
                double step = ManagementTraineePayStandard.GetStep(division, grade, type, i);
                
                if (level == "A") riseFlag = rise_flag_a_arr[i] == 1;
                if (level == "B") riseFlag = rise_flag_b_arr[i] == 1;
                if (level == "C") riseFlag = rise_flag_c_arr[i] == 1;
                
                if (step < 1 && step != 0) riseFlag = false;
                if (riseFlag && time < 10000) time++; //如果提资，序数+1

                //升阶（满足升阶条件，先升阶，每阶+100, 满阶是 10000）
                //2018-9-21 进入二阶段以后，达到也要达到提资时间间隔才能提资
                if (step >= 2 && time < 100 && riseFlag) { time = 100; }
                if (step == 0) { time = 10000; riseFlag = true; }

                ManagementTraineePayRiseStandard currStandard = standards.Find(a => a.提资序数 == time); //当前标准
                if (currStandard != null)
                {
                    decimal rise_rate = 0;
                    decimal year_salary = 0;

                    //计算年薪和增幅
                    if (currStandard.提资方式 == (int)RiseType.金额)
                    {
                        year_salary = currStandard.年薪;
                        if (last_year_salary > 0)
                        {
                            rise_rate = 100 * ((decimal)(year_salary - last_year_salary) / (decimal)last_year_salary);
                            rise_rate = Math.Round(rise_rate, 1, MidpointRounding.AwayFromZero);
                        }
                    }
                    else
                    {
                        if (riseFlag) //如果提资
                        {
                            rise_rate = currStandard.增幅;
                            year_salary = Math.Round(last_year_salary * (100 + rise_rate) * (decimal)0.01, 1, MidpointRounding.AwayFromZero);
                        }
                        else
                            year_salary = last_year_salary;
                    }

                    ManagementTraineeSalaryPlan item = new ManagementTraineeSalaryPlan();
                    item.届别 = division;
                    item.岗位级别 = grade;
                    item.能力级别 = level;
                    item.专业属性 = type;
                    item.季度序数 = i;
                    item.年度序数 = i / 4;
                    item.季度年薪 = year_salary;
                    if (riseFlag && rise_rate > 0)
                    {
                        item.增幅 = rise_rate.ToString("#0.#") + "%";
                        if (time == 10000 && step != 0) item.增幅 = "";
                    }
                    planList.Add(item);

                    last_year_salary = year_salary;
                }
            }
            //统计年薪
            foreach (ManagementTraineeSalaryPlan item in planList)
            {
                List<ManagementTraineeSalaryPlan> list = planList.FindAll(a => a.年度序数 == item.年度序数);
                item.年薪 = Math.Round(list.Sum(a => a.季度年薪) / (decimal)4.0, 1, MidpointRounding.AwayFromZero);
            }
            return planList;
        }

        #endregion
    }
}
