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
    public partial class EditEmployeeQueryPowerForm : XtraForm
    {
        protected bool isCheckInput = false; //是否验证录入
        protected List<QueryLevelInput> currInputRows = new List<QueryLevelInput>();
        protected QueryLevelInput currQueryLevel = null;//当前记录

        public EditEmployeeQueryPowerForm(bool isCheck) 
            : this()
        {
            isCheckInput = isCheck;
        }

        public EditEmployeeQueryPowerForm()
        {
            // This call is required by the Windows Form Designer.
            InitializeComponent();

            // TODO: Add any initialization after the InitializeComponent call
        }

        private void EditEmployeeQueryPowerForm_Load(object sender, EventArgs e)
        {
            this.Text = "查询权限录入 - " + (this.是验证录入 ? "验证录入" : "初次录入");

            repositoryItemImageComboBox1.Items.Clear();
            foreach (DictionaryEntry entry in PsHelper.GetCompanyTable())
            {
                ImageComboBoxItem item = new ImageComboBoxItem();
                item.Description = (string)entry.Key;
                item.Value = (string)entry.Value;
                repositoryItemImageComboBox1.Items.Add(item);
            }

            repositoryItemImageComboBox2.Items.Clear();
            foreach (DictionaryEntry entry in PsHelper.GetSupvLvls())
            {
                ImageComboBoxItem item = new ImageComboBoxItem();
                item.Description = (string)entry.Key;
                item.Value = (string)entry.Value;
                repositoryItemImageComboBox2.Items.Add(item);
            }
            LoadData();
        }

        #region 加载数据

        protected void LoadData()
        {
            //清除原来的数据
            currInputRows = QueryLevelInput.GetEditingRows(this.是验证录入);
            currInputRows = currInputRows.OrderBy(a => a.录入时间).ToList();

            gridControl1.DataSource = currInputRows;
            gridControl1.RefreshDataSource();
        }        

        #endregion
        
        #region BecomeEffective

        private void BecomeEffective(QueryLevelInput input)
        {
            QueryLevel m = new QueryLevel();
            QueryLevel found = QueryLevel.GetQueryLevel(input.姓名, input.公司编码, input.职务等级);
            if (found != null)
            {
                m = found;
            }
            input.CopyWatchMember(m);

            QueryLevelInput anotherInput = input.另一人录入的记录 as QueryLevelInput;

            m.录入人 = !input.是验证录入 ? input.录入人 : anotherInput.录入人;
            m.录入时间 = !input.是验证录入 ? input.录入时间 : anotherInput.录入时间;
            m.验证人 = input.是验证录入 ? input.录入人 : anotherInput.录入人;
            m.验证时间 = input.是验证录入 ? input.录入时间 : anotherInput.录入时间;
            m.Save();
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

        #region btn保存_Click

        private void btn保存_Click(object sender, EventArgs e)
        {
            ColumnView colView = (ColumnView)gridControl1.MainView;
            if (colView != null)
            {
                QueryLevelInput currentItem = (QueryLevelInput)colView.GetFocusedRow();
                if (currentItem != null) currentItem.Save();
                //遍历
                foreach(QueryLevelInput row in currInputRows)
                {
                    if (string.IsNullOrEmpty(row.职务等级)) continue;

                    row.UpdateCompareResult();
                    //如果完全相同，转为正式
                    if (row.内容不同的字段.Count == 0 && row.另一人已录入) BecomeEffective(row);
                }
                MessageBox.Show("保存成功！");
                LoadData();
            }
            MyHelper.WriteLog(LogType.信息, "修改查询权限记录", null);
        }
        #endregion

        #region btn添加_Click

        private void btn添加_Click(object sender, EventArgs e)
        {
            QueryLevelInput item = new QueryLevelInput();

            item.是验证录入 = this.是验证录入;

            item.录入人 = AccessController.CurrentUser.姓名;
            item.录入时间 = DateTime.Now;
            currInputRows.Add(item);
            gridControl1.RefreshDataSource();
            gridView1.FocusedRowHandle = gridView1.RowCount - 1;

            MyHelper.WriteLog(LogType.信息, "新增查询权限录入记录", item.ToString<QueryLevelInput>());
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
                    QueryLevelInput currentItem = (QueryLevelInput)colView.GetFocusedRow();
                    currInputRows.Remove(currentItem);
                    currentItem.Delete();

                    MyHelper.WriteLog(LogType.信息, "删除查询权限记录", currentItem.ToString<QueryLevelInput>());

                    gridControl1.RefreshDataSource();
                    MessageBox.Show("删除成功。", "删除提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        #endregion

        #region btn刷新_Click

        private void btn刷新_Click(object sender, EventArgs e)
        {
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
            QueryLevelInput row = gridView1.GetRow(e.RowHandle) as QueryLevelInput;

            if (row != null)
            {               
                row.GetModifiyFields();
            }
        }
        #endregion

        #region gridView1_CustomDrawCell

        private void gridView1_CustomDrawCell(object sender, RowCellCustomDrawEventArgs e)
        {
            e.Appearance.ForeColor = Color.Black;
            e.Appearance.BackColor = Color.Transparent;

            QueryLevelInput row = gridView1.GetRow(e.RowHandle) as QueryLevelInput;
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

        #region gridView1_FocusedRowChanged

        private void gridView1_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            QueryLevelInput row = gridView1.GetRow(e.PrevFocusedRowHandle) as QueryLevelInput;
            if (row != null)
            {                
                row.GetModifiyFields();
            }
        }
        #endregion

        #region gridView1_CellValueChanging

        private void gridView1_CellValueChanging(object sender, CellValueChangedEventArgs e)
        {
            QueryLevelInput row = gridView1.GetRow(e.RowHandle) as QueryLevelInput;

            if (row != null)
            {
            }
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
            BaseEdit editor = gridView1.ActiveEditor as BaseEdit;
            gridView1.SetFocusedRowCellValue("薪级标识", editor.EditValue);
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
            if (view.FocusedColumn.FieldName == "姓名")
            {
                string name = (string)e.Value;
                if (name == null || name.Trim() == "")
                {
                    e.Valid = false;
                    e.ErrorText = "用户名不能为空";
                }
                else
                {
                    User usr = User.GetUser((string)e.Value);
                    if (usr == null)
                    {
                        e.Valid = false;
                        e.ErrorText = "指定的用户不存在";
                    }
                }
            }
        }
        #endregion
    }
}

