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
    public partial class SalaryPlanTree : XtraForm
    {
        public SalaryPlanTree()
        {
            InitializeComponent();
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

        private void SalaryPlanTree_Load(object sender, EventArgs e)
        {
            CreateWaitDialog("正在加载数据...", "请稍等");

            List<SalaryPlan> allPlan = SalaryPlan.薪酬体系表;
            List<SalaryGrade> allGrades = SalaryGrade.当前薪等表;
            List<SalaryStep> allSteps = SalaryStep.GetEffectedSteps(DateTime.Today, allGrades);

            var setids = from p in allPlan
                        group p by p.集合 into setid
                        select setid;

            CreateWaitDialog("正在创建薪酬体系树...", "请稍等");

            //生成集合点
            foreach(var setid in setids)
                treeView1.Nodes.Add(setid.Key);

            //生成薪酬体系节点
            foreach (TreeNode node in treeView1.Nodes)
            {
                List<SalaryPlan> salPlans = allPlan.FindAll(a => a.集合 == node.Text);
                foreach (SalaryPlan plan in salPlans)
                {
                    TreeNode planNode = node.Nodes.Add(plan.英文名, plan.中文名);                    
                    //生成薪等
                    List<SalaryGrade> myGrades = allGrades.FindAll(a=>a.集合 == node.Text && a.薪酬体系 == plan.英文名);
                    foreach (SalaryGrade grade in myGrades)
                    {
                        TreeNode gradeNode = planNode.Nodes.Add(grade.薪等编号, grade.薪等名称);
                        //生成薪级
                        List<SalaryStep> mySteps = allSteps.FindAll(a => a.集合 == node.Text && a.薪酬体系 == plan.英文名 && a.薪等编号 == grade.薪等编号);
                        foreach (SalaryStep step in mySteps)
                        {
                            TreeNode stepNode = gradeNode.Nodes.Add(step.薪级编号.ToString(), step.薪级名称);
                        }
                    }
                }
            }

            CloseWaitDialog();

            treeView1.ExpandAll();
            
        }
    }
}
