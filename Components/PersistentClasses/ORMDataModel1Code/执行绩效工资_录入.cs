using System;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
namespace Hwagain.SalaryCalculation.Components
{

    public partial class EffectivePerformanceSalaryInput
    {
        public EffectivePerformanceSalaryInput(Session session) : base(session) { }
        public EffectivePerformanceSalaryInput() : base(MyHelper.XpoSession) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

}
