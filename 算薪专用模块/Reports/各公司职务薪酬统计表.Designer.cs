namespace Hwagain.SalaryCalculation
{
    partial class CompanySalaryJobCounterForm
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
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.endYear = new DevExpress.XtraEditors.SpinEdit();
            this.endMonth = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.startYear = new DevExpress.XtraEditors.SpinEdit();
            this.startMonth = new DevExpress.XtraEditors.ComboBoxEdit();
            this.btn查询 = new DevExpress.XtraEditors.SimpleButton();
            this.btn另存为 = new DevExpress.XtraEditors.SimpleButton();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.pivotGridControl1 = new DevExpress.XtraPivotGrid.PivotGridControl();
            this.col公司 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.col部门 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.col职等 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.人数 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.col金额 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.col季度 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.col年度 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.col月份 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.col职务 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.col平均 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.col省办 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.col体系 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.toBankReportItemBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ccb公司名称 = new DevExpress.XtraEditors.ImageComboBoxEdit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.endYear.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.endMonth.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.startYear.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.startMonth.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pivotGridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toBankReportItemBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ccb公司名称.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.ccb公司名称);
            this.panelControl1.Controls.Add(this.labelControl5);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.labelControl4);
            this.panelControl1.Controls.Add(this.endYear);
            this.panelControl1.Controls.Add(this.endMonth);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.labelControl3);
            this.panelControl1.Controls.Add(this.startYear);
            this.panelControl1.Controls.Add(this.startMonth);
            this.panelControl1.Controls.Add(this.btn查询);
            this.panelControl1.Controls.Add(this.btn另存为);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1020, 45);
            this.panelControl1.TabIndex = 3;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(213, 15);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(12, 14);
            this.labelControl5.TabIndex = 32;
            this.labelControl5.Text = "到";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(409, 15);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(12, 14);
            this.labelControl1.TabIndex = 31;
            this.labelControl1.Text = "月";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(326, 15);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(12, 14);
            this.labelControl4.TabIndex = 30;
            this.labelControl4.Text = "年";
            // 
            // endYear
            // 
            this.endYear.EditValue = new decimal(new int[] {
            2014,
            0,
            0,
            0});
            this.endYear.Location = new System.Drawing.Point(252, 12);
            this.endYear.Name = "endYear";
            this.endYear.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.endYear.Properties.MaxValue = new decimal(new int[] {
            2099,
            0,
            0,
            0});
            this.endYear.Properties.MinValue = new decimal(new int[] {
            2014,
            0,
            0,
            0});
            this.endYear.Size = new System.Drawing.Size(68, 20);
            this.endYear.TabIndex = 29;
            // 
            // endMonth
            // 
            this.endMonth.Location = new System.Drawing.Point(344, 13);
            this.endMonth.Name = "endMonth";
            this.endMonth.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.endMonth.Properties.Items.AddRange(new object[] {
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
            this.endMonth.Size = new System.Drawing.Size(59, 20);
            this.endMonth.TabIndex = 28;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(180, 15);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(12, 14);
            this.labelControl2.TabIndex = 27;
            this.labelControl2.Text = "月";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(97, 15);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(12, 14);
            this.labelControl3.TabIndex = 26;
            this.labelControl3.Text = "年";
            // 
            // startYear
            // 
            this.startYear.EditValue = new decimal(new int[] {
            2014,
            0,
            0,
            0});
            this.startYear.Location = new System.Drawing.Point(23, 12);
            this.startYear.Name = "startYear";
            this.startYear.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.startYear.Properties.MaxValue = new decimal(new int[] {
            2099,
            0,
            0,
            0});
            this.startYear.Properties.MinValue = new decimal(new int[] {
            2014,
            0,
            0,
            0});
            this.startYear.Size = new System.Drawing.Size(68, 20);
            this.startYear.TabIndex = 25;
            // 
            // startMonth
            // 
            this.startMonth.Location = new System.Drawing.Point(115, 13);
            this.startMonth.Name = "startMonth";
            this.startMonth.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.startMonth.Properties.Items.AddRange(new object[] {
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
            this.startMonth.Size = new System.Drawing.Size(59, 20);
            this.startMonth.TabIndex = 24;
            // 
            // btn查询
            // 
            this.btn查询.Location = new System.Drawing.Point(655, 11);
            this.btn查询.Name = "btn查询";
            this.btn查询.Size = new System.Drawing.Size(62, 23);
            this.btn查询.TabIndex = 21;
            this.btn查询.Text = "查询";
            this.btn查询.Click += new System.EventHandler(this.btn查询_Click);
            // 
            // btn另存为
            // 
            this.btn另存为.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn另存为.Location = new System.Drawing.Point(936, 12);
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
            // pivotGridControl1
            // 
            this.pivotGridControl1.Appearance.FieldValueGrandTotal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.pivotGridControl1.Appearance.FieldValueGrandTotal.Options.UseBackColor = true;
            this.pivotGridControl1.Appearance.FieldValueTotal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.pivotGridControl1.Appearance.FieldValueTotal.Options.UseBackColor = true;
            this.pivotGridControl1.Appearance.TotalCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.pivotGridControl1.Appearance.TotalCell.Options.UseBackColor = true;
            this.pivotGridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pivotGridControl1.Fields.AddRange(new DevExpress.XtraPivotGrid.PivotGridField[] {
            this.col公司,
            this.col部门,
            this.col职等,
            this.人数,
            this.col金额,
            this.col季度,
            this.col年度,
            this.col月份,
            this.col职务,
            this.col平均});
            this.pivotGridControl1.Location = new System.Drawing.Point(0, 45);
            this.pivotGridControl1.Name = "pivotGridControl1";
            this.pivotGridControl1.OptionsView.ShowDataHeaders = false;
            this.pivotGridControl1.Size = new System.Drawing.Size(1020, 378);
            this.pivotGridControl1.TabIndex = 4;
            this.pivotGridControl1.CellDoubleClick += new DevExpress.XtraPivotGrid.PivotCellEventHandler(this.pivotGridControl1_CellDoubleClick);
            // 
            // col公司
            // 
            this.col公司.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
            this.col公司.AreaIndex = 0;
            this.col公司.FieldName = "公司";
            this.col公司.Name = "col公司";
            // 
            // col部门
            // 
            this.col部门.AreaIndex = 3;
            this.col部门.Caption = "部门";
            this.col部门.FieldName = "部门";
            this.col部门.Name = "col部门";
            // 
            // col职等
            // 
            this.col职等.AreaIndex = 4;
            this.col职等.Caption = "级别";
            this.col职等.FieldName = "职等";
            this.col职等.Name = "col职等";
            // 
            // 人数
            // 
            this.人数.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.人数.AreaIndex = 0;
            this.人数.Caption = "人数";
            this.人数.FieldName = "员工编号";
            this.人数.Name = "人数";
            this.人数.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;
            this.人数.Width = 57;
            // 
            // col金额
            // 
            this.col金额.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.col金额.AreaIndex = 1;
            this.col金额.Caption = "金额";
            this.col金额.FieldName = "金额";
            this.col金额.Name = "col金额";
            this.col金额.Width = 85;
            // 
            // col季度
            // 
            this.col季度.AreaIndex = 2;
            this.col季度.Caption = "季度";
            this.col季度.FieldName = "季度";
            this.col季度.Name = "col季度";
            // 
            // col年度
            // 
            this.col年度.AreaIndex = 0;
            this.col年度.Caption = "年";
            this.col年度.FieldName = "年度";
            this.col年度.Name = "col年度";
            // 
            // col月份
            // 
            this.col月份.AreaIndex = 1;
            this.col月份.Caption = "月";
            this.col月份.FieldName = "月份";
            this.col月份.Name = "col月份";
            // 
            // col职务
            // 
            this.col职务.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.col职务.AreaIndex = 0;
            this.col职务.Caption = "职务";
            this.col职务.FieldName = "职务";
            this.col职务.Name = "col职务";
            this.col职务.Width = 125;
            // 
            // col平均
            // 
            this.col平均.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.col平均.AreaIndex = 2;
            this.col平均.Caption = "平均";
            this.col平均.FieldName = "金额";
            this.col平均.Name = "col平均";
            this.col平均.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Average;
            this.col平均.Width = 74;
            // 
            // col省办
            // 
            this.col省办.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.col省办.AreaIndex = 1;
            this.col省办.Caption = "省办";
            this.col省办.FieldName = "省办";
            this.col省办.Name = "col省办";
            // 
            // col体系
            // 
            this.col体系.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.col体系.AreaIndex = 0;
            this.col体系.Caption = "体系";
            this.col体系.FieldName = "体系";
            this.col体系.Name = "col体系";
            // 
            // toBankReportItemBindingSource
            // 
            this.toBankReportItemBindingSource.DataSource = typeof(Hwagain.SalaryCalculation.Components.ToBankReportItem);
            // 
            // ccb公司名称
            // 
            this.ccb公司名称.Location = new System.Drawing.Point(427, 13);
            this.ccb公司名称.Name = "ccb公司名称";
            this.ccb公司名称.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ccb公司名称.Properties.NullValuePrompt = "请选择查询的公司";
            this.ccb公司名称.Properties.NullValuePromptShowForEmptyValue = true;
            this.ccb公司名称.Size = new System.Drawing.Size(222, 20);
            this.ccb公司名称.TabIndex = 33;
            // 
            // CompanySalaryJobCounterForm
            // 
            this.ClientSize = new System.Drawing.Size(1020, 423);
            this.Controls.Add(this.pivotGridControl1);
            this.Controls.Add(this.panelControl1);
            this.LookAndFeel.SkinName = "Summer 2008";
            this.Name = "CompanySalaryJobCounterForm";
            this.Text = "各公司职务薪酬统计表";
            this.Load += new System.EventHandler(this.CompanySalaryJobCounterForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.endYear.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.endMonth.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.startYear.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.startMonth.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pivotGridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toBankReportItemBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ccb公司名称.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.ComponentModel.IContainer components = null;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.BindingSource toBankReportItemBindingSource;
        private DevExpress.XtraEditors.SimpleButton btn另存为;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private DevExpress.XtraEditors.SimpleButton btn查询;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.SpinEdit startYear;
        private DevExpress.XtraEditors.ComboBoxEdit startMonth;
        private DevExpress.XtraPivotGrid.PivotGridControl pivotGridControl1;
        private DevExpress.XtraPivotGrid.PivotGridField 人数;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.SpinEdit endYear;
        private DevExpress.XtraEditors.ComboBoxEdit endMonth;
        private DevExpress.XtraPivotGrid.PivotGridField col部门;
        private DevExpress.XtraPivotGrid.PivotGridField col职等;
        private DevExpress.XtraPivotGrid.PivotGridField col金额;
        private DevExpress.XtraPivotGrid.PivotGridField col季度;
        private DevExpress.XtraPivotGrid.PivotGridField col年度;
        private DevExpress.XtraPivotGrid.PivotGridField col月份;
        private DevExpress.XtraPivotGrid.PivotGridField col公司;
        private DevExpress.XtraPivotGrid.PivotGridField col省办;
        private DevExpress.XtraPivotGrid.PivotGridField col体系;
        private DevExpress.XtraPivotGrid.PivotGridField col职务;
        private DevExpress.XtraPivotGrid.PivotGridField col平均;
        private DevExpress.XtraEditors.ImageComboBoxEdit ccb公司名称;
           
    }
}
