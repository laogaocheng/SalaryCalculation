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
using System.Reflection;

namespace Hwagain.SalaryCalculation.Components
{
    public partial class ManagementTraineePayRiseStandardInput
    {
        static readonly ILog log = LogManager.GetLogger(typeof(ManagementTraineePayRiseStandardInput));
        public static ICache<string, ManagementTraineePayRiseStandardInput> MANAGEMENT_TRAINEE_PAY_RISE_INPUT_CACHE = MemoryCache<string, ManagementTraineePayRiseStandardInput>.Instance;

        #region GetManagementTraineePayRiseStandardInput

        public static ManagementTraineePayRiseStandardInput GetManagementTraineePayRiseStandardInput(Guid id)
        {
            ManagementTraineePayRiseStandardInput obj = (ManagementTraineePayRiseStandardInput)Session.DefaultSession.GetObjectByKey(typeof(ManagementTraineePayRiseStandardInput), id);
            return obj;
        }

        public static ManagementTraineePayRiseStandardInput GetManagementTraineePayRiseStandardInput(string division, string grade, string type, bool isVerify)
        {
            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                new BinaryOperator("届别", division, BinaryOperatorType.Equal),
                new BinaryOperator("岗位级别", grade, BinaryOperatorType.Equal),
                new BinaryOperator("类别", type, BinaryOperatorType.Equal),
                new BinaryOperator("是验证录入", isVerify, BinaryOperatorType.Equal));

            XPCollection objset = new XPCollection(typeof(ManagementTraineePayRiseStandardInput), criteria, new SortProperty("录入时间", SortingDirection.Descending));

            if (objset.Count > 0)
            {
                return (ManagementTraineePayRiseStandardInput)objset[0];
            }
            else
                return null;
        }

        #endregion

        #region GetManagementTraineePayRiseStandardInputList
        
        public static List<ManagementTraineePayRiseStandardInput> GetManagementTraineePayRiseStandardInputList(string year, string grade, bool isVerify)
        {
            List<ManagementTraineePayRiseStandardInput> list = new List<ManagementTraineePayRiseStandardInput>();

            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                new BinaryOperator("届别", year, BinaryOperatorType.Equal),
                new BinaryOperator("岗位级别", grade, BinaryOperatorType.Equal),
                new BinaryOperator("是验证录入", isVerify, BinaryOperatorType.Equal));

            XPCollection objset = new XPCollection(typeof(ManagementTraineePayRiseStandardInput), criteria, new SortProperty("序号", SortingDirection.Ascending));

            foreach (ManagementTraineePayRiseStandardInput item in objset)
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
        public static ManagementTraineePayRiseStandardInput GetEditingRow(string year, string grade, string type, bool isVerify)
        {
            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                new BinaryOperator("届别", year, BinaryOperatorType.Equal),
                new BinaryOperator("岗位级别", grade, BinaryOperatorType.Equal),
                new BinaryOperator("类别", type, BinaryOperatorType.Equal),
                new BinaryOperator("是验证录入", isVerify, BinaryOperatorType.Equal));

            XPCollection objset = new XPCollection(MyHelper.XpoSession, typeof(ManagementTraineePayRiseStandardInput), criteria, new SortProperty("录入时间", SortingDirection.Descending));

            if (objset.Count > 0)
            {
                return (ManagementTraineePayRiseStandardInput)objset[0];
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
        public static List<ManagementTraineePayRiseStandardInput> GetEditingRows(string division, string grade, string type, bool isVerify)
        {
            List<ManagementTraineePayRiseStandardInput> rows = new List<ManagementTraineePayRiseStandardInput>();

            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                new BinaryOperator("届别", division, BinaryOperatorType.Equal),
                new BinaryOperator("岗位级别", grade, BinaryOperatorType.Equal),
                new BinaryOperator("是验证录入", isVerify, BinaryOperatorType.Equal));

            if (type != null) criteria.Operands.Add(new BinaryOperator("类别", type, BinaryOperatorType.Equal));

            XPCollection objset = new XPCollection(MyHelper.XpoSession, typeof(ManagementTraineePayRiseStandardInput), criteria, new SortProperty("序号", SortingDirection.Ascending));

            foreach (ManagementTraineePayRiseStandardInput input in objset)
            {
                rows.Add(input);
            }
            return rows;
        }
        #endregion

