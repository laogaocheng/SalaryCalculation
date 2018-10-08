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
using System.ComponentModel;

namespace Hwagain.SalaryCalculation.Components
{
    public partial class MemberDeptInput
    {
        static readonly ILog log = LogManager.GetLogger(typeof(MemberDeptInput));
        public static ICache<string, MemberDeptInput> MEMBER_DEPT_INPUT_CACHE = MemoryCache<string, MemberDeptInput>.Instance;

        #region GetMemberDeptInput

        public static MemberDeptInput GetMemberDeptInput(Guid id)
        {
            MemberDeptInput obj = (MemberDeptInput)Session.DefaultSession.GetObjectByKey(typeof(MemberDeptInput), id);
            return obj;
        }

        public static MemberDeptInput GetMemberDeptInput(string emplid, string company, string dept, bool isVerify)
        {
            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                       new BinaryOperator("员工编号", emplid, BinaryOperatorType.Equal),
                       new BinaryOperator("可查公司名称", company, BinaryOperatorType.Equal),
                       new BinaryOperator("可查部门编号", dept, BinaryOperatorType.Equal),
                       new BinaryOperator("是验证录入", isVerify, BinaryOperatorType.Equal));

            XPCollection objset = new XPCollection(typeof(MemberDeptInput), criteria, new SortProperty("录入时间", SortingDirection.Ascending));

            if (objset.Count > 0)
            {
                return (MemberDeptInput)objset[0];
            }
            else
                return null;
        }

        #endregion

        #region GetMemberDeptInputs

        public static List<MemberDeptInput> GetMemberDeptInputs(string emplid, string company, bool isVerify)
        {
            List<MemberDeptInput> list = new List<MemberDeptInput>();

            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                       new BinaryOperator("员工编号", emplid, BinaryOperatorType.Equal),
                       new BinaryOperator("可查公司名称", company, BinaryOperatorType.Equal),
                       new BinaryOperator("是验证录入", isVerify, BinaryOperatorType.Equal));
            
            XPCollection objset = new XPCollection(typeof(MemberDeptInput), criteria, new SortProperty("录入时间", SortingDirection.Ascending));

