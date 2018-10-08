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
    public partial class TraineePersonalAbilityListForm : XtraForm
    {  
        string division = null;
        string grade = null;

        public delegate void SelectTraineeHandle(object sender, ManagementTraineeInfo trainee);
        public event SelectTraineeHandle OnSelected;

        List<ManagementTraineeInfo> trainee_info_list = new List<ManagementTraineeInfo>();

        public TraineePersonalAbilityListForm(string division, string grade)
            : this()
        {
            this.division = division;
            this.grade = grade;        
        }

        public TraineePersonalAbilityListForm()
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
            lbl标题.Text = division + " 届定职人员（" + grade + "）个人年度评定结果及提资表";

            CreateWaitDialog("正在查询...", "请稍等");

            trainee_info_list = ManagementTraineeInfo.GetManagementTraineeInfoList(division, grade);
            trainee_info_list = trainee_info_list.OrderBy(a => a.届别).ThenBy(a => a.岗位级别).ThenBy(a => a.入职时间).ToList();
            //+序号
            int order = 1;
            foreach(ManagementTraineeInfo item in trainee_info_list)
            {
                item.序号 = order++;
            }

            SetWaitDialogCaption("正在加载...");            
            
            gridControl1.DataSource = trainee_info_list;
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
            lbl标题.Text = division + " 届" + grade + "定职人员";
            gridBand专业.Visible = grade != "一级";
            gridBand岗位类型.Visible = grade == "一级";
            gridBand专业属性.Visible = grade != "一级";
            LoadData();
        }

        private void advBandedGridView1_ShowingEditor(object sender, CancelEventArgs e)
        {
            
        }

        #region gridView1_CustomDrawCell

        private void gridView1_CustomDrawCell(object sender, RowCellCustomDrawEventArgs e)
        {

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

        private void advBandedGridView1_DoubleClick(object sender, EventArgs e)
        {
            ManagementTraineeInfo currentItem = (ManagementTraineeInfo)advBandedGridView1.GetFocusedRow();
            选择的管培生 = currentItem;

            TraineePersonalSalaryPlanForm form = new TraineePersonalSalaryPlanForm(currentItem);
            form.Owner = this;
            form.ShowDialog();

            if (OnSelected != null)
            {
                OnSelected(this, currentItem);
                this.DialogResult = DialogResult.OK;
            }            
        }

        public ManagementTraineeInfo 选择的管培生 { get; set; }
    }

}

