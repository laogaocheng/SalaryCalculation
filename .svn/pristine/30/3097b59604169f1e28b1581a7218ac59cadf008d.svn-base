using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using log4net;
using DevExpress.Data.Filtering;
using System.Data.SqlClient;
using Hwagain;
using YiKang;
using System.Data.OleDb;

namespace Hwagain.SalaryCalculation.Components
{
    public partial class KpiItem
    {
        static readonly ILog log = LogManager.GetLogger(typeof(KpiItem));

        #region GetKpiItem
        /// <summary>
        /// 通过 Id 获取
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static KpiItem GetKpiItem(Guid id)
        {
            KpiItem obj = (KpiItem)MyHelper.XpoSession.GetObjectByKey(typeof(KpiItem), id);
            return obj;
        }
        /// <summary>
        /// </summary>
        /// <param name="empNo"></param>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="kpiName">考核项目名称</param>
        /// <returns></returns>
        public static KpiItem GetKpiItem(string empNo, int year, int month, string kpiName)
        {
            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                       new BinaryOperator("员工编号", empNo, BinaryOperatorType.Equal),
                       new BinaryOperator("年", year, BinaryOperatorType.Equal),
                       new BinaryOperator("月", month, BinaryOperatorType.Equal),
                       new BinaryOperator("考核项目名称", kpiName, BinaryOperatorType.Equal)
                       );

            XPCollection objset = new XPCollection(MyHelper.XpoSession, typeof(KpiItem), criteria, new SortProperty("上次同步时间", SortingDirection.Descending));

            if (objset.Count > 0)
            {
                return (KpiItem)objset[0];
            }
            else
                return null;
        }
        #endregion

        #region AddKpiItem

        public static KpiItem AddKpiItem(string empNo, int year, int month, string kpiName)
        {
            KpiItem kpi = GetKpiItem(empNo, year, month, kpiName);
            if (kpi == null)
            {
                kpi = new KpiItem();
                kpi.标识 = Guid.NewGuid();
                kpi.员工编号 = empNo;
                kpi.年 = year;
                kpi.月 = month;
                kpi.考核项目名称 = kpiName;
                kpi.Save();
            }
            return kpi;
        }
        #endregion

        #region GetKpiItems

        public static List<KpiItem> GetKpiItems(string empNo, int year, int month)
        {
            List<KpiItem> list = new List<KpiItem>();

            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                       new BinaryOperator("员工编号", year, BinaryOperatorType.Equal),
                       new BinaryOperator("年", year, BinaryOperatorType.Equal),
                       new BinaryOperator("月", month, BinaryOperatorType.Equal)
                       );

            XPCollection objset = new XPCollection(MyHelper.XpoSession, typeof(KpiItem), criteria, new SortProperty("创建时间", SortingDirection.Ascending));

            foreach (KpiItem item in objset)
            {
                list.Add(item);
            }

