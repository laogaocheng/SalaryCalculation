using System;
using DevExpress.Xpo;

namespace Hwagain.Components
{
    [Persistent("类型定义")]
    public partial class TypeDefine : XPLiteObject
    {
        Guid f标识;
        [Key(true)]
        public Guid 标识
        {
            get { return f标识; }
            set { SetPropertyValue<Guid>("标识", ref f标识, value); }
        }
        string f名称;
        [Size(50)]
        public string 名称
        {
            get { return f名称; }
            set { SetPropertyValue<string>("名称", ref f名称, value); }
        }
        public TypeDefine(Session session) : base(session) { }
        public TypeDefine() : base(MyHelper.XpoSession) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }
}
