using System;
using DevExpress.Xpo;

namespace Hwagain.Components
{
    [Persistent("编号信息")]
    public partial class NumberInfo : XPLiteObject
    {
        int f标识;
        [Key(true)]
        public int 标识
        {
            get { return f标识; }
            set { SetPropertyValue<int>("标识", ref f标识, value); }
        }
        string f编号名称;
        [Size(50)]
        public string 编号名称
        {
            get { return f编号名称; }
            set { SetPropertyValue<string>("编号名称", ref f编号名称, value); }
        }
        string f编号规则;
        [Size(50)]
        public string 编号规则
        {
            get { return f编号规则; }
            set { SetPropertyValue<string>("编号规则", ref f编号规则, value); }
        }
        int f序号长度;
        public int 序号长度
        {
            get { return f序号长度; }
            set { SetPropertyValue<int>("序号长度", ref f序号长度, value); }
        }
        int f当前序号;
        public int 当前序号
        {
            get { return f当前序号; }
            set { SetPropertyValue<int>("当前序号", ref f当前序号, value); }
        }
        public NumberInfo(Session session) : base(session) { }
        public NumberInfo() : base(MyHelper.XpoSession) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }
}
