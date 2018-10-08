namespace Hwagain.SalaryCalculation
{
    partial class SearchRembursementSalaryForm
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
            this.gridBand开始时间 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.bandedGridColumn3 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.repositoryItemDateEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.gridBand结束时间 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.bandedGridColumn5 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand9 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridBand1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.bandedGridColumn8 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand4 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.bandedGridColumn9 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand7 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridBand5 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.bandedGridColumn7 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand6 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.bandedGridColumn6 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn4 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.textEdit关键字 = new DevExpress.XtraEditors.TextEdit();
            this.btn查询 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bandedGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit关键字.Properties)).BeginInit();
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
            this.gridControl1.Size = new System.Drawing.Size(774, 387);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.bandedGridView1});
            // 
            // bandedGridView1
            // 
            this.bandedGridView1.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand2,
            this.gridBand3,
            this.gridBand开始时间,
            this.gridBand结束时间,
            this.gridBand9,
            this.gridBand7});
            this.bandedGridView1.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.bandedGridColumn1,
            this.bandedGridColumn2,
            this.bandedGridColumn3,
            this.bandedGridColumn5,
            this.bandedGridColumn8,
            this.bandedGridColumn9,
            this.bandedGridColumn4,
            this.bandedGridColumn6,
            this.bandedGridColumn7});
            this.bandedGridView1.GridControl = this.gridControl1;
            this.bandedGridView1.Name = "bandedGridView1";
            this.bandedGridView1.NewItemRowText = "点击这里增加新动作";
            this.bandedGridView1.OptionsBehavior.Editable = false;
            this.bandedGridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.bandedGridView1.OptionsView.ColumnAutoWidth = false;
            this.bandedGridView1.OptionsView.ShowColumnHeaders = false;
            this.bandedGridView1.OptionsView.ShowDetailButtons = false;
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
            // gridBand开始时间
            // 
            this.gridBand开始时间.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand开始时间.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand开始时间.Caption = "开始时间";
            this.gridBand开始时间.Columns.Add(this.bandedGridColumn3);
            this.gridBand开始时间.Name = "gridBand开始时间";
            this.gridBand开始时间.VisibleIndex = 2;
            this.gridBand开始时间.Width = 100;
            // 
            // bandedGridColumn3
            // 
            this.bandedGridColumn3.AppearanceCell.Options.UseTextOptions = true;
            this.bandedGridColumn3.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.bandedGridColumn3.Caption = "开始时间";
            this.bandedGridColumn3.ColumnEdit = this.repositoryItemDateEdit1;
            this.bandedGridColumn3.FieldName = "开始时间";
            this.bandedGridColumn3.Name = "bandedGridColumn3";
            this.bandedGridColumn3.OptionsColumn.ReadOnly = true;
            this.bandedGridColumn3.Visible = true;
            this.bandedGridColumn3.Width = 100;
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
            // gridBand结束时间
            // 
            this.gridBand结束时间.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand结束时间.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand结束时间.Caption = "结束时间";
            this.gridBand结束时间.Columns.Add(this.bandedGridColumn5);
            this.gridBand结束时间.Name = "gridBand结束时间";
            this.gridBand结束时间.VisibleIndex = 3;
            this.gridBand结束时间.Width = 100;
            // 
            // bandedGridColumn5
            // 
            this.bandedGridColumn5.AppearanceCell.Options.UseTextOptions = true;
            this.bandedGridColumn5.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.bandedGridColumn5.Caption = "结束时间";
            this.bandedGridColumn5.ColumnEdit = this.repositoryItemDateEdit1;
            this.bandedGridColumn5.FieldName = "结束时间";
            this.bandedGridColumn5.Name = "bandedGridColumn5";
            this.bandedGridColumn5.OptionsColumn.ReadOnly = true;
            this.bandedGridColumn5.Visible = true;
            this.bandedGridColumn5.Width = 100;
            // 
            // gridBand9
            // 
            this.gridBand9.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand9.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand9.Caption = "报账标准（税前）";
            this.gridBand9.Children.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand4,
            this.gridBand1});
            this.gridBand9.Name = "gridBand9";
            this.gridBand9.VisibleIndex = 4;
            this.gridBand9.Width = 200;
            // 
            // gridBand1
            // 
            this.gridBand1.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand1.Caption = "年度";
            this.gridBand1.Columns.Add(this.bandedGridColumn8);
            this.gridBand1.Name = "gridBand1";
            this.gridBand1.VisibleIndex = 0;
            this.gridBand1.Width = 100;
            // 
            // bandedGridColumn8
            // 
            this.bandedGridColumn8.AppearanceCell.Options.UseTextOptions = true;
            this.bandedGridColumn8.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.bandedGridColumn8.Caption = "年度可报账标准_税前";
            this.bandedGridColumn8.DisplayFormat.FormatString = "{0:#0.##}";
            this.bandedGridColumn8.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.bandedGridColumn8.FieldName = "年度可报账标准_税前";
            this.bandedGridColumn8.Name = "bandedGridColumn8";
            this.bandedGridColumn8.OptionsColumn.ReadOnly = true;
            this.bandedGridColumn8.Visible = true;
            this.bandedGridColumn8.Width = 100;
            // 
            // gridBand4
            // 
            this.gridBand4.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand4.Caption = "月度";
            this.gridBand4.Columns.Add(this.bandedGridColumn9);
            this.gridBand4.Name = "gridBand4";
            this.gridBand4.VisibleIndex = 1;
            this.gridBand4.Width = 100;
            // 
            // bandedGridColumn9
            // 
            this.bandedGridColumn9.AppearanceCell.Options.UseTextOptions = true;
            this.bandedGridColumn9.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.bandedGridColumn9.Caption = "月度可报账标准_税前";
            this.bandedGridColumn9.DisplayFormat.FormatString = "{0:#0.##}";
            this.bandedGridColumn9.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.bandedGridColumn9.FieldName = "月度可报账标准_税前";
            this.bandedGridColumn9.Name = "bandedGridColumn9";
            this.bandedGridColumn9.OptionsColumn.ReadOnly = true;
            this.bandedGridColumn9.Visible = true;
            this.bandedGridColumn9.Width = 100;
            // 
            // gridBand7
            // 
            this.gridBand7.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand7.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand7.Caption = "报账标准（税后）";
            this.gridBand7.Children.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand6,
            this.gridBand5});
            this.gridBand7.Name = "gridBand7";
            this.gridBand7.VisibleIndex = 5;
            this.gridBand7.Width = 200;
            // 
            // gridBand5
            // 
            this.gridBand5.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand5.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand5.Caption = "年度";
            this.gridBand5.Columns.Add(this.bandedGridColumn7);
            this.gridBand5.Name = "gridBand5";
            this.gridBand5.VisibleIndex = 0;
            this.gridBand5.Width = 100;
            // 
            // bandedGridColumn7
            // 
            this.bandedGridColumn7.AppearanceCell.Options.UseTextOptions = true;
            this.bandedGridColumn7.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.bandedGridColumn7.Caption = "年度可报账标准_税后";
            this.bandedGridColumn7.DisplayFormat.FormatString = "{0:#0.##}";
            this.bandedGridColumn7.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.bandedGridColumn7.FieldName = "年度可报账标准_税后";
            this.bandedGridColumn7.Name = "bandedGridColumn7";
            this.bandedGridColumn7.Visible = true;
            this.bandedGridColumn7.Width = 100;
            // 
            // gridBand6
            // 
            this.gridBand6.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand6.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand6.Caption = "月度";
            this.gridBand6.Columns.Add(this.bandedGridColumn6);
            this.gridBand6.Name = "gridBand6";
            this.gridBand6.VisibleIndex = 1;
            this.gridBand6.Width = 100;
            // 
            // bandedGridColumn6
            // 
            this.bandedGridColumn6.AppearanceCell.Options.UseTextOptions = true;
            this.bandedGridColumn6.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.bandedGridColumn6.Caption = "月度可报账标准_税后";
            this.bandedGridColumn6.DisplayFormat.FormatString = "{0:#0.##}";
            this.bandedGridColumn6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.bandedGridColumn6.FieldName = "月度可报账标准_税后";
            this.bandedGridColumn6.Name = "bandedGridColumn6";
            this.bandedGridColumn6.Visible = true;
            this.bandedGridColumn6.Width = 100;
            // 
            // bandedGridColumn4
            // 
            this.bandedGridColumn4.AppearanceCell.Options.UseTextOptions = true;
            this.bandedGridColumn4.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.bandedGridColumn4.Caption = "提交时间";
            this.bandedGridColumn4.FieldName = "创建时间";
            this.bandedGridColumn4.Name = "bandedGridColumn4";
            this.bandedGridColumn4.Visible = true;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.textEdit关键字);
            this.panelControl1.Controls.Add(this.btn查询);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(774, 48);
            this.panelControl1.TabIndex = 3;
            // 
            // textEdit关键字
            // 
            this.textEdit关键字.Location = new System.Drawing.Point(22, 12);
            this.textEdit关键字.Name = "textEdit关键字";
            this.textEdit关键字.Properties.NullValuePrompt = "请输入要查询的姓名";
            this.textEdit关键字.Size = new System.Drawing.Size(128, 20);
            this.textEdit关键字.TabIndex = 5;
            // 
            // btn查询
            // 
            this.btn查询.Location = new System.Drawing.Point(156, 11);
            this.btn查询.Name = "btn查询";
            this.btn查询.Size = new System.Drawing.Size(76, 23);
            this.btn查询.TabIndex = 4;
            this.btn查询.Text = "查询";
            this.btn查询.Click += new System.EventHandler(this.btn查询_Click);
            // 
            // SearchRembursementSalaryForm
            // 
            this.ClientSize = new System.Drawing.Size(774, 435);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.panelControl1);
            this.LookAndFeel.SkinName = "Summer 2008";
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SearchRembursementSalaryForm";
            this.Text = "报账工资查询";
            this.Load += new System.EventHandler(this.EditRembursementSalaryForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bandedGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.textEdit关键字.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.ComponentModel.IContainer components = null;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit1;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridView bandedGridView1;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn1;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn2;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn3;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn5;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn8;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn9;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn4;
        private DevExpress.XtraEditors.TextEdit textEdit关键字;
        private DevExpress.XtraEditors.SimpleButton btn查询;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn7;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn6;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand2;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand3;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand开始时间;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand结束时间;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand9;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand1;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand4;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand7;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand5;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand6;
    }
}
