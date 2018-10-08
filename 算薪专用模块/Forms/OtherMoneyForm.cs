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
    public partial class OtherMoneyForm : XtraForm
    {
        protected string type = ""; //项目类型：其它奖项、其它扣项、代垫费用、工资降级
        protected List<OtherMoney> currRows = new List<OtherMoney>();
        protected OtherMoney currPersonPayRate = null;//当前记录

        public OtherMoneyForm(string itemType) 
            : this()
        {
            type = itemType;
        }

        public OtherMoneyForm()
        {
            // This call is required by the Windows Form Designer.
            InitializeComponent();

            // TODO: Add any initialization after the InitializeComponent call
        }

        private void EditPersonPayRateForm_Load(object sender, EventArgs e)
        {
            this.Text = "录入" + type;
            
            DateTime prevMonth = DateTime.Today.AddMonths(-1);
            year.Value = prevMonth.Year;
            month.EditValue = prevMonth.Month;

            LoadData();
        }

        #region 加载数据

        protected void LoadData()
        {
            currRows = OtherMoney.GetOtherMoneyList(Convert.ToInt32(year.Value), Convert.ToInt32(month.Text));
            currRows = currRows.FindAll(a => a.类型 == type);
            //根据权限过滤
            currRows = currRows.FindAll(a => a.员工信息 != null && AccessController.CheckPayGroup(a.员工信息.薪资组));
            currRows = currRows.OrderBy(a => a.员工信息.创建时间).ToList();

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
                for (int i = 0; i < colView.RowCount; i++)
                {
                    OtherMoney currentItem = colView.GetRow(i) as OtherMoney;
                    if (currentItem != null) currentItem.Save();
                }
                MessageBox.Show("保存成功！");
                LoadData();
            }
        }
        #endregion

        #region btn添加_Click

        private void btn添加_Click(object sender, EventArgs e)
        {
            SearchEmployeeInfoForm form = new SearchEmployeeInfoForm();
            form.OnSelected += OnEmployeeSelectd;
            form.ShowDialog();
        }

        private void OnEmployeeSelectd(object sender, EmployeeInfo emp)
        {
            OtherMoney item = new OtherMoney();
            item.类型 = type;
            item.年 = Convert.ToInt32(year.Value);
            item.月 = Convert.ToInt32(month.Text);
            item.录入人 = AccessController.CurrentUser.姓名;

            item.员工编号 = emp.员工编号;
            item.姓名 = emp.姓名;
            try
            {
                item.Save();
                currRows.Add(item);
                gridControl1.RefreshDataSource();
                gridView1.FocusedRowHandle = gridView1.RowCount - 1;
            }
            catch(Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    OtherMoney currentItem = (OtherMoney)colView.GetFocusedRow();
                    currRows.Remove(currentItem);
                    currentItem.Delete();
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
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError;
        }
        #endregion

        #region gridView1_CellValueChanged

        private void gridView1_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            OtherMoney row = gridView1.GetRow(e.RowHandle) as OtherMoney;

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

        #region btn查询_Click

        private void btn查询_Click(object sender, EventArgs e)
        {
            LoadData();
        }
        #endregion

        #region gridView1_DoubleClick

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {

        }

        #endregion
    }

}

