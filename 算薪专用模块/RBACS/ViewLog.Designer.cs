namespace Hwagain.SalaryCalculation
{
    partial class ViewLog {
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
            this.col���� = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col������ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col�¼����� = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col��ϸ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoExEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit();
            this.col����ʱ�� = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoExEdit1)).BeginInit();
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
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemMemoExEdit1});
            this.gridControl1.Size = new System.Drawing.Size(667, 450);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1,
            this.gridView2});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col����,
            this.col������,
            this.col�¼�����,
            this.col��ϸ,
            this.col����ʱ��});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.NewItemRowText = "������������¶���";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.gridView1_InitNewRow);
            this.gridView1.HiddenEditor += new System.EventHandler(this.gridView1_HiddenEditor);
            this.gridView1.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.gridView1_CustomColumnDisplayText);
            // 
            // col����
            // 
            this.col����.AppearanceCell.Options.UseTextOptions = true;
            this.col����.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col����.Caption = "����";
            this.col����.FieldName = "LogType";
            this.col����.Name = "col����";
            this.col����.OptionsColumn.ReadOnly = true;
            this.col����.Visible = true;
            this.col����.VisibleIndex = 0;
            this.col����.Width = 66;
            // 
            // col������
            // 
            this.col������.AppearanceCell.Options.UseTextOptions = true;
            this.col������.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col������.Caption = "������";
            this.col������.FieldName = "Username";
            this.col������.Name = "col������";
            this.col������.OptionsColumn.ReadOnly = true;
            this.col������.Visible = true;
            this.col������.VisibleIndex = 1;
            this.col������.Width = 71;
            // 
            // col�¼�����
            // 
            this.col�¼�����.Caption = "�¼�����";
            this.col�¼�����.FieldName = "Title";
            this.col�¼�����.Name = "col�¼�����";
            this.col�¼�����.OptionsColumn.ReadOnly = true;
            this.col�¼�����.Visible = true;
            this.col�¼�����.VisibleIndex = 2;
            this.col�¼�����.Width = 331;
            // 
            // col��ϸ
            // 
            this.col��ϸ.Caption = "��ϸ";
            this.col��ϸ.ColumnEdit = this.repositoryItemMemoExEdit1;
            this.col��ϸ.FieldName = "Detail";
            this.col��ϸ.Name = "col��ϸ";
            this.col��ϸ.OptionsColumn.ReadOnly = true;
            this.col��ϸ.Visible = true;
            this.col��ϸ.VisibleIndex = 3;
            this.col��ϸ.Width = 59;
            // 
            // repositoryItemMemoExEdit1
            // 
            this.repositoryItemMemoExEdit1.AutoHeight = false;
            this.repositoryItemMemoExEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemMemoExEdit1.Name = "repositoryItemMemoExEdit1";
            this.repositoryItemMemoExEdit1.ReadOnly = true;
            // 
            // col����ʱ��
            // 
            this.col����ʱ��.AppearanceCell.Options.UseTextOptions = true;
            this.col����ʱ��.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col����ʱ��.Caption = "����ʱ��";
            this.col����ʱ��.DisplayFormat.FormatString = "d";
            this.col����ʱ��.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.col����ʱ��.FieldName = "DateAndTime";
            this.col����ʱ��.Name = "col����ʱ��";
            this.col����ʱ��.OptionsColumn.ReadOnly = true;
            this.col����ʱ��.Visible = true;
            this.col����ʱ��.VisibleIndex = 4;
            this.col����ʱ��.Width = 135;
            // 
            // ViewLog
            // 
            this.Controls.Add(this.gridControl1);
            this.Name = "ViewLog";
            this.Size = new System.Drawing.Size(667, 450);
            this.Load += new System.EventHandler(this.ViewLog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoExEdit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.ComponentModel.IContainer components = null;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn col����;
        private DevExpress.XtraGrid.Columns.GridColumn col������;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn col��������;
        private DevExpress.XtraGrid.Columns.GridColumn col��������;
        private DevExpress.XtraGrid.Columns.GridColumn col����˵��;
        private DevExpress.XtraGrid.Columns.GridColumn col�¼�����;
        private DevExpress.XtraGrid.Columns.GridColumn col����ʱ��;
        private DevExpress.XtraGrid.Columns.GridColumn col��ϸ;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit repositoryItemMemoExEdit1;
    }
}
