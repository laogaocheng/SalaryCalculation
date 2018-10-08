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


namespace Hwagain.SalaryCalculation
{
    public partial class PersonPayRateList : XtraForm
    {
        protected List<PersonPayRate> rows = new List<PersonPayRate>();

        public PersonPayRateList()
        {
            // This call is required by the Windows Form Designer.
            InitializeComponent();

            // TODO: Add any initialization after the InitializeComponent call
        }

        private void PersonPayRateList_Load(object sender, EventArgs e)
        {
            this.Text = gridView1.OptionsBehavior.Editable ? "调整个人职级工资表顺序" : "个人职级工资表";
            LoadData();
        }

        #region btn设置个人职级工资无效_Click

        private void btn设置个人职级工资无效_Click(object sender, EventArgs e)
        {
            ColumnView colView = (ColumnView)gridControl1.MainView;
            if (colView != null)
            {
                PersonPayRate currPersonPayRate = (PersonPayRate)colView.GetFocusedRow();
                if (currPersonPayRate != null)
                {
                    if (MessageBox.Show(String.Format("确实将【{0}】的职级工资设置为无效吗？", currPersonPayRate.姓名), "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2, 0, false) == DialogResult.Yes)
                    {
                        //默认本月月底
                        DateTime expiredDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1).AddMonths(1).AddDays(-1);
                        if (DateTime.Today.Day > 15) expiredDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1).AddDays(-1);
                        currPersonPayRate.失效日期 = expiredDate;
                        currPersonPayRate.有效 = false;
                        currPersonPayRate.Save();

                        LoadData();

                        MessageBox.Show(String.Format("已将【{0}】的职级工资设置为无效。", currPersonPayRate.姓名), "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);                        
                    }
                }
                else
                    MessageBox.Show("错误：没有选中的记录。");
            }
        }
        #endregion

        #region SetEditable

        protected void SetEditable()
        {
            gridView1.OptionsBehavior.Editable = true;
        }
        #endregion

        #region btn导出_Click

        private void btn导出_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = "不执行标准的员工职级工资明细表";
            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string filename = saveFileDialog1.FileName;
                gridView1.ExportToXls(filename);
            }
        }
        #endregion

        #region btn查询_Click

        private void btn查询_Click(object sender, EventArgs e)
        {
            LoadData();
        }
        #endregion

        #region LoadData

        private void LoadData()
        {
            rows = PersonPayRate.GetAll(chk仅显示有效的记录.Checked);
            if (string.IsNullOrEmpty(searchKey.Text) == false) rows = rows.FindAll(a => a.姓名.Contains(searchKey.Text));
            //根据权限过滤
            rows = rows.FindAll(a => a.员工信息 != null && AccessController.CheckPayGroup(a.员工信息.薪资组));
            rows = rows.OrderBy(a => a.员工信息.员工序号).ToList();

            gridControl1.DataSource = rows;
            gridControl1.RefreshDataSource();
            gridView1.ExpandAllGroups();
        }
        #endregion

        #region chk仅显示有效的记录_CheckedChanged

        private void chk仅显示有效的记录_CheckedChanged(object sender, EventArgs e)
        {
            LoadData();
        }
        #endregion

        #region gridView1_FocusedRowChanged

        private void gridView1_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            PersonPayRate row = gridView1.GetFocusedRow() as PersonPayRate;
            if (row != null)
            {
                btn设置个人职级工资无效.Enabled = row.有效;
            }
        }
        #endregion
    }

}

