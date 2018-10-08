using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using YiKang.RBACS.DataObjects;
using System.Collections.Generic;
using DevExpress.XtraGrid.Views.Base;
using Hwagain.Components;
using Hwagain.SalaryCalculation.Components;
using YiKang;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.Utils;


namespace Hwagain.SalaryCalculation
{
    public partial class GradeSalaryStandardForm : XtraForm
    {
        string salary_plan = null;
        int year;
        SemiannualType sntype;
        List<ImplementJobGrade> grade_list = new List<ImplementJobGrade>();  

        public GradeSalaryStandardForm(string salary_plan, int year, SemiannualType st)
            : this()
        {
            this.salary_plan = salary_plan;
            this.year = year;
            this.sntype = st;
        }

        public GradeSalaryStandardForm()
        {
            // This call is required by the Windows Form Designer.
            InitializeComponent();

            // TODO: Add any initialization after the InitializeComponent call
        }

        private void GradeSalaryStandardForm_Load(object sender, EventArgs e)
        {
            lbl标题.Text = "管理人员各职等职级"+ year + sntype.ToString() + "月薪执行标准表";
            LoadData(false);
            this.WindowState = FormWindowState.Maximized;
        }

        #region CreateWaitDialog

        WaitDialogForm dlg = null;
        public void CreateWaitDialog()
        {
            CreateWaitDialog("正在启动...", "请稍等");
        }
        public void CreateWaitDialog(string caption, string title, Size size)
        {
            CloseWaitDialog();
            dlg = new DevExpress.Utils.WaitDialogForm(caption, title, size);
        }
        public void CreateWaitDialog(string caption, string title)
        {
            CloseWaitDialog();
            dlg = new DevExpress.Utils.WaitDialogForm(caption, title);
        }
        public void SetWaitDialogCaption(string fCaption)
        {
            if (dlg != null)
                dlg.Caption = fCaption;
        }
        public void CloseWaitDialog()
        {
            if (dlg != null)
                dlg.Close();
        }
        #endregion

        #region 加载数据

        protected void LoadData(bool compare)
        {
            grade_list = ImplementJobGrade.GetImplementJobGradeList(salary_plan, year, sntype, true);
            gridControl1.DataSource = grade_list;
            SetMonthlySalaryColumnInfo();   
        }

        #endregion

        #region SetMonthlySalaryColumnInfo
        //设置月薪字段的表头名称
        void SetMonthlySalaryColumnInfo()
        {
            for (int i = 1; i <= 20; i++)
            {
                string fieldName = "R" + i;
                //获取第 i 列对象
                GridColumn col = gridView1.Columns[fieldName];
                //查找第 i 列值不为空的记录
                ImplementJobGrade ag = grade_list.Find(a => a.GetPropertyValue(fieldName) != null);

                if (ag != null)
                {                    
                    col.Caption = "　";
                    RankSalaryStandard rss = grade_list[0].职级工资表.Find(a => a.序号 == i);
                    if (rss != null)
                    {
                        col.Caption = rss.职级;
                    }

                    col.Visible = true;
                    col.Width = 50;
                    col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    col.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                }
                else
                    col.Visible = false;
            }
        }
        #endregion

        private void btn返回上一层_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GradeSalaryStandardForm_Shown(object sender, EventArgs e)
        {
            if (this.Owner != null) this.Owner.Hide();
        }

        private void GradeSalaryStandardForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.Owner != null) this.Owner.Show();
        }

    }

}

