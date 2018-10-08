using System;
using DevExpress.Xpo;

namespace Hwagain.SalaryCalculation.Components
{
    [Persistent("个人职级工资")]
    public partial class PersonPayRate : XPLiteObject
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
        decimal f月薪;
        public decimal 月薪
        {
            get { return f月薪; }
            set { SetPropertyValue<decimal>("年薪", ref f月薪, value); }
        }
        decimal f年终奖;
        public decimal 年终奖
        {
            get { return f年终奖; }
            set { SetPropertyValue<decimal>("年终奖", ref f年终奖, value); }
        }
        decimal f月报销额度;
        public decimal 月报销额度
        {
            get { return f月报销额度; }
            set { SetPropertyValue<decimal>("月报销额度", ref f月报销额度, value); }
        }
        string f津贴1名称;
        public string 津贴1名称
        {
            get { return f津贴1名称; }
            set { SetPropertyValue<string>("津贴1名称", ref f津贴1名称, value); }
        }
        decimal f津贴1金额;
        public decimal 津贴1金额
        {
            get { return f津贴1金额; }
            set { SetPropertyValue<decimal>("津贴1金额", ref f津贴1金额, value); }
        }
        string f津贴2名称;
        public string 津贴2名称
        {
            get { return f津贴2名称; }
            set { SetPropertyValue<string>("津贴2名称", ref f津贴2名称, value); }
        }
        decimal f津贴2金额;
        public decimal 津贴2金额
        {
            get { return f津贴2金额; }
            set { SetPropertyValue<decimal>("津贴2金额", ref f津贴2金额, value); }
        }
        DateTime f生效日期;
        public DateTime 生效日期
        {
            get { return f生效日期; }
            set { SetPropertyValue<DateTime>("生效日期", ref f生效日期, value); }
        }
        DateTime f失效日期;
        public DateTime 失效日期
        {
            get { return f失效日期; }
            set { SetPropertyValue<DateTime>("失效日期", ref f失效日期, value); }
        }
        bool f有效;
        public bool 有效
        {
            get { return f有效; }
            set { SetPropertyValue<bool>("有效", ref f有效, value); }
        }
        double f序号;
        public double 序号
        {
            get { return f序号; }
            set { SetPropertyValue<double>("序号", ref f序号, value); }
        }
        DateTime f录入时间;
        public DateTime 录入时间
        {
            get { return f录入时间; }
            set { SetPropertyValue<DateTime>("录入时间", ref f录入时间, value); }
        }
        string f录入人;
        [Size(20)]
        public string 录入人
        {
            get { return f录入人; }
            set { SetPropertyValue<string>("录入人", ref f录入人, value); }
        }
        DateTime f验证时间;
        public DateTime 验证时间
        {
            get { return f验证时间; }
            set { SetPropertyValue<DateTime>("验证时间", ref f验证时间, value); }
        }
        string f验证人;
        [Size(20)]
        public string 验证人
        {
            get { return f验证人; }
            set { SetPropertyValue<string>("验证人", ref f验证人, value); }
        }
        public PersonPayRate(Session session) : base(session) { }
        public PersonPayRate() : base(MyHelper.XpoSession) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }
}
