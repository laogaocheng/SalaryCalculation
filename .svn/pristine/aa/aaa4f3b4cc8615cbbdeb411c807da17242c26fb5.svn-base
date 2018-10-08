using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Hwagain.Common;
using Hwagain.SalaryCalculation.Components;
using Hwagain.Components;

namespace Hwagain.SalaryCalculation.Modules
{
    public partial class TypeDefineModule : ModuleBase
    {
        BindingList<TypeDefine> typeDefines = new BindingList<TypeDefine>();

        public TypeDefineModule()
        {
            InitializeComponent();
            foreach (TypeDefine t in TypeDefine.GetListing())
            {
                typeDefines.Add(t);
            }
            gridControl1.DataSource = typeDefines;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确实要删除当前记录吗？", "删除", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                gridView1.DeleteRow(gridView1.FocusedRowHandle);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            gridView1.AddNewRow();
        }
    }
}
