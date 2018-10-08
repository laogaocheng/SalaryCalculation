using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using DevExpress.Xpo.DB;
using log4net;
using YiKang;

namespace Hwagain.Components
{
    //类型定义
    public partial class TypeDefine
    {
        static readonly ILog log = LogManager.GetLogger(typeof(TypeDefine));

        #region GetTypeDefine
        /// <param name="id"></param>
        /// <returns></returns>
        public static TypeDefine GetTypeDefine(Guid id)
        {
            TypeDefine obj = (TypeDefine)MyHelper.XpoSession.GetObjectByKey(typeof(TypeDefine), id);
            return obj;
        }
        #endregion

        #region GetListing
        /// <summary>
        /// 获取清单
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static List<TypeDefine> GetListing()
        {
            List<TypeDefine> list = new List<TypeDefine>();

            XPCollection objset = new XPCollection(MyHelper.XpoSession, typeof(TypeDefine),
                new BinaryOperator("名称", "", BinaryOperatorType.NotEqual),
                new SortProperty("名称", SortingDirection.Ascending));

            foreach (TypeDefine d in objset)
            {
                list.Add(d);
            }
            return list;
        }
        #endregion                        

    }
}
