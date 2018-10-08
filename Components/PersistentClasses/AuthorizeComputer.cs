using System;
using DevExpress.Xpo;

namespace Hwagain.SalaryCalculation.Components
{
    [Persistent("准入电脑")]
    public partial class AuthorizeComputer : XPLiteObject
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
        string f地址;
        [Size(50)]
        public string 地址
        {
            get { return f地址; }
            set { SetPropertyValue<string>("地址", ref f地址, value); }
        }
        string f类型;
        [Size(20)]
        public string 类型
        {
            get { return f类型; }
            set { SetPropertyValue<string>("类型", ref f类型, value); }
        }
        string f备注;
        public string 备注
        {
            get { return f备注; }
            set { SetPropertyValue<string>("备注", ref f备注, value); }
        }
        string f创建人;
        [Size(20)]
        public string 创建人
        {
            get { return f创建人; }
            set { SetPropertyValue<string>("创建人", ref f创建人, value); }
        }
        DateTime f创建时间;
        public DateTime 创建时间
        {
            get { return f创建时间; }
            set { SetPropertyValue<DateTime>("创建时间", ref f创建时间, value); }
        }
        public AuthorizeComputer(Session session) : base(session) { }
        public AuthorizeComputer() : base(MyHelper.XpoSession) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }
}
