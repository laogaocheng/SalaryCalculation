using System;
using DevExpress.Xpo;
namespace Hwagain.SalaryCalculation.Components
{
    [Persistent("薪等")]
    public partial class SalaryGrade : XPLiteObject
    {
        Guid f标识;
        [Key(true)]
        public Guid 标识
        {
            get { return f标识; }
            set { SetPropertyValue<Guid>("标识", ref f标识, value); }
        }
        string f集合;
        [Size(10)]
        public string 集合
        {
            get { return f集合; }
            set { SetPropertyValue<string>("集合", ref f集合, value); }
        }
        string f薪酬体系;
        [Size(20)]
        public string 薪酬体系
        {
            get { return f薪酬体系; }
            set { SetPropertyValue<string>("薪酬体系", ref f薪酬体系, value); }
        }
        string f薪等编号;
        [Size(20)]
        public string 薪等编号
        {
            get { return f薪等编号; }
            set { SetPropertyValue<string>("薪等编号", ref f薪等编号, value); }
        }
        string f薪等名称;
        [Size(100)]
        public string 薪等名称
        {
            get { return f薪等名称; }
            set { SetPropertyValue<string>("薪等名称", ref f薪等名称, value); }
        }
        DateTime f生效日期;
        public DateTime 生效日期
        {
            get { return f生效日期; }
            set { SetPropertyValue<DateTime>("生效日期", ref f生效日期, value); }
        }
        decimal f基准工资标准;
        public decimal 基准工资标准
        {
            get { return f基准工资标准; }
            set { SetPropertyValue<decimal>("基准工资标准", ref f基准工资标准, value); }
        }
        decimal f上表工资标准;
        public decimal 上表工资标准
        {
            get { return f上表工资标准; }
            set { SetPropertyValue<decimal>("上表工资标准", ref f上表工资标准, value); }
        }
        decimal f设定工资标准;
        public decimal 设定工资标准
        {
            get { return f设定工资标准; }
            set { SetPropertyValue<decimal>("设定工资标准", ref f设定工资标准, value); }
        }
        decimal f年休假工资;
        public decimal 年休假工资
        {
            get { return f年休假工资; }
            set { SetPropertyValue<decimal>("年休假工资", ref f年休假工资, value); }
        }
        decimal f养老保险缴纳基数;
        public decimal 养老保险缴纳基数
        {
            get { return f养老保险缴纳基数; }
            set { SetPropertyValue<decimal>("养老保险缴纳基数", ref f养老保险缴纳基数, value); }
        }
        decimal f医疗保险缴纳基数;
        public decimal 医疗保险缴纳基数
        {
            get { return f医疗保险缴纳基数; }
            set { SetPropertyValue<decimal>("医疗保险缴纳基数", ref f医疗保险缴纳基数, value); }
        }
        decimal f生育保险缴纳基数;
        public decimal 生育保险缴纳基数
        {
            get { return f生育保险缴纳基数; }
            set { SetPropertyValue<decimal>("生育保险缴纳基数", ref f生育保险缴纳基数, value); }
        }
        decimal f失业保险缴纳基数;
        public decimal 失业保险缴纳基数
        {
            get { return f失业保险缴纳基数; }
            set { SetPropertyValue<decimal>("失业保险缴纳基数", ref f失业保险缴纳基数, value); }
        }
        decimal f工伤保险缴纳基数;
        public decimal 工伤保险缴纳基数
        {
            get { return f工伤保险缴纳基数; }
            set { SetPropertyValue<decimal>("工伤保险缴纳基数", ref f工伤保险缴纳基数, value); }
        }
        decimal f公积金基数;
        public decimal 公积金基数
        {
            get { return f公积金基数; }
            set { SetPropertyValue<decimal>("公积金基数", ref f公积金基数, value); }
        }
        DateTime f上次同步时间;
        public DateTime 上次同步时间
        {
            get { return f上次同步时间; }
            set { SetPropertyValue<DateTime>("上次同步时间", ref f上次同步时间, value); }
        }
        DateTime f创建时间;
        public DateTime 创建时间
        {
            get { return f创建时间; }
            set { SetPropertyValue<DateTime>("创建时间", ref f创建时间, value); }
        }
        string f状态;
        [Size(10)]
        public string 状态
        {
            get { return f状态; }
            set { SetPropertyValue<string>("状态", ref f状态, value); }
        }
        public SalaryGrade(Session session) : base(session) { }
        public SalaryGrade() : base(MyHelper.XpoSession) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

}
