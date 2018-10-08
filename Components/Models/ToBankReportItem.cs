using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;

namespace Hwagain.SalaryCalculation.Components
{
    //报盘记录
    public class ToBankReportItem
    {
        public string 银行名称 { get; set; }
        public string 银行编号 { get; set; }
        public string 员工编号 { get; set; }
        public string 员工姓名 { get; set; }
        public string 银行账户 { get; set; }
        public string 账户名称 { get; set; }
        public string 账户类型 { get; set; }
        public int 部门序号 { get; set; }
        public int 员工序号 { get; set; }
        public decimal 金额 { get; set; }


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
