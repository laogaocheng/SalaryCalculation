using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using DevExpress.Xpo.DB;
using log4net;
using System.Collections;
using Hwagain;
using YiKang;

namespace Hwagain.Components
{
    public class 基础资料
    {
        internal static List<BaseData> baseDataSet = null; //基础资料数据集
        
        #region 所有资料

        public static List<BaseData> 所有资料
        {
            get
            {
                if (baseDataSet == null || baseDataSet.Count == 0) baseDataSet = BaseData.GetAllBaseData();
                return baseDataSet;
            }
        }
        #endregion

        #region 品牌

        public static Dictionary<string, string> 品牌
        {
            get
            {
                return BaseData.GetItemsByType("品牌");
            }
        }
        #endregion

        #region 品类

        public static Dictionary<string, string> 品类
        {
            get
            {
                return BaseData.GetItemsByType("品类");
            }
        }
        #endregion

        #region 价格单位

        public static Dictionary<string, string> 价格单位
        {
            get
            {
                return BaseData.GetItemsByType("价格单位");
            }
        }
        #endregion

        #region 快讯类型

        public static Dictionary<string, string> 快讯类型
        {
            get
            {
                return BaseData.GetItemsByType("快讯类型");
            }
        }
        #endregion
    }
    //基础资料
    public partial class BaseData
    {
        static readonly ILog log = LogManager.GetLogger(typeof(BaseData));

        #region GetBaseData
        /// <summary>
        /// 通过 Id 获取线路
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static BaseData GetBaseData(int id)
        {
            BaseData obj = (BaseData)MyHelper.XpoSession.GetObjectByKey(typeof(BaseData), id);
            return obj;
        }
        #endregion

        #region GetByCode

        public static BaseData GetByCode(string type, string code)
        {
            BaseData found = 基础资料.所有资料.Find(delegate(BaseData bd) { return bd.项目 == type && bd.代码 == code; });
            return found;
        }
        #endregion

        #region GetByName

        public static BaseData GetByName(string type, string name)
        {
            BaseData found = 基础资料.所有资料.Find(delegate(BaseData bd) { return bd.项目 == type && bd.名称 == name; });
            return found;
        }
        #endregion

        #region GetItemsByType
        /// <summary>
        /// 通过资料类型获取基础资料项目清单
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, string> GetItemsByType(string type)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            List<BaseData> list = 基础资料.所有资料.FindAll(bd => bd.项目 == type && bd.禁用 == false);
            foreach (BaseData bd in list)
            {
                dic.Add(bd.代码, bd.名称);
            }
            return dic;                
        }
        #endregion 
        
        #region GetAllBaseData

        //获取所有基础数据
        public static List<BaseData> GetAllBaseData()
        {
            List<BaseData> list = new List<BaseData>();

            XPCollection objset = new XPCollection(MyHelper.XpoSession, typeof(BaseData), new BinaryOperator("标识", 0, BinaryOperatorType.Greater), new SortProperty("项目", SortingDirection.Ascending), new SortProperty("代码", SortingDirection.Ascending));

            foreach (BaseData m in objset)
            {
                list.Add(m);
            }
            return list;
        }
        #endregion

        #region OnSaving

        protected override void OnSaving()
        {
            if (this.内建) throw new Exception("系统内建的基础资料不能修改");
            if (Common.IsInteger(this.代码) == false) throw new Exception("代码必须是一个整数（可在数字前置零，如“01、012等”）");

            BaseData found = GetByCode(this.项目, this.代码);
            if (found != null && found.标识 != this.标识)
                throw new Exception("同一类型的基础资料，代码不能重复使用。");
            else
            {
                found = GetByName(this.项目, this.名称);
                if (found != null && found.标识 != this.标识)
                    throw new Exception("同一类型的基础资料，名称不能重复使用。");
                else
                    base.OnSaving();
            }
        }
        #endregion

        #region OnSaved

        protected override void OnSaved()
        {
            base.OnSaved();
            基础资料.baseDataSet = null;
        }
        #endregion

        #region OnDeleting

        protected override void OnDeleting()
        {
            if (this.内建) throw new Exception("系统内建的基础资料不能删除");
            base.OnDeleting();
        }
        #endregion

        #region OnDeleted

        protected override void OnDeleted()
        {
            base.OnDeleted();
            基础资料.baseDataSet = null;
        }
        #endregion        
    }
}