        #region OnSaving

        protected override void OnSaving()
        {
            if (string.IsNullOrEmpty(this.届别)) throw new Exception("届别不能为空");
            if (string.IsNullOrEmpty(this.岗位级别)) throw new Exception("岗位级别不能为空.");

            ManagementTraineePayRiseStandardInput found = GetManagementTraineePayRiseStandardInput(届别, 岗位级别, 类别, 是验证录入);
            if (found != null && found.标识 != this.标识)
                throw new Exception("已经存在记录，不能重复创建");
            else
                base.OnSaving();

            contentDifferentFields = null;
            MANAGEMENT_TRAINEE_PAY_RISE_INPUT_CACHE.Set(CacheKey, this, TimeSpan.FromHours(1));
        }
        #endregion

        #region OnSaved

        protected override void OnSaved()
        {
            //自动建立另一人的记录
            AddManagementTraineePayRiseStandardInput(序号, 届别, 岗位级别, 类别, 满阶起薪方式, !this.是验证录入);
        }
        #endregion

        #region OnDeleting

        protected override void OnDeleting()
        {
            base.OnDeleting();
            MANAGEMENT_TRAINEE_PAY_RISE_INPUT_CACHE.Remove(CacheKey);
        }
        #endregion

        #region AddManagementTraineePayRiseStandardInput

