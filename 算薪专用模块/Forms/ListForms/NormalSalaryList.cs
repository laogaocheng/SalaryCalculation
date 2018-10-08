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


namespace Hwagain.SalaryCalculation
{
    public partial class NormalSalaryList : XtraForm
    {
        public NormalSalaryList()
        {
            // This call is required by the Windows Form Designer.
            InitializeComponent();
            // TODO: Add any initialization after the InitializeComponent call
        }

        #region Init

        void Init()
        {
            DateTime prevMonth = DateTime.Today.AddMonths(-1);
            year.Value = prevMonth.Year;
            month.EditValue = prevMonth.Month;

            ccb发放单位.Properties.Items.Clear();
            foreach (string company in PsHelper.GetCompanyList())
            {
                ImageComboBoxItem item = new ImageComboBoxItem((string)company, (string)company);
                ccb发放单位.Properties.Items.Add(item);
            }
        }
        #endregion

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

        #region EditEmployeeSalaryStepForm_Load

        private void EditEmployeeSalaryStepForm_Load(object sender, EventArgs e)
        {
            Init();
        }
        #endregion

        #region 加载数据

        protected void LoadData()
        {
            CreateWaitDialog("正在查询...", "请稍等");

            List<PersonalTax> rows = PersonalTax.GetPersonalTaxList(Convert.ToInt32(year.Value), Convert.ToInt32(month.Text), (string)ccb发放单位.EditValue);
            //排序
            rows = rows.OrderBy(a => a.上表工资.财务公司).ThenBy(a => a.上表工资.财务部门序号).ThenBy(a => a.上表工资.员工序号).ToList();

            CreateWaitDialog("正在加载...", "请稍等");            

            CloseWaitDialog();
            gridControl1.DataSource = rows;
            gridControl1.RefreshDataSource();
            gridView1.ExpandAllGroups();

            btn导出.Enabled = true;
        }        

        #endregion       

        #region btn查询_Click

        private void btn查询_Click(object sender, EventArgs e)
        {
        }
        #endregion
        
        #region searchKey_KeyUp

        private void searchKey_KeyUp(object sender, KeyEventArgs e)
        {
        }
        #endregion

        private void btn按发放单位查询_Click(object sender, EventArgs e)
        {
            btn按发放单位查询.Enabled = false;
            LoadData();
            btn按发放单位查询.Enabled = true;
        }

        private void btn导出_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = (string)ccb发放单位.EditValue + "正常工资薪金收入表";
            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string filename = saveFileDialog1.FileName;
                XlsExportOptions options = new XlsExportOptions();
                options.SheetName = "正常工资薪金收入表";
                options.RawDataMode = false;
                gridView1.ExportToXls(filename, options);

                Aspose.Cells.Workbook workbook = new Aspose.Cells.Workbook(filename);
                Worksheet sheet = workbook.Worksheets[0];
                sheet.AutoFitColumns();
                workbook.Save(filename);
            }
        }
    }

}

