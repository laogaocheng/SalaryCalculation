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
    public partial class PayRateInputForm : XtraForm
    {
        List<PayRateInput> currInputRows = new List<PayRateInput>();

        bool isCheckInput = false; //是否验证录入
        SalaryNode currSalaryGrade = null;//当前薪等
        public PayRateInputForm()
        {
            InitializeComponent();
        }

        #region PayRateInput_Load

        private void PayRateInput_Load(object sender, EventArgs e)
        {
            this.Text = "职级工资录入 - " + (this.是验证录入 ? "验证录入" : "初次录入");

            SalaryNode root = SalaryNode.GetSalaryNode("");
            TreeNode rootNode = treeView1.Nodes.Add(root.标识.ToString(), root.名称);
            //生成薪等
            foreach (SalaryNode grade in root.子节点)
            {
                if (grade.已撤销 == false && AccessController.CheckGrade(grade.标识))
                {
                    TreeNode gradeNode = rootNode.Nodes.Add(grade.标识.ToString(), grade.名称);
                    gradeNode.Tag = grade;
                }
            }
            treeView1.ExpandAll();
        }
        #endregion

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
            currInputRows.Clear();
            btn确定.Enabled = false;
            currSalaryGrade = null;
            if (e.Node.Tag != null)
            {
                currSalaryGrade = e.Node.Tag as SalaryNode;

                if (AccessController.CheckGrade(currSalaryGrade.标识))
                {
                    btn确定.Enabled = true;
                    //创建当前薪等下的所有薪级的录入记录
                    foreach (SalaryNode step in currSalaryGrade.子节点)
                    {
                        if (step.已撤销) continue;

                        PayRateInput pInput = PayRateInput.GetEditing(step.标识, this.是验证录入);
                        //如果没有初次录入
                        if (pInput == null)
                        {
                            pInput = new PayRateInput();

                            pInput.执行日期 = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
                            pInput.薪等标识 = currSalaryGrade.标识;
                            pInput.薪级标识 = step.标识;
                            pInput.是验证录入 = this.是验证录入;
                            pInput.双人录入结果 = "";
                            //找验证录入
                            PayRateInput pInputOther = PayRateInput.GetEditing(step.标识, !this.是验证录入);
                            if (pInputOther != null)
                            {
                                pInput.编号 = pInputOther.编号;
                            }
                            pInput.Save();
                        }
                        currInputRows.Add(pInput);
                        dateEdit1.DateTime = pInput.执行日期;
                    }
                }
                else
                {
                    MessageBox.Show("你没有权限设置该薪等的职级工资。");
                }
            }
            gridControl1.DataSource = currInputRows;
            gridControl1.RefreshDataSource();
        }
        #endregion

        #region 是验证录入

        public bool 是验证录入
        {
            get
            {
                return isCheckInput;
            }
            set
            {
                isCheckInput = value;
            }
        }
        #endregion

        private void repositoryItemCalcEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {

        }

        #region btn确定_Click

        private void btn确定_Click(object sender, EventArgs e)
        {
            if (dateEdit1.DateTime == DateTime.MinValue)
            {
                MessageBox.Show("请输入执行日期");
                return;
            }

            if (currInputRows.Count == 0)
            {
                MessageBox.Show("没有找到职级工资记录");
                return;
            }
            foreach (PayRateInput input in currInputRows)
            {
                if (input.工资额 == 0)
                {
                    MessageBox.Show("请输入职级工资后重试");
                    return;
                }
            }
            List<PayRateInput> otherInputRows = PayRateInput.GetEditingRows(currSalaryGrade.标识, !是验证录入);
            bool allOK = currInputRows.Count == otherInputRows.Count;
            //遍历当前录入的行
            foreach (PayRateInput input in currInputRows)
            {
                string comparingResult = input.Compare();
                if (comparingResult != "两人录入完全一致") allOK = false;
            }
            //如果所有录入一致
            if (allOK)
            {
                //将录入内容转到正式表
                foreach (PayRateInput input in currInputRows)
                {
                    BecomeEffective(input);
                }
                MessageBox.Show("职级工资录入成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (otherInputRows.Count > 0)
                    MessageBox.Show("初次录入和验证录入的职级工资不一致，请纠正后再试！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show("保存成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        #region BecomeEffective

        //编程正式数据
        private static void BecomeEffective(PayRateInput input)
        {
            StepPayRate stepPayRate = StepPayRate.AddStepPayRate(input.薪等标识, input.薪级标识, input.执行日期);
            stepPayRate.工资额 = input.工资额;
            stepPayRate.设定时间 = DateTime.Now;

            PayRateInput anotherInput = input.另一人录入的记录 as PayRateInput;

            stepPayRate.录入人 = !input.是验证录入 ? input.录入人 : anotherInput.录入人;
            stepPayRate.录入时间 = !input.是验证录入 ? input.录入时间 : anotherInput.录入时间;
            stepPayRate.验证人 = input.是验证录入 ? input.录入人 : anotherInput.录入人;
            stepPayRate.验证时间 = input.是验证录入 ? input.录入时间 : anotherInput.录入时间;

            stepPayRate.Save();

            input.UpdateCompareResult();
        }
        #endregion

        #region gridView1_ValidateRow

        private void gridView1_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            PayRateInput row = e.Row as PayRateInput;
            if (row != null)
            {
                if (row.工资额 == 0) e.Valid = false;
            }
        }
        #endregion

        #region gridView1_CustomDrawCell

        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            e.Appearance.ForeColor = Color.Black;
            e.Appearance.BackColor = Color.Transparent;

            PayRateInput row = gridView1.GetRow(e.RowHandle) as PayRateInput;
            if (row != null)
            {
                foreach (ModifyField field in row.内容不同的字段)
                {
                    if (field.名称 == e.Column.FieldName)
                    {
                        e.Appearance.ForeColor = Color.Yellow;
                        e.Appearance.BackColor = Color.Red;
                    }
                }
            }
        }
        #endregion

        #region gridView1_CellValueChanged

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            PayRateInput row = gridView1.GetRow(e.RowHandle) as PayRateInput;
            if (row != null)
            {
                row.GetModifiyFields();
            }
        }
        #endregion

        #region dateEdit1_EditValueChanged

        private void dateEdit1_EditValueChanged(object sender, EventArgs e)
        {
            //将录入内容转到正式表
            foreach (PayRateInput input in currInputRows)
            {
                input.执行日期 = dateEdit1.DateTime;
                input.Save();
            }
        }
        #endregion

        #region treeView1_DrawNode

        private void treeView1_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.White, e.Node.Bounds);
            if (e.State == TreeNodeStates.Selected)//做判断
            {
                e.Graphics.FillRectangle(new SolidBrush(SystemColors.HotTrack), new Rectangle(e.Node.Bounds.Left, e.Node.Bounds.Top, e.Node.Bounds.Width, e.Node.Bounds.Height));//背景色为蓝色
                e.Graphics.DrawString(e.Node.Text, treeView1.Font, Brushes.White, e.Bounds);                //字体为白色
            }
            else
                e.DrawDefault = true;
        }
        #endregion
    }
}
