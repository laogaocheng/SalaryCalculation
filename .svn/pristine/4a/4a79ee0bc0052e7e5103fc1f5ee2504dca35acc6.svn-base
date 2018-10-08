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
using DevExpress.XtraEditors;
using DevExpress.Utils;
using DevExpress.XtraEditors.Controls;


namespace Hwagain.SalaryCalculation
{
    public partial class QueryEmployeePayInfoForm : XtraForm
    {
        List<EmployeePayData> list = new List<EmployeePayData>();

        public QueryEmployeePayInfoForm()
        {
            // This call is required by the Windows Form Designer.
            InitializeComponent();
            // TODO: Add any initialization after the InitializeComponent call
        }

        #region QueryEmployeePayInfoForm_Load

        private void QueryEmployeePayInfoForm_Load(object sender, EventArgs e)
        {
            DeptInfo root = DeptInfo.组织机构表.Find(a => a.部门层级 == 10);
            TreeNode rootNode = new TreeNode() { Text = "华劲集团", Tag = root };
            InitNodes(rootNode, DeptInfo.组织机构表);

            treeView1.Nodes.Clear();
            treeView1.Nodes.Add(rootNode);            
            treeView1.SelectedNode = rootNode;
            rootNode.Expand();
            
            LoadData();
        }
        #endregion

        #region InitNodes

        void InitNodes(TreeNode node)
        {
            DeptInfo parent = node.Tag as DeptInfo;
            if (parent != null)
            {
                List<DeptInfo> categories = DeptInfo.组织机构表.FindAll(cat => cat.上级编号 == parent.部门编号);
                foreach (DeptInfo dept in categories)
                {
                    TreeNode childNode = new TreeNode() { Text = dept.部门名称, Tag = dept };
                    InitNodes(childNode);
                    node.Nodes.Add(childNode);

                    if (dept.部门层级 <= 25) node.Expand();
                }
            }
        }

        void InitNodes(TreeNode node, List<DeptInfo> all)
        {
            DeptInfo dept = node.Tag as DeptInfo;
            if (dept != null)
            {
                List<DeptInfo> deptList = all.FindAll(cat => cat.上级编号 == dept.部门编号);
                foreach (DeptInfo item in deptList)
                {
                    TreeNode childNode = new TreeNode() { Text = item.部门名称, Tag = item };
                    InitNodes(childNode);
                    node.Nodes.Add(childNode);
                }
            }
        }
        #endregion

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

        #region btn查询_Click

        private void btn查询_Click(object sender, EventArgs e)
        {
            if (!YiKang.Common.IsIncludeInvalidChars(searchKey.Text.Trim(), "-'\"/><=!"))
            {
                LoadData();
                BindData();
            }
            else
                MessageBox.Show("输入的条件中不能包含无效的字符");
        }
        #endregion

        #region LoadData

        void LoadData()
        {            
            list.Clear();

            List<EmployeeInfo> employeeInfoSearch = EmployeeInfo.Search(null);
            foreach (EmployeeInfo emp in employeeInfoSearch)
            {
                if (AccessController.CheckPayGroup(emp.薪资组))
                {
                    list.Add(new EmployeePayData(emp, DateTime.Today, true));
                }
            }
            list = list.OrderBy(a => a.员工序号).ToList();
        }
        #endregion

        #region BindData

        void BindData()
        {
            CreateWaitDialog("正在查询....", "请稍等");

            List<EmployeePayData> dataList = new List<EmployeePayData>(list);

            //如果输入的不是姓名只显示当前机构下员工
            if (searchKey.Text.Trim().Length == 0)
            {
                if (treeView1.SelectedNode != null)
                {
                    DeptInfo dept = treeView1.SelectedNode.Tag as DeptInfo;
                    dataList = dataList.FindAll(a => a.员工信息.部门 == dept.部门编号 || chk包括下属机构.Checked && dept.IsDescendant(a.所属部门));
                }
            }
            else
            {
                //不支持模糊查找，按姓名查询是和部门无关
                dataList = dataList.FindAll(a => a.姓名 == searchKey.Text.Trim());
            }

            gridControl1.DataSource = dataList;
            gridView1.ExpandAllGroups();

            CloseWaitDialog();
        }
        #endregion

        #region gridView1_DoubleClick

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            
        }
        #endregion

        #region searchKey_KeyUp

        private void searchKey_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoadData();
                BindData();
            }
        }
        #endregion

        #region chk选中部门后自动显示名单_CheckedChanged

        private void chk选中部门后自动显示名单_CheckedChanged(object sender, EventArgs e)
        {
            if (chk选中部门后自动显示名单.Checked)
                BindData();
            else
            { //清空
                ClearGridData();
            }
        }
        #endregion

        #region treeView1_AfterSelect

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            searchKey.Text = "";
            if (chk选中部门后自动显示名单.Checked)
                BindData();
            else
            { //清空
                ClearGridData();
            }
        }

        private void ClearGridData()
        {
            gridControl1.DataSource = null;
            gridControl1.RefreshDataSource();
            gridControl1.Refresh();
        }
        #endregion

    }

}

