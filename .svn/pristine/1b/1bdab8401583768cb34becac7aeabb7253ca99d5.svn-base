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
using System.Data.SqlClient;

namespace Hwagain.SalaryCalculation.Components
{
    public partial class ManagementTraineeInfoInput
    {
        static readonly ILog log = LogManager.GetLogger(typeof(ManagementTraineeInfoInput));
        public static ICache<string, ManagementTraineeInfoInput> MANAGEMENT_TRAINEE_INFO_INPUT_CACHE = MemoryCache<string, ManagementTraineeInfoInput>.Instance;

        #region GetManagementTraineeInfoInput

        public static ManagementTraineeInfoInput GetManagementTraineeInfoInput(Guid id)
        {
            ManagementTraineeInfoInput obj = (ManagementTraineeInfoInput)Session.DefaultSession.GetObjectByKey(typeof(ManagementTraineeInfoInput), id);
            return obj;
        }

        public static ManagementTraineeInfoInput GetManagementTraineeInfoInput(string empNo, bool isVerify)
        {
            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                       new BinaryOperator("员工编号", empNo, BinaryOperatorType.Equal),
                       new BinaryOperator("是验证录入", isVerify, BinaryOperatorType.Equal));

            XPCollection objset = new XPCollection(typeof(ManagementTraineeInfoInput), criteria, new SortProperty("录入时间", SortingDirection.Descending));

            if (objset.Count > 0)
            {
                return (ManagementTraineeInfoInput)objset[0];
            }
            else
                return null;
        }

        #endregion

        #region GetManagementTraineeInfoInputList
        
        public static List<ManagementTraineeInfoInput> GetManagementTraineeInfoInputList(string year, bool isVerify)
        {
            List<ManagementTraineeInfoInput> list = new List<ManagementTraineeInfoInput>();

            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                       new BinaryOperator("是验证录入", isVerify, BinaryOperatorType.Equal));

            if (!string.IsNullOrEmpty(year)) criteria.Operands.Add(new BinaryOperator("届别", year, BinaryOperatorType.Equal));

            XPCollection objset = new XPCollection(typeof(ManagementTraineeInfoInput), criteria, new SortProperty("入职时间", SortingDirection.Ascending));

            foreach (ManagementTraineeInfoInput item in objset)
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
        public static ManagementTraineeInfoInput GetEditingRow(string emplid, bool isVerify)
        {
            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                       new BinaryOperator("员工编号", emplid, BinaryOperatorType.Equal),
                       new NullOperator("生效时间"),
                       new BinaryOperator("是验证录入", isVerify, BinaryOperatorType.Equal));

            XPCollection objset = new XPCollection(MyHelper.XpoSession, typeof(ManagementTraineeInfoInput), criteria, new SortProperty("录入时间", SortingDirection.Descending));

