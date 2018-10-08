using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using DevExpress.Xpo.DB;
using log4net;

namespace Hwagain.SalaryCalculation.Components
{
    public partial class DeptIndex
    {
        static readonly ILog log = LogManager.GetLogger(typeof(DeptIndex));

        #region GetDeptIndex

        public static DeptIndex GetDeptIndex(string code)
        {
            XPCollection objset = new XPCollection(typeof(DeptIndex),
                 new BinaryOperator("部门编号", code, BinaryOperatorType.Equal),
                 new SortProperty("序号", SortingDirection.Ascending));

            if (objset.Count > 0)
            {
                return (DeptIndex)objset[0];
            }
            else
                return null;
        }
        #endregion

        #region GetAll

        public static List<DeptIndex> GetAll(string company)
        {
            List<DeptIndex> list = new List<DeptIndex>();

            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                       new BinaryOperator("公司名称", company, BinaryOperatorType.Equal));

            if (string.IsNullOrEmpty(company)) criteria = null;

            XPCollection objset = new XPCollection(typeof(DeptIndex), criteria, new SortProperty("公司名称", SortingDirection.Ascending), new SortProperty("序号", SortingDirection.Ascending));

            foreach (DeptIndex item in objset)
            {
                list.Add(item);
            }
            return list;
        }
        #endregion

        #region AddDept

        public static DeptIndex AddDept(string deptCode, string company, int idx)
        {
            DeptIndex item = GetDeptIndex(deptCode);
            if (item == null)
            {
                item = new DeptIndex();
                item.部门编号 = deptCode;
                item.公司名称 = company;
            }
            item.序号 = idx;
            item.Save();
            return item;
        }
        #endregion

        #region OnSaving

        protected override void OnSaving()
        {
            base.OnSaving();
        }
        #endregion

        #region 部门信息

        DeptInfo deptInfo = null;
        public DeptInfo 部门信息
        {
            get
            {
                if (deptInfo == null) deptInfo = DeptInfo.Get(this.部门编号);
                return deptInfo;
            }
        }

        #endregion

        [NonPersistent]
        public string 部门名称
        {
            get
            {
                if (部门信息 == null)
                    return "";
                else
                    return 部门信息.部门名称;
            }
        }
    }
}
