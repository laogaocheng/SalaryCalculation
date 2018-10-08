using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YiKang.RBACS;
using YiKang.SSO.Components;
using Hwagain.SalaryCalculation.Components;

namespace Hwagain
{
    public class AccessController
    {
        public static string[] CurrentRoles = new string[] { };
        public static Ticket Ticket = null;
        public static Hwagain.SalaryCalculation.Components.User CurrentUser = null;
        public static Hwagain.SalaryCalculation.Components.Member CurrentMember = null;

        static MonthlySalary mySalary = null; //我的工资
        static List<PayGroup> myPayGroups = null; //我管理的薪资组
        static List<RoleGrade> myGrades = null; //我管理的薪等
        static List<RoleLevel> myLevels = null; //我可以查阅的职等
        static List<MemberDept> memDepts = null; //我可以查阅的部门
        static List<MemberGrade> memGrades = null; //我可以查阅的职等

        #region ClearLoginInfo
        /// <summary>
        /// 清空登录信息
        /// </summary>
        public static void ClearLoginInfo()
        {
            Ticket = null;
            CurrentUser = null;
            CurrentMember = null;
            myPayGroups = null;
            myGrades = null;
            memDepts = null;
            memGrades = null;
            AccessService.aclDoc = null;
        }
        #endregion

        #region 我管理的薪资组

        public static List<PayGroup> 我管理的薪资组
        {
            get
            {
                if (myPayGroups == null)
                {
                    myPayGroups = new List<PayGroup>();
                    if (CurrentRoles != null)
                    {
                        foreach (string role in CurrentRoles)
                        {
                            List<RolePayGroup> groups = RolePayGroup.GetPayGroups(role);
                            foreach(RolePayGroup item in groups)
                            {
                                PayGroup group = PayGroup.Get(item.薪资组);
                                if (group != null && !myPayGroups.Contains(group))
                                    myPayGroups.Add(group);               
                            }
                        }
                    }
                }
                return myPayGroups;
            }
        }
        #endregion

        #region 我管理的薪等

        public static List<RoleGrade> 我管理的薪等
        {
            get
            {
                if (myGrades == null)
                {
                    myGrades = new List<RoleGrade>();
                    foreach (string role in CurrentRoles)
                    {
                        List<RoleGrade> grades = RoleGrade.GetRoleGrades(role);
                        myGrades.AddRange(grades);
                    }
                }
                return myGrades;
            }
        }
        #endregion

        #region 我管理的职等

        public static List<RoleLevel> 我管理的职等
        {
            get
            {
                if (myLevels == null)
                {
                    myLevels = new List<RoleLevel>();
                    foreach (string role in CurrentRoles)
                    {
                        List<RoleLevel> lvls = RoleLevel.GetRoleLevels(role);
                        myLevels.AddRange(lvls);
                    }
                }
                return myLevels;
            }
        }
        #endregion

        #region 我可以查阅的部门

        public static List<MemberDept> 我可以查阅的部门
        {
            get
            {
                if (memDepts == null)
                {
                    if (CurrentMember == null)
                        memDepts = new List<MemberDept>();
                    else
                    {
                        EmployeeInfo myInfo = CurrentMember.员工信息;
                        //如果有异动
                        if (myInfo.职务等级 != CurrentMember.职务等级 ||
                            myInfo.公司 != CurrentMember.公司编号 ||
                            myInfo.部门 != CurrentMember.部门编号)
                        {
                            CurrentMember.有异动 = true;
                            CurrentMember.Save();
                            //删除部门权限
                            MemberDept.ClearMemberDept(CurrentMember.员工编号);
                        }
                        memDepts = MemberDept.GetMemberDepts(CurrentMember.员工编号, null);
                    }
                }
                return memDepts;
            }
        }
        #endregion

        #region 我可以查阅的职等

