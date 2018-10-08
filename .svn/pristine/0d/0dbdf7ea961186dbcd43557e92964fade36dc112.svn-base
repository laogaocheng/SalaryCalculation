using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using DevExpress.Utils;

namespace Hwagain.SalaryCalculation.Components
{
    /// <summary>
    /// 工资标准
    /// </summary>
    public class PayRate
    {
        public string 标识 { get; set; }
        public string 父节点标识 { get; set; }
        public string 英文名 { get; set; }
        public string 中文名 { get; set; }

        public string 基准工资标准 { get; set; }
        public string 上表工资标准 { get; set; }
        public string 设定工资标准 { get; set; }
        public string 年休假工资 { get; set; }

        #region GetAll

        //获取所有工资标准
        public static List<PayRate> GetAll()
        {
            List<PayRate> list = new List<PayRate>();

            List<SalaryPlan> allPlan = SalaryPlan.薪酬体系表;
            List<SalaryGrade> allGrades = SalaryGrade.当前薪等表;
            List<SalaryStep> allSteps = SalaryStep.GetEffectedSteps(DateTime.Today, allGrades);

            var setids = from p in allPlan
                         group p by p.集合 into setid
                         select setid;

            //生成集合点
            foreach (var setid in setids)
            {
                PayRate payRate_SetId = new PayRate();
                payRate_SetId.父节点标识 = "";
                payRate_SetId.标识 = setid.Key;
                payRate_SetId.英文名 = setid.Key;
                payRate_SetId.中文名 = setid.Key;
                list.Add(payRate_SetId);
                //生成薪酬体系节点                
                List<SalaryPlan> salPlans = allPlan.FindAll(a => a.集合 == setid.Key);
                foreach (SalaryPlan plan in salPlans)
                {
                    PayRate payRate_Plan = new PayRate();

                    payRate_Plan.父节点标识 = setid.Key;
                    payRate_Plan.标识 = plan.标识.ToString();
                    payRate_Plan.英文名 = plan.英文名;
                    payRate_Plan.中文名 = plan.中文名;

                    list.Add(payRate_Plan);

                    //生成薪等
                    List<SalaryGrade> myGrades = allGrades.FindAll(a => a.集合 == setid.Key && a.薪酬体系 == plan.英文名);
                    foreach (SalaryGrade grade in myGrades)
                    {
                        PayRate payRate_Grade = new PayRate();

                        payRate_Grade.父节点标识 = payRate_Plan.标识;
                        payRate_Grade.标识 = grade.标识.ToString();
                        payRate_Grade.英文名 = grade.薪等编号;
                        payRate_Grade.中文名 = grade.薪等名称;

                        payRate_Grade.基准工资标准 = grade.基准工资标准.ToString("c");
                        payRate_Grade.上表工资标准 = grade.上表工资标准.ToString("c");
                        payRate_Grade.设定工资标准 = grade.设定工资标准.ToString("c");
                        payRate_Grade.年休假工资 = grade.年休假工资.ToString("c");

                        list.Add(payRate_Grade);
                    }
                }
            }
            return list;
        }
        #endregion
    }
}
