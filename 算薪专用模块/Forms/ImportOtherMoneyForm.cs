using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

using System.Windows.Forms;
using YiKang.RBACS.DataObjects;
using System.Collections.Generic;
using DevExpress.XtraGrid.Views.Base;
using Hwagain.Components;
using Hwagain.SalaryCalculation.Components;
using YiKang;
using DevExpress.XtraEditors;
using Aspose.Cells;
using DevExpress.Utils;


namespace Hwagain.SalaryCalculation
{
    public partial class ImportOtherMoneyForm : XtraForm
    {
        protected List<OtherMoneyData> currRows = new List<OtherMoneyData>();
        protected OtherMoneyData currRow = null;//当前记录
        DateTime prevMonth = DateTime.Today.AddMonths(-1);
            
        public ImportOtherMoneyForm()
        {
            // This call is required by the Windows Form Designer.
            InitializeComponent();

            // TODO: Add any initialization after the InitializeComponent call
        }

        private void EditPersonPayRateForm_Load(object sender, EventArgs e)
        {
            this.Text = "批量导入其它奖项和扣项";
            
            year.Value = prevMonth.Year;
            month.EditValue = prevMonth.Month.ToString();

            gridControl1.DataSource = currRows;
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

        #region btn保存_Click

        private void btn保存_Click(object sender, EventArgs e)
        {
            CreateWaitDialog("正在保存导入的奖扣项数据...", "请稍等");

            foreach(OtherMoneyData row in currRows)
            {
                OtherMoney newItem = OtherMoney.AddOtherMoney(row.员工编号, row.姓名, row.年, row.月, row.类型, row.项目名称);
                newItem.金额 = row.金额;
                newItem.录入人 = AccessController.CurrentUser.姓名;
                newItem.录入时间 = DateTime.Now;
                newItem.Save();
            }
            
            CloseWaitDialog();

            MyHelper.WriteLog(LogType.信息, "导入其他奖项和扣项", null);

            MessageBox.Show("保存成功！");
        }
        #endregion

        #region btn添加_Click

        private void btn添加_Click(object sender, EventArgs e)
        {
            OtherMoneyData item = new OtherMoneyData();
            
            item.年 = Convert.ToInt32(year.Value);
            item.月 = Convert.ToInt32(month.Text);

            currRows.Add(item);
            gridControl1.RefreshDataSource();
            gridView1.FocusedRowHandle = gridView1.RowCount - 1;
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
                    OtherMoneyData currentItem = (OtherMoneyData)colView.GetFocusedRow();
                    currRows.Remove(currentItem);
                    OtherMoney.GetOtherMoney(currentItem.员工编号, currentItem.年, currentItem.月, currentItem.类型, currentItem.项目名称);
                    currentItem = null;
                    gridControl1.RefreshDataSource();
                    MessageBox.Show("删除成功。", "删除提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        #endregion

        #region gridView1_InvalidRowException

        private void gridView1_InvalidRowException(object sender, InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError;
        }
        #endregion

        #region gridView1_CellValueChanged

        private void gridView1_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            OtherMoneyData row = gridView1.GetRow(e.RowHandle) as OtherMoneyData;

            if (row != null)
            {
                if (e.Column.FieldName == "员工编号")
                {
                    PersonalInfo pInfo = PersonalInfo.Get(row.员工编号);
                    if (pInfo == null)
                    {
                        MessageBox.Show("找不到指定编号的员工");
                    }
                    else
                    {
                        row.姓名 = pInfo.姓名;
                        gridControl1.RefreshDataSource();
                    }
                }
            }
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

        #region gridView1_DoubleClick

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
 
        }

        #endregion

        #region btn导入_Click

        private void btn导入_Click(object sender, EventArgs e)
        {
            if (prevMonth.Year != Convert.ToInt32(year.Value) || prevMonth.Month != Convert.ToInt32(month.Text))
            {
                if (MessageBox.Show("您导入的不是上月的数据，您要继续吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2, 0, false) != DialogResult.Yes)
                {
                    return;
                }
            }

            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                CreateWaitDialog("正在导入数据...", "请稍等");

                Workbook workbook = new Workbook(openFileDialog1.FileName);
                Worksheet sheet = workbook.Worksheets[0];
                Cells cells = sheet.Cells;

                currRows.Clear();

                int totalCount = 0;
                List<Row> errorRows = new List<Row>();
                foreach (Row row in sheet.Cells.Rows)
                {
                    try
                    {
                        OtherMoneyData item = new OtherMoneyData();

                        item.年 = Convert.ToInt32(year.Value);
                        item.月 = Convert.ToInt32(month.Text);

                        item.员工编号 = (string)cells[row.Index, 0].StringValue;
                        item.姓名 = (string)cells[row.Index, 1].StringValue;
                        item.类型 = (string)cells[row.Index, 2].StringValue;
                        item.项目名称 = (string)cells[row.Index, 3].StringValue;
                        item.金额 = Convert.ToDecimal(cells[row.Index, 4].Value);

                        currRows.Add(item);
                        totalCount++;
                    }
                    catch
                    {
                        errorRows.Add(row);
                    }
                }
                CloseWaitDialog();
                gridControl1.RefreshDataSource();

                string errMsg = "";
                foreach (Row row in errorRows)
                {
                    if (errMsg != "") errMsg += "、";
                    errMsg += (row.Index + 1).ToString();
                }
                string msg = "导入完毕，" + totalCount + " 成功, " + errorRows.Count + " 失败。\n\n失败行：" + errMsg;
                MessageBox.Show(msg);
            }
        }
        #endregion

    }

}

