using System;
using DevExpress.Xpo;
namespace Hwagain.Components
{
    [Persistent("常用过滤条件")]
    public partial class FilterString : XPLiteObject
    {
        int f标识;
        [Key(true)]
        public int 标识
        {
            get { return f标识; }
            set { SetPropertyValue<int>("标识", ref f标识, value); }
        }
        string f网格;
        [Size(50)]
        public string 网格
        {
            get { return f网格; }
            set { SetPropertyValue<string>("网格", ref f网格, value); }
        }
        string f名称;
        [Size(50)]
        public string 名称
        {
            get { return f名称; }
            set { SetPropertyValue<string>("名称", ref f名称, value); }
        }
        string f过滤字符串;
        [Size(500)]
        public string 过滤字符串
        {
            get { return f过滤字符串; }
            set { SetPropertyValue<string>("过滤字符串", ref f过滤字符串, value); }
        }
        string f布局;
        public string 布局
        {
            get { return f布局; }
            set { SetPropertyValue<string>("布局", ref f布局, value); }
        }
        DateTime f创建时间;
        public DateTime 创建时间
        {
            get { return f创建时间; }
            set { SetPropertyValue<DateTime>("创建时间", ref f创建时间, value); }
        }
        public FilterString(Session session) : base(session) { }
        public FilterString() : base(Session.DefaultSession) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

}
