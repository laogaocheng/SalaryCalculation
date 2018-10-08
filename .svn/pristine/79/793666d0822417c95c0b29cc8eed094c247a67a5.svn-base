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
    public partial class EditAuthorizeComputerForm : XtraForm
    {
        protected bool isCheckInput = false; //是否验证录入
        protected List<AuthorizeComputer> currRows = new List<AuthorizeComputer>();
        protected AuthorizeComputer currQueryLevel = null;//当前记录

        public EditAuthorizeComputerForm()
        {
            // This call is required by the Windows Form Designer.
            InitializeComponent();

            // TODO: Add any initialization after the InitializeComponent call
        }

        private void EditAuthorizeComputerForm_Load(object sender, EventArgs e)
        {
            this.Text = "可接入工资查询模块的电脑";

            LoadData();
        }

        #region 加载数据

        protected void LoadData()
        {
            //清除原来的数据
            currRows = AuthorizeComputer.GetAll();

            gridControl1.DataSource = currRows;
            gridControl1.RefreshDataSource();
        }        

        #endregion

        #region btn保存_Click

        private void btn保存_Click(object sender, EventArgs e)
        {
            ColumnView colView = (ColumnView)gridControl1.MainView;
            if (colView != null)
            {
                AuthorizeComputer currentItem = (AuthorizeComputer)colView.GetFocusedRow();
                if (currentItem != null) currentItem.Save();
                
                MessageBox.Show("保存成功！");
                LoadData();
            }
            MyHelper.WriteLog(LogType.信息, "修改允许启动工资查询模块的电脑的记录", null);
        }
        #endregion

        #region btn添加_Click

        private void btn添加_Click(object sender, EventArgs e)
        {
            AuthorizeComputer item = new AuthorizeComputer();
            
            item.创建人 = AccessController.CurrentUser.姓名;
            item.创建时间 = DateTime.Now;
            currRows.Add(item);
            gridControl1.RefreshDataSource();
            gridView1.FocusedRowHandle = gridView1.RowCount - 1;

            MyHelper.WriteLog(LogType.信息, "新增允许启动工资查询模块的电脑的记录", item.ToString<AuthorizeComputer>());
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
                    AuthorizeComputer currentItem = (AuthorizeComputer)colView.GetFocusedRow();
                    currRows.Remove(currentItem);
                    currentItem.Delete();

                    MyHelper.WriteLog(LogType.信息, "删除可接入工资查询模块的电脑的记录", currentItem.ToString<AuthorizeComputer>());

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
            if (view.FocusedColumn.FieldName == "名称" || view.FocusedColumn.FieldName == "地址")
            {
                string name = (string)e.Value;
                if (name == null || name.Trim() == "")
                {
                    e.Valid = false;
                    e.ErrorText = "名称和IP地址不能为空";
                }                
            }
        }
        #endregion
    }
}

