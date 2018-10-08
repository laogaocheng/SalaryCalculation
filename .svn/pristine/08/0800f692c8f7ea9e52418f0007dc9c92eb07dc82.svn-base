using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Hwagain
{
    //变更字段
    [DataContract]
    public class ModifyField
    {
        public ModifyField() { }

        #region LoadFromJson

        public static ModifyField LoadFromJson(string json)
        {
            return json.FromJsonTo<ModifyField>();
        }
        #endregion

        #region ToString

        public override string ToString()
        {
            return this.ToJson();
        }
        #endregion

        #region 名称

        string _name = "名称";
        [DataMember]
        public string 名称
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
        #endregion

        #region 数据类型

        private string _数据类型;
        [DataMember]
        public string 数据类型
        {
            get { return _数据类型; }
            set
            {
                _数据类型 = value;
            }
        }
        #endregion

        #region 旧值

        private string _旧值;
        [DataMember]
        public string 旧值
        {
            get { return _旧值; }
            set
            {
                _旧值 = value;
            }
        }
        #endregion

        #region 新值

        private string _新值;
        [DataMember]
        public string 新值
        {
            get { return _新值; }
            set
            {
                _新值 = value;
            }
        }
        #endregion
    }
}
