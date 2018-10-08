using System;
using DevExpress.Xpo;
namespace Hwagain.SalaryCalculation.Components
{
    [Persistent("员工职级")]
    public partial class EmpSalaryStep : XPLiteObject
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
        string f姓名;
        [Size(20)]
        public string 姓名
        {
            get { return f姓名; }
            set { SetPropertyValue<string>("姓名", ref f姓名, value); }
        }
        string f薪资组;
        [Size(20)]
        public string 薪资组
        {
            get { return f薪资组; }
            set { SetPropertyValue<string>("薪资组", ref f薪资组, value); }
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
        DateTime f执行日期;
        public DateTime 执行日期
        {
            get { return f执行日期; }
            set { SetPropertyValue<DateTime>("执行日期", ref f执行日期, value); }
        }
        DateTime f截止日期;
        public DateTime 截止日期
        {
            get { return f截止日期; }
            set { SetPropertyValue<DateTime>("截止日期", ref f截止日期, value); }
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
        public EmpSalaryStep(Session session) : base(session) { }
        public EmpSalaryStep() : base(MyHelper.XpoSession) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

}
