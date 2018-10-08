using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using DevExpress.Xpo.DB;
using log4net;
using System.Data.SqlClient;
using YiKang;
using YiKang.Data;
using Hwagain.Components;
using System.Collections;
using System.Web.UI;

namespace Hwagain.SalaryCalculation.Components
{
    public partial class SalaryNode
    {
        static readonly ILog log = LogManager.GetLogger(typeof(SalaryNode));
        internal static List<SalaryNode> SalaryNodeSet = null; //所有工资等级

        #region 工资等级表

        public static List<SalaryNode> 工资等级表
        {
            get
            {
                if (SalaryNodeSet == null || SalaryNodeSet.Count == 0) ReloadSalaryNodeTree();
                return SalaryNodeSet;
            }
        }
        #endregion

        #region ReloadSalaryNodeTree

        /// <summary>
        /// 重新加载结构树
        /// </summary>
        public static void ReloadSalaryNodeTree()
        {
            SalaryNodeSet = null;
            SalaryNodeSet = SalaryNode.GetAll();
            foreach (SalaryNode org in SalaryNodeSet)
                org.Resolve();
            SalaryNodeCompareByCode comparer = new SalaryNodeCompareByCode();
            SalaryNodeSet.Sort(comparer);
        }

        class SalaryNodeCompareByCode : IComparer<SalaryNode>
        {
            #region IComparer<SalaryNode> 成员

            public int Compare(SalaryNode x, SalaryNode y)
            {
                return x.代码.CompareTo(y.代码);
            }

            #endregion
        }
        #endregion

        #region GetSalaryNode
        /// <summary>
        /// 通过 Id 获取线路
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static SalaryNode GetSalaryNode(int id)
        {
            SalaryNode obj = (SalaryNode)MyHelper.XpoSession.GetObjectByKey(typeof(SalaryNode), id);
            return obj;
        }

        public static SalaryNode GetSalaryNode(int parentId, string name)
        {
            List<SalaryNode> list = new List<SalaryNode>();

            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                       new BinaryOperator("上级", parentId, BinaryOperatorType.Equal),
                       new BinaryOperator("名称", name, BinaryOperatorType.Equal));

            XPCollection objset = new XPCollection(MyHelper.XpoSession, typeof(SalaryNode), criteria, new SortProperty("序号", SortingDirection.Ascending));

            if (objset.Count > 0)
            {
                return (SalaryNode)objset[0];
            }
            else
                return null;
        }
        /// <summary>
        /// 通过代码获取
        /// </summary>
        /// <param name="code">机构代码</param>
        /// <returns></returns>
        public static SalaryNode GetSalaryNode(string code)
        {
            List<SalaryNode> list = new List<SalaryNode>();
            
            if (code == null) code = "";

            XPCollection objset = new XPCollection(MyHelper.XpoSession, typeof(SalaryNode),
                 new BinaryOperator("代码", code, BinaryOperatorType.Equal),
                 new SortProperty("序号", SortingDirection.Ascending));

            if (objset.Count > 0)
            {
                return (SalaryNode)objset[0];
            }
            else
                return null;
        }
        /// <summary>
        /// 通过工种获取组织机构
        /// </summary>
        /// <param name="grade">薪等</param>
        /// <param name="step">薪级</param>
        /// <returns></returns>
        public static SalaryNode GetSalaryNode(string grade, string step)
        {
            return 工资等级表.Find(a => a.薪等 == grade && a.薪级 == step);
        }

        #endregion
                        
        #region GetSubSalaryNodes
        /// <summary>
        /// 获取子机构
        /// </summary>
        /// <param name="parentId">节点 Id </param>
        /// <returns></returns>
        public static List<SalaryNode> GetSubSalaryNodes(int parentId)
        {
            List<SalaryNode> list = new List<SalaryNode>();

            XPCollection objset = new XPCollection(MyHelper.XpoSession, typeof(SalaryNode),
                new BinaryOperator("上级", parentId, BinaryOperatorType.Equal),
                new SortProperty("序号", SortingDirection.Ascending));

            foreach (SalaryNode cat in objset)
            {
                list.Add(cat);
            }
            return list;
        }
        /// <summary>
        /// 获取子机构
        /// </summary>
        /// <param name="code">机构代码</param>
        /// <param name="allSon">是否所有后裔</param>
        /// <returns>子栏目的集合</returns>
        public static List<SalaryNode> GetSubSalaryNodes(string code, bool allSon)
        {
            List<SalaryNode> list = new List<SalaryNode>();
            SalaryNode parent = GetSalaryNode(code);
            if (parent != null)
            {
                BinaryOperator bo = new BinaryOperator("上级", parent.标识, BinaryOperatorType.Equal);
                if (allSon)
                {
                    if (parent.代码 == "")
                        bo = new BinaryOperator("类型", 0, BinaryOperatorType.Greater);
                    else
                        bo = new BinaryOperator("代码", code + ".%", BinaryOperatorType.Like);
                }

                XPCollection objset = new XPCollection(MyHelper.XpoSession, typeof(SalaryNode), bo, new SortProperty("序号", SortingDirection.Ascending));

                foreach (SalaryNode SalaryNode in objset)
                {
                    list.Add(SalaryNode);
                }
            }
            return list;
        }
        
