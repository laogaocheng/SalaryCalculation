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


namespace Hwagain.SalaryCalculation
{
    public partial class EmployeeSalaryStepList : XtraForm
    {
        public EmployeeSalaryStepList()
        {
            // This call is required by the Windows Form Designer.
            InitializeComponent();

            // TODO: Add any initialization after the InitializeComponent call
        }

        #region EditEmployeeSalaryStepForm_Load

        private void EditEmployeeSalaryStepForm_Load(object sender, EventArgs e)
        {
            this.Text = "员工工资职级";

            List<SalaryNode> allGrade = SalaryNode.工资等级表.FindAll(a => a.类型 == (int)节点类型.薪等);
            foreach (SalaryNode grade in allGrade)
            {
                ImageComboBoxItem item = new ImageComboBoxItem();
                item.Description = grade.名称;
                item.Value = grade.标识;
                repositoryItemImageComboBox1.Items.Add(item);
            }
            LoadData();
            btn设置截止日期.Enabled = AccessController.CheckEmployeeSalaryStepInput();
        }
        #endregion

        #region 加载数据

        protected void LoadData()
        {
            LoadData(null);
        }

        protected void LoadData(string key)
        {
            List<EmpSalaryStep> list = EmpSalaryStep.GetAll();
            //根据权限过滤
            list = list.FindAll(a => AccessController.CheckPayGroup(a.薪资组) && AccessController.CheckGrade(a.薪等标识));
            list = list.OrderBy(a => a.员工信息.员工序号).ToList();
            if (string.IsNullOrEmpty(key) == false) list = list.FindAll(a => a.姓名.Contains(key));
            //如果不显示历史记录
            if (chk显示历史记录.Checked == false)
            {
                List<EmpSalaryStep> tempList = new List<EmpSalaryStep>();
                foreach (EmpSalaryStep item in list)
                {
                    EmpSalaryStep effectiveItem = EmpSalaryStep.GetEffective(item.员工编号, DateTime.Today);
                    if (effectiveItem != null && effectiveItem.标识 == item.标识) tempList.Add(item);
                }
                list = tempList;
            }
            gridControl1.DataSource = list;
            gridControl1.RefreshDataSource();
            gridView1.ExpandAllGroups();
        }        

        #endregion       

        #region btn查询_Click

        private void btn查询_Click(object sender, EventArgs e)
        {
            LoadData(searchKey.Text);
        }
        #endregion

        #region btn刷新_Click

        private void btn刷新_Click(object sender, EventArgs e)
        {
            LoadData(searchKey.Text);
        }
        #endregion

        #region searchKey_KeyUp

        private void searchKey_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                LoadData(searchKey.Text);
        }
        #endregion

        #region btn导出_Click

        private void btn导出_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = "员工工资职级明细";
            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string filename = saveFileDialog1.FileName;
                gridView1.ExportToXls(filename);
            }
        }
        #endregion

        #region btn设置截止日期_Click

        private void btn设置截止日期_Click(object sender, EventArgs e)
        {
            ColumnView colView = (ColumnView)gridControl1.MainView;
            if (colView != null)
            {
                EmpSalaryStep currEmpSalaryStep = (EmpSalaryStep)colView.GetFocusedRow();
                if (currEmpSalaryStep != null)
                {
                    if (dateEdit1.DateTime != DateTime.MinValue && (dateEdit1.DateTime < MyHelper.GetPrevMonth1Day().AddMonths(-1) || dateEdit1.DateTime < currEmpSalaryStep.执行日期))
                    {
                        MessageBox.Show("错误：截止日期不能小于执行日期或上上月1号。");
                    }
                    else
                    {
                        EmpSalaryStep latestItem = EmpSalaryStep.GetLatest(currEmpSalaryStep.员工编号);
                        if (currEmpSalaryStep.标识 != latestItem.标识)
                        {
                            MessageBox.Show("错误：只能设置最后录入的那条记录。");
                        }
                        else
                        {
                            string s = String.Format("设置为【{0:yyyy-M-d}】", dateEdit1.DateTime);
                            if (dateEdit1.DateTime == DateTime.MinValue) s = "清除";
                            if (MessageBox.Show(String.Format("确实将【{0}】当前职级的截止日期" + s + "吗？", currEmpSalaryStep.姓名), "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2, 0, false) == DialogResult.Yes)
                            {
                                currEmpSalaryStep.截止日期 = dateEdit1.DateTime;
                                currEmpSalaryStep.Save();

                                MessageBox.Show(String.Format("已将【{0}】当前职级的截止日期" + s + "。", currEmpSalaryStep.姓名), "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LoadData();
                            }
                        }
                    }
                }
                else
                    MessageBox.Show("错误：没有选中的记录。");
            }
        }
        #endregion
    }

}

