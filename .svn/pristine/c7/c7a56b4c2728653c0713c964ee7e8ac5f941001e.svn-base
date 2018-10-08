using System;
using DevExpress.Xpo;
namespace Hwagain.SalaryCalculation.Components
{
    [Persistent("职级工资_录入")]
    public partial class PayRateInput : XPLiteObject
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
        int f薪等标识;
        [WatchMember]
        public int 薪等标识
        {
            get { return f薪等标识; }
            set { SetPropertyValue<int>("薪等标识", ref f薪等标识, value); }
        }
        int f薪级标识;
        [WatchMember]
        public int 薪级标识
        {
            get { return f薪级标识; }
            set { SetPropertyValue<int>("薪级标识", ref f薪级标识, value); }
        }
        DateTime f执行日期;
        [WatchMember]
        public DateTime 执行日期
        {
            get { return f执行日期; }
            set { SetPropertyValue<DateTime>("执行日期", ref f执行日期, value); }
        }
        decimal f工资额;
        [WatchMember]
        public decimal 工资额
        {
            get { return f工资额; }
            set { SetPropertyValue<decimal>("工资额", ref f工资额, value); }
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
        public PayRateInput(Session session) : base(session) { }
        public PayRateInput() : base(MyHelper.XpoSession) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

}
