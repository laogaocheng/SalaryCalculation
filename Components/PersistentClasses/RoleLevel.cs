using System;
using DevExpress.Xpo;

namespace Hwagain.SalaryCalculation.Components
{
    [Persistent("角色_职等")]
    public partial class RoleLevel : XPLiteObject
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
        string f公司编码;
        [Size(10)]
        public string 公司编码
        {
            get { return f公司编码; }
            set { SetPropertyValue<string>("公司编码", ref f公司编码, value); }
        }
        string f职务等级;
        [Size(10)]
        public string 职务等级
        {
            get { return f职务等级; }
            set { SetPropertyValue<string>("职务等级", ref f职务等级, value); }
        }
        public RoleLevel(Session session) : base(session) { }
        public RoleLevel() : base(MyHelper.XpoSession) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }
}
