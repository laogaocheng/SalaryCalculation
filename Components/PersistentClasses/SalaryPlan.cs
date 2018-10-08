using System;
using DevExpress.Xpo;

namespace Hwagain.SalaryCalculation.Components
{
    [Persistent("薪酬体系")]
    public partial class SalaryPlan : XPLiteObject
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
        string f英文名;
        [Size(50)]
        public string 英文名
        {
            get { return f英文名; }
            set { SetPropertyValue<string>("英文名", ref f英文名, value); }
        }
        string f中文名;
        [Size(50)]
        public string 中文名
        {
            get { return f中文名; }
            set { SetPropertyValue<string>("中文名", ref f中文名, value); }
        }
        string f状态;
        [Size(10)]
        public string 状态
        {
            get { return f状态; }
            set { SetPropertyValue<string>("状态", ref f状态, value); }
        }
        public SalaryPlan(Session session) : base(session) { }
        public SalaryPlan() : base(MyHelper.XpoSession) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }
}
