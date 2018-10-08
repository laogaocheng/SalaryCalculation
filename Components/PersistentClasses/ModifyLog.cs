using System;
using DevExpress.Xpo;
namespace Hwagain.Components
{
    [Persistent("修改日志")]
    public partial class ModifyLog : XPLiteObject
    {
        Guid f标识;
        [Key(true)]
        public Guid 标识
        {
            get { return f标识; }
            set { SetPropertyValue<Guid>("标识", ref f标识, value); }
        }
        string f表名;
        [Size(50)]
        public string 表名
        {
            get { return f表名; }
            set { SetPropertyValue<string>("表名", ref f表名, value); }
        }
        Guid f记录键值;
        public Guid 记录键值
        {
            get { return f记录键值; }
            set { SetPropertyValue<Guid>("记录键值", ref f记录键值, value); }
        }
        DateTime f修改时间;
        public DateTime 修改时间
        {
            get { return f修改时间; }
            set { SetPropertyValue<DateTime>("修改时间", ref f修改时间, value); }
        }
        string f修改内容;
        [Size(2147483647)]
        public string 修改内容
        {
            get { return f修改内容; }
            set { SetPropertyValue<string>("修改内容", ref f修改内容, value); }
        }
        string f修改人;
        [Size(10)]
        public string 修改人
        {
            get { return f修改人; }
            set { SetPropertyValue<string>("修改人", ref f修改人, value); }
        }
        string f描述;
        [Size(200)]
        public string 描述
        {
            get { return f描述; }
            set { SetPropertyValue<string>("描述", ref f描述, value); }
        }        
        public ModifyLog(Session session) : base(session) { }
        public ModifyLog() : base(Session.DefaultSession) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

}
