namespace Hwagain.SalaryCalculation
{
    partial class ManageLevelImpowers
    {
        /// <summary>
        /// Clean up any resources being used.
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
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.��ɫ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemRole = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.��˾ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCompany = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.ְ��ȼ� = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemGrade = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.panel2 = new DevExpress.XtraEditors.PanelControl();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemRole)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCompany)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGrade)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panel2)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 44);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemRole,
            this.repositoryItemCompany,
            this.repositoryItemGrade});
            this.gridControl1.Size = new System.Drawing.Size(667, 406);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControl1.Load += new System.EventHandler(this.gridControl1_Load);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.��ɫ,
            this.��˾,
            this.ְ��ȼ�});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.NewItemRowText = "������������¶���";
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.gridView1_InitNewRow);
            // 
            // ��ɫ
            // 
            this.��ɫ.Caption = "��ɫ";
            this.��ɫ.ColumnEdit = this.repositoryItemRole;
            this.��ɫ.FieldName = "��ɫ";
            this.��ɫ.Name = "��ɫ";
            this.��ɫ.Visible = true;
            this.��ɫ.VisibleIndex = 0;
            this.��ɫ.Width = 131;
            // 
            // repositoryItemRole
            // 
            this.repositoryItemRole.AutoHeight = false;
            this.repositoryItemRole.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemRole.Name = "repositoryItemRole";
            // 
            // ��˾
            // 
            this.��˾.Caption = "��˾";
            this.��˾.ColumnEdit = this.repositoryItemCompany;
            this.��˾.FieldName = "��˾����";
            this.��˾.Name = "��˾";
            this.��˾.Visible = true;
            this.��˾.VisibleIndex = 1;
            this.��˾.Width = 146;
            // 
            // repositoryItemCompany
            // 
            this.repositoryItemCompany.AutoHeight = false;
            this.repositoryItemCompany.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemCompany.Name = "repositoryItemCompany";
            // 
            // ְ��ȼ�
            // 
            this.ְ��ȼ�.Caption = "ְ��ȼ�";
            this.ְ��ȼ�.ColumnEdit = this.repositoryItemGrade;
            this.ְ��ȼ�.FieldName = "ְ��ȼ�";
            this.ְ��ȼ�.Name = "ְ��ȼ�";
            this.ְ��ȼ�.Visible = true;
            this.ְ��ȼ�.VisibleIndex = 2;
            this.ְ��ȼ�.Width = 371;
            // 
            // repositoryItemGrade
            // 
            this.repositoryItemGrade.AutoHeight = false;
            this.repositoryItemGrade.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemGrade.Name = "repositoryItemGrade";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnDelete);
            this.panel2.Controls.Add(this.btnAdd);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(667, 44);
            this.panel2.TabIndex = 8;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(106, 8);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(92, 28);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Text = "ɾ��";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(8, 8);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(92, 28);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "���";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // ManageLevelImpowers
            // 
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.panel2);
            this.Name = "ManageLevelImpowers";
            this.Size = new System.Drawing.Size(667, 450);
            this.Load += new System.EventHandler(this.ManageLevel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemRole)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCompany)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGrade)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panel2)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.ComponentModel.IContainer components = null;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn ��ɫ;
        private DevExpress.XtraGrid.Columns.GridColumn ְ��ȼ�;
        private DevExpress.XtraEditors.PanelControl panel2;
        private DevExpress.XtraEditors.SimpleButton btnDelete;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemRole;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemCompany;
        private DevExpress.XtraGrid.Columns.GridColumn ��˾;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemGrade;
    }
}
