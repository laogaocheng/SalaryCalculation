using System;
using DevExpress.Xpo;

namespace Hwagain.SalaryCalculation.Components
{
    [Persistent("职等配置")]
    public partial class LevelInfo : XPLiteObject
    {
        Guid f标识;
        [Key(true)]
        public Guid 标识
        {
            get { return f标识; }
            set { SetPropertyValue<Guid>("标识", ref f标识, value); }
        }
        string f编码;
        [Size(10)]
        public string 编码
        {
            get { return f编码; }
            set { SetPropertyValue<string>("编码", ref f编码, value); }
        }
        string f名称;
        public string 名称
        {
            get { return f名称; }
            set { SetPropertyValue<string>("名称", ref f名称, value); }
        }
        decimal f级别;
        public decimal 级别
        {
            get { return f级别; }
            set { SetPropertyValue<decimal>("级别", ref f级别, value); }
        }
        decimal f最低工资额;
        public decimal 最低工资额
        {
            get { return f最低工资额; }
            set { SetPropertyValue<decimal>("最低工资额", ref f最低工资额, value); }
        }
        public LevelInfo(Session session) : base(session) { }
        public LevelInfo() : base(MyHelper.XpoSession) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }
}
