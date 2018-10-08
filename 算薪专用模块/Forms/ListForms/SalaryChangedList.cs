using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Linq;

using System.Windows.Forms;
using YiKang.RBACS.DataObjects;
using System.Collections.Generic;
using DevExpress.XtraGrid.Views.Base;
using Hwagain.Components;
using Hwagain.SalaryCalculation.Components;
using YiKang;
using DevExpress.XtraEditors;
using Aspose.Cells;
using System.IO;


namespace Hwagain.SalaryCalculation
{
    public partial class SalaryChangedList : XtraForm
    {
        protected List<SalaryChangedItem> rows = new List<SalaryChangedItem>();

        int year; int month; string payGroup;

        public SalaryChangedList(int year, int month, string payGroup, string payGroupName)
        {
            // This call is required by the Windows Form Designer.
            InitializeComponent();

            this.year = year;
            this.month = month;
            this.payGroup = payGroup;

            lbl标题.Text = String.Format("{0}本月工资与上月对比差异", payGroupName);
            lbl期间.Text = String.Format("{0}年 {1}月", year, month);
        }

        private void SalaryChangedList_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        #region LoadData

        private void LoadData()
        {
            rows = SalaryChangedItem.GetChangedItems(year, month, payGroup);
            rows = rows.OrderBy(a => a.变动类型).ThenBy(a => a.计算部门序号).ThenBy(a => a.员工信息.员工序号).ToList();

            gridControl1.DataSource = rows;
            gridControl1.RefreshDataSource();
            gridView1.ExpandAllGroups();
        }

        #endregion

        #region btn刷新_Click

        private void btn刷新_Click(object sender, EventArgs e)
        {
            LoadData();
        }
        #endregion

        #region btn导出_Click

        private void btn导出_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = lbl标题.Text;
            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string filename = saveFileDialog1.FileName;
                MemoryStream ms = new MemoryStream();
                gridView1.ExportToXls(ms);
                Workbook workbook = new Workbook(ms);
                Worksheet sheet = workbook.Worksheets[0];
                sheet.Cells.InsertRow(0);
                sheet.Cells.Merge(0, 0, 1, 8);
                sheet.Cells[0].Value = lbl标题.Text;
                Style style = new Style();
                style.Font.Size = 18;
                style.HorizontalAlignment = TextAlignmentType.Center;
                style.VerticalAlignment = TextAlignmentType.Center;
                sheet.Cells[0].SetStyle(style);
                sheet.PageSetup.LeftMargin = 1.5 ;
                workbook.Save(filename);
            }
        }
        #endregion
    }

}

