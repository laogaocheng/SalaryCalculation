﻿using System;
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
    public partial class SalaryStructureEntry
    {
        static readonly ILog log = LogManager.GetLogger(typeof(SalaryStructureEntry));
        public static ICache<string, SalaryStructureEntry> SALARY_STRUCTURE_ENTRY_CACHE = MemoryCache<string, SalaryStructureEntry>.Instance;

        #region GetSalaryStructureEntry

        public static SalaryStructureEntry GetSalaryStructureEntry(Guid id)
        {
            SalaryStructureEntry obj = (SalaryStructureEntry)Session.DefaultSession.GetObjectByKey(typeof(SalaryStructureEntry), id);
            return obj;
        }

        public static SalaryStructureEntry GetSalaryStructureEntry(string emplid, DateTime effDate, bool isVerify)
        {
            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                       new BinaryOperator("员工编号", emplid, BinaryOperatorType.Equal),
                       new BinaryOperator("开始执行日期", effDate, BinaryOperatorType.Equal),
                       new BinaryOperator("是验证录入", isVerify, BinaryOperatorType.Equal));

            XPCollection objset = new XPCollection(typeof(SalaryStructureEntry), criteria, new SortProperty("录入时间", SortingDirection.Ascending));

            if (objset.Count > 0)
            {
                return (SalaryStructureEntry)objset[0];
            }
            else
                return null;
        }

        #endregion

        #region GetSalaryStructureEntrys

        public static List<SalaryStructureEntry> GetSalaryStructureEntrys(string emplid, bool isVerify)
        {
            List<SalaryStructureEntry> list = new List<SalaryStructureEntry>();

            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                       new BinaryOperator("员工编号", emplid, BinaryOperatorType.Equal),
                       new BinaryOperator("是验证录入", isVerify, BinaryOperatorType.Equal));
            
            XPCollection objset = new XPCollection(typeof(SalaryStructureEntry), criteria, new SortProperty("录入时间", SortingDirection.Ascending));

            foreach (SalaryStructureEntry ms in objset)
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
        public static SalaryStructureEntry GetEditingRow(string emplid, bool isVerify)
        {
            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                       new BinaryOperator("员工编号", emplid, BinaryOperatorType.Equal),
                       new NullOperator("生效时间"),
                       new BinaryOperator("是验证录入", isVerify, BinaryOperatorType.Equal));

            XPCollection objset = new XPCollection(typeof(SalaryStructureEntry), criteria, new SortProperty("录入时间", SortingDirection.Ascending));

            if (objset.Count > 0)
            {
                return (SalaryStructureEntry)objset[0];
            }
            else
                return null;
        }
        #endregion

        #region GetEditingRows

        /// <returns></returns>
        public static List<SalaryStructureEntry> GetEditingRows(bool isVerify)
        {
            List<SalaryStructureEntry> rows = new List<SalaryStructureEntry>();

            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                       new NullOperator("生效时间"),
                       new BinaryOperator("是验证录入", isVerify, BinaryOperatorType.Equal));

            XPCollection objset = new XPCollection(typeof(SalaryStructureEntry), criteria, new SortProperty("录入时间", SortingDirection.Ascending));

            foreach (SalaryStructureEntry input in objset)
            {
                rows.Add(input);
            }
            return rows;
        }
        #endregion

        #region ClearSalaryStructureEntry

        //清除正在录入的记录(只能清除未生效的记录)
        public static void ClearSalaryStructureEntry(string emplid )
        {
            string sql = "DELETE FROM 薪酬结构_录入 WHERE (员工编号 = '" + emplid + "') AND 生效时间 IS NULL";
            using (SqlConnection connection = new SqlConnection(MyHelper.GetConnectionString()))
            {
                YiKang.Data.SqlHelper.ExecuteNonQuery(connection, System.Data.CommandType.Text, sql);
                
            }
        }
        #endregion

        #region AddSalaryStructureEntry

        public static SalaryStructureEntry AddSalaryStructureEntry(string emplid, DateTime effDate, bool isVerify)
        {            
            SalaryStructureEntry item = GetSalaryStructureEntry(emplid, effDate, isVerify);
            if (item == null)
            {
                item = new SalaryStructureEntry();

                item.标识 = Guid.NewGuid();
                item.员工编号 = emplid;
                item.开始执行日期 = effDate;
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

            SalaryStructure m = SalaryStructure.AddSalaryStructure(this.员工编号, this.开始执行日期);

            this.CopyWatchMember(m);

            m.创建人 = this.录入人;
            m.创建时间 = DateTime.Now;
            m.Save();

            //更新生效标记
            if (!this.已生效)
            {
                this.生效时间 = DateTime.Now;
                this.Save();

                SalaryStructureEntry opposite = 另一人录入的记录;
                opposite.生效时间 = DateTime.Now;
                opposite.Save();
            }
        }
        #endregion

        #region OnSaving

        protected override void OnSaving()
        {
            if (string.IsNullOrEmpty(this.员工编号)) throw new Exception("员工编号不能为空");
            
            SalaryStructureEntry found = GetEditingRow(this.员工编号, this.是验证录入);
            if (found != null && found.标识 != this.标识)
                throw new Exception("该员工的薪资结构正在录入，不能重复创建。");
            else
                base.OnSaving();

            contentDifferentFields = null;
            SALARY_STRUCTURE_ENTRY_CACHE.Set(CacheKey, this, TimeSpan.FromHours(1));
        }
        #endregion

        #region OnSaved

        protected override void OnSaved()
        {
            base.OnSaved();
            if (录入人 == null)
            {
                //如果对向没有记录，自动创建
                SalaryStructureEntry opposite = GetEditingRow(this.员工编号, !this.是验证录入);
                if (opposite == null)
                {
                    opposite = new SalaryStructureEntry();

                    opposite.标识 = Guid.NewGuid();
                    opposite.员工编号 = this.员工编号;
                    opposite.是验证录入 = !this.是验证录入;

                    opposite.录入人 = "";
                    opposite.录入时间 = DateTime.Now;
                    opposite.Save();
                }
            }
        }
        #endregion

        #region OnDeleting

        protected override void OnDeleting()
        {
            if (已生效) throw new Exception("不能删除已生效的记录");
            base.OnDeleting();
            SALARY_STRUCTURE_ENTRY_CACHE.Remove(CacheKey);   
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

        SalaryStructureEntry anotherInput = null;
        [Browsable(false)]
        public SalaryStructureEntry 另一人录入的记录
        {
            get
            {
                if (anotherInput == null)
                {
                    if(this.已生效)
                        anotherInput = GetSalaryStructureEntry(this.员工编号, this.开始执行日期, !this.是验证录入);
                    else
                        anotherInput = GetEditingRow(this.员工编号, !this.是验证录入);
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
            get { return this.员工编号 + "$$" + this.开始执行日期 + "$$" + this.是验证录入; }
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

        #region 姓名

        public string 姓名
        {
            get
            {
                if (员工信息 != null)
                {
                    return 员工信息.姓名;
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

        [NonPersistent]
        public string 录入按钮文字
        {
            get { return "录入"; }
        }
    }
}
