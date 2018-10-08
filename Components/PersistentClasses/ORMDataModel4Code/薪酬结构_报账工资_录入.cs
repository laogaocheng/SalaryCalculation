using System;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
namespace Hwagain.SalaryCalculation.Components
{

    public partial class RembursementSalaryEntry
    {
        public RembursementSalaryEntry() : base(MyHelper.XpoSession) { }
        public RembursementSalaryEntry(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

}
