using System;
using DevExpress.Xpo;

namespace Hwagain.SalaryCalculation.Components
{
    [Persistent("角色_薪资组")]
    public partial class RolePayGroup : XPLiteObject
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
        string f薪资组;
        [Size(50)]
        public string 薪资组
        {
            get { return f薪资组; }
            set { SetPropertyValue<string>("薪资组", ref f薪资组, value); }
        }
        public RolePayGroup(Session session) : base(session) { }
        public RolePayGroup() : base(MyHelper.XpoSession) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }
}
