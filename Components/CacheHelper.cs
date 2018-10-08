using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using System.Configuration;
using System.Data.SqlClient;
using System.Reflection;
using DevExpress.Xpo;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using System.Diagnostics;
using YiKang;
using TobyEmden.Security.Encryption;
using System.Runtime.InteropServices;
using DevExpress.Xpo.DB;
using DevExpress.Xpo.Metadata;
using System.Web;
using System.Management;
using Microsoft.Win32;
using System.Net;
using System.ComponentModel;
using System.Collections;
using System.Runtime.Caching;

namespace Hwagain.Components
{
    public interface ICache<TK, TV>
    {
        TV Get<TV>(TK cacheKey, Func<TV> getUncachedValue, DateTimeOffset dateTimeOffset);
        TV Get<TV>(TK cacheKey, Func<TV> getUncachedValue, TimeSpan timeSpan);
        void Set(TK cacheKey, object o, TimeSpan timeSpan);
        void Remove(TK cacheKey);
    }

    public class SingletonProvider<T> where T : new()
    {
        SingletonProvider() { }

        public static T Instance
        {
            get { return new T(); }
        }
    }

    public class MemoryCache<TK, TV> : ICache<TK, TV>
    {
        private ObjectCache _memoryCache;
        public static MemoryCache<TK, TV> Instance
        {
            get { return SingletonProvider<MemoryCache<TK, TV>>.Instance; }
        }

        public MemoryCache() : this(null) { }
        public MemoryCache(string name)
        {
            if (string.IsNullOrEmpty(name)) name = Guid.NewGuid().ToString();
            _memoryCache = new MemoryCache(string.Format("{0}-{1}-{2}", typeof(TK).Name, typeof(TV).Name, name));
        }

        public TV Get<TV>(TK cacheKey, Func<TV> getUncachedValue, DateTimeOffset dateTimeOffset)
        {
            if (_memoryCache.Contains(ParseKey(cacheKey)))
            {
                return (TV)_memoryCache[ParseKey(cacheKey)];
            }
            else
            {
                var v = getUncachedValue();
                object o = v;
                if (v != null) _memoryCache.Set(ParseKey(cacheKey), o, dateTimeOffset);
                return v;
            }
        }

        public TV Get<TV>(TK cacheKey, Func<TV> getUncachedValue, TimeSpan timeSpan)
        {
            return Get(cacheKey, getUncachedValue, new DateTimeOffset(DateTime.Now + timeSpan));
        }

        public void Set(TK cacheKey, object o, TimeSpan timeSpan)
        {
            _memoryCache.Set(ParseKey(cacheKey), o, new DateTimeOffset(DateTime.Now + timeSpan));
        }

        public void Remove(TK cacheKey)
        {
            _memoryCache.Remove(ParseKey(cacheKey));
        }

        private string ParseKey(TK key)
        {
            return key.GetHashCode().ToString();
        }
    }
}
