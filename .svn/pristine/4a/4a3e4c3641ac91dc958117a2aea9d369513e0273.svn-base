using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;

namespace Hwagain.SalaryCalculation.Components
{
    public class DeptInfo
    {
        public string 公司编码 { get; set; }
        public string 部门编号 { get; set; }
        public string 上级编号 { get; set; }
        public string 部门名称 { get; set; }
        public int 部门层级 { get; set; }
        public int 部门序号 { get; set; }
        public DateTime 生效日期 { get; set; }
        public bool 有效 { get; set; }

        public string 本部 { get; set; }
        public string 体系 { get; set; }
        public DeptInfo 公司 { get; set; }
        public DeptInfo 部门 { get; set; }
        public DeptInfo 工厂 { get; set; }
        public DeptInfo 车间 { get; set; }
        public DeptInfo 班 { get; set; }
        public DeptInfo 组 { get; set; }
        public DeptInfo 区域 { get; set; }
        public DeptInfo 城市 { get; set; }
        public DeptInfo 省办 { get; set; }

        #region Resolve
        /// <summary>
        /// 分解
        /// </summary>
        public void Resolve()
        {
            公司 = null;
            部门 = null;
            区域 = null;
            城市 = null;
            省办 = null;

            车间 = null;
            工厂 = null;
            班 = null;
            组 = null;

            DeptInfo deptInfo = this;
            while (deptInfo != null)
            {
                switch (deptInfo.部门层级)
                {
                    case 15:
                        公司 = deptInfo;
                        break;
                    case 20:
                        部门 = deptInfo;
                        break;
                    case 25:
                        车间 = deptInfo;
                        break;
                    case 30:
                        班 = deptInfo;
                        break;
                    case 35:
                        组 = deptInfo;
                        break;
                    case 40:
                        省办 = deptInfo;
                        break;
                    case 45:
                        区域 = deptInfo;
                        break;
                    case 50:
                        城市 = deptInfo;
                        break;
                    case 60:
                        工厂 = deptInfo;
                        break;
                }
                deptInfo = DeptInfo.组织机构表.Find(org => org.部门编号 == deptInfo.上级编号);
            }

            if (部门 == null)
            {
                if (省办 != null) 部门 = 省办;
                if (工厂 != null) 部门 = 工厂;
            }
        }
        
        #endregion

        #region 组织机构表

        static List<DeptInfo> deptList = null;

        public static List<DeptInfo> 组织机构表
        {
            get
            {
                if (deptList == null)
                {
                    deptList = GetAll();
                    foreach (DeptInfo dept in deptList)
                        dept.Resolve();
                }
                return deptList;
            }
        }
        #endregion
       
        #region GetAll

        //获取值列表
        public static List<DeptInfo> GetAll()
        {
            List<DeptInfo> list = new List<DeptInfo>();
            OleDbConnection conn = new OleDbConnection(MyHelper.GetPsConnectionString());
            using (conn)
            {
                OleDbDataReader rs = null;
                try
                {
                    conn.Open();
                    using (OleDbCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "SELECT COMPANY, DEPTID , PARENT_NODE_NAME , DESCRSHORT , EFFDT , C_DEPT_LEVEL, EFF_STATUS, C_DEPT_ORDER FROM PS_C_DEPT_TBL_VW";
                        rs = cmd.ExecuteReader();
                        while (rs.Read())
                        {
                            DeptInfo dpt = new DeptInfo();
                            
                            dpt.公司编码 = ((string)rs["COMPANY"]).Trim();
                            dpt.部门编号 = ((string)rs["DEPTID"]).Trim();
                            dpt.上级编号 = ((string)rs["PARENT_NODE_NAME"]).Trim();
                            dpt.部门名称 = ((string)rs["DESCRSHORT"]).Trim();
                            if (rs["C_DEPT_LEVEL"] != DBNull.Value && YiKang.Common.IsInteger(Convert.ToString(rs["C_DEPT_LEVEL"])))
                                dpt.部门层级 = Convert.ToInt32(rs["C_DEPT_LEVEL"]);
                            dpt.生效日期 = Convert.ToDateTime(rs["EFFDT"]);
                            dpt.有效 = (string)rs["EFF_STATUS"] == "A";
                            dpt.部门序号 = Convert.ToInt32(rs["C_DEPT_ORDER"]);

                            list.Add(dpt);

                        }
                        rs.Close();
                    }
                }
                finally
                {
                    if (rs != null) rs.Close();
                    conn.Close();
                }
            }
            return list;
        }
        #endregion

