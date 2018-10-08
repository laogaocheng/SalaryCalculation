namespace Hwagain.SalaryCalculation
{
    partial class PayBankReportForm
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
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.year = new DevExpress.XtraEditors.SpinEdit();
            this.month = new DevExpress.XtraEditors.ComboBoxEdit();
            this.btn按发放单位查询 = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.ccb发放单位 = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.btn另存为 = new DevExpress.XtraEditors.SimpleButton();
            this.cb账户类型 = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.toBankReportItemBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col银行名称 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col银行编号 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col员工编号 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col员工姓名 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col银行账户 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col账户名称 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col账户类型 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col员工序号 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col金额 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.year.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.month.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ccb发放单位.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cb账户类型.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toBankReportItemBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.labelControl3);
            this.panelControl1.Controls.Add(this.year);
            this.panelControl1.Controls.Add(this.month);
            this.panelControl1.Controls.Add(this.btn按发放单位查询);
            this.panelControl1.Controls.Add(this.labelControl4);
            this.panelControl1.Controls.Add(this.ccb发放单位);
            this.panelControl1.Controls.Add(this.btn另存为);
            this.panelControl1.Controls.Add(this.cb账户类型);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1064, 45);
            this.panelControl1.TabIndex = 3;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(169, 14);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(12, 14);
            this.labelControl2.TabIndex = 34;
            this.labelControl2.Text = "月";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(86, 13);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(12, 14);
            this.labelControl3.TabIndex = 33;
            this.labelControl3.Text = "年";
            // 
            // year
            // 
            this.year.EditValue = new decimal(new int[] {
            2014,
            0,
            0,
            0});
            this.year.Location = new System.Drawing.Point(12, 11);
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
            this.year.Size = new System.Drawing.Size(68, 20);
            this.year.TabIndex = 32;
            // 
            // month
            // 
            this.month.Location = new System.Drawing.Point(104, 11);
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
            this.month.TabIndex = 31;
            // 
            // btn按发放单位查询
            // 
            this.btn按发放单位查询.Location = new System.Drawing.Point(694, 11);
            this.btn按发放单位查询.Name = "btn按发放单位查询";
            this.btn按发放单位查询.Size = new System.Drawing.Size(62, 23);
            this.btn按发放单位查询.TabIndex = 28;
            this.btn按发放单位查询.Text = "查询";
            this.btn按发放单位查询.Click += new System.EventHandler(this.btn按发放单位查询_Click);
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(412, 13);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(48, 14);
            this.labelControl4.TabIndex = 30;
            this.labelControl4.Text = "发放单位";
            // 
            // ccb发放单位
            // 
            this.ccb发放单位.Location = new System.Drawing.Point(466, 11);
            this.ccb发放单位.Name = "ccb发放单位";
            this.ccb发放单位.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ccb发放单位.Size = new System.Drawing.Size(222, 20);
            this.ccb发放单位.TabIndex = 29;
            // 
            // btn另存为
            // 
            this.btn另存为.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn另存为.Location = new System.Drawing.Point(990, 14);
            this.btn另存为.Name = "btn另存为";
            this.btn另存为.Size = new System.Drawing.Size(62, 23);
            this.btn另存为.TabIndex = 10;
            this.btn另存为.Text = "另存为";
            this.btn另存为.Click += new System.EventHandler(this.btn另存为_Click);
            // 
            // cb账户类型
            // 
            this.cb账户类型.Location = new System.Drawing.Point(252, 11);
            this.cb账户类型.Name = "cb账户类型";
            this.cb账户类型.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cb账户类型.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("上表工资账号", "A", -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("封闭工资账号", "B", -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("年休假工资", "D", -1)});
            this.cb账户类型.Size = new System.Drawing.Size(148, 20);
            this.cb账户类型.TabIndex = 9;
            this.cb账户类型.SelectedValueChanged += new System.EventHandler(this.cb账户类型_SelectedValueChanged);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(188, 14);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(48, 14);
            this.labelControl1.TabIndex = 7;
            this.labelControl1.Text = "账户类型";
            // 
            // gridControl1
            // 
            this.gridControl1.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridControl1.DataSource = this.toBankReportItemBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 45);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1064, 378);
            this.gridControl1.TabIndex = 4;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // toBankReportItemBindingSource
            // 
            this.toBankReportItemBindingSource.DataSource = typeof(Hwagain.SalaryCalculation.Components.ToBankReportItem);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col银行名称,
            this.col银行编号,
            this.col员工编号,
            this.col员工姓名,
            this.col银行账户,
            this.col账户名称,
            this.col账户类型,
            this.col员工序号,
            this.col金额});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.GroupCount = 1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.col银行名称, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // col银行名称
            // 
            this.col银行名称.FieldName = "银行名称";
            this.col银行名称.Name = "col银行名称";
            this.col银行名称.SortMode = DevExpress.XtraGrid.ColumnSortMode.Custom;
            this.col银行名称.Visible = true;
            this.col银行名称.VisibleIndex = 0;
            // 
            // col银行编号
            // 
            this.col银行编号.FieldName = "银行编号";
            this.col银行编号.Name = "col银行编号";
            // 
            // col员工编号
            // 
            this.col员工编号.FieldName = "员工编号";
            this.col员工编号.Name = "col员工编号";
            // 
            // col员工姓名
            // 
            this.col员工姓名.FieldName = "员工姓名";
            this.col员工姓名.Name = "col员工姓名";
            this.col员工姓名.Visible = true;
            this.col员工姓名.VisibleIndex = 0;
            this.col员工姓名.Width = 115;
            // 
            // col银行账户
            // 
            this.col银行账户.FieldName = "银行账户";
            this.col银行账户.Name = "col银行账户";
            this.col银行账户.Visible = true;
            this.col银行账户.VisibleIndex = 1;
            this.col银行账户.Width = 177;
            // 
            // col账户名称
            // 
            this.col账户名称.FieldName = "账户名称";
            this.col账户名称.Name = "col账户名称";
            this.col账户名称.Width = 99;
            // 
            // col账户类型
            // 
            this.col账户类型.FieldName = "账户类型";
            this.col账户类型.Name = "col账户类型";
            // 
            // col员工序号
            // 
            this.col员工序号.FieldName = "员工序号";
            this.col员工序号.Name = "col员工序号";
            // 
            // col金额
            // 
            this.col金额.DisplayFormat.FormatString = "{0:#0.00}";
            this.col金额.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col金额.FieldName = "金额";
            this.col金额.Name = "col金额";
            this.col金额.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "金额", "{0:#0.00}")});
            this.col金额.Visible = true;
            this.col金额.VisibleIndex = 2;
            this.col金额.Width = 131;
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileName = "银行报盘表";
            this.saveFileDialog1.Filter = "Excel 文件 | *.xls";
            // 
            // PayBankReportForm
            // 
            this.ClientSize = new System.Drawing.Size(1064, 423);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.panelControl1);
            this.LookAndFeel.SkinName = "Summer 2008";
            this.Name = "PayBankReportForm";
            this.Text = "银行报盘表";
            this.Load += new System.EventHandler(this.PayBankReportForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.year.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.month.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ccb发放单位.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cb账户类型.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toBankReportItemBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.ComponentModel.IContainer components = null;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.ImageComboBoxEdit cb账户类型;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.BindingSource toBankReportItemBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn col银行名称;
        private DevExpress.XtraGrid.Columns.GridColumn col银行编号;
        private DevExpress.XtraGrid.Columns.GridColumn col员工编号;
        private DevExpress.XtraGrid.Columns.GridColumn col员工姓名;
        private DevExpress.XtraGrid.Columns.GridColumn col银行账户;
        private DevExpress.XtraGrid.Columns.GridColumn col账户名称;
        private DevExpress.XtraGrid.Columns.GridColumn col账户类型;
        private DevExpress.XtraGrid.Columns.GridColumn col员工序号;
        private DevExpress.XtraGrid.Columns.GridColumn col金额;
        private DevExpress.XtraEditors.SimpleButton btn另存为;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.SpinEdit year;
        private DevExpress.XtraEditors.ComboBoxEdit month;
        private DevExpress.XtraEditors.SimpleButton btn按发放单位查询;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.ImageComboBoxEdit ccb发放单位;
           
    }
}
