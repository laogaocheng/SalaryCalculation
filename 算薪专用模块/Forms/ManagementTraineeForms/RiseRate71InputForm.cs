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
    public partial class RiseRate71InputForm : XtraForm
    {        
        protected bool isCheck = false; //是否验证录入

        string division = null;
        string grade = null;
        string type = null;
        RiseType rise_type_final = RiseType.金额; //满阶提资类型 

        List<ManagementTraineePayRiseStandardInput> rist_items = new List<ManagementTraineePayRiseStandardInput>();
        List<ManagementTraineePayRiseStandardInput> rist_items_opposite = new List<ManagementTraineePayRiseStandardInput>();

        bool showDifferent = false;

        public RiseRate71InputForm(string division, string grade, string type, bool isCheck)
            : this()
        {
            this.division = division;
            this.grade = grade;
            this.type = type;
            this.isCheck = isCheck;            
        }

        public RiseRate71InputForm()
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
        
        #region 加载数据

        protected void LoadData(bool compare)
        {
            CreateWaitDialog("正在查询...", "请稍等");

            rist_items = ManagementTraineePayRiseStandardInput.GetEditingRows(division, grade, type, isCheck);
            //如果没有记录，自动创建
            if (rist_items.Count == 0) rist_items = CreateEditingRows();
            //如果比较
            if (compare) rist_items_opposite = ManagementTraineePayRiseStandardInput.GetEditingRows(division, grade, type, !isCheck);
            
            SetWaitDialogCaption("正在加载...");
            
            gridControl1.DataSource = rist_items;
            gridControl1.RefreshDataSource();

            CloseWaitDialog();
            showDifferent = compare;            
        }

        #endregion

        #region 创建编辑记录

        List<ManagementTraineePayRiseStandardInput> CreateEditingRows()
        {
            List<ManagementTraineePayRiseStandardInput> list = new List<ManagementTraineePayRiseStandardInput>();
            list.Add(AddManagementTraineePayRiseStandardInput(1, type));
            list = list.OrderBy(a => a.序号).ToList();
            return list;
        }

        private ManagementTraineePayRiseStandardInput AddManagementTraineePayRiseStandardInput(int order, string type)
        {
            ManagementTraineePayRiseStandardInput item = ManagementTraineePayRiseStandardInput.AddManagementTraineePayRiseStandardInput(order, division, grade, type, (int)rise_type_final, isCheck);
            return item;
        }

        #endregion

        private void AdjustMonthlySalaryForm_Load(object sender, EventArgs e)
        {
            lbl标题.Text = division + " 届（" + grade + "）定职人员各次提资幅度标准录入";
            LoadData(false);
        }

        private void advBandedGridView1_ShowingEditor(object sender, CancelEventArgs e)
        {
            
        }

        private void btn保存提交_Click(object sender, EventArgs e)
        {
            bool isSameEditor = false;

            CreateWaitDialog("正在准备保存...", "请稍等");
            try
            {
                int order = 1;
                //保存录入人、录入时间
                foreach (ManagementTraineePayRiseStandardInput ms in rist_items)
                {
                    if (ms.另一人录入的记录 != null)
                    {
                        string editor = AccessController.CurrentUser.姓名;
                        string editor_opposite = ms.另一人录入的记录.录入人.Trim();
                        if (editor == editor_opposite && editor_opposite != "")
                        {
                            isSameEditor = true;
                            break;
                        }
                    }
                    ms.序号 = order++;
                    ms.录入人 = AccessController.CurrentUser.姓名;
                    ms.录入时间 = DateTime.Now;
                    ms.Save();
                }

                if (isSameEditor)
                {
                    CloseWaitDialog();

                    MessageBox.Show("提交失败：两次录入不能是同一个人");
                    return;
                }

                foreach (ManagementTraineePayRiseStandardInput ms in rist_items)
                {
                    //手动比较录入的内容
                    ms.CompareInputContent();
                }

                SetWaitDialogCaption("正在比较双人录入是否一致...");

                LoadData(true);
                //检查差异
                bool all_same = true;
                foreach (ManagementTraineePayRiseStandardInput ms in rist_items)
                {
                    if (!ms.另一人已录入 || ms.内容不同的字段.Count > 0)
                    {
                        all_same = false;
                        break;
                    }
                }
                if (all_same)
                {
                    rist_items = rist_items.OrderBy(a => a.序号).ThenByDescending(a => a.录入时间).ToList();
                    //转成正式
                    foreach (ManagementTraineePayRiseStandardInput ms in rist_items)
                    {
                        if (ms.一阶起薪 > 0) ms.UpdateToFormalTable();
                    }
                    MessageBox.Show("双人录入成功");
                }
                else
                {
                    //显示差异
                    gridControl1.DataSource = rist_items;
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

        #region gridView1_CustomDrawCell

        private void gridView1_CustomDrawCell(object sender, RowCellCustomDrawEventArgs e)
        {
            if (showDifferent == false) return;

            e.Appearance.ForeColor = Color.Black;
            e.Appearance.BackColor = Color.Transparent;

            ManagementTraineePayRiseStandardInput row = bandedGridView1.GetRow(e.RowHandle) as ManagementTraineePayRiseStandardInput;
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
            if (this.Owner != null) this.Owner.Hide();
        }

        private void AdjustMonthlySalaryForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.Owner != null) this.Owner.Show();
        }

        private void btn返回目录_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void gridView1_CustomColumnDisplayText(object sender, CustomColumnDisplayTextEventArgs e)
        {
            bool flag = e.Column.FieldName.IndexOf("增幅") != -1;
            if (e.Column.FieldName.IndexOf("二阶起薪") != -1) flag = true;
            if (e.Column.FieldName.IndexOf("满阶") != -1 && rise_type_final == RiseType.百分比) flag = true;

            if (flag)
            {
                decimal v = Convert.ToDecimal(e.Value);
                if (v > 0)
                    e.DisplayText = v.ToString("#.#") + "%";
                else
                    e.DisplayText = "";
            }
        }

        private void gridView1_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {

        }
    }

}

