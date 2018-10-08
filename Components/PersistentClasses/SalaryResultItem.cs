using System;
using DevExpress.Xpo;

namespace Hwagain.SalaryCalculation.Components
{
    [Persistent("工资明细")]
    public partial class SalaryResultItem : XPLiteObject
    {
        Guid f标识;
        [Key(true)]
        public Guid 标识
        {
            get { return f标识; }
            set { SetPropertyValue<Guid>("标识", ref f标识, value); }
        }
        string f员工编号;
        [Size(20)]
        public string 员工编号
        {
            get { return f员工编号; }
            set { SetPropertyValue<string>("员工编号", ref f员工编号, value); }
        }
        string f日历组;
        [Size(20)]
        public string 日历组
        {
            get { return f日历组; }
            set { SetPropertyValue<string>("日历组", ref f日历组, value); }
        }
        string f日历;
        [Size(20)]
        public string 日历
        {
            get { return f日历; }
            set { SetPropertyValue<string>("日历", ref f日历, value); }
        }
        string f薪资组;
        [Size(10)]
        public string 薪资组
        {
            get { return f薪资组; }
            set { SetPropertyValue<string>("薪资组", ref f薪资组, value); }
        }
        int f年度;
        public int 年度
        {
            get { return f年度; }
            set { SetPropertyValue<int>("年度", ref f年度, value); }
        }
        int f月份;
        public int 月份
        {
            get { return f月份; }
            set { SetPropertyValue<int>("月份", ref f月份, value); }
        }
        decimal f元素编号;
        public decimal 元素编号
        {
            get { return f元素编号; }
            set { SetPropertyValue<decimal>("元素编号", ref f元素编号, value); }
        }
        string f英文名称;
        [Size(50)]
        public string 英文名称
        {
            get { return f英文名称; }
            set { SetPropertyValue<string>("英文名称", ref f英文名称, value); }
        }
        string f中文名称;
        [Size(50)]
        public string 中文名称
        {
            get { return f中文名称; }
            set { SetPropertyValue<string>("中文名称", ref f中文名称, value); }
        }
        decimal f金额;
        public decimal 金额
        {
            get { return f金额; }
            set { SetPropertyValue<decimal>("金额", ref f金额, value); }
        }
        string f类别;
        public string 类别
        {
            get { return f类别; }
            set { SetPropertyValue<string>("类别", ref f类别, value); }
        }
        DateTime f上次同步时间;
        public DateTime 上次同步时间
        {
            get { return f上次同步时间; }
            set { SetPropertyValue<DateTime>("上次同步时间", ref f上次同步时间, value); }
        }
        public SalaryResultItem(Session session) : base(session) { }
        public SalaryResultItem() : base(MyHelper.XpoSession) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }
}
