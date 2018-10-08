using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Data;
using System.Reflection;
using System.Collections;

namespace Hwagain
{
    public static class Extensions
    {
        #region FromJsonTo

        public static T FromJsonTo<T>(this string jsonString)
        {
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(T));
            MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(jsonString));
            T jsonObject = (T)ser.ReadObject(ms);
            ms.Close();
            return jsonObject;
        }
        #endregion
        
        #region ToJson

        public static string ToJson(this object item)
        {
            DataContractJsonSerializer ser = new DataContractJsonSerializer(item.GetType());
            using (MemoryStream ms = new MemoryStream())
            {
                ser.WriteObject(ms, item);
                StringBuilder sb = new StringBuilder();
                sb.Append(Encoding.UTF8.GetString(ms.ToArray()));
                return sb.ToString();
            }
        }
        #endregion

        #region ToDataTable

        //List<T>集合转化为 DataTable
        public static DataTable ToDataTable<TResult>(this IEnumerable<TResult> val) where TResult : class
        {
            //创建属性的集合
            List<PropertyInfo> pList = new List<PropertyInfo>();
            //获得反射的入口
            Type type = typeof(TResult);
            DataTable dt = new DataTable();
            //把所有的 Public 属性加入到集合并添加 DataTable的列
            Array.ForEach<PropertyInfo>(type.GetProperties(), p => { pList.Add(p); dt.Columns.Add(p.Name, p.PropertyType); });
            foreach (var item in val)
            {
                //创建一个 DataRow
                DataRow row = dt.NewRow();
                //给 row 赋值
                pList.ForEach(p => row[p.Name] = p.GetValue(item, null));
                //加入到 DataTable
                dt.Rows.Add(row);
            }
            return dt;
        }
        #endregion

        #region ToList

        public static List<TResult> ToList<TResult>(this DataTable dt) where TResult : class, new()
        {
            //创建一个属性的列表
            List<PropertyInfo> prlist = new List<PropertyInfo>();
            //获取TResult的类型实力 反射的入口
            Type t = typeof(TResult);
            //获取 TResult 的所有 Public 属性，并找出 TResult 属性和DataTable的列名称相同的属性（PropertyInfo）并加入到属性列表
            Array.ForEach<PropertyInfo>(t.GetProperties(), p => { if (dt.Columns.IndexOf(p.Name) != -1) prlist.Add(p); });
            //创建返回的集合
            List<TResult> oblist = new List<TResult>();
            foreach (DataRow row in dt.Rows)
            {
                //创建 TResult 的实例
                TResult ob = new TResult();
                //找到对应的数据并赋值
                prlist.ForEach(p => { if (row[p.Name] != DBNull.Value) { try { p.SetValue(ob, row[p.Name], null); } catch { };} });
                //放入到返回的集合中
                oblist.Add(ob);
            }
            return oblist;
        }
        #endregion

        #region CloneWatchMember
        
        public static T CloneWatchMember<T>(this object obj) where T : class, new()
        {
            T newT = new T();
            Type t = typeof(T);
            Array.ForEach<PropertyInfo>(t.GetProperties(), p =>
            {
                object[] watchMember = p.GetCustomAttributes(typeof(WatchMember), false);
                //如果是监视的属性
                if (watchMember.Length > 0 &&p.CanRead && p.CanWrite)
                {
                    object o = p.GetValue(obj, null);
                    p.SetValue(newT, o, null);
                }
            });
            return newT;
        }
        #endregion

        #region CopyWatchMember

        public static void CopyWatchMember(this object orig, object target)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            if (assembly != null)
            {
                Type origType = assembly.GetType(orig.GetType().ToString());
                Type targetType = assembly.GetType(target.GetType().ToString());
                if (origType != null && targetType != null)
                {
                    Array.ForEach<PropertyInfo>(origType.GetProperties(), p =>
                    {
                        object[] watchMember = p.GetCustomAttributes(typeof(WatchMember), false);
                        //如果是监视的属性
                        if (watchMember.Length > 0 && p.CanRead)
                        {
                            //获取监视对象的值
                            object o = p.GetValue(orig, null);
                            PropertyInfo p_target = targetType.GetProperty(p.Name);
                            if (p_target != null && p_target.CanWrite)
                                p_target.SetValue(target, o, null);
                        }
                    });
                }
            }
        }
        #endregion

        #region Clone

        public static T Clone<T>(this object obj) where T : class, new()
        {
            T newT = new T();
            Type t = typeof(T);
            Array.ForEach<PropertyInfo>(t.GetProperties(), p =>
            {
                //可读写
                if (p.CanRead && p.CanWrite)
                {
                    object o = p.GetValue(obj, null);
                    p.SetValue(newT, o, null);
                }
                
            });
            return newT;
        }
        #endregion

        #region ToString

        public static string ToString<T>(this object item) where T : class
        {
            return ToString<T>(item, false);
        }

        public static string ToString<T>(this object item, bool inherit) where T : class
        {
            string str = "";
            Type type = typeof(T);
            PropertyInfo[] properities = type.GetProperties(); //得到实体类属性的集合
            foreach (PropertyInfo p in properities) //遍历数组
            {
                string typeName = p.PropertyType.ToString();
                string[] arr = typeName.Split(new char[] { '.'});
                if ((inherit || (!inherit && p.DeclaringType == type)) && typeName.StartsWith("System.") && arr.Length == 2)
                {
                    object val = item == null ? string.Empty : p.GetValue(item, null);
                    string s = val == null ? string.Empty : val.ToString();
                    if (str != "") str += "\r\n";
                    str += p.Name + ": " + s;
                }
            }
            return str;
        }
        #endregion
    }
}
