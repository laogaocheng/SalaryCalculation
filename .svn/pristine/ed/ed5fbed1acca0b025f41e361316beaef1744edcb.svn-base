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

namespace Hwagain.SalaryCalculation.Components
{
    //半年度职级
    public partial class SemiannualJobRank
    {
        static readonly ILog log = LogManager.GetLogger(typeof(SemiannualJobRank));

        JobRank jobRank = null;
        int year = 0;
        int period = 0;
        int monthlySalary = 0;
        SemiannualType semiannual;

        public SemiannualJobRank(JobRank rank, int year, SemiannualType semiannual, int monthly_salary)
        {
            this.jobRank = rank;
            this.year = year;
            this.semiannual = semiannual;
            this.period = year * 10 + (byte)semiannual;
            this.monthlySalary = monthly_salary;
        }

        public string 名称
        {
            get { return year + semiannual.ToString(); }
        }

        public int 月薪
        {
            get { return monthlySalary; }
        }


    }
}