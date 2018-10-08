using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;

namespace Hwagain.SalaryCalculation.Components
{
    public class OtherMoneyData
    {
        public string 员工编号 { get; set; }
        public string 姓名 { get; set; }
        public int 年 { get; set; }
        public int 月 { get; set; }
        public string 类型 { get; set; }
        public string 项目名称 { get; set; }
        public decimal 金额 { get; set; }
    }
}
