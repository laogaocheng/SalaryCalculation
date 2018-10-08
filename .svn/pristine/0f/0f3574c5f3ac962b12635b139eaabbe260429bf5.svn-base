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
    public partial class BaseDataModule : ModuleBase
    {
        BindingList<BaseData> baseDatas = new BindingList<BaseData>();
        public BaseDataModule()
        {
            InitializeComponent();

            foreach (TypeDefine td in TypeDefine.GetListing())
            {
                repositoryItemComboBox1.Items.Add(td.名称);
            }

            foreach (BaseData data in BaseData.GetAllBaseData())
            {
                baseDatas.Add(data);
            }

            gridControl1.DataSource = baseDatas;
        }

        private void gridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            gridView1.AddNewRow();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确实要删除当前记录吗？", "删除", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                gridView1.DeleteRow(gridView1.FocusedRowHandle);
            }
        }
    }
}
