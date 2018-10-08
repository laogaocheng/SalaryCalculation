using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;

namespace Hwagain.SalaryCalculation.Components
{
    //管培生工资
    public class ManagementTraineeSalaryStandard
    {
        public int 序号 { get; set; }
        public string 届别 { get; set; }
        public string 岗位级别 { get; set; }
        public string 类别 { get; set; }
        public string 能力级别 { get; set; }
        public string 提资周期 { get; set; }
        public decimal 一阶起薪 { get; set; }
        public decimal 二阶起薪 { get; set; }
        public decimal 满阶起薪 { get; set; }
        public int 满阶起薪方式 { get; set; }
        public decimal 一阶增幅1 { get; set; }
        public decimal 一阶增幅2 { get; set; }
        public decimal 一阶增幅3 { get; set; }
        public decimal 一阶增幅4 { get; set; }
        public decimal 一阶增幅5 { get; set; }
        public decimal 一阶增幅6 { get; set; }
        public decimal 一阶增幅7 { get; set; }
        public decimal 一阶增幅8 { get; set; }
        public decimal 一阶增幅9 { get; set; }
        public decimal 一阶增幅10 { get; set; }
        public decimal 一阶增幅11 { get; set; }
        public decimal 二阶增幅1 { get; set; }
        public decimal 二阶增幅2 { get; set; }
        public decimal 二阶增幅3 { get; set; }
        public decimal 二阶增幅4 { get; set; }
        public decimal 二阶增幅5 { get; set; }
        public decimal 二阶增幅6 { get; set; }

        public static List<ManagementTraineeSalaryStandard> GetList(string division, string grade, string type)
        {
            List<ManagementTraineeSalaryStandard> list = new List<ManagementTraineeSalaryStandard>();
            list.Add(Get(division, grade, type, "A"));
            list.Add(Get(division, grade, type, "B"));
            list.Add(Get(division, grade, type, "C"));
            return list;
        }
        public static ManagementTraineeSalaryStandard Get(string division, string grade, string type, string level)
        {
            ManagementTraineeSalaryStandard standard = new ManagementTraineeSalaryStandard();

            List<ManagementTraineePayRiseStandard> items = ManagementTraineePayRiseStandard.GetManagementTraineePayRiseStandardList(division, grade, type, level);

            standard.届别 = division;
            standard.岗位级别 = grade;
            standard.类别 = type;
            standard.能力级别 = level;

            if (items.Count > 0)
            {
                standard.提资周期 = items[0].提资周期;

                ManagementTraineePayRiseStandard rise_item;
                //-------------------------------------------------------
                //一阶
                rise_item = items.Find(a => a.提资序数 == 0);
                if (rise_item != null) standard.一阶起薪 = rise_item.年薪;

                rise_item = items.Find(a => a.提资序数 == 1);
                if (rise_item != null) standard.一阶增幅1 = rise_item.增幅;

                rise_item = items.Find(a => a.提资序数 == 2);
                if (rise_item != null) standard.一阶增幅2 = rise_item.增幅;

                rise_item = items.Find(a => a.提资序数 == 3);
                if (rise_item != null) standard.一阶增幅3 = rise_item.增幅;

                rise_item = items.Find(a => a.提资序数 == 4);
                if (rise_item != null) standard.一阶增幅4 = rise_item.增幅;

                rise_item = items.Find(a => a.提资序数 == 5);
                if (rise_item != null) standard.一阶增幅5 = rise_item.增幅;

                rise_item = items.Find(a => a.提资序数 == 6);
                if (rise_item != null) standard.一阶增幅6 = rise_item.增幅;

                rise_item = items.Find(a => a.提资序数 == 7);
                if (rise_item != null) standard.一阶增幅7 = rise_item.增幅;

                rise_item = items.Find(a => a.提资序数 == 8);
                if (rise_item != null) standard.一阶增幅8 = rise_item.增幅;

                rise_item = items.Find(a => a.提资序数 == 9);
                if (rise_item != null) standard.一阶增幅9 = rise_item.增幅;

                rise_item = items.Find(a => a.提资序数 == 10);
                if (rise_item != null) standard.一阶增幅10 = rise_item.增幅;

                rise_item = items.Find(a => a.提资序数 == 11);
                if (rise_item != null) standard.一阶增幅11 = rise_item.增幅;

                //---------------------------------------------------------
                //二阶
                rise_item = items.Find(a => a.提资序数 == 100);
                if (rise_item != null) standard.二阶起薪 = rise_item.增幅;

                rise_item = items.Find(a => a.提资序数 == 101);
                if (rise_item != null) standard.二阶增幅1 = rise_item.增幅;

                rise_item = items.Find(a => a.提资序数 == 102);
                if (rise_item != null) standard.二阶增幅2 = rise_item.增幅;

                rise_item = items.Find(a => a.提资序数 == 103);
                if (rise_item != null) standard.二阶增幅3 = rise_item.增幅;

                rise_item = items.Find(a => a.提资序数 == 104);
                if (rise_item != null) standard.二阶增幅4 = rise_item.增幅;

                rise_item = items.Find(a => a.提资序数 == 105);
                if (rise_item != null) standard.二阶增幅5 = rise_item.增幅;

                rise_item = items.Find(a => a.提资序数 == 106);
                if (rise_item != null) standard.二阶增幅6 = rise_item.增幅;

                //---------------------------------------------------------
                //满阶
                rise_item = items.Find(a => a.提资序数 == 10000);
                if (rise_item != null)
                {
                    standard.满阶起薪方式 = rise_item.提资方式;
                    standard.满阶起薪 = rise_item.提资方式 == 0 ? rise_item.增幅 : rise_item.年薪;
                }


            }

            return standard;
        }

    }
}
