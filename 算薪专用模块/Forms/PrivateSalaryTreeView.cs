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
    public partial class PrivateSalaryTreeView : DevExpress.XtraEditors.XtraForm
    {
        TreeListNode currNode = null;
        List<SalaryNode> nodes = new List<SalaryNode>();

        public PrivateSalaryTreeView()
        {
            InitializeComponent();
        }

        private void PrivateSalaryTreeView_Load(object sender, EventArgs e)
        {
            nodes = SalaryNode.GetAll().FindAll(a => a.已撤销 == false);

            treeList1.DataSource = nodes;
            treeList1.ExpandAll();
        }

        private void treeList1_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            currNode = e.Node;
            SalaryNode salaryNode = treeList1.GetDataRecordByNode(currNode) as SalaryNode;
            treeList1.OptionsBehavior.Editable = salaryNode != null && salaryNode.代码 != "";
        }

        private void treeList1_AfterFocusNode(object sender, DevExpress.XtraTreeList.NodeEventArgs e)
        {
            
        }

        private void btn另存为_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = "职级工资标准表.xls";
            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string filename = saveFileDialog1.FileName;
                treeList1.ExportToXls(filename);
            }
        }
    }
}