using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.LookAndFeel;
using System.IO;
using Hwagain.SalaryCalculation.Components;
using System.Diagnostics;
using Hwagain.Components;
using Hwagain;
using Hwagain.SalaryCalculation;
using System.Data.SqlClient;
using System.Configuration;
using Hwagain.Common.Components;
using Microsoft.Win32;

namespace Hwagain.SalaryCalculation
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            DevExpress.Skins.SkinManager.EnableFormSkins();
            DevExpress.UserSkins.BonusSkins.Register();
            UserLookAndFeel.Default.SetSkinStyle("Summer 2008");

            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("zh-CN");

            //日志配置
            string log4netfilename = Path.Combine(Application.StartupPath, "log4net.config");
            log4net.Config.XmlConfigurator.ConfigureAndWatch(new FileInfo(log4netfilename));

            if(MyHelper.TryConnectDatabase() == false)
            {
                DatabaseConfig dbConfig = new DatabaseConfig();
                dbConfig.ShowInTaskbar = true;
                dbConfig.ShowDialog();

                if (dbConfig.DialogResult == DialogResult.OK)
                {
                    Start();
                }
            }             
            else
            {
                Start();
            }
        }

        private static void Start()
        {
            //连接数据库
            SqlConnection conn = MyHelper.GetConnection();
            DevExpress.Xpo.XpoDefault.DataLayer = CreateThreadSafeDataLayer(conn);
            DevExpress.Xpo.Session.DefaultSession.Connection = conn;

            Application.Run(new MainForm());
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

        static bool IsAlreadyRunning()
        {
            bool b = false;
            string pName = Process.GetCurrentProcess().ProcessName;
            Process[] mProcs = Process.GetProcessesByName(pName);
            if (mProcs.Length > 1)
                b = true;
            return b;
        }
    }
}
