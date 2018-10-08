namespace Hwagain.SalaryCalculation
{
    partial class TraineeAnnualAssessmentForm
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
            this.btn查漏 = new DevExpress.XtraEditors.SimpleButton();
            this.btn返回目录 = new DevExpress.XtraEditors.SimpleButton();
            this.lbl标题 = new DevExpress.XtraEditors.LabelControl();
            this.btn保存提交 = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.monthlySalaryInputBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.advBandedGridView1 = new DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView();
            this.gridBand20 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.序号 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand13 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.姓名 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand公司 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.公司 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand届别 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.届别 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand岗位级别 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.岗位级别 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand14 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.能力级别 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.repositoryItemLevel = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.gridBand18 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridBand2 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.员工编号 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand5 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridBand10 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridBand9 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridBand17 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.标识 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.年度 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.btn更新名单 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.monthlySalaryInputBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.advBandedGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLevel)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btn更新名单);
            this.panelControl1.Controls.Add(this.btn查漏);
            this.panelControl1.Controls.Add(this.btn返回目录);
            this.panelControl1.Controls.Add(this.lbl标题);
            this.panelControl1.Controls.Add(this.btn保存提交);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(462, 78);
            this.panelControl1.TabIndex = 4;
            // 
            // btn查漏
            // 
            this.btn查漏.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn查漏.Location = new System.Drawing.Point(-561, 38);
            this.btn查漏.Name = "btn查漏";
            this.btn查漏.Size = new System.Drawing.Size(65, 22);
            this.btn查漏.TabIndex = 50;
            this.btn查漏.Text = "更新名单";
            this.btn查漏.Click += new System.EventHandler(this.btn查漏_Click);
            // 
            // btn返回目录
            // 
            this.btn返回目录.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn返回目录.Location = new System.Drawing.Point(369, 41);
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
            this.lbl标题.Location = new System.Drawing.Point(19, 12);
            this.lbl标题.Name = "lbl标题";
            this.lbl标题.Size = new System.Drawing.Size(40, 19);
            this.lbl标题.TabIndex = 44;
            this.lbl标题.Text = "标题";
            // 
            // btn保存提交
            // 
            this.btn保存提交.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn保存提交.Location = new System.Drawing.Point(289, 41);
            this.btn保存提交.Name = "btn保存提交";
            this.btn保存提交.Size = new System.Drawing.Size(74, 31);
            this.btn保存提交.TabIndex = 35;
            this.btn保存提交.Text = "保存提交";
            this.btn保存提交.Click += new System.EventHandler(this.btn保存提交_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridControl1.DataSource = this.monthlySalaryInputBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 78);
            this.gridControl1.MainView = this.advBandedGridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemLevel});
            this.gridControl1.Size = new System.Drawing.Size(462, 502);
            this.gridControl1.TabIndex = 5;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.advBandedGridView1});
            // 
            // monthlySalaryInputBindingSource
            // 
            this.monthlySalaryInputBindingSource.DataSource = typeof(Hwagain.SalaryCalculation.Components.MonthlySalaryInput);
            // 
            // advBandedGridView1
            // 
            this.advBandedGridView1.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand20,
            this.gridBand13,
            this.gridBand公司,
            this.gridBand届别,
            this.gridBand岗位级别,
            this.gridBand14,
            this.gridBand18,
            this.gridBand2,
            this.gridBand5,
            this.gridBand17});
            this.advBandedGridView1.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.标识,
            this.序号,
            this.公司,
            this.届别,
            this.岗位级别,
            this.年度,
            this.员工编号,
            this.姓名,
            this.能力级别});
            this.advBandedGridView1.GridControl = this.gridControl1;
            this.advBandedGridView1.Name = "advBandedGridView1";
            this.advBandedGridView1.NewItemRowText = "点击这里增加新动作";
            this.advBandedGridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.advBandedGridView1.OptionsView.ShowColumnHeaders = false;
            this.advBandedGridView1.OptionsView.ShowGroupPanel = false;
            this.advBandedGridView1.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.gridView1_CustomDrawCell);
            this.advBandedGridView1.ShowingEditor += new System.ComponentModel.CancelEventHandler(this.advBandedGridView1_ShowingEditor);
            this.advBandedGridView1.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.advBandedGridView1_CellValueChanged);
            // 
            // gridBand20
            // 
            this.gridBand20.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand20.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand20.Caption = "序号";
            this.gridBand20.Columns.Add(this.序号);
            this.gridBand20.Name = "gridBand20";
            this.gridBand20.VisibleIndex = 0;
            this.gridBand20.Width = 41;
            // 
            // 序号
            // 
            this.序号.AppearanceCell.Options.UseTextOptions = true;
            this.序号.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.序号.AppearanceHeader.Options.UseTextOptions = true;
            this.序号.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.序号.Caption = "序号";
            this.序号.FieldName = "序号";
            this.序号.Name = "序号";
            this.序号.OptionsColumn.AllowEdit = false;
            this.序号.OptionsColumn.ReadOnly = true;
            this.序号.Visible = true;
            this.序号.Width = 41;
            // 
            // gridBand13
            // 
            this.gridBand13.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand13.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand13.Caption = "姓名";
            this.gridBand13.Columns.Add(this.姓名);
            this.gridBand13.Name = "gridBand13";
            this.gridBand13.VisibleIndex = 1;
            this.gridBand13.Width = 63;
            // 
            // 姓名
            // 
            this.姓名.AppearanceCell.Options.UseTextOptions = true;
            this.姓名.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.姓名.AppearanceHeader.Options.UseTextOptions = true;
            this.姓名.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.姓名.Caption = "姓名";
            this.姓名.FieldName = "姓名";
            this.姓名.Name = "姓名";
            this.姓名.OptionsColumn.AllowEdit = false;
            this.姓名.OptionsColumn.ReadOnly = true;
            this.姓名.Visible = true;
            this.姓名.Width = 63;
            // 
            // gridBand公司
            // 
            this.gridBand公司.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand公司.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand公司.Caption = "公司";
            this.gridBand公司.Columns.Add(this.公司);
            this.gridBand公司.Name = "gridBand公司";
            this.gridBand公司.VisibleIndex = 2;
            this.gridBand公司.Width = 86;
            // 
            // 公司
            // 
            this.公司.Caption = "公司";
            this.公司.FieldName = "公司";
            this.公司.Name = "公司";
            this.公司.OptionsColumn.AllowEdit = false;
            this.公司.OptionsColumn.ReadOnly = true;
            this.公司.Visible = true;
            this.公司.Width = 86;
            // 
            // gridBand届别
            // 
            this.gridBand届别.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand届别.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand届别.Caption = "届别";
            this.gridBand届别.Columns.Add(this.届别);
            this.gridBand届别.Name = "gridBand届别";
            this.gridBand届别.VisibleIndex = 3;
            this.gridBand届别.Width = 48;
            // 
            // 届别
            // 
            this.届别.AppearanceCell.Options.UseTextOptions = true;
            this.届别.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.届别.AppearanceHeader.Options.UseTextOptions = true;
            this.届别.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.届别.Caption = "届别";
            this.届别.FieldName = "届别";
            this.届别.Name = "届别";
            this.届别.OptionsColumn.AllowEdit = false;
            this.届别.OptionsColumn.ReadOnly = true;
            this.届别.Visible = true;
            this.届别.Width = 48;
            // 
            // gridBand岗位级别
            // 
            this.gridBand岗位级别.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand岗位级别.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand岗位级别.Caption = "岗位级别";
            this.gridBand岗位级别.Columns.Add(this.岗位级别);
            this.gridBand岗位级别.Name = "gridBand岗位级别";
            this.gridBand岗位级别.VisibleIndex = 4;
            this.gridBand岗位级别.Width = 67;
            // 
            // 岗位级别
            // 
            this.岗位级别.AppearanceCell.Options.UseTextOptions = true;
            this.岗位级别.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.岗位级别.AppearanceHeader.Options.UseTextOptions = true;
            this.岗位级别.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.岗位级别.Caption = "岗位级别";
            this.岗位级别.FieldName = "岗位级别";
            this.岗位级别.Name = "岗位级别";
            this.岗位级别.OptionsColumn.AllowEdit = false;
            this.岗位级别.OptionsColumn.ReadOnly = true;
            this.岗位级别.Visible = true;
            this.岗位级别.Width = 67;
            // 
            // gridBand14
            // 
            this.gridBand14.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand14.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand14.Caption = "能力级别";
            this.gridBand14.Columns.Add(this.能力级别);
            this.gridBand14.Name = "gridBand14";
            this.gridBand14.VisibleIndex = 5;
            this.gridBand14.Width = 72;
            // 
            // 能力级别
            // 
            this.能力级别.AppearanceCell.Options.UseTextOptions = true;
            this.能力级别.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.能力级别.AppearanceHeader.Options.UseTextOptions = true;
            this.能力级别.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.能力级别.Caption = "能力级别";
            this.能力级别.ColumnEdit = this.repositoryItemLevel;
            this.能力级别.FieldName = "能力级别";
            this.能力级别.Name = "能力级别";
            this.能力级别.Visible = true;
            this.能力级别.Width = 72;
            // 
            // repositoryItemLevel
            // 
            this.repositoryItemLevel.AutoHeight = false;
            this.repositoryItemLevel.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLevel.Items.AddRange(new object[] {
            "A",
            "B",
            "C"});
            this.repositoryItemLevel.Name = "repositoryItemLevel";
            this.repositoryItemLevel.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            // 
            // gridBand18
            // 
            this.gridBand18.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand18.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand18.Caption = "备注";
            this.gridBand18.Name = "gridBand18";
            this.gridBand18.Visible = false;
            this.gridBand18.VisibleIndex = -1;
            this.gridBand18.Width = 107;
            // 
            // gridBand2
            // 
            this.gridBand2.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand2.Caption = "员工编号";
            this.gridBand2.Columns.Add(this.员工编号);
            this.gridBand2.Name = "gridBand2";
            this.gridBand2.Visible = false;
            this.gridBand2.VisibleIndex = -1;
            this.gridBand2.Width = 68;
            // 
            // 员工编号
            // 
            this.员工编号.AppearanceCell.Options.UseTextOptions = true;
            this.员工编号.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.员工编号.Caption = "员工编号";
            this.员工编号.FieldName = "员工编号";
            this.员工编号.Name = "员工编号";
            this.员工编号.OptionsColumn.AllowEdit = false;
            this.员工编号.OptionsColumn.ReadOnly = true;
            this.员工编号.Visible = true;
            this.员工编号.Width = 68;
            // 
            // gridBand5
            // 
            this.gridBand5.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand5.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand5.Caption = "确定执行职级、月薪";
            this.gridBand5.Children.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand10,
            this.gridBand9});
            this.gridBand5.Name = "gridBand5";
            this.gridBand5.Visible = false;
            this.gridBand5.VisibleIndex = -1;
            this.gridBand5.Width = 134;
            // 
            // gridBand10
            // 
            this.gridBand10.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand10.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand10.Caption = "月薪类型";
            this.gridBand10.Name = "gridBand10";
            this.gridBand10.VisibleIndex = 0;
            this.gridBand10.Width = 67;
            // 
            // gridBand9
            // 
            this.gridBand9.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand9.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand9.Caption = "月薪";
            this.gridBand9.Name = "gridBand9";
            this.gridBand9.VisibleIndex = 1;
            this.gridBand9.Width = 67;
            // 
            // gridBand17
            // 
            this.gridBand17.Caption = "开始执行日期";
            this.gridBand17.Name = "gridBand17";
            this.gridBand17.Visible = false;
            this.gridBand17.VisibleIndex = -1;
            this.gridBand17.Width = 99;
            // 
            // 标识
            // 
            this.标识.Caption = "标识";
            this.标识.FieldName = "标识";
            this.标识.Name = "标识";
            this.标识.Width = 67;
            // 
            // 年度
            // 
            this.年度.AppearanceCell.Options.UseTextOptions = true;
            this.年度.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.年度.AppearanceHeader.Options.UseTextOptions = true;
            this.年度.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.年度.Caption = "年度";
            this.年度.FieldName = "年度";
            this.年度.Name = "年度";
            this.年度.OptionsColumn.AllowEdit = false;
            this.年度.OptionsColumn.ReadOnly = true;
            this.年度.Width = 80;
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileName = "薪酬执行明细表";
            this.saveFileDialog1.Filter = "Excel 文件 | *.xls";
            // 
            // btn更新名单
            // 
            this.btn更新名单.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn更新名单.Location = new System.Drawing.Point(202, 50);
            this.btn更新名单.Name = "btn更新名单";
            this.btn更新名单.Size = new System.Drawing.Size(65, 22);
            this.btn更新名单.TabIndex = 51;
            this.btn更新名单.Text = "更新名单";
            this.btn更新名单.Click += new System.EventHandler(this.btn更新名单_Click);
            // 
            // TraineeAnnualAssessmentForm
            // 
            this.ClientSize = new System.Drawing.Size(462, 580);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.panelControl1);
            this.LookAndFeel.SkinName = "Summer 2008";
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TraineeAnnualAssessmentForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "能力评定录入";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AdjustMonthlySalaryForm_FormClosed);
            this.Load += new System.EventHandler(this.AdjustMonthlySalaryForm_Load);
            this.Shown += new System.EventHandler(this.AdjustMonthlySalaryForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.monthlySalaryInputBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.advBandedGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLevel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.ComponentModel.IContainer components = null;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraEditors.SimpleButton btn保存提交;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.BindingSource monthlySalaryInputBindingSource;
        private DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView advBandedGridView1;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn 序号;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn 员工编号;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn 岗位级别;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn 标识;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn 年度;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemLevel;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn 姓名;
        private DevExpress.XtraEditors.LabelControl lbl标题;
        private DevExpress.XtraEditors.SimpleButton btn返回目录;
        private DevExpress.XtraEditors.SimpleButton btn查漏;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn 届别;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn 能力级别;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand20;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand13;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand公司;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn 公司;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand届别;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand岗位级别;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand14;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand18;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand2;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand5;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand10;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand9;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand17;
        private DevExpress.XtraEditors.SimpleButton btn更新名单;
    }
}
