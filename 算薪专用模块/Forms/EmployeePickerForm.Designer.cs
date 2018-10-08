namespace Hwagain.SalaryCalculation
{
    partial class EmployeePickerForm
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
            DevExpress.XtraGrid.GridFormatRule gridFormatRule1 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleValue formatConditionRuleValue1 = new DevExpress.XtraEditors.FormatConditionRuleValue();
            this.标记 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.员工编号 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.姓名 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.性别 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.公司 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.部门 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.职务 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.职等 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col动作名称 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col动作代码 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col动作说明 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // 标记
            // 
            this.标记.Caption = "标记";
            this.标记.FieldName = "标记";
            this.标记.Name = "标记";
            // 
            // gridControl1
            // 
            this.gridControl1.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(551, 423);
            this.gridControl1.TabIndex = 5;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1,
            this.gridView2});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.员工编号,
            this.姓名,
            this.性别,
            this.公司,
            this.部门,
            this.职务,
            this.职等,
            this.标记});
            gridFormatRule1.ApplyToRow = true;
            gridFormatRule1.Column = this.标记;
            gridFormatRule1.Name = "标记";
            formatConditionRuleValue1.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            formatConditionRuleValue1.Appearance.Options.UseForeColor = true;
            formatConditionRuleValue1.Condition = DevExpress.XtraEditors.FormatCondition.Equal;
            formatConditionRuleValue1.Value1 = true;
            gridFormatRule1.Rule = formatConditionRuleValue1;
            this.gridView1.FormatRules.Add(gridFormatRule1);
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.NewItemRowText = "点击这里增加新动作";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
            // 
            // 员工编号
            // 
            this.员工编号.AppearanceCell.Options.UseTextOptions = true;
            this.员工编号.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.员工编号.Caption = "员工编号";
            this.员工编号.FieldName = "员工编号";
            this.员工编号.Name = "员工编号";
            this.员工编号.OptionsColumn.AllowEdit = false;
            this.员工编号.OptionsColumn.ReadOnly = true;
            this.员工编号.Visible = true;
            this.员工编号.VisibleIndex = 0;
            this.员工编号.Width = 65;
            // 
            // 姓名
            // 
            this.姓名.AppearanceCell.Options.UseTextOptions = true;
            this.姓名.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.姓名.Caption = "姓名";
            this.姓名.FieldName = "姓名";
            this.姓名.Name = "姓名";
            this.姓名.OptionsColumn.AllowEdit = false;
            this.姓名.OptionsColumn.ReadOnly = true;
            this.姓名.Visible = true;
            this.姓名.VisibleIndex = 1;
            this.姓名.Width = 53;
            // 
            // 性别
            // 
            this.性别.AppearanceCell.Options.UseTextOptions = true;
            this.性别.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.性别.Caption = "性别";
            this.性别.FieldName = "性别";
            this.性别.Name = "性别";
            this.性别.Visible = true;
            this.性别.VisibleIndex = 2;
            this.性别.Width = 36;
            // 
            // 公司
            // 
            this.公司.AppearanceCell.Options.UseTextOptions = true;
            this.公司.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.公司.Caption = "公司";
            this.公司.FieldName = "公司名称";
            this.公司.Name = "公司";
            this.公司.Visible = true;
            this.公司.VisibleIndex = 3;
            this.公司.Width = 95;
            // 
            // 部门
            // 
            this.部门.AppearanceCell.Options.UseTextOptions = true;
            this.部门.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.部门.Caption = "部门";
            this.部门.FieldName = "部门名称";
            this.部门.Name = "部门";
            this.部门.Visible = true;
            this.部门.VisibleIndex = 4;
            this.部门.Width = 85;
            // 
            // 职务
            // 
            this.职务.AppearanceCell.Options.UseTextOptions = true;
            this.职务.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.职务.Caption = "职务";
            this.职务.FieldName = "职务名称";
            this.职务.Name = "职务";
            this.职务.Visible = true;
            this.职务.VisibleIndex = 5;
            this.职务.Width = 93;
            // 
            // 职等
            // 
            this.职等.AppearanceCell.Options.UseTextOptions = true;
            this.职等.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.职等.Caption = "职等";
            this.职等.FieldName = "职等";
            this.职等.Name = "职等";
            this.职等.Width = 106;
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
            // EmployeePickerForm
            // 
            this.ClientSize = new System.Drawing.Size(551, 423);
            this.Controls.Add(this.gridControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EmployeePickerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "人员选择器";
            this.Load += new System.EventHandler(this.SelectEmployeeForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.ComponentModel.IContainer components = null;
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
        private DevExpress.XtraGrid.Columns.GridColumn 职务;
        private DevExpress.XtraGrid.Columns.GridColumn 职等;
        private DevExpress.XtraGrid.Columns.GridColumn 标记;
    }
}