        public static List<MemberGrade> 我可以查阅的职等
        {
            get
            {
                if (memGrades == null)
                {
                    if (CurrentMember == null)
                        memGrades = new List<MemberGrade>();
                    else
                    {
                        EmployeeInfo myInfo = CurrentMember.员工信息;
                        //如果有异动
                        if(myInfo.职务等级 != CurrentMember.职务等级 || 
                            myInfo.公司 != CurrentMember.公司编号 ||
                            myInfo.部门 != CurrentMember.部门编号)
                        {
                            CurrentMember.有异动 = true;
                            CurrentMember.Save();
                            //删除职等权限
                            MemberGrade.ClearMemberGrade(CurrentMember.员工编号);
                        }
                        memGrades = MemberGrade.GetMemberGrades(CurrentMember.员工编号, null);                        
                    }
                }
                return memGrades;
            }
        }
        #endregion

        #region 我的月薪

        public static MonthlySalary 我的月薪
        {
            get
            {
                if (mySalary == null)
                {
                    if (CurrentMember == null) return null;
                    mySalary = MonthlySalary.GetEffective(CurrentMember.员工编号, DateTime.Today);
                    //查上月工资
                    if (mySalary == null) mySalary = MonthlySalary.GetEffective(CurrentMember.员工编号, DateTime.Today.AddMonths(-1));
                }
                return mySalary;
            }
        }

        #endregion

        #region CheckPayGroup

        /// <summary>
        /// 检测薪资组权限
        /// </summary>
        /// <param name="payGroup"></param>
        /// <returns></returns>
        public static bool CheckPayGroup(string payGroup)
        {
            return 我管理的薪资组.Find(a => a.英文名 == payGroup) != null;
        }
        #endregion

        #region CheckGrade

        /// <summary>
        /// 检测职级权限
        /// </summary>
        /// <param name="payGroup"></param>
        /// <returns></returns>
        public static bool CheckGrade(int gradeId)
        {
            return 我管理的薪等.Find(a => a.薪等标识 == gradeId) != null;            
        }
        #endregion

        #region CheckLevel

        /// <summary>
        /// 检测职等权限
        /// </summary>
        /// <param name="comanyCode">公司编码</param>
        /// <param name="level">职务等级</param>
        /// <returns></returns>
        public static bool CheckLevel(string comanyCode, string level)
        {
            return 我管理的职等.Find(a => a.公司编码 == comanyCode && a.职务等级 == level) != null;
        }

        #endregion

        #region CheckQueryDept
        //检查是否可以查阅指定的部门
        public static bool CheckQueryDept(string company, string deptCode)
        {
            //我可以查看这个部门
            MemberDept md = 我可以查阅的部门.Find(a => a.可查公司名称 == company && deptCode != null && (a.可查部门编号 == deptCode.Trim() || a.可查部门编号 == "所有部门"));
            return md != null;
        }
        #endregion

        #region CheckQueryGrade

        //检查是否可以查阅指定的职等
        public static bool CheckQueryGrade(string gradeCode)
        {
            if (AccessController.CurrentMember == null) return false;

            string myUserType = CurrentMember.用户类型;

            MemberGrade mg = 我可以查阅的职等.Find(a => a.工资职等 == gradeCode || a.工资职等 == "所有职等");
            if (myUserType == "算薪人员")
            {
                return mg != null;
            }
            else
                return true;
        }
        #endregion

        #region 检查功能权限

        #region CheckDoAuditingPublicPay

        //审核上表工资权限
        public static bool CheckDoAuditingPublicPay()
        {
            if (CheckNormalAuth("Salary", "DoAuditingPublicPay") == AuthType.允许)
                return true;
            else
                return CheckNormalAuth("Salary", "Admin") == AuthType.允许;

        }
        #endregion

        #region CheckDoAuditingPay

        //审核工资权限
        public static bool CheckDoAuditingPay()
        {
            if (CheckNormalAuth("Salary", "DoAuditingPay") == AuthType.允许)
                return true;
            else
                return CheckNormalAuth("Salary", "Admin") == AuthType.允许;

        }
        #endregion

        #region CheckSyncPsData