        #endregion

        #region GetAll

        /// <summary>
        /// 获取所有机构
        /// </summary>
        /// <returns></returns>
        public static List<SalaryNode> GetAll()
        {
            SalaryNode root = GetSalaryNode("");
            List<SalaryNode> all = GetSubSalaryNodes("", true);
            all.Insert(0, root);
            return all;
        }

        #endregion

        #region GetName

        public static string GetName(int id)
        {
            SalaryNode node = 工资等级表.Find(a => a.标识 == id);
            return node == null ? "" : node.名称;
        }
        #endregion

        #region AddNew
        public static SalaryNode AddNew(SalaryNode parent, SalaryNode newSalaryNode)
        {
            if (newSalaryNode.标识 == 0)
            {
                if (parent == null || !parent.CheckExists()) throw new Exception("指定的父节点不存在。");
                newSalaryNode.上级 = parent.标识;
                newSalaryNode.Save();
            }
            return newSalaryNode;
        }
        #endregion

        #region CheckExists
        private bool CheckExists()
        {
            return GetSalaryNode(this.标识) != null;
        }
        #endregion
        
        #region GetNewCode

        /// <summary>
        /// 获取一个新的编码
        /// </summary>
        /// <param name="parent">父节点</param>
        /// <returns></returns>
        private string GetNewCode(SalaryNode parent)
        {
            long nextSeq = 1;
            string parentcode = ""; //默认为根
            if (parent != null) parentcode = parent.代码;
            string last = GetLastChildSalaryNodeCode(parentcode); //父栏目的最后一个子栏目的位置
            if (last == null) //如果父栏目下没有子栏目
            {
                nextSeq = 1;
                SalaryTreeNode cn = new SalaryTreeNode(parentcode, nextSeq);
                return cn.Position;
            }
            else
            {
                SalaryTreeNode cn = new SalaryTreeNode(last);
                return cn.NextSibling;
            }
        }
        #endregion

        #region GetForefathers
        //获取祖先
        private List<SalaryNode> GetForefathers()
        {
            List<SalaryNode> list = new List<SalaryNode>();
            SalaryNode parent = this.Parent;
            while (parent != null)
            {
                list.Insert(0, parent);
                parent = SalaryNode.GetSalaryNode(parent.上级);
            }
            return list;
        }
        #endregion

        #region GetFullPath
        private string GetFullPath()
        {
            string path = "";
            foreach (SalaryNode SalaryNode in this.Forefathers)
            {
                if (path != "") path = path += "\\";
                path += SalaryNode.名称;
            }
            return path;
        }
        #endregion

        #region GetLastChildSalaryNodeCode
        /// <summary>
        /// 查找最后一个孩子的代码
        /// </summary>
        /// <param name="code">代码</param>
        /// <returns>如果找到就返回 true, 否则返回 false</returns>
        public string GetLastChildSalaryNodeCode(string code)
        {
            SalaryNode parent = GetSalaryNode(code);
            if (parent != null)
            {
                List<SalaryNode> chidren = GetSubSalaryNodes(parent.标识);
                
                SalaryNodeCompareByCode comparer = new SalaryNodeCompareByCode();
                chidren.Sort(comparer);

                if (chidren.Count > 0)
                    return chidren[chidren.Count - 1].代码;
                else
                    return null;
            }
            else
                return null;
        }
        #endregion

        #region ClearEmptyData

        //整理空数据
        private void ClearEmptyData(ref string data)
        {
            if (data == null || data.Trim() == "无" || data.Trim() == "——") data = "";
            data = data.Trim();
        }
        #endregion

        #region Resolve
        /// <summary>
        /// 分解
        /// </summary>
        public void Resolve()
        {
            _薪等 = "";
            _薪级 = "";
            
            SalaryNode salaryNode = this;
            while (salaryNode != null)
            {
                switch (salaryNode.类型)
                {
                    case (int)节点类型.薪等:
                        _薪等 = salaryNode.薪等;
                        ClearEmptyData(ref _薪等);
                        break;
                    case (int)节点类型.薪级:
                        _薪级 = salaryNode.薪级;
                        ClearEmptyData(ref _薪级);
                        break;                    
                }
                salaryNode = 工资等级表.Find(org => org.标识 == salaryNode.上级);
            }
        }
        #endregion

