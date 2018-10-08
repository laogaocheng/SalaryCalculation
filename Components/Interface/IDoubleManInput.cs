using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hwagain.Components;

namespace Hwagain.Interface
{
    public interface IDoubleManInput
    {
        string 录入人 { get; set; }
        DateTime 录入时间 { get; set; }
        bool 是验证录入 { get; set; }
        List<ModifyField> 内容不同的字段 { get; }
        IDoubleManInput 另一人录入的记录 { get; }
        bool 另一人已录入 { get; }
        bool 已生效 { get; }
    }
}
