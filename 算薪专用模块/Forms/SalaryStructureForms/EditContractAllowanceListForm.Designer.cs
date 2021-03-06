namespace Hwagain.SalaryCalculation
{
    partial class EditContractAllowanceListForm
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
            this.bandedGridColumn1 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn2 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn3 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.repositoryItemDateEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.bandedGridColumn5 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn6 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn8 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn4 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn14 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btn刷新 = new DevExpress.XtraEditors.SimpleButton();
            this.btn添加 = new DevExpress.XtraEditors.SimpleButton();
            this.btn删除 = new DevExpress.XtraEditors.SimpleButton();
            this.btn保存 = new DevExpress.XtraEditors.SimpleButton();
            this.gridBand2 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridBand3 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridBand开始时间 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridBand结束时间 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridBand约定年限 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridBand9 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridBand1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridBand15 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bandedGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
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
            this.gridBand开始时间,
            this.gridBand结束时间,
            this.gridBand约定年限,
            this.gridBand9,
            this.gridBand1,
            this.gridBand15});
            this.bandedGridView1.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.bandedGridColumn1,
            this.bandedGridColumn2,
            this.bandedGridColumn3,
            this.bandedGridColumn5,
            this.bandedGridColumn6,
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
            this.bandedGridColumn3.Width = 80;
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
            this.bandedGridColumn5.Width = 80;
            // 
            // bandedGridColumn6
            // 
            this.bandedGridColumn6.AppearanceCell.Options.UseTextOptions = true;
            this.bandedGridColumn6.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.bandedGridColumn6.Caption = "约定年限";
            this.bandedGridColumn6.DisplayFormat.FormatString = "{0:#0}年";
            this.bandedGridColumn6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.bandedGridColumn6.FieldName = "约定年限";
            this.bandedGridColumn6.Name = "bandedGridColumn6";
            this.bandedGridColumn6.OptionsColumn.ReadOnly = true;
            this.bandedGridColumn6.Visible = true;
            this.bandedGridColumn6.Width = 64;
            // 
            // bandedGridColumn8
            // 
            this.bandedGridColumn8.AppearanceCell.Options.UseTextOptions = true;
            this.bandedGridColumn8.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.bandedGridColumn8.Caption = "月津贴额度";
            this.bandedGridColumn8.DisplayFormat.FormatString = "{0:#0.##}";
            this.bandedGridColumn8.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.bandedGridColumn8.FieldName = "月津贴额度";
            this.bandedGridColumn8.Name = "bandedGridColumn8";
            this.bandedGridColumn8.OptionsColumn.ReadOnly = true;
            this.bandedGridColumn8.Visible = true;
            this.bandedGridColumn8.Width = 73;
            // 
            // bandedGridColumn4
            // 
            this.bandedGridColumn4.Caption = "录入人";
            this.bandedGridColumn4.FieldName = "录入人";
            this.bandedGridColumn4.Name = "bandedGridColumn4";
            this.bandedGridColumn4.Visible = true;
            this.bandedGridColumn4.Width = 63;
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
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btn刷新);
            this.panelControl1.Controls.Add(this.btn添加);
            this.panelControl1.Controls.Add(this.btn删除);
            this.panelControl1.Controls.Add(this.btn保存);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(700, 48);
            this.panelControl1.TabIndex = 3;
            // 
            // btn刷新
            // 
            this.btn刷新.Location = new System.Drawing.Point(12, 12);
            this.btn刷新.Name = "btn刷新";
            this.btn刷新.Size = new System.Drawing.Size(62, 23);
            this.btn刷新.TabIndex = 3;
            this.btn刷新.Text = "刷新";
            this.btn刷新.Click += new System.EventHandler(this.btn刷新_Click);
            // 
            // btn添加
            // 
            this.btn添加.Location = new System.Drawing.Point(80, 12);
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
            this.btn保存.Location = new System.Drawing.Point(148, 12);
            this.btn保存.Name = "btn保存";
            this.btn保存.Size = new System.Drawing.Size(76, 23);
            this.btn保存.TabIndex = 0;
            this.btn保存.Text = "提交完成";
            this.btn保存.Click += new System.EventHandler(this.btn保存_Click);
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
            // gridBand开始时间
            // 
            this.gridBand开始时间.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand开始时间.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand开始时间.Caption = "开始时间";
            this.gridBand开始时间.Columns.Add(this.bandedGridColumn3);
            this.gridBand开始时间.Name = "gridBand开始时间";
            this.gridBand开始时间.VisibleIndex = 2;
            this.gridBand开始时间.Width = 80;
            // 
            // gridBand结束时间
            // 
            this.gridBand结束时间.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand结束时间.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand结束时间.Caption = "结束时间";
            this.gridBand结束时间.Columns.Add(this.bandedGridColumn5);
            this.gridBand结束时间.Name = "gridBand结束时间";
            this.gridBand结束时间.VisibleIndex = 3;
            this.gridBand结束时间.Width = 80;
            // 
            // gridBand约定年限
            // 
            this.gridBand约定年限.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand约定年限.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand约定年限.Caption = "约定年限";
            this.gridBand约定年限.Columns.Add(this.bandedGridColumn6);
            this.gridBand约定年限.Name = "gridBand约定年限";
            this.gridBand约定年限.VisibleIndex = 4;
            this.gridBand约定年限.Width = 64;
            // 
            // gridBand9
            // 
            this.gridBand9.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand9.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand9.Caption = "月津贴额度";
            this.gridBand9.Columns.Add(this.bandedGridColumn8);
            this.gridBand9.Name = "gridBand9";
            this.gridBand9.VisibleIndex = 5;
            this.gridBand9.Width = 73;
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
            // EditContractAllowanceListForm
            // 
            this.ClientSize = new System.Drawing.Size(700, 435);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.panelControl1);
            this.LookAndFeel.SkinName = "Summer 2008";
            this.Name = "EditContractAllowanceListForm";
            this.Text = "录入契约津贴标准";
            this.Load += new System.EventHandler(this.EditContractAllowanceForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bandedGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.ComponentModel.IContainer components = null;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btn保存;
        private DevExpress.XtraEditors.SimpleButton btn删除;
        private DevExpress.XtraEditors.SimpleButton btn添加;
        private DevExpress.XtraEditors.SimpleButton btn刷新;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit1;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridView bandedGridView1;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn1;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn2;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn3;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn5;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn6;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn8;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn14;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn4;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand2;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand3;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand开始时间;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand结束时间;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand约定年限;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand9;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand1;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand15;
    }
}
