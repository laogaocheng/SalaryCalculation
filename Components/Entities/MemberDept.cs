using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using DevExpress.Xpo.DB;
using log4net;
using Hwagain.Components;
using System.Data.SqlClient;

namespace Hwagain.SalaryCalculation.Components
{
    public partial class MemberDept
    {
        static readonly ILog log = LogManager.GetLogger(typeof(MemberDept));
        public static ICache<string, MemberDept> MEMBER_DEPT_CACHE = MemoryCache<string, MemberDept>.Instance;

        #region GetMemberDept

        public static MemberDept GetMemberDept(Guid id)
        {
            MemberDept obj = (MemberDept)Session.DefaultSession.GetObjectByKey(typeof(MemberDept), id);
            return obj;
        }

        public static MemberDept GetMemberDept(string emplid, string company, string dept)
        {
            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                       new BinaryOperator("员工编号", emplid, BinaryOperatorType.Equal),
                       new BinaryOperator("可查公司名称", company, BinaryOperatorType.Equal),
                       new BinaryOperator("可查部门编号", dept, BinaryOperatorType.Equal)
                       );

            XPCollection objset = new XPCollection(typeof(MemberDept), criteria, new SortProperty("可查部门编号", SortingDirection.Ascending));

            if (objset.Count > 0)
            {
                return (MemberDept)objset[0];
            }
            else
                return null;
        }

        #endregion

        #region GetFromCache

        public static MemberDept GetFromCache(string emplid, string company, string dept)
        {
            string key = emplid + "$$" + company + "$$" + dept;
            return MEMBER_DEPT_CACHE.Get(key, () => GetMemberDept(emplid, company, dept), TimeSpan.FromHours(1));                
        }
        #endregion
        
        #region GetMemberDepts

        public static List<MemberDept> GetMemberDepts(string emplid, string company)
        {
            List<MemberDept> list = new List<MemberDept>();

            GroupOperator criteria = new GroupOperator(GroupOperatorType.And);

            if (!string.IsNullOrEmpty(emplid)) criteria.Operands.Add(new BinaryOperator("员工编号", emplid, BinaryOperatorType.Equal));
            if (!string.IsNullOrEmpty(company)) criteria.Operands.Add(new BinaryOperator("可查公司名称", company, BinaryOperatorType.Equal));

            XPCollection objset = new XPCollection(typeof(MemberDept), criteria, new SortProperty("可查部门编号", SortingDirection.Ascending));

            foreach (MemberDept ms in objset)
            {
                list.Add(ms);                
            }
            return list;
        }

        #endregion

        #region AddMemberDept

        public static MemberDept AddMemberDept(string emplid, string company, string dept)
        {
            MemberDept item = GetMemberDept(emplid, company, dept);
            //删除原来的记录
            if (item != null) item.Delete();

            item = new MemberDept();
            item.标识 = Guid.NewGuid();
            item.员工编号 = emplid;
            item.可查公司名称 = company;
            item.可查部门编号 = dept;

            EmployeeInfo emp = EmployeeInfo.GetEmployeeInfo(emplid);
            if (emp != null)
            {
                item.所属公司编号 = emp.公司;
                item.所属部门编号 = emp.部门;
                item.职务等级代码 = emp.职务等级;
            }
            item.Save();

            return item;
        }
        #endregion

        #region OnSaving

        protected override void OnSaving()
        {
            MemberDept found = GetMemberDept(this.员工编号, this.可查公司名称, this.可查部门编号);
            if (found != null && found.标识 != this.标识)
                throw new Exception("已存在该员工的相同权限记录，不能重复创建。");
            else
                base.OnSaving();

            MEMBER_DEPT_CACHE.Set(CacheKey, this, TimeSpan.FromHours(1));
        }
        #endregion

        #region OnDeleting

        protected override void OnDeleting()
        {
            base.OnDeleting();
            MEMBER_DEPT_CACHE.Remove(CacheKey);
        }
        #endregion

        #region OnDeleted
        protected override void OnDeleted()
        {
            base.OnDeleted();
        }
        #endregion

        #region ClearMemberDept

        //清除
        public static void ClearMemberDept(string emplid)
        {
            string sql = "DELETE FROM 会员_部门 WHERE 员工编号 = '" + emplid + "'";
            using (SqlConnection connection = new SqlConnection(MyHelper.GetConnectionString()))
            {
                YiKang.Data.SqlHelper.ExecuteNonQuery(connection, System.Data.CommandType.Text, sql);
            }
        }
        #endregion

        #region ClearInvalidRecord
        //清理无效的记录
        public static void ClearInvalidRecord()
        {
            List<Member> memberList = Member.GetAll();
            foreach (Member member in memberList)
            {
                if (member.用户类型 == "系统管理员") continue;

                EmployeeInfo emp = EmployeeInfo.GetEmployeeInfo(member.员工编号);
                if (emp != null && (member.公司编号 != emp.公司 || member.部门编号 != emp.部门 || member.职务等级 != emp.职务等级))
                {
                    ClearMemberDept(member.员工编号);
                    //清除授权时所在部门的信息
                    member.公司编号 = null;
                    member.部门编号 = null;
                    member.职务等级 = null;
                    member.Save();
                }
            }
        }
        #endregion

        #region OnLoaded

        protected override void OnLoaded()
        {
            AutoSaveOnEndEdit = false; //关闭自动保存的开关
            //缓存
            MEMBER_DEPT_CACHE.Set(this.CacheKey, this, TimeSpan.FromHours(1));
            base.OnLoaded();
        }
        #endregion

        #region CacheKey

        string CacheKey
        {
            get { return this.员工编号 + "$$" + this.可查公司名称 + "$$" + this.可查部门编号; }
        }

        #endregion

        #region 员工信息

        EmployeeInfo empInfo = null;
        [NonPersistent]
        public EmployeeInfo 员工信息
        {
            get
            {
                if (empInfo == null) empInfo = EmployeeInfo.GetEmployeeInfo(this.员工编号);
                return empInfo;
            }
            set { empInfo = value; }
        }
        #endregion

        #region 部门

        public string 部门
        {
            get
            {
                if (员工信息 != null)
                {
                    return 员工信息.部门名称;
                }
                return null;
            }
        }

        #endregion

        #region 姓名

        public string 姓名
        {
            get
            {
                if (员工信息 != null)
                {
                    return 员工信息.姓名;
                }
                return null;
            }
        }

        #endregion

        #region 性别

        public string 性别
        {
            get
            {
                if (员工信息 != null)
                {
                    return 员工信息.性别;
                }
                return null;
            }
        }

        #endregion

        #region 职务

        public string 职务
        {
            get
            {
                if (员工信息 != null)
                {
                    return 员工信息.职务名称;
                }
                return null;
            }
        }

        #endregion

        public DeptInfo 可查询部门
        {
            get { return DeptInfo.Get(可查部门编号); }
        }

    }
}
