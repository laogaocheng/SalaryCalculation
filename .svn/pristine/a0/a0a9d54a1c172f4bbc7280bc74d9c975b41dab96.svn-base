using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using log4net;
using DevExpress.Data.Filtering;
using System.Data.SqlClient;
using Hwagain;
using YiKang;
using System.Data.OleDb;
using System.Reflection;

namespace Hwagain.SalaryCalculation.Components
{
    //执行的职等
    public partial class ImplementJobGrade
    {
        static readonly ILog log = LogManager.GetLogger(typeof(ImplementJobGrade));

        internal GradeSalaryAdjust gsh;
        List<RankSalaryStandard> rss_list = new List<RankSalaryStandard>();

        int year = 0;
        int period = 0;

        public ImplementJobGrade(string rankNames)
        {
            is_separator = true;
            string[] names = rankNames.Split(new char[] { ':' });
            for (int i = 0; i < names.Length; i++)
            {
                //赋值
                string propertyName = "R" + (i + 1).ToString();
                PropertyInfo property = this.GetType().GetProperty(propertyName);
                if (property != null) property.SetValue(this, names[i], null);
            }
        }
        public ImplementJobGrade(string salaryPlan, string grade, int year, SemiannualType semiannual)
        {
            is_separator = false;

            this.year = year;
            this.period = year * 10 + (byte)semiannual;

            薪酬体系 = salaryPlan;
            职等 = grade;
            期号 = period;

            ID = salaryPlan + grade + period;

            RankNames = "";

            rss_list = RankSalaryStandard.GetRankSalaryStandards(salaryPlan, grade, period);
            foreach (RankSalaryStandard rss in rss_list)
            {
                开始执行日期 = rss.开始执行日期;
                //赋值
                string propertyName = "R" + rss.序号;
                string monthlySalary = rss != null ? rss.月薪.ToString() : "";
                PropertyInfo property = this.GetType().GetProperty(propertyName);
                if (property != null) property.SetValue(this, monthlySalary, null);

                if (RankNames != "") RankNames += ":";
                RankNames += rss.职级;
            }
            GradeSalaryAdjust gsa = GradeSalaryAdjust.GetGradeSalaryAdjust(salaryPlan, grade, period, 0);
            if (gsa == null)
            {
                gsa = GradeSalaryAdjust.AddGradeSalaryAdjust(salaryPlan, grade, period, 0);
                gsa.Calculate();
            }

            序号 = gsa.职等数;
            职等数 = gsa.职等数.ToString();
            级差 = gsa.级差.ToString();
            平均工资 = gsa.平均工资.ToString();
            最低工资 = gsa.最低工资;
            最高工资 = gsa.最高工资;
            对比的职等 = gsa.对比的职等;

            if (gsa.年调率 > 0)
            {
                半年调资额 = gsa.半年调资额.ToString();
                年调 = gsa.每年调资额.ToString();

                半年调率 = (gsa.年调率 * 100 / 1.5).ToString("#0.#") + "%";
                年调率 = (gsa.年调率 * 100).ToString("#0.#") + "%";
            }

            if (gsa.年调率 == 1) 年调率 = "";
            if (!string.IsNullOrEmpty(对比的职等)) 职等差 = gsa.职等差.ToString();
            if (gsa.上期调整 != null) 上期级别平均 = gsa.上期调整.平均工资.ToString();
        }

        public static List<ImplementJobGrade> GetImplementJobGradeList(string salary_plan, int year, SemiannualType semiannual, bool insert_separator)
        {
            List<ImplementJobGrade> gradeList = new List<ImplementJobGrade>();

            int period = year * 10 + (byte)semiannual;
            List<RankSalaryStandard> rss_list = RankSalaryStandard.GetRankSalaryStandards(salary_plan, null, period);
            List<string> jobGrades = RankSalaryStandard.GetGrades(rss_list);
            foreach (string grade in jobGrades)
            {
                ImplementJobGrade snGrade = new ImplementJobGrade(salary_plan, grade, year, semiannual);
                gradeList.Add(snGrade);
            }
            gradeList = gradeList.OrderBy(a => a.序号).ToList();
            string ranknames = "";
            List<ImplementJobGrade> grades_result = new List<ImplementJobGrade>();
            //遍历
            foreach (ImplementJobGrade grade in gradeList)
            {
                //如果职级划分不同，插入一行分割数据
                if (ranknames != grade.RankNames)
                {
                    if (ranknames != "")
                        grades_result.Add(new ImplementJobGrade(grade.RankNames));

                    ranknames = grade.RankNames;
                }
                grades_result.Add(grade);                
            }
            return grades_result;
        }

        //获取属性值
        public object GetPropertyValue(string propertyName)
        {
            PropertyInfo property = this.GetType().GetProperty(propertyName);
            if (property == null) return null;
            return property.GetValue(this, null);
        }

        public List<RankSalaryStandard> 职级工资表
        {
            get { return rss_list; }
        }

        public DateTime 开始执行日期 { get; set; }
        public string 薪酬体系 { get; set; }
        public string 职等 { get; set; }
        public int 期号 { get; set; }
        public int 序号 { get; set; }

        public string 职等数 { get; set; }
        public string 级差 { get; set; }
        public string 半年调资额 { get; set; }
        public string 半年调率 { get; set; }
        public string 年调 { get; set; }
        public string 年调率 { get; set; }
        public string 平均工资 { get; set; }
        public string 职等差 { get; set; }
        public string 对比的职等 { get; set; }

        public string 上期级别平均 { get; set; }        

        public string R1 { get; set; }
        public string R2 { get; set; }
        public string R3 { get; set; }
        public string R4 { get; set; }
        public string R5 { get; set; }
        public string R6 { get; set; }
        public string R7 { get; set; }
        public string R8 { get; set; }
        public string R9 { get; set; }
        public string R10 { get; set; }
        public string R11 { get; set; }
        public string R12 { get; set; }
        public string R13 { get; set; }
        public string R14 { get; set; }
        public string R15 { get; set; }
        public string R16 { get; set; }
        public string R17 { get; set; }
        public string R18 { get; set; }
        public string R19 { get; set; }
        public string R20 { get; set; }

        public string RankNames { get; set; }
        public int 最低工资 { get; set; }
        public int 最高工资 { get; set; }
        public string ID { get; set; }
        public bool is_separator { get; set; } //分隔器，非数据容器，用于分割不同职级方案，只显示职级名称
    }
}