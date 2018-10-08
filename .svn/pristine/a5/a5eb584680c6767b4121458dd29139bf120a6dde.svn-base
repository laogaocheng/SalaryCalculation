using System;
using DevExpress.Xpo;

namespace Hwagain.Components
{
    [Persistent("日志")]
    public partial class Log : XPLiteObject
    {
        int fLogId;
        [Key(true)]
        public int LogId
        {
            get { return fLogId; }
            set { SetPropertyValue<int>("LogId", ref fLogId, value); }
        }
        DateTime fDateAndTime;
        public DateTime DateAndTime
        {
            get { return fDateAndTime; }
            set { SetPropertyValue<DateTime>("DateAndTime", ref fDateAndTime, value); }
        }
        string fAddress;
        [Size(20)]
        public string Address
        {
            get { return fAddress; }
            set { SetPropertyValue<string>("Address", ref fAddress, value); }
        }
        string fUsername;
        [Size(50)]
        public string Username
        {
            get { return fUsername; }
            set { SetPropertyValue<string>("Username", ref fUsername, value); }
        }
        byte fLogType;
        public byte LogType
        {
            get { return fLogType; }
            set { SetPropertyValue<byte>("LogType", ref fLogType, value); }
        }
        string fTitle;
        [Size(200)]
        public string Title
        {
            get { return fTitle; }
            set { SetPropertyValue<string>("Title", ref fTitle, value); }
        }
        string fDetail;
        [Size(1073741823)]
        public string Detail
        {
            get { return fDetail; }
            set { SetPropertyValue<string>("Detail", ref fDetail, value); }
        }
        string fUrl;
        [Size(500)]
        public string Url
        {
            get { return fUrl; }
            set { SetPropertyValue<string>("Url", ref fUrl, value); }
        }
        public Log(Session session) : base(session) { }
        public Log() : base(MyHelper.XpoSession) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }
}
