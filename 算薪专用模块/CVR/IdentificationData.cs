using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace Hwagain.SalaryCalculation.Components
{
    //身份证数据
    public class IdentificationData
    {
        public string 身份证号 { get; set; }
        public string 姓名 { get; set; }
        public string 性别 { get; set; }
        public string 民族 { get; set; }
        public string 地址 { get; set; }
        public string 签发机关 { get; set; }
        public string 有效期限 { get; set; }
        public DateTime 出生日期 { get; set; }
    }
}
