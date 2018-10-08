using System;
using DevExpress.Xpo;

namespace Hwagain.SalaryCalculation.Components
{
    [Persistent("角色_薪等")]
    public partial class RoleGrade : XPLiteObject
    {
        Guid f标识;
        [Key(true)]
        public Guid 标识
        {
            get { return f标识; }
            set { SetPropertyValue<Guid>("标识", ref f标识, value); }
        }
        string f角色;
        [Size(50)]
        public string 角色
        {
            get { return f角色; }
            set { SetPropertyValue<string>("角色", ref f角色, value); }
        }
        int f薪等标识;
        public int 薪等标识
        {
            get { return f薪等标识; }
            set { SetPropertyValue<int>("薪等标识", ref f薪等标识, value); }
        }
        public RoleGrade(Session session) : base(session) { }
        public RoleGrade() : base(MyHelper.XpoSession) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }
}
