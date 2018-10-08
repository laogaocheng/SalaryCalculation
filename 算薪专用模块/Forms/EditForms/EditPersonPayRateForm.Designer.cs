namespace Hwagain.SalaryCalculation
{
    partial class EditPersonPayRateForm
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
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col动作名称 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col动作代码 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col动作说明 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.薪资组 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.发放单位 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.计算部门 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.员工编号 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.姓名 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.职务 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.生效日期 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemDateEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.月薪 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.年终奖 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.月报销额度 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.津贴1名称 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.津贴1金额 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCalcEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit();
            this.津贴2名称 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.津贴2金额 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.录入人 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btn刷新 = new DevExpress.XtraEditors.SimpleButton();
            this.btn添加 = new DevExpress.XtraEditors.SimpleButton();
            this.btn删除 = new DevExpress.XtraEditors.SimpleButton();
            this.btn保存 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCalcEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
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
            // gridControl1
            // 
            this.gridControl1.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 48);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemDateEdit1,
            this.repositoryItemCalcEdit1});
            this.gridControl1.Size = new System.Drawing.Size(760, 375);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1,
            this.gridView2});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.薪资组,
            this.发放单位,
            this.计算部门,
            this.员工编号,
            this.姓名,
            this.职务,
            this.生效日期,
            this.月薪,
            this.年终奖,
            this.月报销额度,
            this.津贴1名称,
            this.津贴1金额,
            this.津贴2名称,
            this.津贴2金额,
            this.录入人});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.GroupCount = 3;
            this.gridView1.Name = "gridView1";
            this.gridView1.NewItemRowText = "点击这里增加新动作";
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.薪资组, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.发放单位, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.计算部门, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gridView1.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.gridView1_CustomDrawCell);
            this.gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView1_FocusedRowChanged);
            this.gridView1.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanged);
            this.gridView1.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.gridView1_InvalidRowException);
            // 
            // 薪资组
            // 
            this.薪资组.Caption = "薪资组";
            this.薪资组.FieldName = "员工信息.薪资组名称";
            this.薪资组.Name = "薪资组";
            this.薪资组.OptionsColumn.AllowEdit = false;
            this.薪资组.OptionsColumn.ReadOnly = true;
            this.薪资组.Visible = true;
            this.薪资组.VisibleIndex = 0;
            // 
            // 发放单位
            // 
            this.发放单位.Caption = "发放单位";
            this.发放单位.FieldName = "员工信息.财务公司";
            this.发放单位.Name = "发放单位";
            this.发放单位.OptionsColumn.AllowEdit = false;
            this.发放单位.OptionsColumn.ReadOnly = true;
            this.发放单位.Visible = true;
            this.发放单位.VisibleIndex = 0;
            // 
            // 计算部门
            // 
            this.计算部门.Caption = "计算部门";
            this.计算部门.FieldName = "员工信息.财务部门";
            this.计算部门.Name = "计算部门";
            this.计算部门.OptionsColumn.AllowEdit = false;
            this.计算部门.OptionsColumn.ReadOnly = true;
            this.计算部门.Visible = true;
            this.计算部门.VisibleIndex = 0;
            // 
            // 员工编号
            // 
            this.员工编号.Caption = "员工编号";
            this.员工编号.FieldName = "员工编号";
            this.员工编号.Name = "员工编号";
            this.员工编号.OptionsColumn.AllowEdit = false;
            this.员工编号.OptionsColumn.ReadOnly = true;
            this.员工编号.Visible = true;
            this.员工编号.VisibleIndex = 0;
            this.员工编号.Width = 134;
            // 
            // 姓名
            // 
            this.姓名.Caption = "姓名";
            this.姓名.FieldName = "姓名";
            this.姓名.Name = "姓名";
            this.姓名.OptionsColumn.AllowEdit = false;
            this.姓名.OptionsColumn.ReadOnly = true;
            this.姓名.Visible = true;
            this.姓名.VisibleIndex = 1;
            this.姓名.Width = 63;
            // 
            // 职务
            // 
            this.职务.Caption = "职务";
            this.职务.FieldName = "职务";
            this.职务.Name = "职务";
            this.职务.OptionsColumn.AllowEdit = false;
            this.职务.OptionsColumn.ReadOnly = true;
            this.职务.Visible = true;
            this.职务.VisibleIndex = 2;
            this.职务.Width = 82;
            // 
            // 生效日期
            // 
            this.生效日期.Caption = "执行时间";
            this.生效日期.ColumnEdit = this.repositoryItemDateEdit1;
            this.生效日期.FieldName = "生效日期";
            this.生效日期.Name = "生效日期";
            this.生效日期.Visible = true;
            this.生效日期.VisibleIndex = 3;
            this.生效日期.Width = 79;
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
            // 月薪
            // 
            this.月薪.Caption = "月薪";
            this.月薪.DisplayFormat.FormatString = "0";
            this.月薪.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.月薪.FieldName = "月薪";
            this.月薪.Name = "月薪";
            this.月薪.Visible = true;
            this.月薪.VisibleIndex = 4;
            this.月薪.Width = 77;
            // 
            // 年终奖
            // 
            this.年终奖.Caption = "年终奖";
            this.年终奖.DisplayFormat.FormatString = "0";
            this.年终奖.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.年终奖.FieldName = "年终奖";
            this.年终奖.Name = "年终奖";
            this.年终奖.Visible = true;
            this.年终奖.VisibleIndex = 5;
            this.年终奖.Width = 72;
            // 
            // 月报销额度
            // 
            this.月报销额度.Caption = "月报销额度";
            this.月报销额度.DisplayFormat.FormatString = "0";
            this.月报销额度.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.月报销额度.FieldName = "月报销额度";
            this.月报销额度.Name = "月报销额度";
            this.月报销额度.Visible = true;
            this.月报销额度.VisibleIndex = 6;
            this.月报销额度.Width = 82;
            // 
            // 津贴1名称
            // 
            this.津贴1名称.Caption = "津贴1名称";
            this.津贴1名称.FieldName = "津贴1名称";
            this.津贴1名称.Name = "津贴1名称";
            this.津贴1名称.Visible = true;
            this.津贴1名称.VisibleIndex = 7;
            this.津贴1名称.Width = 85;
            // 
            // 津贴1金额
            // 
            this.津贴1金额.Caption = "津贴1金额";
            this.津贴1金额.ColumnEdit = this.repositoryItemCalcEdit1;
            this.津贴1金额.DisplayFormat.FormatString = "0";
            this.津贴1金额.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.津贴1金额.FieldName = "津贴1金额";
            this.津贴1金额.Name = "津贴1金额";
            this.津贴1金额.Visible = true;
            this.津贴1金额.VisibleIndex = 8;
            this.津贴1金额.Width = 79;
            // 
            // repositoryItemCalcEdit1
            // 
            this.repositoryItemCalcEdit1.AutoHeight = false;
            this.repositoryItemCalcEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemCalcEdit1.Name = "repositoryItemCalcEdit1";
            // 
            // 津贴2名称
            // 
            this.津贴2名称.Caption = "津贴2名称";
            this.津贴2名称.FieldName = "津贴2名称";
            this.津贴2名称.Name = "津贴2名称";
            this.津贴2名称.Visible = true;
            this.津贴2名称.VisibleIndex = 9;
            this.津贴2名称.Width = 83;
            // 
            // 津贴2金额
            // 
            this.津贴2金额.Caption = "津贴2金额";
            this.津贴2金额.ColumnEdit = this.repositoryItemCalcEdit1;
            this.津贴2金额.DisplayFormat.FormatString = "0";
            this.津贴2金额.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.津贴2金额.FieldName = "津贴2金额";
            this.津贴2金额.Name = "津贴2金额";
            this.津贴2金额.Visible = true;
            this.津贴2金额.VisibleIndex = 10;
            this.津贴2金额.Width = 105;
            // 
            // 录入人
            // 
            this.录入人.Caption = "录入人";
            this.录入人.FieldName = "录入人";
            this.录入人.Name = "录入人";
            this.录入人.OptionsColumn.AllowEdit = false;
            this.录入人.OptionsColumn.ReadOnly = true;
            this.录入人.Visible = true;
            this.录入人.VisibleIndex = 11;
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
            this.btn删除.Location = new System.Drawing.Point(216, 12);
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
            this.btn保存.Size = new System.Drawing.Size(62, 23);
            this.btn保存.TabIndex = 0;
            this.btn保存.Text = "保存";
            this.btn保存.Click += new System.EventHandler(this.btn保存_Click);
            // 
            // EditPersonPayRateForm
            // 
            this.ClientSize = new System.Drawing.Size(760, 423);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.panelControl1);
            this.LookAndFeel.SkinName = "Summer 2008";
            this.Name = "EditPersonPayRateForm";
            this.Text = "个人职级工资录入";
            this.Load += new System.EventHandler(this.EditPersonPayRateForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCalcEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.ComponentModel.IContainer components = null;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn col动作名称;
        private DevExpress.XtraGrid.Columns.GridColumn col动作代码;
        private DevExpress.XtraGrid.Columns.GridColumn col动作说明;
        private DevExpress.XtraGrid.Columns.GridColumn 员工编号;
        private DevExpress.XtraGrid.Columns.GridColumn 姓名;
        private DevExpress.XtraGrid.Columns.GridColumn 职务;
        private DevExpress.XtraGrid.Columns.GridColumn 月薪;
        private DevExpress.XtraGrid.Columns.GridColumn 月报销额度;
        private DevExpress.XtraGrid.Columns.GridColumn 年终奖;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btn保存;
        private DevExpress.XtraEditors.SimpleButton btn删除;
        private DevExpress.XtraGrid.Columns.GridColumn 津贴1名称;
        private DevExpress.XtraGrid.Columns.GridColumn 津贴1金额;
        private DevExpress.XtraGrid.Columns.GridColumn 津贴2名称;
        private DevExpress.XtraGrid.Columns.GridColumn 津贴2金额;
        private DevExpress.XtraEditors.SimpleButton btn添加;
        private DevExpress.XtraEditors.SimpleButton btn刷新;
        private DevExpress.XtraGrid.Columns.GridColumn 生效日期;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn 薪资组;
        private DevExpress.XtraGrid.Columns.GridColumn 发放单位;
        private DevExpress.XtraGrid.Columns.GridColumn 计算部门;
        private DevExpress.XtraGrid.Columns.GridColumn 录入人;
        private DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit repositoryItemCalcEdit1;
    }
}
