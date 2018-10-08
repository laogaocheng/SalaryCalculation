namespace Hwagain.SalaryCalculation
{
    partial class QueryEmployeePayInfoForm
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
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.chk选中部门后自动显示名单 = new DevExpress.XtraEditors.CheckEdit();
            this.chk包括下属机构 = new DevExpress.XtraEditors.CheckEdit();
            this.searchKey = new DevExpress.XtraEditors.TextEdit();
            this.btn查询 = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.薪等 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.公司 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.部门 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.员工编号 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.姓名 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.性别 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.月薪 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.年薪 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col动作名称 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col动作代码 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col动作说明 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.treeView1 = new System.Windows.Forms.TreeView();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chk选中部门后自动显示名单.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk包括下属机构.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchKey.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.chk选中部门后自动显示名单);
            this.panelControl1.Controls.Add(this.chk包括下属机构);
            this.panelControl1.Controls.Add(this.searchKey);
            this.panelControl1.Controls.Add(this.btn查询);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(770, 48);
            this.panelControl1.TabIndex = 2;
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl1.Location = new System.Drawing.Point(526, 26);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(232, 14);
            this.labelControl1.TabIndex = 22;
            this.labelControl1.Text = "说明：本表显示的是上个月在职员工的月薪.";
            // 
            // chk选中部门后自动显示名单
            // 
            this.chk选中部门后自动显示名单.EditValue = true;
            this.chk选中部门后自动显示名单.Location = new System.Drawing.Point(12, 23);
            this.chk选中部门后自动显示名单.Name = "chk选中部门后自动显示名单";
            this.chk选中部门后自动显示名单.Properties.Caption = "选中部门后自动显示名单";
            this.chk选中部门后自动显示名单.Size = new System.Drawing.Size(169, 20);
            this.chk选中部门后自动显示名单.TabIndex = 21;
            this.chk选中部门后自动显示名单.CheckedChanged += new System.EventHandler(this.chk选中部门后自动显示名单_CheckedChanged);
            // 
            // chk包括下属机构
            // 
            this.chk包括下属机构.Location = new System.Drawing.Point(12, 5);
            this.chk包括下属机构.Name = "chk包括下属机构";
            this.chk包括下属机构.Properties.Caption = "包括下属机构";
            this.chk包括下属机构.Size = new System.Drawing.Size(118, 20);
            this.chk包括下属机构.TabIndex = 20;
            // 
            // searchKey
            // 
            this.searchKey.Location = new System.Drawing.Point(260, 12);
            this.searchKey.Name = "searchKey";
            this.searchKey.Properties.NullValuePrompt = "请输入姓名";
            this.searchKey.Size = new System.Drawing.Size(137, 20);
            this.searchKey.TabIndex = 5;
            this.searchKey.KeyUp += new System.Windows.Forms.KeyEventHandler(this.searchKey_KeyUp);
            // 
            // btn查询
            // 
            this.btn查询.Location = new System.Drawing.Point(403, 10);
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
            this.gridControl1.Location = new System.Drawing.Point(260, 48);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(510, 459);
            this.gridControl1.TabIndex = 5;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1,
            this.gridView2});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.薪等,
            this.公司,
            this.部门,
            this.员工编号,
            this.姓名,
            this.性别,
            this.月薪,
            this.年薪});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.GroupCount = 1;
            this.gridView1.Name = "gridView1";
            this.gridView1.NewItemRowText = "点击这里增加新动作";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.薪等, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gridView1.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
            // 
            // 薪等
            // 
            this.薪等.Caption = "薪等";
            this.薪等.FieldName = "薪等名称";
            this.薪等.FieldNameSortGroup = "薪等";
            this.薪等.Name = "薪等";
            this.薪等.SortMode = DevExpress.XtraGrid.ColumnSortMode.Value;
            this.薪等.Visible = true;
            this.薪等.VisibleIndex = 3;
            // 
            // 公司
            // 
            this.公司.Caption = "公司";
            this.公司.FieldName = "公司名称";
            this.公司.Name = "公司";
            this.公司.Width = 85;
            // 
            // 部门
            // 
            this.部门.Caption = "部门";
            this.部门.FieldName = "部门名称";
            this.部门.Name = "部门";
            this.部门.Width = 134;
            // 
            // 员工编号
            // 
            this.员工编号.Caption = "员工编号";
            this.员工编号.FieldName = "员工编号";
            this.员工编号.Name = "员工编号";
            this.员工编号.Visible = true;
            this.员工编号.VisibleIndex = 0;
            this.员工编号.Width = 99;
            // 
            // 姓名
            // 
            this.姓名.Caption = "姓名";
            this.姓名.FieldName = "姓名";
            this.姓名.Name = "姓名";
            this.姓名.Visible = true;
            this.姓名.VisibleIndex = 1;
            this.姓名.Width = 80;
            // 
            // 性别
            // 
            this.性别.Caption = "性别";
            this.性别.FieldName = "性别";
            this.性别.Name = "性别";
            this.性别.Visible = true;
            this.性别.VisibleIndex = 2;
            this.性别.Width = 46;
            // 
            // 月薪
            // 
            this.月薪.AppearanceCell.Font = new System.Drawing.Font("华文中宋", 12F);
            this.月薪.AppearanceCell.Options.UseFont = true;
            this.月薪.Caption = "月薪";
            this.月薪.DisplayFormat.FormatString = "{0:0}";
            this.月薪.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.月薪.FieldName = "月薪";
            this.月薪.Name = "月薪";
            this.月薪.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            this.月薪.Visible = true;
            this.月薪.VisibleIndex = 3;
            this.月薪.Width = 95;
            // 
            // 年薪
            // 
            this.年薪.AppearanceCell.Font = new System.Drawing.Font("华文中宋", 12F);
            this.年薪.AppearanceCell.Options.UseFont = true;
            this.年薪.Caption = "年薪";
            this.年薪.DisplayFormat.FormatString = "{0:0}";
            this.年薪.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.年薪.FieldName = "年薪";
            this.年薪.Name = "年薪";
            this.年薪.Visible = true;
            this.年薪.VisibleIndex = 4;
            this.年薪.Width = 114;
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
            // treeView1
            // 
            this.treeView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Left;
            this.treeView1.ForeColor = System.Drawing.Color.Black;
            this.treeView1.HideSelection = false;
            this.treeView1.HotTracking = true;
            this.treeView1.Location = new System.Drawing.Point(0, 48);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(260, 459);
            this.treeView1.TabIndex = 6;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // QueryEmployeePayInfoForm
            // 
            this.ClientSize = new System.Drawing.Size(770, 507);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.panelControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "QueryEmployeePayInfoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "查询员工月薪";
            this.Load += new System.EventHandler(this.QueryEmployeePayInfoForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chk选中部门后自动显示名单.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk包括下属机构.Properties)).EndInit();
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
        private DevExpress.XtraGrid.Columns.GridColumn 公司;
        private DevExpress.XtraGrid.Columns.GridColumn 部门;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn col动作名称;
        private DevExpress.XtraGrid.Columns.GridColumn col动作代码;
        private DevExpress.XtraGrid.Columns.GridColumn col动作说明;
        private DevExpress.XtraGrid.Columns.GridColumn 薪等;
        private DevExpress.XtraEditors.CheckEdit chk包括下属机构;
        private System.Windows.Forms.TreeView treeView1;
        private DevExpress.XtraEditors.CheckEdit chk选中部门后自动显示名单;
        private DevExpress.XtraGrid.Columns.GridColumn 员工编号;
        private DevExpress.XtraGrid.Columns.GridColumn 姓名;
        private DevExpress.XtraGrid.Columns.GridColumn 性别;
        private DevExpress.XtraGrid.Columns.GridColumn 月薪;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraGrid.Columns.GridColumn 年薪;
    }
}
