namespace Hwagain.SalaryCalculation
{
    partial class ManageUsers {
        /// <summary>
        /// Clean up any Users being used.
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
            this.col���� = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.�û��� = new DevExpress.XtraGrid.Columns.GridColumn();
            this.���� = new DevExpress.XtraGrid.Columns.GridColumn();
            this.���֤���� = new DevExpress.XtraGrid.Columns.GridColumn();
            this.�����ַ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.����ʱ�� = new DevExpress.XtraGrid.Columns.GridColumn();
            this.����¼ʱ�� = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemDateEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.panel2 = new DevExpress.XtraEditors.PanelControl();
            this.btnChangePassword = new DevExpress.XtraEditors.SimpleButton();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.btn�ָ�ΪĬ������ = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panel2)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridView2
            // 
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col����});
            this.gridView2.GridControl = this.gridControl1;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsBehavior.Editable = false;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            this.gridView2.ViewCaption = "��ָ�����û�";
            this.gridView2.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.gridView2_CustomColumnDisplayText);
            // 
            // col����
            // 
            this.col����.Caption = "����";
            this.col����.FieldName = "UserId";
            this.col����.Name = "col����";
            this.col����.Visible = true;
            this.col����.VisibleIndex = 0;
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 44);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemDateEdit1});
            this.gridControl1.Size = new System.Drawing.Size(667, 406);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1,
            this.gridView2});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.�û���,
            this.����,
            this.���֤����,
            this.�����ַ,
            this.����ʱ��,
            this.����¼ʱ��});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.NewItemRowText = "������������¶���";
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.gridView1_InitNewRow);
            // 
            // �û���
            // 
            this.�û���.Caption = "�û���";
            this.�û���.FieldName = "�û���";
            this.�û���.Name = "�û���";
            this.�û���.Visible = true;
            this.�û���.VisibleIndex = 0;
            this.�û���.Width = 157;
            // 
            // ����
            // 
            this.����.Caption = "����";
            this.����.FieldName = "����";
            this.����.Name = "����";
            this.����.Visible = true;
            this.����.VisibleIndex = 1;
            this.����.Width = 130;
            // 
            // ���֤����
            // 
            this.���֤����.Caption = "���֤����";
            this.���֤����.FieldName = "���֤����";
            this.���֤����.Name = "���֤����";
            this.���֤����.Visible = true;
            this.���֤����.VisibleIndex = 2;
            this.���֤����.Width = 297;
            // 
            // �����ַ
            // 
            this.�����ַ.Caption = "�����ַ";
            this.�����ַ.FieldName = "�����ַ";
            this.�����ַ.Name = "�����ַ";
            this.�����ַ.Visible = true;
            this.�����ַ.VisibleIndex = 3;
            this.�����ַ.Width = 322;
            // 
            // ����ʱ��
            // 
            this.����ʱ��.Caption = "����ʱ��";
            this.����ʱ��.FieldName = "����ʱ��";
            this.����ʱ��.Name = "����ʱ��";
            this.����ʱ��.OptionsColumn.ReadOnly = true;
            this.����ʱ��.Visible = true;
            this.����ʱ��.VisibleIndex = 5;
            this.����ʱ��.Width = 172;
            // 
            // ����¼ʱ��
            // 
            this.����¼ʱ��.Caption = "����¼ʱ��";
            this.����¼ʱ��.ColumnEdit = this.repositoryItemDateEdit1;
            this.����¼ʱ��.FieldName = "����¼ʱ��";
            this.����¼ʱ��.Name = "����¼ʱ��";
            this.����¼ʱ��.OptionsColumn.ReadOnly = true;
            this.����¼ʱ��.Visible = true;
            this.����¼ʱ��.VisibleIndex = 4;
            this.����¼ʱ��.Width = 173;
            // 
            // repositoryItemDateEdit1
            // 
            this.repositoryItemDateEdit1.AutoHeight = false;
            this.repositoryItemDateEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit1.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.repositoryItemDateEdit1.DisplayFormat.FormatString = "yyyy-M-d HH:MM:ss";
            this.repositoryItemDateEdit1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.repositoryItemDateEdit1.EditFormat.FormatString = "yyyy-M-d HH:MM:ss";
            this.repositoryItemDateEdit1.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.repositoryItemDateEdit1.Name = "repositoryItemDateEdit1";
            this.repositoryItemDateEdit1.NullDate = new System.DateTime(((long)(0)));
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btn�ָ�ΪĬ������);
            this.panel2.Controls.Add(this.btnChangePassword);
            this.panel2.Controls.Add(this.btnDelete);
            this.panel2.Controls.Add(this.btnAdd);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(667, 44);
            this.panel2.TabIndex = 8;
            // 
            // btnChangePassword
            // 
            this.btnChangePassword.Location = new System.Drawing.Point(204, 8);
            this.btnChangePassword.Name = "btnChangePassword";
            this.btnChangePassword.Size = new System.Drawing.Size(92, 28);
            this.btnChangePassword.TabIndex = 2;
            this.btnChangePassword.Text = "��������";
            this.btnChangePassword.Click += new System.EventHandler(this.btnChangePassword_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(106, 8);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(92, 28);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Text = "ɾ���û�";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(8, 8);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(92, 28);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "����û�";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btn�ָ�ΪĬ������
            // 
            this.btn�ָ�ΪĬ������.Location = new System.Drawing.Point(302, 8);
            this.btn�ָ�ΪĬ������.Name = "btn�ָ�ΪĬ������";
            this.btn�ָ�ΪĬ������.Size = new System.Drawing.Size(109, 28);
            this.btn�ָ�ΪĬ������.TabIndex = 3;
            this.btn�ָ�ΪĬ������.Text = "�ָ�ΪĬ������";
            this.btn�ָ�ΪĬ������.Click += new System.EventHandler(this.btn�ָ�ΪĬ������_Click);
            // 
            // ManageUsers
            // 
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.panel2);
            this.Name = "ManageUsers";
            this.Size = new System.Drawing.Size(667, 450);
            this.Load += new System.EventHandler(this.ManageUsers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panel2)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.ComponentModel.IContainer components = null;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn �û���;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraEditors.PanelControl panel2;
        private DevExpress.XtraEditors.SimpleButton btnDelete;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private DevExpress.XtraGrid.Columns.GridColumn col����;
        private DevExpress.XtraGrid.Columns.GridColumn �����ַ;
        private DevExpress.XtraGrid.Columns.GridColumn ����ʱ��;
        private DevExpress.XtraGrid.Columns.GridColumn ����¼ʱ��;
        private DevExpress.XtraEditors.SimpleButton btnChangePassword;
        private DevExpress.XtraGrid.Columns.GridColumn ����;
        private DevExpress.XtraGrid.Columns.GridColumn ���֤����;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit1;
        private DevExpress.XtraEditors.SimpleButton btn�ָ�ΪĬ������;
    }
}
