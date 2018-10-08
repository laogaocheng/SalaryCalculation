using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using log4net;
using DevExpress.Data.Filtering;
using System.Data.SqlClient;

namespace Hwagain.SalaryCalculation.Components
{
    public partial class PrivateSalary
    {
        static readonly ILog log = LogManager.GetLogger(typeof(PrivateSalary));
        SalaryResult salaryResult = null;

        #region OnLoaded

        protected override void OnLoaded()
        {
            if (string.IsNullOrEmpty(this.职务名称))
            {
                this.职务名称 = PsHelper.GetValue(PsHelper.职务代码, this.基础工资表.职务代码);
                this.Save();
            }
            salaryResult = SalaryResult.GetFromCache(this.员工编号, this.年度, this.月份);
            base.OnLoaded();
        }
        #endregion

        #region GetPrivateSalary
        /// <summary>
        /// 通过 Id 获取
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static PrivateSalary GetPrivateSalary(Guid id)
        {
            PrivateSalary obj = (PrivateSalary)MyHelper.XpoSession.GetObjectByKey(typeof(PrivateSalary), id);
            return obj;
        }

        public static PrivateSalary GetPrivateSalary(string empNo, int year, int month)
        {
            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                       new BinaryOperator("年度", year, BinaryOperatorType.Equal),
                       new BinaryOperator("月份", month, BinaryOperatorType.Equal),
                       new BinaryOperator("员工编号", empNo, BinaryOperatorType.Equal)
                       );

            XPCollection objset = new XPCollection(MyHelper.XpoSession, typeof(PrivateSalary), criteria, new SortProperty("创建时间", SortingDirection.Descending));

            if (objset.Count > 0)
            {
                return (PrivateSalary)objset[0];
            }
            else
                return null;
        }

        #endregion

        #region GetPrivateSalarys

        public static List<PrivateSalary> GetPrivateSalarys(string payGroup, string calId)
        {
            List<PrivateSalary> list = new List<PrivateSalary>();

            GroupOperator criteria = new GroupOperator(GroupOperatorType.And);
            if (payGroup != null) criteria.Operands.Add(new BinaryOperator("薪资组", payGroup, BinaryOperatorType.Equal));
            if (calId != null) criteria.Operands.Add(new BinaryOperator("日历组", calId, BinaryOperatorType.Equal));

            XPCollection objset = new XPCollection(MyHelper.XpoSession, typeof(PrivateSalary), criteria, new SortProperty("职级工资", SortingDirection.Descending), new SortProperty("姓名", SortingDirection.Ascending));

            foreach (PrivateSalary item in objset)
            {
                list.Add(item);
            }
            return list;
        }

        public static List<PrivateSalary> GetPrivateSalarys(int year, int month, string company, string payGroup)
        {
            List<PrivateSalary> list = new List<PrivateSalary>();

            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                       new BinaryOperator("年度", year, BinaryOperatorType.Equal),
                       new BinaryOperator("月份", month, BinaryOperatorType.Equal)
                       );

            if (payGroup != null) criteria.Operands.Add(new BinaryOperator("薪资组", payGroup, BinaryOperatorType.Equal));

            XPCollection objset = new XPCollection(MyHelper.XpoSession, typeof(PrivateSalary), criteria, new SortProperty("职级工资", SortingDirection.Descending));

            foreach (PrivateSalary item in objset)
            {
                if (company != null)
                {
                    if (item.基础工资表.财务公司 == company) list.Add(item);
                }
                else
                    list.Add(item);
            }