            foreach (MemberDeptInput ms in objset)
            {
                list.Add(ms);                
            }
            return list;
        }
        #endregion

        #region GetEditingRows

        /// <summary>
        /// 获取正在录入的记录
        /// </summary>
        /// <param name="emplid"></param>
        /// <param name="isVerify"></param>
        /// <returns></returns>
        public static List<MemberDeptInput> GetEditingRows(string emplid, string company, bool isVerify)
        {
            List<MemberDeptInput> rows = new List<MemberDeptInput>();

            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                       new BinaryOperator("员工编号", emplid, BinaryOperatorType.Equal),
                       new BinaryOperator("可查公司名称", company, BinaryOperatorType.Equal),
                       new NullOperator("生效时间"),
                       new BinaryOperator("是验证录入", isVerify, BinaryOperatorType.Equal));

            XPCollection objset = new XPCollection(typeof(MemberDeptInput), criteria, new SortProperty("录入时间", SortingDirection.Ascending));

            foreach (MemberDeptInput input in objset)
            {
                rows.Add(input);
            }
            return rows;
        }
        #endregion

        #region GetEditingRow

        /// <summary>
        /// 获取正在录入的记录
        /// </summary>
        /// <param name="isVerify"></param>
        /// <returns></returns>
        public static MemberDeptInput GetEditingRow(string emplid, string company, string dept, bool isVerify)
        {
            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                       new BinaryOperator("员工编号", emplid, BinaryOperatorType.Equal),
                       new NullOperator("生效时间"),
                       new BinaryOperator("可查公司名称", company, BinaryOperatorType.Equal),
                       new BinaryOperator("可查部门编号", dept, BinaryOperatorType.Equal),
                       new BinaryOperator("是验证录入", isVerify, BinaryOperatorType.Equal));

            XPCollection objset = new XPCollection(typeof(MemberDeptInput), criteria, new SortProperty("录入时间", SortingDirection.Ascending));

            if (objset.Count > 0)
            {
                return (MemberDeptInput)objset[0];
            }
            else
                return null;
        }
        #endregion

        #region ClearMemberDeptInput
        
        //清除指定期号的录入记录(只能清除未生效的记录)
        public void ClearMemberDeptInput(string emplid)
        {
            string sql = "DELETE FROM 会员_部门_录入 WHERE (员工编号 = '" + emplid + "') AND 生效时间 IS NULL";
            using (SqlConnection connection = new SqlConnection(MyHelper.GetConnectionString()))
            {
                YiKang.Data.SqlHelper.ExecuteNonQuery(connection, System.Data.CommandType.Text, sql);
                
            }
        }
        #endregion

        #region AddMemberDeptInput

        public static MemberDeptInput AddMemberDeptInput(string emplid, string company, string dept, bool isVerify)
        {
            return AddMemberDeptInput(emplid, company, dept, isVerify, false);
        }

        public static MemberDeptInput AddMemberDeptInput(string emplid, string company, string dept, bool isVerify, bool copyEffective)
        {
            MemberDeptInput item = GetMemberDeptInput(emplid, company, dept, isVerify);
            if (item == null)
            {
                item = new MemberDeptInput();

                if (copyEffective)
                {
                    //将当前执行的标准带过来
                    MemberDept effectiveMemberDept = MemberDept.GetMemberDept(emplid, company, dept);
                    if (effectiveMemberDept != null)
                    {
                        item.CopyEffective = copyEffective;
                        effectiveMemberDept.CopyWatchMember(item);
                    }
                }

                item.标识 = Guid.NewGuid();
                item.员工编号 = emplid;
                item.可查公司名称 = company;
                item.可查部门编号 = dept;
                item.是验证录入 = isVerify;
                item.录入人 = "   ";
                item.录入时间 = DateTime.Now;

                item.Save();                
            }            
            return item;
        }
        #endregion

        #region UpdateToFormalTable
        //更新到正式表
        public void UpdateToFormalTable()
        {
            if (另一人录入的记录 == null || this.内容不同的字段.Count > 0) return;

            MemberDept m = MemberDept.AddMemberDept(this.员工编号, this.可查公司名称, this.可查部门编号);
            //更新生效标记
            if (!this.已生效)
            {
                this.生效时间 = DateTime.Now;
                this.Save();

                MemberDeptInput opposite = 另一人录入的记录;
                opposite.生效时间 = DateTime.Now;
                opposite.Save();
            }
        }
        #endregion

        #region OnSaving

        protected override void OnSaving()
        {
            if (string.IsNullOrEmpty(this.员工编号)) throw new Exception("员工编号不能为空");
            if (string.IsNullOrEmpty(this.可查公司名称)) throw new Exception("可查公司名称不能为空");
            if (string.IsNullOrEmpty(this.可查部门编号)) throw new Exception("可查部门编号不能为空");

            MemberDeptInput found = GetMemberDeptInput(this.员工编号, this.可查公司名称, this.可查部门编号, this.是验证录入);
            if (found != null && found.标识 != this.标识)
                throw new Exception("已存在这个权限，不能重复创建。");
            else
                base.OnSaving();

            contentDifferentFields = null;
            MEMBER_DEPT_INPUT_CACHE.Set(CacheKey, this, TimeSpan.FromHours(1));
        }
        #endregion        

        #region OnDeleting

        protected override void OnDeleting()
        {
            base.OnDeleting();
            MEMBER_DEPT_INPUT_CACHE.Remove(CacheKey);   
        }
        #endregion

        #region CompareInputContent
        //比较录入的内容
        public void CompareInputContent()
        {
            contentDifferentFields = null;
            GetModifiyFields();
        }
        #endregion

        #region GetModifiyFields

        public void GetModifiyFields()
        {
            if (contentDifferentFields == null)
            {
                contentDifferentFields = new List<ModifyField>();

                if (另一人录入的记录 != null)
                {
                    contentDifferentFields = MyHelper.GetModifyFields(this, 另一人录入的记录);
                }

            }                
        }
        #endregion

        #region 内容不同的字段

        List<ModifyField> contentDifferentFields = null;
        [Browsable(false)]
        public List<ModifyField> 内容不同的字段
        {
            get
            {
                if (contentDifferentFields == null) GetModifiyFields();
                return contentDifferentFields;
            }
        }

        #endregion

        #region 另一人录入的记录

        MemberDeptInput anotherInput = null;
        [Browsable(false)]
        public MemberDeptInput 另一人录入的记录
        {
            get
            {
                if (anotherInput == null)
                {
                    anotherInput = GetMemberDeptInput(this.员工编号, this.可查公司名称, this.可查部门编号, !this.是验证录入);
                }
                return anotherInput;
            }
        }
        #endregion

        #region 另一人已录入

        public bool 另一人已录入
        {
            get
            {
                return 另一人录入的记录 != null;
            }
        }
        #endregion

        #region 已生效

        public bool 已生效
        {
            get
            {
                return this.生效时间 != DateTime.MinValue;
            }
        }
        #endregion

        #region 是新表

        [Browsable(false)]
        public bool 是新表
        {
            get
            {
                return this.录入时间.Year < 2010;
            }
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

        #region CacheKey

        string CacheKey
        {
            get { return this.员工编号 + "$$" + this.可查公司名称 + "$$" + this.可查部门编号 + "$$" + this.是验证录入; }
        }

        #endregion

        #region 部门
        
        public string 部门
        {
            get
            {
                if (员工信息 != null)
                {
                    return 员工信息.机构名称;
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

        [NonPersistent]
        public bool CopyEffective { get; set; }

        public override string ToString()
        {
            DeptInfo dept = DeptInfo.Get(可查部门编号);
            if (dept != null)
                return dept.部门名称;
            else
            {
                if (可查部门编号 == "所有部门")
                    return "所有部门";
                else
                    return "";
            }
        }
    }
}
