using System;
using DevExpress.Xpo;

namespace Hwagain.SalaryCalculation.Components
{
    [Persistent("用户")]
    public partial class User : XPLiteObject
    {
        Guid f标识;
        [Key(true)]
        public Guid 标识
        {
            get { return f标识; }
            set { SetPropertyValue<Guid>("标识", ref f标识, value); }
        }
        string f用户名;
        [Size(50)]
        public string 用户名
        {
            get { return f用户名; }
            set { SetPropertyValue<string>("用户名", ref f用户名, value); }
        }
        string f姓名;
        [Size(10)]
        public string 姓名
        {
            get { return f姓名; }
            set { SetPropertyValue<string>("姓名", ref f姓名, value); }
        }
        string f密码;
        public string 密码
        {
            get { return f密码; }
            set { SetPropertyValue<string>("密码", ref f密码, value); }
        }
        string f盐;
        [Size(10)]
        public string 盐
        {
            get { return f盐; }
            set { SetPropertyValue<string>("盐", ref f盐, value); }
        }
        string f身份证号码;
        [Size(20)]
        public string 身份证号码
        {
            get { return f身份证号码; }
            set { SetPropertyValue<string>("身份证号码", ref f身份证号码, value); }
        }
        string f邮箱地址;
        public string 邮箱地址
        {
            get { return f邮箱地址; }
            set { SetPropertyValue<string>("邮箱地址", ref f邮箱地址, value); }
        }
        DateTime f创建时间;
        public DateTime 创建时间
        {
            get { return f创建时间; }
            set { SetPropertyValue<DateTime>("创建时间", ref f创建时间, value); }
        }
        DateTime f最后登录时间;
        public DateTime 最后登录时间
        {
            get { return f最后登录时间; }
            set { SetPropertyValue<DateTime>("最后登录时间", ref f最后登录时间, value); }
        }
        public User(Session session) : base(session) { }
        public User() : base(MyHelper.XpoSession) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }
}
