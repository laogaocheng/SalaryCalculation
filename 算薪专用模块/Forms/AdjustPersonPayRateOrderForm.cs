using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Hwagain.SalaryCalculation
{
    public partial class AdjustPersonPayRateOrderForm : PersonPayRateList
    {
        public AdjustPersonPayRateOrderForm()
        {
            InitializeComponent();
            SetEditable();
        }
    }
}