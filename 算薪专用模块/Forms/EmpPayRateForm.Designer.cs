namespace Hwagain.SalaryCalculation
{
    partial class EmpPayRateForm
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
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btn查询 = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.year = new DevExpress.XtraEditors.SpinEdit();
            this.month = new DevExpress.XtraEditors.ComboBoxEdit();
            this.btn刷新 = new DevExpress.XtraEditors.SimpleButton();
            this.btn添加 = new DevExpress.XtraEditors.SimpleButton();
            this.btn删除 = new DevExpress.XtraEditors.SimpleButton();
            this.btn保存 = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.员工编号 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.姓名 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.年 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.月 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.系数 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.录入人 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.录入时间 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col动作名称 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col动作代码 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col动作说明 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.year.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.month.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btn查询);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.year);
            this.panelControl1.Controls.Add(this.month);
            this.panelControl1.Controls.Add(this.btn刷新);
            this.panelControl1.Controls.Add(this.btn添加);
            this.panelControl1.Controls.Add(this.btn删除);
            this.panelControl1.Controls.Add(this.btn保存);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(704, 48);
            this.panelControl1.TabIndex = 3;
            // 
            // btn查询
            // 
            this.btn查询.Location = new System.Drawing.Point(239, 11);
            this.btn查询.Name = "btn查询";
            this.btn查询.Size = new System.Drawing.Size(62, 23);
            this.btn查询.TabIndex = 8;
            this.btn查询.Text = "查询";
            this.btn查询.Click += new System.EventHandler(this.btn查询_Click);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(204, 15);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(12, 14);
            this.labelControl2.TabIndex = 7;
            this.labelControl2.Text = "月";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(121, 15);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(12, 14);
            this.labelControl1.TabIndex = 6;
            this.labelControl1.Text = "年";
            // 
            // year
            // 
            this.year.EditValue = new decimal(new int[] {
            2014,
            0,
            0,
            0});
            this.year.Location = new System.Drawing.Point(28, 12);
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
            this.year.Size = new System.Drawing.Size(87, 20);
            this.year.TabIndex = 5;
            // 
            // month
            // 
            this.month.Location = new System.Drawing.Point(139, 13);
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
            this.month.Size = new System.Drawing.Size(59, 20);
            this.month.TabIndex = 4;
            // 
            // btn刷新
            // 
            this.btn刷新.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn刷新.Location = new System.Drawing.Point(607, 11);
            this.btn刷新.Name = "btn刷新";
            this.btn刷新.Size = new System.Drawing.Size(62, 23);
            this.btn刷新.TabIndex = 3;
            this.btn刷新.Text = "刷新";
            this.btn刷新.Click += new System.EventHandler(this.btn刷新_Click);
            // 
            // btn添加
            // 
            this.btn添加.Location = new System.Drawing.Point(307, 11);
            this.btn添加.Name = "btn添加";
            this.btn添加.Size = new System.Drawing.Size(62, 23);
            this.btn添加.TabIndex = 2;
            this.btn添加.Text = "添加";
            this.btn添加.Click += new System.EventHandler(this.btn添加_Click);
            // 
            // btn删除
            // 
            this.btn删除.Location = new System.Drawing.Point(443, 11);
            this.btn删除.Name = "btn删除";
            this.btn删除.Size = new System.Drawing.Size(62, 23);
            this.btn删除.TabIndex = 1;
            this.btn删除.Text = "删除";
            this.btn删除.Click += new System.EventHandler(this.btn删除_Click);
            // 
            // btn保存
            // 
            this.btn保存.Location = new System.Drawing.Point(375, 11);
            this.btn保存.Name = "btn保存";
            this.btn保存.Size = new System.Drawing.Size(62, 23);
            this.btn保存.TabIndex = 0;
            this.btn保存.Text = "保存";
            this.btn保存.Click += new System.EventHandler(this.btn保存_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 48);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(704, 437);
            this.gridControl1.TabIndex = 6;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1,
            this.gridView2});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.员工编号,
            this.姓名,
            this.年,
            this.月,
            this.系数,
            this.录入人,
            this.录入时间});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.NewItemRowText = "点击这里增加新动作";
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanged);
            this.gridView1.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
            // 
            // 员工编号
            // 
            this.员工编号.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.员工编号.AppearanceCell.Options.UseBackColor = true;
            this.员工编号.Caption = "员工编号";
            this.员工编号.FieldName = "员工编号";
            this.员工编号.Name = "员工编号";
            this.员工编号.OptionsColumn.AllowEdit = false;
            this.员工编号.OptionsColumn.ReadOnly = true;
            this.员工编号.Visible = true;
            this.员工编号.VisibleIndex = 0;
            this.员工编号.Width = 81;
            // 
            // 姓名
            // 
            this.姓名.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.姓名.AppearanceCell.Options.UseBackColor = true;
            this.姓名.Caption = "姓名";
            this.姓名.FieldName = "姓名";
            this.姓名.Name = "姓名";
            this.姓名.OptionsColumn.AllowEdit = false;
            this.姓名.OptionsColumn.ReadOnly = true;
            this.姓名.Visible = true;
            this.姓名.VisibleIndex = 1;
            this.姓名.Width = 70;
            // 
            // 年
            // 
            this.年.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.年.AppearanceCell.Options.UseBackColor = true;
            this.年.Caption = "年";
            this.年.FieldName = "年";
            this.年.Name = "年";
            this.年.OptionsColumn.AllowEdit = false;
            this.年.OptionsColumn.ReadOnly = true;
            this.年.Visible = true;
            this.年.VisibleIndex = 2;
            // 
            // 月
            // 
            this.月.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.月.AppearanceCell.Options.UseBackColor = true;
            this.月.Caption = "月";
            this.月.FieldName = "月";
            this.月.Name = "月";
            this.月.OptionsColumn.AllowEdit = false;
            this.月.OptionsColumn.ReadOnly = true;
            this.月.Visible = true;
            this.月.VisibleIndex = 3;
            this.月.Width = 52;
            // 
            // 系数
            // 
            this.系数.Caption = "系数";
            this.系数.FieldName = "系数";
            this.系数.Name = "系数";
            this.系数.Visible = true;
            this.系数.VisibleIndex = 4;
            this.系数.Width = 79;
            // 
            // 录入人
            // 
            this.录入人.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.录入人.AppearanceCell.Options.UseBackColor = true;
            this.录入人.Caption = "录入人";
            this.录入人.FieldName = "录入人";
            this.录入人.Name = "录入人";
            this.录入人.OptionsColumn.AllowEdit = false;
            this.录入人.Visible = true;
            this.录入人.VisibleIndex = 5;
            // 
            // 录入时间
            // 
            this.录入时间.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.录入时间.AppearanceCell.Options.UseBackColor = true;
            this.录入时间.Caption = "录入时间";
            this.录入时间.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.录入时间.FieldName = "录入时间";
            this.录入时间.Name = "录入时间";
            this.录入时间.OptionsColumn.AllowEdit = false;
            this.录入时间.Visible = true;
            this.录入时间.VisibleIndex = 6;
            this.录入时间.Width = 162;
            // 
            // gridView2
            // 
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col动作名称,
            this.col动作代码,
            this.col动作说明});
            this.gridView2.GridControl = this.gridControl1;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsView.ShowGroupPanel = false;
            this.gridView2.ViewCaption = "动作";
            // 
            // col动作名称
            // 
            this.col动作名称.Caption = "动作名称";
            this.col动作名称.FieldName = "Name";
            this.col动作名称.Name = "col动作名称";
            this.col动作名称.Visible = true;
            this.col动作名称.VisibleIndex = 0;
            // 
            // col动作代码
            // 
            this.col动作代码.Caption = "动作代码";
            this.col动作代码.FieldName = "Code";
            this.col动作代码.Name = "col动作代码";
            this.col动作代码.Visible = true;
            this.col动作代码.VisibleIndex = 1;
            // 
            // col动作说明
            // 
            this.col动作说明.Caption = "动作说明";
            this.col动作说明.FieldName = "Description";
            this.col动作说明.Name = "col动作说明";
            this.col动作说明.Visible = true;
            this.col动作说明.VisibleIndex = 2;
            // 
            // EmpPayRateForm
            // 
            this.ClientSize = new System.Drawing.Size(704, 485);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.panelControl1);
            this.LookAndFeel.SkinName = "Summer 2008";
            this.Name = "EmpPayRateForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "工资系数录入";
            this.Load += new System.EventHandler(this.EditEmpPayRateForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.year.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.month.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.ComponentModel.IContainer components = null;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btn保存;
        private DevExpress.XtraEditors.SimpleButton btn删除;
        private DevExpress.XtraEditors.SimpleButton btn添加;
        private DevExpress.XtraEditors.SimpleButton btn刷新;
        private DevExpress.XtraEditors.SimpleButton btn查询;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SpinEdit year;
        private DevExpress.XtraEditors.ComboBoxEdit month;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn 员工编号;
        private DevExpress.XtraGrid.Columns.GridColumn 姓名;
        private DevExpress.XtraGrid.Columns.GridColumn 年;
        private DevExpress.XtraGrid.Columns.GridColumn 月;
        private DevExpress.XtraGrid.Columns.GridColumn 系数;
        private DevExpress.XtraGrid.Columns.GridColumn 录入人;
        private DevExpress.XtraGrid.Columns.GridColumn 录入时间;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn col动作名称;
        private DevExpress.XtraGrid.Columns.GridColumn col动作代码;
        private DevExpress.XtraGrid.Columns.GridColumn col动作说明;
    }
}