        #region Get

        public static DeptInfo Get(string deptId)
        {
            if (deptId == null) return null;

            DeptInfo dept = 组织机构表.Find(a => a.部门编号 == deptId.Trim());
            if (dept != null)
            {
                dept.Resolve();
                if (dept.部门体系 != null)
                {
                    dept.体系 = dept.部门体系.体系;
                    dept.本部 = dept.部门体系.本部;
                }
            }
            return dept;
        }
        #endregion

        #region IsAncestor

        //检查指定的部门是否是祖先
        public bool IsAncestor(string deptCode)
        {
            foreach (DeptInfo d in this.GetAncestors())
            {
                if (d.部门编号 == deptCode) return true;
            }
            return false;
        }

        #endregion

        #region IsDescendant

        //检查指定的部门是否是子孙
        public bool IsDescendant(DeptInfo dept)
        {
            if (dept == null) return false;
            return dept.IsAncestor(部门编号);
        }

        #endregion

        #region GetAncestors

        /// <summary>
        /// 获取所有上级部门
        /// </summary>
        /// <returns></returns>
        public List<DeptInfo> GetAncestors()
        {
            DeptInfo parent = this.Parent;
            List<DeptInfo> list = new List<DeptInfo>();
            while (parent != null)
            {
                list.Add(parent);
                parent = parent.Parent;
            }
            return list;
        }
        #endregion

        #region GetDescendants

        /// <summary>
        /// 获取所有下属部门
        /// </summary>
        /// <returns></returns>
        public List<DeptInfo> GetDescendants()
        {
            DeptInfo parent = this.Parent;
            List<DeptInfo> list =new List<DeptInfo>();
            GetDescendants(this, ref list);
            return list;
        }

        public void GetDescendants(DeptInfo dept, ref List<DeptInfo> all)
        {
            List<DeptInfo> list = 组织机构表.FindAll(a => a.Parent == dept);
            all.AddRange(list);
            foreach (DeptInfo child in list)
            {
                GetDescendants(child, ref all);
            }
        }

        #endregion

        #region Parent

        public DeptInfo Parent
        {
            get
            {
                if (this.上级编号 == "")
                    return null;
                else
                    return 组织机构表.Find(a => a.部门编号 == this.上级编号.Trim());
            }
        }
        #endregion

        #region 所属公司

        public DeptInfo 所属公司
        {
            get
            {
                return this.GetAncestors().Find(a => a.部门层级 == 15);
            }
        }
        #endregion

        #region 所在部门

        public DeptInfo 所在部门
        {
            get
            {
                if (this.部门层级 == 20)
                    return this;
                else
                {
                    DeptInfo dept = this.GetAncestors().Find(a => a.部门层级 == 20);
                    if (dept == null) dept = this.省办;
                    return dept;
                }
            }
        }
        #endregion

        #region 部门体系

        DeptSystem deptSys = null;
        public DeptSystem 部门体系
        {
            get
            {
                if (deptSys == null && 部门 != null) deptSys = DeptSystem.GetDeptSystem(部门.部门编号);
                return deptSys;
            }
        }
        #endregion

        #region 职能类型
        
        string funType = null;
        public string 职能类型
        {
            get
            {
                if (funType == null)
                {
                    DeptFunctionType deptType = DeptFunctionType.Get(this.部门编号);
                    funType = deptType != null ? deptType.类型名称 : "";
                }
                return funType;
            }
        }

        #endregion

        public override string ToString()
        {
            return this.部门名称;
        }
    }
}
