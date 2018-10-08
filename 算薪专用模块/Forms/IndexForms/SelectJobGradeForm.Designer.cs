namespace Hwagain.SalaryCalculation.Components.Forms.IndexForms
{
    partial class SelectJobGradeForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.spin年度 = new DevExpress.XtraEditors.SpinEdit();
            this.cbSemiannual = new DevExpress.XtraEditors.ComboBoxEdit();
            this.btn确定 = new DevExpress.XtraEditors.SimpleButton();
            this.btn取消 = new DevExpress.XtraEditors.SimpleButton();
            this.listBoxControl职级 = new DevExpress.XtraEditors.ListBoxControl();
            ((System.ComponentModel.ISupportInitialize)(this.spin年度.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbSemiannual.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.listBoxControl职级)).BeginInit();
            this.SuspendLayout();
            // 
            // spin年度
            // 
            this.spin年度.EditValue = new decimal(new int[] {
            2018,
            0,
            0,
            0});
            this.spin年度.Location = new System.Drawing.Point(44, 18);
            this.spin年度.Name = "spin年度";
            this.spin年度.Properties.Appearance.Font = new System.Drawing.Font("仿宋", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.spin年度.Properties.Appearance.Options.UseFont = true;
            this.spin年度.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spin年度.Properties.IsFloatValue = false;
            this.spin年度.Properties.Mask.EditMask = "\\d{4}";
            this.spin年度.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Regular;
            this.spin年度.Properties.Mask.ShowPlaceHolders = false;
            this.spin年度.Properties.MaxValue = new decimal(new int[] {
            2050,
            0,
            0,
            0});
            this.spin年度.Properties.MinValue = new decimal(new int[] {
            2017,
            0,
            0,
            0});
            this.spin年度.Size = new System.Drawing.Size(102, 26);
            this.spin年度.TabIndex = 0;
            // 
            // cbSemiannual
            // 
            this.cbSemiannual.Location = new System.Drawing.Point(151, 18);
            this.cbSemiannual.Name = "cbSemiannual";
            this.cbSemiannual.Properties.Appearance.Font = new System.Drawing.Font("仿宋", 14.25F);
            this.cbSemiannual.Properties.Appearance.Options.UseFont = true;
            this.cbSemiannual.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbSemiannual.Properties.Items.AddRange(new object[] {
            "上半年",
            "下半年"});
            this.cbSemiannual.Properties.NullValuePrompt = "请选择";
            this.cbSemiannual.Properties.NullValuePromptShowForEmptyValue = true;
            this.cbSemiannual.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbSemiannual.Size = new System.Drawing.Size(111, 26);
            this.cbSemiannual.TabIndex = 1;
            // 
            // btn确定
            // 
            this.btn确定.Location = new System.Drawing.Point(71, 534);
            this.btn确定.Name = "btn确定";
            this.btn确定.Size = new System.Drawing.Size(75, 23);
            this.btn确定.TabIndex = 2;
            this.btn确定.Text = "确定";
            this.btn确定.Click += new System.EventHandler(this.btn确定_Click);
            // 
            // btn取消
            // 
            this.btn取消.Location = new System.Drawing.Point(151, 534);
            this.btn取消.Name = "btn取消";
            this.btn取消.Size = new System.Drawing.Size(75, 23);
            this.btn取消.TabIndex = 4;
            this.btn取消.Text = "取消";
            this.btn取消.Click += new System.EventHandler(this.btn取消_Click);
            // 
            // listBoxControl职级
            // 
            this.listBoxControl职级.Appearance.Font = new System.Drawing.Font("华文宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxControl职级.Appearance.Options.UseFont = true;
            this.listBoxControl职级.Cursor = System.Windows.Forms.Cursors.Default;
            this.listBoxControl职级.DisplayMember = "薪等名称";
            this.listBoxControl职级.Location = new System.Drawing.Point(44, 50);
            this.listBoxControl职级.Name = "listBoxControl职级";
            this.listBoxControl职级.Size = new System.Drawing.Size(218, 478);
            this.listBoxControl职级.TabIndex = 5;
            this.listBoxControl职级.ValueMember = "薪等编号";
            // 
            // SelectJobGradeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(302, 569);
            this.Controls.Add(this.listBoxControl职级);
            this.Controls.Add(this.btn取消);
            this.Controls.Add(this.btn确定);
            this.Controls.Add(this.cbSemiannual);
            this.Controls.Add(this.spin年度);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SelectJobGradeForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "请选择年度和职等";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SelectJobGradeForm_FormClosed);
            this.Load += new System.EventHandler(this.SelectJobGradeForm_Load);
            this.Shown += new System.EventHandler(this.SelectJobGradeForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.spin年度.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbSemiannual.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.listBoxControl职级)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SpinEdit spin年度;
        private DevExpress.XtraEditors.ComboBoxEdit cbSemiannual;
        private DevExpress.XtraEditors.SimpleButton btn确定;
        private DevExpress.XtraEditors.SimpleButton btn取消;
        private DevExpress.XtraEditors.ListBoxControl listBoxControl职级;
    }
}