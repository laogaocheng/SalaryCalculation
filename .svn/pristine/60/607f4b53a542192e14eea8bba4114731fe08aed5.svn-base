using System;
using DevExpress.Xpo;

namespace Hwagain.SalaryCalculation.Components
{
    [Persistent("薪级")]
    public partial class SalaryStep : XPLiteObject
    {
        Guid f标识;
        [Key(true)]
        public Guid 标识
        {
            get { return f标识; }
            set { SetPropertyValue<Guid>("标识", ref f标识, value); }
        }
        Guid f薪等标识;
        public Guid 薪等标识
        {
            get { return f薪等标识; }
            set { SetPropertyValue<Guid>("薪等标识", ref f薪等标识, value); }
        }
        int f薪级编号;
        public int 薪级编号
        {
            get { return f薪级编号; }
            set { SetPropertyValue<int>("薪级编号", ref f薪级编号, value); }
        }
        string f薪级名称;
        [Size(20)]
        public string 薪级名称
        {
            get { return f薪级名称; }
            set { SetPropertyValue<string>("薪级名称", ref f薪级名称, value); }
        }
        DateTime f生效日期;
        public DateTime 生效日期
        {
            get { return f生效日期; }
            set { SetPropertyValue<DateTime>("生效日期", ref f生效日期, value); }
        }
        DateTime f创建时间;
        public DateTime 创建时间
        {
            get { return f创建时间; }
            set { SetPropertyValue<DateTime>("创建时间", ref f创建时间, value); }
        }
        DateTime f上次同步时间;
        public DateTime 上次同步时间
        {
            get { return f上次同步时间; }
            set { SetPropertyValue<DateTime>("上次同步时间", ref f上次同步时间, value); }
        }
        public SalaryStep(Session session) : base(session) { }
        public SalaryStep() : base(MyHelper.XpoSession) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }
}
