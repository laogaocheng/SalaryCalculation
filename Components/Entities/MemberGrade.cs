using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using DevExpress.Xpo.DB;
using log4net;
using YiKang;
using System.Data.SqlClient;

namespace Hwagain.SalaryCalculation.Components
{
    public partial class MemberGrade
    {
        static readonly ILog log = LogManager.GetLogger(typeof(MemberGrade));

        #region GetMemberGrade
        /// <summary>
        /// 通过 Id 获取线路
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static MemberGrade GetMemberGrade(Guid id)
        {
            MemberGrade obj = (MemberGrade)Session.DefaultSession.GetObjectByKey(typeof(MemberGrade), id);
            return obj;
        }

        public static MemberGrade GetMemberGrade(string emplid, string company, string grade)
        {
            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                       new BinaryOperator("员工编号", emplid, BinaryOperatorType.Equal),
                       new BinaryOperator("公司名称", company, BinaryOperatorType.Equal),
                       new BinaryOperator("工资职等", grade, BinaryOperatorType.Equal));

            XPCollection objset = new XPCollection(typeof(MemberGrade), criteria, new SortProperty("工资职等", SortingDirection.Ascending));

            if (objset.Count > 0)
            {
                return (MemberGrade)objset[0];
            }
            else
                return null;
        }

        #endregion

        #region GetMemberGrades

        //获取所有职等
        public static List<MemberGrade> GetMemberGrades(string emplid, string company)
        {
            List<MemberGrade> list = new List<MemberGrade>();

            GroupOperator criteria = new GroupOperator(GroupOperatorType.And);

            if (!string.IsNullOrEmpty(emplid)) criteria.Operands.Add(new BinaryOperator("员工编号", emplid, BinaryOperatorType.Equal));
            if (!string.IsNullOrEmpty(company)) criteria.Operands.Add(new BinaryOperator("公司名称", company, BinaryOperatorType.Equal));

            XPCollection objset = new XPCollection(typeof(MemberGrade), criteria, new SortProperty("工资职等", SortingDirection.Ascending));

            foreach (MemberGrade grade in objset)
            {
                list.Add(grade);
            }
            return list;
        }
        #endregion

        #region GetAll

        //获取所有职等
        public static List<MemberGrade> GetAll()
        {
            List<MemberGrade> list = new List<MemberGrade>();

            XPCollection objset = new XPCollection(typeof(MemberGrade));

            foreach (MemberGrade group in objset)
            {
                list.Add(group);
            }
            return list;
        }
        #endregion

        #region OnSaving

        protected override void OnSaving()
        {
            MemberGrade found = GetMemberGrade(this.员工编号, this.公司名称, this.工资职等);
            if (found != null && found.标识 != this.标识)
                throw new Exception("已具备这个职等的权限，不能重复设置.");
            else
                base.OnSaving();
        }
        #endregion

        #region ClearMemberGrade

        //清除
        public static void ClearMemberGrade(string emplid)
        {
            string sql = "DELETE FROM 会员_等级 WHERE 员工编号 = '" + emplid + "'";
            using (SqlConnection connection = new SqlConnection(MyHelper.GetConnectionString()))
            {
                YiKang.Data.SqlHelper.ExecuteNonQuery(connection, System.Data.CommandType.Text, sql);
            }
        }
        #endregion

        #region AddMemberGrade

        public static MemberGrade AddMemberGrade(string emplid, string company, string grade)
        {
            MemberGrade memberGrade = MemberGrade.GetMemberGrade(emplid, company, grade);
            if (memberGrade == null)
            {
                memberGrade = new MemberGrade();
                memberGrade.员工编号 = emplid;
                memberGrade.公司名称 = company;
                memberGrade.工资职等 = grade;
                memberGrade.Save();
            }
            return memberGrade;
        }
        #endregion

        #region ToString
        public override string ToString()
        {
            return this.工资职等;
        }
        #endregion
    }
}
