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

    [Persistent(@"职级工资调整_录入")]
    public partial class GradeSalaryAdjustInput : XPLiteObject
    {
        Guid f标识;
        [Key(true)]
        public Guid 标识
        {
            get { return f标识; }
            set { SetPropertyValue<Guid>("标识", ref f标识, value); }
        }
        string f薪酬体系;
        [Size(50)]
        public string 薪酬体系
        {
            get { return f薪酬体系; }
            set { SetPropertyValue<string>("薪酬体系", ref f薪酬体系, value); }
        }
        string f职等;
        [Size(20)]
        public string 职等
        {
            get { return f职等; }
            set { SetPropertyValue<string>("职等", ref f职等, value); }
        }
        int f期号;
        public int 期号
        {
            get { return f期号; }
            set { SetPropertyValue<int>("期号", ref f期号, value); }
        }
        int f级差;
        public int 级差
        {
            get { return f级差; }
            set { SetPropertyValue<int>("级差", ref f级差, value); }
        }
        int f半年调资额;
        [WatchMember]        
        public int 半年调资额
        {
            get { return f半年调资额; }
            set { SetPropertyValue<int>("半年调资额", ref f半年调资额, value); }
        }
        int f每年调资额;
        public int 每年调资额
        {
            get { return f每年调资额; }
            set { SetPropertyValue<int>("每年调资额", ref f每年调资额, value); }
        }
        double f年调率;
        public double 年调率
        {
            get { return f年调率; }
            set { SetPropertyValue<double>("年调率", ref f年调率, value); }
        }
        int f平均工资;
        public int 平均工资
        {
            get { return f平均工资; }
            set { SetPropertyValue<int>("平均工资", ref f平均工资, value); }
        }
        int f最低工资;
        public int 最低工资
        {
            get { return f最低工资; }
            set { SetPropertyValue<int>("最低工资", ref f最低工资, value); }
        }
        int f最高工资;
        public int 最高工资
        {
            get { return f最高工资; }
            set { SetPropertyValue<int>("最高工资", ref f最高工资, value); }
        }
        int f职等差;
        public int 职等差
        {
            get { return f职等差; }
            set { SetPropertyValue<int>("职等差", ref f职等差, value); }
        }
        int f职等数;
        public int 职等数
        {
            get { return f职等数; }
            set { SetPropertyValue<int>("职等数", ref f职等数, value); }
        }
        int f序号;
        public int 序号
        {
            get { return f序号; }
            set { SetPropertyValue<int>("序号", ref f序号, value); }
        }
        string f对比的职等;
        public string 对比的职等
        {
            get { return f对比的职等; }
            set { SetPropertyValue<string>("对比的职等", ref f对比的职等, value); }
        }
        DateTime f开始执行日期;
        [WatchMember]
        public DateTime 开始执行日期
        {
            get { return f开始执行日期; }
            set { SetPropertyValue<DateTime>("开始执行日期", ref f开始执行日期, value); }
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
