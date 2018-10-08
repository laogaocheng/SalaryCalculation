using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hwagain.SalaryCalculation.Components
{
    //调整方法
    public enum AdjustWay
    {
        正式数据 = 0,
        初次录入_逐个 = 1,
        验证录入_逐个 = 2,
        初次录入_批量 = 3,
        验证录入_批量 = 4
    }
}
