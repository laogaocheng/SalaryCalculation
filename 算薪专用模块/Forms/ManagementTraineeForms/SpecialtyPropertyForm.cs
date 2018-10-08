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
using DevExpress.XtraGrid.Columns;

namespace Hwagain.SalaryCalculation
{
    public partial class SpecialtyPropertyForm : XtraForm
    {        
        protected bool isCheck = false; //是否验证录入

        string division = null;

        List<TraineeInfo> traineeList = new List<TraineeInfo>();
        List<ManagementSpecialtyPropertyInput> specialty_property_list = new List<ManagementSpecialtyPropertyInput>();
        List<ManagementSpecialtyPropertyInput> specialty_property_list_opposite = new List<ManagementSpecialtyPropertyInput>();

        bool showDifferent = false;

        public SpecialtyPropertyForm(string division, bool isCheck)
            : this()
        {
            this.division = division;
            this.isCheck = isCheck;
            traineeList = TraineeInfo.GetAll().FindAll(a=>a.届别 == division);
        }

        public SpecialtyPropertyForm()
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

            specialty_property_list = ManagementSpecialtyPropertyInput.GetEditingRows(division, isCheck);
            
            //如果比较
            if (compare) specialty_property_list_opposite = ManagementSpecialtyPropertyInput.GetEditingRows(this.division, !isCheck);

            SetWaitDialogCaption("正在加载...");            
            
            gridControl1.DataSource = specialty_property_list;
            gridControl1.RefreshDataSource();

            CloseWaitDialog();
            showDifferent = compare;            
        }        

        #endregion       

        private void AdjustMonthlySalaryForm_Load(object sender, EventArgs e)
        {
            lbl标题.Text = division + " 届定职人员（管培生）专业属性确认表";
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
                //检查是否所有记录都已确认
                foreach (ManagementSpecialtyPropertyInput ms in specialty_property_list)
                {
                    if (ms.已确认 == false)
                    {
                        MessageBox.Show("错误：请确认所有记录后再试");
                        return;
                    }
                }
                int order = 1;
                //保存录入人、录入时间
                foreach (ManagementSpecialtyPropertyInput ms in specialty_property_list)
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

                foreach (ManagementSpecialtyPropertyInput ms in specialty_property_list)
                {
                    //手动比较录入的内容
                    ms.CompareInputContent();
                }

                SetWaitDialogCaption("正在比较双人录入是否一致...");

                LoadData(true);
                //检查差异
                bool all_same = true;
                foreach (ManagementSpecialtyPropertyInput ms in specialty_property_list)
                {
                    if (!ms.另一人已录入 || ms.内容不同的字段.Count > 0)
                    {
                        all_same = false;
                        break;
                    }
                }
                if (all_same)
                {
                    specialty_property_list = specialty_property_list.OrderBy(a => a.序号).ThenByDescending(a => a.录入时间).ToList();
                    //转成正式
                    foreach (ManagementSpecialtyPropertyInput ms in specialty_property_list)
                    {
                        ms.UpdateToFormalTable();
                    }
                    MessageBox.Show("双人录入成功");
                }
                else
                {
                    //显示差异
                    gridControl1.DataSource = specialty_property_list;
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

            ManagementSpecialtyPropertyInput row = gridView1.GetRow(e.RowHandle) as ManagementSpecialtyPropertyInput;
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

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void repositoryItemConfirmButton_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            ManagementSpecialtyPropertyInput row = gridView1.GetRow(gridView1.FocusedRowHandle) as ManagementSpecialtyPropertyInput;
            if (row != null)
            {
                //如果专业是有效的
                if (CheckSpecialtyValid(row))
                {
                    row.已确认 = true;
                    gridControl1.RefreshDataSource();
                    gridControl1.Refresh();
                }
                else //否则
                {
                    MessageBox.Show("确认失败：录入的专业名称无效。");
                }
            }
        }

        private bool CheckSpecialtyValid(ManagementSpecialtyPropertyInput row)
        {
            TraineeInfo item = traineeList.Find(a => a.岗位级别 == row.岗位级别 && a.学历 == row.学历 && a.学习专业 == row.专业名称);
            return item != null;
        }

        #region btnAdd_Click

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ManagementSpecialtyPropertyInput item = new ManagementSpecialtyPropertyInput();
            item.标识 = Guid.NewGuid();
            item.届别 = division;
            item.序号 = gridView1.RowCount + 1;
            specialty_property_list.Add(item);
            gridControl1.RefreshDataSource();
            gridView1.FocusedRowHandle = gridView1.RowCount - 1;
        }
        #endregion

        #region btnDelete_Click

        private void btnDelete_Click(object sender, EventArgs e)
        {
            ColumnView colView = (ColumnView)gridControl1.MainView;
            if (colView != null)
            {
                if (MessageBox.Show("确实删除当前记录吗？", "删除提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2, 0, false) == DialogResult.Yes)
                {
                    ManagementSpecialtyPropertyInput currentManagementSpecialtyPropertyInput = (ManagementSpecialtyPropertyInput)colView.GetFocusedRow();
                    if (currentManagementSpecialtyPropertyInput != null)
                    {
                        specialty_property_list.Remove(currentManagementSpecialtyPropertyInput);
                        currentManagementSpecialtyPropertyInput.Delete();
                        gridControl1.RefreshDataSource();
                        MessageBox.Show("删除成功。", "删除提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        #endregion

        private void gridView1_CustomColumnDisplayText(object sender, CustomColumnDisplayTextEventArgs e)
        {
            if(e.Column.FieldName == "已确认")
            {
                e.DisplayText = Convert.ToBoolean(e.Value) ? "已通过" : "";
            }            
        }

        private void gridView1_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "岗位级别" 
                || e.Column.FieldName == "学历"
                || e.Column.FieldName == "属性"
                || e.Column.FieldName == "专业名称")
            {
                ManagementSpecialtyPropertyInput row = gridView1.GetRow(gridView1.FocusedRowHandle) as ManagementSpecialtyPropertyInput;
                if (row != null)
                {
                    row.已确认 = false;
                    gridControl1.RefreshDataSource();
                    gridControl1.Refresh();
                }
            }
        }

        private void btn自动排序_Click(object sender, EventArgs e)
        {
            int order = 1;
            specialty_property_list = specialty_property_list.OrderBy(a => 岗位级别).ThenBy(a => a.学历).ThenBy(a => a.专业名称).ToList();
            foreach (ManagementSpecialtyPropertyInput item in specialty_property_list)
            {
                item.序号 = order++;
            }
            gridControl1.DataSource = specialty_property_list;
            gridControl1.RefreshDataSource();
            gridControl1.Refresh();
        }

        private void gridView1_ColumnChanged(object sender, EventArgs e)
        {
            
        }

        private void gridView1_FocusedColumnChanged(object sender, FocusedColumnChangedEventArgs e)
        {
            GridColumn col = e.FocusedColumn;
            if (col == null) return;

            if (col.FieldName == "岗位级别"
                || col.FieldName == "学历"
                || col.FieldName == "专业名称")
            {
                ManagementSpecialtyPropertyInput row = gridView1.GetRow(gridView1.FocusedRowHandle) as ManagementSpecialtyPropertyInput;
                if (row != null)
                {
                    col.OptionsColumn.AllowEdit = MyHelper.XpoSession.IsNewObject(row);
                }
            }
        }
    }

}

