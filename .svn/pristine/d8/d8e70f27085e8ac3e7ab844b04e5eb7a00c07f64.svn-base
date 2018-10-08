using System;
using DevExpress.Xpo;

namespace Hwagain.SalaryCalculation.Components
{
    [Persistent("查询权限_录入")]
    public partial class QueryLevelInput : XPLiteObject
    {
        Guid f标识;
        [Key(true)]
        public Guid 标识
        {
            get { return f标识; }
            set { SetPropertyValue<Guid>("标识", ref f标识, value); }
        }
        string f编号;
        [Size(20)]
        [WatchMember]
        public string 编号
        {
            get { return f编号; }
            set { SetPropertyValue<string>("编号", ref f编号, value); }
        }
        string f姓名;
        [Size(50)]
        [WatchMember]
        public string 姓名
        {
            get { return f姓名; }
            set { SetPropertyValue<string>("姓名", ref f姓名, value); }
        }
        string f公司编码;
        [Size(10)]
        [WatchMember]
        public string 公司编码
        {
            get { return f公司编码; }
            set { SetPropertyValue<string>("公司编码", ref f公司编码, value); }
        }
        string f职务等级;
        [Size(10)]
        [WatchMember]
        public string 职务等级
        {
            get { return f职务等级; }
            set { SetPropertyValue<string>("职务等级", ref f职务等级, value); }
        }        
        string f录入人;
        [Size(20)]
        public string 录入人
        {
            get { return f录入人; }
            set { SetPropertyValue<string>("录入人", ref f录入人, value); }
        }
        DateTime f录入时间;
        public DateTime 录入时间
        {
            get { return f录入时间; }
            set { SetPropertyValue<DateTime>("录入时间", ref f录入时间, value); }
        }
        bool f是验证录入;
        public bool 是验证录入
        {
            get { return f是验证录入; }
            set { SetPropertyValue<bool>("是验证录入", ref f是验证录入, value); }
        }
        DateTime f生效时间;
        public DateTime 生效时间
        {
            get { return f生效时间; }
            set { SetPropertyValue<DateTime>("生效时间", ref f生效时间, value); }
        }
        string f双人录入结果;
        [Size(20)]
        public string 双人录入结果
        {
            get { return f双人录入结果; }
            set { SetPropertyValue<string>("双人录入结果", ref f双人录入结果, value); }
        }
        public QueryLevelInput(Session session) : base(session) { }
        public QueryLevelInput() : base(MyHelper.XpoSession) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }
}
