using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using DevExpress.Xpo.DB;
using log4net;
using System.Data.SqlClient;

namespace Hwagain.SalaryCalculation.Components
{
    public partial class ManagementTraineePayRiseStandard
    {
        static readonly ILog log = LogManager.GetLogger(typeof(ManagementTraineePayRiseStandard));

        #region GetManagementTraineePayRiseStandard
        
        public static ManagementTraineePayRiseStandard GetManagementTraineePayRiseStandard(Guid id)
        {
            ManagementTraineePayRiseStandard obj = (ManagementTraineePayRiseStandard)Session.DefaultSession.GetObjectByKey(typeof(ManagementTraineePayRiseStandard), id);
            return obj;
        }

        public static ManagementTraineePayRiseStandard GetManagementTraineePayRiseStandard(string division, string grade, string type, string level, int seq)
        {
            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                new BinaryOperator("届别", division, BinaryOperatorType.Equal),
                new BinaryOperator("岗位级别", grade, BinaryOperatorType.Equal),
                new BinaryOperator("类别", type, BinaryOperatorType.Equal),
                new BinaryOperator("能力级别", level, BinaryOperatorType.Equal),
                new BinaryOperator("提资序数", seq, BinaryOperatorType.Equal));

            XPCollection objset = new XPCollection(typeof(ManagementTraineePayRiseStandard), criteria, new SortProperty("创建时间", SortingDirection.Descending));

            if (objset.Count > 0)
            {
                return (ManagementTraineePayRiseStandard)objset[0];
            }
            else
                return null;
        }

        #endregion

        #region GetManagementTraineePayRiseStandardList
        
        public static List<ManagementTraineePayRiseStandard> GetManagementTraineePayRiseStandardList(string division, string grade, string type, string level)
        {
            List<ManagementTraineePayRiseStandard> list = new List<ManagementTraineePayRiseStandard>();

            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                new BinaryOperator("届别", division, BinaryOperatorType.Equal),
                new BinaryOperator("岗位级别", grade, BinaryOperatorType.Equal),
                new BinaryOperator("类别", type, BinaryOperatorType.Equal),
                new BinaryOperator("能力级别", level, BinaryOperatorType.Equal));

            XPCollection objset = new XPCollection(typeof(ManagementTraineePayRiseStandard), criteria, new SortProperty("创建时间", SortingDirection.Descending));

            foreach (ManagementTraineePayRiseStandard item in objset)
            {
                list.Add(item);
            }
            return list;
        }
        #endregion

        #region OnSaving

        protected override void OnSaving()
        {
            if (string.IsNullOrEmpty(this.届别)) throw new Exception("届别不能为空");
            if (string.IsNullOrEmpty(this.岗位级别)) throw new Exception("岗位级别不能为空.");
            if (string.IsNullOrEmpty(this.能力级别)) throw new Exception("能力级别不能为空.");
            
            ManagementTraineePayRiseStandard found = GetManagementTraineePayRiseStandard(届别, 岗位级别, 类别, 能力级别, 提资序数);
            if (found != null && found.标识 != this.标识)
                throw new Exception("已经存在该提资标准，不能重复创建");
            else
                base.OnSaving();
        }
        #endregion

        #region AddManagementTraineePayRiseStandard

        public static ManagementTraineePayRiseStandard AddManagementTraineePayRiseStandard(string division, string grade, string type, string level, int seq)
        {
            ManagementTraineePayRiseStandard item = GetManagementTraineePayRiseStandard(division, grade, type, level, seq);
            if (item == null)
            {
                item = new ManagementTraineePayRiseStandard();

                item.标识 = Guid.NewGuid();
                item.届别 = division;
                item.岗位级别 = grade;
                item.类别 = type;
                item.能力级别 = level;
                item.提资序数 = seq;
                item.创建时间 = DateTime.Now;

                //提资周期
                switch (level)
                {
                    case "A":
                        item.提资周期 = "6个月";
                        break;
                    case "B":
                        item.提资周期 = "9个月";
                        break;
                    case "C":
                        item.提资周期 = "12个月";
                        break;
                }

                item.Save();
            }

            return item;
        }
        #endregion

        #region Count 统计标准数量
        public static int Count(string division, string grade, string type)
        {
            string sql = "SELECT COUNT(*) FROM 管培生_提资标准 WHERE 届别 = '" + division + "' AND 岗位级别='" + grade + "' AND 类别='" + type + "'";
            using (SqlConnection connection = new SqlConnection(MyHelper.GetConnectionString()))
            {
                SqlDataReader dr = YiKang.Data.SqlHelper.ExecuteReader(connection, System.Data.CommandType.Text, sql);
                if(dr.Read())
                {
                    return (int)dr[0];
                }
                dr.Close();
                return -1;
            }
        }
        #endregion

        #region Clear

        public static void Clear(string division, string grade, string type)
        {
            string sql = "DELETE FROM 管培生_提资标准 WHERE 届别 = '" + division + "' AND 岗位级别='" + grade + "' AND 类别='" + type + "'";
            using (SqlConnection connection = new SqlConnection(MyHelper.GetConnectionString()))
            {
                YiKang.Data.SqlHelper.ExecuteNonQuery(connection, System.Data.CommandType.Text, sql);
            }
        }

        #endregion
    }
}
