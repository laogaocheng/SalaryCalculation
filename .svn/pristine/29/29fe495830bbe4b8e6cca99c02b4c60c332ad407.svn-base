using System;
using DevExpress.Xpo;
namespace Hwagain.SalaryCalculation.Components
{
    [Persistent("个人职级工资_录入")]
    public partial class PersonPayRateInput : XPLiteObject
    {
        Guid f标识;
        [Key(true)]
        public Guid 标识
        {
            get { return f标识; }
            set { SetPropertyValue<Guid>("标识", ref f标识, value); }
        }
        string f编号;
        [Size(20)]
        [WatchMember]
        public string 编号
        {
            get { return f编号; }
            set { SetPropertyValue<string>("编号", ref f编号, value); }
        }
        string f员工编号;
        [Size(20)]
        [WatchMember]
        public string 员工编号
        {
            get { return f员工编号; }
            set { SetPropertyValue<string>("员工编号", ref f员工编号, value); }
        }
        decimal f月薪;
        [WatchMember]
        public decimal 月薪
        {
            get { return f月薪; }
            set { SetPropertyValue<decimal>("年薪", ref f月薪, value); }
        }
        decimal f年终奖;
        [WatchMember]
        public decimal 年终奖
        {
            get { return f年终奖; }
            set { SetPropertyValue<decimal>("年终奖", ref f年终奖, value); }
        }
        decimal f月报销额度;
        [WatchMember]
        public decimal 月报销额度
        {
            get { return f月报销额度; }
            set { SetPropertyValue<decimal>("月报销额度", ref f月报销额度, value); }
        }
        string f津贴1名称;
        [WatchMember]
        public string 津贴1名称
        {
            get { return f津贴1名称; }
            set { SetPropertyValue<string>("津贴1名称", ref f津贴1名称, value); }
        }
        decimal f津贴1金额;
        [WatchMember]
        public decimal 津贴1金额
        {
            get { return f津贴1金额; }
            set { SetPropertyValue<decimal>("津贴1金额", ref f津贴1金额, value); }
        }
        string f津贴2名称;
        [WatchMember]
        public string 津贴2名称
        {
            get { return f津贴2名称; }
            set { SetPropertyValue<string>("津贴2名称", ref f津贴2名称, value); }
        }
        decimal f津贴2金额;
        [WatchMember]
        public decimal 津贴2金额
        {
            get { return f津贴2金额; }
            set { SetPropertyValue<decimal>("津贴2金额", ref f津贴2金额, value); }
        }
        string f姓名;
        [WatchMember]
        public string 姓名
        {
            get { return f姓名; }
            set { SetPropertyValue<string>("姓名", ref f姓名, value); }
        }
        string f职务;
        [WatchMember]
        public string 职务
        {
            get { return f职务; }
            set { SetPropertyValue<string>("职务", ref f职务, value); }
        }
        DateTime f生效日期;
        [WatchMember]
        public DateTime 生效日期
        {
            get { return f生效日期; }
            set { SetPropertyValue<DateTime>("生效日期", ref f生效日期, value); }
        }
        double f序号;
        public double 序号
        {
            get { return f序号; }
            set { SetPropertyValue<double>("序号", ref f序号, value); }
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
        public PersonPayRateInput(Session session) : base(session) { }
        public PersonPayRateInput() : base(MyHelper.XpoSession) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

}
