using System;
using DevExpress.Xpo;

namespace Hwagain.Components
{
    [Persistent("基础资料")]
    public partial class BaseData : XPLiteObject
    {
        int f标识;
        [Key(true)]
        public int 标识
        {
            get { return f标识; }
            set { SetPropertyValue<int>("标识", ref f标识, value); }
        }
        string f名称;
        [Size(20)]
        public string 名称
        {
            get { return f名称; }
            set { SetPropertyValue<string>("名称", ref f名称, value); }
        }
        string f代码;
        [Size(20)]
        public string 代码
        {
            get { return f代码; }
            set { SetPropertyValue<string>("代码", ref f代码, value); }
        }
        string f项目;
        [Size(20)]
        public string 项目
        {
            get { return f项目; }
            set { SetPropertyValue<string>("项目", ref f项目, value); }
        }
        bool f内建;
        public bool 内建
        {
            get { return f内建; }
            set { SetPropertyValue<bool>("内建", ref f内建, value); }
        }
        bool f禁用;
        public bool 禁用
        {
            get { return f禁用; }
            set { SetPropertyValue<bool>("禁用", ref f禁用, value); }
        }
        string f标签;
        [Size(20)]
        public string 标签
        {
            get { return f标签; }
            set { SetPropertyValue<string>("标签", ref f标签, value); }
        }
        public BaseData(Session session) : base(session) { }
        public BaseData() : base(MyHelper.XpoSession) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }
}
