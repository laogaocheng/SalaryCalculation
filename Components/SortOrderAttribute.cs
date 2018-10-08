using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hwagain.Components
{
    public class SortOrderAttribute : Attribute
    {
        public int Order { get; set; }
        public SortOrderAttribute(int order) { Order = order; }

        public static IEnumerable<object> GetPropertiesSorted(object obj)
        {
            var type = obj.GetType();
            return type
                .GetProperties()
                .Select(x => new
                {
                    Value = x.GetValue(obj, null),
                    Attribute = (SortOrderAttribute)Attribute.GetCustomAttribute(x, typeof(SortOrderAttribute), false)
                })
                    .OrderBy(x => x.Attribute.Order)
                    .Select(x => x.Value)
                    .Cast<object>();
        }
    }
}
