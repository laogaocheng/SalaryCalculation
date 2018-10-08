using System;
using DevExpress.Xpo;
namespace Hwagain.SalaryCalculation.Components
{
    [Persistent("职级工资")]
    public partial class StepPayRate : XPLiteObject
    {
        Guid f标识;
        [Key(true)]
        public Guid 标识
        {
            get { return f标识; }
            set { SetPropertyValue<Guid>("标识", ref f标识, value); }
        }
        int f薪等标识;
        public int 薪等标识
        {
            get { return f薪等标识; }
            set { SetPropertyValue<int>("薪等标识", ref f薪等标识, value); }
        }
        int f薪级标识;
        public int 薪级标识
        {
            get { return f薪级标识; }
            set { SetPropertyValue<int>("薪级标识", ref f薪级标识, value); }
        }        
        decimal f工资额;
        public decimal 工资额
        {
            get { return f工资额; }
            set { SetPropertyValue<decimal>("工资额", ref f工资额, value); }
        }
        DateTime f执行日期;
        public DateTime 执行日期
        {
            get { return f执行日期; }
            set { SetPropertyValue<DateTime>("执行日期", ref f执行日期, value); }
        }
        DateTime f设定时间;
        public DateTime 设定时间
        {
            get { return f设定时间; }
            set { SetPropertyValue<DateTime>("设定时间", ref f设定时间, value); }
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
        string f验证人;
        [Size(20)]
        public string 验证人
        {
            get { return f验证人; }
            set { SetPropertyValue<string>("验证人", ref f验证人, value); }
        }
        DateTime f验证时间;
        public DateTime 验证时间
        {
            get { return f验证时间; }
            set { SetPropertyValue<DateTime>("验证时间", ref f验证时间, value); }
        }
        public StepPayRate(Session session) : base(session) { }
        public StepPayRate() : base(MyHelper.XpoSession) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

}
