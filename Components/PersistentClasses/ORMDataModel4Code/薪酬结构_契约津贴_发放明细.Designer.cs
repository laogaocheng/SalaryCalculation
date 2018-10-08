﻿//------------------------------------------------------------------------------
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

    [Persistent(@"薪酬结构_契约津贴_发放明细")]
    public partial class MonthlyContractAllowanceItem : XPLiteObject
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
        string f期间;
        [Size(10)]
        public string 期间
        {
            get { return f期间; }
            set { SetPropertyValue<string>("期间", ref f期间, value); }
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
        decimal f约定税率;
        public decimal 约定税率
        {
            get { return f约定税率; }
            set { SetPropertyValue<decimal>("约定税率", ref f约定税率, value); }
        }
        decimal f月津贴标准;
        public decimal 月津贴标准
        {
            get { return f月津贴标准; }
            set { SetPropertyValue<decimal>("月津贴标准", ref f月津贴标准, value); }
        }
        decimal f应出勤天数;
        public decimal 应出勤天数
        {
            get { return f应出勤天数; }
            set { SetPropertyValue<decimal>("应出勤天数", ref f应出勤天数, value); }
        }
        decimal f实际出勤天数;
        public decimal 实际出勤天数
        {
            get { return f实际出勤天数; }
            set { SetPropertyValue<decimal>("实际出勤天数", ref f实际出勤天数, value); }
        }
        decimal f实际发放金额;
        public decimal 实际发放金额
        {
            get { return f实际发放金额; }
            set { SetPropertyValue<decimal>("实际发放金额", ref f实际发放金额, value); }
        }        
        string f创建人;
        [Size(20)]
        public string 创建人
        {
            get { return f创建人; }
            set { SetPropertyValue<string>("创建人", ref f创建人, value); }
        }
        DateTime f创建时间;
        public DateTime 创建时间
        {
            get { return f创建时间; }
            set { SetPropertyValue<DateTime>("创建时间", ref f创建时间, value); }
        }
    }

}
