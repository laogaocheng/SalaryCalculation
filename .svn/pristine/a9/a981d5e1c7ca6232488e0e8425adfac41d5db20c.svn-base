using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.Extensions;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraPrinting.Preview;
using DevExpress.XtraReports.UI;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.Design;
using System.IO;
using DevExpress.XtraPrinting.Control;
using Hwagain.SalaryCalculation.Components.UserControls;

namespace Hwagain.SalaryCalculation.Components.PrintViews
{
    public partial class PreviewControl : ReportBase
    {
        public class DesignForm : DevExpress.XtraReports.UserDesigner.XRDesignFormEx
        {
            protected override void SaveLayout() { }
            protected override void RestoreLayout() { }
        }
        protected class DemoReportExtension : ReportDesignExtension
        {
            protected RepositoryItem CreateRepositoryItemImageComboBox(string[] names, int valuesShift)
            {
                RepositoryItemImageComboBox item = new RepositoryItemImageComboBox();
                object[] values = CreateValues(valuesShift, names.Length);
                for (int i = 0; i < values.Length && i < names.Length; i++)
                {
                    item.Items.Add(new ImageComboBoxItem(names[i], values[i]));
                }
                return item;
            }

            object[] CreateValues(int valuesShift, int count)
            {
                List<object> values = new List<object>();
                for (int i = valuesShift; i < valuesShift + count; i++)
                {
                    values.Add(i);
                }
                return values.ToArray();
            }
        }
        protected DevExpress.XtraPrinting.Control.PrintControl printControl;
        private System.ComponentModel.IContainer components;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        protected PrintBarManager fPrintBarManager;

        public PreviewControl()
        {
            InitializeComponent();
            fPrintBarManager = CreatePrintBarManager(printControl);
        }

        public override XtraReport Report
        {
            get { return fReport; }
            set
            {
                if (fReport != value)
                {
                    if (fReport != null)
                        fReport.Dispose();
                    fReport = value;
                    if (fReport == null)
                        return;
                    Invalidate();
                    Update();
                    fileName = GetReportPath(fReport, "repx");
                    this.printControl.PrintingSystem = fReport.PrintingSystem;
                    fReport.PrintingSystem.SetCommandVisibility(PrintingSystemCommand.ClosePreview, DevExpress.XtraPrinting.CommandVisibility.None);
                    fReport.CreateDocument(true);
                }
            }
        }
        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        /// 
        private void InitializeComponent()
        {
            this.printControl = new DevExpress.XtraPrinting.Control.PrintControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // printControl
            // 
            this.printControl.BackColor = System.Drawing.Color.Empty;
            this.printControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.printControl.ForeColor = System.Drawing.Color.Empty;
            this.printControl.IsMetric = false;
            this.printControl.Location = new System.Drawing.Point(2, 2);
            this.printControl.Name = "printControl";
            this.printControl.Size = new System.Drawing.Size(696, 392);
            this.printControl.TabIndex = 1;
            this.printControl.TabStop = false;
            this.printControl.TooltipFont = new System.Drawing.Font("Tahoma", 9F);
            // 
            // panelControl1
            // 
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.panelControl1.Controls.Add(this.printControl);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(700, 396);
            this.panelControl1.TabIndex = 4;
            // 
            // PreviewControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.Controls.Add(this.panelControl1);
            this.Name = "PreviewControl";
            this.Size = new System.Drawing.Size(700, 396);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        protected PrintBarManager CreatePrintBarManager(PrintControl pc)
        {
            PrintBarManager printBarManager = new PrintBarManager();
            printBarManager.Form = printControl;
            printBarManager.Initialize(pc);
            printBarManager.MainMenu.Visible = false;
            printBarManager.AllowCustomization = false;
            return printBarManager;
        }
        private void ShowDesignerForm(Form designForm, Form parentForm)
        {
            designForm.MinimumSize = parentForm.MinimumSize;
            if (parentForm.WindowState == FormWindowState.Normal)
                designForm.Bounds = parentForm.Bounds;
            designForm.WindowState = parentForm.WindowState;
            parentForm.Visible = false;
            designForm.ShowDialog();
            parentForm.Visible = true;
        }
        protected virtual void InitializeControls()
        {
        }
        static string GetReportPath(DevExpress.XtraReports.UI.XtraReport fReport, string ext)
        {
            System.Reflection.Assembly asm = System.Reflection.Assembly.GetExecutingAssembly();
            string repName = fReport.Name;
            if (repName.Length == 0)
                repName = fReport.GetType().Name;
            string dirName = Path.GetDirectoryName(asm.Location);
            return Path.Combine(dirName, String.Format("{0}.{1}", repName, ext));
        }
    }
}