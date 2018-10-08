using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YiKang;

namespace Hwagain.SalaryCalculation.Components
{
    public class SalaryTreeNode : TreeNode
    {
        public static readonly long MAX = 999;
        public SalaryTreeNode() : base(MAX) { }
        public SalaryTreeNode(string position) : base(position, MAX) { }
        public SalaryTreeNode(string parentPosition, long seq) : base(parentPosition, seq, MAX) { }
    }
}
