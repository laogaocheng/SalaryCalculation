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
    public partial class MonthlyRembursementSalaryItemEntry
    {
        static readonly ILog log = LogManager.GetLogger(typeof(MonthlyRembursementSalaryItemEntry));
        public static ICache<string, MonthlyRembursementSalaryItemEntry> MONTHLYREMBURSEMENTSALARYITEM_ENTRY_CACHE = MemoryCache<string, MonthlyRembursementSalaryItemEntry>.Instance;

        #region GetMonthlyRembursementSalaryItemEntry

        public static MonthlyRembursementSalaryItemEntry GetMonthlyRembursementSalaryItemEntry(Guid id)
        {
            MonthlyRembursementSalaryItemEntry obj = (MonthlyRembursementSalaryItemEntry)Session.DefaultSession.GetObjectByKey(typeof(MonthlyRembursementSalaryItemEntry), id);
            return obj;
        }

        public static MonthlyRembursementSalaryItemEntry GetMonthlyRembursementSalaryItemEntry(string emplid, int year, int month, bool isVerify)
        {
            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                       new BinaryOperator("员工编号", emplid, BinaryOperatorType.Equal),
                       new BinaryOperator("年", year, BinaryOperatorType.Equal),
                       new BinaryOperator("月", month, BinaryOperatorType.Equal),
                       new BinaryOperator("是验证录入", isVerify, BinaryOperatorType.Equal));

            XPCollection objset = new XPCollection(typeof(MonthlyRembursementSalaryItemEntry), criteria, new SortProperty("录入时间", SortingDirection.Ascending));

            if (objset.Count > 0)
            {
                return (MonthlyRembursementSalaryItemEntry)objset[0];
            }
            else
                return null;
        }

        #endregion

        #region GetMonthlyRembursementSalaryItemEntrys

        public static List<MonthlyRembursementSalaryItemEntry> GetMonthlyRembursementSalaryItemEntrys(string emplid, bool isVerify)
        {
            List<MonthlyRembursementSalaryItemEntry> list = new List<MonthlyRembursementSalaryItemEntry>();

            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                       new BinaryOperator("员工编号", emplid, BinaryOperatorType.Equal),
                       new BinaryOperator("是验证录入", isVerify, BinaryOperatorType.Equal));
            
            XPCollection objset = new XPCollection(typeof(MonthlyRembursementSalaryItemEntry), criteria, new SortProperty("录入时间", SortingDirection.Ascending));

            foreach (MonthlyRembursementSalaryItemEntry ms in objset)
            {
                list.Add(ms);                
            }
            return list;
        }
        #endregion

        #region GetEditingRow

        /// <summary>
        /// 获取正在录入的记录
        /// </summary>
        /// <param name="isVerify"></param>
        /// <returns></returns>
        public static MonthlyRembursementSalaryItemEntry GetEditingRow(string emplid, int year, int month, bool isVerify)
        {
            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                       new BinaryOperator("员工编号", emplid, BinaryOperatorType.Equal),
                       new BinaryOperator("年", year, BinaryOperatorType.Equal),
                       new BinaryOperator("月", month, BinaryOperatorType.Equal),
                       new NullOperator("生效时间"),
                       new BinaryOperator("是验证录入", isVerify, BinaryOperatorType.Equal));

            XPCollection objset = new XPCollection(typeof(MonthlyRembursementSalaryItemEntry), criteria, new SortProperty("录入时间", SortingDirection.Ascending));

            if (objset.Count > 0)
            {
                return (MonthlyRembursementSalaryItemEntry)objset[0];
            }
            else
                return null;
        }
        #endregion

        #region GetEditingRows

        /// <returns></returns>
        public static List<MonthlyRembursementSalaryItemEntry> GetEditingRows(int year, int month, bool isVerify)
        {
            List<MonthlyRembursementSalaryItemEntry> rows = new List<MonthlyRembursementSalaryItemEntry>();

            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                       new BinaryOperator("年", year, BinaryOperatorType.Equal),
                       new BinaryOperator("月", month, BinaryOperatorType.Equal),
                       new NullOperator("生效时间"),
                       new BinaryOperator("是验证录入", isVerify, BinaryOperatorType.Equal));

            XPCollection objset = new XPCollection(typeof(MonthlyRembursementSalaryItemEntry), criteria, new SortProperty("录入时间", SortingDirection.Ascending));

            foreach (MonthlyRembursementSalaryItemEntry input in objset)
            {
                rows.Add(input);
            }
            return rows;
        }
        #endregion

        #region ClearMonthlyRembursementSalaryItemEntry

        //清除指员工的报账记录(只能清除未生效的记录)
        public static void ClearMonthlyRembursementSalaryItemEntry(string emplid, int year, int month)
        {
            string sql = "DELETE FROM 薪酬结构_报账工资_发放明细_录入 WHERE 员工编号 = '" + emplid + "' AND 年 = " + year+ " AND 月 = " + month + " AND 生效时间 IS NULL";
            using (SqlConnection connection = new SqlConnection(MyHelper.GetConnectionString()))
            {
                YiKang.Data.SqlHelper.ExecuteNonQuery(connection, System.Data.CommandType.Text, sql);
                
            }
        }
        #endregion

        #region AddMonthlyRembursementSalaryItemEntry

        public static MonthlyRembursementSalaryItemEntry AddMonthlyRembursementSalaryItemEntry(string emplid, string name, int year, int month, bool isVerify)
        {            
            MonthlyRembursementSalaryItemEntry item = GetMonthlyRembursementSalaryItemEntry(emplid, year, month, isVerify);
            if (item == null)
            {
                item = new MonthlyRembursementSalaryItemEntry();

                item.标识 = Guid.NewGuid();
                item.员工编号 = emplid;
                item.姓名 = name;
                item.年 = year;
                item.月 = month;
                item.是验证录入 = isVerify;
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

            MonthlyRembursementSalaryItem m = MonthlyRembursementSalaryItem.AddMonthlyRembursementSalaryItem(this.员工编号, this.年, this.月);

            this.CopyWatchMember(m);

            m.创建人 = this.录入人;
            m.创建时间 = DateTime.Now;
            m.Save();

            //更新生效标记
            if (!this.已生效)
            {
                this.生效时间 = DateTime.Now;
                this.Save();

                MonthlyRembursementSalaryItemEntry opposite = 另一人录入的记录;
                opposite.生效时间 = DateTime.Now;
                opposite.Save();
            }
        }
        #endregion

        #region OnSaving

        protected override void OnSaving()
        {
            this.期间 = GetPeriod(年, 月);

            if (string.IsNullOrEmpty(this.员工编号)) throw new Exception("员工编号不能为空");
            
            MonthlyRembursementSalaryItemEntry found = GetEditingRow(this.员工编号, this.年, this.月, this.是验证录入);
            if (found != null && found.标识 != this.标识)
                throw new Exception("已存在该员工的报账记录，不能重复创建。");
            else
                base.OnSaving();

            contentDifferentFields = null;
            MONTHLYREMBURSEMENTSALARYITEM_ENTRY_CACHE.Set(CacheKey, this, TimeSpan.FromHours(1));
        }
        #endregion        

        #region OnSaved

        protected override void OnSaved()
        {
            base.OnSaved();

            //如果对向没有记录，自动创建
            MonthlyRembursementSalaryItemEntry opposite = GetEditingRow(this.员工编号, this.年, this.月, !this.是验证录入);
            if (opposite == null)
            {
                opposite = new MonthlyRembursementSalaryItemEntry();

                opposite.标识 = Guid.NewGuid();
                opposite.员工编号 = this.员工编号;
                opposite.姓名 = this.姓名;
                opposite.年 = this.年;
                opposite.月 = this.月;
                opposite.上月剩余金额 = this.上月剩余金额;
                opposite.上年剩余金额 = this.上年剩余金额;
                opposite.是验证录入 = !this.是验证录入;

                opposite.录入人 = "";
                opposite.录入时间 = DateTime.Now;
                opposite.Save();
            }
        }
        #endregion

        #region OnDeleting

        protected override void OnDeleting()
        {
            if (已生效) throw new Exception("不能删除已生效的记录");
            base.OnDeleting();
            MONTHLYREMBURSEMENTSALARYITEM_ENTRY_CACHE.Remove(CacheKey);   
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
                    另一人录入的记录.Reload(); //比较前重新加载一次数据，以保证数据最新
                    contentDifferentFields = MyHelper.GetModifyFields(this, 另一人录入的记录);
                }

            }                
        }
        #endregion

        #region GetPeriod
        public static string GetPeriod(int year, int month)
        {
            return Convert.ToString(year * 100 + month);
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

        MonthlyRembursementSalaryItemEntry anotherInput = null;
        [Browsable(false)]
        public MonthlyRembursementSalaryItemEntry 另一人录入的记录
        {
            get
            {
                if (anotherInput == null)
                {
                    anotherInput = GetMonthlyRembursementSalaryItemEntry(this.员工编号, this.年, this.月, !this.是验证录入);
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
            get { return this.员工编号 + "$$" + this.年 + "$$" + this.月 + "$$" + this.是验证录入; }
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

        #region 报账时间
        public string 报账时间
        {
            get
            {
                return 年 + "年" + 月 + "月";
            }
        }
        #endregion

        #region 上月发放记录

        MonthlyRembursementSalaryItem lastMonthItem = null;
        public MonthlyRembursementSalaryItem 上月发放记录
        {
            get
            {
                if (lastMonthItem == null)
                {
                    string lastPeriod = MonthlyRembursementSalaryItem.GetLastMonthPeriod(年, 月);
                    lastMonthItem = MonthlyRembursementSalaryItem.GetMonthlyRembursementSalaryItem(员工编号, lastPeriod);
                }
                return lastMonthItem;
            }
        }

        #endregion

        #region 报账标准

        RembursementSalary rs = null;
        [NonPersistent]
        public RembursementSalary 报账标准
        {
            get
            {
                if (rs == null) rs = RembursementSalary.GetEffectiveRembursementSalary(员工编号, new DateTime(年, 月, 1));
                return rs;
            }
        }
        #endregion

        #region 报账标准_税后_月
        public decimal 报账标准_税后_月
        {
            get
            {
                RembursementSalary rs = this.报账标准;
                if (rs == null)
                    return 0;
                else
                    return rs.月度可报账标准_税后;
            }
        }
        #endregion

        #region 本月报账工资标准
        public decimal 本月报账工资标准
        {
            get
            {
                return 报账标准_税后_月;
            }
        }
        #endregion

        #region 本月可报账金额

        public decimal 本月可报账金额
        {
            get
            {
                return 报账标准_税后_月 + 上月剩余金额;
            }
        }
        #endregion

        #region 本月剩余可报账金额

        public decimal 本月剩余可报账金额
        {
            get
            {
                return 本月可报账金额 - 实际报账金额;
            }
        }
        #endregion

        [NonPersistent]
        public string 录入按钮文字
        {
            get { return "录入"; }
        }
    }
}
