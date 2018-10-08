using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Hwagain.Common;
using Hwagain.SalaryCalculation.Components;
using DevExpress.XtraEditors;
using DevExpress.Utils;

namespace Hwagain.SalaryCalculation.Modules
{
    public partial class StepPayRateView : XtraForm
    {
        List<StepPayRate> currRows = new List<StepPayRate>();

        SalaryNode currSalaryGrade = null;//当前薪等
        public StepPayRateView()
        {
            InitializeComponent();
        }

        private void PayRateInput_Load(object sender, EventArgs e)
        {
            this.Text = "职级工资标准表";

            SalaryNode root = SalaryNode.GetSalaryNode("");
            TreeNode rootNode = treeView1.Nodes.Add(root.标识.ToString(), root.名称);
            //生成薪等
            foreach (SalaryNode grade in root.子节点)
            {
                if (AccessController.CheckGrade(grade.标识))
                {
                    TreeNode gradeNode = rootNode.Nodes.Add(grade.标识.ToString(), grade.名称);
                    gradeNode.Tag = grade;
                }
            }
        }

        #region CreateWaitDialog

        WaitDialogForm dlg = null;
        public void CreateWaitDialog()
        {
            CreateWaitDialog("正在启动...", "请稍等...");
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

        #region treeView1_AfterSelect

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //清除原来的数据
            currRows.Clear();
            currSalaryGrade = null;
            if (e.Node.Tag != null)
            {
                currSalaryGrade = e.Node.Tag as SalaryNode;

                if (AccessController.CheckGrade(currSalaryGrade.标识))
                {                    
                    //创建当前薪等下的所有薪级的录入记录
                    currRows = StepPayRate.GetAll().FindAll(a => a.薪等标识 == currSalaryGrade.标识);
                    if (currRows.Count > 0)
                    {
                        StepPayRate step = currRows[0];
                        lbl设定时间.Text = step.设定时间.ToString("yyyy/M/d");
                        lbl执行时间.Text = step.执行日期.ToString("yyyy/M/d");
                    }
                }
                else
                {
                    MessageBox.Show("你没有权限浏览该薪等的职级工资标准。");
                }
            }
            gridControl1.DataSource = currRows;
            gridControl1.RefreshDataSource();
        }
        #endregion

        #region btn关闭窗口_Click

        private void btn关闭窗口_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}
