namespace Hwagain.SalaryCalculation
{
    partial class SalaryAdjustDetail
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
            this.�ѵ������� = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl�ڼ� = new System.Windows.Forms.Label();
            this.lbl���� = new System.Windows.Forms.Label();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Ա����� = new DevExpress.XtraGrid.Columns.GridColumn();
            this.���� = new DevExpress.XtraGrid.Columns.GridColumn();
            this.����ְ�� = new DevExpress.XtraGrid.Columns.GridColumn();
            this.����ְ������ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.���¹���ְ�� = new DevExpress.XtraGrid.Columns.GridColumn();
            this.����ְ�� = new DevExpress.XtraGrid.Columns.GridColumn();
            this.����ְ������ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.���¹���ְ�� = new DevExpress.XtraGrid.Columns.GridColumn();
            this.���ʱ仯 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.label2 = new System.Windows.Forms.Label();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // �ѵ�������
            // 
            this.�ѵ�������.Caption = "�ѵ�������";
            this.�ѵ�������.FieldName = "�ѵ�������";
            this.�ѵ�������.Name = "�ѵ�������";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.label1);
            this.panelControl1.Controls.Add(this.lbl�ڼ�);
            this.panelControl1.Controls.Add(this.lbl����);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(670, 65);
            this.panelControl1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 11F);
            this.label1.ForeColor = System.Drawing.Color.OrangeRed;
            this.label1.Location = new System.Drawing.Point(12, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(418, 18);
            this.label1.TabIndex = 13;
            this.label1.Text = "��������ΪӦ�õ������ʵ���Ա�����к�ɫ�ı�ʾ��û�е���.";
            // 
            // lbl�ڼ�
            // 
            this.lbl�ڼ�.AutoSize = true;
            this.lbl�ڼ�.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl�ڼ�.Location = new System.Drawing.Point(192, 32);
            this.lbl�ڼ�.Name = "lbl�ڼ�";
            this.lbl�ڼ�.Size = new System.Drawing.Size(0, 25);
            this.lbl�ڼ�.TabIndex = 12;
            // 
            // lbl����
            // 
            this.lbl����.AutoSize = true;
            this.lbl����.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl����.Location = new System.Drawing.Point(12, 7);
            this.lbl����.Name = "lbl����";
            this.lbl����.Size = new System.Drawing.Size(243, 25);
            this.lbl����.TabIndex = 11;
            this.lbl����.Text = "ְ���춯���ʵ��������";
            // 
            // gridControl1
            // 
            this.gridControl1.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 65);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(670, 391);
            this.gridControl1.TabIndex = 3;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.Ա�����,
            this.����,
            this.����ְ��,
            this.����ְ������,
            this.���¹���ְ��,
            this.����ְ��,
            this.����ְ������,
            this.���¹���ְ��,
            this.���ʱ仯,
            this.�ѵ�������});
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            styleFormatCondition1.Appearance.BackColor = System.Drawing.Color.Red;
            styleFormatCondition1.Appearance.ForeColor = System.Drawing.Color.Gold;
            styleFormatCondition1.Appearance.Options.UseBackColor = true;
            styleFormatCondition1.Appearance.Options.UseForeColor = true;
            styleFormatCondition1.ApplyToRow = true;
            styleFormatCondition1.Column = this.�ѵ�������;
            styleFormatCondition1.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal;
            styleFormatCondition1.Value1 = false;
            this.gridView1.FormatConditions.AddRange(new DevExpress.XtraGrid.StyleFormatCondition[] {
            styleFormatCondition1});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "Ա�����", null, " {0:#0} ��"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "���¹���.ְ������", this.����ְ������, "{0:#0}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "���¹���.ְ������", this.����ְ������, "{0:#0}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "���ʱ仯", this.���ʱ仯, "{0:#0}")});
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // Ա�����
            // 
            this.Ա�����.Caption = "Ա�����";
            this.Ա�����.FieldName = "Ա����Ϣ.Ա�����";
            this.Ա�����.Name = "Ա�����";
            this.Ա�����.OptionsColumn.AllowEdit = false;
            this.Ա�����.OptionsColumn.ReadOnly = true;
            this.Ա�����.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "Ա����Ϣ.Ա�����", "�ϼ� {0:#0} ��")});
            this.Ա�����.Visible = true;
            this.Ա�����.VisibleIndex = 0;
            this.Ա�����.Width = 82;
            // 
            // ����
            // 
            this.����.Caption = "����";
            this.����.FieldName = "Ա����Ϣ.����";
            this.����.Name = "����";
            this.����.OptionsColumn.AllowEdit = false;
            this.����.OptionsColumn.ReadOnly = true;
            this.����.Visible = true;
            this.����.VisibleIndex = 1;
            this.����.Width = 65;
            // 
            // ����ְ��
            // 
            this.����ְ��.Caption = "����ְ��";
            this.����ְ��.FieldName = "���¹���.ְ������";
            this.����ְ��.Name = "����ְ��";
            this.����ְ��.Width = 109;
            // 
            // ����ְ������
            // 
            this.����ְ������.Caption = "���¹���";
            this.����ְ������.DisplayFormat.FormatString = "{0:#0}";
            this.����ְ������.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.����ְ������.FieldName = "����ְ������";
            this.����ְ������.Name = "����ְ������";
            this.����ְ������.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "���¹���.ְ������", "{0:#0}")});
            this.����ְ������.Visible = true;
            this.����ְ������.VisibleIndex = 4;
            this.����ְ������.Width = 90;
            // 
            // ���¹���ְ��
            // 
            this.���¹���ְ��.Caption = "����ְ��";
            this.���¹���ְ��.FieldName = "���¹���.����ְ��";
            this.���¹���ְ��.Name = "���¹���ְ��";
            this.���¹���ְ��.Visible = true;
            this.���¹���ְ��.VisibleIndex = 2;
            this.���¹���ְ��.Width = 86;
            // 
            // ����ְ��
            // 
            this.����ְ��.Caption = "����ְ��";
            this.����ְ��.FieldName = "���¹���.ְ������";
            this.����ְ��.Name = "����ְ��";
            this.����ְ��.Width = 110;
            // 
            // ����ְ������
            // 
            this.����ְ������.Caption = "���¹���";
            this.����ְ������.DisplayFormat.FormatString = "{0:#0}";
            this.����ְ������.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.����ְ������.FieldName = "���¹���.ְ������";
            this.����ְ������.Name = "����ְ������";
            this.����ְ������.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "���¹���.ְ������", "{0:#0}")});
            this.����ְ������.Visible = true;
            this.����ְ������.VisibleIndex = 5;
            this.����ְ������.Width = 90;
            // 
            // ���¹���ְ��
            // 
            this.���¹���ְ��.Caption = "����ְ��";
            this.���¹���ְ��.FieldName = "���¹���.����ְ��";
            this.���¹���ְ��.Name = "���¹���ְ��";
            this.���¹���ְ��.Visible = true;
            this.���¹���ְ��.VisibleIndex = 3;
            this.���¹���ְ��.Width = 97;
            // 
            // ���ʱ仯
            // 
            this.���ʱ仯.Caption = "���ʱ仯";
            this.���ʱ仯.DisplayFormat.FormatString = "{0:#0}";
            this.���ʱ仯.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.���ʱ仯.FieldName = "���ʱ仯";
            this.���ʱ仯.Name = "���ʱ仯";
            this.���ʱ仯.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "���ʱ仯", "{0:#0}")});
            this.���ʱ仯.Visible = true;
            this.���ʱ仯.VisibleIndex = 6;
            this.���ʱ仯.Width = 96;
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileName = "��ִ�б�׼��Ա��ְ��������ϸ��";
            this.saveFileDialog1.Filter = "Excel �ļ� | *.xls";
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.label2);
            this.panelControl2.Controls.Add(this.simpleButton2);
            this.panelControl2.Controls.Add(this.btnOK);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl2.Location = new System.Drawing.Point(0, 456);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(670, 73);
            this.panelControl2.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 11F);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(5, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(577, 18);
            this.label2.TabIndex = 14;
            this.label2.Text = "����������δ�����ļ�¼������������������������ȡ����������Ҫ������ú�����.";
            // 
            // simpleButton2
            // 
            this.simpleButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton2.Location = new System.Drawing.Point(345, 38);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(62, 23);
            this.simpleButton2.TabIndex = 6;
            this.simpleButton2.Text = "ȡ��";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(256, 38);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(73, 23);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "����";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // SalaryAdjustDetail
            // 
            this.ClientSize = new System.Drawing.Size(670, 529);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SalaryAdjustDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "���ʵ��������";
            this.Load += new System.EventHandler(this.SalaryAdjustDetail_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.ComponentModel.IContainer components = null;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn Ա�����;
        private DevExpress.XtraGrid.Columns.GridColumn ����;
        private DevExpress.XtraGrid.Columns.GridColumn ����ְ��;
        private DevExpress.XtraGrid.Columns.GridColumn ����ְ������;
        private DevExpress.XtraGrid.Columns.GridColumn ���¹���ְ��;
        private DevExpress.XtraGrid.Columns.GridColumn ����ְ��;
        private DevExpress.XtraGrid.Columns.GridColumn ����ְ������;
        private DevExpress.XtraGrid.Columns.GridColumn ���¹���ְ��;
        private System.Windows.Forms.Label lbl�ڼ�;
        private System.Windows.Forms.Label lbl����;
        private DevExpress.XtraGrid.Columns.GridColumn ���ʱ仯;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraGrid.Columns.GridColumn �ѵ�������;
    }
}