        public static ManagementTraineePayRiseStandardInput AddManagementTraineePayRiseStandardInput(int order, string year, string grade, string type, int rise_type_final, bool isVerify)
        {        
            ManagementTraineePayRiseStandardInput item = GetManagementTraineePayRiseStandardInput(year, grade, type, isVerify);
            if (item == null)
            {
                item = new ManagementTraineePayRiseStandardInput();
                item.标识 = Guid.NewGuid();
                item.届别 = year;
                item.岗位级别 = grade;
                item.满阶起薪方式 = rise_type_final;
                item.类别 = type;
                item.序号 = order;
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
            //清除旧记录
            ManagementTraineePayRiseStandard.Clear(届别, 岗位级别, 类别);
            //创建和更新提资标准
            CreateOrUpdatePayStandard();
            //更新生效标记
            if (!this.已生效)
            {
                this.生效时间 = DateTime.Now;
                this.Save();

                ManagementTraineePayRiseStandardInput opposite = 另一人录入的记录;
                opposite.生效时间 = DateTime.Now;
                opposite.Save();
            }
        }

        private void CreateOrUpdatePayStandard()
        {
            decimal last_year_salary = 0;

            decimal year_salary = 0;
            decimal rise_rate = 0;
            RiseType rise_type = RiseType.百分比; //提资方式：0:百分比 1：金额   默认是百分比

            //创建起薪记录
            CreateOrUpdatePayStandard(0, 0, this.一阶起薪, RiseType.金额); //起薪必须是金额
            last_year_salary = this.一阶起薪;

            //创建一阶提资标准记录
            for (int i = 1; i <= 12; i++)
            {
                //初始化变量
                year_salary = 0;
                rise_rate = 0;
                rise_type = RiseType.百分比;

                object val = GetFieldValue("一阶增幅" + i.ToString());
                rise_rate = Convert.ToDecimal(val);
                if (rise_rate == 0) break;
                year_salary = Math.Round(last_year_salary * (100 + rise_rate) * (decimal)0.01, 1);

                CreateOrUpdatePayStandard(i, rise_rate, year_salary, rise_type);

                last_year_salary = year_salary;
            }
            //创建二阶起薪记录
            if (this.二阶起薪 > 0)
            {
                if (this.二阶起薪方式 == (int)RiseType.百分比) //如果是百分比
                {
                    rise_rate = this.二阶起薪;
                    year_salary = Math.Round(last_year_salary * (100 + rise_rate) * (decimal)0.01, 1);
                }
                else
                {
                    year_salary = this.二阶起薪;
                    rise_rate = 100 * ((decimal)(year_salary - last_year_salary) / (decimal)last_year_salary);
                    rise_rate = Math.Round(rise_rate, 2);
                }
                CreateOrUpdatePayStandard(100, rise_rate, year_salary, this.二阶起薪方式 == 0 ? RiseType.百分比 : RiseType.金额);
                last_year_salary = year_salary;

                //创建二阶提资标准记录
                for (int i = 1; i <= 6; i++)
                {
                    //初始化变量
                    year_salary = 0;
                    rise_rate = 0;
                    rise_type = RiseType.百分比;

                    object val = GetFieldValue("二阶增幅" + i.ToString());
                    rise_rate = Convert.ToDecimal(val);
                    if (rise_rate == 0) break;
                    year_salary = Math.Round(last_year_salary * (100 + rise_rate) * (decimal)0.01, 1);
                    //序数的基数是每阶+100，起阶是0, 满阶基数是 10000
                    CreateOrUpdatePayStandard(i + 100, rise_rate, year_salary, rise_type);

                    last_year_salary = year_salary;
                }
            }
            //创建满阶提资标准记录
            if (this.满阶起薪方式 == (int)RiseType.百分比) //如果是百分比
            {
                rise_rate = this.满阶A起薪;
                CreateOrUpdatePayStandard("A", 10000, this.满阶A起薪, 0, RiseType.百分比);

                rise_rate = this.满阶B起薪;
                CreateOrUpdatePayStandard("B", 10000, this.满阶B起薪, 0, RiseType.百分比);

                rise_rate = this.满阶C起薪;
                CreateOrUpdatePayStandard("C", 10000, this.满阶C起薪, 0, RiseType.百分比);

            }
            else
            {
                year_salary = this.满阶A起薪;
                CreateOrUpdatePayStandard("A", 10000, 0, this.满阶A起薪, RiseType.金额);

                year_salary = this.满阶B起薪;
                CreateOrUpdatePayStandard("B", 10000, 0, this.满阶B起薪, RiseType.金额);

                year_salary = this.满阶C起薪;
                CreateOrUpdatePayStandard("C", 10000, 0, this.满阶C起薪, RiseType.金额);
            }
        }

        //获取属性值
        private object GetFieldValue(string propertyName)
        {
            PropertyInfo property = this.GetType().GetProperty(propertyName);
            if (property == null) return null;
            return property.GetValue(this, null);
        }
        /// <summary>
        /// 创建或更新提资标准
        /// </summary>
        /// <param name="seq">序号</param>
        /// <param name="rise_rate">增幅</param>
        /// <param name="year_salary">年薪</param>
        /// <param name="rise_type">提资方式</param>
        private void CreateOrUpdatePayStandard(string level, int seq, decimal rise_rate, decimal year_salary, RiseType rise_type)
        {
            ManagementTraineePayRiseStandard m = ManagementTraineePayRiseStandard.AddManagementTraineePayRiseStandard(届别, 岗位级别, 类别, level, seq);
            
            m.序号 = 序号;
            m.增幅 = rise_rate;
            m.年薪 = year_salary;
            m.提资方式 = (int)rise_type;
            if (AccessController.CurrentUser != null) m.创建人 = AccessController.CurrentUser.姓名;
            m.Save();
        }

        private void CreateOrUpdatePayStandard(int seq, decimal rise_rate, decimal year_salary, RiseType rise_type)
        {
            CreateOrUpdatePayStandard("A", seq, rise_rate, year_salary, rise_type);
            CreateOrUpdatePayStandard("B", seq, rise_rate, year_salary, rise_type);
            CreateOrUpdatePayStandard("C", seq, rise_rate, year_salary, rise_type);
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

        ManagementTraineePayRiseStandardInput anotherInput = null;
        [Browsable(false)]
        public ManagementTraineePayRiseStandardInput 另一人录入的记录
        {
            get
            {
                if (anotherInput == null)
                {
                    anotherInput = GetManagementTraineePayRiseStandardInput(届别, 岗位级别, 类别, !是验证录入);
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
            get { return 届别 + "$$" + 岗位级别 + "$$" + 类别 + "$$" + this.是验证录入; }
        }

        #endregion

        [NonPersistent]
        public bool CopyEffective { get; set; }
    }
}