            return list;
        }

        #endregion

        #region AddPrivateSalary

        public static PrivateSalary AddPrivateSalary(string empNo, int year, int month, string payGroup, string calRunId)
        {
            PrivateSalary result = GetPrivateSalary(empNo, year, month);
            if (result == null)
            {
                result = new PrivateSalary();

                result.标识 = Guid.NewGuid();
                result.员工编号 = empNo;
                result.年度 = year;
                result.月份 = month;
                if (payGroup != null) result.薪资组 = payGroup.Trim();
                result.日历组 = calRunId.Trim();

                result.创建时间 = DateTime.Now;

                result.Save();
            }

            return result;
        }
        #endregion

        #region ClearPrivateSalary

        //删除
        public static void ClearPrivateSalary(string calRunId, string payGroup)
        {

            string condition = String.Format(" AND 薪资组='{0}'", payGroup);

            string sql = String.Format("DELETE FROM 工资表 WHERE 日历组 = '{0}' {1}", calRunId, condition);

            using (SqlConnection connection = new SqlConnection(MyHelper.GetConnectionString()))
            {
                YiKang.Data.SqlHelper.ExecuteNonQuery(connection, System.Data.CommandType.Text, sql);
            }
        }
        #endregion

        #region GetLastestDate
        //获取最近发放的日期
        public static DateTime GetLastestDate()
        {
            string sql = "SELECT TOP 1 年度, 月份  FROM 工资表 ORDER BY 年度 DESC, 月份 DESC";
            SqlConnection conn = new SqlConnection(MyHelper.GetConnectionString());
            using (conn)
            {
                SqlDataReader rs = null;
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = sql;
                        rs = cmd.ExecuteReader();
                        if (rs.Read())
                        {
                            int year = Convert.ToInt32(rs["年度"]);
                            int month = Convert.ToInt32(rs["月份"]);
                            return new DateTime(year, month, 1);
                        }
                    }
                }
                finally
                {
                    if (rs != null) rs.Close();
                    conn.Close();
                }

                return DateTime.MinValue;
            }
        }
        #endregion

        #region GetPrivateSalarysByGrade
        public static List<PrivateSalary> GetPrivateSalarysByGrade(int year, int month, List<string> companyList, List<string> grades)
        {
            List<PrivateSalary> list = new List<PrivateSalary>();

            XPQuery<PrivateSalary> privateSalarys = MyHelper.XpoSession.Query<PrivateSalary>();
            XPQuery<EmployeeInfo> employees = MyHelper.XpoSession.Query<EmployeeInfo>();

            var l = from s in privateSalarys
                    where (s.年度 == year && s.月份 == month && (grades == null || grades.Contains(s.评定职等)) && (companyList == null || companyList.Contains(s.薪酬体系)))
                    select s;

            foreach (PrivateSalary item in l)
            {
                list.Add(item);
            }
            return list;
        }
        #endregion

        #region GetPrivateSalarysOfTrainee
        //获取管培生工资表
        public static List<PrivateSalary> GetPrivateSalarysOfTrainee(int year, int month, List<string> companyList, List<string> grades)
        {
            List<PrivateSalary> list = new List<PrivateSalary>();

            XPQuery<PrivateSalary> privateSalarys = MyHelper.XpoSession.Query<PrivateSalary>();
            XPQuery<EmployeeInfo> employees = MyHelper.XpoSession.Query<EmployeeInfo>();

            var l = from s in privateSalarys
                    join e in employees on s.员工编号 equals e.员工编号
                    where (e.是管培生 && s.年度 == year && s.月份 == month && (grades == null || grades.Contains(s.评定职等)) && (companyList == null || companyList.Contains(s.薪酬体系)))
                    select s;

            foreach (PrivateSalary item in l)
            {
                list.Add(item);
            }
            return list;
        }
        #endregion

        #region GetMonthlySalaryItems
        //获取职级工资项
        static List<decimal> GetMonthlySalaryItems(string emplid)
        {
            List<decimal> list = new List<decimal>();
            string sql = "SELECT 职级工资 FROM 工资表 where 员工编号='" + emplid + "' AND 职级工资 > 0 group by 职级工资 ";
            SqlConnection conn = new SqlConnection(MyHelper.GetConnectionString());
            using (conn)
            {
                SqlDataReader rs = null;
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = sql;
                        rs = cmd.ExecuteReader();
                        while (rs.Read())
                        {
                            decimal pay = Convert.ToDecimal(rs["职级工资"]);
                            list.Add(pay);
                        }
                    }
                }
                finally
                {
                    if (rs != null) rs.Close();
                    conn.Close();
                }

                return list;
            }
        }
        #endregion
        
        #region GetAdjustItems
        //获取工资调整明细
        public static List<PrivateSalary> GetAdjustItems(string emplid)
        {
            List<PrivateSalary> list = new List<PrivateSalary>();
            List<decimal> payItems = GetMonthlySalaryItems(emplid);

            XPQuery<PrivateSalary> privateSalarys = MyHelper.XpoSession.Query<PrivateSalary>();
            
            foreach (decimal item in payItems)
            {
                var l = (from s in privateSalarys
                        where (s.员工编号 == emplid && s.职级工资 == item)
                        orderby s.年度, s.月份
                        select s).Take(1);

                foreach(PrivateSalary p in l)
                    list.Add(p);
            }
            return list.OrderByDescending(a=>a.年度).ThenByDescending(a=>a.月份).ToList();
        }
        #endregion

        #region 基础工资表
        [NonPersistent]
        public SalaryResult 基础工资表
        {
            get
            {
                if (salaryResult == null) salaryResult = SalaryResult.GetFromCache(this.员工编号, this.年度, this.月份);
                return salaryResult;
            }
            set { salaryResult = value; }
        }

        #endregion

        #region 法定工作日出勤天数

        public decimal 法定工作日出勤天数
        {
            get { return 基础工资表.法定工作日出勤天数; }
        }
        #endregion

        #region 法定工作日出勤工资

        public decimal 法定工作日出勤工资
        {
            get { return 基础工资表.法定工作日出勤工资; }
        }
        #endregion

        #region 法定节假日出勤天数

        public decimal 法定节假日出勤天数
        {
            get { return 基础工资表.法定节假日出勤天数; }
        }
        #endregion

        #region 法定节假日出勤工资

        public decimal 法定节假日出勤工资
        {
            get { return 基础工资表.法定节假日出勤工资; }
        }
        #endregion

        #region 工作日延长出勤小时数

        public decimal 工作日延长出勤小时数
        {
            get { return 基础工资表.工作日延长出勤小时数; }
        }
        #endregion

        #region 工作日延长工作出勤工资

        public decimal 工作日延长工作出勤工资
        {
            get { return 基础工资表.工作日延长工作出勤工资; }
        }
        #endregion

        #region 休息日出勤天数

        public decimal 休息日出勤天数
        {
            get { return 基础工资表.休息日出勤天数; }
        }
        #endregion

        #region 休息日出勤工资

        public decimal 休息日出勤工资
        {
            get { return 基础工资表.休息日出勤工资; }
        }
        #endregion

        #region 年休假工资

        public decimal 年休假工资
        {
            get { return 基础工资表.未休年休假工资; }
        }
        #endregion

        #region 企业排班天数

        public decimal 企业排班天数
        {
            get { return 基础工资表.企业排班天数; }
        }
        #endregion

        #region 实际出勤天数

        public decimal 实际出勤天数
        {
            get { return 基础工资表.实际出勤天数; }
        }
        #endregion

        #region 班别

        public string 班别
        {
            get { return 基础工资表.班别; }
        }
        #endregion

        #region 月满勤奖

        public decimal 月满勤奖
        {
            get { return 基础工资表.实得满勤奖; }
        }
        #endregion

        #region 奖项

        public decimal 奖项
        {
            get { return 基础工资表.奖项 + 其它奖项; }
        }
        #endregion

        #region 扣项

        public decimal 扣项
        {
            get { return 基础工资表.扣项 + 其它扣项; }
        }
        #endregion

        #region 综合考核工资

        public decimal 综合考核工资
        {
            get { return 基础工资表.综合考核工资; }
        }
        #endregion

        #region 住房公积金

        public decimal 住房公积金
        {
            get { return 基础工资表.住房公积金个人缴纳金额; }
        }
        #endregion

        #region 社保费用

        public decimal 社保费用
        {
            get { return 基础工资表.社保个人缴纳金额 - 住房公积金; }
        }
        #endregion

        #region 总代垫费用

        public decimal 总代垫费用
        {
            get { return 基础工资表.代垫费用 + 其它代垫费用; }
        }
        #endregion

        #region 已审核

        public bool 已审核
        {
            get
            {
                PayCheckRecord item = PayCheckRecord.GetPayCheckRecord(this.标识);
                if (item == null)
                    return false;
                else
                    return item.已审核;
            }
        }
        #endregion

        #region 人数

        public int 人数
        {
            get
            {
                return 1;
            }
        }
        #endregion

        #region 期间

        public string 期间
        {
            get
            {
                return String.Format("{0}年{1}月", this.年度, this.月份);
            }
        }
        #endregion

        #region 发放日期

        public DateTime 发放日期
        {
            get
            {
                //DateTime date = new DateTime(this.年度, this.月份, 15);
                //date = date.AddMonths(1);
                //return date;
                return DateTime.Today;
            }
        }
        #endregion

        #region 工资职级

        public string 工资职级
        {
            get
            {
                if (this.是标准职级工资)
                {
                    if (薪级名称 != null && 薪级名称.Length > 1)
                    {
                        return 薪级名称;
                    }
                    else
                    {
                        string salaryLevel = String.Format("{0}{1}", 薪等名称, 薪级名称);

                        int pos = salaryLevel.IndexOf('-');
                        if (pos != -1)
                            salaryLevel = salaryLevel.Substring(pos + 1);

                        return salaryLevel;
                    }
                }
                else
                {
                    return "";
                }
            }
        }
        #endregion

        #region 封闭工资个税

        public decimal 封闭工资个税
        {
            get
            {
                return this.个人所得税 - 基础工资表.个人所得税金额;
            }
        }
        #endregion

        #region 其它所得

        public decimal 其它所得
        {
            get
            {
                return 其它奖项 + 津贴补助 + 本月实得绩效工资额 + 放弃年休假补助;
            }
        }
        #endregion

        #region 其它扣款

        public decimal 其它扣款
        {
            get
            {
                return 其它扣项 + 其它代垫费用 + 个人费用;
            }
        }
        #endregion

        #region 本次发放工资

        public decimal 本次发放工资
        {
            get
            {
                return 封闭工资合计;
            }
        }
        #endregion

        #region 本次实发工资

        public decimal 本次实发工资
        {
            get
            {
                return 封闭工资合计 - 封闭工资个税 - 其它代垫费用;
            }
        }
        #endregion

        #region 补扣个人所得税

        public decimal 补扣个人所得税
        {
            get
            {
                return 封闭工资个税;
            }
        }
        #endregion

        #region 含年休假工资总额

        public decimal 含年休假工资总额
        {
            get
            {
                return this.基础工资表.设定工资 + this.年休假工资 + this.本次发放标准;
            }
        }
        #endregion

        #region 封闭工资账号

        PersonBankInfo bankInfo = null;
        public PersonBankInfo 封闭工资账号
        {
            get
            {
                if (bankInfo == null) bankInfo = PersonBankInfo.Get(this.员工编号, "B");
                if (bankInfo == null) bankInfo = PersonBankInfo.Get(this.员工编号, "A");
                return bankInfo;
            }
        }
        #endregion

        #region 银行名称

        public string 银行名称
        {
            get
            {
                if (封闭工资账号 != null)
                    return 封闭工资账号.银行名称;
                else
                    return null;
            }
        }
        #endregion

        #region 年薪

        [NonPersistent]
        public decimal 年薪
        {
            get
            {
                return 总工资 * 12;
            }
        }
        #endregion

        #region 提前借工资

        public PersonBorrow 提前借工资
        {
            get
            {
                return 借款记录.Find(a => a.项目 == "提前借工资");
            }
        }
        #endregion

        #region 个人专用车费用

        public PersonBorrow 个人专用车费用
        {
            get
            {
                return 借款记录.Find(a => a.项目 == "个人专用车费用");
            }
        }
        #endregion

        #region 月租房报销费用

        public PersonReimbursement 月租房报销费用
        {
            get
            {
                return 报销记录.Find(a => a.项目 == "月租房报销");
            }
        }
        #endregion

        #region 探亲飞机票

        public PersonReimbursement 探亲飞机票
        {
            get
            {
                return 报销记录.Find(a => a.项目 == "探亲飞机票");
            }
        }
        #endregion

        #region 借款记录

        List<PersonBorrow> personBorrowList = null;
        public List<PersonBorrow> 借款记录
        {
            get
            {
                if (personBorrowList == null) personBorrowList = PersonBorrow.GetMyBorrows(this.员工编号, this.年度, this.月份);
                return personBorrowList;
            }
        }
        #endregion

        #region 还款记录

        List<PersonRepayment> personRepaymentList = null;
        public List<PersonRepayment> 还款记录
        {
            get
            {
                if (personRepaymentList == null) personRepaymentList = PersonRepayment.GetPersonRepayments(this.员工编号, this.年度, this.月份);
                return personRepaymentList;
            }
        }
        #endregion

        #region 报销记录

        List<PersonReimbursement> personReimbursement = null;
        public List<PersonReimbursement> 报销记录
        {
            get
            {
                if (personReimbursement == null) personReimbursement = PersonReimbursement.GetPersonReimbursements(this.员工编号, this.年度, this.月份);
                return personReimbursement;
            }
        }
        #endregion

        #region 执行绩效工资

        EffectivePerformanceSalary effectivePerformanceSalary = null;
        public EffectivePerformanceSalary 执行绩效工资
        {
            get
            {
                if (effectivePerformanceSalary == null)
                {
                    effectivePerformanceSalary = EffectivePerformanceSalary.GetEffective(this.员工编号, this.年度, this.月份);
                }
                return effectivePerformanceSalary;
            }
        }
        #endregion

        #region 约定绩效工资

        PerformanceSalary performanceSalary = null;
        public PerformanceSalary 约定绩效工资
        {
            get
            {
                if (performanceSalary == null)
                {
                    performanceSalary = PerformanceSalary.GetEffective(this.员工编号, new DateTime(this.年度, this.月份, 1));
                    if (performanceSalary != null) performanceSalary.职级工资 = this.职级工资;
                }
                return performanceSalary;
            }
        }
        #endregion

        #region 总工资降级

        public decimal 总工资降级
        {
            get
            {
                //2017-9-25 改。工资降级该从PS直接读取工资降级数据后计算后已经与封闭合并在一起
                decimal x = this.工资降级; // + this.基础工资表.工资降级;
                return x < 0 ? 0 : x;
            }
        }
        #endregion

        #region 总出勤工资

        public decimal 总出勤工资
        {
            get
            {
                return this.封闭出勤工资 + this.基础工资表.出勤工资;
            }
        }
        #endregion

        #region 总补助工资

        public decimal 总补助工资
        {
            get
            {
                return this.津贴补助 + this.基础工资表.津贴补助;
            }
        }
        #endregion

        #region 税后工资

        public decimal 税后工资
        {
            get
            {
                return 总应税工资 - 个人所得税;
            }
        }
        #endregion

        #region 上表工资标准

        public decimal 上表工资标准
        {
            get
            {
                return this.基础工资表.上表工资 + 基础工资表.工资降级;
            }
        }
        #endregion

        #region 序号

        [NonPersistent]
        public int 序号 { get; set; }

        #endregion

        #region 还借款

        [NonPersistent]
        public decimal 还借款
        {
            get
            {
                return 提前借工资本月还款额 + 个人专用车费用本月还款额;
            }
        }
        #endregion

        #region 个人费用

        [NonPersistent]
        public decimal 个人费用
        {
            get
            {
                return 月租房报销费用本月实际报销额 + 探亲飞机票本月实际报销额;
            }
        }
        #endregion

        #region 职级年休假工资合计

        [NonPersistent]
        public decimal 职级年休假工资合计
        {
            get
            {
                return 职级工资 + 年休假工资;
            }
        }
        #endregion

        #region 奖项_不含满勤奖

        public decimal 奖项_不含满勤奖
        {
            get
            {
                return 奖项 - 月满勤奖;
            }
        }
        #endregion

        #region 缺勤天数

        public decimal 缺勤天数
        {
            get
            {
                decimal x = 基础工资表.企业排班天数 - 基础工资表.实际出勤天数;
                //行政班不会超勤
                if (x < 0 && 基础工资表.班别 == "6") x = 0;
                return x;
            }
        }
        #endregion

        #region 工资调整额度

        public decimal 工资调整额度
        {
            get
            {
                DateTime currMonth = new DateTime(年度, 月份, 1);
                DateTime prevMonth = currMonth.AddMonths(-1);
                PrivateSalary prevMonthPay = PrivateSalary.GetPrivateSalary(this.员工编号, prevMonth.Year, prevMonth.Month);
                decimal 上月工资 = prevMonthPay == null ? 0 : prevMonthPay.职级工资 + prevMonthPay.基础工资表.未休年休假工资;
                decimal 本月工资 = 职级工资 + 基础工资表.未休年休假工资;

                return 本月工资 - 上月工资;
            }
        }
        #endregion

        #region 工资调整幅度

        public decimal 工资调整幅度
        {
            get
            {
                DateTime currMonth = new DateTime(年度, 月份, 1);
                DateTime prevMonth = currMonth.AddMonths(-1);
                PrivateSalary prevMonthPay = PrivateSalary.GetPrivateSalary(this.员工编号, prevMonth.Year, prevMonth.Month);
                decimal 上月工资 = prevMonthPay == null ? 0 : prevMonthPay.职级工资 + prevMonthPay.基础工资表.未休年休假工资;
                decimal 本月工资 = 职级工资 + 基础工资表.未休年休假工资;

                if (上月工资 == 0)
                    return 1;
                else
                    return Math.Abs((本月工资 - 上月工资) / 上月工资);
            }
        }

        #endregion

        #region 总工资

        public decimal 总工资
        {
            get
            {
                DateTime date1 = new DateTime(年度, 月份, 1);
                DateTime date2 = new DateTime(2018, 1, 1);
                if (date1 < date2)
                    return 职级工资 + 基础工资表.未休年休假工资;
                else
                    return 职级工资;
            }
        }

        #endregion

        #region 职务工资

        [NonPersistent]
        public decimal 职务工资
        {
            get
            {
                return 总工资 - 满勤奖标准;
            }
        }
        #endregion

        #region 员工信息
        public EmployeeInfo 员工信息
        {
            get { return 基础工资表.员工信息; }
        }

        #endregion

        #region 满勤奖标准
        object fullAttendancePay = null;
        public decimal 满勤奖标准
        {
            get
            {
                if (fullAttendancePay == null)
                {
                    if (满勤奖执行标准 > 0)
                        fullAttendancePay = 满勤奖执行标准;
                    else
                        fullAttendancePay = PsHelper.GetFullAttendancePayFromCache(this.基础工资表.薪酬体系编号, this.基础工资表.薪等编号, new DateTime(this.年度, this.月份, 1));
                }
                return Convert.ToDecimal(fullAttendancePay);
            }
        }
        #endregion

        #region 交通餐饮补助标准

        object trafficSubsidies = null;
        public decimal 交通餐饮补助标准
        {
            get
            {
                if (trafficSubsidies == null)
                {
                    if (交通餐饮补助执行标准 > 0)
                        trafficSubsidies = 交通餐饮补助执行标准;
                    else
                        trafficSubsidies = PsHelper.GetTrafficSubsidies(员工编号, new DateTime(this.年度, this.月份, 1));
                }
                return Convert.ToDecimal(trafficSubsidies);
            }
        }

        #endregion

        #region 管培生信息

        TraineeInfo traineeInfo = null;
        public TraineeInfo 管培生信息
        {
            get
            {
                if(traineeInfo == null && this.员工信息.是管培生)
                {
                    traineeInfo = TraineeInfo.Get(this.员工编号);
                }
                return traineeInfo;
            }
        }

        #endregion

        #region 管培生级别

        public string 管培生级别
        {
            get
            {
                if (管培生信息 == null)
                    return "";
                else
                    return 管培生信息.岗位级别;
            }
        }
        #endregion

        #region 管培生届别

        public string 管培生届别
        {
            get
            {
                if (管培生信息 == null)
                    return "";
                else
                    return 管培生信息.毕业时间.Year.ToString();
            }
        }
        #endregion

        #region 职级工资减项

        public decimal 职级工资减项
        {
            get
            {
                return 薪资奖励_月摊 + 年绩效工资_月摊 +  工资借款标准 + 报账工资标准 + 福利借款标准 + 契约津贴标准 + 本月执行绩效工资额;
            }
        }

        #endregion

        #region 薪酬结构

        EmployeeSalaryStructure salaryStructure;
        [NonPersistent]
        public EmployeeSalaryStructure 薪酬结构
        {
            get
            {
                if (salaryStructure == null) salaryStructure = new EmployeeSalaryStructure(this.员工信息);
                return salaryStructure;
            }
            set { salaryStructure = value; }
        }
        #endregion
    }
}