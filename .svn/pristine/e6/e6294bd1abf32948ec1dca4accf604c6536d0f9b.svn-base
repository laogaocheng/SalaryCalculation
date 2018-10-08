using System;
using System.Web.UI;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Permissions;
using Hwagain.SalaryCalculation.Components;

namespace Hwagain.SalaryCalculation.Components
{
    public class SalaryNodeCollection : List<SalaryNode>, IHierarchicalEnumerable
    {
        #region IHierarchicalEnumerable Members

        public IHierarchyData GetHierarchyData(object enumeratedItem)
        {
            return enumeratedItem as IHierarchyData;
        }

        #endregion        
    }
}
