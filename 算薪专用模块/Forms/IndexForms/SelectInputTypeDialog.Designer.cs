namespace Hwagain.SalaryCalculation.Components.Forms.IndexForms
{
    partial class SelectInputTypeDialog
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
            this.btn初次录入 = new DevExpress.XtraEditors.SimpleButton();
            this.btn验证录入 = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // btn初次录入
            // 
            this.btn初次录入.Appearance.Font = new System.Drawing.Font("华文新魏", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn初次录入.Appearance.Options.UseFont = true;
            this.btn初次录入.Location = new System.Drawing.Point(39, 32);
            this.btn初次录入.Name = "btn初次录入";
            this.btn初次录入.Size = new System.Drawing.Size(159, 50);
            this.btn初次录入.TabIndex = 1;
            this.btn初次录入.Text = "初次录入";
            this.btn初次录入.Click += new System.EventHandler(this.btn初次录入_Click);
            // 
            // btn验证录入
            // 
            this.btn验证录入.Appearance.Font = new System.Drawing.Font("华文新魏", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn验证录入.Appearance.Options.UseFont = true;
            this.btn验证录入.Location = new System.Drawing.Point(39, 109);
            this.btn验证录入.Name = "btn验证录入";
            this.btn验证录入.Size = new System.Drawing.Size(159, 50);
            this.btn验证录入.TabIndex = 2;
            this.btn验证录入.Text = "验证录入";
            this.btn验证录入.Click += new System.EventHandler(this.btn验证录入_Click);
            // 
            // SelectInputTypeDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(239, 199);
            this.Controls.Add(this.btn验证录入);
            this.Controls.Add(this.btn初次录入);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SelectInputTypeDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "选择初次录入还是验证录入";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SelectInputTypeDialog_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btn初次录入;
        private DevExpress.XtraEditors.SimpleButton btn验证录入;
    }
}