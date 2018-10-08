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
    public partial class ManagementTraineeAbilityInput
    {
        static readonly ILog log = LogManager.GetLogger(typeof(ManagementTraineeAbilityInput));
        public static ICache<string, ManagementTraineeAbilityInput> MANAGEMENT_TRAINEE_ABILITY_INPUT_CACHE = MemoryCache<string, ManagementTraineeAbilityInput>.Instance;

        #region GetManagementTraineeAbilityInput

        public static ManagementTraineeAbilityInput GetManagementTraineeAbilityInput(Guid id)
        {
            ManagementTraineeAbilityInput obj = (ManagementTraineeAbilityInput)Session.DefaultSession.GetObjectByKey(typeof(ManagementTraineeAbilityInput), id);
            return obj;
        }

        public static ManagementTraineeAbilityInput GetManagementTraineeAbilityInput(string emplid, int year, bool isVerify)
        {
            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                       new BinaryOperator("员工编号", emplid, BinaryOperatorType.Equal),
                       new BinaryOperator("年度", year, BinaryOperatorType.Equal),
                       new BinaryOperator("是验证录入", isVerify, BinaryOperatorType.Equal));

            XPCollection objset = new XPCollection(typeof(ManagementTraineeAbilityInput), criteria, new SortProperty("录入时间", SortingDirection.Descending));

            if (objset.Count > 0)
            {
                return (ManagementTraineeAbilityInput)objset[0];
            }
            else
                return null;
        }

        #endregion

        #region GetManagementTraineeAbilityInputList
        
        public static List<ManagementTraineeAbilityInput> GetManagementTraineeAbilityInputList(string division, string grade, int year, bool isVerify)
        {
            List<ManagementTraineeAbilityInput> list = new List<ManagementTraineeAbilityInput>();

            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                       new BinaryOperator("是验证录入", isVerify, BinaryOperatorType.Equal));

            if (!string.IsNullOrEmpty(division)) criteria.Operands.Add(new BinaryOperator("届别", division, BinaryOperatorType.Equal));
            if (!string.IsNullOrEmpty(grade)) criteria.Operands.Add(new BinaryOperator("岗位级别", grade, BinaryOperatorType.Equal));
            if (year > 0) criteria.Operands.Add(new BinaryOperator("年度", year, BinaryOperatorType.Equal));

            XPCollection objset = new XPCollection(typeof(ManagementTraineeAbilityInput), criteria, new SortProperty("录入时间", SortingDirection.Ascending));

            foreach (ManagementTraineeAbilityInput item in objset)
            {
                list.Add(item);
            }
            return list;
        }
        #endregion

        #region GetEditingRows

        /// <summary>
        /// 获取正在录入的记录
        /// </summary>
        /// <param name="stepId"></param>
        /// <param name="isVerify"></param>
        /// <returns></returns>
        public static List<ManagementTraineeAbilityInput> GetEditingRows(string division, string grade, int year, bool isVerify)
        {
            List<ManagementTraineeAbilityInput> rows = new List<ManagementTraineeAbilityInput>();

            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,                 
                       new BinaryOperator("是验证录入", isVerify, BinaryOperatorType.Equal));

            if (!string.IsNullOrEmpty(division)) criteria.Operands.Add(new BinaryOperator("届别", division, BinaryOperatorType.Equal));
            if (!string.IsNullOrEmpty(grade)) criteria.Operands.Add(new BinaryOperator("岗位级别", grade, BinaryOperatorType.Equal));
            if (year > 0) criteria.Operands.Add(new BinaryOperator("年度", year, BinaryOperatorType.Equal));

            XPCollection objset = new XPCollection(MyHelper.XpoSession, typeof(ManagementTraineeAbilityInput), criteria, new SortProperty("序号", SortingDirection.Ascending), new SortProperty("录入时间", SortingDirection.Ascending));

            foreach (ManagementTraineeAbilityInput input in objset)
            {
                rows.Add(input);
            }
            return rows;
        }
        #endregion

        #region OnSaving

        protected override void OnSaving()
        {
            if (string.IsNullOrEmpty(this.届别)) throw new Exception("届别不能为空.");
            if (string.IsNullOrEmpty(this.岗位级别)) throw new Exception("岗位级别不能为空.");
            if (this.年度 <=0) throw new Exception("年度不能为空.");
            
            ManagementTraineeAbilityInput found = GetManagementTraineeAbilityInput(this.员工编号, this.年度, this.是验证录入);
            if (found != null && found.标识 != this.标识)
                throw new Exception("已经存在该员工的能力评定记录，不能重复创建");
            else
                base.OnSaving();

            contentDifferentFields = null;
            MANAGEMENT_TRAINEE_ABILITY_INPUT_CACHE.Set(CacheKey, this, TimeSpan.FromHours(1));
        }
        #endregion

        #region OnSaved

        protected override void OnSaved()
        {
            //自动建立另一人的记录
            AddManagementTraineeAbilityInput(届别, 岗位级别, 员工编号, 姓名, 年度, 序号, !this.是验证录入);
        }
        #endregion

        #region OnDeleting

        protected override void OnDeleting()
        {
            base.OnDeleting();
            MANAGEMENT_TRAINEE_ABILITY_INPUT_CACHE.Remove(CacheKey);
        }
        #endregion

        #region AddManagementTraineeAbilityInput

        public static ManagementTraineeAbilityInput AddManagementTraineeAbilityInput(string division, string grade, string emplid, string name, int year, int order,bool isVerify)
        {
            ManagementTraineeAbilityInput item = GetManagementTraineeAbilityInput(emplid, year, isVerify);
            if (item == null)
            {
                item = new ManagementTraineeAbilityInput();

                item.标识 = Guid.NewGuid();
                item.届别 = division;
                item.岗位级别 = grade;
                item.员工编号 = emplid;
                item.姓名 = name;
                item.年度 = year;
                item.序号 = order;
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

            ManagementTraineeAbility m = ManagementTraineeAbility.GetManagementTraineeAbility(员工编号, 年度);
            if (m == null)
            {
                m = new ManagementTraineeAbility();
                m.标识 = Guid.NewGuid();
                m.创建时间 = DateTime.Now;
            }
            this.CopyWatchMember(m);
            m.序号 = this.序号;
            m.更新时间 = DateTime.Now;
            m.Save();

            //更新生效标记
            if (!this.已生效)
            {
                this.生效时间 = DateTime.Now;
                this.Save();

                ManagementTraineeAbilityInput opposite = 另一人录入的记录;
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

        #region ClearTraineeAbility

        //清除评定结果(只能清除未生效的记录)
        public static void ClearTraineeAbility(string division, string grade, int year)
        {
            string sql = "DELETE FROM 管培生_综合能力评定_录入 WHERE 届别 = '" + division + "' AND 岗位级别 = '" + grade + "' AND 年度 = '" + year + "' AND 生效时间 IS NULL";
            using (SqlConnection connection = new SqlConnection(MyHelper.GetConnectionString()))
            {
                YiKang.Data.SqlHelper.ExecuteNonQuery(connection, System.Data.CommandType.Text, sql);
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

        ManagementTraineeAbilityInput anotherInput = null;
        [Browsable(false)]
        public ManagementTraineeAbilityInput 另一人录入的记录
        {
            get
            {
                if (anotherInput == null)
                {
                    anotherInput = GetManagementTraineeAbilityInput(员工编号, 年度, !this.是验证录入);
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
            get { return this.员工编号 + "$$" + this.年度 + "$$" + this.是验证录入; }
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

        #region 公司

        [NonPersistent]
        public string 公司
        {
            get { return 员工信息.公司名称; }
        }

        #endregion
    }
}
