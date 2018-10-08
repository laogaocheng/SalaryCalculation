using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;

using YiKang.RBACS.DataObjects;
using DevExpress.XtraGrid.Views.Base;
using Hwagain.Components;
using Hwagain.SalaryCalculation.Components;
using YiKang;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.Utils;
using DevExpress.XtraPrinting;
using Aspose.Cells;
using System.Data;


namespace Hwagain.SalaryCalculation
{
    public partial class TraineeAnnualAssessmentForm : XtraForm
    {        
        protected bool isCheck = false; //是否验证录入

        string division = null;
        string grade = null;
        int year;

        List<ManagementTraineeAbilityInput> trainee_ability_list = new List<ManagementTraineeAbilityInput>();
        List<ManagementTraineeAbilityInput> trainee_ability_list_opposite = new List<ManagementTraineeAbilityInput>();

        bool showDifferent = false;

        public TraineeAnnualAssessmentForm(string division, string grade, int year, bool isCheck)
            : this()
        {
            this.division = division;
            this.grade = grade;
            this.year = year;
            this.isCheck = isCheck;            
        }

        public TraineeAnnualAssessmentForm()
        {
            // This call is required by the Windows Form Designer.
            InitializeComponent();
            // TODO: Add any initialization after the InitializeComponent call
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
        
        #region 创建编辑记录

        List<ManagementTraineeAbilityInput> CreateEditingRows()
        {
            //清除旧记录
            ManagementTraineeAbilityInput.ClearTraineeAbility(division, grade, year);

            List<ManagementTraineeAbilityInput> list = new List<ManagementTraineeAbilityInput>();
            //通过管培生名单
            List<ManagementTraineeInfo> traineeList = ManagementTraineeInfo.GetManagementTraineeInfoList(division, grade);
            //排序
            traineeList = traineeList.OrderBy(a => a.公司).ThenBy(a => a.入职时间).ToList();

            int order = 1;
            foreach (ManagementTraineeInfo trainee in traineeList)
            {
                if (trainee.员工信息.状态 == "A") //只需要录入在职的管培生
                {
                    ManagementTraineeAbilityInput item = ManagementTraineeAbilityInput.AddManagementTraineeAbilityInput(division, grade, trainee.员工编号, trainee.姓名, year, order++, isCheck);
                    list.Add(item);
                }
            }

            return list;
        }

        #endregion

        #region 加载数据

        protected void LoadData(bool compare)
        {
            bool isSameEditor = false;

            CreateWaitDialog("正在查询...", "请稍等");

            trainee_ability_list = ManagementTraineeAbilityInput.GetEditingRows(division, grade, year, isCheck);
            //如果没有记录，自动创建
            if (trainee_ability_list.Count == 0) trainee_ability_list = CreateEditingRows();

            //如果比较
            if (compare) trainee_ability_list_opposite = ManagementTraineeAbilityInput.GetEditingRows(this.division, grade, year, !isCheck);
            
            SetWaitDialogCaption("正在加载...");            
            
            if (isSameEditor)
            {
                CloseWaitDialog();

                MessageBox.Show("两次录入不能是同一个人");
                this.Close();
            }

            gridControl1.DataSource = trainee_ability_list;
            gridControl1.Refresh();

            CloseWaitDialog();

            showDifferent = compare;            
        }        

        #endregion       

        private void AdjustMonthlySalaryForm_Load(object sender, EventArgs e)
        {
            lbl标题.Text = division + " 届" + grade + "定职人员 " + year + " 年能力评定结果录入";
            LoadData(false);
        }

        private void advBandedGridView1_ShowingEditor(object sender, CancelEventArgs e)
        {
            
        }

        #region btn保存提交_Click

        private void btn保存提交_Click(object sender, EventArgs e)
        {
            bool isSameEditor = false;

            CreateWaitDialog("正在准备保存...", "请稍等");
            try
            {
                //检查是否所有职等都录入完成
                foreach (ManagementTraineeAbilityInput ta in trainee_ability_list)
                {
                    if (string.IsNullOrEmpty(ta.能力级别))
                    {
                        MessageBox.Show("错误：能力级别不能为空");
                        return;
                    }
                }                

                int order = 1;
                foreach (ManagementTraineeAbilityInput item in trainee_ability_list)
                {
                    if (item.另一人录入的记录 != null)
                    {
                        string editor = AccessController.CurrentUser.姓名;
                        string editor_opposite = item.另一人录入的记录.录入人.Trim();
                        if (editor == editor_opposite && editor_opposite != "")
                        {
                            isSameEditor = true;
                            break;
                        }
                    }
                    item.序号 = order++;
                    item.录入人 = AccessController.CurrentUser.姓名;
                    item.录入时间 = DateTime.Now;
                    item.Save();
                }

                if (isSameEditor)
                {
                    CloseWaitDialog();

                    MessageBox.Show("提交失败：两次录入不能是同一个人");
                    return;
                }

                foreach (ManagementTraineeAbilityInput item in trainee_ability_list)
                {
                    //手动比较录入的内容
                    item.CompareInputContent();
                }

                SetWaitDialogCaption("正在比较双人录入是否一致...");

                LoadData(true);
                //检查差异
                bool all_same = true;
                foreach (ManagementTraineeAbilityInput ms in trainee_ability_list)
                {
                    if (!ms.另一人已录入 || ms.内容不同的字段.Count > 0)
                    {
                        all_same = false;
                        break;
                    }
                }
                if (all_same)
                {
                    //转成正式
                    foreach (ManagementTraineeAbilityInput ms in trainee_ability_list)
                    {
                        ms.UpdateToFormalTable();
                        //生成员工提资标准
                        ManagementTraineePayStandard.CreatePayStandards(ms.员工编号, ms.年度);
                    }
                    MessageBox.Show("双人录入成功");
                }
                else
                {
                    //显示差异
                    gridControl1.DataSource = trainee_ability_list;
                    gridControl1.Refresh();
                    MessageBox.Show("提交失败：红色项目不一致，请重新核对修改");
                }
                gridControl1.Focus();
                this.Refresh();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
            finally
            {
                CloseWaitDialog();
            }
        }
        
        #endregion

        #region gridView1_CustomDrawCell

        private void gridView1_CustomDrawCell(object sender, RowCellCustomDrawEventArgs e)
        {
            if (showDifferent == false) return;

            e.Appearance.ForeColor = Color.Black;
            e.Appearance.BackColor = Color.Transparent;

            ManagementTraineeAbilityInput row = advBandedGridView1.GetRow(e.RowHandle) as ManagementTraineeAbilityInput;
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

        #region advBandedGridView1_CellValueChanged

        private void advBandedGridView1_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            
        }

        #endregion

        private void AdjustMonthlySalaryForm_Shown(object sender, EventArgs e)
        {
            if (this.Owner != null && this.Owner.Visible) this.Owner.Hide();
        }

        private void AdjustMonthlySalaryForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.Owner != null) this.Owner.Show();
        }

        private void btn返回目录_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn查漏_Click(object sender, EventArgs e)
        {
            CreateEditingRows();
            LoadData(false);
        }

        private void btn更新名单_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("更新名单会清除已经录入的数据，继续吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2, 0, false) == DialogResult.Yes)
            {
                CreateEditingRows();
                LoadData(false);
            }
        }
    }

}

