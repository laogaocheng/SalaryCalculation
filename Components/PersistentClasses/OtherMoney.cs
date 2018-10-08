using System;
using DevExpress.Xpo;
namespace Hwagain.SalaryCalculation.Components
{
    [Persistent("其他奖扣")]
    public partial class OtherMoney : XPLiteObject
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
        string f类型;
        [Size(50)]
        public string 类型
        {
            get { return f类型; }
            set { SetPropertyValue<string>("类型", ref f类型, value); }
        }
        string f项目名称;
        [Size(50)]
        public string 项目名称
        {
            get { return f项目名称; }
            set { SetPropertyValue<string>("项目名称", ref f项目名称, value); }
        }
        decimal f金额;
        public decimal 金额
        {
            get { return f金额; }
            set { SetPropertyValue<decimal>("金额", ref f金额, value); }
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
        public OtherMoney(Session session) : base(session) { }
        public OtherMoney() : base(MyHelper.XpoSession) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

}
