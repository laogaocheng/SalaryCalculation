namespace Hwagain.SalaryCalculation
{
    partial class ManageUserInRole {
        /// <summary>
        /// Clean up any UserInRole being used.
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
            this.�û��� = new DevExpress.XtraGrid.Columns.GridColumn();
            this.���� = new DevExpress.XtraGrid.Columns.GridColumn();
            this.checkedListBoxControl1 = new DevExpress.XtraEditors.CheckedListBoxControl();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkedListBoxControl1)).BeginInit();
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
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(209, 450);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1,
            this.gridView2});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.�û���,
            this.����});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.NewItemRowText = "������������¶���";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsSelection.InvertSelection = true;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView1_FocusedRowChanged);
            // 
            // �û���
            // 
            this.�û���.Caption = "�û���";
            this.�û���.FieldName = "�û���";
            this.�û���.Name = "�û���";
            this.�û���.Visible = true;
            this.�û���.VisibleIndex = 1;
            // 
            // ����
            // 
            this.����.Caption = "����";
            this.����.FieldName = "����";
            this.����.Name = "����";
            this.����.Visible = true;
            this.����.VisibleIndex = 0;
            // 
            // checkedListBoxControl1
            // 
            this.checkedListBoxControl1.DisplayMember = "Name";
            this.checkedListBoxControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkedListBoxControl1.Location = new System.Drawing.Point(209, 0);
            this.checkedListBoxControl1.Name = "checkedListBoxControl1";
            this.checkedListBoxControl1.Size = new System.Drawing.Size(458, 450);
            this.checkedListBoxControl1.TabIndex = 9;
            this.checkedListBoxControl1.ValueMember = "Name";
            this.checkedListBoxControl1.ItemCheck += new DevExpress.XtraEditors.Controls.ItemCheckEventHandler(this.checkedListBoxControl1_ItemCheck);
            this.checkedListBoxControl1.SelectedValueChanged += new System.EventHandler(this.checkedListBoxControl1_SelectedValueChanged);
            // 
            // ManageUserInRole
            // 
            this.Controls.Add(this.checkedListBoxControl1);
            this.Controls.Add(this.gridControl1);
            this.Name = "ManageUserInRole";
            this.Size = new System.Drawing.Size(667, 450);
            this.Load += new System.EventHandler(this.ManageUserInRole_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkedListBoxControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.ComponentModel.IContainer components = null;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn ����;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn col��������;
        private DevExpress.XtraGrid.Columns.GridColumn col��������;
        private DevExpress.XtraGrid.Columns.GridColumn col����˵��;
        private DevExpress.XtraEditors.CheckedListBoxControl checkedListBoxControl1;
        private DevExpress.XtraGrid.Columns.GridColumn �û���;
    }
}
