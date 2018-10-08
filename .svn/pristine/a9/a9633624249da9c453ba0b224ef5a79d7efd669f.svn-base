using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using DevExpress.Xpo.DB;
using Hwagain.SalaryCalculation.Components;

namespace Hwagain.Components
{
    //参保变更记录
    public partial class ModifyLog
    {
        static readonly ILog log = LogManager.GetLogger(typeof(ModifyLog));

        #region GetModifyLog
        /// <summary>
        /// 通过 Id 获取
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static ModifyLog GetModifyLog(Guid id)
        {
            ModifyLog obj = (ModifyLog)Session.DefaultSession.GetObjectByKey(typeof(ModifyLog), id);
            return obj;
        }
        #endregion

        #region OnSaving

        protected override void OnSaving()
        {
            List<ModifyField> fields = _modifyFileds.FindAll(delegate(ModifyField field) { return field.旧值 != field.新值; }); 
            //如果没有变更的内容，不保存
            if (fields.Count > 0)
            {
                this.修改内容 = fields.ToJson();
            }
            else
                this.修改内容 = "[]";

            base.OnSaving();
        }
        #endregion

        #region OnLoaded

        protected override void OnLoaded()
        {
            base.OnLoaded();
            this.修改明细表 = this.修改内容.FromJsonTo<List<ModifyField>>();
        }
        #endregion

        #region 修改明细表

        List<ModifyField> _modifyFileds = new List<ModifyField>();
        public List<ModifyField> 修改明细表
        {
            get
            {
                return _modifyFileds;
            }
            set
            {
                _modifyFileds = value.FindAll(delegate(ModifyField field) { return field.旧值 != field.新值; });
            }
        }
        #endregion        
    }
}
