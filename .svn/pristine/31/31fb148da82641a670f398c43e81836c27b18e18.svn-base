using System;
using DevExpress.Xpo;

namespace Hwagain.SalaryCalculation.Components
{
    [Persistent("查询权限")]
    public partial class QueryLevel : XPLiteObject
    {
        Guid f标识;
        [Key(true)]
        public Guid 标识
        {
            get { return f标识; }
            set { SetPropertyValue<Guid>("标识", ref f标识, value); }
        }
        string f姓名;
        [Size(50)]
        public string 姓名
        {
            get { return f姓名; }
            set { SetPropertyValue<string>("姓名", ref f姓名, value); }
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
        DateTime f录入时间;
        public DateTime 录入时间
        {
            get { return f录入时间; }
            set { SetPropertyValue<DateTime>("录入时间", ref f录入时间, value); }
        }
        string f录入人;
        [Size(20)]
        public string 录入人
        {
            get { return f录入人; }
            set { SetPropertyValue<string>("录入人", ref f录入人, value); }
        }
        DateTime f验证时间;
        public DateTime 验证时间
        {
            get { return f验证时间; }
            set { SetPropertyValue<DateTime>("验证时间", ref f验证时间, value); }
        }
        string f验证人;
        [Size(20)]
        public string 验证人
        {
            get { return f验证人; }
            set { SetPropertyValue<string>("验证人", ref f验证人, value); }
        }
        public QueryLevel(Session session) : base(session) { }
        public QueryLevel() : base(MyHelper.XpoSession) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }
}
