namespace Hwagain.SalaryCalculation
{
    partial class SearchEmployeeInfoForm
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
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition1 = new DevExpress.XtraGrid.StyleFormatCondition();
            this.是标准职级工资 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.chk仅显示在职员工 = new DevExpress.XtraEditors.CheckEdit();
            this.chk选择后自动关闭窗口 = new DevExpress.XtraEditors.CheckEdit();
            this.cb薪资组 = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btn同步员工信息 = new DevExpress.XtraEditors.SimpleButton();
            this.searchKey = new DevExpress.XtraEditors.TextEdit();
            this.btn查询 = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.薪资组 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.员工编号 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.姓名 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.性别 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.发放单位 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.计算部门 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.公司 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.部门 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.上月薪等 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.上月薪级 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col动作名称 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col动作代码 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col动作说明 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chk仅显示在职员工.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk选择后自动关闭窗口.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cb薪资组.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchKey.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // 是标准职级工资
            // 
            this.是标准职级工资.Caption = "是标准职级工资";
            this.是标准职级工资.FieldName = "上月工资.是标准职级工资";
            this.是标准职级工资.Name = "是标准职级工资";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.chk仅显示在职员工);
            this.panelControl1.Controls.Add(this.chk选择后自动关闭窗口);
            this.panelControl1.Controls.Add(this.cb薪资组);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.btn同步员工信息);
            this.panelControl1.Controls.Add(this.searchKey);
            this.panelControl1.Controls.Add(this.btn查询);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(673, 48);
            this.panelControl1.TabIndex = 2;
            // 
            // chk仅显示在职员工
            // 
            this.chk仅显示在职员工.EditValue = true;
            this.chk仅显示在职员工.Location = new System.Drawing.Point(526, 5);
            this.chk仅显示在职员工.Name = "chk仅显示在职员工";
            this.chk仅显示在职员工.Properties.Caption = "仅显示在职员工";
            this.chk仅显示在职员工.Size = new System.Drawing.Size(142, 20);
            this.chk仅显示在职员工.TabIndex = 20;
            // 
            // chk选择后自动关闭窗口
            // 
            this.chk选择后自动关闭窗口.Location = new System.Drawing.Point(526, 23);
            this.chk选择后自动关闭窗口.Name = "chk选择后自动关闭窗口";
            this.chk选择后自动关闭窗口.Properties.Caption = "选择后自动关闭窗口";
            this.chk选择后自动关闭窗口.Size = new System.Drawing.Size(142, 20);
            this.chk选择后自动关闭窗口.TabIndex = 19;
            this.chk选择后自动关闭窗口.CheckedChanged += new System.EventHandler(this.chk选择后自动关闭窗口_CheckedChanged);
            // 
            // cb薪资组
            // 
            this.cb薪资组.Location = new System.Drawing.Point(56, 14);
            this.cb薪资组.Name = "cb薪资组";
            this.cb薪资组.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cb薪资组.Size = new System.Drawing.Size(202, 20);
            this.cb薪资组.TabIndex = 18;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(14, 17);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(36, 14);
            this.labelControl1.TabIndex = 17;
            this.labelControl1.Text = "薪资组";
            // 
            // btn同步员工信息
            // 
            this.btn同步员工信息.Location = new System.Drawing.Point(424, 13);
            this.btn同步员工信息.Name = "btn同步员工信息";
            this.btn同步员工信息.Size = new System.Drawing.Size(88, 23);
            this.btn同步员工信息.TabIndex = 7;
            this.btn同步员工信息.Text = "同步员工信息";
            this.btn同步员工信息.Click += new System.EventHandler(this.btn同步员工信息_Click);
            // 
            // searchKey
            // 
            this.searchKey.Location = new System.Drawing.Point(264, 14);
            this.searchKey.Name = "searchKey";
            this.searchKey.Properties.NullValuePrompt = "请输入姓名";
            this.searchKey.Size = new System.Drawing.Size(86, 20);
            this.searchKey.TabIndex = 5;
            this.searchKey.EditValueChanged += new System.EventHandler(this.searchKey_EditValueChanged);
            this.searchKey.KeyUp += new System.Windows.Forms.KeyEventHandler(this.searchKey_KeyUp);
            // 
            // btn查询
            // 
            this.btn查询.Location = new System.Drawing.Point(356, 13);
            this.btn查询.Name = "btn查询";
            this.btn查询.Size = new System.Drawing.Size(62, 23);
            this.btn查询.TabIndex = 4;
            this.btn查询.Text = "查询";
            this.btn查询.Click += new System.EventHandler(this.btn查询_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 48);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(673, 375);
            this.gridControl1.TabIndex = 5;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1,
            this.gridView2});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.薪资组,
            this.员工编号,
            this.姓名,
            this.性别,
            this.发放单位,
            this.计算部门,
            this.公司,
            this.部门,
            this.上月薪等,
            this.上月薪级,
            this.是标准职级工资});
            styleFormatCondition1.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            styleFormatCondition1.Appearance.Options.UseForeColor = true;
            styleFormatCondition1.ApplyToRow = true;
            styleFormatCondition1.Column = this.是标准职级工资;
            styleFormatCondition1.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal;
            styleFormatCondition1.Value1 = false;
            this.gridView1.FormatConditions.AddRange(new DevExpress.XtraGrid.StyleFormatCondition[] {
            styleFormatCondition1});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.GroupCount = 3;
            this.gridView1.Name = "gridView1";
            this.gridView1.NewItemRowText = "点击这里增加新动作";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.薪资组, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.发放单位, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.计算部门, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gridView1.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
            // 
            // 薪资组
            // 
            this.薪资组.Caption = "薪资组";
            this.薪资组.FieldName = "薪资组名称";
            this.薪资组.Name = "薪资组";
            this.薪资组.Visible = true;
            this.薪资组.VisibleIndex = 3;
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
            this.员工编号.Width = 120;
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
            this.姓名.Width = 52;
            // 
            // 性别
            // 
            this.性别.Caption = "性别";
            this.性别.FieldName = "性别";
            this.性别.Name = "性别";
            this.性别.Visible = true;
            this.性别.VisibleIndex = 2;
            this.性别.Width = 36;
            // 
            // 发放单位
            // 
            this.发放单位.Caption = "发放单位";
            this.发放单位.FieldName = "财务公司";
            this.发放单位.Name = "发放单位";
            this.发放单位.Visible = true;
            this.发放单位.VisibleIndex = 6;
            // 
            // 计算部门
            // 
            this.计算部门.Caption = "计算部门";
            this.计算部门.FieldName = "财务部门";
            this.计算部门.Name = "计算部门";
            this.计算部门.Visible = true;
            this.计算部门.VisibleIndex = 4;
            // 
            // 公司
            // 
            this.公司.Caption = "公司";
            this.公司.FieldName = "公司名称";
            this.公司.Name = "公司";
            this.公司.Visible = true;
            this.公司.VisibleIndex = 3;
            this.公司.Width = 85;
            // 
            // 部门
            // 
            this.部门.Caption = "部门";
            this.部门.FieldName = "部门名称";
            this.部门.Name = "部门";
            this.部门.Visible = true;
            this.部门.VisibleIndex = 4;
            this.部门.Width = 134;
            // 
            // 上月薪等
            // 
            this.上月薪等.Caption = "上月薪等";
            this.上月薪等.FieldName = "上月工资.薪等名称";
            this.上月薪等.Name = "上月薪等";
            this.上月薪等.Visible = true;
            this.上月薪等.VisibleIndex = 5;
            this.上月薪等.Width = 107;
            // 
            // 上月薪级
            // 
            this.上月薪级.Caption = "上月薪级";
            this.上月薪级.FieldName = "上月工资.薪级名称";
            this.上月薪级.Name = "上月薪级";
            this.上月薪级.Visible = true;
            this.上月薪级.VisibleIndex = 6;
            this.上月薪级.Width = 120;
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
            // SearchEmployeeInfoForm
            // 
            this.ClientSize = new System.Drawing.Size(673, 423);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.panelControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SearchEmployeeInfoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "查询/选择员工";
            this.Load += new System.EventHandler(this.SearchEmployeeInfoForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chk仅显示在职员工.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk选择后自动关闭窗口.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cb薪资组.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchKey.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.ComponentModel.IContainer components = null;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btn查询;
        private DevExpress.XtraEditors.TextEdit searchKey;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn 员工编号;
        private DevExpress.XtraGrid.Columns.GridColumn 姓名;
        private DevExpress.XtraGrid.Columns.GridColumn 性别;
        private DevExpress.XtraGrid.Columns.GridColumn 公司;
        private DevExpress.XtraGrid.Columns.GridColumn 部门;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn col动作名称;
        private DevExpress.XtraGrid.Columns.GridColumn col动作代码;
        private DevExpress.XtraGrid.Columns.GridColumn col动作说明;
        private DevExpress.XtraGrid.Columns.GridColumn 薪资组;
        private DevExpress.XtraEditors.SimpleButton btn同步员工信息;
        private DevExpress.XtraEditors.ImageComboBoxEdit cb薪资组;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraGrid.Columns.GridColumn 上月薪等;
        private DevExpress.XtraEditors.CheckEdit chk选择后自动关闭窗口;
        private DevExpress.XtraEditors.CheckEdit chk仅显示在职员工;
        private DevExpress.XtraGrid.Columns.GridColumn 发放单位;
        private DevExpress.XtraGrid.Columns.GridColumn 计算部门;
        private DevExpress.XtraGrid.Columns.GridColumn 上月薪级;
        private DevExpress.XtraGrid.Columns.GridColumn 是标准职级工资;
    }
}
