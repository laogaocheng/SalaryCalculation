﻿using System;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
namespace Hwagain.SalaryCalculation.Components
{

    public partial class MonthlyWageLoanItem
    {
        public MonthlyWageLoanItem() : base(MyHelper.XpoSession) { }
        public MonthlyWageLoanItem(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

}
