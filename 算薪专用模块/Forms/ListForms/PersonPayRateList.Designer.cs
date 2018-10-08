namespace Hwagain.SalaryCalculation
{
    partial class PersonPayRateList
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
            this.有效 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.chk仅显示有效的记录 = new DevExpress.XtraEditors.CheckEdit();
            this.btn查询 = new DevExpress.XtraEditors.SimpleButton();
            this.searchKey = new DevExpress.XtraEditors.TextEdit();
            this.btn导出 = new DevExpress.XtraEditors.SimpleButton();
            this.btn设置个人职级工资无效 = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.薪资组 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.发放单位 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.计算部门 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.序号 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.员工编号 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.姓名 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.职务 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.生效日期 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.年薪 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.月薪 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.年终奖 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.月报销额度 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.津贴1名称 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.津贴1金额 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.津贴2名称 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.津贴2金额 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col动作名称 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col动作代码 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col动作说明 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chk仅显示有效的记录.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchKey.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // 有效
            // 
            this.有效.Caption = "有效";
            this.有效.FieldName = "有效";
            this.有效.Name = "有效";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.chk仅显示有效的记录);
            this.panelControl1.Controls.Add(this.btn查询);
            this.panelControl1.Controls.Add(this.searchKey);
            this.panelControl1.Controls.Add(this.btn导出);
            this.panelControl1.Controls.Add(this.btn设置个人职级工资无效);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(760, 48);
            this.panelControl1.TabIndex = 2;
            // 
            // chk仅显示有效的记录
            // 
            this.chk仅显示有效的记录.EditValue = true;
            this.chk仅显示有效的记录.Location = new System.Drawing.Point(156, 15);
            this.chk仅显示有效的记录.Name = "chk仅显示有效的记录";
            this.chk仅显示有效的记录.Properties.Caption = "仅显示有效的记录";
            this.chk仅显示有效的记录.Size = new System.Drawing.Size(128, 20);
            this.chk仅显示有效的记录.TabIndex = 13;
            this.chk仅显示有效的记录.CheckedChanged += new System.EventHandler(this.chk仅显示有效的记录_CheckedChanged);
            // 
            // btn查询
            // 
            this.btn查询.Location = new System.Drawing.Point(290, 14);
            this.btn查询.Name = "btn查询";
            this.btn查询.Size = new System.Drawing.Size(62, 23);
            this.btn查询.TabIndex = 12;
            this.btn查询.Text = "查询";
            this.btn查询.Click += new System.EventHandler(this.btn查询_Click);
            // 
            // searchKey
            // 
            this.searchKey.Location = new System.Drawing.Point(21, 15);
            this.searchKey.Name = "searchKey";
            this.searchKey.Properties.NullValuePrompt = "请输入要查询的姓名";
            this.searchKey.Size = new System.Drawing.Size(129, 20);
            this.searchKey.TabIndex = 11;
            // 
            // btn导出
            // 
            this.btn导出.Location = new System.Drawing.Point(358, 14);
            this.btn导出.Name = "btn导出";
            this.btn导出.Size = new System.Drawing.Size(62, 23);
            this.btn导出.TabIndex = 10;
            this.btn导出.Text = "导出";
            this.btn导出.Click += new System.EventHandler(this.btn导出_Click);
            // 
            // btn设置个人职级工资无效
            // 
            this.btn设置个人职级工资无效.Location = new System.Drawing.Point(538, 14);
            this.btn设置个人职级工资无效.Name = "btn设置个人职级工资无效";
            this.btn设置个人职级工资无效.Size = new System.Drawing.Size(132, 23);
            this.btn设置个人职级工资无效.TabIndex = 0;
            this.btn设置个人职级工资无效.Text = "将当前记录变为无效";
            this.btn设置个人职级工资无效.Click += new System.EventHandler(this.btn设置个人职级工资无效_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 48);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(760, 375);
            this.gridControl1.TabIndex = 3;
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
            this.序号,
            this.员工编号,
            this.姓名,
            this.职务,
            this.生效日期,
            this.年薪,
            this.月薪,
            this.年终奖,
            this.月报销额度,
            this.津贴1名称,
            this.津贴1金额,
            this.津贴2名称,
            this.津贴2金额,
            this.有效});
            styleFormatCondition1.Appearance.ForeColor = System.Drawing.Color.Silver;
            styleFormatCondition1.Appearance.Options.UseForeColor = true;
            styleFormatCondition1.ApplyToRow = true;
            styleFormatCondition1.Column = this.有效;
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
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.薪资组, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.发放单位, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.计算部门, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView1_FocusedRowChanged);
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
            // 序号
            // 
            this.序号.Caption = "序号";
            this.序号.FieldName = "序号";
            this.序号.Name = "序号";
            this.序号.Visible = true;
            this.序号.VisibleIndex = 0;
            this.序号.Width = 83;
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
            this.员工编号.Width = 62;
            // 
            // 姓名
            // 
            this.姓名.Caption = "姓名";
            this.姓名.FieldName = "姓名";
            this.姓名.Name = "姓名";
            this.姓名.OptionsColumn.AllowEdit = false;
            this.姓名.OptionsColumn.ReadOnly = true;
            this.姓名.Visible = true;
            this.姓名.VisibleIndex = 2;
            this.姓名.Width = 46;
            // 
            // 职务
            // 
            this.职务.Caption = "职务";
            this.职务.FieldName = "职务";
            this.职务.Name = "职务";
            this.职务.OptionsColumn.AllowEdit = false;
            this.职务.OptionsColumn.ReadOnly = true;
            this.职务.Visible = true;
            this.职务.VisibleIndex = 3;
            this.职务.Width = 91;
            // 
            // 生效日期
            // 
            this.生效日期.Caption = "执行时间";
            this.生效日期.FieldName = "生效日期";
            this.生效日期.Name = "生效日期";
            this.生效日期.OptionsColumn.AllowEdit = false;
            this.生效日期.OptionsColumn.ReadOnly = true;
            this.生效日期.Visible = true;
            this.生效日期.VisibleIndex = 4;
            this.生效日期.Width = 77;
            // 
            // 年薪
            // 
            this.年薪.Caption = "年薪";
            this.年薪.DisplayFormat.FormatString = "0";
            this.年薪.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.年薪.FieldName = "年薪";
            this.年薪.Name = "年薪";
            this.年薪.OptionsColumn.AllowEdit = false;
            this.年薪.OptionsColumn.ReadOnly = true;
            this.年薪.Visible = true;
            this.年薪.VisibleIndex = 6;
            this.年薪.Width = 101;
            // 
            // 月薪
            // 
            this.月薪.Caption = "月薪";
            this.月薪.DisplayFormat.FormatString = "0";
            this.月薪.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.月薪.FieldName = "月薪";
            this.月薪.Name = "月薪";
            this.月薪.OptionsColumn.AllowEdit = false;
            this.月薪.OptionsColumn.ReadOnly = true;
            this.月薪.Visible = true;
            this.月薪.VisibleIndex = 5;
            this.月薪.Width = 73;
            // 
            // 年终奖
            // 
            this.年终奖.Caption = "年终奖";
            this.年终奖.DisplayFormat.FormatString = "0";
            this.年终奖.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.年终奖.FieldName = "年终奖";
            this.年终奖.Name = "年终奖";
            this.年终奖.OptionsColumn.AllowEdit = false;
            this.年终奖.OptionsColumn.ReadOnly = true;
            this.年终奖.Visible = true;
            this.年终奖.VisibleIndex = 7;
            this.年终奖.Width = 86;
            // 
            // 月报销额度
            // 
            this.月报销额度.Caption = "月报销额度";
            this.月报销额度.DisplayFormat.FormatString = "0";
            this.月报销额度.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.月报销额度.FieldName = "月报销额度";
            this.月报销额度.Name = "月报销额度";
            this.月报销额度.OptionsColumn.AllowEdit = false;
            this.月报销额度.OptionsColumn.ReadOnly = true;
            this.月报销额度.Visible = true;
            this.月报销额度.VisibleIndex = 8;
            this.月报销额度.Width = 79;
            // 
            // 津贴1名称
            // 
            this.津贴1名称.Caption = "津贴1名称";
            this.津贴1名称.FieldName = "津贴1名称";
            this.津贴1名称.Name = "津贴1名称";
            this.津贴1名称.OptionsColumn.AllowEdit = false;
            this.津贴1名称.OptionsColumn.ReadOnly = true;
            this.津贴1名称.Visible = true;
            this.津贴1名称.VisibleIndex = 9;
            this.津贴1名称.Width = 87;
            // 
            // 津贴1金额
            // 
            this.津贴1金额.Caption = "津贴1金额";
            this.津贴1金额.DisplayFormat.FormatString = "0";
            this.津贴1金额.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.津贴1金额.FieldName = "津贴1金额";
            this.津贴1金额.Name = "津贴1金额";
            this.津贴1金额.OptionsColumn.AllowEdit = false;
            this.津贴1金额.OptionsColumn.ReadOnly = true;
            this.津贴1金额.Visible = true;
            this.津贴1金额.VisibleIndex = 10;
            this.津贴1金额.Width = 76;
            // 
            // 津贴2名称
            // 
            this.津贴2名称.Caption = "津贴2名称";
            this.津贴2名称.FieldName = "津贴2名称";
            this.津贴2名称.Name = "津贴2名称";
            this.津贴2名称.OptionsColumn.AllowEdit = false;
            this.津贴2名称.OptionsColumn.ReadOnly = true;
            this.津贴2名称.Visible = true;
            this.津贴2名称.VisibleIndex = 11;
            this.津贴2名称.Width = 78;
            // 
            // 津贴2金额
            // 
            this.津贴2金额.Caption = "津贴2金额";
            this.津贴2金额.DisplayFormat.FormatString = "0";
            this.津贴2金额.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.津贴2金额.FieldName = "津贴2金额";
            this.津贴2金额.Name = "津贴2金额";
            this.津贴2金额.OptionsColumn.AllowEdit = false;
            this.津贴2金额.OptionsColumn.ReadOnly = true;
            this.津贴2金额.Visible = true;
            this.津贴2金额.VisibleIndex = 12;
            this.津贴2金额.Width = 90;
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
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileName = "不执行标准的员工职级工资明细表";
            this.saveFileDialog1.Filter = "Excel 文件 | *.xls";
            // 
            // PersonPayRateList
            // 
            this.ClientSize = new System.Drawing.Size(760, 423);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.panelControl1);
            this.Name = "PersonPayRateList";
            this.Text = "个人职级工资表";
            this.Load += new System.EventHandler(this.PersonPayRateList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chk仅显示有效的记录.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchKey.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.ComponentModel.IContainer components = null;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btn设置个人职级工资无效;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn 序号;
        private DevExpress.XtraGrid.Columns.GridColumn 员工编号;
        private DevExpress.XtraGrid.Columns.GridColumn 姓名;
        private DevExpress.XtraGrid.Columns.GridColumn 职务;
        private DevExpress.XtraGrid.Columns.GridColumn 生效日期;
        private DevExpress.XtraGrid.Columns.GridColumn 年薪;
        private DevExpress.XtraGrid.Columns.GridColumn 年终奖;
        private DevExpress.XtraGrid.Columns.GridColumn 月报销额度;
        private DevExpress.XtraGrid.Columns.GridColumn 津贴1名称;
        private DevExpress.XtraGrid.Columns.GridColumn 津贴1金额;
        private DevExpress.XtraGrid.Columns.GridColumn 津贴2名称;
        private DevExpress.XtraGrid.Columns.GridColumn 津贴2金额;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn col动作名称;
        private DevExpress.XtraGrid.Columns.GridColumn col动作代码;
        private DevExpress.XtraGrid.Columns.GridColumn col动作说明;
        private DevExpress.XtraGrid.Columns.GridColumn 月薪;
        private DevExpress.XtraEditors.SimpleButton btn导出;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private DevExpress.XtraGrid.Columns.GridColumn 薪资组;
        private DevExpress.XtraGrid.Columns.GridColumn 发放单位;
        private DevExpress.XtraGrid.Columns.GridColumn 计算部门;
        private DevExpress.XtraEditors.TextEdit searchKey;
        private DevExpress.XtraEditors.SimpleButton btn查询;
        private DevExpress.XtraEditors.CheckEdit chk仅显示有效的记录;
        private DevExpress.XtraGrid.Columns.GridColumn 有效;
    }
}
