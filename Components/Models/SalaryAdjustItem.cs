using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;

namespace Hwagain.SalaryCalculation.Components
{
    //工资调整项
    public class SalaryAdjustItem
    {
        PrivateSalary prevMonthSalary = null; //上月工资
        PrivateSalary currMonthSalary = null; //本月工资

        public bool 已调整工资 { get; set; }
        public string 薪资组  { get; set; }

        public SalaryAdjustItem(EmployeeInfo emp, PrivateSalary salary)
        {
            empInfo = emp;
            if (salary != null)
            {
                DateTime currMonth = new DateTime(salary.年度, salary.月份, 1);
                DateTime prevMonth = currMonth.AddMonths(-1);
                prevMonthSalary = PrivateSalary.GetPrivateSalary(salary.员工编号, prevMonth.Year, prevMonth.Month);
                currMonthSalary = salary;
            }
        }

        #region GetChangedItems

        public static List<SalaryAdjustItem> GetAdjustItems(int year, int month, string payGroup)
        {
            List<SalaryAdjustItem> list = new List<SalaryAdjustItem>();

            DateTime currMonth = new DateTime(year, month, 1);
            DateTime prevMonth = currMonth.AddMonths(-1);

            //获取应调整人员名单
            List<EmployeeInfo> empList = GetEmployeeListToAdjust(year, month, payGroup);
            List<PrivateSalary> currList = PrivateSalary.GetPrivateSalarys(year, month, null, payGroup);
            foreach (EmployeeInfo emp in empList)
            {
                PrivateSalary currSalary = currList.Find(a => a.员工编号 == emp.员工编号);
                SalaryAdjustItem item = new SalaryAdjustItem(emp, currSalary);                
                //工资调整幅度超过 2% 才认为有调整
                if (currSalary != null && currSalary.工资调整幅度 > (decimal)0.02)
                {
                    item.薪资组 = currSalary.薪资组; 
                    item.已调整工资 = true;
                }
                list.Add(item);
            }

            return list;
        }

        private static List<EmployeeInfo> GetEmployeeListToAdjust(int year, int month, string payGroup)
        {
            List<EmployeeInfo> list = new List<EmployeeInfo>();

#if(DEBUG)
            //list.Add(EmployeeInfo.GetEmployeeInfoByName("徐柳青"));
            //list.Add(EmployeeInfo.GetEmployeeInfoByName("麦凤彩"));
            //list.Add(EmployeeInfo.GetEmployeeInfoByName("李元芳"));
#endif
            return list;
        }

        #endregion

        #region 员工信息

        EmployeeInfo empInfo = null;
        public EmployeeInfo 员工信息
        {
            get
            {
                return empInfo;
            }
        }
        #endregion

        #region 上月工资

        public PrivateSalary 上月工资
        {
            get
            {
                if (AccessController.CheckPayGroup(薪资组))
                    return prevMonthSalary;
                else
                    return null;
            }
        }
        #endregion

        #region 本月工资

        public PrivateSalary 本月工资
        {
            get
            {
                if (AccessController.CheckPayGroup(薪资组))
                    return currMonthSalary;
                else
                    return null;
            }
        }
        #endregion

        #region 工资变化

        public decimal 工资变化
        {
            get
            {
                decimal curr = currMonthSalary == null ? 0 : currMonthSalary.职级工资;
                decimal prev = prevMonthSalary == null ? 0 : prevMonthSalary.职级工资;
                return curr - prev;
            }
        }
        #endregion

        #region 上月职级工资

        public decimal 上月职级工资
        {
            get
            {
                return prevMonthSalary == null ? 0 : prevMonthSalary.职级工资;
            }
        }
        #endregion
    }
}
