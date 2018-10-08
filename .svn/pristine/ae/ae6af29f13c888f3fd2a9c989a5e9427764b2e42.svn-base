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
    public partial class ManagementTraineeAbility
    {
        static readonly ILog log = LogManager.GetLogger(typeof(ManagementTraineeAbility));

        #region GetManagementTraineeAbility
        
        public static ManagementTraineeAbility GetManagementTraineeAbility(Guid id)
        {
            ManagementTraineeAbility obj = (ManagementTraineeAbility)Session.DefaultSession.GetObjectByKey(typeof(ManagementTraineeAbility), id);
            return obj;
        }

        public static ManagementTraineeAbility GetManagementTraineeAbility(string empNo, int year)
        {
            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                       new BinaryOperator("员工编号", empNo, BinaryOperatorType.Equal),
                       new BinaryOperator("年度", year, BinaryOperatorType.Equal));

            XPCollection objset = new XPCollection(typeof(ManagementTraineeAbility), criteria, new SortProperty("创建时间", SortingDirection.Ascending));

            if (objset.Count > 0)
            {
                return (ManagementTraineeAbility)objset[0];
            }
            else
                return null;
        }

        #endregion

        #region GetLastAbility
        //最近一次评定
        public static ManagementTraineeAbility GetLastAbility(string empNo)
        {
            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                       new BinaryOperator("员工编号", empNo, BinaryOperatorType.Equal));

            XPCollection objset = new XPCollection(typeof(ManagementTraineeAbility), criteria, new SortProperty("年度", SortingDirection.Descending));

            if (objset.Count > 0)
            {
                return (ManagementTraineeAbility)objset[0];
            }
            else
                return null;
        }
        #endregion

        #region GetManagementTraineeAbilityList

        public static List<ManagementTraineeAbility> GetManagementTraineeAbilityList(string year)
        {
            List<ManagementTraineeAbility> list = new List<ManagementTraineeAbility>();

            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                       new BinaryOperator("年度", year, BinaryOperatorType.Equal));

            if (year == null) criteria = null;

            XPCollection objset = new XPCollection(typeof(ManagementTraineeAbility), criteria, new SortProperty("员工编号", SortingDirection.Ascending));

            foreach (ManagementTraineeAbility item in objset)
            {
                list.Add(item);
            }
            return list;
        }
        #endregion

        #region OnSaving

        protected override void OnSaving()
        {
            if (string.IsNullOrEmpty(this.姓名)) throw new Exception("姓名不能为空");
            if (string.IsNullOrEmpty(this.员工编号)) throw new Exception("员工编号不能为空.");
            if (this.年度 < 2018 || this.年度 > DateTime.Today.Year) throw new Exception("年度不正确");

            ManagementTraineeAbility found = GetManagementTraineeAbility(this.员工编号, this.年度);
            if (found != null && found.标识 != this.标识)
                throw new Exception("已经存在该员工的" + 年度 + "年度评定，不能重复创建");
            else
                base.OnSaving();
        }
        #endregion

        #region CreateOrUpdateAbility

        public static ManagementTraineeAbility CreateOrUpdateAbility(string empNo, int year, string name, string level)
        {
            ManagementTraineeAbility item = GetManagementTraineeAbility(empNo, year);
            if (item == null)
            {
                item = new ManagementTraineeAbility();

                item.标识 = Guid.NewGuid();
                item.员工编号 = empNo;
                item.姓名 = name;
                item.年度 = year;
                item.创建时间 = DateTime.Now;
            }
            item.能力级别 = level;
            item.Save();

            return item;
        }

        #endregion

        #region 员工信息

        EmployeeInfo empInfo = null;
        public EmployeeInfo 员工信息
        {
            get
            {
                if (empInfo == null) empInfo = EmployeeInfo.GetEmployeeInfo(this.员工编号);
                return empInfo;
            }
        }
        #endregion
    }
}
