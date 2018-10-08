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
    public partial class ManagementSpecialtyProperty
    {
        static readonly ILog log = LogManager.GetLogger(typeof(ManagementSpecialtyProperty));

        #region GetManagementSpecialtyProperty
        
        public static ManagementSpecialtyProperty GetManagementSpecialtyProperty(Guid id)
        {
            ManagementSpecialtyProperty obj = (ManagementSpecialtyProperty)Session.DefaultSession.GetObjectByKey(typeof(ManagementSpecialtyProperty), id);
            return obj;
        }

        public static ManagementSpecialtyProperty GetManagementSpecialtyProperty(string division, string grade, string xueli, string specialty)
        {
            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                       new BinaryOperator("届别", division, BinaryOperatorType.Equal),
                       new BinaryOperator("岗位级别", grade, BinaryOperatorType.Equal),
                       new BinaryOperator("学历", xueli, BinaryOperatorType.Equal),
                       new BinaryOperator("专业名称", specialty, BinaryOperatorType.Equal)
                       );

            XPCollection objset = new XPCollection(typeof(ManagementSpecialtyProperty), criteria, new SortProperty("更新时间", SortingDirection.Descending));

            if (objset.Count > 0)
            {
                return (ManagementSpecialtyProperty)objset[0];
            }
            else
                return null;
        }

        #endregion

        #region GetManagementSpecialtyPropertyList
        
        public static List<ManagementSpecialtyProperty> GetManagementSpecialtyPropertyList(string year)
        {
            List<ManagementSpecialtyProperty> list = new List<ManagementSpecialtyProperty>();

            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                       new BinaryOperator("届别", year, BinaryOperatorType.Equal));

            if (year == null) criteria = null;

            XPCollection objset = new XPCollection(typeof(ManagementSpecialtyProperty), criteria, new SortProperty("序号", SortingDirection.Ascending));

            foreach (ManagementSpecialtyProperty item in objset)
            {
                list.Add(item);
            }
            return list;
        }
        #endregion

        #region OnSaving

        protected override void OnSaving()
        {
            if (string.IsNullOrEmpty(this.届别)) throw new Exception("届别不能为空.");
            if (string.IsNullOrEmpty(this.岗位级别)) throw new Exception("岗位级别不能为空.");
            if (string.IsNullOrEmpty(this.学历)) throw new Exception("学历不能为空.");
            if (string.IsNullOrEmpty(this.专业名称)) throw new Exception("专业名称不能为空.");

            ManagementSpecialtyProperty found = GetManagementSpecialtyProperty(this.届别, this.岗位级别, this.学历, this.专业名称);
            if (found != null && found.标识 != this.标识)
                throw new Exception("已经存在该专业的属性信息，不能重复创建");
            else
                base.OnSaving();
        }
        #endregion

        #region AddManagementSpecialtyProperty

        public static ManagementSpecialtyProperty AddManagementSpecialtyProperty(string year, string grade, string xueli, string specialty, string property)
        {
            ManagementSpecialtyProperty item = GetManagementSpecialtyProperty(year, grade, xueli, specialty);
            if (item == null)
            {
                item = new ManagementSpecialtyProperty();

                item.标识 = Guid.NewGuid();

                item.届别 = year;
                item.岗位级别 = grade;
                item.学历 = xueli;
                item.专业名称 = specialty;
                item.属性 = property;
                
                item.更新时间 = DateTime.Now;
                item.Save();
            }
            return item;
        }
        #endregion
    }
}
