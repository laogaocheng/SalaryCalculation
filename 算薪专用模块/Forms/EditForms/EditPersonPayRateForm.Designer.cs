namespace Hwagain.SalaryCalculation
{
    partial class EditPersonPayRateForm
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
            this.н���� = new DevExpress.XtraGrid.Columns.GridColumn();
            this.���ŵ�λ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.���㲿�� = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Ա����� = new DevExpress.XtraGrid.Columns.GridColumn();
            this.���� = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ְ�� = new DevExpress.XtraGrid.Columns.GridColumn();
            this.��Ч���� = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemDateEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.��н = new DevExpress.XtraGrid.Columns.GridColumn();
            this.���ս� = new DevExpress.XtraGrid.Columns.GridColumn();
            this.�±������ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.����1���� = new DevExpress.XtraGrid.Columns.GridColumn();
            this.����1��� = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCalcEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit();
            this.����2���� = new DevExpress.XtraGrid.Columns.GridColumn();
            this.����2��� = new DevExpress.XtraGrid.Columns.GridColumn();
            this.¼���� = new DevExpress.XtraGrid.Columns.GridColumn();
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
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCalcEdit1)).BeginInit();
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
            this.repositoryItemDateEdit1,
            this.repositoryItemCalcEdit1});
            this.gridControl1.Size = new System.Drawing.Size(760, 375);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1,
            this.gridView2});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.н����,
            this.���ŵ�λ,
            this.���㲿��,
            this.Ա�����,
            this.����,
            this.ְ��,
            this.��Ч����,
            this.��н,
            this.���ս�,
            this.�±������,
            this.����1����,
            this.����1���,
            this.����2����,
            this.����2���,
            this.¼����});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.GroupCount = 3;
            this.gridView1.Name = "gridView1";
            this.gridView1.NewItemRowText = "������������¶���";
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.н����, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.���ŵ�λ, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.���㲿��, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gridView1.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.gridView1_CustomDrawCell);
            this.gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView1_FocusedRowChanged);
            this.gridView1.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanged);
            this.gridView1.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.gridView1_InvalidRowException);
            // 
            // н����
            // 
            this.н����.Caption = "н����";
            this.н����.FieldName = "Ա����Ϣ.н��������";
            this.н����.Name = "н����";
            this.н����.OptionsColumn.AllowEdit = false;
            this.н����.OptionsColumn.ReadOnly = true;
            this.н����.Visible = true;
            this.н����.VisibleIndex = 0;
            // 
            // ���ŵ�λ
            // 
            this.���ŵ�λ.Caption = "���ŵ�λ";
            this.���ŵ�λ.FieldName = "Ա����Ϣ.����˾";
            this.���ŵ�λ.Name = "���ŵ�λ";
            this.���ŵ�λ.OptionsColumn.AllowEdit = false;
            this.���ŵ�λ.OptionsColumn.ReadOnly = true;
            this.���ŵ�λ.Visible = true;
            this.���ŵ�λ.VisibleIndex = 0;
            // 
            // ���㲿��
            // 
            this.���㲿��.Caption = "���㲿��";
            this.���㲿��.FieldName = "Ա����Ϣ.������";
            this.���㲿��.Name = "���㲿��";
            this.���㲿��.OptionsColumn.AllowEdit = false;
            this.���㲿��.OptionsColumn.ReadOnly = true;
            this.���㲿��.Visible = true;
            this.���㲿��.VisibleIndex = 0;
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
            this.Ա�����.Width = 134;
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
            // ְ��
            // 
            this.ְ��.Caption = "ְ��";
            this.ְ��.FieldName = "ְ��";
            this.ְ��.Name = "ְ��";
            this.ְ��.OptionsColumn.AllowEdit = false;
            this.ְ��.OptionsColumn.ReadOnly = true;
            this.ְ��.Visible = true;
            this.ְ��.VisibleIndex = 2;
            this.ְ��.Width = 82;
            // 
            // ��Ч����
            // 
            this.��Ч����.Caption = "ִ��ʱ��";
            this.��Ч����.ColumnEdit = this.repositoryItemDateEdit1;
            this.��Ч����.FieldName = "��Ч����";
            this.��Ч����.Name = "��Ч����";
            this.��Ч����.Visible = true;
            this.��Ч����.VisibleIndex = 3;
            this.��Ч����.Width = 79;
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
            // ��н
            // 
            this.��н.Caption = "��н";
            this.��н.DisplayFormat.FormatString = "0";
            this.��н.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.��н.FieldName = "��н";
            this.��н.Name = "��н";
            this.��н.Visible = true;
            this.��н.VisibleIndex = 4;
            this.��н.Width = 77;
            // 
            // ���ս�
            // 
            this.���ս�.Caption = "���ս�";
            this.���ս�.DisplayFormat.FormatString = "0";
            this.���ս�.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.���ս�.FieldName = "���ս�";
            this.���ս�.Name = "���ս�";
            this.���ս�.Visible = true;
            this.���ս�.VisibleIndex = 5;
            this.���ս�.Width = 72;
            // 
            // �±������
            // 
            this.�±������.Caption = "�±������";
            this.�±������.DisplayFormat.FormatString = "0";
            this.�±������.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.�±������.FieldName = "�±������";
            this.�±������.Name = "�±������";
            this.�±������.Visible = true;
            this.�±������.VisibleIndex = 6;
            this.�±������.Width = 82;
            // 
            // ����1����
            // 
            this.����1����.Caption = "����1����";
            this.����1����.FieldName = "����1����";
            this.����1����.Name = "����1����";
            this.����1����.Visible = true;
            this.����1����.VisibleIndex = 7;
            this.����1����.Width = 85;
            // 
            // ����1���
            // 
            this.����1���.Caption = "����1���";
            this.����1���.ColumnEdit = this.repositoryItemCalcEdit1;
            this.����1���.DisplayFormat.FormatString = "0";
            this.����1���.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.����1���.FieldName = "����1���";
            this.����1���.Name = "����1���";
            this.����1���.Visible = true;
            this.����1���.VisibleIndex = 8;
            this.����1���.Width = 79;
            // 
            // repositoryItemCalcEdit1
            // 
            this.repositoryItemCalcEdit1.AutoHeight = false;
            this.repositoryItemCalcEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemCalcEdit1.Name = "repositoryItemCalcEdit1";
            // 
            // ����2����
            // 
            this.����2����.Caption = "����2����";
            this.����2����.FieldName = "����2����";
            this.����2����.Name = "����2����";
            this.����2����.Visible = true;
            this.����2����.VisibleIndex = 9;
            this.����2����.Width = 83;
            // 
            // ����2���
            // 
            this.����2���.Caption = "����2���";
            this.����2���.ColumnEdit = this.repositoryItemCalcEdit1;
            this.����2���.DisplayFormat.FormatString = "0";
            this.����2���.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.����2���.FieldName = "����2���";
            this.����2���.Name = "����2���";
            this.����2���.Visible = true;
            this.����2���.VisibleIndex = 10;
            this.����2���.Width = 105;
            // 
            // ¼����
            // 
            this.¼����.Caption = "¼����";
            this.¼����.FieldName = "¼����";
            this.¼����.Name = "¼����";
            this.¼����.OptionsColumn.AllowEdit = false;
            this.¼����.OptionsColumn.ReadOnly = true;
            this.¼����.Visible = true;
            this.¼����.VisibleIndex = 11;
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
            // EditPersonPayRateForm
            // 
            this.ClientSize = new System.Drawing.Size(760, 423);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.panelControl1);
            this.LookAndFeel.SkinName = "Summer 2008";
            this.Name = "EditPersonPayRateForm";
            this.Text = "����ְ������¼��";
            this.Load += new System.EventHandler(this.EditPersonPayRateForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCalcEdit1)).EndInit();
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
        private DevExpress.XtraGrid.Columns.GridColumn ְ��;
        private DevExpress.XtraGrid.Columns.GridColumn ��н;
        private DevExpress.XtraGrid.Columns.GridColumn �±������;
        private DevExpress.XtraGrid.Columns.GridColumn ���ս�;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btn����;
        private DevExpress.XtraEditors.SimpleButton btnɾ��;
        private DevExpress.XtraGrid.Columns.GridColumn ����1����;
        private DevExpress.XtraGrid.Columns.GridColumn ����1���;
        private DevExpress.XtraGrid.Columns.GridColumn ����2����;
        private DevExpress.XtraGrid.Columns.GridColumn ����2���;
        private DevExpress.XtraEditors.SimpleButton btn���;
        private DevExpress.XtraEditors.SimpleButton btnˢ��;
        private DevExpress.XtraGrid.Columns.GridColumn ��Ч����;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn н����;
        private DevExpress.XtraGrid.Columns.GridColumn ���ŵ�λ;
        private DevExpress.XtraGrid.Columns.GridColumn ���㲿��;
        private DevExpress.XtraGrid.Columns.GridColumn ¼����;
        private DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit repositoryItemCalcEdit1;
    }
}
