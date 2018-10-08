namespace Hwagain.SalaryCalculation
{
    partial class PrivateSalaryPayItemsForm
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
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.year = new DevExpress.XtraEditors.SpinEdit();
            this.month = new DevExpress.XtraEditors.ComboBoxEdit();
            this.btn按发放单位查询 = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.ccb发放单位 = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.btn打印 = new DevExpress.XtraEditors.SimpleButton();
            this.btn另存为 = new DevExpress.XtraEditors.SimpleButton();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.documentViewer1 = new DevExpress.XtraPrinting.Preview.DocumentViewer();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.ccb银行 = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.toBankReportItemBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.year.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.month.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ccb发放单位.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ccb银行.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toBankReportItemBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.labelControl4);
            this.panelControl1.Controls.Add(this.ccb银行);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.labelControl3);
            this.panelControl1.Controls.Add(this.year);
            this.panelControl1.Controls.Add(this.month);
            this.panelControl1.Controls.Add(this.btn按发放单位查询);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.ccb发放单位);
            this.panelControl1.Controls.Add(this.btn打印);
            this.panelControl1.Controls.Add(this.btn另存为);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1020, 45);
            this.panelControl1.TabIndex = 3;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(168, 14);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(12, 14);
            this.labelControl2.TabIndex = 31;
            this.labelControl2.Text = "月";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(96, 14);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(12, 14);
            this.labelControl3.TabIndex = 30;
            this.labelControl3.Text = "年";
            // 
            // year
            // 
            this.year.EditValue = new decimal(new int[] {
            2014,
            0,
            0,
            0});
            this.year.Location = new System.Drawing.Point(22, 11);
            this.year.Name = "year";
            this.year.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.year.Properties.MaxValue = new decimal(new int[] {
            2099,
            0,
            0,
            0});
            this.year.Properties.MinValue = new decimal(new int[] {
            2014,
            0,
            0,
            0});
            this.year.Size = new System.Drawing.Size(68, 20);
            this.year.TabIndex = 29;
            // 
            // month
            // 
            this.month.Location = new System.Drawing.Point(114, 12);
            this.month.Name = "month";
            this.month.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.month.Properties.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.month.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.month.Size = new System.Drawing.Size(48, 20);
            this.month.TabIndex = 28;
            // 
            // btn按发放单位查询
            // 
            this.btn按发放单位查询.Location = new System.Drawing.Point(630, 10);
            this.btn按发放单位查询.Name = "btn按发放单位查询";
            this.btn按发放单位查询.Size = new System.Drawing.Size(62, 23);
            this.btn按发放单位查询.TabIndex = 24;
            this.btn按发放单位查询.Text = "查询";
            this.btn按发放单位查询.Click += new System.EventHandler(this.btn按发放单位查询_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(186, 14);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(48, 14);
            this.labelControl1.TabIndex = 26;
            this.labelControl1.Text = "发放单位";
            // 
            // ccb发放单位
            // 
            this.ccb发放单位.Location = new System.Drawing.Point(240, 12);
            this.ccb发放单位.Name = "ccb发放单位";
            this.ccb发放单位.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ccb发放单位.Size = new System.Drawing.Size(174, 20);
            this.ccb发放单位.TabIndex = 25;
            // 
            // btn打印
            // 
            this.btn打印.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn打印.Location = new System.Drawing.Point(945, 11);
            this.btn打印.Name = "btn打印";
            this.btn打印.Size = new System.Drawing.Size(62, 23);
            this.btn打印.TabIndex = 11;
            this.btn打印.Text = "打印";
            this.btn打印.Click += new System.EventHandler(this.btn打印_Click);
            // 
            // btn另存为
            // 
            this.btn另存为.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn另存为.Location = new System.Drawing.Point(877, 11);
            this.btn另存为.Name = "btn另存为";
            this.btn另存为.Size = new System.Drawing.Size(62, 23);
            this.btn另存为.TabIndex = 10;
            this.btn另存为.Text = "另存为";
            this.btn另存为.Click += new System.EventHandler(this.btn另存为_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileName = "银行报盘表";
            this.saveFileDialog1.Filter = "Excel 文件 | *.xls";
            // 
            // documentViewer1
            // 
            this.documentViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.documentViewer1.IsMetric = true;
            this.documentViewer1.Location = new System.Drawing.Point(0, 45);
            this.documentViewer1.Name = "documentViewer1";
            this.documentViewer1.Size = new System.Drawing.Size(1020, 378);
            this.documentViewer1.TabIndex = 4;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(449, 15);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(24, 14);
            this.labelControl4.TabIndex = 33;
            this.labelControl4.Text = "银行";
            // 
            // ccb银行
            // 
            this.ccb银行.Location = new System.Drawing.Point(479, 12);
            this.ccb银行.Name = "ccb银行";
            this.ccb银行.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ccb银行.Size = new System.Drawing.Size(145, 20);
            this.ccb银行.TabIndex = 32;
            // 
            // toBankReportItemBindingSource
            // 
            this.toBankReportItemBindingSource.DataSource = typeof(Hwagain.SalaryCalculation.Components.ToBankReportItem);
            // 
            // PrivateSalaryPayItemsForm
            // 
            this.ClientSize = new System.Drawing.Size(1020, 423);
            this.Controls.Add(this.documentViewer1);
            this.Controls.Add(this.panelControl1);
            this.LookAndFeel.SkinName = "Summer 2008";
            this.Name = "PrivateSalaryPayItemsForm";
            this.Text = "职工封闭工资发放清单";
            this.Load += new System.EventHandler(this.PrivateSalaryPayItemsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.year.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.month.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ccb发放单位.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ccb银行.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toBankReportItemBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.ComponentModel.IContainer components = null;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.BindingSource toBankReportItemBindingSource;
        private DevExpress.XtraEditors.SimpleButton btn另存为;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private DevExpress.XtraPrinting.Preview.DocumentViewer documentViewer1;
        private DevExpress.XtraEditors.SimpleButton btn打印;
        private DevExpress.XtraEditors.SimpleButton btn按发放单位查询;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.ImageComboBoxEdit ccb发放单位;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.SpinEdit year;
        private DevExpress.XtraEditors.ComboBoxEdit month;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.ImageComboBoxEdit ccb银行;
    }
}
