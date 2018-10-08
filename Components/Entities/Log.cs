using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using DevExpress.Xpo.DB;
using log4net;
using Hwagain.Components;
using YiKang;

namespace Hwagain.Components
{
    public partial class Log
    {
        static readonly ILog log = LogManager.GetLogger(typeof(Log));

        #region GetLog
        /// <summary>
        /// 通过 Id 获取线路
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Log GetLog(int id)
        {
            Log obj = (Log)MyHelper.XpoSession.GetObjectByKey(typeof(Log), id);
            return obj;
        }
        #endregion

        #region GetLog
        /// <summary>
        /// 获取一定期限内的所有日志
        /// </summary>
        /// <param name="dtStart">起始时间</param>
        /// <param name="dtEnd">结束时间</param>
        /// <returns></returns>
        public static List<Log> GetLog(DateTime dtStart, DateTime dtEnd)
        {
            List<Log> list = new List<Log>();
            
            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                       new BinaryOperator("DateAndTime", dtStart, BinaryOperatorType.GreaterOrEqual),
                       new BinaryOperator("DateAndTime", dtEnd, BinaryOperatorType.Less));

            XPCollection objset = new XPCollection(typeof(Log), criteria, new SortProperty("DateAndTime", SortingDirection.Descending));            
 
            foreach (Log log in objset)
            {
                list.Add(log);
            }
            return list;
        }
        #endregion

        #region WriteLog

        public static void WriteLog(LogType logType, string title, string detail)
        {
            string username;
            if (AccessController.CurrentUser != null)
                username = AccessController.CurrentUser.用户名;
            else
                username = "无名";

            WriteLog(logType, title, detail, username);
        }
        //写日志
        public static void WriteLog(LogType logType, string title, string detail, string username)
        {            
            Log log = new Log();
            log.DateAndTime = DateTime.Now;
            log.Address = MyHelper.LOCAL_IP_LIST[0];
            log.Url = "";
            log.Username = username;
            log.Title = title;
            log.LogType = (byte)logType;
            log.Detail = detail;
            log.Save();
        }

        #endregion

        #region GetLogByUser

        /// <summary>
        /// 获取某人的所有日志
        /// </summary>
        /// <param name="dtStart">起始时间</param>
        /// <param name="dtEnd">结束时间</param>
        /// <returns></returns>
        public static List<Log> GetLogByUser(string username, DateTime dtStart, DateTime dtEnd)
        {
            List<Log> list = new List<Log>();

            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                       new BinaryOperator("DateAndTime", dtStart, BinaryOperatorType.GreaterOrEqual),
                       new BinaryOperator("DateAndTime", dtEnd, BinaryOperatorType.Less),
                       new BinaryOperator("Username", username, BinaryOperatorType.Equal)
                       );

            XPCollection objset = new XPCollection(typeof(Log), criteria, new SortProperty("DateAndTime", SortingDirection.Descending));

            foreach (Log log in objset)
            {
                list.Add(log);
            }
            return list;
        }
        #endregion

        #region GetLogByAddress
        /// <summary>
        /// 获取某人的所有日志
        /// </summary>
        /// <param name="dtStart">起始时间</param>
        /// <param name="dtEnd">结束时间</param>
        /// <returns></returns>
        public static List<Log> GetLogByAddress(string address, DateTime dtStart, DateTime dtEnd)
        {
            List<Log> list = new List<Log>();

            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                       new BinaryOperator("DateAndTime", dtStart, BinaryOperatorType.GreaterOrEqual),
                       new BinaryOperator("DateAndTime", dtEnd, BinaryOperatorType.Less),
                       new BinaryOperator("Address", address, BinaryOperatorType.Like)
                       );

            XPCollection objset = new XPCollection(typeof(Log), criteria, new SortProperty("DateAndTime", SortingDirection.Descending));

            foreach (Log log in objset)
            {
                list.Add(log);
            }
            return list;
        }
        #endregion 
        
    }
}
