namespace Hwagain.SalaryCalculation
{
    partial class PerformanceSalaryList
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
            this.chk��ʾ��ʷ��¼ = new DevExpress.XtraEditors.CheckEdit();
            this.searchKey = new DevExpress.XtraEditors.TextEdit();
            this.btn��ѯ = new DevExpress.XtraEditors.SimpleButton();
            this.btnˢ�� = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Ա����� = new DevExpress.XtraGrid.Columns.GridColumn();
            this.���� = new DevExpress.XtraGrid.Columns.GridColumn();
            this.��Ч���� = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemDateEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.ÿ�½�� = new DevExpress.XtraGrid.Columns.GridColumn();
            this.¼���� = new DevExpress.XtraGrid.Columns.GridColumn();
            this.¼��ʱ�� = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemImageComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col�������� = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col�������� = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col����˵�� = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chk��ʾ��ʷ��¼.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchKey.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.chk��ʾ��ʷ��¼);
            this.panelControl1.Controls.Add(this.searchKey);
            this.panelControl1.Controls.Add(this.btn��ѯ);
            this.panelControl1.Controls.Add(this.btnˢ��);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(760, 48);
            this.panelControl1.TabIndex = 4;
            // 
            // chk��ʾ��ʷ��¼
            // 
            this.chk��ʾ��ʷ��¼.Location = new System.Drawing.Point(329, 11);
            this.chk��ʾ��ʷ��¼.Name = "chk��ʾ��ʷ��¼";
            this.chk��ʾ��ʷ��¼.Properties.Caption = "��ʾ��ʷ��¼";
            this.chk��ʾ��ʷ��¼.Size = new System.Drawing.Size(142, 20);
            this.chk��ʾ��ʷ��¼.TabIndex = 8;
            // 
            // searchKey
            // 
            this.searchKey.Location = new System.Drawing.Point(22, 12);
            this.searchKey.Name = "searchKey";
            this.searchKey.Properties.NullValuePrompt = "������Ҫ��ѯ������";
            this.searchKey.Size = new System.Drawing.Size(129, 20);
            this.searchKey.TabIndex = 7;
            this.searchKey.KeyUp += new System.Windows.Forms.KeyEventHandler(this.searchKey_KeyUp);
            // 
            // btn��ѯ
            // 
            this.btn��ѯ.Location = new System.Drawing.Point(157, 9);
            this.btn��ѯ.Name = "btn��ѯ";
            this.btn��ѯ.Size = new System.Drawing.Size(62, 23);
            this.btn��ѯ.TabIndex = 6;
            this.btn��ѯ.Text = "��ѯ";
            this.btn��ѯ.Click += new System.EventHandler(this.btn��ѯ_Click);
            // 
            // btnˢ��
            // 
            this.btnˢ��.Location = new System.Drawing.Point(225, 9);
            this.btnˢ��.Name = "btnˢ��";
            this.btnˢ��.Size = new System.Drawing.Size(62, 23);
            this.btnˢ��.TabIndex = 3;
            this.btnˢ��.Text = "ˢ��";
            this.btnˢ��.Click += new System.EventHandler(this.btnˢ��_Click);
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
            this.repositoryItemDateEdit1});
            this.gridControl1.Size = new System.Drawing.Size(760, 375);
            this.gridControl1.TabIndex = 5;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1,
            this.gridView2});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.Ա�����,
            this.����,
            this.��Ч����,
            this.ÿ�½��,
            this.¼����,
            this.¼��ʱ��});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.NewItemRowText = "������������¶���";
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // Ա�����
            // 
            this.Ա�����.Caption = "Ա�����";
            this.Ա�����.FieldName = "Ա�����";
            this.Ա�����.Name = "Ա�����";
            this.Ա�����.OptionsColumn.AllowEdit = false;
            this.Ա�����.OptionsColumn.ReadOnly = true;
            this.Ա�����.Visible = true;
            this.Ա�����.VisibleIndex = 0;
            this.Ա�����.Width = 70;
            // 
            // ����
            // 
            this.����.Caption = "����";
            this.����.FieldName = "����";
            this.����.Name = "����";
            this.����.OptionsColumn.AllowEdit = false;
            this.����.OptionsColumn.ReadOnly = true;
            this.����.Visible = true;
            this.����.VisibleIndex = 1;
            this.����.Width = 63;
            // 
            // ��Ч����
            // 
            this.��Ч����.Caption = "��Ч����";
            this.��Ч����.ColumnEdit = this.repositoryItemDateEdit1;
            this.��Ч����.FieldName = "��Ч����";
            this.��Ч����.Name = "��Ч����";
            this.��Ч����.OptionsColumn.ReadOnly = true;
            this.��Ч����.Visible = true;
            this.��Ч����.VisibleIndex = 2;
            this.��Ч����.Width = 94;
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
            // ÿ�½��
            // 
            this.ÿ�½��.Caption = "ÿ�½��";
            this.ÿ�½��.DisplayFormat.FormatString = "{0:0.00}";
            this.ÿ�½��.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.ÿ�½��.FieldName = "ÿ�½��";
            this.ÿ�½��.Name = "ÿ�½��";
            this.ÿ�½��.OptionsColumn.ReadOnly = true;
            this.ÿ�½��.Visible = true;
            this.ÿ�½��.VisibleIndex = 3;
            this.ÿ�½��.Width = 95;
            // 
            // ¼����
            // 
            this.¼����.Caption = "¼����";
            this.¼����.FieldName = "¼����";
            this.¼����.Name = "¼����";
            this.¼����.Visible = true;
            this.¼����.VisibleIndex = 4;
            this.¼����.Width = 124;
            // 
            // ¼��ʱ��
            // 
            this.¼��ʱ��.Caption = "¼��ʱ��";
            this.¼��ʱ��.FieldName = "¼��ʱ��";
            this.¼��ʱ��.Name = "¼��ʱ��";
            this.¼��ʱ��.Visible = true;
            this.¼��ʱ��.VisibleIndex = 5;
            this.¼��ʱ��.Width = 132;
            // 
            // repositoryItemImageComboBox1
            // 
            this.repositoryItemImageComboBox1.AutoHeight = false;
            this.repositoryItemImageComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageComboBox1.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("�·��ⱨ��", "�·��ⱨ��", -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("̽�׷ɻ�Ʊ", "̽�׷ɻ�Ʊ", -1)});
            this.repositoryItemImageComboBox1.Name = "repositoryItemImageComboBox1";
            // 
            // gridView2
            // 
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col��������,
            this.col��������,
            this.col����˵��});
            this.gridView2.GridControl = this.gridControl1;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsView.ShowGroupPanel = false;
            this.gridView2.ViewCaption = "����";
            // 
            // col��������
            // 
            this.col��������.Caption = "��������";
            this.col��������.FieldName = "Name";
            this.col��������.Name = "col��������";
            this.col��������.Visible = true;
            this.col��������.VisibleIndex = 0;
            // 
            // col��������
            // 
            this.col��������.Caption = "��������";
            this.col��������.FieldName = "Code";
            this.col��������.Name = "col��������";
            this.col��������.Visible = true;
            this.col��������.VisibleIndex = 1;
            // 
            // col����˵��
            // 
            this.col����˵��.Caption = "����˵��";
            this.col����˵��.FieldName = "Description";
            this.col����˵��.Name = "col����˵��";
            this.col����˵��.Visible = true;
            this.col����˵��.VisibleIndex = 2;
            // 
            // PerformanceSalaryList
            // 
            this.ClientSize = new System.Drawing.Size(760, 423);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.panelControl1);
            this.LookAndFeel.SkinName = "Summer 2008";
            this.Name = "PerformanceSalaryList";
            this.Text = "Ա��Լ����Ч����";
            this.Load += new System.EventHandler(this.EditEmployeeSalaryStepForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chk��ʾ��ʷ��¼.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchKey.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.ComponentModel.IContainer components = null;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btnˢ��;
        private DevExpress.XtraEditors.TextEdit searchKey;
        private DevExpress.XtraEditors.SimpleButton btn��ѯ;
        private DevExpress.XtraEditors.CheckEdit chk��ʾ��ʷ��¼;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn Ա�����;
        private DevExpress.XtraGrid.Columns.GridColumn ����;
        private DevExpress.XtraGrid.Columns.GridColumn ��Ч����;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox1;
        private DevExpress.XtraGrid.Columns.GridColumn ÿ�½��;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn col��������;
        private DevExpress.XtraGrid.Columns.GridColumn col��������;
        private DevExpress.XtraGrid.Columns.GridColumn col����˵��;
        private DevExpress.XtraGrid.Columns.GridColumn ¼����;
        private DevExpress.XtraGrid.Columns.GridColumn ¼��ʱ��;
    }
}