        //同步PS数据
        public static bool CheckSyncPsData()
        {
            if (CheckNormalAuth("Salary", "SyncPsData") == AuthType.允许)
                return true;
            else
                return CheckNormalAuth("Salary", "Admin") == AuthType.允许;

        }
        #endregion

        #region CheckLockPay

        //审核冻结工资权限
        public static bool CheckLockPay()
        {
            if (CheckNormalAuth("Salary", "LockPay") == AuthType.允许)
                return true;
            else
                return CheckNormalAuth("Salary", "Admin") == AuthType.允许;

        }
        #endregion

        #region CheckOpenPayReport

        //打开工资报表
        public static bool CheckOpenPayReport()
        {
            if (CheckNormalAuth("Salary", "OpenPayReport") == AuthType.允许)
                return true;
            else
                return CheckNormalAuth("Salary", "Admin") == AuthType.允许;

        }
        #endregion

        #region CheckInputSalaryItem

        //检查录入工资项（奖扣项、工资降级等）
        public static bool CheckInputSalaryItem()
        {
            if (CheckNormalAuth("Salary", "InputSalaryItem") == AuthType.允许)
                return true;
            else
                return CheckNormalAuth("Salary", "Admin") == AuthType.允许;

        }
        #endregion

        #region CheckInputPersonPayRate

        //检查录入职级工资
        public static bool CheckInputPersonPayRate()
        {
            if (CheckNormalAuth("Salary", "InputPersonPayRate") == AuthType.允许)
                return true;
            else
                return CheckNormalAuth("Salary", "Admin") == AuthType.允许;

        }

        #endregion

        #region CheckInputEmpPayRate

        //检查录入工资系数
        public static bool CheckInputEmpPayRate()
        {
            if (CheckNormalAuth("Salary", "InputEmpPayRate") == AuthType.允许)
                return true;
            else
                return CheckNormalAuth("Salary", "Admin") == AuthType.允许;

        }

        #endregion

        #region CheckPersonBorrowInput

        //录入个人借款记录权限
        public static bool CheckPersonBorrowInput()
        {
            if (CheckNormalAuth("Salary", "PersonBorrowInput") == AuthType.允许)
                return true;
            else
                return CheckNormalAuth("Salary", "Admin") == AuthType.允许;

        }
        #endregion

        #region CheckReimbursementStandardInput

        //录入报销标准权限
        public static bool CheckReimbursementStandardInput()
        {
            if (CheckNormalAuth("Salary", "ReimbursementStandardInput") == AuthType.允许)
                return true;
            else
                return CheckNormalAuth("Salary", "Admin") == AuthType.允许;

        }
        #endregion

        #region CheckManagePrivateSalaryTree

        //检查维护封闭工资结构
        public static bool CheckManagePrivateSalaryTree()
        {
            if (CheckNormalAuth("Salary", "ManagePrivateSalaryTree") == AuthType.允许)
                return true;
            else
                return CheckNormalAuth("Salary", "Admin") == AuthType.允许;

        }

        #endregion

        #region CheckLookupStepPayRate

        //检查查看职级工资标准
        public static bool CheckLookupStepPayRate()
        {
            if (CheckNormalAuth("Salary", "CheckLookupStepPayRate") == AuthType.允许)
                return true;
            else
                return CheckNormalAuth("Salary", "Admin") == AuthType.允许;

        }

        #endregion

        #region CheckPrintPayReport

        //打印工资表权限
        public static bool CheckPrintPayReport()
        {
            if (CheckNormalAuth("Salary", "PrintPayReport") == AuthType.允许)
                return true;
            else
                return CheckNormalAuth("Salary", "Admin") == AuthType.允许;

        }
        #endregion

        #region CheckEmployeeSalaryStepInput

        //录入员工工资职级权限
        public static bool CheckEmployeeSalaryStepInput()
        {
            if (CheckNormalAuth("Salary", "EmployeeSalaryStepInput") == AuthType.允许)
                return true;
            else
                return CheckNormalAuth("Salary", "Admin") == AuthType.允许;

        }
        #endregion

