﻿using System;
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
    public partial class PayRateInput : IDoubleManInput
    {
        static readonly ILog log = LogManager.GetLogger(typeof(PayRateInput));

        #region PayRateInput

        /// <param name="id"></param>
        /// <returns></returns>
        public static PayRateInput Get(Guid id)
        {
            PayRateInput obj = (PayRateInput)MyHelper.XpoSession.GetObjectByKey(typeof(PayRateInput), id);
            return obj;
        }

        public static PayRateInput Get(string number, bool isVerify)
        {
            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                new BinaryOperator("编号", number, BinaryOperatorType.Equal),
                new BinaryOperator("是验证录入", isVerify, BinaryOperatorType.Equal));
            
            XPCollection objset = new XPCollection(MyHelper.XpoSession, typeof(PayRateInput), criteria, new SortProperty("录入时间", SortingDirection.Descending));

            if (objset.Count > 0)
                return (PayRateInput)objset[0];
            else
                return null;
        }

        #endregion

        #region GetEditing
        /// <summary>
        /// 获取正在录入的记录
        /// </summary>
        /// <param name="stepId"></param>
        /// <param name="isVerify"></param>
        /// <returns></returns>
        public static PayRateInput GetEditing(int stepId, bool isVerify)
        {
            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                new BinaryOperator("薪级标识", stepId, BinaryOperatorType.Equal),
                new BinaryOperator("是验证录入", isVerify, BinaryOperatorType.Equal),
                new BinaryOperator("双人录入结果", "两人录入完全一致", BinaryOperatorType.NotEqual));

            XPCollection objset = new XPCollection(MyHelper.XpoSession, typeof(PayRateInput), criteria, new SortProperty("录入时间", SortingDirection.Descending));

            if (objset.Count > 0)
                return (PayRateInput)objset[0];
            else
                return null;
        }
        #endregion

        #region GetEditingRows

        /// <summary>
        /// 获取指定薪等下正在录入的记录
        /// </summary>
        /// <param name="stepId"></param>
        /// <param name="isVerify"></param>
        /// <returns></returns>
        public static List<PayRateInput> GetEditingRows(int gradeId, bool isVerify)
        {
            List<PayRateInput> rows = new List<PayRateInput>();

            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                new BinaryOperator("薪等标识", gradeId, BinaryOperatorType.Equal),
                new BinaryOperator("是验证录入", isVerify, BinaryOperatorType.Equal),
                new BinaryOperator("双人录入结果", "两人录入完全一致", BinaryOperatorType.NotEqual));

            XPCollection objset = new XPCollection(MyHelper.XpoSession, typeof(PayRateInput), criteria, new SortProperty("录入时间", SortingDirection.Descending));

            foreach (PayRateInput input in objset)
            {
                rows.Add(input);
            }
            return rows;
        }
        #endregion

        #region GetPayRateInputs

        public static List<PayRateInput> GetPayRateInputs(string setId, string salPlan, string grade)
        {
            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                new BinaryOperator("集合", setId, BinaryOperatorType.Equal),
                new BinaryOperator("薪酬体系", salPlan, BinaryOperatorType.Equal),
                new BinaryOperator("薪等编号", grade, BinaryOperatorType.Equal));

            using (XPCollection objset = new XPCollection(MyHelper.XpoSession, typeof(PayRateInput), criteria, new SortProperty("序号", SortingDirection.Ascending)))
            {
                List<PayRateInput> list = new List<PayRateInput>();
                foreach (PayRateInput bi in objset)
                {
                    list.Add(bi);
                }
                return list;
            }
        }
        #endregion

        #region GetPayRateInputGroup

        public static PayRateInputGroup GetPayRateInputGroup(string number)
        {
            PayRateInputGroup inputGroup = new PayRateInputGroup();

            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                       new BinaryOperator("编号", number, BinaryOperatorType.Equal));

            XPCollection objset = new XPCollection(MyHelper.XpoSession, typeof(PayRateInput), criteria, new SortProperty("录入时间", SortingDirection.Descending));

            foreach (PayRateInput di in objset)
            {
                if (di.是验证录入)
                    inputGroup.B = di;
                else
                    inputGroup.A = di;
            }
            return inputGroup;
        }
        #endregion

        #region AddPayRateInput

        public static PayRateInput AddPayRateInput(string number, bool isVerify)
        {
            PayRateInput item = Get(number, isVerify);
            if (item == null)
            {
                item = new PayRateInput();
                item.标识 = Guid.NewGuid();
                item.编号 = number;
                item.是验证录入 = isVerify;
                item.录入人 = "   "; 
                item.录入时间 = DateTime.Now;

                item.Save();
            }
            return item;
        }
        #endregion

        #region OnSaving

        protected override void OnSaving()
        {
            if (string.IsNullOrEmpty(编号))
            {
                if (this.标识 == Guid.Empty) this.标识 = Guid.NewGuid();
                this.编号 = GetNewNumber();
                //如果是新编号，更新编号信息的当前序号
                this.NumberInfo.UpdateCurrentSN();

                PayRateInput found = Get(this.编号, this.是验证录入);
                if (found != null && found.标识 != this.标识) throw new Exception(String.Format("同一编号不能重复创建，请稍后重试。", this.编号));
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
            string sql = String.Format("UPDATE 职级工资_录入 SET 双人录入结果 = '{0}' WHERE 标识 = '{1}'", result, this.标识);
            using (SqlConnection connection = new SqlConnection(MyHelper.GetConnectionString()))
            {
                YiKang.Data.SqlHelper.ExecuteNonQuery(connection, System.Data.CommandType.Text, sql);
                //如果已生效
                if (result == "两人录入完全一致")
                {
                    sql = String.Format("UPDATE 职级工资_录入 SET 生效时间 = '{0}' WHERE 标识 = '{1}'  AND 生效时间 IS NULL", DateTime.Now, this.标识);
                    YiKang.Data.SqlHelper.ExecuteNonQuery(connection, System.Data.CommandType.Text, sql);
                }
            }
            
        }
        #endregion

        #region OnSaved

        protected override void OnSaved()
        {
            base.OnSaved();
        }
        //更新比较结果
        public void UpdateCompareResult()
        {
            contentDifferentFields = null;
            anotherInput = null;

            PayRateInputGroup inputGroup = GetPayRateInputGroup(this.编号);

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
            PayRateInputGroup inputGroup = GetPayRateInputGroup(this.编号);
            return Compare(inputGroup);
        }

        private string Compare(PayRateInputGroup inputGroup)
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

        #region OnLoaded

        protected override void OnLoaded()
        {
            //如果薪级已经被删除，这条录入记录也删除
            if (薪级 == null) 
                this.Delete();

            base.OnLoaded();
        }
        #endregion

        #region GetModifiyFields

        public void GetModifiyFields()
        {
            contentDifferentFields = new List<ModifyField>();

            PayRateInputGroup inputGroup = GetPayRateInputGroup(this.编号);

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
                    _numberInfo = NumberInfo.GetNumberInfo("职级工资录入");
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

                    PayRateInputGroup inputGroup = GetPayRateInputGroup(this.编号);

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

        PayRateInput anotherInput = null;
        [Browsable(false)]
        public IDoubleManInput 另一人录入的记录
        {
            get
            {
                if (anotherInput == null)
                {
                    PayRateInputGroup inputGroup = GetPayRateInputGroup(this.编号);
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

        #region 薪级
        SalaryNode step = null;
        [NonPersistent]
        public SalaryNode 薪级
        {
            get
            {
                if (step == null) step = SalaryNode.GetSalaryNode(this.薪级标识);
                return step;
            }
        }
        #endregion

        #region 薪级名称
        [NonPersistent]
        public string 薪级名称
        {
            get
            {
                if (this.薪级 != null)
                    return this.薪级.名称;
                else
                    return "";
            }
        }
        #endregion

        #region 现行标准

        public string 现行标准
        {
            get
            {
                StepPayRate rate = StepPayRate.GetEffective(this.薪级标识, DateTime.Today);
                if (rate != null)
                {
                    return rate.工资额.ToString("n0");
                }
                else
                    return "";
            }
        }
        #endregion

        #region 现行标准执行日期

        public string 现行标准执行日期
        {
            get
            {
                StepPayRate rate = StepPayRate.GetEffective(this.薪级标识, DateTime.Today);
                if (rate != null)
                {
                    return rate.执行日期.ToString("yyyy-M-d");
                }
                else
                    return "";
            }
        }
        #endregion
    }
}
