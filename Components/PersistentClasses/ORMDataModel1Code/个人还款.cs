using System;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
namespace Hwagain.SalaryCalculation.Components
{

    public partial class PersonRepayment
    {
        public PersonRepayment(Session session) : base(session) { }
        public PersonRepayment() : base(MyHelper.XpoSession) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

}
