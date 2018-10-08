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

    [Persistent(@"个人借款_录入")]
    public partial class PersonBorrowInput : XPLiteObject
    {
        Guid f标识;
        [Key(true)]
        public Guid 标识
        {
            get { return f标识; }
            set { SetPropertyValue<Guid>("标识", ref f标识, value); }
        }
        string f项目;
        [Size(50)]
        [WatchMember]
        public string 项目
        {
            get { return f项目; }
            set { SetPropertyValue<string>("项目", ref f项目, value); }
        }
        decimal f金额;
        [WatchMember]
        public decimal 金额
        {
            get { return f金额; }
            set { SetPropertyValue<decimal>("金额", ref f金额, value); }
        }
        double f返还年限;
        [WatchMember]
        public double 返还年限
        {
            get { return f返还年限; }
            set { SetPropertyValue<double>("返还年限", ref f返还年限, value); }
        }
        decimal f每月扣还;
        [WatchMember]
        public decimal 每月扣还
        {
            get { return f每月扣还; }
            set { SetPropertyValue<decimal>("每月扣还", ref f每月扣还, value); }
        }
        string f备注;
        [Size(500)]
        [WatchMember]
        public string 备注
        {
            get { return f备注; }
            set { SetPropertyValue<string>("备注", ref f备注, value); }
        }
        bool f已还清;
        public bool 已还清
        {
            get { return f已还清; }
            set { SetPropertyValue<bool>("已还清", ref f已还清, value); }
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
        bool f是验证录入;
        public bool 是验证录入
        {
            get { return f是验证录入; }
            set { SetPropertyValue<bool>("是验证录入", ref f是验证录入, value); }
        }
        DateTime f生效时间;
        public DateTime 生效时间
        {
            get { return f生效时间; }
            set { SetPropertyValue<DateTime>("生效时间", ref f生效时间, value); }
        }
        string f双人录入结果;
        [Size(20)]
        public string 双人录入结果
        {
            get { return f双人录入结果; }
            set { SetPropertyValue<string>("双人录入结果", ref f双人录入结果, value); }
        }
        string f员工编号;
        [Size(20)]
        [WatchMember]
        public string 员工编号
        {
            get { return f员工编号; }
            set { SetPropertyValue<string>("员工编号", ref f员工编号, value); }
        }
        string f姓名;
        [Size(10)]
        [WatchMember]
        public string 姓名
        {
            get { return f姓名; }
            set { SetPropertyValue<string>("姓名", ref f姓名, value); }
        }        
        string f编号;
        [Size(20)]
        [WatchMember]
        public string 编号
        {
            get { return f编号; }
            set { SetPropertyValue<string>("编号", ref f编号, value); }
        }
        DateTime f生效日期;
        [WatchMember]
        public DateTime 生效日期
        {
            get { return f生效日期; }
            set { SetPropertyValue<DateTime>("生效日期", ref f生效日期, value); }
        }
    }

}
