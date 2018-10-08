using System;
using DevExpress.Xpo;

namespace Hwagain.Components
{
    [Persistent("角色")]
    public partial class Role : XPLiteObject
    {
        int fId;
        [Key(true)]
        public int Id
        {
            get { return fId; }
            set { SetPropertyValue<int>("Id", ref fId, value); }
        }
        string fName;
        [Size(50)]
        public string Name
        {
            get { return fName; }
            set { SetPropertyValue<string>("Name", ref fName, value); }
        }
        string fDescription;
        [Size(256)]
        public string Description
        {
            get { return fDescription; }
            set { SetPropertyValue<string>("Description", ref fDescription, value); }
        }
        public Role(Session session) : base(session) { }
        public Role() : base(Session.DefaultSession) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }
    [Persistent("角色成员")]
    public partial class UserInRole : XPLiteObject
    {
        int fId;
        [Key(true)]
        public int Id
        {
            get { return fId; }
            set { SetPropertyValue<int>("Id", ref fId, value); }
        }
        Guid fUserId;
        public Guid UserId
        {
            get { return fUserId; }
            set { SetPropertyValue<Guid>("UserId", ref fUserId, value); }
        }
        string fRole;
        [Size(50)]
        public string Role
        {
            get { return fRole; }
            set { SetPropertyValue<string>("Role", ref fRole, value); }
        }
        public UserInRole(Session session) : base(session) { }
        public UserInRole() : base(Session.DefaultSession) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

}
