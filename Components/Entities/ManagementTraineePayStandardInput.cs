using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using DevExpress.Xpo.DB;
using log4net;
using Hwagain.Components;
using System.ComponentModel;

namespace Hwagain.SalaryCalculation.Components
{
    public partial class ManagementTraineePayStandardInput
    {
        static readonly ILog log = LogManager.GetLogger(typeof(ManagementTraineePayStandardInput));
        public static ICache<string, ManagementTraineePayStandardInput> MANAGEMENT_TRAINEE_PAYSTANDARD_INPUT_CACHE = MemoryCache<string, ManagementTraineePayStandardInput>.Instance;

        #region GetManagementTraineePayStandardInput

        public static ManagementTraineePayStandardInput GetManagementTraineePayStandardInput(Guid id)
        {
            ManagementTraineePayStandardInput obj = (ManagementTraineePayStandardInput)Session.DefaultSession.GetObjectByKey(typeof(ManagementTraineePayStandardInput), id);
            return obj;
        }

        public static ManagementTraineePayStandardInput GetManagementTraineePayStandardInput(string empNo, int year, int quarter, bool isVerify)
        {
            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                       new BinaryOperator("员工编号", empNo, BinaryOperatorType.Equal),
                       new BinaryOperator("年份", year, BinaryOperatorType.Equal),
                       new BinaryOperator("季度", quarter, BinaryOperatorType.Equal),
                       new BinaryOperator("是验证录入", isVerify, BinaryOperatorType.Equal));

            XPCollection objset = new XPCollection(typeof(ManagementTraineePayStandardInput), criteria, new SortProperty("录入时间", SortingDirection.Descending));

            if (objset.Count > 0)
            {
                return (ManagementTraineePayStandardInput)objset[0];
            }
            else
                return null;
        }

        #endregion

        #region GetManagementTraineePayStandardInputList
        
        public static List<ManagementTraineePayStandardInput> GetManagementTraineePayStandardInputList(int year, int quarter, bool isVerify)
        {
            List<ManagementTraineePayStandardInput> list = new List<ManagementTraineePayStandardInput>();

            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                       new BinaryOperator("年份", year, BinaryOperatorType.Equal),
                       new BinaryOperator("季度", quarter, BinaryOperatorType.Equal),
                       new BinaryOperator("是验证录入", isVerify, BinaryOperatorType.Equal));
           
            XPCollection objset = new XPCollection(typeof(ManagementTraineePayStandardInput), criteria, new SortProperty("录入时间", SortingDirection.Ascending));

