using System;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
namespace Hwagain.SalaryCalculation.Components
{

    public partial class MemberDept
    {
        public MemberDept() : base(MyHelper.XpoSession) { }
        public MemberDept(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

}
