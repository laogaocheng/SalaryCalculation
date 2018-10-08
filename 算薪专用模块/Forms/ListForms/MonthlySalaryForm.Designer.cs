namespace Hwagain.SalaryCalculation
{
    partial class MonthlySalaryForm
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
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.monthlySalaryInputBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.advBandedGridView1 = new DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView();
            this.gridBand3 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.序号 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand12 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.部门 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand2 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.员工编号 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand13 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.姓名 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand14 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.性别 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand15 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.职务 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand4 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridBand6 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.评定_职级 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand7 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.评定_月薪 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand5 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridBand8 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.执行_职级 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand10 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.执行_月薪类型 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand9 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.执行_月薪 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.标识 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.薪酬体系 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.职等 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.期号 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.开始执行日期 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.repositoryItemDate = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.gridBand11 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.备注 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.repositoryItemSalaryType = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.repositoryItemMonthlySalary = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemRank = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.btn导出 = new DevExpress.XtraEditors.SimpleButton();
            this.lbl标题 = new DevExpress.XtraEditors.LabelControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.monthlySalaryInputBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.advBandedGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDate.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSalaryType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMonthlySalary)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemRank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridControl1.DataSource = this.monthlySalaryInputBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 48);
            this.gridControl1.MainView = this.advBandedGridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemSalaryType,
            this.repositoryItemMonthlySalary,
            this.repositoryItemRank,
            this.repositoryItemDate});
            this.gridControl1.Size = new System.Drawing.Size(942, 472);
            this.gridControl1.TabIndex = 5;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.advBandedGridView1});
            // 
            // monthlySalaryInputBindingSource
            // 
            this.monthlySalaryInputBindingSource.DataSource = typeof(Hwagain.SalaryCalculation.Components.MonthlySalaryInput);
            // 
            // advBandedGridView1
            // 
            this.advBandedGridView1.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand3,
            this.gridBand12,
            this.gridBand2,
            this.gridBand13,
            this.gridBand14,
            this.gridBand15,
            this.gridBand4,
            this.gridBand5,
            this.gridBand1,
            this.gridBand11});
            this.advBandedGridView1.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.标识,
            this.序号,
            this.部门,
            this.员工编号,
            this.姓名,
            this.性别,
            this.职务,
            this.薪酬体系,
            this.职等,
            this.期号,
            this.评定_职级,
            this.评定_月薪,
            this.执行_职级,
            this.执行_月薪类型,
            this.执行_月薪,
            this.开始执行日期,
            this.备注});
            this.advBandedGridView1.GridControl = this.gridControl1;
            this.advBandedGridView1.Name = "advBandedGridView1";
            this.advBandedGridView1.NewItemRowText = "点击这里增加新动作";
            this.advBandedGridView1.OptionsBehavior.Editable = false;
            this.advBandedGridView1.OptionsBehavior.ReadOnly = true;
            this.advBandedGridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.advBandedGridView1.OptionsView.ShowColumnHeaders = false;
            this.advBandedGridView1.OptionsView.ShowGroupPanel = false;
            // 
            // gridBand3
            // 
            this.gridBand3.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand3.Caption = "序号";
            this.gridBand3.Columns.Add(this.序号);
            this.gridBand3.Name = "gridBand3";
            this.gridBand3.VisibleIndex = 0;
            this.gridBand3.Width = 50;
            // 
            // 序号
            // 
            this.序号.AppearanceCell.Options.UseTextOptions = true;
            this.序号.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.序号.Caption = "序号";
            this.序号.FieldName = "序号";
            this.序号.Name = "序号";
            this.序号.OptionsColumn.ReadOnly = true;
            this.序号.Visible = true;
            this.序号.Width = 50;
            // 
            // gridBand12
            // 
            this.gridBand12.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand12.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand12.Caption = "部门";
            this.gridBand12.Columns.Add(this.部门);
            this.gridBand12.Name = "gridBand12";
            this.gridBand12.VisibleIndex = 1;
            this.gridBand12.Width = 83;
            // 
            // 部门
            // 
            this.部门.AppearanceCell.Options.UseTextOptions = true;
            this.部门.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.部门.Caption = "部门";
            this.部门.FieldName = "部门";
            this.部门.Name = "部门";
            this.部门.Visible = true;
            this.部门.Width = 83;
            // 
            // gridBand2
            // 
            this.gridBand2.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand2.Caption = "员工编号";
            this.gridBand2.Columns.Add(this.员工编号);
            this.gridBand2.Name = "gridBand2";
            this.gridBand2.VisibleIndex = 2;
            this.gridBand2.Width = 63;
            // 
            // 员工编号
            // 
            this.员工编号.AppearanceCell.Options.UseTextOptions = true;
            this.员工编号.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.员工编号.Caption = "员工编号";
            this.员工编号.FieldName = "员工编号";
            this.员工编号.Name = "员工编号";
            this.员工编号.OptionsColumn.ReadOnly = true;
            this.员工编号.Visible = true;
            this.员工编号.Width = 63;
            // 
            // gridBand13
            // 
            this.gridBand13.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand13.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand13.Caption = "姓名";
            this.gridBand13.Columns.Add(this.姓名);
            this.gridBand13.Name = "gridBand13";
            this.gridBand13.VisibleIndex = 3;
            this.gridBand13.Width = 61;
            // 
            // 姓名
            // 
            this.姓名.AppearanceCell.Options.UseTextOptions = true;
            this.姓名.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.姓名.Caption = "姓名";
            this.姓名.FieldName = "姓名";
            this.姓名.Name = "姓名";
            this.姓名.Visible = true;
            this.姓名.Width = 61;
            // 
            // gridBand14
            // 
            this.gridBand14.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand14.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand14.Caption = "性别";
            this.gridBand14.Columns.Add(this.性别);
            this.gridBand14.Name = "gridBand14";
            this.gridBand14.VisibleIndex = 4;
            this.gridBand14.Width = 46;
            // 
            // 性别
            // 
            this.性别.AppearanceCell.Options.UseTextOptions = true;
            this.性别.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.性别.Caption = "性别";
            this.性别.FieldName = "性别";
            this.性别.Name = "性别";
            this.性别.Visible = true;
            this.性别.Width = 46;
            // 
            // gridBand15
            // 
            this.gridBand15.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand15.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand15.Caption = "职务";
            this.gridBand15.Columns.Add(this.职务);
            this.gridBand15.Name = "gridBand15";
            this.gridBand15.VisibleIndex = 5;
            this.gridBand15.Width = 75;
            // 
            // 职务
            // 
            this.职务.AppearanceCell.Options.UseTextOptions = true;
            this.职务.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.职务.Caption = "职务";
            this.职务.FieldName = "职务";
            this.职务.Name = "职务";
            this.职务.Visible = true;
            // 
            // gridBand4
            // 
            this.gridBand4.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand4.Caption = "评定职级、月薪";
            this.gridBand4.Children.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand6,
            this.gridBand7});
            this.gridBand4.Name = "gridBand4";
            this.gridBand4.VisibleIndex = 6;
            this.gridBand4.Width = 134;
            // 
            // gridBand6
            // 
            this.gridBand6.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand6.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand6.Caption = "职级";
            this.gridBand6.Columns.Add(this.评定_职级);
            this.gridBand6.Name = "gridBand6";
            this.gridBand6.VisibleIndex = 0;
            this.gridBand6.Width = 67;
            // 
            // 评定_职级
            // 
            this.评定_职级.AppearanceCell.Options.UseTextOptions = true;
            this.评定_职级.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.评定_职级.Caption = "职级";
            this.评定_职级.FieldName = "评定_职级";
            this.评定_职级.Name = "评定_职级";
            this.评定_职级.Visible = true;
            this.评定_职级.Width = 67;
            // 
            // gridBand7
            // 
            this.gridBand7.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand7.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand7.Caption = "月薪";
            this.gridBand7.Columns.Add(this.评定_月薪);
            this.gridBand7.Name = "gridBand7";
            this.gridBand7.VisibleIndex = 1;
            this.gridBand7.Width = 67;
            // 
            // 评定_月薪
            // 
            this.评定_月薪.AppearanceCell.Options.UseTextOptions = true;
            this.评定_月薪.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.评定_月薪.Caption = "月薪";
            this.评定_月薪.DisplayFormat.FormatString = "{#0:0.#}";
            this.评定_月薪.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.评定_月薪.FieldName = "评定_月薪";
            this.评定_月薪.Name = "评定_月薪";
            this.评定_月薪.OptionsColumn.ReadOnly = true;
            this.评定_月薪.Visible = true;
            this.评定_月薪.Width = 67;
            // 
            // gridBand5
            // 
            this.gridBand5.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand5.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand5.Caption = "确定执行职级、月薪";
            this.gridBand5.Children.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand8,
            this.gridBand10,
            this.gridBand9});
            this.gridBand5.Name = "gridBand5";
            this.gridBand5.VisibleIndex = 7;
            this.gridBand5.Width = 201;
            // 
            // gridBand8
            // 
            this.gridBand8.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand8.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand8.Caption = "职级";
            this.gridBand8.Columns.Add(this.执行_职级);
            this.gridBand8.Name = "gridBand8";
            this.gridBand8.VisibleIndex = 0;
            this.gridBand8.Width = 67;
            // 
            // 执行_职级
            // 
            this.执行_职级.AppearanceCell.Options.UseTextOptions = true;
            this.执行_职级.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.执行_职级.Caption = "职级";
            this.执行_职级.FieldName = "执行_职级";
            this.执行_职级.Name = "执行_职级";
            this.执行_职级.Visible = true;
            this.执行_职级.Width = 67;
            // 
            // gridBand10
            // 
            this.gridBand10.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand10.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand10.Caption = "月薪类型";
            this.gridBand10.Columns.Add(this.执行_月薪类型);
            this.gridBand10.Name = "gridBand10";
            this.gridBand10.VisibleIndex = 1;
            this.gridBand10.Width = 67;
            // 
            // 执行_月薪类型
            // 
            this.执行_月薪类型.AppearanceCell.Options.UseTextOptions = true;
            this.执行_月薪类型.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.执行_月薪类型.Caption = "月薪类型";
            this.执行_月薪类型.FieldName = "执行_月薪类型";
            this.执行_月薪类型.Name = "执行_月薪类型";
            this.执行_月薪类型.Visible = true;
            this.执行_月薪类型.Width = 67;
            // 
            // gridBand9
            // 
            this.gridBand9.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand9.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand9.Caption = "月薪";
            this.gridBand9.Columns.Add(this.执行_月薪);
            this.gridBand9.Name = "gridBand9";
            this.gridBand9.VisibleIndex = 2;
            this.gridBand9.Width = 67;
            // 
            // 执行_月薪
            // 
            this.执行_月薪.AppearanceCell.Options.UseTextOptions = true;
            this.执行_月薪.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.执行_月薪.Caption = "月薪";
            this.执行_月薪.DisplayFormat.FormatString = "{#0:0.#}";
            this.执行_月薪.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.执行_月薪.FieldName = "执行_月薪";
            this.执行_月薪.Name = "执行_月薪";
            this.执行_月薪.Visible = true;
            this.执行_月薪.Width = 67;
            // 
            // gridBand1
            // 
            this.gridBand1.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand1.Caption = "执行开始时间";
            this.gridBand1.Columns.Add(this.标识);
            this.gridBand1.Columns.Add(this.薪酬体系);
            this.gridBand1.Columns.Add(this.职等);
            this.gridBand1.Columns.Add(this.期号);
            this.gridBand1.Columns.Add(this.开始执行日期);
            this.gridBand1.Name = "gridBand1";
            this.gridBand1.VisibleIndex = 8;
            this.gridBand1.Width = 99;
            // 
            // 标识
            // 
            this.标识.Caption = "标识";
            this.标识.FieldName = "标识";
            this.标识.Name = "标识";
            this.标识.Width = 67;
            // 
            // 薪酬体系
            // 
            this.薪酬体系.Caption = "薪酬体系";
            this.薪酬体系.FieldName = "薪酬体系";
            this.薪酬体系.Name = "薪酬体系";
            this.薪酬体系.Width = 67;
            // 
            // 职等
            // 
            this.职等.Caption = "职等";
            this.职等.Name = "职等";
            this.职等.Width = 67;
            // 
            // 期号
            // 
            this.期号.Caption = "期号";
            this.期号.Name = "期号";
            this.期号.Width = 67;
            // 
            // 开始执行日期
            // 
            this.开始执行日期.AppearanceCell.Options.UseTextOptions = true;
            this.开始执行日期.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.开始执行日期.Caption = "执行开始日期";
            this.开始执行日期.ColumnEdit = this.repositoryItemDate;
            this.开始执行日期.FieldName = "开始执行日期";
            this.开始执行日期.Name = "开始执行日期";
            this.开始执行日期.Visible = true;
            this.开始执行日期.Width = 99;
            // 
            // repositoryItemDate
            // 
            this.repositoryItemDate.AutoHeight = false;
            this.repositoryItemDate.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDate.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDate.Name = "repositoryItemDate";
            this.repositoryItemDate.NullDate = new System.DateTime(((long)(0)));
            // 
            // gridBand11
            // 
            this.gridBand11.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand11.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand11.Caption = "备注";
            this.gridBand11.Columns.Add(this.备注);
            this.gridBand11.Name = "gridBand11";
            this.gridBand11.VisibleIndex = 9;
            this.gridBand11.Width = 107;
            // 
            // 备注
            // 
            this.备注.Caption = "备注";
            this.备注.FieldName = "备注";
            this.备注.Name = "备注";
            this.备注.Visible = true;
            this.备注.Width = 107;
            // 
            // repositoryItemSalaryType
            // 
            this.repositoryItemSalaryType.AutoHeight = false;
            this.repositoryItemSalaryType.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemSalaryType.Items.AddRange(new object[] {
            "常资",
            "特资"});
            this.repositoryItemSalaryType.Name = "repositoryItemSalaryType";
            // 
            // repositoryItemMonthlySalary
            // 
            this.repositoryItemMonthlySalary.AutoHeight = false;
            this.repositoryItemMonthlySalary.DisplayFormat.FormatString = "{0:0}";
            this.repositoryItemMonthlySalary.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.repositoryItemMonthlySalary.Name = "repositoryItemMonthlySalary";
            // 
            // repositoryItemRank
            // 
            this.repositoryItemRank.AutoHeight = false;
            this.repositoryItemRank.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemRank.Name = "repositoryItemRank";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileName = "薪酬执行明细表";
            this.saveFileDialog1.Filter = "Excel 文件 | *.xls";
            // 
            // btn导出
            // 
            this.btn导出.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn导出.Enabled = false;
            this.btn导出.Location = new System.Drawing.Point(822, 13);
            this.btn导出.Name = "btn导出";
            this.btn导出.Size = new System.Drawing.Size(62, 23);
            this.btn导出.TabIndex = 42;
            this.btn导出.Text = "导出";
            this.btn导出.Click += new System.EventHandler(this.btn导出_Click);
            // 
            // lbl标题
            // 
            this.lbl标题.Appearance.Font = new System.Drawing.Font("黑体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl标题.Appearance.Options.UseFont = true;
            this.lbl标题.Location = new System.Drawing.Point(22, 18);
            this.lbl标题.Name = "lbl标题";
            this.lbl标题.Size = new System.Drawing.Size(40, 19);
            this.lbl标题.TabIndex = 43;
            this.lbl标题.Text = "标题";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.lbl标题);
            this.panelControl1.Controls.Add(this.btn导出);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(942, 48);
            this.panelControl1.TabIndex = 4;
            // 
            // MonthlySalaryForm
            // 
            this.ClientSize = new System.Drawing.Size(942, 520);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.panelControl1);
            this.LookAndFeel.SkinName = "Summer 2008";
            this.Name = "MonthlySalaryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "薪酬执行明细";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MonthlySalaryForm_FormClosed);
            this.Load += new System.EventHandler(this.MonthlySalaryForm_Load);
            this.Shown += new System.EventHandler(this.MonthlySalaryForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.monthlySalaryInputBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.advBandedGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDate.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSalaryType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMonthlySalary)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemRank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.ComponentModel.IContainer components = null;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.BindingSource monthlySalaryInputBindingSource;
        private DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView advBandedGridView1;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn 序号;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn 员工编号;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn 评定_职级;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn 评定_月薪;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn 执行_职级;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn 执行_月薪类型;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn 执行_月薪;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn 标识;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn 薪酬体系;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn 职等;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn 期号;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn 开始执行日期;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn 备注;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemSalaryType;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemMonthlySalary;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemRank;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand3;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand12;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn 部门;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand2;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand13;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn 姓名;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand14;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn 性别;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand15;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn 职务;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand4;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand6;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand7;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand5;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand8;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand10;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand9;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand1;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand11;
        private DevExpress.XtraEditors.SimpleButton btn导出;
        private DevExpress.XtraEditors.LabelControl lbl标题;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDate;
    }
}
