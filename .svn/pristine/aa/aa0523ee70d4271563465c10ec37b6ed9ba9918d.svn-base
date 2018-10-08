using System;
using DevExpress.Xpo;
namespace Hwagain.SalaryCalculation.Components
{
    [Persistent("工资审核审批情况")]
    public partial class SalaryAuditingResult : XPLiteObject
    {
        Guid f标识;
        [Key(true)]
        public Guid 标识
        {
            get { return f标识; }
            set { SetPropertyValue<Guid>("标识", ref f标识, value); }
        }
        string f薪资组;
        [Size(20)]
        public string 薪资组
        {
            get { return f薪资组; }
            set { SetPropertyValue<string>("薪资组", ref f薪资组, value); }
        }
        string f日历组;
        [Size(20)]
        public string 日历组
        {
            get { return f日历组; }
            set { SetPropertyValue<string>("日历组", ref f日历组, value); }
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
        string f类别;
        [Size(20)]
        public string 类别
        {
            get { return f类别; }
            set { SetPropertyValue<string>("类别", ref f类别, value); }
        }
        string f上表审核人;
        [Size(20)]
        public string 上表审核人
        {
            get { return f上表审核人; }
            set { SetPropertyValue<string>("上表审核人", ref f上表审核人, value); }
        }
        DateTime f上表审核时间;
        public DateTime 上表审核时间
        {
            get { return f上表审核时间; }
            set { SetPropertyValue<DateTime>("上表审核时间", ref f上表审核时间, value); }
        }
        DateTime f工资计算时间;
        public DateTime 工资计算时间
        {
            get { return f工资计算时间; }
            set { SetPropertyValue<DateTime>("工资计算时间", ref f工资计算时间, value); }
        }
        string f审核人;
        [Size(20)]
        public string 审核人
        {
            get { return f审核人; }
            set { SetPropertyValue<string>("审核人", ref f审核人, value); }
        }
        DateTime f审核时间;
        public DateTime 审核时间
        {
            get { return f审核时间; }
            set { SetPropertyValue<DateTime>("审核时间", ref f审核时间, value); }
        }
        string f冻结人;
        [Size(20)]
        public string 冻结人
        {
            get { return f冻结人; }
            set { SetPropertyValue<string>("冻结人", ref f冻结人, value); }
        }
        DateTime f冻结时间;
        public DateTime 冻结时间
        {
            get { return f冻结时间; }
            set { SetPropertyValue<DateTime>("冻结时间", ref f冻结时间, value); }
        }
        string f审批人;
        [Size(20)]
        public string 审批人
        {
            get { return f审批人; }
            set { SetPropertyValue<string>("审批人", ref f审批人, value); }
        }
        DateTime f审批时间;
        public DateTime 审批时间
        {
            get { return f审批时间; }
            set { SetPropertyValue<DateTime>("审批时间", ref f审批时间, value); }
        }
        DateTime f创建时间;
        public DateTime 创建时间
        {
            get { return f创建时间; }
            set { SetPropertyValue<DateTime>("创建时间", ref f创建时间, value); }
        }
        string f制表人;
        [Size(20)]
        public string 制表人
        {
            get { return f制表人; }
            set { SetPropertyValue<string>("制表人", ref f制表人, value); }
        }
        DateTime f制表时间;
        public DateTime 制表时间
        {
            get { return f制表时间; }
            set { SetPropertyValue<DateTime>("制表人时间", ref f制表时间, value); }
        }
        public SalaryAuditingResult(Session session) : base(session) { }
        public SalaryAuditingResult() : base(MyHelper.XpoSession) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

}
