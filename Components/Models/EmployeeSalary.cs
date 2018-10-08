using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Hwagain.SalaryCalculation.Components
{
    //员工薪酬
    public class EmployeeSalary
    {
        public string 员工编号 { get; set; }
        public string 姓名 { get; set; }

        public string 本部 { get; set; }
        public string 体系 { get; set; }
        public string 公司 { get; set; }
        public string 部门 { get; set; }
        public string 区域 { get; set; }
        public string 城市 { get; set; }
        public string 省办 { get; set; }

        public string 发放单位 { get; set; }

        public string 职务 { get; set; }

        public 职等 职等 { get; set; }
        public int 人数 { get; set; }
        public decimal 金额 { get; set; }

        public string 年度 { get; set; }
        public string 月份 { get; set; }
        public string 季度 { get; set; }

        SalaryResult 上表工资 { get; set; }
        PrivateSalary 封闭工资 { get; set; }

        #region 构造函数

        public EmployeeSalary(SalaryResult sr, PrivateSalary ps)
        {
            上表工资 = sr;
            封闭工资 = ps;

            //处理，获取相关数据
            this.员工编号 = sr.员工编号;
            this.姓名 = sr.姓名;
            this.职务 = PsHelper.GetValue(PsHelper.职务代码, 上表工资.职务代码);
            this.年度 = sr.年度.ToString() + " 年";
            this.月份 = sr.月份.ToString() + " 月";
            this.季度 = (Convert.ToInt32(sr.月份 / 3) + 1).ToString() + " 季度";
            //this.金额 = 封闭工资 == null ? 上表工资.上表工资 : 封闭工资.职级工资;
            this.金额 = 封闭工资 == null ? 上表工资.上表工资总额 : 封闭工资.工资发放总额;
            this.职等 = sr.职等;

            this.发放单位 = sr.财务公司;
            DeptInfo dept = DeptInfo.Get(sr.机构编号);
            if (dept != null)
            {
                this.本部 = dept.本部;
                this.体系 = dept.体系;

                this.公司 = dept.公司.部门名称;
                if (dept.部门 != null) this.部门 = dept.部门.部门名称;
                if (dept.区域 != null) this.区域 = dept.区域.部门名称;
                if (dept.省办 != null) this.省办 = dept.省办.部门名称.Replace("省办", "");
                if (dept.城市 != null) this.城市 = dept.城市.部门名称.Replace("市办", "");
            }
            else
            {
                CompanyInfo company = CompanyInfo.Get(sr.公司编号);
                if (company != null) this.公司 = company.公司简称;
            }
        }

        #endregion

        #region GetEmployeeSalarys

        public static List<EmployeeSalary> GetEmployeeSalarys(DateTime start, DateTime end, string companyCode)
        {
            List<EmployeeSalary> list = new List<EmployeeSalary>();

            DateTime currMonth = start;
            while (currMonth <= end)
            {
                //取出当前月份的工资明细
                List<SalaryResult> srList = SalaryResult.GetSalaryResults(currMonth.Year, currMonth.Month, companyCode);
                //遍历
                foreach (SalaryResult sr in srList)
                {
                    PrivateSalary ps = PrivateSalary.GetPrivateSalary(sr.员工编号, sr.年度, sr.月份);
                    EmployeeSalary es = new EmployeeSalary(sr, ps);
                    list.Add(es);
                }

                currMonth = currMonth.AddMonths(1);
            }
            return list;
        }
        #endregion

        public string 工资
        {
            get
            {
                return this.金额.ToString("0.00");
            }
        }
    }
}
