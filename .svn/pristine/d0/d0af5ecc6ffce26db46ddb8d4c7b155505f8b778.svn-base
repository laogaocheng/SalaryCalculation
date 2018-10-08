using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using YiKang.RBACS.DataObjects;
using DevExpress.XtraGrid.Views.Base;
using Hwagain.Components;
using Hwagain.SalaryCalculation.Components;
using YiKang;
using DevExpress.XtraEditors;
using DevExpress.Utils;
using DevExpress.XtraEditors.Controls;


namespace Hwagain.SalaryCalculation
{
    public partial class SearchEmployeeInfoForm : XtraForm
    {
        public delegate void SelectEmployeeHandle(object sender, EmployeeInfo employee);
        public event SelectEmployeeHandle OnSelected;
        static bool singleOne = false;

        public SearchEmployeeInfoForm()
        {
            // This call is required by the Windows Form Designer.
            InitializeComponent();
            chk选择后自动关闭窗口.Checked = singleOne;
            // TODO: Add any initialization after the InitializeComponent call
        }

        private void SearchEmployeeInfoForm_Load(object sender, EventArgs e)
        {
            cb薪资组.Properties.Items.Clear();
            foreach (PayGroup rpg in AccessController.我管理的薪资组)
            {
                PayGroup pg = PayGroup.Get(rpg.英文名);
                if (pg != null)
                {
                    ImageComboBoxItem item = new ImageComboBoxItem(pg.中文名, rpg.英文名);
                    cb薪资组.Properties.Items.Add(item);
                }
            }
            ImageComboBoxItem all = new ImageComboBoxItem("所有薪资组", "");
            cb薪资组.Properties.Items.Add(all);
            cb薪资组.SelectedItem = all;
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

        private void btn查询_Click(object sender, EventArgs e)
        {
            if (!YiKang.Common.IsIncludeInvalidChars(searchKey.Text.Trim(), "-'\"/><=!"))
                Search();
            else
                MessageBox.Show("输入的条件中不能包含无效的字符");
        }


        void Search()
        {
            CreateWaitDialog("正在查询....", "请稍等");

            string group = cb薪资组.EditValue as string;
            List<EmployeeInfo> list = new List<EmployeeInfo>();
            List<EmployeeInfo> employeeInfoSearch = EmployeeInfo.Search(searchKey.Text.Trim(), chk仅显示在职员工.Checked);
            
            if (string.IsNullOrEmpty(group) == false) employeeInfoSearch = employeeInfoSearch.FindAll(a => a.薪资组 == group || a.上个月薪资组 == group);
            foreach (EmployeeInfo emp in employeeInfoSearch)
            {
                if (AccessController.CheckPayGroup(emp.薪资组) || AccessController.CheckPayGroup(emp.上个月薪资组))
                {
                    list.Add(emp);
                }
            }
            list = list.OrderBy(a => a.员工序号).ToList();
            gridControl1.DataSource = list;
            gridView1.ExpandAllGroups();

            CloseWaitDialog();
        }

        #region gridView1_DoubleClick

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            if (OnSelected != null)
            {
                EmployeeInfo currentItem = (EmployeeInfo)gridView1.GetFocusedRow();
                if (currentItem != null) OnSelected(sender, currentItem);
            }
            if (chk选择后自动关闭窗口.Checked) this.Close();
        }
        #endregion

        #region searchKey_KeyUp

        private void searchKey_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Search();
        }
        #endregion

        private void searchKey_EditValueChanged(object sender, EventArgs e)
        {

        }

        #region btn同步员工信息_Click

        private void btn同步员工信息_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("同步需要几分钟甚至更长，过程中请不可进行其他操作，确实要立即同步吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2, 0, false) == DialogResult.Yes)
            {
                CreateWaitDialog("正在同步薪酬体系....", "请稍等");
                SalaryPlan.SychSalaryPlan();

                CreateWaitDialog("正在同步薪等....", "请稍等");
                SalaryGrade.SychSalaryGrade();

                CreateWaitDialog("正在同步薪级....", "请稍等");
                SalaryStep.SychSalaryStep();

                CreateWaitDialog("正在同步员工基本信息....", "请耐心等待");
                EmployeeInfo.SychEmployeeInfo();

                CloseWaitDialog();
            }
        }
        #endregion

        #region 单选

        public bool 单选
        {
            set
            {
                singleOne = value;
                chk选择后自动关闭窗口.Checked = value;
            }
        }
        #endregion

        #region chk选择后自动关闭窗口_CheckedChanged

        private void chk选择后自动关闭窗口_CheckedChanged(object sender, EventArgs e)
        {
            singleOne = chk选择后自动关闭窗口.Checked;
        }
        #endregion
    }

}

