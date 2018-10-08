using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;

namespace Hwagain.SalaryCalculation.Components
{
    public class PersonalTax
    {

        public int 年 { get; set; }
        public int 月 { get; set; }
        public DateTime 期间_开始 { get; set; }
        public DateTime 期间_结束 { get; set; }

        public string 发放单位 { get; set; }
        public string 期间 { get; set; }
        public string 员工编号 { get; set; }
        public string 姓名 { get; set; }
        public string 身份证号 { get; set; }
        public decimal 养老保险个人缴纳金额 { get; set; }
        public decimal 医疗保险个人缴纳金额 { get; set; }
        public decimal 失业保险个人缴纳金额 { get; set; }
        public decimal 住房公积金个人缴纳金额 { get; set; }

        public decimal 应税工资额 { get; set; }
        public decimal 个税起征点 { get; set; }
        public decimal 税率 { get; set; }
        public decimal 速算扣除数 { get; set; }
        public decimal 工资发放总额 { get; set; }
        public decimal 个人所得税 { get; set; }

        public SalaryResult 上表工资 = null;
        public PrivateSalary 封闭工资 = null;

        public PersonalTax(SalaryResult salary)
        {
            上表工资 = salary;
            封闭工资 = PrivateSalary.GetPrivateSalary(salary.员工编号, salary.年度, salary.月份);

            CalRunInfo cal = CalRunInfo.Get(salary.日历组);

            年 = cal.年度;
            月 = cal.月份;
            期间_开始 = cal.开始日期;
            期间_结束 = cal.结束日期;
            期间 = String.Format("{0}年{1}", 年, 月) + "月";
            发放单位 = salary.财务公司;

            员工编号 = salary.员工编号;
            姓名 = salary.姓名;
            身份证号 = salary.身份证号;
            养老保险个人缴纳金额 = salary.养老保险个人缴纳;
            医疗保险个人缴纳金额 = salary.基本医疗个人缴纳 + salary.大病医疗个人缴纳金额;
            失业保险个人缴纳金额 = salary.失业保险个人缴纳;
            住房公积金个人缴纳金额 = salary.住房公积金个人缴纳;

            应税工资额 = 上表工资.应税工资额;
            个人所得税 = 封闭工资 == null ? 上表工资.个人所得税金额 : 封闭工资.个人所得税;
            工资发放总额 = 上表工资.上表工资总额 + 上表工资.未休年休假工资;
            //如果有封闭工资
            if (封闭工资 != null)
            {
                应税工资额 = 封闭工资.总应税工资;
                工资发放总额 = 封闭工资.工资发放总额;
            }
            个税起征点 = PsHelper.GetPersonTaxPoint(期间_开始);


            decimal taxIncome = 应税工资额 - 个税起征点;
            if (taxIncome > 0)
            {
                TaxInfo tax = TaxInfo.Get(taxIncome);
                税率 = tax.税率;
                速算扣除数 = tax.速算扣除数;
            }
        }
        
        #region GetPersonalTaxList

        //获取纳税清单
        public static List<PersonalTax> GetPersonalTaxList(int year, int month, string company)
        {
            List<PersonalTax> list = new List<PersonalTax>();
            List<SalaryResult> salaryList = SalaryResult.GetSalaryResults(year, month, company, null);
            foreach (SalaryResult item in salaryList)
            {
                list.Add(new PersonalTax(item));
            }
            return list;
        }
        #endregion

        #region 发放日期

        public DateTime 发放日期
        {
            get
            {
                return DateTime.Today;
            }
        }
        #endregion

        public string 证照类型
        {
            get { return "身份证"; }
        }

        public string 税款负担方式
        {
            get { return "自行负担"; }  //1、自行负担 2、雇主全额负担
        }
    }
}
