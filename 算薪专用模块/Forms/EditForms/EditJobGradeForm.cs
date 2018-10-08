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
using DevExpress.XtraGrid.Views.Grid;


namespace Hwagain.SalaryCalculation
{
    public partial class EditJobGradeForm : XtraForm
    {
        protected bool isCheckInput = false; //是否验证录入
        protected List<JobGrade> currRows = new List<JobGrade>();
        protected JobGrade currJobGrade = null;//当前记录

        string salary_plan = "";

        public EditJobGradeForm(string salary_plan)
        {
            this.salary_plan = salary_plan;
            InitializeComponent();
        }

        private void EditJobGradeForm_Load(object sender, EventArgs e)
        {
            lbl标题.Text = salary_plan + "职等表";
            LoadData();
        }

        #region 加载数据

        protected void LoadData()
        {
            currRows = JobGrade.GetJobGrades(salary_plan);

            gridControl1.DataSource = currRows;
            gridControl1.RefreshDataSource();

            //初始化对比的职等
            repositoryItemGrades.Items.Clear();
            foreach (JobGrade grade in currRows)
            {
                repositoryItemGrades.Items.Add(grade.名称);
            }
        }        

        #endregion

        #region btn保存_Click

        private void btn保存_Click(object sender, EventArgs e)
        {
            ColumnView colView = (ColumnView)gridControl1.MainView;
            if (colView != null)
            {
                JobGrade currentItem = (JobGrade)colView.GetFocusedRow();
                if (currentItem != null) currentItem.Save();
                
                MessageBox.Show("保存成功！");
                LoadData();
            }
            MyHelper.WriteLog(LogType.信息, "修改职等", null);
        }
        #endregion

        #region btn添加_Click

        private void btn添加_Click(object sender, EventArgs e)
        {
            if (SaveFocusedRow())
            {
                JobGrade item = new JobGrade();
                item.薪酬体系 = salary_plan;
                item.序号 = currRows.Count + 1;

                currRows.Add(item);
                gridControl1.RefreshDataSource();
                gridView1.FocusedRowHandle = gridView1.RowCount - 1;

                MyHelper.WriteLog(LogType.信息, "新增职等", item.ToString<JobGrade>());
            }
        }

        private bool SaveFocusedRow()
        {
            try
            {
                ColumnView colView = (ColumnView)gridControl1.MainView;
                if (colView != null)
                {
                    JobGrade currentItem = (JobGrade)colView.GetFocusedRow();
                    if (currentItem != null) currentItem.Save();                    
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        #endregion

        #region btn删除_Click

        private void btn删除_Click(object sender, EventArgs e)
        {
            ColumnView colView = (ColumnView)gridControl1.MainView;
            if (colView != null)
            {
                if (MessageBox.Show("确实删除当前记录吗？", "删除提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2, 0, false) == DialogResult.Yes)
                {
                    JobGrade currentItem = (JobGrade)colView.GetFocusedRow();
                    currRows.Remove(currentItem);
                    currentItem.Delete();

                    MyHelper.WriteLog(LogType.信息, "删除职等", currentItem.ToString<JobGrade>());

                    gridControl1.RefreshDataSource();
                    MessageBox.Show("删除成功。", "删除提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        #endregion

        #region btn自动创建_Click

        private void btn自动创建_Click(object sender, EventArgs e)
        {
            int x = currRows.Count + 100;
            foreach (DictionaryEntry entry in PsHelper.职务等级)
            {
                string name = (string)entry.Key;
                int order = Convert.ToInt32(entry.Value);
                if (name != "岗位工级" && name != "非全日制") 
                    JobGrade.AddJobGrade(salary_plan, name.Replace("级", ""), ++x);
            }
            LoadData();
        }
        #endregion

        #region gridView1_InvalidRowException

        private void gridView1_InvalidRowException(object sender, InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.ThrowException;
        }
        #endregion

        #region gridView1_CellValueChanged

        private void gridView1_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {

        }
        #endregion

        #region gridView1_CustomDrawCell

        private void gridView1_CustomDrawCell(object sender, RowCellCustomDrawEventArgs e)
        {

        }
        #endregion

        #region gridView1_FocusedRowChanged

        private void gridView1_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {

        }
        #endregion

        #region gridView1_CellValueChanging

        private void gridView1_CellValueChanging(object sender, CellValueChangedEventArgs e)
        {

        }
        #endregion

        #region ProcessCmdKey

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                BaseEdit editor = gridView1.ActiveEditor;
                if (editor != null && string.IsNullOrEmpty(editor.ErrorText) == false)
                {
                    editor.EditValue = editor.OldEditValue;
                    return true;
                }
                else
                    return base.ProcessCmdKey(ref msg, keyData);
            }
            else
                return base.ProcessCmdKey(ref msg, keyData);
        }
        #endregion

        #region gridView1_CustomRowCellEditForEditing

        private void gridView1_CustomRowCellEditForEditing(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            
        }

        private void comboBox_SelectedValueChanged(object sender, EventArgs e)
        {

        }
        #endregion

        #region gridView1_DoubleClick

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {

        }
        #endregion

        #region repositoryItemImageComboBox1_SelectedValueChanged

        private void repositoryItemImageComboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            
        }
        #endregion

        private void gridView1_InvalidValueException(object sender, InvalidValueExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError;
        }

        #region gridView1_ValidatingEditor

        private void gridView1_ValidatingEditor(object sender, BaseContainerValidateEditorEventArgs e)
        {
            GridView view = sender as GridView;
            if (view.FocusedColumn.FieldName == "名称")
            {
                string name = (string)e.Value;
                if (name == null || name.Trim() == "")
                {
                    e.Valid = false;
                    e.ErrorText = "名称不能为空";
                }                
            }
        }
        #endregion

        private void EditJobGradeForm_Shown(object sender, EventArgs e)
        {
            if (this.Owner != null) this.Owner.Hide();
        }

        private void EditJobGradeForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.Owner != null) this.Owner.Show();
        }

        private void repositoryItemGrades_Validating(object sender, CancelEventArgs e)
        {
           
        }

        private void repositoryItemGrades_EditValueChanging(object sender, ChangingEventArgs e)
        {
            string g = (string)e.NewValue;
         
            ColumnView colView = (ColumnView)gridControl1.MainView;
            if (colView != null)
            {
                JobGrade currentItem = (JobGrade)colView.GetFocusedRow();
                if (currentItem.名称 == g)
                {
                    throw new Exception("对比的职等不能是自己");
                }
            }
        }
    }
}