            return list;
        }

        #endregion

        #region DeleteAll

        //删除指定月份的绩效考核结果
        static bool DeleteAll(int year, int month)
        {
            try
            {
                string sql = String.Format("DELETE FROM 绩效考核结果 WHERE 年={0} AND 月={1}", year, month);
                using (SqlConnection connection = new SqlConnection(MyHelper.GetConnectionString()))
                {
                    YiKang.Data.SqlHelper.ExecuteNonQuery(connection, System.Data.CommandType.Text, sql);
                    connection.Close();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region OnLoaded

        protected override void OnLoaded()
        {            
            base.OnLoaded();
        }
        #endregion

        #region OnSaved

        protected override void OnSaved()
        {            
            base.OnSaved();
        }
        #endregion

        #region SychKpiItem

        /// <summary>
        /// 同步上月绩效考核结果
        /// </summary>
        /// <returns></returns>
        public static StringBuilder SychKpiItem()
        {
            DateTime prevMonth = DateTime.Now.AddMonths(-1);
            return SychKpiItem(prevMonth.Year, prevMonth.Month);
        }

        public static StringBuilder SychKpiItem(int year, int month)
        {
            //清除历史数据
            DeleteAll(year, month);

            StringBuilder sb = new StringBuilder();

            OleDbConnection conn = new OleDbConnection(MyHelper.GetPsConnectionString());
            using (conn)
            {
                OleDbDataReader rs = null;
                try
                {
                    conn.Open();
                    using (OleDbCommand cmd = conn.CreateCommand())
                    {
                        string sql = String.Format("SELECT * FROM C_INF_PER_KPI_DTL WHERE YEAR = '{0}' AND MONTH = '{1}' ORDER BY EMPLID", year, month);
                        cmd.CommandText = sql;
                        rs = cmd.ExecuteReader();

                        string lastEmpLid = "";
                        List<KpiItem> items = new List<KpiItem>();

                        while (rs.Read())
                        {
                            string empLid = (string)rs["EMPLID"];
                            string kpiName = (string)rs["KPINAME"];

                            KpiItem item = KpiItem.AddKpiItem(empLid, year, month, kpiName);
                            if (item != null)
                            {
                                #region 读取数据

                                item.创建人 = "系统";
                                item.创建时间 = DateTime.Now;
                                item.原标识 = Convert.ToInt32(rs["ID"]);
                                item.岗位序号 = Convert.ToInt32(rs["EMPL_RCD"]);
                                item.职级代码 = (string)rs["SUPV_LVL_ID"];
                                item.职位编号 = (string)rs["POSITION_NBR"];
                                item.生效日期 = Convert.ToDateTime(rs["EFFDT"]);
                                item.考核基准工资 = Convert.ToDecimal(rs["BASESALARY"]);
                                item.个人挂钩比例 = Convert.ToDouble(rs["PERRATE"]);
                                item.公司奖励比例 = Convert.ToDouble(rs["COMRATE"]);
                                item.个人绩效标准 = Convert.ToDecimal(rs["STDPER"]);
                                item.公司奖励标准 = Convert.ToDecimal(rs["STDCOM"]);
                                item.个人绩效实得 = Convert.ToDecimal(rs["SLRPER"]);
                                item.公司奖励实得 = Convert.ToDecimal(rs["SLRCOM"]);

                                item.上次同步时间 = DateTime.Now;

                                #endregion

                                item.Save();

                                items.Add(item);
                                //如果轮到下一个人，统计前一个人并保存
                                if (empLid != lastEmpLid && lastEmpLid == "")
                                {
                                    SumKpi(items, lastEmpLid, year, month);
                                }
                            }
                            lastEmpLid = empLid;
                        }
                        SumKpi(items, lastEmpLid, year, month);
                    }
                }
                catch (Exception err)
                {
                    Common.WriteLog(Environment.CurrentDirectory + "\\LogFiles\\Error.log", err.ToString());
                    DeleteAll(year, month);
                }
                finally
                {
                    if (rs != null) rs.Close();
                    conn.Close();
                }
            }
            return sb;
        }

        #region SumKpi

        private static void SumKpi(List<KpiItem> items, string empLid, int year, int month)
        {
            if (string.IsNullOrEmpty(empLid)) return;

            List<KpiItem> list = items.FindAll(a => a.员工编号 == empLid && a.年 == year && a.月 == month);
            decimal 个人执行绩效 = list.Sum(a => a.个人绩效标准);
            decimal 个人绩效实得 = list.Sum(a => a.个人绩效实得);
            decimal 公司奖励实得 = list.Sum(a => a.公司奖励实得);
            decimal 实得绩效工资 = 个人绩效实得 + 公司奖励实得;

            EffectivePerformanceSalary 绩效考核 = EffectivePerformanceSalary.AddEffectivePerformanceSalary(empLid, year, month);
            if (绩效考核 != null)
            {
                绩效考核.姓名 = PsHelper.GetEmplName(empLid);
                绩效考核.绩效工资 = 个人执行绩效;
                绩效考核.实得工资 = 实得绩效工资;
                绩效考核.录入人 = "系统同步获取";
                绩效考核.录入时间 = DateTime.Now;
                绩效考核.Save();
            }
        }
        #endregion

        #endregion
    }
}