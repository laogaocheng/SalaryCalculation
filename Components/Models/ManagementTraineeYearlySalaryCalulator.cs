using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;

namespace Hwagain.SalaryCalculation.Components
{
    //管培生工资
    public class ManagementTraineeYearlySalaryCalulator
    {
        public int 序号 { get; set; }
        public string 员工编号 { get; set; }
        public string 姓名 { get; set; }
        public string 公司 { get; set; }
        public int 年度 { get; set; }
        public string 专业属性 { get; set; }
        public string 岗位类型 { get; set; }

        public string 评定结果 { get; set; }
        public decimal 起薪 { get; set; }
        public string 起薪_万元 { get; set; }

        public ManagementTraineeAbility 年度评定 { get; set; }
        
        public ManagementTraineeSalary 一季度 { get; set; }
        public ManagementTraineeSalary 二季度 { get; set; }
        public ManagementTraineeSalary 三季度 { get; set; }
        public ManagementTraineeSalary 四季度 { get; set; }

        public ManagementTraineeInfo 管培生信息 { get; set; }

        public ManagementTraineeYearlySalaryCalulator(ManagementTraineeInfo trainee, int year)
        {
            List<ManagementTraineeSalary> list = ManagementTraineeSalary.GetQuarterSalaryList(trainee.员工编号, year);
            一季度 = list.Find(a => a.季度 == 1);
            二季度 = list.Find(a => a.季度 == 2);
            三季度 = list.Find(a => a.季度 == 3);
            四季度 = list.Find(a => a.季度 == 4);

            员工编号 = trainee.员工编号;
            年度 = year;

            管培生信息 = trainee;
            起薪 = trainee.年薪;
            if (起薪 > 0) 起薪_万元 = 起薪.ToString("#0.#");
            姓名 = 管培生信息.姓名;
            公司 = 管培生信息.员工信息.公司名称;
            专业属性 = 管培生信息.专业属性;
            岗位类型 = 管培生信息.岗位类型;
            年度评定 = ManagementTraineeAbility.GetManagementTraineeAbility(员工编号, year);
            if (年度评定 != null) 评定结果 = 年度评定.能力级别;
        }

        public ManagementTraineePayStandard 上期标准
        {
            get
            {
                ManagementTraineePayStandard tps;
                DateTime startDate = new DateTime(年度, 1, 1);
                if (年度.ToString() == 管培生信息.届别)
                    tps = ManagementTraineePayStandard.GetFromCache(员工编号, 0);
                else
                    tps = ManagementTraineePayStandard.GetLatestBeforeOneday(员工编号, startDate);

                return tps;
            }
        }

        public decimal 上期年薪
        {
            get
            {
                if (上期标准 == null)
                    return 0;
                else
                    return 上期标准.年薪;
            }
        }

        public string 上期年薪_万元
        {
            get
            {
                if (上期年薪 > 0)
                    return 上期年薪.ToString("#0.#");
                else
                    return "";
            }
        }

        ManagementTraineeYearlySalaryCalulator nextYearCalulator;
        public ManagementTraineeYearlySalaryCalulator 明年
        {
            get
            {
                if (nextYearCalulator == null) nextYearCalulator = new ManagementTraineeYearlySalaryCalulator(管培生信息, 年度 + 1);
                return nextYearCalulator;
            }
        }

    }
}
