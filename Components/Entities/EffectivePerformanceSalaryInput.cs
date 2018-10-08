using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using DevExpress.Xpo.DB;
using Hwagain.Interface;
using System.ComponentModel;
using Hwagain.Components;
using System.Data.SqlClient;
using YiKang;
using log4net;
using System.Data;
using System.Data.OleDb;

namespace Hwagain.SalaryCalculation.Components
{
    public partial class EffectivePerformanceSalaryInput : IDoubleManInput
    {
        static readonly ILog log = LogManager.GetLogger(typeof(EffectivePerformanceSalaryInput));

        #region EffectivePerformanceSalaryInput

        /// <param name="id"></param>
        /// <returns></returns>
        public static EffectivePerformanceSalaryInput Get(Guid id)
        {
            EffectivePerformanceSalaryInput obj = (EffectivePerformanceSalaryInput)MyHelper.XpoSession.GetObjectByKey(typeof(EffectivePerformanceSalaryInput), id);
            return obj;
        }

        public static EffectivePerformanceSalaryInput Get(string number, bool isVerify)
        {
            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                new BinaryOperator("编号", number, BinaryOperatorType.Equal),
                new BinaryOperator("是验证录入", isVerify, BinaryOperatorType.Equal));
            
            XPCollection objset = new XPCollection(MyHelper.XpoSession, typeof(EffectivePerformanceSalaryInput), criteria, new SortProperty("录入时间", SortingDirection.Descending));

            if (objset.Count > 0)
                return (EffectivePerformanceSalaryInput)objset[0];
            else
                return null;
        }
        /// <summary>
        /// 获取正在录入的记录
        /// </summary>
        /// <param name="stepId"></param>
        /// <param name="isVerify"></param>
        /// <returns></returns>
        public static EffectivePerformanceSalaryInput GetEditing(string empNo, int year, int month, bool isVerify)
        {
            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                new BinaryOperator("员工编号", empNo, BinaryOperatorType.Equal),
                new BinaryOperator("年", year, BinaryOperatorType.Equal),
                new BinaryOperator("月", month, BinaryOperatorType.Equal),
                new BinaryOperator("是验证录入", isVerify, BinaryOperatorType.Equal),
                new BinaryOperator("双人录入结果", "两人录入完全一致", BinaryOperatorType.NotEqual));

            XPCollection objset = new XPCollection(MyHelper.XpoSession, typeof(EffectivePerformanceSalaryInput), criteria, new SortProperty("录入时间", SortingDirection.Descending));

            if (objset.Count > 0)
                return (EffectivePerformanceSalaryInput)objset[0];
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
        public static List<EffectivePerformanceSalaryInput> GetEditingRows(int year, int month, bool isVerify)
        {
            List<EffectivePerformanceSalaryInput> rows = new List<EffectivePerformanceSalaryInput>();

            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                new BinaryOperator("年", year, BinaryOperatorType.Equal),
                new BinaryOperator("月", month, BinaryOperatorType.Equal),
                new BinaryOperator("是验证录入", isVerify, BinaryOperatorType.Equal),
                new BinaryOperator("双人录入结果", "两人录入完全一致", BinaryOperatorType.NotEqual));

            XPCollection objset = new XPCollection(MyHelper.XpoSession, typeof(EffectivePerformanceSalaryInput), criteria, new SortProperty("录入时间", SortingDirection.Descending));

