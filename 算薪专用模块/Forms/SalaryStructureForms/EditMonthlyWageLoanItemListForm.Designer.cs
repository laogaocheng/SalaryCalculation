namespace Hwagain.SalaryCalculation
{
    partial class EditMonthlyWageLoanItemListForm
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
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.bandedGridView1 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridView();
            this.gridBand2 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.bandedGridColumn1 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand3 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.bandedGridColumn2 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand借款时间 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.bandedGridColumn3 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand上月剩余金额 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.bandedGridColumn6 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.合计 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.bandedGridColumn7 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand9 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.bandedGridColumn8 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.bandedGridColumn4 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand15 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.bandedGridColumn14 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.repositoryItemDateEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.comboBoxEdit月 = new DevExpress.XtraEditors.ComboBoxEdit();
            this.comboBoxEdit年 = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.lbl借款时间 = new DevExpress.XtraEditors.LabelControl();
            this.btn查询 = new DevExpress.XtraEditors.SimpleButton();
            this.btn添加 = new DevExpress.XtraEditors.SimpleButton();
            this.btn删除 = new DevExpress.XtraEditors.SimpleButton();
            this.btn保存 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bandedGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit月.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit年.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 48);
            this.gridControl1.MainView = this.bandedGridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemDateEdit1});
            this.gridControl1.Size = new System.Drawing.Size(700, 387);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.bandedGridView1});
            // 
            // bandedGridView1
            // 
            this.bandedGridView1.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand2,
            this.gridBand3,
            this.gridBand借款时间,
            this.gridBand上月剩余金额,
            this.合计,
            this.gridBand9,
            this.gridBand1,
            this.gridBand15});
            this.bandedGridView1.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.bandedGridColumn1,
            this.bandedGridColumn2,
            this.bandedGridColumn3,
            this.bandedGridColumn6,
            this.bandedGridColumn7,
            this.bandedGridColumn8,
            this.bandedGridColumn14,
            this.bandedGridColumn4});
            this.bandedGridView1.GridControl = this.gridControl1;
            this.bandedGridView1.Name = "bandedGridView1";
            this.bandedGridView1.NewItemRowText = "点击这里增加新动作";
            this.bandedGridView1.OptionsBehavior.Editable = false;
            this.bandedGridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.bandedGridView1.OptionsView.ColumnAutoWidth = false;
            this.bandedGridView1.OptionsView.ShowColumnHeaders = false;
            this.bandedGridView1.OptionsView.ShowGroupPanel = false;
            this.bandedGridView1.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.bandedGridView1_RowCellClick);
            this.bandedGridView1.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.bandedGridView1_CustomDrawCell);
            this.bandedGridView1.DoubleClick += new System.EventHandler(this.bandedGridView1_DoubleClick);
            // 
            // gridBand2
            // 
            this.gridBand2.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand2.Caption = "员工编号";
            this.gridBand2.Columns.Add(this.bandedGridColumn1);
            this.gridBand2.Name = "gridBand2";
            this.gridBand2.VisibleIndex = 0;
            // 
            // bandedGridColumn1
            // 
            this.bandedGridColumn1.AppearanceCell.Options.UseTextOptions = true;
            this.bandedGridColumn1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.bandedGridColumn1.Caption = "员工编号";
            this.bandedGridColumn1.FieldName = "员工编号";
            this.bandedGridColumn1.Name = "bandedGridColumn1";
            this.bandedGridColumn1.OptionsColumn.AllowEdit = false;
            this.bandedGridColumn1.OptionsColumn.ReadOnly = true;
            this.bandedGridColumn1.Visible = true;
            this.bandedGridColumn1.Width = 70;
            // 
            // gridBand3
            // 
            this.gridBand3.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand3.Caption = "姓名";
            this.gridBand3.Columns.Add(this.bandedGridColumn2);
            this.gridBand3.Name = "gridBand3";
            this.gridBand3.VisibleIndex = 1;
            this.gridBand3.Width = 63;
            // 
            // bandedGridColumn2
            // 
            this.bandedGridColumn2.AppearanceCell.Options.UseTextOptions = true;
            this.bandedGridColumn2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.bandedGridColumn2.Caption = "姓名";
            this.bandedGridColumn2.FieldName = "姓名";
            this.bandedGridColumn2.Name = "bandedGridColumn2";
            this.bandedGridColumn2.OptionsColumn.AllowEdit = false;
            this.bandedGridColumn2.OptionsColumn.ReadOnly = true;
            this.bandedGridColumn2.Visible = true;
            this.bandedGridColumn2.Width = 63;
            // 
            // gridBand借款时间
            // 
            this.gridBand借款时间.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand借款时间.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand借款时间.Caption = "借款时间";
            this.gridBand借款时间.Columns.Add(this.bandedGridColumn3);
            this.gridBand借款时间.Name = "gridBand借款时间";
            this.gridBand借款时间.VisibleIndex = 2;
            this.gridBand借款时间.Width = 82;
            // 
            // bandedGridColumn3
            // 
            this.bandedGridColumn3.AppearanceCell.Options.UseTextOptions = true;
            this.bandedGridColumn3.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.bandedGridColumn3.Caption = "借款时间";
            this.bandedGridColumn3.FieldName = "借款时间";
            this.bandedGridColumn3.Name = "bandedGridColumn3";
            this.bandedGridColumn3.OptionsColumn.ReadOnly = true;
            this.bandedGridColumn3.Visible = true;
            this.bandedGridColumn3.Width = 82;
            // 
            // gridBand上月剩余金额
            // 
            this.gridBand上月剩余金额.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand上月剩余金额.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand上月剩余金额.Caption = "实际借款金额";
            this.gridBand上月剩余金额.Columns.Add(this.bandedGridColumn6);
            this.gridBand上月剩余金额.Name = "gridBand上月剩余金额";
            this.gridBand上月剩余金额.VisibleIndex = 3;
            this.gridBand上月剩余金额.Width = 89;
            // 
            // bandedGridColumn6
            // 
            this.bandedGridColumn6.AppearanceCell.Options.UseTextOptions = true;
            this.bandedGridColumn6.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.bandedGridColumn6.Caption = "实际借款金额";
            this.bandedGridColumn6.DisplayFormat.FormatString = "{0:#0.##}";
            this.bandedGridColumn6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.bandedGridColumn6.FieldName = "实际借款金额";
            this.bandedGridColumn6.Name = "bandedGridColumn6";
            this.bandedGridColumn6.OptionsColumn.ReadOnly = true;
            this.bandedGridColumn6.Visible = true;
            this.bandedGridColumn6.Width = 89;
            // 
            // 合计
            // 
            this.合计.AppearanceHeader.Options.UseTextOptions = true;
            this.合计.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.合计.Caption = "代缴个税";
            this.合计.Columns.Add(this.bandedGridColumn7);
            this.合计.Name = "合计";
            this.合计.VisibleIndex = 4;
            this.合计.Width = 94;
            // 
            // bandedGridColumn7
            // 
            this.bandedGridColumn7.AppearanceCell.Options.UseTextOptions = true;
            this.bandedGridColumn7.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.bandedGridColumn7.Caption = "代缴个税";
            this.bandedGridColumn7.DisplayFormat.FormatString = "{0:#0.##}";
            this.bandedGridColumn7.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.bandedGridColumn7.FieldName = "代缴个税";
            this.bandedGridColumn7.Name = "bandedGridColumn7";
            this.bandedGridColumn7.OptionsColumn.ReadOnly = true;
            this.bandedGridColumn7.Visible = true;
            this.bandedGridColumn7.Width = 94;
            // 
            // gridBand9
            // 
            this.gridBand9.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand9.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand9.Caption = "税后实发金额";
            this.gridBand9.Columns.Add(this.bandedGridColumn8);
            this.gridBand9.Name = "gridBand9";
            this.gridBand9.VisibleIndex = 5;
            this.gridBand9.Width = 93;
            // 
            // bandedGridColumn8
            // 
            this.bandedGridColumn8.AppearanceCell.Options.UseTextOptions = true;
            this.bandedGridColumn8.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.bandedGridColumn8.Caption = "税后实发金额";
            this.bandedGridColumn8.DisplayFormat.FormatString = "{0:#0.##}";
            this.bandedGridColumn8.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.bandedGridColumn8.FieldName = "税后实发金额";
            this.bandedGridColumn8.Name = "bandedGridColumn8";
            this.bandedGridColumn8.OptionsColumn.ReadOnly = true;
            this.bandedGridColumn8.Visible = true;
            this.bandedGridColumn8.Width = 93;
            // 
            // gridBand1
            // 
            this.gridBand1.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand1.Caption = "录入人";
            this.gridBand1.Columns.Add(this.bandedGridColumn4);
            this.gridBand1.Name = "gridBand1";
            this.gridBand1.VisibleIndex = 6;
            this.gridBand1.Width = 63;
            // 
            // bandedGridColumn4
            // 
            this.bandedGridColumn4.Caption = "录入人";
            this.bandedGridColumn4.FieldName = "录入人";
            this.bandedGridColumn4.Name = "bandedGridColumn4";
            this.bandedGridColumn4.Visible = true;
            this.bandedGridColumn4.Width = 63;
            // 
            // gridBand15
            // 
            this.gridBand15.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand15.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand15.Caption = "#";
            this.gridBand15.Columns.Add(this.bandedGridColumn14);
            this.gridBand15.Name = "gridBand15";
            this.gridBand15.VisibleIndex = 7;
            this.gridBand15.Width = 56;
            // 
            // bandedGridColumn14
            // 
            this.bandedGridColumn14.AppearanceCell.Options.UseTextOptions = true;
            this.bandedGridColumn14.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.bandedGridColumn14.Caption = "录入";
            this.bandedGridColumn14.FieldName = "录入按钮文字";
            this.bandedGridColumn14.Name = "bandedGridColumn14";
            this.bandedGridColumn14.OptionsColumn.ReadOnly = true;
            this.bandedGridColumn14.Visible = true;
            this.bandedGridColumn14.Width = 56;
            // 
            // repositoryItemDateEdit1
            // 
            this.repositoryItemDateEdit1.AutoHeight = false;
            this.repositoryItemDateEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit1.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit1.Name = "repositoryItemDateEdit1";
            this.repositoryItemDateEdit1.NullDate = new System.DateTime(((long)(0)));
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.labelControl8);
            this.panelControl1.Controls.Add(this.comboBoxEdit月);
            this.panelControl1.Controls.Add(this.comboBoxEdit年);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.lbl借款时间);
            this.panelControl1.Controls.Add(this.btn查询);
            this.panelControl1.Controls.Add(this.btn添加);
            this.panelControl1.Controls.Add(this.btn删除);
            this.panelControl1.Controls.Add(this.btn保存);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(700, 48);
            this.panelControl1.TabIndex = 3;
            // 
            // labelControl8
            // 
            this.labelControl8.Appearance.Font = new System.Drawing.Font("华文宋体", 12F);
            this.labelControl8.Appearance.Options.UseFont = true;
            this.labelControl8.Location = new System.Drawing.Point(545, 25);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(64, 18);
            this.labelControl8.TabIndex = 83;
            this.labelControl8.Text = "单位：元";
            // 
            // comboBoxEdit月
            // 
            this.comboBoxEdit月.Location = new System.Drawing.Point(189, 15);
            this.comboBoxEdit月.Name = "comboBoxEdit月";
            this.comboBoxEdit月.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEdit月.Properties.Items.AddRange(new object[] {
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
            this.comboBoxEdit月.Size = new System.Drawing.Size(52, 20);
            this.comboBoxEdit月.TabIndex = 48;
            this.comboBoxEdit月.SelectedValueChanged += new System.EventHandler(this.comboBoxEdit月_SelectedValueChanged);
            // 
            // comboBoxEdit年
            // 
            this.comboBoxEdit年.Location = new System.Drawing.Point(98, 15);
            this.comboBoxEdit年.Name = "comboBoxEdit年";
            this.comboBoxEdit年.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEdit年.Size = new System.Drawing.Size(67, 20);
            this.comboBoxEdit年.TabIndex = 47;
            this.comboBoxEdit年.SelectedValueChanged += new System.EventHandler(this.comboBoxEdit年_SelectedValueChanged);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(247, 18);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(12, 14);
            this.labelControl2.TabIndex = 46;
            this.labelControl2.Text = "月";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(171, 18);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(12, 14);
            this.labelControl1.TabIndex = 45;
            this.labelControl1.Text = "年";
            // 
            // lbl借款时间
            // 
            this.lbl借款时间.Appearance.Font = new System.Drawing.Font("华文宋体", 12F);
            this.lbl借款时间.Appearance.Options.UseFont = true;
            this.lbl借款时间.Location = new System.Drawing.Point(12, 16);
            this.lbl借款时间.Name = "lbl借款时间";
            this.lbl借款时间.Size = new System.Drawing.Size(80, 18);
            this.lbl借款时间.TabIndex = 44;
            this.lbl借款时间.Text = "借款时间：";
            // 
            // btn查询
            // 
            this.btn查询.Location = new System.Drawing.Point(288, 14);
            this.btn查询.Name = "btn查询";
            this.btn查询.Size = new System.Drawing.Size(62, 23);
            this.btn查询.TabIndex = 3;
            this.btn查询.Text = "查询";
            this.btn查询.Click += new System.EventHandler(this.btn刷新_Click);
            // 
            // btn添加
            // 
            this.btn添加.Location = new System.Drawing.Point(356, 14);
            this.btn添加.Name = "btn添加";
            this.btn添加.Size = new System.Drawing.Size(62, 23);
            this.btn添加.TabIndex = 2;
            this.btn添加.Text = "添加";
            this.btn添加.Click += new System.EventHandler(this.btn添加_Click);
            // 
            // btn删除
            // 
            this.btn删除.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn删除.Location = new System.Drawing.Point(626, 12);
            this.btn删除.Name = "btn删除";
            this.btn删除.Size = new System.Drawing.Size(62, 23);
            this.btn删除.TabIndex = 1;
            this.btn删除.Text = "删除";
            this.btn删除.Click += new System.EventHandler(this.btn删除_Click);
            // 
            // btn保存
            // 
            this.btn保存.Location = new System.Drawing.Point(424, 14);
            this.btn保存.Name = "btn保存";
            this.btn保存.Size = new System.Drawing.Size(76, 23);
            this.btn保存.TabIndex = 0;
            this.btn保存.Text = "提交完成";
            this.btn保存.Click += new System.EventHandler(this.btn保存_Click);
            // 
            // EditMonthlyWageLoanItemListForm
            // 
            this.ClientSize = new System.Drawing.Size(700, 435);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.panelControl1);
            this.LookAndFeel.SkinName = "Summer 2008";
            this.Name = "EditMonthlyWageLoanItemListForm";
            this.Text = "每月工资借款录入";
            this.Load += new System.EventHandler(this.EditMonthlyWageLoanItemForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bandedGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit月.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit年.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.ComponentModel.IContainer components = null;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btn保存;
        private DevExpress.XtraEditors.SimpleButton btn删除;
        private DevExpress.XtraEditors.SimpleButton btn添加;
        private DevExpress.XtraEditors.SimpleButton btn查询;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit1;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridView bandedGridView1;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn1;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn2;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn3;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn7;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn6;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn8;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn14;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn4;
        private DevExpress.XtraEditors.LabelControl lbl借款时间;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand2;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand3;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand借款时间;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand上月剩余金额;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand 合计;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand9;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand1;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand15;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit月;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit年;
        private DevExpress.XtraEditors.LabelControl labelControl8;
    }
}
