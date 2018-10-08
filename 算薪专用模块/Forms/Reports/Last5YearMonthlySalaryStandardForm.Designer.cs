namespace Hwagain.SalaryCalculation
{
    partial class Last5YearMonthlySalaryStandardForm
    {
        /// <summary>
        /// Clean up any Roles being used.
        /// </summary>
        protected override void Dispose(bool disposing) {
            if(disposing) {
                if(components != null) {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Last5YearMonthlySalaryStandardForm));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btn返回目录 = new DevExpress.XtraEditors.SimpleButton();
            this.lbl标题 = new DevExpress.XtraEditors.LabelControl();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.spreadsheetControl1 = new DevExpress.XtraSpreadsheet.SpreadsheetControl();
            this.monthlySalaryInputBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.monthlySalaryInputBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btn返回目录);
            this.panelControl1.Controls.Add(this.lbl标题);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1035, 48);
            this.panelControl1.TabIndex = 4;
            // 
            // btn返回目录
            // 
            this.btn返回目录.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn返回目录.Location = new System.Drawing.Point(942, 8);
            this.btn返回目录.Name = "btn返回目录";
            this.btn返回目录.Size = new System.Drawing.Size(81, 31);
            this.btn返回目录.TabIndex = 47;
            this.btn返回目录.Text = "返回目录";
            this.btn返回目录.Click += new System.EventHandler(this.btn返回目录_Click);
            // 
            // lbl标题
            // 
            this.lbl标题.Appearance.Font = new System.Drawing.Font("黑体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl标题.Appearance.Options.UseFont = true;
            this.lbl标题.Location = new System.Drawing.Point(19, 15);
            this.lbl标题.Name = "lbl标题";
            this.lbl标题.Size = new System.Drawing.Size(40, 19);
            this.lbl标题.TabIndex = 44;
            this.lbl标题.Text = "标题";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileName = "薪酬执行明细表";
            this.saveFileDialog1.Filter = "Excel 文件 | *.xls";
            // 
            // spreadsheetControl1
            // 
            this.spreadsheetControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spreadsheetControl1.Location = new System.Drawing.Point(0, 48);
            this.spreadsheetControl1.Name = "spreadsheetControl1";
            this.spreadsheetControl1.Options.Culture = new System.Globalization.CultureInfo("zh-CN");
            this.spreadsheetControl1.Options.Import.Csv.Encoding = ((System.Text.Encoding)(resources.GetObject("spreadsheetControl1.Options.Import.Csv.Encoding")));
            this.spreadsheetControl1.Options.Import.Txt.Encoding = ((System.Text.Encoding)(resources.GetObject("spreadsheetControl1.Options.Import.Txt.Encoding")));
            this.spreadsheetControl1.Options.TabSelector.Visibility = DevExpress.XtraSpreadsheet.SpreadsheetElementVisibility.Hidden;
            this.spreadsheetControl1.Options.View.ShowColumnHeaders = false;
            this.spreadsheetControl1.Options.View.ShowRowHeaders = false;
            this.spreadsheetControl1.ReadOnly = true;
            this.spreadsheetControl1.Size = new System.Drawing.Size(1035, 571);
            this.spreadsheetControl1.TabIndex = 5;
            this.spreadsheetControl1.Text = "spreadsheetControl1";
            // 
            // monthlySalaryInputBindingSource
            // 
            this.monthlySalaryInputBindingSource.DataSource = typeof(Hwagain.SalaryCalculation.Components.MonthlySalaryInput);
            // 
            // Last5YearMonthlySalaryStandardForm
            // 
            this.ClientSize = new System.Drawing.Size(1035, 619);
            this.Controls.Add(this.spreadsheetControl1);
            this.Controls.Add(this.panelControl1);
            this.LookAndFeel.SkinName = "Summer 2008";
            this.Name = "Last5YearMonthlySalaryStandardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "各职等月薪执行标准各年度汇总表";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AdjustMonthlySalaryForm_FormClosed);
            this.Load += new System.EventHandler(this.AdjustMonthlySalaryForm_Load);
            this.Shown += new System.EventHandler(this.AdjustMonthlySalaryForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.monthlySalaryInputBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.ComponentModel.IContainer components = null;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.BindingSource monthlySalaryInputBindingSource;
        private DevExpress.XtraEditors.LabelControl lbl标题;
        private DevExpress.XtraEditors.SimpleButton btn返回目录;
        private DevExpress.XtraSpreadsheet.SpreadsheetControl spreadsheetControl1;
    }
}
