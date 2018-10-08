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
    public partial class RiseRate72Form : XtraForm
    { 
        string division = null;
        string grade = null;
        string type = null;
        RiseType rise_type_final = RiseType.金额; //满阶提资类型 

        public RiseRate72Form(string division, string grade, string type)
            : this()
        {
            this.division = division;
            this.grade = grade;
            this.type = type;        
        }

        public RiseRate72Form()
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

            List<ManagementTraineeSalaryStandard> rist_items = ManagementTraineeSalaryStandard.GetList(division, grade, type);

            SetWaitDialogCaption("正在加载...");

            gridControl1.DataSource = rist_items;
            gridControl1.RefreshDataSource();

            CloseWaitDialog();
        }

        #endregion

        private void AdjustMonthlySalaryForm_Load(object sender, EventArgs e)
        {
            lbl标题.Text = division + " 届（" + grade + "）定职人员各次提资幅度标准录入";
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
            if (this.Owner != null) this.Owner.Hide();
        }

        private void AdjustMonthlySalaryForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.Owner != null) this.Owner.Show();
        }

        private void btn返回目录_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void gridView1_CustomColumnDisplayText(object sender, CustomColumnDisplayTextEventArgs e)
        {
            bool flag = e.Column.FieldName.IndexOf("增幅") != -1;
            if (e.Column.FieldName.IndexOf("二阶起薪") != -1) flag = true;
            if (e.Column.FieldName.IndexOf("满阶") != -1 && rise_type_final == RiseType.百分比) flag = true ;

            if (flag)
            {
                decimal v = Convert.ToDecimal(e.Value);
                if (v > 0)
                    e.DisplayText = v.ToString("#.#") + "%";
                else
                    e.DisplayText = "";
            }
        }

        private void gridView1_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {

        }
    }

}

