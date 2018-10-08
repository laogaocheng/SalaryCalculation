using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Hwagain.SalaryCalculation.Components;
using DevExpress.XtraTreeList.Nodes;

namespace Hwagain.SalaryCalculation
{
    public partial class SalaryTreeForm : DevExpress.XtraEditors.XtraForm
    {
        TreeListNode currNode = null;
        List<SalaryNode> nodes = new List<SalaryNode>();

        public SalaryTreeForm()
        {
            InitializeComponent();
        }

        private void SalaryTreeForm_Load(object sender, EventArgs e)
        {
            nodes = SalaryNode.GetAll();
            treeList1.DataSource = nodes;
            treeList1.ExpandAll();
        }

        private void treeList1_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            currNode = e.Node;
            SalaryNode salaryNode = treeList1.GetDataRecordByNode(currNode) as SalaryNode;
            treeList1.OptionsBehavior.Editable = salaryNode != null && salaryNode.代码 != "" && salaryNode.已撤销 == false;
            SetButtonEnabled();
        }

        #region SetButtonEnabled

        void SetButtonEnabled()
        {
            btnAdd.Enabled = false;
            btnDelete.Enabled = false;
            btn撤销.Enabled = false;
            btn重新启用.Enabled = false;

            if (currNode != null)
            {
                SalaryNode salaryNode = treeList1.GetDataRecordByNode(currNode) as SalaryNode;
                if (salaryNode != null)
                {
                    btnAdd.Enabled = salaryNode.已撤销 == false && salaryNode.类型 != (int)节点类型.薪级;
                    if (salaryNode.代码 != "")
                    {
                        btnDelete.Enabled = salaryNode.已撤销 == false;
                        btn撤销.Enabled = salaryNode.已撤销 == false;
                        btn重新启用.Enabled = salaryNode.已撤销;
                    }
                }
            }
        }
        #endregion

        #region btnDelete_Click

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (currNode != null)
            {
                if (MessageBox.Show("确实删除当前节点吗？", "删除提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2, 0, false) == DialogResult.Yes)
                {
                    SalaryNode salaryNode = treeList1.GetDataRecordByNode(currNode) as SalaryNode;
                    if (salaryNode != null)
                    {
                        if (salaryNode.代码 == "" || salaryNode.已启用 || salaryNode.子节点.Count > 0)
                        {
                            MessageBox.Show("删除失败：根节点、已关联或者有子节点的节点！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2, 0, false);
                        }
                        else
                        {
                            treeList1.DeleteNode(currNode);
                            salaryNode.Delete();
                            MessageBox.Show("删除成功！", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, 0, false);
                        }
                    }
                }
            }
        }
        #endregion

        #region btnAdd_Click

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (text节点名称.Text.Trim() == "")
                MessageBox.Show("请输入节点的名称后再试");
            else
            {
                if (currNode == null)
                    MessageBox.Show("请选择一个节点");
                else
                {
                    SalaryNode parent = treeList1.GetDataRecordByNode(currNode) as SalaryNode;
                    if (parent != null)
                    {
                        if (parent.类型 == (int)节点类型.薪级)
                        {
                            MessageBox.Show("错误：薪级不能创建子节点");
                        }
                        else
                        {
                            SalaryNode newNode = new SalaryNode();
                            newNode.名称 = text节点名称.Text;
                            newNode.上级 = parent.标识;
                            newNode.Save();

                            nodes.Add(newNode);
                            treeList1.RefreshDataSource();
                            treeList1.Refresh();
                            treeList1.ExpandAll();
                            treeList1.SetFocusedNode(currNode);

                            text节点名称.Text = "";
                        }
                    }
                }
            }
        }
        #endregion

        private void treeList1_AfterFocusNode(object sender, DevExpress.XtraTreeList.NodeEventArgs e)
        {
            
        }

        #region btn撤销_Click

        private void btn撤销_Click(object sender, EventArgs e)
        {
            if (currNode != null)
            {
                if (MessageBox.Show("确实要撤销当前节点吗？", "撤销提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2, 0, false) == DialogResult.Yes)
                {
                    SalaryNode salaryNode = treeList1.GetDataRecordByNode(currNode) as SalaryNode;
                    if (salaryNode != null)
                    {
                        if (salaryNode.代码 == "")
                        {
                            MessageBox.Show("撤销失败：不能撤销根节点！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2, 0, false);
                        }
                        else
                        {
                            salaryNode.已撤销 = true;
                            salaryNode.Save();

                            foreach (SalaryNode child in salaryNode.子节点)
                            {
                                child.已撤销 = true;
                                child.Save();
                            }

                            MessageBox.Show("撤销成功！", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, 0, false);
                        }
                    }
                }
            }
        }
        #endregion

        #region btn重新启用_Click

        private void btn重新启用_Click(object sender, EventArgs e)
        {
            if (currNode != null)
            {
                SalaryNode salaryNode = treeList1.GetDataRecordByNode(currNode) as SalaryNode;
                if (salaryNode != null)
                {
                    salaryNode.已撤销 = false;
                    salaryNode.Save();

                    if (salaryNode.类型 == (int)节点类型.薪级)
                    {
                        SalaryNode parent = salaryNode.父节点;
                        if (parent != null)
                        {
                            parent.已撤销 = false;
                            parent.Save();
                        }
                    }

                    if (salaryNode.类型 == (int)节点类型.薪等)
                    {
                        foreach (SalaryNode child in salaryNode.子节点)
                        {
                            child.已撤销 = false;
                            child.Save();
                        }
                    }

                    MessageBox.Show("启用成功！", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, 0, false);
                }
            }
        }
        #endregion
    }
}