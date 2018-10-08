using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hwagain.Components
{
    /// <summary>
    /// 加班信息
    /// </summary>
    public partial class SalaryBaseInfo
    {
        public string 员工编号 { get; set; }
        public decimal 上表工资标准 { get; set; }
        public decimal 设定工资 { get; set; }
        public decimal 基准工资 { get; set; }
        public decimal 年休假工资 { get; set; }
        public decimal 满勤奖金额 { get; set; }
    }
}