        #region OnSaving

        protected override void OnSaving()
        {
            if (string.IsNullOrEmpty(this.名称))
            {
                throw new Exception("名称不能为空。");
            }
            SalaryNode parent = GetSalaryNode(this.上级);
            if (parent == null)
                throw new Exception("指定的父节点不存在。");
            else
            {
                //如果还没有分配位置标识
                if (string.IsNullOrEmpty(this.代码))
                {
                    this.代码 = GetNewCode(parent);
                    this.已启用 = false;
                    this.序号 = (parent.子节点.Count + 1).ToString(); //自动分配一个顺序号
                    this.类型 = parent.类型 + 1;
                    SalaryNode foundByCode = GetSalaryNode(this.代码);
                    if (foundByCode != null)
                    {
                        throw new Exception(String.Format("分配代码失败：系统中已存在同代码（{0}）的单元，请稍后再试。", this.代码));
                    }
                }
                else
                {
                    //如果移动目录
                    SalaryTreeNode cn = new SalaryTreeNode(this.代码);
                    if (cn.ParentNodePosition != parent.代码)
                    {
                        throw new Exception("节点的位置不能改变。");
                    }
                }
            }
            SalaryNode found = GetSalaryNode(this.上级, this.名称);
            if (found != null && found.标识 != this.标识)
            {
                throw new Exception("在同一个层中不能重复创建同名的节点单元。");
            }
            if (this.类型 == (int)节点类型.薪等)
            {
                if(this.Parent == null || this.Parent.代码 != "")
                    throw new Exception("薪等类型的机构，只能从属于根节点。");
            }
            base.OnSaving();
        }
        #endregion

        #region OnSaved

        protected override void OnSaved()
        {
            base.OnSaved();
            SalaryNodeSet = null;
        }
        #endregion

        #region OnDeleting

        protected override void OnDeleting()
        {
            if (this.类型 > 0 && this.已启用 == false)
            {
                List<SalaryNode> children = GetSubSalaryNodes(this.标识);
                if(children.Count == 0)
                    base.OnDeleting();
                else
                    throw new Exception("删除失败：该节点还有子节点。");
            }
            else
                throw new Exception("不能删除根节点、已关联的节点。");
        }
        #endregion

        #region 子节点
        //子类
        [NonPersistent]
        public List<SalaryNode> 子节点
        {
            get
            {
                return GetSubSalaryNodes(this.标识);
            }
        }
        #endregion

        #region 父节点
        //子类
        [NonPersistent]
        public SalaryNode 父节点
        {
            get
            {
                return GetSalaryNode(this.上级);
            }
        }
        #endregion

        #region 父代码

        public string 父代码
        {
            get
            {
                SalaryTreeNode cn = new SalaryTreeNode(this.代码);
                return cn.ParentNodePosition;
            }
        }
        #endregion

        #region Parent

        public SalaryNode Parent
        {
            get
            {
                return GetSalaryNode(this.父代码);
            }
        }
        #endregion

        #region Forefathers
        List<SalaryNode> _Forefathers = null;
        public List<SalaryNode> Forefathers
        {
            get
            {
                if (_Forefathers == null) _Forefathers = GetForefathers();
                return _Forefathers;
            }
        }
        #endregion

        #region ToString

        public override string ToString()
        {
            return GetFullPath();
        }
        
        #endregion

        #region 薪等

        private string _薪等 = null;
        public string 薪等
        {
            get
            {
                if (_薪等 == null) Resolve();
                return _薪等;
            }
        }
        #endregion

        #region 薪级

        private string _薪级;
        public string 薪级
        {
            get
            {
                if (_薪级 == null) Resolve();
                return _薪级;
            }
        }
        #endregion

        #region 当前执行标准

        StepPayRate stepPayRate = null;
        public StepPayRate 当前执行标准
        {
            get
            {
                if (this.类型 == (int)节点类型.薪级 && stepPayRate == null)
                {
                    stepPayRate = StepPayRate.GetEffective(this.标识, DateTime.Today);
                }
                return stepPayRate;
            }
        }

        public string 当前标准
        {
            get
            {
                if (当前执行标准 != null)
                {
                    if (AccessController.CheckGrade(this.上级))
                        return 当前执行标准.工资额.ToString("c");
                    else
                        return "******";
                }
                else
                    return "";
            }
        }
        #endregion

        #region 当前标准开始执行日期

        public DateTime 当前标准开始执行日期
        {
            get
            {
                if (当前执行标准 != null)
                {
                    return 当前执行标准.执行日期;
                }
                else
                    return DateTime.MinValue;
            }
        }
        #endregion                
    }
}
