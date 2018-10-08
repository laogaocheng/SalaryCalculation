using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using log4net;
using DevExpress.Data.Filtering;
using YiKang;
using Hwagain.Components;
using System.Data.OleDb;

namespace Hwagain.SalaryCalculation.Components
{
    public partial class EmployeeInfo
    {
        static readonly ILog log = LogManager.GetLogger(typeof(EmployeeInfo));
        public static ICache<string, EmployeeInfo> EMPLOYEEINFO_CACHE = MemoryCache<string, EmployeeInfo>.Instance;

        #region GetEmployeeInfo
        /// <summary>
        /// 通过 Id 获取
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static EmployeeInfo GetEmployeeInfo(Guid id)
        {
            EmployeeInfo obj = (EmployeeInfo)MyHelper.XpoSession.GetObjectByKey(typeof(EmployeeInfo), id);
            return obj;
        }

        public static EmployeeInfo GetEmployeeInfo(string empNo)
        {
            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                       new BinaryOperator("员工编号", empNo, BinaryOperatorType.Equal)
                       );

            XPCollection objset = new XPCollection(MyHelper.XpoSession, typeof(EmployeeInfo), criteria, new SortProperty("创建时间", SortingDirection.Ascending));

            if (objset.Count > 0)
            {
                return (EmployeeInfo)objset[0];
            }
            else
                return null;
        }

        #endregion

        #region GetEmployeeInfoByName

        public static EmployeeInfo GetEmployeeInfoByName(string name)
        {
            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                       new BinaryOperator("姓名", name, BinaryOperatorType.Equal)
                       );

            XPCollection objset = new XPCollection(MyHelper.XpoSession, typeof(EmployeeInfo), criteria, new SortProperty("创建时间", SortingDirection.Ascending));

