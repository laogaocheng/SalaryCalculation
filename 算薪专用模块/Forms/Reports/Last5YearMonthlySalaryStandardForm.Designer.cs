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
            this.btn����Ŀ¼ = new DevExpress.XtraEditors.SimpleButton();
            this.lbl���� = new DevExpress.XtraEditors.LabelControl();
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
            this.panelControl1.Controls.Add(this.btn����Ŀ¼);
            this.panelControl1.Controls.Add(this.lbl����);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1035, 48);
            this.panelControl1.TabIndex = 4;
            // 
            // btn����Ŀ¼
            // 
            this.btn����Ŀ¼.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn����Ŀ¼.Location = new System.Drawing.Point(942, 8);
            this.btn����Ŀ¼.Name = "btn����Ŀ¼";
            this.btn����Ŀ¼.Size = new System.Drawing.Size(81, 31);
            this.btn����Ŀ¼.TabIndex = 47;
            this.btn����Ŀ¼.Text = "����Ŀ¼";
            this.btn����Ŀ¼.Click += new System.EventHandler(this.btn����Ŀ¼_Click);
            // 
            // lbl����
            // 
            this.lbl����.Appearance.Font = new System.Drawing.Font("����", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl����.Appearance.Options.UseFont = true;
            this.lbl����.Location = new System.Drawing.Point(19, 15);
            this.lbl����.Name = "lbl����";
            this.lbl����.Size = new System.Drawing.Size(40, 19);
            this.lbl����.TabIndex = 44;
            this.lbl����.Text = "����";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileName = "н��ִ����ϸ��";
            this.saveFileDialog1.Filter = "Excel �ļ� | *.xls";
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
            this.Text = "��ְ����нִ�б�׼����Ȼ��ܱ�";
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
        private DevExpress.XtraEditors.LabelControl lbl����;
        private DevExpress.XtraEditors.SimpleButton btn����Ŀ¼;
        private DevExpress.XtraSpreadsheet.SpreadsheetControl spreadsheetControl1;
    }
}
