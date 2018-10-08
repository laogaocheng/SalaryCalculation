using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;

namespace Hwagain.SalaryCalculation.Components
{
    public class QueryPermission
    {
        public string 员工编号 { get; set; }
        public string 姓名 { get; set; }
        public string 公司 { get; set; }
        public string 部门 { get; set; }
        public string 职务 { get; set; }
        public string 职等 { get; set; }
        public int 序号 { get; set; }
        public string 用户类型 { get; set; }
        public string 查询部门范围 { get; set; }
        public string 查询职等范围 { get; set; }
        public List<MemberDept> 部门权限集 { get; set; }
        public List<MemberGrade> 职等权限集 { get; set; }
        public Member 会员 { get; set; }

        static List<QueryPermission> permissionList = null;
        public static List<QueryPermission> 权限表
        {
            get
            {
                if (permissionList == null) permissionList = GetAll();
                return permissionList;
            }
        }

        public QueryPermission()
        {
        }

        public QueryPermission(Member member, string company)
        {
            EmployeeInfo employee = EmployeeInfo.GetEmployeeInfo(member.员工编号);
            if (employee == null) return;
            
            List<MemberDept> list_dept = MemberDept.GetMemberDepts(employee.员工编号, company);
            List<MemberGrade> list_grade = MemberGrade.GetMemberGrades(employee.员工编号, company);

            会员 = member;
            员工编号 = employee.员工编号;
            姓名 = employee.姓名;
            公司 = employee.公司名称;
            部门 = employee.部门名称;
            职务 = employee.职务名称;
            职等 = employee.职等;
            部门权限集 = list_dept;
            职等权限集 = list_grade;
            用户类型 = member.用户类型;
        }

        public static QueryPermission Get(string emplid)
        {
            return 权限表.Find(a => a.员工编号 == emplid);
        }

        public static List<QueryPermission> GetAll()
        {
            List<QueryPermission> list = new List<QueryPermission>();
            List<MemberDept> memDepts = MemberDept.GetMemberDepts(null, null);
            List<MemberGrade> memGrades = MemberGrade.GetAll();
            List<Member> memberList = Member.GetAll();
            //找出员工清单
            var emps = from u in memDepts
                        group u by u.员工信息 into emp
                        select emp.Key;

            foreach(Member member in memberList)
            {
                EmployeeInfo employee = EmployeeInfo.GetEmployeeInfo(member.员工编号);
                if (employee == null) continue;

                QueryPermission qp = new QueryPermission();
                List<MemberDept> list_dept = memDepts.FindAll(a=>a.员工编号 == employee.员工编号);
                List<MemberGrade> list_grade = memGrades.FindAll(a => a.员工编号 == employee.员工编号);

                qp.会员 = member;
                qp.员工编号 = employee.员工编号;
                qp.姓名 = employee.姓名;
                qp.公司 = employee.公司名称;
                qp.部门 = employee.部门名称;
                qp.职务 = employee.职务名称;
                qp.职等 = employee.职等;
                qp.部门权限集 = list_dept;
                qp.职等权限集 = list_grade;
                qp.用户类型 = member.用户类型;

                list.Add(qp);

            }
            return list;
        }
        public string GetDeptList(string company)
        {
            List<MemberDept> list = 部门权限集;
            if (string.IsNullOrEmpty(company) == false)
            {
                list = 部门权限集.FindAll(a => a.可查公司名称 == company);
                if (company == "集团总部") list.AddRange(部门权限集.FindAll(a => a.可查公司名称 == "华劲人纸品"));//包括华劲人纸品
            }
            string s = "";
            foreach (MemberDept md in list)
            {
                if (s != "") s += "、";
                if (string.IsNullOrEmpty(company)) s += md.可查公司名称;
                if (md.可查询部门 == null)
                    s += md.可查部门编号;
                else
                    s += md.可查询部门.部门名称;
            }
            return s;
        }

        public string GetGradeList(string company)
        {

            List<MemberGrade> list = 职等权限集;
            if (string.IsNullOrEmpty(company) == false)
            {
                list = 职等权限集.FindAll(a => a.公司名称 == company);
                if (company == "集团总部") list.AddRange(职等权限集.FindAll(a => a.公司名称 == "华劲人纸品"));//包括华劲人纸品
            }
            string s = "";
            foreach (MemberGrade mg in list)
            {
                if (s != "") s += "、";
                if (string.IsNullOrEmpty(company)) s += mg.公司名称;
                s += mg.工资职等;
            }
            return s;
        }

        public string 修改按钮文本
        {
            get { return "设置"; }
        }

        #region 员工信息

        EmployeeInfo empInfo = null;
        public EmployeeInfo 员工信息
        {
            get
            {
                if (empInfo == null) empInfo = EmployeeInfo.GetEmployeeInfo(员工编号);
                return empInfo;
            }
            set { empInfo = value; }
        }
        #endregion
    }

}