            if (objset.Count > 0)
            {
                return (EmployeeInfo)objset[0];
            }
            else
                return null;
        }
        #endregion

        #region GetEmployeeInfoByCID

        public static EmployeeInfo GetEmployeeInfoByCID(string cid)
        {
            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                       new BinaryOperator("身份证号", cid, BinaryOperatorType.Equal)
                       );

            XPCollection objset = new XPCollection(MyHelper.XpoSession, typeof(EmployeeInfo), criteria, new SortProperty("创建时间", SortingDirection.Ascending));

            if (objset.Count > 0)
            {
                return (EmployeeInfo)objset[0];
            }
            else
                return null;
        }
        #endregion

        #region GetFromCache

        public static EmployeeInfo GetFromCache(string emplid)
        {
            return EMPLOYEEINFO_CACHE.Get(emplid, () => GetEmployeeInfo(emplid), TimeSpan.FromHours(4));
        }
        #endregion

        #region GetDeptManagers
        /// <summary>
        /// 获取部门主管
        /// </summary>
        /// <returns></returns>
        public static List<EmployeeInfo> GetDeptManagers()
        {
            List<EmployeeInfo> list = new List<EmployeeInfo>();

            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                       new BinaryOperator("职务代码", "10591", BinaryOperatorType.Equal),
                       new BinaryOperator("状态", "A", BinaryOperatorType.Equal),
                       new BinaryOperator("职务等级", "0007", BinaryOperatorType.Greater)
                       );

            XPCollection objset = new XPCollection(MyHelper.XpoSession, typeof(EmployeeInfo), criteria, new SortProperty("员工编号", SortingDirection.Ascending));

            foreach (EmployeeInfo item in objset)
            {
                list.Add(item);
            }

            return list;
        }
        #endregion

        #region Search

        public static List<EmployeeInfo> Search(string name)
        {
            return Search(name,  true);
        }

        public static List<EmployeeInfo> Search(string name, bool onlyOnJob)
        {
            List<EmployeeInfo> list = new List<EmployeeInfo>();

            GroupOperator criteria = criteria = new GroupOperator(GroupOperatorType.And); 

            //只要在职员工
            if (onlyOnJob) criteria.Operands.Add(new BinaryOperator("状态", "A", BinaryOperatorType.Equal));
            if (!string.IsNullOrEmpty(name))
            {   
                criteria.Operands.Add(new BinaryOperator("姓名", String.Format("%{0}%", name), BinaryOperatorType.Like));
            }

            XPCollection objset = null;

            objset = new XPCollection(typeof(EmployeeInfo), criteria, new SortProperty("薪资组", SortingDirection.Ascending), new SortProperty("职务等级", SortingDirection.Ascending), new SortProperty("员工序号", SortingDirection.Ascending), new SortProperty("创建时间", SortingDirection.Ascending));

            foreach (EmployeeInfo item in objset)
            {
                list.Add(item);
            }
            return list;
        }
        #endregion

        #region GetEmployeeList

        public static List<EmployeeInfo> GetEmployeeList(List<string> companyCodeList, List<string> gradeCodeList, bool onlyOnJob)
        {
            List<EmployeeInfo> list = new List<EmployeeInfo>();

            GroupOperator criteria = criteria = new GroupOperator(GroupOperatorType.And);

            //只要在职员工
            if (onlyOnJob) criteria.Operands.Add(new BinaryOperator("状态", "A", BinaryOperatorType.Equal));
            if (companyCodeList != null) criteria.Operands.Add(new InOperator("公司", companyCodeList));
            if (gradeCodeList != null) criteria.Operands.Add(new InOperator("职务等级", gradeCodeList));
            
            XPCollection objset = null;

            objset = new XPCollection(typeof(EmployeeInfo), criteria, new SortProperty("薪资组", SortingDirection.Ascending), new SortProperty("职务等级", SortingDirection.Ascending), new SortProperty("员工序号", SortingDirection.Ascending), new SortProperty("创建时间", SortingDirection.Ascending));

            foreach (EmployeeInfo item in objset)
            {
                list.Add(item);
            }
            return list;
        }


        public static List<EmployeeInfo> GetEmployeeList(DeptInfo dept, bool onlyOnJob)
        {
            List<EmployeeInfo> list = new List<EmployeeInfo>();

            GroupOperator criteria = criteria = new GroupOperator(GroupOperatorType.And);

            //只要在职员工
            if (onlyOnJob) criteria.Operands.Add(new BinaryOperator("状态", "A", BinaryOperatorType.Equal));
            if (dept != null) criteria.Operands.Add(new BinaryOperator("部门", dept.部门编号, BinaryOperatorType.Equal));

            XPCollection objset = null;

            objset = new XPCollection(typeof(EmployeeInfo), criteria, new SortProperty("薪资组", SortingDirection.Ascending), new SortProperty("职务等级", SortingDirection.Ascending), new SortProperty("员工序号", SortingDirection.Ascending), new SortProperty("创建时间", SortingDirection.Ascending));

            foreach (EmployeeInfo item in objset)
            {
                list.Add(item);
            }
            return list;
        }

        public static List<EmployeeInfo> GetEmployeeList(string company_code, string grade, bool onlyOnJob)
        {
            List<EmployeeInfo> list = new List<EmployeeInfo>();

            GroupOperator criteria = criteria = new GroupOperator(GroupOperatorType.And);

            //只要在职员工
            if (onlyOnJob) criteria.Operands.Add(new BinaryOperator("状态", "A", BinaryOperatorType.Equal));
            if (company_code != null) criteria.Operands.Add(new BinaryOperator("公司", company_code, BinaryOperatorType.Equal));
            if (grade != null) criteria.Operands.Add(new BinaryOperator("职等", grade, BinaryOperatorType.Equal));

            XPCollection objset = null;

            objset = new XPCollection(typeof(EmployeeInfo), criteria, new SortProperty("部门", SortingDirection.Ascending), new SortProperty("职务等级", SortingDirection.Ascending), new SortProperty("员工序号", SortingDirection.Ascending), new SortProperty("创建时间", SortingDirection.Ascending));

            foreach (EmployeeInfo item in objset)
            {
                list.Add(item);
            }
            return list;
        }
        #endregion

        #region GetHasPayEmployeeList

        //获取有工资的员工（有些人虽然已经离职，但是还有未结算的工资）
        public static List<EmployeeInfo> GetHasPayEmployeeList()
        {
            List<EmployeeInfo> list = new List<EmployeeInfo>();

            GroupOperator criteria = criteria = new GroupOperator(GroupOperatorType.And);

            criteria.Operands.Add(new BinaryOperator("薪资组", "NO PAY", BinaryOperatorType.NotEqual));
            criteria.Operands.Add(new BinaryOperator("薪资组", "NO_PAY", BinaryOperatorType.NotEqual));

            XPCollection objset = new XPCollection(MyHelper.XpoSession, typeof(EmployeeInfo), criteria, new SortProperty("薪资组", SortingDirection.Ascending), new SortProperty("职务等级", SortingDirection.Ascending), new SortProperty("员工序号", SortingDirection.Ascending), new SortProperty("创建时间", SortingDirection.Descending));

            foreach (EmployeeInfo item in objset)
            {
                list.Add(item);
            }
            return list;
        }
        #endregion

        #region GetGuanPeiShengList

        //获取管培生列表
        public static List<EmployeeInfo> GetGuanPeiShengList(List<string> companyCodeList, bool onlyOnJob)
        {
            List<EmployeeInfo> list = new List<EmployeeInfo>();

            GroupOperator criteria = criteria = new GroupOperator(GroupOperatorType.And);

            //只要在职员工
            if (onlyOnJob) criteria.Operands.Add(new BinaryOperator("状态", "A", BinaryOperatorType.Equal));
            if (companyCodeList != null) criteria.Operands.Add(new InOperator("公司", companyCodeList));

            criteria.Operands.Add(new BinaryOperator("是管培生", true, BinaryOperatorType.Equal));

            XPCollection objset = null;

            objset = new XPCollection(typeof(EmployeeInfo), criteria, new SortProperty("薪资组", SortingDirection.Ascending), new SortProperty("职务等级", SortingDirection.Ascending), new SortProperty("员工序号", SortingDirection.Ascending), new SortProperty("创建时间", SortingDirection.Ascending));

            foreach (EmployeeInfo item in objset)
            {
                list.Add(item);
            }
            return list;
        }
        #endregion

        #region GetAll

        public static List<EmployeeInfo> GetAll()
        {
            List<EmployeeInfo> list = new List<EmployeeInfo>();

            XPCollection objset = new XPCollection(MyHelper.XpoSession, typeof(EmployeeInfo), null, new SortProperty("姓名", SortingDirection.Ascending), new SortProperty("出生日期", SortingDirection.Ascending));

            foreach (EmployeeInfo order in objset)
            {
                list.Add(order);
            }
            return list;
        }
        #endregion

        private void GetEmployeeBaseInfo()
        {
            OleDbConnection conn = new OleDbConnection(MyHelper.GetPsConnectionString());
            using (conn)
            {
                OleDbDataReader rs = null;
                try
                {
                    conn.Open();
                    using (OleDbCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "SELECT B.HIGHEST_EDUC_LVL, B.BIRTHPLACE FROM sysadm.PS_C_EMP_BASE_VW B WHERE EMPLID='" + this.员工编号 + "'";
                        rs = cmd.ExecuteReader();
                        if (rs.Read())
                        {
                            List<KeyValue> list = KeyValue.GetList(PsHelper.学历);
                            KeyValue kv = list.Find(a => a.值 == (string)rs["HIGHEST_EDUC_LVL"]);
                            if (kv != null) xueli = kv.键;
                            jiguan = (string)rs["BIRTHPLACE"];
                        }
                    }
                }
                finally
                {
                    if (rs != null) rs.Close();
                    conn.Close();
                }
            }
        }

        #region AddEmployeeInfo

        public static EmployeeInfo AddEmployeeInfo(string empNo)
        {
            EmployeeInfo emp = GetEmployeeInfo(empNo);
            if (emp == null)
            {
                emp = new EmployeeInfo();
                emp.员工编号 = empNo;
                emp.创建时间 = DateTime.Now;
                emp.Save();
            }
            return emp;
        }
        #endregion

        #region SychEmployeeInfo

        public static void SychEmployeeInfo()
        {
            foreach (EmpInfo emp in EmpInfo.GetAll())
            {
                EmployeeInfo empInfo = AddEmployeeInfo(emp.员工编号);

                empInfo.姓名 = emp.姓名;
                empInfo.出生日期 = emp.出生日期;
                empInfo.性别 = emp.性别;
                empInfo.身份证号 = emp.身份证号;
                empInfo.公司 = emp.公司;
                empInfo.部门 = emp.部门;
                empInfo.状态 = emp.状态;
                empInfo.职位代码 = emp.职位代码;
                empInfo.职务代码 = emp.职务代码;
                empInfo.职务等级 = emp.职务等级;

                empInfo.集合 = emp.集合;
                empInfo.薪资体系 = emp.薪资体系;
                empInfo.薪等 = emp.薪等;
                empInfo.薪级 = emp.薪级;
                empInfo.薪资组 = emp.薪资组;
                empInfo.上个月薪资组 = emp.上个月薪资组;

                empInfo.银行账号 = emp.银行账号;
                empInfo.帐户名称 = emp.帐户名称;

                empInfo.财务公司 = emp.财务公司;
                empInfo.财务部门 = emp.财务部门;
                empInfo.财务部门序号 = emp.财务部门序号;
                empInfo.员工序号 = emp.员工序号;

                empInfo.职等 = GetGrade(empInfo);
                empInfo.是管培生 = PsHelper.CheckIsGuanPeiSheng(emp.员工编号);
                empInfo.离职时间 = emp.离职时间;

                empInfo.上次同步时间 = DateTime.Now;
                empInfo.Save();
            }
        }

        #endregion

        #region GetGrade

        public static string GetGrade(EmployeeInfo empInfo)
        {
            //"003": //广西华劲竹林发展有限公司
            //"005": //赣州华劲竹林发展有限公司                
            if (empInfo.公司 == "003" || empInfo.公司 == "005")
                return GetGrade2(empInfo);
            else
                return GetGrade1(empInfo);
        }

        public static string GetGrade1(EmployeeInfo empInfo)
        {
            //有二级分类的职务等级
            string JOB_HAS_SECONDARY = "主任|副主任|工程师|班长|";
            try
            {
                if (empInfo.职等名称 == null) return null;

                //职等默认等于职务等级
                string grade = GetGrade(empInfo.职等名称);

                if (JOB_HAS_SECONDARY.IndexOf(grade + "|") == -1)
                    return grade;
                else
                {
                    if (empInfo.所在部门 == null) return grade;

                    DeptInfo dept = empInfo.所在部门.部门;
                    //如果找不到部门
                    if (dept == null) return grade;

                    //获取部门板块属性
                    string fun = dept.职能类型;

                    //获取班长岗位级别
                    string level = "";
                    if (empInfo.所在部门.车间 != null)
                    {
                        MonitorLevel mv = MonitorLevel.Get(empInfo.所在部门.车间.部门编号, empInfo.职务代码);
                        if (mv != null) level = mv.级别名称;
                    }

                    if (level == "")
                        return fun + grade;
                    else
                        return level + grade;
                }
            }
            catch(Exception err)
            {
                Common.WriteLog(Environment.CurrentDirectory + "\\LogFiles\\Error.log", err.ToString());                
            }
            return null;
        }
        public static string GetGrade(string s)
        {
            //string grade = sr.职等名称.Replace("级", "");
            int pos = s.LastIndexOf("级");
            if (pos < s.Length - 1)
                return s;
            else
            {
                return s.Substring(0, pos);
            }
        }
        public static string GetGrade2(EmployeeInfo empInfo)
        {
            //有二级分类的职务等级
            string JOB_HAS_SECONDARY = "经理|副经理|科员|";
            try
            {
                if (empInfo.职等名称 == null) return null;

                //职等默认等于职务等级
                string grade = GetGrade(empInfo.职等名称);

                if (JOB_HAS_SECONDARY.IndexOf(grade + "|") == -1)
                    return grade;
                else
                {
                    DeptInfo dept = empInfo.所在部门.部门;
                    //如果找不到部门
                    if (dept == null) return grade;

                    //获取部门板块属性
                    string fun = dept.职能类型;


                    if (fun == "部门")
                        return "部门" + grade;
                    else
                    {
                        if (grade == "科员")
                            return "林场科员";
                        else
                            return "经营区" + grade;
                    }
                }
            }
            catch (Exception err)
            {
                Common.WriteLog(Environment.CurrentDirectory + "\\LogFiles\\Error.log", err.ToString());
            }
            return null;
        }

        #endregion

        #region OnSaved

        protected override void OnSaved()
        {
            EMPLOYEEINFO_CACHE.Set(this.员工编号, this, TimeSpan.FromHours(4));
            base.OnSaved();
        }
        #endregion

        #region OnLoaded

        protected override void OnLoaded()
        {
            //缓存
            EMPLOYEEINFO_CACHE.Set(this.员工编号, this, TimeSpan.FromHours(1));
            base.OnLoaded();
        }
        #endregion

        #region OnDeleting

        protected override void OnDeleting()
        {
            base.OnDeleting();
            EMPLOYEEINFO_CACHE.Remove(员工编号);
        }
        #endregion

        #region 公司名称

        public string 公司名称
        {
            get
            {
                CompanyInfo c = CompanyInfo.Get(this.公司);
                if (c == null)
                    return "";
                else
                    return c.公司简称;
            }
        }
        #endregion

        #region 所在部门

        DeptInfo deptInfo = null;
        public DeptInfo 所在部门
        {
            get
            {
                if (deptInfo == null) deptInfo = DeptInfo.Get(this.部门);
                return deptInfo;
            }
        }
        #endregion

        #region 机构名称

        public string 机构名称
        {
            get
            {
                if (所在部门 == null)
                    return "";
                else
                {
                    if(所在部门.车间 == null)
                        return 所在部门.部门名称;
                    else
                        return 所在部门.部门.部门名称 + "/" + 所在部门.车间.部门名称;
                }
            }
        }

        #endregion

        #region 部门名称

        public string 部门名称
        {
            get
            {
                if (所在部门 == null)
                    return "";
                else
                    return 所在部门.部门名称;
            }
        }
        #endregion        

        #region 所在部门职能类型

        public string 所在部门职能类型
        {
            get
            {
                if (所在部门 == null)
                    return "";
                else
                    return 所在部门.职能类型;
            }
        }
        #endregion

        #region 机构序号

        public int 机构序号
        {
            get
            {
                if (所在部门 == null)
                    return 10000;
                else
                {
                    if (所在部门.车间 == null)
                        return 所在部门.部门序号;
                    else
                        return 所在部门.车间.部门序号;
                }
            }
        }

        #endregion

        #region 部门序号

        public int 部门序号
        {
            get
            {
                DeptInfo d = DeptInfo.Get(this.部门);
                if (d == null || d.所在部门 == null)
                    return 10000;
                else
                    return d.所在部门.部门序号;
            }
        }
        #endregion        

        #region 公司序号

        public int 公司序号
        {
            get
            {
                DeptInfo d = DeptInfo.Get(this.部门);
                if (d == null || d.公司 == null)
                    return 999;
                else
                {
                    return d.公司.部门序号;
                }
            }
        }
        #endregion

        #region 职等名称

        public string 职等名称
        {
            get
            {
                return PsHelper.GetSupvsrLvDescr(this.职务等级);
            }
        }
        #endregion        

        #region 职务名称

        public string 职务名称
        {
            get
            {
                return PsHelper.GetJobNameFromCache(this.职务代码);
            }
        }
        #endregion        

        #region 薪资组名称

        public string 薪资组名称
        {
            get
            {
                PayGroup group = PayGroup.Get(this.薪资组);
                if (group != null)
                    return group.中文名;
                else
                    return "";

            }
        }
        #endregion        

        #region 薪等名称

        public string 薪等名称
        {
            get
            {
                SalaryGrade grade = SalaryGrade.当前薪等表.Find(a => a.集合 == this.集合 && a.薪酬体系 == this.薪资体系 && a.薪等编号 == this.薪等);
                if (grade != null) return grade.薪等名称;
                return "";
            }
        }
        #endregion        

        #region 上月工资

        public PrivateSalary 上月工资
        {
            get
            {
                DateTime prevMonth = DateTime.Today.AddMonths(-1);
                return PrivateSalary.GetPrivateSalary(this.员工编号, prevMonth.Year, prevMonth.Month);
            }
        }
        #endregion

        #region 工龄

        decimal workAge = -1;
        public decimal 工龄
        {
            get
            {
                if (workAge == -1) workAge = PsHelper.GetWorkAge(this.员工编号, DateTime.Today);
                return workAge;
            }
        }
        #endregion

        #region 年龄

        public int 年龄
        {
            get
            {
                TimeSpan ts = DateTime.Today - this.出生日期;
                return (int)(ts.TotalDays / (double)365.0);
            }
        }
        #endregion

        #region 职务开始日期

        DateTime jobEntryDate = DateTime.MinValue;
        public DateTime 职务开始日期
        {
            get
            {
                if (jobEntryDate == DateTime.MinValue) jobEntryDate = PsHelper.GetJobEntryDate(this.员工编号, this.职务代码);
                return jobEntryDate;
            }
        }

        #endregion

        #region 任职时间

        public string 任职时间
        {
            get
            {
                DateTime end;
                DateTime start = PsHelper.GetJobLvlEntryDate(this.员工编号, this.职务等级, out end);
                if (start == DateTime.MinValue)
                    return "";
                else
                {
                    TimeSpan ts = end - start;
                    decimal months = (decimal)ts.TotalDays / (decimal)30.5;
                    return MyHelper.ConvertMonthToChinese(Convert.ToInt32(Math.Truncate(months)));
                }
            }
        }
        #endregion

        #region 华劲工龄

        public string 华劲工龄
        {
            get
            {
                return MyHelper.ConvertMonthToChinese(Convert.ToInt32(Math.Truncate(工龄)));
            }
        }

        #endregion

        #region 学历

        string xueli = null;
        string jiguan = null;
        [NonPersistent]
        public string 学历
        {
            get
            {
                if (xueli == null) GetEmployeeBaseInfo();
                return xueli;
            }
        }

        #endregion

        #region 籍贯
        [NonPersistent]
        public string 籍贯
        {
            get
            {
                if (jiguan == null) GetEmployeeBaseInfo();
                return jiguan;
            }
        }
        #endregion

        [NonPersistent]
        public bool 标记 { get; set; }
    }
}