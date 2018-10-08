namespace Hwagain.SalaryCalculation
{
    partial class SpecialtyPropertyForm
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
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions1 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btn自动排序 = new DevExpress.XtraEditors.SimpleButton();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.btn返回目录 = new DevExpress.XtraEditors.SimpleButton();
            this.lbl标题 = new DevExpress.XtraEditors.LabelControl();
            this.btn保存提交 = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.monthlySalaryInputBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.标识 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.序号 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.届别 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.学历 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemComboBoxXueLi = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.岗位级别 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemComboBoxGrade = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.专业名称 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.专业属性 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemComboBoxSpecialtyProperty = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.已确认 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEditConfirmStatus = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.操作 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemConfirmButton = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.monthlySalaryInputBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBoxXueLi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBoxGrade)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBoxSpecialtyProperty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEditConfirmStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemConfirmButton)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btn自动排序);
            this.panelControl1.Controls.Add(this.btnDelete);
            this.panelControl1.Controls.Add(this.btnAdd);
            this.panelControl1.Controls.Add(this.btn返回目录);
            this.panelControl1.Controls.Add(this.lbl标题);
            this.panelControl1.Controls.Add(this.btn保存提交);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(688, 66);
            this.panelControl1.TabIndex = 4;
            // 
            // btn自动排序
            // 
            this.btn自动排序.Location = new System.Drawing.Point(155, 38);
            this.btn自动排序.Name = "btn自动排序";
            this.btn自动排序.Size = new System.Drawing.Size(65, 23);
            this.btn自动排序.TabIndex = 50;
            this.btn自动排序.Text = "自动排序";
            this.btn自动排序.Click += new System.EventHandler(this.btn自动排序_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(84, 37);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(65, 23);
            this.btnDelete.TabIndex = 49;
            this.btnDelete.Text = "删除";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(19, 37);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(59, 23);
            this.btnAdd.TabIndex = 48;
            this.btnAdd.Text = "添加";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btn返回目录
            // 
            this.btn返回目录.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn返回目录.Location = new System.Drawing.Point(585, 29);
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
            this.lbl标题.Size = new System.Drawing.Size(320, 19);
            this.lbl标题.TabIndex = 44;
            this.lbl标题.Text = "定职人员（管培生）专业属性确认表";
            // 
            // btn保存提交
            // 
            this.btn保存提交.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn保存提交.Location = new System.Drawing.Point(505, 29);
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
            this.gridControl1.Location = new System.Drawing.Point(0, 66);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemConfirmButton,
            this.repositoryItemComboBoxGrade,
            this.repositoryItemComboBoxSpecialtyProperty,
            this.repositoryItemComboBoxXueLi,
            this.repositoryItemTextEditConfirmStatus});
            this.gridControl1.Size = new System.Drawing.Size(688, 514);
            this.gridControl1.TabIndex = 5;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControl1.Click += new System.EventHandler(this.gridControl1_Click);
            // 
            // monthlySalaryInputBindingSource
            // 
            this.monthlySalaryInputBindingSource.DataSource = typeof(Hwagain.SalaryCalculation.Components.MonthlySalaryInput);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.标识,
            this.序号,
            this.届别,
            this.学历,
            this.岗位级别,
            this.专业名称,
            this.专业属性,
            this.已确认,
            this.操作});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.NewItemRowText = "点击这里增加";
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.gridView1_CustomDrawCell);
            this.gridView1.ColumnChanged += new System.EventHandler(this.gridView1_ColumnChanged);
            this.gridView1.FocusedColumnChanged += new DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventHandler(this.gridView1_FocusedColumnChanged);
            this.gridView1.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanged);
            this.gridView1.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.gridView1_CustomColumnDisplayText);
            // 
            // 标识
            // 
            this.标识.Caption = "标识";
            this.标识.FieldName = "标识";
            this.标识.Name = "标识";
            this.标识.Width = 67;
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
            this.序号.VisibleIndex = 0;
            this.序号.Width = 55;
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
            this.届别.Width = 48;
            // 
            // 学历
            // 
            this.学历.AppearanceCell.Options.UseTextOptions = true;
            this.学历.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.学历.AppearanceHeader.Options.UseTextOptions = true;
            this.学历.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.学历.Caption = "学历";
            this.学历.ColumnEdit = this.repositoryItemComboBoxXueLi;
            this.学历.FieldName = "学历";
            this.学历.Name = "学历";
            this.学历.Visible = true;
            this.学历.VisibleIndex = 2;
            this.学历.Width = 87;
            // 
            // repositoryItemComboBoxXueLi
            // 
            this.repositoryItemComboBoxXueLi.AutoHeight = false;
            this.repositoryItemComboBoxXueLi.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBoxXueLi.Items.AddRange(new object[] {
            "大专",
            "本科",
            "硕士",
            "研究生",
            "博士"});
            this.repositoryItemComboBoxXueLi.Name = "repositoryItemComboBoxXueLi";
            this.repositoryItemComboBoxXueLi.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            // 
            // 岗位级别
            // 
            this.岗位级别.AppearanceCell.Options.UseTextOptions = true;
            this.岗位级别.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.岗位级别.AppearanceHeader.Options.UseTextOptions = true;
            this.岗位级别.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.岗位级别.Caption = "岗位级别";
            this.岗位级别.ColumnEdit = this.repositoryItemComboBoxGrade;
            this.岗位级别.FieldName = "岗位级别";
            this.岗位级别.Name = "岗位级别";
            this.岗位级别.Visible = true;
            this.岗位级别.VisibleIndex = 1;
            this.岗位级别.Width = 77;
            // 
            // repositoryItemComboBoxGrade
            // 
            this.repositoryItemComboBoxGrade.AutoHeight = false;
            this.repositoryItemComboBoxGrade.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBoxGrade.Items.AddRange(new object[] {
            "一级",
            "二级",
            "三级"});
            this.repositoryItemComboBoxGrade.Name = "repositoryItemComboBoxGrade";
            this.repositoryItemComboBoxGrade.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            // 
            // 专业名称
            // 
            this.专业名称.AppearanceCell.Options.UseTextOptions = true;
            this.专业名称.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.专业名称.AppearanceHeader.Options.UseTextOptions = true;
            this.专业名称.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.专业名称.Caption = "专业名称";
            this.专业名称.FieldName = "专业名称";
            this.专业名称.Name = "专业名称";
            this.专业名称.Visible = true;
            this.专业名称.VisibleIndex = 3;
            this.专业名称.Width = 228;
            // 
            // 专业属性
            // 
            this.专业属性.AppearanceCell.Options.UseTextOptions = true;
            this.专业属性.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.专业属性.AppearanceHeader.Options.UseTextOptions = true;
            this.专业属性.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.专业属性.Caption = "专业属性";
            this.专业属性.ColumnEdit = this.repositoryItemComboBoxSpecialtyProperty;
            this.专业属性.FieldName = "属性";
            this.专业属性.Name = "专业属性";
            this.专业属性.Visible = true;
            this.专业属性.VisibleIndex = 4;
            this.专业属性.Width = 131;
            // 
            // repositoryItemComboBoxSpecialtyProperty
            // 
            this.repositoryItemComboBoxSpecialtyProperty.AutoHeight = false;
            this.repositoryItemComboBoxSpecialtyProperty.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBoxSpecialtyProperty.Items.AddRange(new object[] {
            "硕士",
            "本科",
            "专硕",
            "专本",
            "普硕",
            "普本",
            "计算机硕",
            "计算机本",
            "营林硕",
            "营林本"});
            this.repositoryItemComboBoxSpecialtyProperty.Name = "repositoryItemComboBoxSpecialtyProperty";
            this.repositoryItemComboBoxSpecialtyProperty.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            // 
            // 已确认
            // 
            this.已确认.AppearanceCell.Options.UseTextOptions = true;
            this.已确认.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.已确认.AppearanceHeader.Options.UseTextOptions = true;
            this.已确认.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.已确认.Caption = "确认情况";
            this.已确认.ColumnEdit = this.repositoryItemTextEditConfirmStatus;
            this.已确认.FieldName = "已确认";
            this.已确认.Name = "已确认";
            this.已确认.OptionsColumn.AllowEdit = false;
            this.已确认.OptionsColumn.ReadOnly = true;
            this.已确认.SortMode = DevExpress.XtraGrid.ColumnSortMode.Custom;
            this.已确认.Visible = true;
            this.已确认.VisibleIndex = 6;
            this.已确认.Width = 89;
            // 
            // repositoryItemTextEditConfirmStatus
            // 
            this.repositoryItemTextEditConfirmStatus.AutoHeight = false;
            this.repositoryItemTextEditConfirmStatus.Name = "repositoryItemTextEditConfirmStatus";
            // 
            // 操作
            // 
            this.操作.AppearanceHeader.Options.UseTextOptions = true;
            this.操作.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.操作.Caption = "#";
            this.操作.ColumnEdit = this.repositoryItemConfirmButton;
            this.操作.Name = "操作";
            this.操作.Visible = true;
            this.操作.VisibleIndex = 5;
            // 
            // repositoryItemConfirmButton
            // 
            this.repositoryItemConfirmButton.Appearance.Options.UseTextOptions = true;
            this.repositoryItemConfirmButton.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.repositoryItemConfirmButton.AutoHeight = false;
            serializableAppearanceObject1.Options.UseTextOptions = true;
            serializableAppearanceObject1.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            serializableAppearanceObject2.Options.UseTextOptions = true;
            serializableAppearanceObject2.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            serializableAppearanceObject3.Options.UseTextOptions = true;
            serializableAppearanceObject3.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            serializableAppearanceObject4.Options.UseTextOptions = true;
            serializableAppearanceObject4.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.repositoryItemConfirmButton.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "确认", -1, true, true, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "", null, null)});
            this.repositoryItemConfirmButton.Name = "repositoryItemConfirmButton";
            this.repositoryItemConfirmButton.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.repositoryItemConfirmButton.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.repositoryItemConfirmButton_ButtonClick);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileName = "薪酬执行明细表";
            this.saveFileDialog1.Filter = "Excel 文件 | *.xls";
            // 
            // SpecialtyPropertyForm
            // 
            this.ClientSize = new System.Drawing.Size(688, 580);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.panelControl1);
            this.LookAndFeel.SkinName = "Summer 2008";
            this.Name = "SpecialtyPropertyForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "专业属性确认表";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AdjustMonthlySalaryForm_FormClosed);
            this.Load += new System.EventHandler(this.AdjustMonthlySalaryForm_Load);
            this.Shown += new System.EventHandler(this.AdjustMonthlySalaryForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.monthlySalaryInputBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBoxXueLi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBoxGrade)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBoxSpecialtyProperty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEditConfirmStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemConfirmButton)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.ComponentModel.IContainer components = null;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraEditors.SimpleButton btn保存提交;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.BindingSource monthlySalaryInputBindingSource;
        private DevExpress.XtraEditors.LabelControl lbl标题;
        private DevExpress.XtraEditors.SimpleButton btn返回目录;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemConfirmButton;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn 标识;
        private DevExpress.XtraGrid.Columns.GridColumn 序号;
        private DevExpress.XtraGrid.Columns.GridColumn 届别;
        private DevExpress.XtraGrid.Columns.GridColumn 学历;
        private DevExpress.XtraGrid.Columns.GridColumn 岗位级别;
        private DevExpress.XtraGrid.Columns.GridColumn 专业名称;
        private DevExpress.XtraGrid.Columns.GridColumn 专业属性;
        private DevExpress.XtraGrid.Columns.GridColumn 已确认;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBoxGrade;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBoxSpecialtyProperty;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private DevExpress.XtraEditors.SimpleButton btnDelete;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBoxXueLi;
        private DevExpress.XtraGrid.Columns.GridColumn 操作;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEditConfirmStatus;
        private DevExpress.XtraEditors.SimpleButton btn自动排序;
    }
}
