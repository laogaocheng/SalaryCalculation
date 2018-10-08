using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using DevExpress.Xpo.DB;
using log4net;
using System.Data.SqlClient;

namespace Hwagain.Components
{
    public partial class NumberInfo
    {
        static readonly ILog log = LogManager.GetLogger(typeof(NumberInfo));

        #region GetNumberInfo
        /// <summary>
        /// 通过 Id 获取线路
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static NumberInfo GetNumberInfo(int id)
        {
            NumberInfo obj = (NumberInfo)MyHelper.XpoSession.GetObjectByKey(typeof(NumberInfo), id);
            return obj;
        }

        public static NumberInfo GetNumberInfo(string name)
        {
            string sql = String.Format("SELECT * FROM 编号信息 WHERE 编号名称 = '{0}'", name);
            using (SqlConnection connection = new SqlConnection(MyHelper.GetConnectionString()))
            {
                SqlDataReader reader = null;
                try
                {
                    reader = YiKang.Data.SqlHelper.ExecuteReader(connection, System.Data.CommandType.Text, sql);
                    if (reader.Read())
                    {
                        NumberInfo ni = new NumberInfo();
                        ni.标识 = (int)reader["标识"];
                        ni.编号名称 = (string)reader["编号名称"]; ;
                        ni.编号规则 = (string)reader["编号规则"];
                        ni.当前序号 = (int)reader["当前序号"];
                        ni.序号长度 = (int)reader["序号长度"];
                        return ni;
                    }
                }
                finally
                {
                    if (reader != null) reader.Close();
                }
            }
            return null;
        }
        #endregion

        //获取新编号
        public string GetNewNumber(params object[] args)
        {
            string x = new string('0', this.序号长度) + (this.当前序号 + 1);
            x = x.Substring(x.Length - this.序号长度);
            return string.Format(this.编号规则.Replace("x", x), args);
        }

        public string GetNewNumber()
        {
            string x = new string('0', this.序号长度) + (this.当前序号 + 1);
            x = x.Substring(x.Length - this.序号长度);
            return this.编号规则.Replace("x", x);
        }

        //更新当前序号
        public void UpdateCurrentSN(int currSN)
        {
            if (currSN > this.当前序号)
            {
                this.当前序号 = currSN;
                this.Save();
            }
        }
        //序号增长
        public void UpdateCurrentSN()
        {
            string sql = "UPDATE 编号信息 SET 当前序号 = 当前序号 + 1 WHERE 标识 = " + this.标识;
            using (SqlConnection connection = new SqlConnection(MyHelper.GetConnectionString()))
            {
                YiKang.Data.SqlHelper.ExecuteNonQuery(connection, System.Data.CommandType.Text, sql);
            }
        }
    }
}
