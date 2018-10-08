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
    public partial class PersonReimbursementInput : IDoubleManInput
    {
        static readonly ILog log = LogManager.GetLogger(typeof(PersonReimbursementInput));

        #region PersonReimbursementInput

        /// <param name="id"></param>
        /// <returns></returns>
        public static PersonReimbursementInput Get(Guid id)
        {
            PersonReimbursementInput obj = (PersonReimbursementInput)MyHelper.XpoSession.GetObjectByKey(typeof(PersonReimbursementInput), id);
            return obj;
        }

        public static PersonReimbursementInput Get(string number, bool isVerify)
        {
            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                new BinaryOperator("编号", number, BinaryOperatorType.Equal),
                new BinaryOperator("是验证录入", isVerify, BinaryOperatorType.Equal));
            
            XPCollection objset = new XPCollection(MyHelper.XpoSession, typeof(PersonReimbursementInput), criteria, new SortProperty("录入时间", SortingDirection.Descending));

            if (objset.Count > 0)
                return (PersonReimbursementInput)objset[0];
            else
                return null;
        }
        /// <summary>
        /// 获取正在录入的记录
        /// </summary>
        /// <param name="stepId"></param>
        /// <param name="isVerify"></param>
        /// <returns></returns>
        public static PersonReimbursementInput GetEditing(string empNo, int year, int month, string itemName, bool isVerify)
        {
            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                new BinaryOperator("员工编号", empNo, BinaryOperatorType.Equal),
                new BinaryOperator("年", year, BinaryOperatorType.Equal),
                new BinaryOperator("月", month, BinaryOperatorType.Equal),
                new BinaryOperator("项目", itemName, BinaryOperatorType.Equal),
                new BinaryOperator("是验证录入", isVerify, BinaryOperatorType.Equal),
                new BinaryOperator("双人录入结果", "两人录入完全一致", BinaryOperatorType.NotEqual));

            XPCollection objset = new XPCollection(MyHelper.XpoSession, typeof(PersonReimbursementInput), criteria, new SortProperty("录入时间", SortingDirection.Descending));

            if (objset.Count > 0)
                return (PersonReimbursementInput)objset[0];
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
        public static List<PersonReimbursementInput> GetEditingRows(int year, int month, bool isVerify)
        {
            List<PersonReimbursementInput> rows = new List<PersonReimbursementInput>();

            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                new BinaryOperator("年", year, BinaryOperatorType.Equal),
                new BinaryOperator("月", month, BinaryOperatorType.Equal),
                new BinaryOperator("是验证录入", isVerify, BinaryOperatorType.Equal),
                new BinaryOperator("双人录入结果", "两人录入完全一致", BinaryOperatorType.NotEqual));

            XPCollection objset = new XPCollection(MyHelper.XpoSession, typeof(PersonReimbursementInput), criteria, new SortProperty("录入时间", SortingDirection.Descending));

            foreach (PersonReimbursementInput input in objset)
            {
                rows.Add(input);
            }
            return rows;
        }
        #endregion

        #region GetPersonReimbursementInputGroup

        public static PersonReimbursementInputGroup GetPersonReimbursementInputGroup(string number)
        {
            PersonReimbursementInputGroup inputGroup = new PersonReimbursementInputGroup();

            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                       new BinaryOperator("编号", number, BinaryOperatorType.Equal));

            XPCollection objset = new XPCollection(MyHelper.XpoSession, typeof(PersonReimbursementInput), criteria, new SortProperty("录入时间", SortingDirection.Descending));

            foreach (PersonReimbursementInput di in objset)
            {
                if (di.是验证录入)
                    inputGroup.B = di;
                else
                    inputGroup.A = di;
            }
            return inputGroup;
        }
        #endregion

        #region AddPersonReimbursementInput

        public static PersonReimbursementInput AddPersonReimbursementInput(string number, string empNo, bool isVerify)
        {
            PersonReimbursementInput item = Get(number, isVerify);
            if (item == null)
            {
                item = new PersonReimbursementInput();
                item.标识 = Guid.NewGuid();
                item.编号 = number;
                item.员工编号 = empNo;
                item.是验证录入 = isVerify;
                item.双人录入结果 = " ";
                item.录入人 = "   ";
                item.录入时间 = DateTime.Now;

                PersonReimbursementInput otherItem = Get(number, !isVerify);
                if(otherItem  != null)
                {
                    item.姓名 = otherItem.姓名;
                    item.年 = otherItem.年;
                    item.月 = otherItem.月;
                    item.项目 = otherItem.项目;
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
            if (string.IsNullOrEmpty(this.项目)) throw new Exception("项目不能为空。");

            //获取报销标准
            ReimbursementStandard reimbursementStandard = ReimbursementStandard.GetEffective(this.员工编号, this.项目, new DateTime(this.年, this.月, 1));
            if (reimbursementStandard == null)
                throw new Exception("找不到该员工的 " + this.项目 + " 报销标准，不能录入。");
            else
            {
                if (this.报销金额 > reimbursementStandard.报销金额) throw new Exception("报销金额不能大于报销标准。");
            }

            if (string.IsNullOrEmpty(编号))
            {                
                if (this.标识 == Guid.Empty) this.标识 = Guid.NewGuid();
                
                PersonReimbursementInput other = GetEditing(this.员工编号, this.年, this.月, this.项目, !this.是验证录入);
                this.编号 = other == null ? GetNewNumber() : other.编号;
                
                //如果是新编号，更新编号信息的当前序号
                this.NumberInfo.UpdateCurrentSN();

                PersonReimbursementInput found = Get(this.编号, this.是验证录入);
                if (found != null && found.标识 != this.标识) throw new Exception(String.Format("同一编号【{0}】不能重复创建，请稍后重试。", this.编号));

                found = GetEditing(this.员工编号, this.年, this.月, this.项目,this.是验证录入);
                if (found != null && found.标识 != this.标识) throw new Exception(String.Format("该员工【{0}】已经有一条{1}报销记录正在录入，不能重复。", this.员工编号, this.项目));
            }

            if (另一人录入的记录 != null)
            {
                TimeSpan ts = DateTime.Now - 另一人录入的记录.录入时间;
                if (ts.TotalMilliseconds > 10000 && 另一人录入的记录.录入人 == AccessController.CurrentUser.姓名)
                    throw new Exception("两次录入不能是同一个人。");
            }

            if (string.IsNullOrEmpty(this.录入人) || (DateTime.Now - this.录入时间).TotalMilliseconds > 10000)
            {
                this.录入人 = AccessController.CurrentUser.姓名;
                this.录入时间 = DateTime.Now;
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

        #region UpdateComparingResult

        //更新比较结果
        public void UpdateComparingResult(string result)
        {
            //如果没有录入金额，不保存
            if (this.报销金额 <= 0) return;

            string sql = String.Format("UPDATE 个人报销_录入 SET 双人录入结果 = '{0}' WHERE 标识 = '{1}'", result, this.标识);
            using (SqlConnection connection = new SqlConnection(MyHelper.GetConnectionString()))
            {
                YiKang.Data.SqlHelper.ExecuteNonQuery(connection, System.Data.CommandType.Text, sql);
                //如果已生效
                if (result == "两人录入完全一致")
                {
                    sql = String.Format("UPDATE 个人报销_录入 SET 生效时间 = '{0}' WHERE 标识 = '{1}'  AND 生效时间 IS NULL", DateTime.Now, this.标识);
                    YiKang.Data.SqlHelper.ExecuteNonQuery(connection, System.Data.CommandType.Text, sql);
                }
            }
            
        }
        #endregion

        #region OnSaved

        protected override void OnSaved()
        {
            //创建验证录入的记录
            AddPersonReimbursementInput(this.编号, this.员工编号, !this.是验证录入);

            PersonReimbursementInputGroup inputGroup = GetPersonReimbursementInputGroup(this.编号);

            if (inputGroup.A != null && inputGroup.B != null)
            {

                string comparingResult = Compare(inputGroup);

                inputGroup.A.UpdateComparingResult(comparingResult);
                inputGroup.B.UpdateComparingResult(comparingResult);

                if (this.报销金额 > 0) this.双人录入结果 = comparingResult;
            }

            base.OnSaved();
        }
        //更新比较结果
        public void UpdateCompareResult()
        {
            contentDifferentFields = null;
            anotherInput = null;

            PersonReimbursementInputGroup inputGroup = GetPersonReimbursementInputGroup(this.编号);

            if (inputGroup.A != null && inputGroup.B != null)
            {
                string comparingResult = Compare(inputGroup);

                inputGroup.A.UpdateComparingResult(comparingResult);
                inputGroup.B.UpdateComparingResult(comparingResult);

                this.双人录入结果 = comparingResult;
            }
        }

        public string Compare()
        {
            PersonReimbursementInputGroup inputGroup = GetPersonReimbursementInputGroup(this.编号);
            return Compare(inputGroup);
        }

        private string Compare(PersonReimbursementInputGroup inputGroup)
        {
            if (inputGroup.A == null || inputGroup.B == null) return "另一人未录入";

            inputGroup.A.Reload();
            inputGroup.B.Reload();

            anotherInput = this.标识 == inputGroup.A.标识 ? inputGroup.B : inputGroup.A;
            contentDifferentFields = MyHelper.GetModifyFields(inputGroup.A, inputGroup.B);

            string comparingResult = contentDifferentFields.Count == 0 ? "两人录入完全一致" : "两人录入记录不同";
            return comparingResult;
        }
        #endregion

        #region GetModifiyFields

        public void GetModifiyFields()
        {
            contentDifferentFields = new List<ModifyField>();

            PersonReimbursementInputGroup inputGroup = GetPersonReimbursementInputGroup(this.编号);

            if (inputGroup.A != null && inputGroup.B != null)
            {
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
                    _numberInfo = NumberInfo.GetNumberInfo("员工报销记录录入");
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

                    PersonReimbursementInputGroup inputGroup = GetPersonReimbursementInputGroup(this.编号);

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

        PersonReimbursementInput anotherInput = null;
        [Browsable(false)]
        public IDoubleManInput 另一人录入的记录
        {
            get
            {
                if (anotherInput == null)
                {
                    PersonReimbursementInputGroup inputGroup = GetPersonReimbursementInputGroup(this.编号);
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
