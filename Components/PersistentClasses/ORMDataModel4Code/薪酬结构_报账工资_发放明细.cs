﻿using System;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
namespace Hwagain.SalaryCalculation.Components
{

    public partial class MonthlyRembursementSalaryItem
    {
        public MonthlyRembursementSalaryItem() : base(MyHelper.XpoSession) { }
        public MonthlyRembursementSalaryItem(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

}
