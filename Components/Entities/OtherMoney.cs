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
    public partial class OtherMoney
    {
        static readonly ILog log = LogManager.GetLogger(typeof(OtherMoney));

        #region GetOtherMoney
        /// <summary>
        /// 通过 Id 获取线路
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static OtherMoney GetOtherMoney(int id)
        {
            OtherMoney obj = (OtherMoney)Session.DefaultSession.GetObjectByKey(typeof(OtherMoney), id);
            return obj;
        }

        public static OtherMoney GetOtherMoney(string empNo, int year, int month, string type, string itemName)
        {
            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                       new BinaryOperator("员工编号", empNo, BinaryOperatorType.Equal),
                       new BinaryOperator("年", year, BinaryOperatorType.Equal),
                       new BinaryOperator("月", month, BinaryOperatorType.Equal),
                       new BinaryOperator("类型", type, BinaryOperatorType.Equal),
                       new BinaryOperator("项目名称", itemName, BinaryOperatorType.Equal));

            XPCollection objset = new XPCollection(typeof(OtherMoney), criteria, new SortProperty("录入时间", SortingDirection.Ascending));

            if (objset.Count > 0)
            {
                return (OtherMoney)objset[0];
            }
            else
                return null;
        }

        #endregion

        #region GetOtherMoneyList

        //获取其他奖扣项清单
        public static List<OtherMoney> GetOtherMoneyList(int year, int month)
        {
            List<OtherMoney> list = new List<OtherMoney>();

            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                       new BinaryOperator("年", year, BinaryOperatorType.Equal),
                       new BinaryOperator("月", month, BinaryOperatorType.Equal));

            XPCollection objset = null;

            objset = new XPCollection(typeof(OtherMoney), criteria, new SortProperty("录入时间", SortingDirection.Ascending));

            foreach (OtherMoney item in objset)
            {
                list.Add(item);
            }
            return list;
        }
        #endregion

        #region OnSaving

        protected override void OnSaving()
        {
            if (string.IsNullOrEmpty(this.员工编号))
            {
                this.员工编号 = "";
                return;
            }
            if (string.IsNullOrEmpty(this.类型)) throw new Exception("类型不能为空.");
            if (this.录入时间 == DateTime.MinValue) this.录入时间 = DateTime.Now;
            //判断已经审核的薪资组不能修改
            SalaryResult salResult = SalaryResult.GetFromCache(this.员工编号, this.年, this.月);
            if (salResult == null)
                throw new Exception("未发现【" + this.姓名 + "】的工资记录，请先生成工资表后再录入。");
            else
            {
                SalaryAuditingResult auditingResult = SalaryAuditingResult.GetSalaryAuditingResult(salResult.薪资组, this.年, this.月);
                if(auditingResult == null)
                    throw new Exception("未发现【" + salResult.薪资组名称 + "】的工资审核情况表");
                else
                {
                    if (auditingResult.已审核) throw new Exception("薪资组【" + salResult.薪资组名称 + "】的工资已经审核，不能添加或修改。");
                }
            }

            OtherMoney found = GetOtherMoney(this.员工编号, this.年, this.月, this.类型, this.项目名称);
            if (found != null && found.标识 != this.标识)
                throw new Exception("同一个奖扣项不能重复录入.");
            else
                base.OnSaving();
        }
        #endregion

        #region AddOtherMoney

        public static OtherMoney AddOtherMoney(string empNo, string name, int year, int month, string type, string itemName)
        {
            OtherMoney item = GetOtherMoney(empNo, year, month, type, itemName);
            if (item == null)
            {
                item = new OtherMoney();

                item.标识 = Guid.NewGuid();
                item.员工编号 = empNo;
                item.姓名 = name;
                item.年 = year;
                item.月 = month;
                item.类型 = type;
                item.项目名称 = itemName;

                item.Save();
            }
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
