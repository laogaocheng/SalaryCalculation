namespace Hwagain.SalaryCalculation
{
    partial class EmployeeSalaryStepList
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
            this.员工编号 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.姓名 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.薪等 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemImageComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.薪级名称 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.执行日期 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.截止日期 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemDateEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.薪资组名称 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.发放单位 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.计算部门 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemImageComboBox2 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.dateEdit1 = new DevExpress.XtraEditors.DateEdit();
            this.btn设置截止日期 = new DevExpress.XtraEditors.SimpleButton();
            this.btn导出 = new DevExpress.XtraEditors.SimpleButton();
            this.chk显示历史记录 = new DevExpress.XtraEditors.CheckEdit();
            this.searchKey = new DevExpress.XtraEditors.TextEdit();
            this.btn查询 = new DevExpress.XtraEditors.SimpleButton();
            this.btn刷新 = new DevExpress.XtraEditors.SimpleButton();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk显示历史记录.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchKey.Properties)).BeginInit();
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
            this.repositoryItemImageComboBox1,
            this.repositoryItemImageComboBox2,
            this.repositoryItemDateEdit1});
            this.gridControl1.Size = new System.Drawing.Size(760, 375);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1,
            this.gridView2});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.员工编号,
            this.姓名,
            this.薪等,
            this.薪级名称,
            this.执行日期,
            this.截止日期,
            this.薪资组名称,
            this.发放单位,
            this.计算部门});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.GroupCount = 3;
            this.gridView1.Name = "gridView1";
            this.gridView1.NewItemRowText = "点击这里增加新动作";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.薪资组名称, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.发放单位, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.计算部门, DevExpress.Data.ColumnSortOrder.Ascending)});
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
            this.员工编号.Width = 126;
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
            this.姓名.Width = 74;
            // 
            // 薪等
            // 
            this.薪等.Caption = "薪等";
            this.薪等.ColumnEdit = this.repositoryItemImageComboBox1;
            this.薪等.FieldName = "薪等标识";
            this.薪等.Name = "薪等";
            this.薪等.Visible = true;
            this.薪等.VisibleIndex = 3;
            this.薪等.Width = 144;
            // 
            // repositoryItemImageComboBox1
            // 
            this.repositoryItemImageComboBox1.AutoHeight = false;
            this.repositoryItemImageComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageComboBox1.Name = "repositoryItemImageComboBox1";
            // 
            // 薪级名称
            // 
            this.薪级名称.Caption = "薪级";
            this.薪级名称.FieldName = "薪级名称";
            this.薪级名称.Name = "薪级名称";
            this.薪级名称.Visible = true;
            this.薪级名称.VisibleIndex = 4;
            this.薪级名称.Width = 104;
            // 
            // 执行日期
            // 
            this.执行日期.Caption = "执行日期";
            this.执行日期.FieldName = "执行日期";
            this.执行日期.Name = "执行日期";
            this.执行日期.Visible = true;
            this.执行日期.VisibleIndex = 2;
            this.执行日期.Width = 83;
            // 
            // 截止日期
            // 
            this.截止日期.Caption = "截止日期";
            this.截止日期.ColumnEdit = this.repositoryItemDateEdit1;
            this.截止日期.FieldName = "截止日期";
            this.截止日期.Name = "截止日期";
            this.截止日期.Visible = true;
            this.截止日期.VisibleIndex = 5;
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
            // 薪资组名称
            // 
            this.薪资组名称.Caption = "薪资组";
            this.薪资组名称.FieldName = "薪资组名称";
            this.薪资组名称.Name = "薪资组名称";
            this.薪资组名称.Visible = true;
            this.薪资组名称.VisibleIndex = 5;
            // 
            // 发放单位
            // 
            this.发放单位.Caption = "发放单位";
            this.发放单位.FieldName = "员工信息.财务公司";
            this.发放单位.Name = "发放单位";
            this.发放单位.Visible = true;
            this.发放单位.VisibleIndex = 5;
            // 
            // 计算部门
            // 
            this.计算部门.Caption = "计算部门";
            this.计算部门.FieldName = "员工信息.财务部门";
            this.计算部门.Name = "计算部门";
            this.计算部门.Visible = true;
            this.计算部门.VisibleIndex = 5;
            // 
            // repositoryItemImageComboBox2
            // 
            this.repositoryItemImageComboBox2.AutoHeight = false;
            this.repositoryItemImageComboBox2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageComboBox2.Name = "repositoryItemImageComboBox2";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.dateEdit1);
            this.panelControl1.Controls.Add(this.btn设置截止日期);
            this.panelControl1.Controls.Add(this.btn导出);
            this.panelControl1.Controls.Add(this.chk显示历史记录);
            this.panelControl1.Controls.Add(this.searchKey);
            this.panelControl1.Controls.Add(this.btn查询);
            this.panelControl1.Controls.Add(this.btn刷新);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(760, 48);
            this.panelControl1.TabIndex = 4;
            // 
            // dateEdit1
            // 
            this.dateEdit1.EditValue = null;
            this.dateEdit1.Location = new System.Drawing.Point(504, 12);
            this.dateEdit1.Name = "dateEdit1";
            this.dateEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit1.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit1.Properties.NullValuePrompt = "这里输入截止日期";
            this.dateEdit1.Properties.NullValuePromptShowForEmptyValue = true;
            this.dateEdit1.Size = new System.Drawing.Size(137, 20);
            this.dateEdit1.TabIndex = 11;
            // 
            // btn设置截止日期
            // 
            this.btn设置截止日期.Location = new System.Drawing.Point(647, 9);
            this.btn设置截止日期.Name = "btn设置截止日期";
            this.btn设置截止日期.Size = new System.Drawing.Size(101, 23);
            this.btn设置截止日期.TabIndex = 10;
            this.btn设置截止日期.Text = "设置截止日期";
            this.btn设置截止日期.Click += new System.EventHandler(this.btn设置截止日期_Click);
            // 
            // btn导出
            // 
            this.btn导出.Location = new System.Drawing.Point(293, 9);
            this.btn导出.Name = "btn导出";
            this.btn导出.Size = new System.Drawing.Size(62, 23);
            this.btn导出.TabIndex = 9;
            this.btn导出.Text = "导出";
            this.btn导出.Click += new System.EventHandler(this.btn导出_Click);
            // 
            // chk显示历史记录
            // 
            this.chk显示历史记录.Location = new System.Drawing.Point(397, 12);
            this.chk显示历史记录.Name = "chk显示历史记录";
            this.chk显示历史记录.Properties.Caption = "显示历史记录";
            this.chk显示历史记录.Size = new System.Drawing.Size(107, 20);
            this.chk显示历史记录.TabIndex = 8;
            // 
            // searchKey
            // 
            this.searchKey.Location = new System.Drawing.Point(22, 12);
            this.searchKey.Name = "searchKey";
            this.searchKey.Properties.NullValuePrompt = "请输入要查询的姓名";
            this.searchKey.Size = new System.Drawing.Size(129, 20);
            this.searchKey.TabIndex = 7;
            this.searchKey.KeyUp += new System.Windows.Forms.KeyEventHandler(this.searchKey_KeyUp);
            // 
            // btn查询
            // 
            this.btn查询.Location = new System.Drawing.Point(157, 9);
            this.btn查询.Name = "btn查询";
            this.btn查询.Size = new System.Drawing.Size(62, 23);
            this.btn查询.TabIndex = 6;
            this.btn查询.Text = "查询";
            this.btn查询.Click += new System.EventHandler(this.btn查询_Click);
            // 
            // btn刷新
            // 
            this.btn刷新.Location = new System.Drawing.Point(225, 9);
            this.btn刷新.Name = "btn刷新";
            this.btn刷新.Size = new System.Drawing.Size(62, 23);
            this.btn刷新.TabIndex = 3;
            this.btn刷新.Text = "刷新";
            this.btn刷新.Click += new System.EventHandler(this.btn刷新_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileName = "员工工资职级明细表";
            this.saveFileDialog1.Filter = "Excel 文件 | *.xls";
            // 
            // EmployeeSalaryStepList
            // 
            this.ClientSize = new System.Drawing.Size(760, 423);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.panelControl1);
            this.LookAndFeel.SkinName = "Summer 2008";
            this.Name = "EmployeeSalaryStepList";
            this.Text = "员工工资职级";
            this.Load += new System.EventHandler(this.EditEmployeeSalaryStepForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk显示历史记录.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchKey.Properties)).EndInit();
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
        private DevExpress.XtraGrid.Columns.GridColumn 薪等;
        private DevExpress.XtraGrid.Columns.GridColumn 执行日期;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox1;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox2;
        private DevExpress.XtraGrid.Columns.GridColumn 薪级名称;
        private DevExpress.XtraGrid.Columns.GridColumn 薪资组名称;
        private DevExpress.XtraGrid.Columns.GridColumn 发放单位;
        private DevExpress.XtraGrid.Columns.GridColumn 计算部门;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btn刷新;
        private DevExpress.XtraEditors.TextEdit searchKey;
        private DevExpress.XtraEditors.SimpleButton btn查询;
        private DevExpress.XtraEditors.CheckEdit chk显示历史记录;
        private DevExpress.XtraEditors.SimpleButton btn导出;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private DevExpress.XtraEditors.SimpleButton btn设置截止日期;
        private DevExpress.XtraEditors.DateEdit dateEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn 截止日期;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit1;
    }
}
