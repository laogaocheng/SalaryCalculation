using System;
using System.Collections.Generic;
using System.Linq;

namespace Hwagain.SalaryCalculation.Components
{
    public class PerformanceSalaryInputGroup
    {
        public PerformanceSalaryInput A { get; set; }
        public PerformanceSalaryInput B { get; set; }

        public PerformanceSalaryInput GetPerformanceSalaryInputByEditor(string editor)
        {
            if (this.A != null && this.A.录入人 == editor) return this.A;
            if (this.B != null && this.B.录入人 == editor) return this.B;
            return null;
        }

        #region 录入人

        public string 录入人
        {
            get
            {
                if (this.A != null && this.A.是验证录入 == false)
                    return this.A.录入人;

                if (this.B != null && this.B.是验证录入 == false)
                    return this.B.录入人;
                
                return "";
            }
        }
        #endregion

        #region 验证人

        public string 验证人
        {
            get
            {
                if (this.A != null && this.A.是验证录入)
                    return this.A.录入人;

                if (this.B != null && this.B.是验证录入)
                    return this.B.录入人;
                
                return "";
            }
        }
        #endregion

        #region 编号

        public string 编号
        {
            get
            {
                if(this.A != null)
                    return this.A.编号;

                if (this.B != null)
                    return this.B.编号;

                return "";
            }
        }
        #endregion
    }
}
