namespace Hwagain.SalaryCalculation
{
    partial class EditRembursementSalaryForm
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
            this.btn保存 = new DevExpress.XtraEditors.SimpleButton();
            this.lbl用户 = new DevExpress.XtraEditors.LabelControl();
            this.lbl员工编号 = new DevExpress.XtraEditors.LabelControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.dateEdit开始时间 = new DevExpress.XtraEditors.DateEdit();
            this.dateEdit结束时间 = new DevExpress.XtraEditors.DateEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.spinEdit年度可报账标准_税前 = new DevExpress.XtraEditors.SpinEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.spinEdit月度可报账标准_税前 = new DevExpress.XtraEditors.SpinEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.spinEdit年度可报账标准_税后 = new DevExpress.XtraEditors.SpinEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.spinEdit月度可报账标准_税后 = new DevExpress.XtraEditors.SpinEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit开始时间.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit开始时间.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit结束时间.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit结束时间.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit年度可报账标准_税前.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit月度可报账标准_税前.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit年度可报账标准_税后.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit月度可报账标准_税后.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btn保存);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 176);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(589, 48);
            this.panelControl1.TabIndex = 3;
            // 
            // btn保存
            // 
            this.btn保存.Location = new System.Drawing.Point(254, 13);
            this.btn保存.Name = "btn保存";
            this.btn保存.Size = new System.Drawing.Size(76, 23);
            this.btn保存.TabIndex = 0;
            this.btn保存.Text = "保存";
            this.btn保存.Click += new System.EventHandler(this.btn保存_Click);
            // 
            // lbl用户
            // 
            this.lbl用户.Appearance.Font = new System.Drawing.Font("华文宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl用户.Appearance.Options.UseFont = true;
            this.lbl用户.Location = new System.Drawing.Point(27, 12);
            this.lbl用户.Name = "lbl用户";
            this.lbl用户.Size = new System.Drawing.Size(57, 21);
            this.lbl用户.TabIndex = 38;
            this.lbl用户.Text = "姓名：";
            // 
            // lbl员工编号
            // 
            this.lbl员工编号.Appearance.Font = new System.Drawing.Font("华文宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl员工编号.Appearance.Options.UseFont = true;
            this.lbl员工编号.Location = new System.Drawing.Point(299, 12);
            this.lbl员工编号.Name = "lbl员工编号";
            this.lbl员工编号.Size = new System.Drawing.Size(95, 21);
            this.lbl员工编号.TabIndex = 39;
            this.lbl员工编号.Text = "员工编号：";
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.lbl员工编号);
            this.panelControl2.Controls.Add(this.lbl用户);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(0, 0);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(589, 41);
            this.panelControl2.TabIndex = 40;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("华文宋体", 12F);
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(44, 71);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(80, 18);
            this.labelControl2.TabIndex = 43;
            this.labelControl2.Text = "开始时间：";
            // 
            // dateEdit开始时间
            // 
            this.dateEdit开始时间.EditValue = null;
            this.dateEdit开始时间.Location = new System.Drawing.Point(172, 70);
            this.dateEdit开始时间.Name = "dateEdit开始时间";
            this.dateEdit开始时间.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit开始时间.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit开始时间.Properties.NullDate = new System.DateTime(((long)(0)));
            this.dateEdit开始时间.Size = new System.Drawing.Size(100, 20);
            this.dateEdit开始时间.TabIndex = 44;
            // 
            // dateEdit结束时间
            // 
            this.dateEdit结束时间.EditValue = null;
            this.dateEdit结束时间.Location = new System.Drawing.Point(453, 70);
            this.dateEdit结束时间.Name = "dateEdit结束时间";
            this.dateEdit结束时间.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit结束时间.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit结束时间.Properties.NullDate = new System.DateTime(((long)(0)));
            this.dateEdit结束时间.Size = new System.Drawing.Size(100, 20);
            this.dateEdit结束时间.TabIndex = 68;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("华文宋体", 12F);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(314, 71);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(80, 18);
            this.labelControl1.TabIndex = 67;
            this.labelControl1.Text = "结束时间：";
            // 
            // spinEdit年度可报账标准_税前
            // 
            this.spinEdit年度可报账标准_税前.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEdit年度可报账标准_税前.Location = new System.Drawing.Point(453, 99);
            this.spinEdit年度可报账标准_税前.Name = "spinEdit年度可报账标准_税前";
            this.spinEdit年度可报账标准_税前.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinEdit年度可报账标准_税前.Properties.DisplayFormat.FormatString = "{0:#0.##}";
            this.spinEdit年度可报账标准_税前.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.spinEdit年度可报账标准_税前.Size = new System.Drawing.Size(100, 20);
            this.spinEdit年度可报账标准_税前.TabIndex = 74;
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("华文宋体", 12F);
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(289, 101);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(170, 18);
            this.labelControl4.TabIndex = 73;
            this.labelControl4.Text = "年度可报账标准(税前)：";
            // 
            // spinEdit月度可报账标准_税前
            // 
            this.spinEdit月度可报账标准_税前.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEdit月度可报账标准_税前.Location = new System.Drawing.Point(172, 100);
            this.spinEdit月度可报账标准_税前.Name = "spinEdit月度可报账标准_税前";
            this.spinEdit月度可报账标准_税前.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinEdit月度可报账标准_税前.Properties.DisplayFormat.FormatString = "{0:#0.##}";
            this.spinEdit月度可报账标准_税前.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.spinEdit月度可报账标准_税前.Size = new System.Drawing.Size(100, 20);
            this.spinEdit月度可报账标准_税前.TabIndex = 72;
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("华文宋体", 12F);
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.Location = new System.Drawing.Point(12, 100);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(154, 18);
            this.labelControl5.TabIndex = 71;
            this.labelControl5.Text = "月可报账标准(税前)：";
            // 
            // spinEdit年度可报账标准_税后
            // 
            this.spinEdit年度可报账标准_税后.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEdit年度可报账标准_税后.Location = new System.Drawing.Point(453, 128);
            this.spinEdit年度可报账标准_税后.Name = "spinEdit年度可报账标准_税后";
            this.spinEdit年度可报账标准_税后.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinEdit年度可报账标准_税后.Properties.DisplayFormat.FormatString = "{0:#0.##}";
            this.spinEdit年度可报账标准_税后.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.spinEdit年度可报账标准_税后.Size = new System.Drawing.Size(100, 20);
            this.spinEdit年度可报账标准_税后.TabIndex = 78;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("华文宋体", 12F);
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(289, 130);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(170, 18);
            this.labelControl3.TabIndex = 77;
            this.labelControl3.Text = "年度可报账标准(税后)：";
            // 
            // spinEdit月度可报账标准_税后
            // 
            this.spinEdit月度可报账标准_税后.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEdit月度可报账标准_税后.Location = new System.Drawing.Point(172, 129);
            this.spinEdit月度可报账标准_税后.Name = "spinEdit月度可报账标准_税后";
            this.spinEdit月度可报账标准_税后.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinEdit月度可报账标准_税后.Properties.DisplayFormat.FormatString = "{0:#0.##}";
            this.spinEdit月度可报账标准_税后.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.spinEdit月度可报账标准_税后.Size = new System.Drawing.Size(100, 20);
            this.spinEdit月度可报账标准_税后.TabIndex = 76;
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("华文宋体", 12F);
            this.labelControl6.Appearance.Options.UseFont = true;
            this.labelControl6.Location = new System.Drawing.Point(12, 129);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(154, 18);
            this.labelControl6.TabIndex = 75;
            this.labelControl6.Text = "月可报账标准(税后)：";
            // 
            // EditRembursementSalaryForm
            // 
            this.ClientSize = new System.Drawing.Size(589, 224);
            this.Controls.Add(this.spinEdit年度可报账标准_税后);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.spinEdit月度可报账标准_税后);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.spinEdit年度可报账标准_税前);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.spinEdit月度可报账标准_税前);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.dateEdit结束时间);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.dateEdit开始时间);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.panelControl2);
            this.LookAndFeel.SkinName = "Summer 2008";
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditRembursementSalaryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "员工薪酬结构录入";
            this.Load += new System.EventHandler(this.EditRembursementSalaryForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit开始时间.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit开始时间.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit结束时间.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit结束时间.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit年度可报账标准_税前.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit月度可报账标准_税前.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit年度可报账标准_税后.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit月度可报账标准_税后.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.IContainer components = null;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btn保存;
        private DevExpress.XtraEditors.LabelControl lbl用户;
        private DevExpress.XtraEditors.LabelControl lbl员工编号;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.DateEdit dateEdit开始时间;
        private DevExpress.XtraEditors.DateEdit dateEdit结束时间;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SpinEdit spinEdit年度可报账标准_税前;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.SpinEdit spinEdit月度可报账标准_税前;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.SpinEdit spinEdit年度可报账标准_税后;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.SpinEdit spinEdit月度可报账标准_税后;
        private DevExpress.XtraEditors.LabelControl labelControl6;
    }
}
