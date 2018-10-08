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
    public partial class ManagementSpecialtyPropertyInput
    {
        static readonly ILog log = LogManager.GetLogger(typeof(ManagementSpecialtyPropertyInput));
        public static ICache<string, ManagementSpecialtyPropertyInput> MANAGEMENT_SPECIALTY_PROPERTY_INPUT_CACHE = MemoryCache<string, ManagementSpecialtyPropertyInput>.Instance;

        #region GetManagementSpecialtyPropertyInput

        public static ManagementSpecialtyPropertyInput GetManagementSpecialtyPropertyInput(Guid id)
        {
            ManagementSpecialtyPropertyInput obj = (ManagementSpecialtyPropertyInput)Session.DefaultSession.GetObjectByKey(typeof(ManagementSpecialtyPropertyInput), id);
            return obj;
        }

        public static ManagementSpecialtyPropertyInput GetManagementSpecialtyPropertyInput(string year, string grade, string xueli, string specialty, bool isVerify)
        {
            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                       new BinaryOperator("届别", year, BinaryOperatorType.Equal),
                       new BinaryOperator("岗位级别", grade, BinaryOperatorType.Equal),
                       new BinaryOperator("学历", xueli, BinaryOperatorType.Equal),
                       new BinaryOperator("专业名称", specialty, BinaryOperatorType.Equal),
                       new BinaryOperator("是验证录入", isVerify, BinaryOperatorType.Equal));

            XPCollection objset = new XPCollection(typeof(ManagementSpecialtyPropertyInput), criteria, new SortProperty("录入时间", SortingDirection.Descending));

            if (objset.Count > 0)
            {
                return (ManagementSpecialtyPropertyInput)objset[0];
            }
            else
                return null;
        }

        #endregion

        #region GetManagementSpecialtyPropertyInputList
        
        public static List<ManagementSpecialtyPropertyInput> GetManagementSpecialtyPropertyInputList(string year, bool isVerify)
        {
            List<ManagementSpecialtyPropertyInput> list = new List<ManagementSpecialtyPropertyInput>();

            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                       new BinaryOperator("是验证录入", isVerify, BinaryOperatorType.Equal));

            if (!string.IsNullOrEmpty(year)) criteria.Operands.Add(new BinaryOperator("届别", year, BinaryOperatorType.Equal));

            XPCollection objset = new XPCollection(typeof(ManagementSpecialtyPropertyInput), criteria, new SortProperty("入职时间", SortingDirection.Ascending));

            foreach (ManagementSpecialtyPropertyInput item in objset)
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
        public static List<ManagementSpecialtyPropertyInput> GetEditingRows(string year, bool isVerify)
        {
            List<ManagementSpecialtyPropertyInput> rows = new List<ManagementSpecialtyPropertyInput>();

            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,                 
                       new BinaryOperator("是验证录入", isVerify, BinaryOperatorType.Equal));

            if (!string.IsNullOrEmpty(year)) criteria.Operands.Add(new BinaryOperator("届别", year, BinaryOperatorType.Equal));
            
            XPCollection objset = new XPCollection(MyHelper.XpoSession, typeof(ManagementSpecialtyPropertyInput), criteria, new SortProperty("序号", SortingDirection.Ascending), new SortProperty("录入时间", SortingDirection.Ascending));

            foreach (ManagementSpecialtyPropertyInput input in objset)
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
            if (string.IsNullOrEmpty(this.学历)) throw new Exception("学历不能为空.");
            if (string.IsNullOrEmpty(this.专业名称)) throw new Exception("专业名称不能为空.");

            if(!ManagementTraineeInfo.CheckSpecialtyValid(Convert.ToInt32(届别), 岗位级别, 学历, 专业名称)) { throw new Exception("专业名称无效."); }

            ManagementSpecialtyPropertyInput found = GetManagementSpecialtyPropertyInput(this.届别, this.岗位级别, this.学历, this.专业名称, this.是验证录入);
            if (found != null && found.标识 != this.标识)
                throw new Exception("已经存在该专业的属性信息，不能重复创建");
            else
                base.OnSaving();

            contentDifferentFields = null;
            MANAGEMENT_SPECIALTY_PROPERTY_INPUT_CACHE.Set(CacheKey, this, TimeSpan.FromHours(1));
        }
        #endregion

        #region OnSaved

        protected override void OnSaved()
        {
            //自动建立另一人的记录
            AddManagementSpecialtyPropertyInput(this.届别, this.岗位级别, this.学历, this.专业名称, !this.是验证录入, CopyEffective);
        }
        #endregion

        #region OnDeleting

        protected override void OnDeleting()
        {
            base.OnDeleting();
            MANAGEMENT_SPECIALTY_PROPERTY_INPUT_CACHE.Remove(CacheKey);
        }
        #endregion

        #region AddManagementSpecialtyPropertyInput

        public static ManagementSpecialtyPropertyInput AddManagementSpecialtyPropertyInput(string year, string grade, string xueli, string specialty, bool isVerify)
        {
            return AddManagementSpecialtyPropertyInput(year, grade, xueli, specialty, isVerify, false);
        }

        public static ManagementSpecialtyPropertyInput AddManagementSpecialtyPropertyInput(string year, string grade, string xueli, string specialty, bool isVerify, bool copyEffective)
        {
            ManagementSpecialtyPropertyInput item = GetManagementSpecialtyPropertyInput(year, grade, xueli, specialty, isVerify);
            if (item == null)
            {
                item = new ManagementSpecialtyPropertyInput();

                if (copyEffective)
                {
                    //将当前的管培生信息带进来
                    ManagementSpecialtyProperty effectiveManagementSpecialtyProperty = ManagementSpecialtyProperty.GetManagementSpecialtyProperty(year, grade, xueli, specialty);
                    if (effectiveManagementSpecialtyProperty != null)
                    {
                        item.CopyEffective = copyEffective;
                        effectiveManagementSpecialtyProperty.CopyWatchMember(item);
                    }
                }

                item.标识 = Guid.NewGuid();
                item.届别 = year;
                item.岗位级别 = grade;
                item.学历 = xueli;
                item.专业名称 = specialty;

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

            ManagementSpecialtyProperty m = ManagementSpecialtyProperty.GetManagementSpecialtyProperty(届别, 岗位级别, 学历, 专业名称);
            if (m == null)
            {
                m = new ManagementSpecialtyProperty();
                m.标识 = Guid.NewGuid();
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

                ManagementSpecialtyPropertyInput opposite = 另一人录入的记录;
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

        ManagementSpecialtyPropertyInput anotherInput = null;
        [Browsable(false)]
        public ManagementSpecialtyPropertyInput 另一人录入的记录
        {
            get
            {
                if (anotherInput == null)
                {
                    anotherInput = GetManagementSpecialtyPropertyInput(届别, 岗位级别, 学历, 专业名称, !this.是验证录入);
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
            get { return this.届别 + "$$" + this.岗位级别 + "$$" + this.学历 + "$$" + this.专业名称 + "$$" + this.是验证录入; }
        }

        #endregion

        [NonPersistent]
        public bool CopyEffective { get; set; }
    }
}
