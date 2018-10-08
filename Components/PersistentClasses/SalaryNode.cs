using System;
using DevExpress.Xpo;

namespace Hwagain.SalaryCalculation.Components
{
    [Persistent("工资结构")]
    public partial class SalaryNode : XPLiteObject
    {
        int f标识;
        [Key(true)]
        public int 标识
        {
            get { return f标识; }
            set { SetPropertyValue<int>("标识", ref f标识, value); }
        }
        string f名称;
        [Size(50)]
        public string 名称
        {
            get { return f名称; }
            set { SetPropertyValue<string>("名称", ref f名称, value); }
        }
        string f代码;
        public string 代码
        {
            get { return f代码; }
            set { SetPropertyValue<string>("代码", ref f代码, value); }
        }
        int f上级;
        public int 上级
        {
            get { return f上级; }
            set { SetPropertyValue<int>("上级", ref f上级, value); }
        }
        string f序号;
        public string 序号
        {
            get { return f序号; }
            set { SetPropertyValue<string>("序号", ref f序号, value); }
        }
        bool f已撤销;
        public bool 已撤销
        {
            get { return f已撤销; }
            set { SetPropertyValue<bool>("已撤销", ref f已撤销, value); }
        }
        bool f已启用;
        public bool 已启用
        {
            get { return f已启用; }
            set { SetPropertyValue<bool>("已启用", ref f已启用, value); }
        }        
        int f类型;
        public int 类型
        {
            get { return f类型; }
            set { SetPropertyValue<int>("类型", ref f类型, value); }
        }        
        public SalaryNode(Session session) : base(session) { }
        public SalaryNode() : base(MyHelper.XpoSession) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }
}
