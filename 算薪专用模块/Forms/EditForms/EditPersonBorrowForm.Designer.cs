namespace Hwagain.SalaryCalculation
{
    partial class EditPersonBorrowForm
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
            this.btn刷新 = new DevExpress.XtraEditors.SimpleButton();
            this.btn添加 = new DevExpress.XtraEditors.SimpleButton();
            this.btn删除 = new DevExpress.XtraEditors.SimpleButton();
            this.btn保存 = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.编号 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.员工编号 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.姓名 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.项目 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemImageComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.金额 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCalcEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit();
            this.返还年限 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.每月扣还 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.生效日期 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.录入人 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.录入时间 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col动作名称 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col动作代码 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col动作说明 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCalcEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            this.SuspendLayout();
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
            this.panelControl1.Size = new System.Drawing.Size(760, 48);
            this.panelControl1.TabIndex = 3;
            // 
            // btn刷新
            // 
            this.btn刷新.Location = new System.Drawing.Point(15, 12);
            this.btn刷新.Name = "btn刷新";
            this.btn刷新.Size = new System.Drawing.Size(62, 23);
            this.btn刷新.TabIndex = 3;
            this.btn刷新.Text = "查询";
            this.btn刷新.Click += new System.EventHandler(this.btn刷新_Click);
            // 
            // btn添加
            // 
            this.btn添加.Location = new System.Drawing.Point(83, 12);
            this.btn添加.Name = "btn添加";
            this.btn添加.Size = new System.Drawing.Size(62, 23);
            this.btn添加.TabIndex = 2;
            this.btn添加.Text = "添加";
            this.btn添加.Click += new System.EventHandler(this.btn添加_Click);
            // 
            // btn删除
            // 
            this.btn删除.Location = new System.Drawing.Point(219, 12);
            this.btn删除.Name = "btn删除";
            this.btn删除.Size = new System.Drawing.Size(62, 23);
            this.btn删除.TabIndex = 1;
            this.btn删除.Text = "删除";
            this.btn删除.Click += new System.EventHandler(this.btn删除_Click);
            // 
            // btn保存
            // 
            this.btn保存.Location = new System.Drawing.Point(151, 12);
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
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemImageComboBox1,
            this.repositoryItemCalcEdit1});
            this.gridControl1.Size = new System.Drawing.Size(760, 375);
            this.gridControl1.TabIndex = 5;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1,
            this.gridView2});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.编号,
            this.员工编号,
            this.姓名,
            this.项目,
            this.金额,
            this.返还年限,
            this.每月扣还,
            this.生效日期,
            this.录入人,
            this.录入时间});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.NewItemRowText = "点击这里增加新动作";
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.gridView1_CustomDrawCell);
            this.gridView1.CustomRowCellEditForEditing += new DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventHandler(this.gridView1_CustomRowCellEditForEditing);
            this.gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView1_FocusedRowChanged);
            this.gridView1.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanged);
            this.gridView1.CellValueChanging += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanging);
            this.gridView1.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.gridView1_InvalidRowException);
            this.gridView1.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
            // 
            // 编号
            // 
            this.编号.Caption = "编号";
            this.编号.FieldName = "编号";
            this.编号.Name = "编号";
            this.编号.OptionsColumn.AllowEdit = false;
            this.编号.OptionsColumn.ReadOnly = true;
            this.编号.Visible = true;
            this.编号.VisibleIndex = 0;
            this.编号.Width = 87;
            // 
            // 员工编号
            // 
            this.员工编号.Caption = "员工编号";
            this.员工编号.FieldName = "员工编号";
            this.员工编号.Name = "员工编号";
            this.员工编号.OptionsColumn.AllowEdit = false;
            this.员工编号.OptionsColumn.ReadOnly = true;
            this.员工编号.Visible = true;
            this.员工编号.VisibleIndex = 1;
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
            this.姓名.VisibleIndex = 2;
            this.姓名.Width = 70;
            // 
            // 项目
            // 
            this.项目.Caption = "项目";
            this.项目.ColumnEdit = this.repositoryItemImageComboBox1;
            this.项目.FieldName = "项目";
            this.项目.Name = "项目";
            this.项目.Visible = true;
            this.项目.VisibleIndex = 4;
            this.项目.Width = 115;
            // 
            // repositoryItemImageComboBox1
            // 
            this.repositoryItemImageComboBox1.AutoHeight = false;
            this.repositoryItemImageComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageComboBox1.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("提前借工资", "提前借工资", -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("个人专用车费用", "个人专用车费用", -1)});
            this.repositoryItemImageComboBox1.Name = "repositoryItemImageComboBox1";
            // 
            // 金额
            // 
            this.金额.Caption = "金额";
            this.金额.ColumnEdit = this.repositoryItemCalcEdit1;
            this.金额.DisplayFormat.FormatString = "{0:0.00}";
            this.金额.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.金额.FieldName = "金额";
            this.金额.Name = "金额";
            this.金额.Visible = true;
            this.金额.VisibleIndex = 5;
            this.金额.Width = 90;
            // 
            // repositoryItemCalcEdit1
            // 
            this.repositoryItemCalcEdit1.AutoHeight = false;
            this.repositoryItemCalcEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemCalcEdit1.Name = "repositoryItemCalcEdit1";
            // 
            // 返还年限
            // 
            this.返还年限.Caption = "返还年限（年）";
            this.返还年限.ColumnEdit = this.repositoryItemCalcEdit1;
            this.返还年限.FieldName = "返还年限";
            this.返还年限.Name = "返还年限";
            this.返还年限.Visible = true;
            this.返还年限.VisibleIndex = 6;
            this.返还年限.Width = 101;
            // 
            // 每月扣还
            // 
            this.每月扣还.Caption = "每月扣还";
            this.每月扣还.DisplayFormat.FormatString = "{0:0.00}";
            this.每月扣还.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.每月扣还.FieldName = "每月扣还";
            this.每月扣还.Name = "每月扣还";
            this.每月扣还.OptionsColumn.AllowEdit = false;
            this.每月扣还.OptionsColumn.ReadOnly = true;
            this.每月扣还.Visible = true;
            this.每月扣还.VisibleIndex = 7;
            this.每月扣还.Width = 93;
            // 
            // 生效日期
            // 
            this.生效日期.Caption = "生效日期";
            this.生效日期.FieldName = "生效日期";
            this.生效日期.Name = "生效日期";
            this.生效日期.Visible = true;
            this.生效日期.VisibleIndex = 3;
            this.生效日期.Width = 72;
            // 
            // 录入人
            // 
            this.录入人.Caption = "录入人";
            this.录入人.FieldName = "录入人";
            this.录入人.Name = "录入人";
            this.录入人.OptionsColumn.AllowEdit = false;
            this.录入人.Visible = true;
            this.录入人.VisibleIndex = 8;
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
            // EditPersonBorrowForm
            // 
            this.ClientSize = new System.Drawing.Size(760, 423);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.panelControl1);
            this.LookAndFeel.SkinName = "Summer 2008";
            this.Name = "EditPersonBorrowForm";
            this.Text = "员工个人借款记录";
            this.Load += new System.EventHandler(this.EditPersonBorrowForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCalcEdit1)).EndInit();
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
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn 员工编号;
        private DevExpress.XtraGrid.Columns.GridColumn 姓名;
        private DevExpress.XtraGrid.Columns.GridColumn 金额;
        private DevExpress.XtraGrid.Columns.GridColumn 录入人;
        private DevExpress.XtraGrid.Columns.GridColumn 录入时间;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn col动作名称;
        private DevExpress.XtraGrid.Columns.GridColumn col动作代码;
        private DevExpress.XtraGrid.Columns.GridColumn col动作说明;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox1;
        private DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit repositoryItemCalcEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn 项目;
        private DevExpress.XtraGrid.Columns.GridColumn 返还年限;
        private DevExpress.XtraGrid.Columns.GridColumn 每月扣还;
        private DevExpress.XtraGrid.Columns.GridColumn 生效日期;
        private DevExpress.XtraGrid.Columns.GridColumn 编号;
    }
}