        #region CheckPersonReimbursementInput

        //录入个人报销记录权限
        public static bool CheckPersonReimbursementInput()
        {
            if (CheckNormalAuth("Salary", "PersonReimbursementInput") == AuthType.允许)
                return true;
            else
                return CheckNormalAuth("Salary", "Admin") == AuthType.允许;

        }
        #endregion

        #region CheckPerformanceSalaryInput

        //录入约定绩效工资记录权限
        public static bool CheckPerformanceSalaryInput()
        {
            if (CheckNormalAuth("Salary", "PerformanceSalaryInput") == AuthType.允许)
                return true;
            else
                return CheckNormalAuth("Salary", "Admin") == AuthType.允许;

        }
        #endregion

        #region CheckEffectivePerformanceSalaryInput

        //录入执行绩效工资记录权限
        public static bool CheckEffectivePerformanceSalaryInput()
        {
            if (CheckNormalAuth("Salary", "EffectivePerformanceSalaryInput") == AuthType.允许)
                return true;
            else
                return CheckNormalAuth("Salary", "Admin") == AuthType.允许;

        }
        #endregion

        #region CheckOpenTaxReport

        //打开个税申报表
        public static bool CheckOpenTaxReport()
        {
            if (CheckNormalAuth("Salary", "OpenTaxReport") == AuthType.允许)
                return true;
            else
                return CheckNormalAuth("Salary", "Admin") == AuthType.允许;

        }
        #endregion

        #region CheckDownloadReport

        //下载报表
        public static bool CheckDownloadReport()
        {
            if (CheckNormalAuth("Salary", "DownloadReport") == AuthType.允许)
                return true;
            else
                return CheckNormalAuth("Salary", "Admin") == AuthType.允许;

        }
        #endregion

        #region CheckQueryLevelInput

        //录入工资查询权限
        public static bool CheckQueryLevelInput()
        {
            if (CheckNormalAuth("Salary", "QueryLevelInput") == AuthType.允许)
                return true;
            else
                return CheckNormalAuth("Salary", "Admin") == AuthType.允许;

        }
        #endregion

        #region 系统管理权限

        //配置权限
        public static bool CheckConfig()
        {
            if (CheckNormalAuth("System", "Config") == AuthType.允许)
                return true;
            else
                return CheckNormalAuth("System", "Admin") == AuthType.允许;

        }
        //管理权限
        public static bool CheckManagePermission()
        {
            if (CheckNormalAuth("System", "ManagePermission") == AuthType.允许)
                return true;
            else
                return CheckNormalAuth("System", "Admin") == AuthType.允许;

        }
        //管理用户
        public static bool CheckManageUser()
        {
            if (CheckNormalAuth("System", "ManageUser") == AuthType.允许)
                return true;
            else
                return CheckNormalAuth("System", "Admin") == AuthType.允许;

        }
        #endregion

        #endregion

        #region CheckNormalAuth

        /// <summary>
        /// 检查一般权限
        /// </summary>
        /// <param name="objName">对象名</param>
        /// <param name="toCheckImpower">要检查的权限</param>
        /// <returns></returns>
        public static AuthType CheckNormalAuth(string objName, string toCheckImpower)
        {
            string denyParams = "";
            string allowParams = "";
            AuthType ret = AccessService.CheckPermissible(CurrentRoles, objName, toCheckImpower, out denyParams, out allowParams);
            return ret;
        }

        #endregion

        #region GetValue

        //获取参数值
        public static string GetValue(string s, string key)
        {
            string ret = "";
            string[] fields = s.Split(new char[] { ';' });
            for (int i = 0; i < fields.Length; i++)
            {
                string[] pair = fields[i].Split(new char[] { '=' });
                if (pair.Length == 2 && (pair[0].ToUpper() == key.ToUpper()))
                {
                    if (ret != "") ret += ","; //要用逗号隔开各个参数值
                    ret += pair[1];
                }
            }
            return ret;
        }
        #endregion
    }
}