            if (objset.Count > 0)
            {
                return (ManagementTraineeInfoInput)objset[0];
            }
            else
                return null;
        }
        #endregion

        #region GetEditingRows

        /// <summary>
        /// 获取正在录入的记录
        /// </summary>
        /// <param name="stepId"></param>
        /// <param name="isVerify"></param>
        /// <returns></returns>
        public static List<ManagementTraineeInfoInput> GetEditingRows(string year, string grade, bool isVerify)
        {
            List<ManagementTraineeInfoInput> rows = new List<ManagementTraineeInfoInput>();

            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,                 
                       new BinaryOperator("是验证录入", isVerify, BinaryOperatorType.Equal));

            if (!string.IsNullOrEmpty(year)) criteria.Operands.Add(new BinaryOperator("届别", year, BinaryOperatorType.Equal));
            if (!string.IsNullOrEmpty(grade)) criteria.Operands.Add(new BinaryOperator("岗位级别", grade, BinaryOperatorType.Equal));

            XPCollection objset = new XPCollection(MyHelper.XpoSession, typeof(ManagementTraineeInfoInput), criteria, new SortProperty("序号", SortingDirection.Ascending));

            foreach (ManagementTraineeInfoInput input in objset)
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
            if(this.员工信息 == null) throw new Exception("指定的员工编号不存在.");

            this.姓名 = this.员工信息.姓名;

            ManagementTraineeInfoInput found = GetManagementTraineeInfoInput(this.员工编号, this.是验证录入);
            if (found != null && found.标识 != this.标识)
                throw new Exception("已经存在该员工的管培生基本信息，不能重复创建");
            else
                base.OnSaving();

            contentDifferentFields = null;
            MANAGEMENT_TRAINEE_INFO_INPUT_CACHE.Set(CacheKey, this, TimeSpan.FromHours(1));
        }
        #endregion

        #region OnSaved

        protected override void OnSaved()
        {
            //自动建立另一人的记录
            AddManagementTraineeInfoInput(this.员工编号, !this.是验证录入, CopyEffective);
        }
        #endregion

        #region OnDeleting

        protected override void OnDeleting()
        {
            base.OnDeleting();
            MANAGEMENT_TRAINEE_INFO_INPUT_CACHE.Remove(CacheKey);
        }
        #endregion

        #region AddManagementTraineeInfoInput

        public static ManagementTraineeInfoInput AddManagementTraineeInfoInput(string emplid, bool isVerify)
        {
            return AddManagementTraineeInfoInput(emplid, isVerify, false);
        }

        public static ManagementTraineeInfoInput AddManagementTraineeInfoInput(string emplid, bool isVerify, bool copyEffective)
        {
            ManagementTraineeInfoInput item = GetManagementTraineeInfoInput(emplid, isVerify);
            if (item == null)
            {
                item = new ManagementTraineeInfoInput();

                if (copyEffective)
                {
                    //将当前的管培生信息带进来
                    ManagementTraineeInfo effectiveManagementTraineeInfo = ManagementTraineeInfo.GetManagementTraineeInfo(emplid);
                    if (effectiveManagementTraineeInfo != null)
                    {
                        item.CopyEffective = copyEffective;
                        effectiveManagementTraineeInfo.CopyWatchMember(item);
                    }
                }

                item.标识 = Guid.NewGuid();
                item.员工编号 = emplid;
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
            if (this.内容不同的字段.Count > 0) return;

            ManagementTraineeInfo m = ManagementTraineeInfo.GetManagementTraineeInfo(this.员工编号);
            if (m == null)
            {
                m = new ManagementTraineeInfo();
                m.标识 = Guid.NewGuid();
            }
            this.CopyWatchMember(m);
            m.更新时间 = DateTime.Now;
            m.Save();

            //更新生效标记
            if (!this.已生效)
            {
                this.生效时间 = DateTime.Now;
                this.Save();

                ManagementTraineeInfoInput opposite = 另一人录入的记录;
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

        #region ClearTraineeInfo

        //清除(只能清除未生效的记录)
        public static void ClearTraineeInfo(string division, string grade)
        {
            string sql = "DELETE FROM 管培生_综合能力评定_录入 WHERE 届别 = '" + division + "' AND 岗位级别 = '" + grade + "' AND 生效时间 IS NULL";
            using (SqlConnection connection = new SqlConnection(MyHelper.GetConnectionString()))
            {
                YiKang.Data.SqlHelper.ExecuteNonQuery(connection, System.Data.CommandType.Text, sql);
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

        ManagementTraineeInfoInput anotherInput = null;
        [Browsable(false)]
        public ManagementTraineeInfoInput 另一人录入的记录
        {
            get
            {
                if (anotherInput == null)
                {
                    anotherInput = GetManagementTraineeInfoInput(this.员工编号, !this.是验证录入);
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
            get { return this.员工编号 + "$$" + this.是验证录入; }
        }

        #endregion

        [NonPersistent]
        public bool CopyEffective { get; set; }
    }
}
