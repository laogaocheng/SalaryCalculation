using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;

namespace Hwagain.SalaryCalculation.Components
{
    //工资异动
    public class SalaryChangedItem
    {
        PrivateSalary prevMonthSalary = null; //上月工资
        PrivateSalary currMonthSalary = null; //本月工资

        public string 变动类型 {get;set;} //新增、减少、变动、不变
        public string 薪资组 = null;

        public SalaryChangedItem(PrivateSalary prevMonth, PrivateSalary currMonth)
        {
            prevMonthSalary = prevMonth;
            currMonthSalary = currMonth;
        }

        #region GetChangedItems

        public static List<SalaryChangedItem> GetChangedItems(int year, int month, string payGroup)
        {
            List<SalaryChangedItem> list = new List<SalaryChangedItem>();

            DateTime currMonth = new DateTime(year, month, 1);
            DateTime prevMonth = currMonth.AddMonths(-1);

            List<PrivateSalary> prevList = PrivateSalary.GetPrivateSalarys(prevMonth.Year, prevMonth.Month, null, payGroup);
            List<PrivateSalary> currList = PrivateSalary.GetPrivateSalarys(year, month, null, payGroup);
            foreach (PrivateSalary currSalary in currList)
            {
                PrivateSalary prevSal = prevList.Find(a => a.员工编号 == currSalary.员工编号);
                if (prevSal == null || prevSal.总工资 != currSalary.总工资)
                {
                    string type = prevSal == null ? "新增人员" : "工资变动";
                    //2018-3-23 如果薪资组变动，需另外获取
                    if (prevSal == null) prevSal = PrivateSalary.GetPrivateSalary(currSalary.员工编号, prevMonth.Year, prevMonth.Month);
                    SalaryChangedItem item = new SalaryChangedItem(prevSal, currSalary) { 变动类型 = type, 薪资组 = currSalary.薪资组 };
                    list.Add(item);
                }
            }
            //找出减少的
            foreach (PrivateSalary prevSalary in prevList)
            {
                if (currList.Find(a => a.员工编号 == prevSalary.员工编号) == null)
                {
                    SalaryChangedItem item = new SalaryChangedItem(prevSalary, null) { 变动类型 = "减少人员", 薪资组 = prevSalary.薪资组 };
                    list.Add(item);
                }
            }

            return list;
        }
        #endregion

        #region 员工信息

        EmployeeInfo empInfo = null;
        public EmployeeInfo 员工信息
        {
            get
            {
                if (empInfo == null)
                {
                    if (prevMonthSalary != null) empInfo = EmployeeInfo.GetEmployeeInfo(prevMonthSalary.员工编号);
                    if (empInfo == null && currMonthSalary != null) empInfo = EmployeeInfo.GetEmployeeInfo(currMonthSalary.员工编号);
                }
                return empInfo;
            }
        }
        #endregion

        #region 上月工资

        public PrivateSalary 上月工资
        {
            get
            {
                return prevMonthSalary;
            }
        }
        #endregion

        #region 本月工资

        public PrivateSalary 本月工资
        {
            get
            {
                return currMonthSalary;
            }
        }
        #endregion

        #region 工资变化

        public decimal 工资变化
        {
            get
            {
                decimal curr = currMonthSalary == null ? 0 : currMonthSalary.总工资;
                decimal prev = prevMonthSalary == null ? 0 : prevMonthSalary.总工资;
                return curr - prev;
            }
        }
        #endregion

        #region 上月职级工资

        public decimal 上月职级工资
        {
            get
            {
                return prevMonthSalary == null ? 0 : prevMonthSalary.总工资;
            }
        }
        #endregion

        #region 计算部门序号
        public int 计算部门序号
        {
            get
            {
                if (currMonthSalary != null) return currMonthSalary.基础工资表.财务部门序号;
                if (prevMonthSalary != null) return prevMonthSalary.基础工资表.财务部门序号;
                return empInfo.部门序号;

            }
        }

        #endregion
    }
}