            foreach (ManagementTraineePayStandardInput item in objset)
            {
                list.Add(item);
            }
            return list;
        }
        #endregion

        #region GetEditingRow

        /// <summary>
        /// 获取正在录入的管培生信息记录
        /// </summary>
        /// <param name="isVerify"></param>
        /// <returns></returns>
        public static ManagementTraineePayStandardInput GetEditingRow(string emplid, int year, int quarter, bool isVerify)
        {
            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                       new BinaryOperator("员工编号", emplid, BinaryOperatorType.Equal),
                       new BinaryOperator("年份", year, BinaryOperatorType.Equal),
                       new BinaryOperator("季度", quarter, BinaryOperatorType.Equal),
                       new NullOperator("生效时间"),
                       new BinaryOperator("是验证录入", isVerify, BinaryOperatorType.Equal));

            XPCollection objset = new XPCollection(MyHelper.XpoSession, typeof(ManagementTraineePayStandardInput), criteria, new SortProperty("录入时间", SortingDirection.Descending));

            if (objset.Count > 0)
            {
                return (ManagementTraineePayStandardInput)objset[0];
            }
            else
                return null;
        }
        #endregion

        #region GetEditingRows

        /// <summary>
        /// 获取正在录入的记录
        /// </summary>
        public static List<ManagementTraineePayStandardInput> GetEditingRows(string emplid, int year, bool isVerify)
        {
            DateTime start = new DateTime(year, 7, 1);
            DateTime end = start.AddYears(1).AddDays(-1);
            List<ManagementTraineePayStandardInput> rows = new List<ManagementTraineePayStandardInput>();

            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                       new BinaryOperator("员工编号", emplid, BinaryOperatorType.Equal),
                       new BinaryOperator("开始执行时间", start, BinaryOperatorType.GreaterOrEqual),
                       new BinaryOperator("开始执行时间", end, BinaryOperatorType.Less),
                       new BinaryOperator("是验证录入", isVerify, BinaryOperatorType.Equal));
            
            XPCollection objset = new XPCollection(MyHelper.XpoSession, typeof(ManagementTraineePayStandardInput), criteria, new SortProperty("开始执行时间", SortingDirection.Ascending));

            foreach (ManagementTraineePayStandardInput input in objset)
            {
                rows.Add(input);
            }
            return rows;
        }
        #endregion

        #region OnSaving

        protected override void OnSaving()
        {
            if (string.IsNullOrEmpty(this.员工编号)) throw new Exception("员工编号不能为空.");
            if (this.年份 < 2015) throw new Exception("年份不能为空");
            if (this.季度 < 1) throw new Exception("季度不能为空");

            ManagementTraineePayStandardInput found = GetManagementTraineePayStandardInput(this.员工编号, this.年份, this.季度, this.是验证录入);
            if (found != null && found.标识 != this.标识)
                throw new Exception("已经存在该员工的工资标准，不能重复创建");
            else
                base.OnSaving();

            contentDifferentFields = null;
            MANAGEMENT_TRAINEE_PAYSTANDARD_INPUT_CACHE.Set(CacheKey, this, TimeSpan.FromHours(1));
        }
        #endregion

        #region OnSaved

        protected override void OnSaved()
        {
            //自动建立另一人的记录
            AddManagementTraineePayStandardInput(this.员工编号, this.年份, this.季度, this.序号, this.提资序数, !this.是验证录入, CopyEffective);
        }
        #endregion

        #region OnDeleting

        protected override void OnDeleting()
        {
            base.OnDeleting();
            MANAGEMENT_TRAINEE_PAYSTANDARD_INPUT_CACHE.Remove(CacheKey);
        }
        #endregion

        #region AddManagementTraineePayStandardInput

        public static ManagementTraineePayStandardInput AddManagementTraineePayStandardInput(string emplid, int year, int quarter, int order, int time, bool isVerify)
        {
            return AddManagementTraineePayStandardInput(emplid, year, quarter, order, time, isVerify, false);
        }

        public static ManagementTraineePayStandardInput AddManagementTraineePayStandardInput(string emplid, int year, int quarter, int order, int time, bool isVerify, bool copyEffective)
        {
            ManagementTraineePayStandardInput item = GetManagementTraineePayStandardInput(emplid, year, quarter, isVerify);
            if (item == null)
            {
                item = new ManagementTraineePayStandardInput();

                if (copyEffective)
                {
                    //将当前的管培生信息带进来
                    ManagementTraineePayStandard effectiveManagementTraineePayStandard = ManagementTraineePayStandard.GetManagementTraineePayStandard(emplid, year, quarter);
                    if (effectiveManagementTraineePayStandard != null)
                    {
                        item.CopyEffective = copyEffective;
                        effectiveManagementTraineePayStandard.CopyWatchMember(item);
                    }
                }

                DateTime 年度开始 = new DateTime(year, 1, 1);

                item.标识 = Guid.NewGuid();
                item.员工编号 = emplid;
                item.年份 = year;
                item.季度 = quarter;
                item.开始执行时间 = 年度开始.AddMonths(3 * (quarter - 1));
                item.序号 = order;
                item.提资序数 = time;
                item.是验证录入 = isVerify;
                item.录入人 = "";
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
            if (this.内容不同的字段.Count > 0) return;

            ManagementTraineePayStandard m = ManagementTraineePayStandard.GetManagementTraineePayStandard(this.员工编号, this.年份, this.季度);
            if (m == null)
            {
                m = new ManagementTraineePayStandard();
                m.标识 = Guid.NewGuid();
            }
            this.CopyWatchMember(m);
            m.姓名 = 员工信息.姓名;
            m.提资序数 = this.提资序数;
            m.增幅 = this.增幅;
            m.月薪 = this.月薪;
            m.开始执行时间 = this.开始执行时间;
            m.备注 = this.备注;
            m.创建人 = this.录入人;
            m.创建时间 = DateTime.Now;
            m.Save();

            //更新生效标记
            if (!this.已生效)
            {
                this.生效时间 = DateTime.Now;
                this.Save();

                ManagementTraineePayStandardInput opposite = 另一人录入的记录;
                opposite.生效时间 = DateTime.Now;
                opposite.Save();
            }
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
                    另一人录入的记录.Reload();
                    contentDifferentFields = MyHelper.GetModifyFields(this, 另一人录入的记录);
                }

            }
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

        ManagementTraineePayStandardInput anotherInput = null;
        [Browsable(false)]
        public ManagementTraineePayStandardInput 另一人录入的记录
        {
            get
            {
                if (anotherInput == null)
                {
                    anotherInput = GetManagementTraineePayStandardInput(this.员工编号, this.年份, this.季度, !this.是验证录入);
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

        #region CacheKey

        string CacheKey
        {
            get { return this.员工编号 + "$$" + this.年份 + "$$" + this.季度 + "$$" + this.是验证录入; }
        }

        #endregion

        [NonPersistent]
        public bool CopyEffective { get; set; }
    }
}
