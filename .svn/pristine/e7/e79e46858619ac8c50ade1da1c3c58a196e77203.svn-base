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
    public partial class DeptSystem
    {
        static readonly ILog log = LogManager.GetLogger(typeof(DeptSystem));

        #region GetDeptSystem
        /// <summary>
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static DeptSystem GetDeptSystem(Guid id)
        {
            DeptSystem obj = (DeptSystem)Session.DefaultSession.GetObjectByKey(typeof(DeptSystem), id);
            return obj;
        }

        public static DeptSystem GetDeptSystem(string code)
        {
            XPCollection objset = new XPCollection(typeof(DeptSystem),
                 new BinaryOperator("部门编号", code, BinaryOperatorType.Equal),
                 new SortProperty("录入时间", SortingDirection.Descending));

            if (objset.Count > 0)
            {
                return (DeptSystem)objset[0];
            }
            else
                return null;
        }
        #endregion

        #region GetAll

        public static List<DeptSystem> GetAll()
        {
            List<DeptSystem> list = new List<DeptSystem>();
            XPCollection objset = new XPCollection(typeof(DeptSystem), null, new SortProperty("录入时间", SortingDirection.Ascending));

            foreach (DeptSystem item in objset)
            {
                list.Add(item);
            }
            return list;
        }
        #endregion

        #region OnSaving

        protected override void OnSaving()
        {
            if (!string.IsNullOrEmpty(this.体系))
            {
                this.录入人 = AccessController.CurrentUser.姓名;
                this.录入时间 = DateTime.Now;
            }
            DeptSystem found = GetDeptSystem(this.部门编号);
            if (found != null && found.标识 != this.标识)
                throw new Exception("已经存在这个部门的体系记录，不能重复创建。");

            base.OnSaving();
        }
        #endregion

        #region 部门信息

        public DeptInfo 部门信息
        {
            get
            {
                return DeptInfo.Get(this.部门编号);
            }
        }
        #endregion
    }
}
