//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
namespace Hwagain.SalaryCalculation.Components
{

    [Persistent(@"执行绩效工资")]
    public partial class EffectivePerformanceSalary : XPLiteObject
    {
        Guid f标识;
        [Key(true)]
        public Guid 标识
        {
            get { return f标识; }
            set { SetPropertyValue<Guid>("标识", ref f标识, value); }
        }
        string f员工编号;
        [Size(20)]
        public string 员工编号
        {
            get { return f员工编号; }
            set { SetPropertyValue<string>("员工编号", ref f员工编号, value); }
        }
        string f姓名;
        [Size(10)]
        public string 姓名
        {
            get { return f姓名; }
            set { SetPropertyValue<string>("姓名", ref f姓名, value); }
        }
        decimal f绩效工资;
        public decimal 绩效工资
        {
            get { return f绩效工资; }
            set { SetPropertyValue<decimal>("绩效工资", ref f绩效工资, value); }
        }
        decimal f实得工资;
        public decimal 实得工资
        {
            get { return f实得工资; }
            set { SetPropertyValue<decimal>("实得工资", ref f实得工资, value); }
        }
        string f录入人;
        [Size(20)]
        public string 录入人
        {
            get { return f录入人; }
            set { SetPropertyValue<string>("录入人", ref f录入人, value); }
        }
        DateTime f录入时间;
        public DateTime 录入时间
        {
            get { return f录入时间; }
            set { SetPropertyValue<DateTime>("录入时间", ref f录入时间, value); }
        }
        int f年;
        public int 年
        {
            get { return f年; }
            set { SetPropertyValue<int>("年", ref f年, value); }
        }
        int f月;
        public int 月
        {
            get { return f月; }
            set { SetPropertyValue<int>("月", ref f月, value); }
        }
    }

}
