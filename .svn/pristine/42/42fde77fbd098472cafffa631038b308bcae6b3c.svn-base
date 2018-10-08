using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hwagain.SalaryCalculation.Components;
using System.Data.SqlClient;
using Hwagain;

namespace SychPeopleSoftData
{
    public class Program
    {
        static void Main(string[] args)
        {
            //连接数据库
            SqlConnection conn = MyHelper.GetConnection();
            DevExpress.Xpo.XpoDefault.DataLayer = CreateThreadSafeDataLayer(conn);
            DevExpress.Xpo.Session.DefaultSession.Connection = conn;

            Console.WriteLine("正在同步薪酬体系....");
            SalaryPlan.SychSalaryPlan();

            Console.WriteLine("正在同步薪等....");
            SalaryGrade.SychSalaryGrade();

            Console.WriteLine("正在同步薪级....");
            SalaryStep.SychSalaryStep();

            Console.WriteLine("正在同步员工基本信息....");
            EmployeeInfo.SychEmployeeInfo();

            Console.WriteLine("正在同步工资表....");
            SalaryResult.SychSalaryResult();

            Console.WriteLine("正在清理无效的月薪记录....");
            MonthlySalary.ClearInvalidRecord();

            Console.WriteLine("正在同步绩效考核结果....");
            KpiItem.SychKpiItem();

            Console.WriteLine("同步完毕！");
            //Console.WriteLine("按任意键退出...");
            //Console.ReadKey(true);
        }

        #region CreateThreadSafeDataLayer

        static DevExpress.Xpo.ThreadSafeDataLayer CreateThreadSafeDataLayer(SqlConnection conn)
        {
            DevExpress.Xpo.Metadata.XPDictionary dict = new DevExpress.Xpo.Metadata.ReflectionDictionary();
            DevExpress.Xpo.DB.IDataStore store = DevExpress.Xpo.XpoDefault.GetConnectionProvider(conn, DevExpress.Xpo.DB.AutoCreateOption.SchemaAlreadyExists);
            //注意：如果项目中的XPO对象不是集中在一个类库而是分散在多个类库的话，我们需要在这里从每一个
            //      类库中都任意抓取一个对象作为参数传递给 GetDataStoreSchema 方法
            dict.GetDataStoreSchema(
                typeof(Hwagain.Components.BaseData).Assembly,
                typeof(YiKang.RBACS.AccessService).Assembly
                );

            return new DevExpress.Xpo.ThreadSafeDataLayer(dict, store);
        }
        #endregion
    }
}
