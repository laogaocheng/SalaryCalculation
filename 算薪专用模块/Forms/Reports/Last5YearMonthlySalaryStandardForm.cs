using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;

using YiKang.RBACS.DataObjects;
using DevExpress.XtraGrid.Views.Base;
using Hwagain.Components;
using Hwagain.SalaryCalculation.Components;
using YiKang;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.Utils;
using DevExpress.XtraPrinting;
using System.Data;
using System.IO;
using DevExpress.Spreadsheet;

namespace Hwagain.SalaryCalculation
{
    public partial class Last5YearMonthlySalaryStandardForm : XtraForm
    {        
        string salary_plan = null;
        string grade = null;

        int max_rank_count = 0; //最大职级数

        Worksheet sheet;
        ColumnCollection columns;
        RowCollection rows;
        CellCollection cells;

        public Last5YearMonthlySalaryStandardForm(string salary_plan, string grade)
            : this()
        {
            this.salary_plan = salary_plan;
            this.grade = grade;
        }

        public Last5YearMonthlySalaryStandardForm()
        {
            // This call is required by the Windows Form Designer.
            InitializeComponent();
            // TODO: Add any initialization after the InitializeComponent call
        }

        #region CreateWaitDialog

        WaitDialogForm dlg = null;
        public void CreateWaitDialog()
        {
            CreateWaitDialog("正在启动...", "请稍等");
        }
        public void CreateWaitDialog(string caption, string title, Size size)
        {
            CloseWaitDialog();
            dlg = new DevExpress.Utils.WaitDialogForm(caption, title, size);
        }
        public void CreateWaitDialog(string caption, string title)
        {
            CloseWaitDialog();
            dlg = new DevExpress.Utils.WaitDialogForm(caption, title);
        }
        public void SetWaitDialogCaption(string fCaption)
        {
            if (dlg != null)
                dlg.Caption = fCaption;
        }
        public void CloseWaitDialog()
        {
            if (dlg != null)
                dlg.Close();
        }
        #endregion

        #region 加载数据

        protected void LoadData()
        { 
            CreateWaitDialog("正在查询...", "请稍等");

            //加载模板
            string filename = Path.Combine(Application.StartupPath, "ReportTemplates\\月薪执行标准年度汇总.tab");
            spreadsheetControl1.LoadDocument(filename);

            sheet = spreadsheetControl1.ActiveWorksheet;
            columns = sheet.Columns;
            rows = sheet.Rows;
            cells = sheet.Cells;

            SetWaitDialogCaption("正在加载数据...");

            FillTable();

            sheet.ScrollToColumn(0);//焦点切回开始位置

            CloseWaitDialog();    
        }        

        #endregion       

        private void AdjustMonthlySalaryForm_Load(object sender, EventArgs e)
        {
            lbl标题.Text = "【" + grade + "】职等月薪执行标准各年度汇总表";
            LoadData();
            this.WindowState = FormWindowState.Maximized;
        }

        private void FillTable()
        {
            List<GradeSalaryAdjust> list = GradeSalaryAdjust.GetGradeSalaryAdjusts(salary_plan, grade, DateTime.Today.Year - 5);
            int x = 0;
            foreach (GradeSalaryAdjust gsa in list)
            {
                FillTableRows(gsa, x++);
            }

            int rank_start_index = 4;
            int rank_end_index = rank_start_index + max_rank_count;
            for (int i = rank_end_index; i <= rank_start_index + 10; i++)
                columns[i].Visible = false;

            //如果没有标准，保留格式模板
            if (list.Count > 0)
            {
                //删除模板
                Range rng_src = sheet.Range["B4:R5"];
                sheet.DeleteCells(rng_src, DeleteMode.ShiftCellsUp);
            }
        }

        private void FillTableRows(GradeSalaryAdjust gsad, int recIndex)
        {
            if (gsad == null) return;

            int rowIndex = 5 + recIndex * 2;

            List<RankSalaryStandard> ranks = RankSalaryStandard.GetRankSalaryStandards(salary_plan, grade, gsad.期号);
            if (ranks.Count == 0) return;

            if (ranks.Count > max_rank_count) max_rank_count = ranks.Count;
            //复制
            Range rng_src = sheet.Range["B4:R5"];

            string dest_pos = "B" + (rowIndex + 1).ToString() + ":R" + (rowIndex + 2).ToString();
            Range rng_dest = sheet.Range[dest_pos];
            
            rng_dest.CopyFrom(rng_src, PasteSpecial.All);
            rng_dest.RowHeight = rng_src.RowHeight;

            //序号
            cells[rowIndex, 1].Value = recIndex + 1;
            //执行日期
            cells[rowIndex, 2].Value = ranks[0].开始执行日期.ToString("yyyy-M-d");
            cells[rowIndex, 14].Value = gsad.平均工资;
            cells[rowIndex, 15].Value = gsad.半年调资额;
            cells[rowIndex, 16].Value = (gsad.年调率 * 100 / 1.5).ToString("#0.#") + "%";
            cells[rowIndex, 17].Value = (gsad.年调率 * 100).ToString("#0.#") + "%";

            int i = 0;
            foreach (RankSalaryStandard rank in ranks)
            {
                cells[rowIndex, 4 + i].Value = rank.职级;
                cells[rowIndex + 1, 4 + i].Value = rank.月薪;

                i++;
            }
        }

        private void AdjustMonthlySalaryForm_Shown(object sender, EventArgs e)
        {
            if (this.Owner != null && this.Owner.Visible) this.Owner.Hide();
        }

        private void AdjustMonthlySalaryForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.Owner != null) this.Owner.Show();
        }

        private void btn返回目录_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }

}

