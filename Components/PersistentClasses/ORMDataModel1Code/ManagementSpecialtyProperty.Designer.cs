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

    [Persistent(@"管培生_专业属性")]
    public partial class ManagementSpecialtyProperty : XPLiteObject
    {
        Guid f标识;
        [Key(true)]
        public Guid 标识
        {
            get { return f标识; }
            set { SetPropertyValue<Guid>("标识", ref f标识, value); }
        }
        string f岗位级别;
        [Size(20)]
        public string 岗位级别
        {
            get { return f岗位级别; }
            set { SetPropertyValue<string>("岗位级别", ref f岗位级别, value); }
        }
        string f学历;
        [Size(20)]
        public string 学历
        {
            get { return f学历; }
            set { SetPropertyValue<string>("学历", ref f学历, value); }
        }
        string f专业名称;
        [Size(50)]
        public string 专业名称
        {
            get { return f专业名称; }
            set { SetPropertyValue<string>("专业名称", ref f专业名称, value); }
        }
        string f属性;
        [Size(20)]
        public string 属性
        {
            get { return f属性; }
            set { SetPropertyValue<string>("属性", ref f属性, value); }
        }
        string f届别;
        [Size(10)]
        public string 届别
        {
            get { return f届别; }
            set { SetPropertyValue<string>("届别", ref f届别, value); }
        }
        int f序号;
        public int 序号
        {
            get { return f序号; }
            set { SetPropertyValue<int>("序号", ref f序号, value); }
        }
        DateTime f更新时间;
        public DateTime 更新时间
        {
            get { return f更新时间; }
            set { SetPropertyValue<DateTime>("更新时间", ref f更新时间, value); }
        }
    }

}