namespace Hwagain.SalaryCalculation
{
    partial class EditEmployeeSalaryStepForm
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
            this.col�������� = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col�������� = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col����˵�� = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Ա����� = new DevExpress.XtraGrid.Columns.GridColumn();
            this.���� = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ִ������ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemDateEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.н�� = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemImageComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.н������ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.н�� = new DevExpress.XtraGrid.Columns.GridColumn();
            this.¼���� = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemImageComboBox2 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnˢ�� = new DevExpress.XtraEditors.SimpleButton();
            this.btn��� = new DevExpress.XtraEditors.SimpleButton();
            this.btnɾ�� = new DevExpress.XtraEditors.SimpleButton();
            this.btn���� = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
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
            this.Ա�����,
            this.����,
            this.ִ������,
            this.н��,
            this.н������,
            this.н��,
            this.¼����});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.NewItemRowText = "������������¶���";
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.gridView1_CustomDrawCell);
            this.gridView1.CustomRowCellEditForEditing += new DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventHandler(this.gridView1_CustomRowCellEditForEditing);
            this.gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView1_FocusedRowChanged);
            this.gridView1.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanged);
            this.gridView1.CellValueChanging += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanging);
            this.gridView1.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.gridView1_InvalidRowException);
            this.gridView1.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
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
            // ִ������
            // 
            this.ִ������.Caption = "ִ������";
            this.ִ������.ColumnEdit = this.repositoryItemDateEdit1;
            this.ִ������.FieldName = "ִ������";
            this.ִ������.Name = "ִ������";
            this.ִ������.Visible = true;
            this.ִ������.VisibleIndex = 2;
            this.ִ������.Width = 79;
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
            // н��
            // 
            this.н��.Caption = "н��";
            this.н��.ColumnEdit = this.repositoryItemImageComboBox1;
            this.н��.FieldName = "н�ȱ�ʶ";
            this.н��.Name = "н��";
            this.н��.Visible = true;
            this.н��.VisibleIndex = 3;
            this.н��.Width = 152;
            // 
            // repositoryItemImageComboBox1
            // 
            this.repositoryItemImageComboBox1.AutoHeight = false;
            this.repositoryItemImageComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageComboBox1.Name = "repositoryItemImageComboBox1";
            this.repositoryItemImageComboBox1.SelectedValueChanged += new System.EventHandler(this.repositoryItemImageComboBox1_SelectedValueChanged);
            // 
            // н������
            // 
            this.н������.Caption = "н��";
            this.н������.FieldName = "н������";
            this.н������.Name = "н������";
            this.н������.Visible = true;
            this.н������.VisibleIndex = 4;
            this.н������.Width = 103;
            // 
            // н��
            // 
            this.н��.Caption = "н����ʶ";
            this.н��.FieldName = "н����ʶ";
            this.н��.Name = "н��";
            this.н��.Width = 59;
            // 
            // ¼����
            // 
            this.¼����.Caption = "¼����";
            this.¼����.FieldName = "¼����";
            this.¼����.Name = "¼����";
            this.¼����.OptionsColumn.AllowEdit = false;
            this.¼����.OptionsColumn.ReadOnly = true;
            this.¼����.Visible = true;
            this.¼����.VisibleIndex = 5;
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
            this.panelControl1.Controls.Add(this.btnˢ��);
            this.panelControl1.Controls.Add(this.btn���);
            this.panelControl1.Controls.Add(this.btnɾ��);
            this.panelControl1.Controls.Add(this.btn����);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(760, 48);
            this.panelControl1.TabIndex = 3;
            // 
            // btnˢ��
            // 
            this.btnˢ��.Location = new System.Drawing.Point(12, 12);
            this.btnˢ��.Name = "btnˢ��";
            this.btnˢ��.Size = new System.Drawing.Size(62, 23);
            this.btnˢ��.TabIndex = 3;
            this.btnˢ��.Text = "ˢ��";
            this.btnˢ��.Click += new System.EventHandler(this.btnˢ��_Click);
            // 
            // btn���
            // 
            this.btn���.Location = new System.Drawing.Point(80, 12);
            this.btn���.Name = "btn���";
            this.btn���.Size = new System.Drawing.Size(62, 23);
            this.btn���.TabIndex = 2;
            this.btn���.Text = "���";
            this.btn���.Click += new System.EventHandler(this.btn���_Click);
            // 
            // btnɾ��
            // 
            this.btnɾ��.Location = new System.Drawing.Point(216, 12);
            this.btnɾ��.Name = "btnɾ��";
            this.btnɾ��.Size = new System.Drawing.Size(62, 23);
            this.btnɾ��.TabIndex = 1;
            this.btnɾ��.Text = "ɾ��";
            this.btnɾ��.Click += new System.EventHandler(this.btnɾ��_Click);
            // 
            // btn����
            // 
            this.btn����.Location = new System.Drawing.Point(148, 12);
            this.btn����.Name = "btn����";
            this.btn����.Size = new System.Drawing.Size(62, 23);
            this.btn����.TabIndex = 0;
            this.btn����.Text = "����";
            this.btn����.Click += new System.EventHandler(this.btn����_Click);
            // 
            // EditEmployeeSalaryStepForm
            // 
            this.ClientSize = new System.Drawing.Size(760, 423);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.panelControl1);
            this.LookAndFeel.SkinName = "Summer 2008";
            this.Name = "EditEmployeeSalaryStepForm";
            this.Text = "Ա������ְ��¼��";
            this.Load += new System.EventHandler(this.EditEmployeeSalaryStepForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.ComponentModel.IContainer components = null;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn col��������;
        private DevExpress.XtraGrid.Columns.GridColumn col��������;
        private DevExpress.XtraGrid.Columns.GridColumn col����˵��;
        private DevExpress.XtraGrid.Columns.GridColumn Ա�����;
        private DevExpress.XtraGrid.Columns.GridColumn ����;
        private DevExpress.XtraGrid.Columns.GridColumn н��;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btn����;
        private DevExpress.XtraEditors.SimpleButton btnɾ��;
        private DevExpress.XtraEditors.SimpleButton btn���;
        private DevExpress.XtraEditors.SimpleButton btnˢ��;
        private DevExpress.XtraGrid.Columns.GridColumn ִ������;
        private DevExpress.XtraGrid.Columns.GridColumn н��;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox1;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox2;
        private DevExpress.XtraGrid.Columns.GridColumn н������;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn ¼����;
    }
}
