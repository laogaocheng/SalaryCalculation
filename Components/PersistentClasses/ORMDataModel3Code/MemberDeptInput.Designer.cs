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

    [Persistent(@"会员_部门_录入")]
    public partial class MemberDeptInput : XPLiteObject
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
        [WatchMember]
        public string 员工编号
        {
            get { return f员工编号; }
            set { SetPropertyValue<string>("员工编号", ref f员工编号, value); }
        }        
        string f可查公司名称;
        [Size(50)]
        [WatchMember]
        public string 可查公司名称
        {
            get { return f可查公司名称; }
            set { SetPropertyValue<string>("可查公司名称", ref f可查公司名称, value); }
        }
        string f可查部门编号;
        [Size(50)]
        [WatchMember]
        public string 可查部门编号
        {
            get { return f可查部门编号; }
            set { SetPropertyValue<string>("可查部门编号", ref f可查部门编号, value); }
        }
        string f创建人;
        [Size(20)]
        public string 创建人
        {
            get { return f创建人; }
            set { SetPropertyValue<string>("创建人", ref f创建人, value); }
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
    }

}