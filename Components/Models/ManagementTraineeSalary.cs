using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;

namespace Hwagain.SalaryCalculation.Components
{
    //管培生工资
    public class ManagementTraineeSalary
    {
        public string 员工编号 { get; set; }
        public string 姓名 { get; set; }
        public int 年份 { get; set; }
        public int 月份 { get; set; }
        public int 季度 { get; set; }
        public decimal 年薪 { get; set; }
        public string 年薪_万元 { get; set; }
        public int 月薪 { get; set; }
        public string 增幅 { get; set; }
        public string 专业属性 { get; set; }
        public ManagementTraineeInfo 管培生信息 { get; set; }

        #region GetMonthlySalaryList

        public static List<ManagementTraineeSalary> GetMonthlySalaryList(string emplid, int year)
        {
            //获取管培生基本信息
            ManagementTraineeInfo traineeInfo = ManagementTraineeInfo.GetManagementTraineeInfo(emplid);
            return GetMonthlySalaryList(traineeInfo, year);
        }
        //获取值指定管培生月薪表
        public static List<ManagementTraineeSalary> GetMonthlySalaryList(ManagementTraineeInfo trainee, int year)
        {
            List<ManagementTraineeSalary> list = new List<ManagementTraineeSalary>();
            if (trainee == null) return list;

            //获取本年所有提资记录
            List<ManagementTraineePayStandard> standards = ManagementTraineePayStandard.GetManagementTraineePayStandards(trainee.员工编号);
            standards = standards.OrderByDescending(a => a.开始执行时间).ToList(); //倒序, 以便按时间找到的第一条记录就是执行的记录
            ManagementTraineePayStandard last_rise = null;
            if (standards.Count > 0)
            {
                //上月标准（去年最后一次提资）
                ManagementTraineePayStandard prev = standards.Find(a => a.开始执行时间 < new DateTime(year, 1, 1));
                //最近一次评定
                ManagementTraineeAbility last_ability = ManagementTraineeAbility.GetLastAbility(trainee.员工编号);
                //最近一次提资
                last_rise = standards[0]; //最后一次提资
                //构造月薪记录
                for (int i = 1; i <= 12; i++)
                {
                    ManagementTraineeSalary salary = new ManagementTraineeSalary();
                    DateTime start = new DateTime(year, i, 1);
                    ManagementTraineePayStandard effectiveStandard = standards.Find(a => a.开始执行时间 <= start);
                    //如果有执行标准
                    if (effectiveStandard != null)
                    {
                        salary.员工编号 = trainee.员工编号;
                        salary.姓名 = trainee.姓名;
                        salary.年份 = year;
                        salary.季度 = (int)((i - 0.5) / 3) + 1;
                        salary.月份 = i;
                        salary.专业属性 = trainee.专业属性;
                        salary.管培生信息 = trainee;
                        salary.年薪 = effectiveStandard.年薪;
                        salary.月薪 = effectiveStandard.月薪;
                        if(prev != null && salary.年薪 > prev.年薪)
                            salary.增幅 = effectiveStandard.增幅.ToString("#0.##") + "%";

                        if (salary.年薪 > 0) salary.年薪_万元 = salary.年薪.ToString("#0.#");

                        //不能超过最后一次提资记录的那个季度，
                        int x = salary.年份 - last_rise.年份;
                        int y = salary.季度 - last_rise.季度;
                        if (x * 4 + y <= 0)
                        {
                            list.Add(salary);
                        }
                        else
                        {
                            if (last_ability != null)
                            {
                                int m = salary.年份 - last_ability.年度;
                                int n = salary.季度 - 3;
                                if (m * 4 + n < 4)
                                {
                                    list.Add(salary);
                                }
                            }
                        }
                        prev = effectiveStandard;
                    }
                }
            }
            return list;
        }
        #endregion

        #region GetQuarterSalaryList
        //获取季度工资表
        public static List<ManagementTraineeSalary> GetQuarterSalaryList(string emplid, int year)
        {
            List<ManagementTraineeSalary> all = GetMonthlySalaryList(emplid, year);

            List<ManagementTraineeSalary> list = new List<ManagementTraineeSalary>();
            for (int i = 1; i <= 4; i++)
            {
                ManagementTraineeSalary first = all.Find(a => a.季度 == i);
                if (first != null) list.Add(first);
            }
            return list;
        }
        #endregion


    }
}
