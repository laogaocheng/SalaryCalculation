using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;

namespace Hwagain.Components
{
    public class KeyValue
    {
        public string 键 { get; set; }
        public string 值 { get; set; }

        public static List<KeyValue> GetList(Hashtable table)
        {
            var list = new List<KeyValue>();
            foreach (DictionaryEntry entry in table)
            {
                var kv = new KeyValue();
                kv.键 = (string)entry.Key;
                kv.值 = (string)entry.Value;
                list.Add(kv);
            }
            return list.OrderBy(a => a.值).ToList();
        }
    }
}