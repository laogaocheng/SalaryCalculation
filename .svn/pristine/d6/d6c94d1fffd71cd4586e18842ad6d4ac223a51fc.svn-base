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
    public partial class EmpPayRateForm : XtraForm
    {
        protected List<EmpPayRate> currRows = new List<EmpPayRate>();
        protected EmpPayRate currEmpPayRate = null;//当前记录

        public EmpPayRateForm()
        {
            // This call is required by the Windows Form Designer.
            InitializeComponent();

            // TODO: Add any initialization after the InitializeComponent call
        }

        private void EditEmpPayRateForm_Load(object sender, EventArgs e)
        {
            DateTime prevMonth = DateTime.Today.AddMonths(-1);
            year.Value = prevMonth.Year;
            month.EditValue = prevMonth.Month.ToString();

            LoadData();
        }

        #region 加载数据

        protected void LoadData()
        {
            currRows = EmpPayRate.GetEmpPayRateList(Convert.ToInt32(year.Value), Convert.ToInt32(month.Text));
            //根据权限过滤
            currRows = currRows.FindAll(a => a.员工信息 != null && AccessController.CheckPayGroup(a.员工信息.薪资组));
            currRows = currRows.OrderBy(a => a.员工信息.员工序号).ToList();

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
                EmpPayRate currentItem = (EmpPayRate)colView.GetFocusedRow();
                if (currentItem != null) currentItem.Save();
                MessageBox.Show("保存成功！");
                LoadData();
            }

            MyHelper.WriteLog(LogType.信息, "修改工资系数记录", null);

        }
        #endregion

        #region btn添加_Click

        private void btn添加_Click(object sender, EventArgs e)
        {
            if (!YiKang.Common.IsNumber(year.Text) || !YiKang.Common.IsNumber(month.Text))
            {
                MessageBox.Show("必须输入所属年月。");
                return;
            }                
            SearchEmployeeInfoForm form = new SearchEmployeeInfoForm();
            form.OnSelected += OnEmployeeSelectd;
            form.ShowDialog();
        }
        private void OnEmployeeSelectd(object sender, EmployeeInfo emp)
        {
            AddItem(emp, Convert.ToInt32(year.Value), Convert.ToInt32(month.Text));
        }

        #region AddItem

        private void AddItem(EmployeeInfo emp, int year, int month)
        {
            EmpPayRate item = EmpPayRate.GetEmpPayRate(emp.员工编号, year, month);
            if (item == null)
            {
                item = new EmpPayRate();
                item.年 = year;
                item.月 = month;
                item.员工编号 = emp.员工编号;
                item.姓名 = emp.姓名;
                item.系数 = 1;
            }
            item.录入人 = AccessController.CurrentUser.姓名;
            item.录入时间 = DateTime.Now;
            currRows.Add(item);
            gridControl1.RefreshDataSource();
            gridView1.FocusedRowHandle = gridView1.RowCount - 1;

            MyHelper.WriteLog(LogType.信息, "新增工资系数", item.ToString<EmpPayRate>());
        }
        #endregion

        #endregion

        #region btn删除_Click

        private void btn删除_Click(object sender, EventArgs e)
        {
            ColumnView colView = (ColumnView)gridControl1.MainView;
            if (colView != null)
            {
                if (MessageBox.Show("确实删除当前记录吗？", "删除提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2, 0, false) == DialogResult.Yes)
                {
                    EmpPayRate currentItem = (EmpPayRate)colView.GetFocusedRow();
                    currRows.Remove(currentItem);
                    currentItem.Delete();
                    gridControl1.RefreshDataSource();

                    MyHelper.WriteLog(LogType.信息, "删除工资系数记录", currentItem.ToString<EmpPayRate>());

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
            EmpPayRate row = gridView1.GetRow(e.RowHandle) as EmpPayRate;

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

