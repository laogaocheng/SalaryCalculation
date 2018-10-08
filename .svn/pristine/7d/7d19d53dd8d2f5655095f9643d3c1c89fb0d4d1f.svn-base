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
using Aspose.Cells;
using System.Data;


namespace Hwagain.SalaryCalculation
{
    public partial class TraineeMonthlySalaryItemsFirstYearForm : XtraForm
    {        
        string division = null;
        int year;
        string grade = null;

        List<ManagementTraineeYearlySalaryCalulator> calulator_list = new List<ManagementTraineeYearlySalaryCalulator>();

        bool showDifferent = false;

        public TraineeMonthlySalaryItemsFirstYearForm(string division, string grade, int year)
            : this()
        {
            this.division = division;
            this.year = year;
            this.grade = grade;         
        }

        public TraineeMonthlySalaryItemsFirstYearForm()
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
            gridBand岗位类型.Visible = grade == "一级";
            gridBand专业属性.Visible = grade != "一级";

            CreateWaitDialog("正在查询...", "请稍等");
            //获取管培生名单
            List<ManagementTraineeInfo> trainee_info_list = ManagementTraineeInfo.GetManagementTraineeInfoList(division, grade);
            int order = 1;
            //构造年薪计算器
            foreach(ManagementTraineeInfo trainee in trainee_info_list)
            {
                ManagementTraineeYearlySalaryCalulator c = new ManagementTraineeYearlySalaryCalulator(trainee, year);
                c.序号 = order++;
                calulator_list.Add(c);
            }
            
            SetWaitDialogCaption("正在加载...");  

            gridControl1.DataSource = calulator_list;
            gridControl1.RefreshDataSource();

            CloseWaitDialog();    
        }        

        #endregion       
      
        private void btn导出_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = lbl标题.Text;

            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string filename = saveFileDialog1.FileName;
                XlsExportOptions options = new XlsExportOptions();
                options.RawDataMode = false;
                advBandedGridView1.ExportToXls(filename, options);

                Aspose.Cells.Workbook workbook = new Aspose.Cells.Workbook(filename);
                Worksheet sheet = workbook.Worksheets[0];
                sheet.AutoFitColumns();
                workbook.Save(filename);
            }
        }

        private void AdjustMonthlySalaryForm_Load(object sender, EventArgs e)
        {
            lbl标题.Text = division + " 届定职人员（" + grade + "）" + year + "年度月薪计算表";
            LoadData();
        }

        private void advBandedGridView1_ShowingEditor(object sender, CancelEventArgs e)
        {
            
        }

        #region gridView1_CustomDrawCell

        private void gridView1_CustomDrawCell(object sender, RowCellCustomDrawEventArgs e)
        {
            if (showDifferent == false) return;

            e.Appearance.ForeColor = Color.Black;
            e.Appearance.BackColor = Color.Transparent;

            ManagementTraineeInfoInput row = advBandedGridView1.GetRow(e.RowHandle) as ManagementTraineeInfoInput;
            if (row != null)
            {
                foreach (ModifyField field in row.内容不同的字段)
                {
                    if (field.名称 == e.Column.FieldName)
                    {
                        e.Appearance.ForeColor = Color.Yellow;
                        e.Appearance.BackColor = Color.Red;
                    }
                }
            }
        }
        #endregion

        #region advBandedGridView1_CellValueChanged

        private void advBandedGridView1_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            
        }

        #endregion

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