            foreach (EffectivePerformanceSalaryInput input in objset)
            {
                rows.Add(input);
            }
            return rows;
        }
        #endregion

        #region GetEffectivePerformanceSalaryInputGroup

        public static EffectivePerformanceSalaryInputGroup GetEffectivePerformanceSalaryInputGroup(string number)
        {
            EffectivePerformanceSalaryInputGroup inputGroup = new EffectivePerformanceSalaryInputGroup();

            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                       new BinaryOperator("编号", number, BinaryOperatorType.Equal));

            XPCollection objset = new XPCollection(MyHelper.XpoSession, typeof(EffectivePerformanceSalaryInput), criteria, new SortProperty("录入时间", SortingDirection.Descending));

            foreach (EffectivePerformanceSalaryInput di in objset)
            {
                if (di.是验证录入)
                    inputGroup.B = di;
                else
                    inputGroup.A = di;
            }
            return inputGroup;
        }
        #endregion

        #region AddEffectivePerformanceSalaryInput

        public static EffectivePerformanceSalaryInput AddEffectivePerformanceSalaryInput(string number, string empNo, bool isVerify)
        {
            EffectivePerformanceSalaryInput item = Get(number, isVerify);
            if (item == null)
            {
                item = new EffectivePerformanceSalaryInput();
                item.标识 = Guid.NewGuid();
                item.编号 = number;
                item.员工编号 = empNo;
                item.是验证录入 = isVerify;
                item.双人录入结果 = "";
                item.录入人 = "";
                item.录入时间 = DateTime.Now;

                EffectivePerformanceSalaryInput otherItem = Get(number, !isVerify);
                if(otherItem  != null)
                {
                    item.姓名 = otherItem.姓名;
                    item.年 = otherItem.年;
                    item.月 = otherItem.月;
                }

                item.Save();
            }
            return item;
        }
        #endregion

        #region OnSaving

        protected override void OnSaving()
        {
            if (string.IsNullOrEmpty(this.员工编号)) throw new Exception("员工编号不能为空。");
            if (PsHelper.GetEmplName(this.员工编号) == "") throw new Exception("找不到指定员工编号的员工。");            

            if (string.IsNullOrEmpty(编号))
            {
                if (this.标识 == Guid.Empty) this.标识 = Guid.NewGuid();
                this.编号 = GetNewNumber();
                //如果是新编号，更新编号信息的当前序号
                this.NumberInfo.UpdateCurrentSN();

                EffectivePerformanceSalaryInput found = Get(this.编号, this.是验证录入);
                if (found != null && found.标识 != this.标识) throw new Exception(String.Format("同一编号【{0}】不能重复创建，请稍后重试。", this.编号));

                found = GetEditing(this.员工编号, this.年, this.月, this.是验证录入);
                if (found != null && found.标识 != this.标识) throw new Exception(String.Format("该员工【{0}】已经有一条执行的绩效工资记录正在录入，不能重复。", this.员工编号));
            }
            
            if (this.双人录入结果 == null) this.双人录入结果 = "";

            base.OnSaving();
        }

        #endregion

        #region OnDeleting

        protected override void OnDeleting()
        {
            base.OnDeleting();
        }
        #endregion

        #region OnDeleted

        protected override void OnDeleted()
        {
            EffectivePerformanceSalaryInputGroup inputGroup = GetEffectivePerformanceSalaryInputGroup(this.编号);
            EffectivePerformanceSalaryInput anotherInput = this.是验证录入 ? inputGroup.A : inputGroup.B;
            //删除对向记录
            if (anotherInput != null) anotherInput.Delete();
            base.OnDeleted();
        }
        #endregion

        #region UpdateComparingResult

        //更新比较结果
        public void UpdateComparingResult(string result)
        {
            string sql = String.Format("UPDATE 执行绩效工资_录入 SET 双人录入结果 = '{0}' WHERE 标识 = '{1}'", result, this.标识);
            using (SqlConnection connection = new SqlConnection(MyHelper.GetConnectionString()))
            {
                YiKang.Data.SqlHelper.ExecuteNonQuery(connection, System.Data.CommandType.Text, sql);
                //如果已生效
                if (result == "两人录入完全一致")
                {
                    sql = String.Format("UPDATE 执行绩效工资_录入 SET 生效时间 = '{0}' WHERE 标识 = '{1}'  AND 生效时间 IS NULL", DateTime.Now, this.标识);
                    YiKang.Data.SqlHelper.ExecuteNonQuery(connection, System.Data.CommandType.Text, sql);
                }
            }            
        }
        #endregion

        #region OnSaved

        protected override void OnSaved()
        {
            //创建验证录入的记录
            AddEffectivePerformanceSalaryInput(this.编号, this.员工编号, !this.是验证录入);
            base.OnSaved();
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

        void GetModifiyFields()
        {
            contentDifferentFields = new List<ModifyField>();

            EffectivePerformanceSalaryInputGroup inputGroup = GetEffectivePerformanceSalaryInputGroup(this.编号);

            if (inputGroup.A != null && inputGroup.B != null)
            {
                inputGroup.A.Reload();
                inputGroup.B.Reload();
                contentDifferentFields = MyHelper.GetModifyFields(inputGroup.A, inputGroup.B);
            }
        }
        #endregion

        #region GetNewNumber
        //获取新编号
        public string GetNewNumber()
        {
            if (this.NumberInfo != null)
            {
                return this.NumberInfo.GetNewNumber(DateTime.Now.ToString("yy"));
            }
            else
                throw new Exception("无法获取编号信息，请联系系统管理员设置编号信息。");
        }
        #endregion

        #region NumberInfo

        NumberInfo _numberInfo = null;
        [NonPersistent]
        [Browsable(false)]
        public NumberInfo NumberInfo
        {
            get
            {
                if (_numberInfo == null)
                {
                    _numberInfo = NumberInfo.GetNumberInfo("执行绩效工资录入");
                }
                return _numberInfo;
            }
            set
            {
                _numberInfo = value;
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
                if (contentDifferentFields == null)
                {
                    contentDifferentFields = new List<ModifyField>();

                    EffectivePerformanceSalaryInputGroup inputGroup = GetEffectivePerformanceSalaryInputGroup(this.编号);

                    if (inputGroup.A != null && inputGroup.B != null)
                    {
                        contentDifferentFields = MyHelper.GetModifyFields(inputGroup.A, inputGroup.B);
                    }

                }
                return contentDifferentFields;
            }
        }
        #endregion

        #region 另一人录入的记录

        EffectivePerformanceSalaryInput anotherInput = null;
        [Browsable(false)]
        public IDoubleManInput 另一人录入的记录
        {
            get
            {
                if (anotherInput == null)
                {
                    EffectivePerformanceSalaryInputGroup inputGroup = GetEffectivePerformanceSalaryInputGroup(this.编号);
                    anotherInput = this.是验证录入 ? inputGroup.A : inputGroup.B;
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
                return anotherInput != null;
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
    }
}
