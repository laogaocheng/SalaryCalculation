using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using DevExpress.Xpo.DB;
using log4net;
using System.Collections;

namespace Hwagain.SalaryCalculation.Components
{
    public partial class AuthorizeComputer
    {
        static readonly ILog log = LogManager.GetLogger(typeof(AuthorizeComputer));

        #region GetAuthorizeComputer
        /// <summary>
        /// 通过 Id 获取
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static AuthorizeComputer GetAuthorizeComputer(Guid id)
        {
            AuthorizeComputer obj = (AuthorizeComputer)Session.DefaultSession.GetObjectByKey(typeof(AuthorizeComputer), id);
            return obj;
        }

        public static AuthorizeComputer GetAuthorizeComputer(string ip)
        {
            GroupOperator criteria = new GroupOperator(GroupOperatorType.And,
                       new BinaryOperator("地址", ip, BinaryOperatorType.Equal));

            XPCollection objset = new XPCollection(typeof(AuthorizeComputer), criteria, new SortProperty("创建时间", SortingDirection.Ascending));

            if (objset.Count > 0)
            {
                return (AuthorizeComputer)objset[0];
            }
            else
                return null;
        }

        #endregion

        #region GetAll

        //获取所有
        public static List<AuthorizeComputer> GetAll()
        {
            List<AuthorizeComputer> list = new List<AuthorizeComputer>();

            XPCollection objset = new XPCollection(typeof(AuthorizeComputer));

            foreach (AuthorizeComputer lc in objset)
            {
                list.Add(lc);
            }
            return list;
        }

        #endregion

        #region AddAuthorizeComputer

        public static AuthorizeComputer AddAuthorizeComputer(string name, string ip)
        {
            AuthorizeComputer computer = GetAuthorizeComputer(ip);
            if (computer == null)
            {
                computer = new AuthorizeComputer();

                computer.标识 = Guid.NewGuid();
                computer.名称 = name;
                computer.地址 = ip;

                computer.Save();
            }

            return computer;
        }
        #endregion

        #region OnSaving

        protected override void OnSaving()
        {
            AuthorizeComputer found = GetAuthorizeComputer(this.地址);
            if (found != null && found.标识 != this.标识)
                throw new Exception("这台电脑已经准入，不能重复设置.");
            else
                base.OnSaving();
        }
        #endregion

    }
}
