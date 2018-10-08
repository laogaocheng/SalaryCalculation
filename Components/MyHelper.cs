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
using Hwagain.Components;
using System.Net;

namespace Hwagain
{
    public class MyHelper
    {
        public static readonly List<string> LOCAL_IP_LIST = GetLocalIp();
        static readonly ILog log = LogManager.GetLogger(typeof(MyHelper));
        public static string configFile = Path.GetFileName(Application.ExecutablePath);
        static Timer timer = new Timer();
        static TimeSpan timeOffset = new TimeSpan(); //时间误差
        static string MY_SALT = "—@IL0VEWEiYI@—"; //盐
        static string COMPUTER_ID = null; //机器码

        #region MyHelper

        static MyHelper()
        {
            //server_time = GetServerTime();

            timer.Interval = 50;
            timer.Tick += timer_Tick;
            timer.Enabled = true;
        }
        #endregion

        #region GetEnumValues

        public static string[] GetEnumValues<T>(bool includeBlank)
        {
            List<string> values = new List<string>((Enum.GetValues(typeof(T)) as T[]).Select(t => t.ToString()));
            if (includeBlank)
            {
                values.Insert(0, string.Empty);
            }
            return values.ToArray();
        }
        #endregion

        #region timer_Tick

        //定时器触发
        static void timer_Tick(object sender, EventArgs e)
        {
            server_time = DateTime.Now.Add(timeOffset);
        }
        #endregion

        #region AddSetting

        public static bool AddSetting(string key, string val)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(configFile);
            config.AppSettings.Settings.Add(key, val);
            config.Save();
            return true;
        }
        #endregion

        #region GetSetting

        public static string GetSetting(string key)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(configFile);
            string val = config.AppSettings.Settings[key].Value;
            return val;
        }
        #endregion

        #region UpdateSetting

        public static bool UpdateSetting(string key, string newVal)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(configFile);
            config.AppSettings.Settings[key].Value = newVal;
            config.Save();
            return true;
        }
        #endregion

        #region SaveConnectString

        public static bool SaveConnectString(string connectString)
        {
            string s = connectString;
            connectString = MyHelper.Encrypt(connectString);
            if (MyHelper.TryConnectDatabase(connectString))
            {
                string configFile = Path.GetFileName(Application.ExecutablePath);
                Configuration config = ConfigurationManager.OpenExeConfiguration(configFile);
                ConnectionStringSettings connSetting = ConfigurationManager.ConnectionStrings["ConnectionString"];
                if (connSetting != null)
                {
                    config.ConnectionStrings.ConnectionStrings.Remove(connSetting);
                }
                connSetting = new ConnectionStringSettings("ConnectionString", connectString);
                config.ConnectionStrings.ConnectionStrings.Add(connSetting);
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("ConnectionStrings");
                MyHelper.ConnectString = s;

                return true;
            }
            else
                return false;
        }
        #endregion

        #region 转换

        #region 将整数转换为 Guid

        public static Guid ConvertToGuid(int integer)
        {
            return ConvertToGuid(0, integer);
        }

        public static Guid ConvertToGuid(int type, int integer)
        {
            string s1 = ("00000000" + type.ToString()).Substring(type.ToString().Length);
            string s2 = ("000000000000" + integer.ToString()).Substring(integer.ToString().Length);
            return new Guid(String.Format("{0}-0000-0000-0000-{1}", s1, s2));
        }
        #endregion

        #endregion

        #region AppId

        static Guid appId = Guid.Empty;
        public static Guid AppId
        {
            get
            {
                if (appId == Guid.Empty)
                {
                    appId = new Guid(ConfigurationManager.AppSettings["AppId"]);
                }
                return appId;
            }
        }
        #endregion

        #region LatestMonths

        public static int LatestMonths
        {
            get
            {
                return Convert.ToInt32(ConfigurationManager.AppSettings["LatestMonths"]);
            }
        }
        #endregion

        #region Decript
        //解密字符串
        internal static string Decript(string str)
        {
            if (string.IsNullOrEmpty(str)) return str;

            string key = "";
            string[] s = str.Replace(' ', '+').Split(new char[] { '*' });
            if (s.Length == 2)
            {
                return DecryptString(s[1], s[0]);
            }
            else
            {
                key = GetComputerId();
                return DecryptString(str, key);
            }
        }

        private static string DecryptString(string s, string key)
        {
            Crypto.EncryptionAlgorithm = Crypto.Algorithm.SHA1;
            Crypto.Encoding = Crypto.EncodingType.BASE_64;
            if (Crypto.GenerateHash(key))
            {
                //用令牌的 HASH 做密码
                key = Crypto.Content;
            }
            else
                key = MY_SALT;

            Crypto.EncryptionAlgorithm = Crypto.Algorithm.Rijndael;
            Crypto.Key = key;
            Crypto.Content = s;
            if (Crypto.DecryptString())
            {
                return Crypto.Content;
            }
            else
                return "";
        }
        #endregion

        #region Encrypt

        public static string Encrypt(string s)
        {
            if (string.IsNullOrEmpty(s)) return "";

            string salt = GetSalt();
            string computerId = GetComputerId();
            string key = string.IsNullOrEmpty(computerId) ? salt : computerId;

            Crypto.EncryptionAlgorithm = Crypto.Algorithm.SHA1;
            Crypto.Encoding = Crypto.EncodingType.BASE_64;
            if (Crypto.GenerateHash(key))
            {
                //用盐或机器码的 HASH 做密码
                key = Crypto.Content;
                Crypto.EncryptionAlgorithm = Crypto.Algorithm.Rijndael;
                Crypto.Key = key;
                if (Crypto.EncryptString(s))
                {
                    if (string.IsNullOrEmpty(computerId))
                        return String.Format("{0}*{1}", key, Crypto.Content);
                    else
                        return Crypto.Content;
                }
            }

            return "";
        }

        //获取加密杂音
        static string GetSalt()
        {
            string salt = DateTime.Now.Ticks.ToString();
            Crypto.EncryptionAlgorithm = Crypto.Algorithm.MD5;
            Crypto.Encoding = Crypto.EncodingType.BASE_64;
            if (Crypto.GenerateHash(salt))
            {
                //用盐的 HASH 做密码
                salt = Crypto.Content;
            }
            return salt.Replace("=", "");
        }
        #endregion

        #region GetLocalIp

        public static List<string> GetLocalIp()
        {
            List<string> list = new List<string>();
            string hostname = Dns.GetHostName();
            IPHostEntry localhost = Dns.GetHostEntry(hostname);
            foreach (IPAddress localaddr in localhost.AddressList)
            {
                if (localaddr.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                    list.Add(localaddr.ToString());
            }
            return list;
        }
        #endregion

        #region SHA1HashEncode

        public static string SHA1HashEncode(string s)
        {
            Crypto.EncryptionAlgorithm = Crypto.Algorithm.SHA1;
            Crypto.Encoding = Crypto.EncodingType.BASE_64;
            if (Crypto.GenerateHash(s))
            {
                return Crypto.Content;
            }
            return "";
        }
        #endregion

        #region ShowSaveFileDialog

        public static string ShowSaveFileDialog(string title, string defaultFilename, string filter)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            string name = Application.ProductName;
            int n = name.LastIndexOf(".") + 1;
            if (n > 0) name = name.Substring(n, name.Length - n);
            dlg.Title = "导出为 " + title;
            dlg.FileName = string.IsNullOrEmpty(defaultFilename) ? name : defaultFilename;
            dlg.Filter = filter;
            if (dlg.ShowDialog() == DialogResult.OK) return dlg.FileName;
            return "";
        }
        #endregion

        #region OpenFile

        public static void OpenFile(string fileName)
        {
            if (MessageBox.Show("是否想要打开这个文件？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    Process process = new Process();
                    process.StartInfo.FileName = fileName;
                    process.StartInfo.Verb = "Open";
                    process.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
                    process.Start();
                }
                catch
                {
                    MessageBox.Show("您的系统不能打开该类型的文件！", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion

        #region GetModifyFields

        //获取修改的字段
        public static List<ModifyField> GetModifyFields<T>(T oldObj, T newObj) where T : class
        {
            List<ModifyField> modifyFields = new List<ModifyField>();
            Type type = typeof(T);
            PropertyInfo[] properities = type.GetProperties(); //得到实体类属性的集合
            foreach (PropertyInfo p in properities) //遍历数组
            {
                object[] watchMember = p.GetCustomAttributes(typeof(WatchMember), false);
                //如果是监视对象
                if (watchMember.Length > 0)
                {
                    ModifyField mField = new ModifyField();

                    mField.名称 = p.Name;
                    mField.数据类型 = p.PropertyType.ToString();
                    object oldval = oldObj == null ? string.Empty : p.GetValue(oldObj, null);
                    object newval = newObj == null ? string.Empty : p.GetValue(newObj, null);
                    mField.旧值 = oldval == null ? "" : oldval.ToString();
                    mField.新值 = newval == null ? "" : newval.ToString();

                    if (mField.数据类型 == "System.Decimal")
                    {
                        if ((decimal)oldval != (decimal)newval) modifyFields.Add(mField);
                    }
                    else
                    {
                        if (mField.旧值 != mField.新值) modifyFields.Add(mField);
                    }
                }
            }
            return modifyFields;
        }
        #endregion

        #region CopyWatchMember

        public static void CopyWatchMember(object orig, object target)
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

        #region SerializeBinary

        public static MemoryStream SerializeBinary(object request)
        {
            BinaryFormatter serializer = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();
            serializer.Serialize(ms, request);
            return ms;
        }
        #endregion

        #region DeSerializeBinary

        public static object DeSerializeBinary(MemoryStream ms)
        {
            ms.Position = 0;
            BinaryFormatter deserializer = new BinaryFormatter();
            object newObj = deserializer.Deserialize(ms);
            ms.Close();
            return newObj;
        }
        #endregion

        #region GetFields

        //List<T>集合转化为 DataTable
        public static List<string> GetFields(object xpl)
        {
            List<string> fields = new List<string>();
            Type type = xpl.GetType();
            PropertyInfo[] properities = type.GetProperties(); //得到实体类属性的集合
            foreach (PropertyInfo p in properities)
            {
                if (p.DeclaringType.Name == type.Name)
                    fields.Add(p.Name);
            }
            return fields;
        }
        #endregion

        #region GetConnectionString

        public static string GetConnectionString()
        {
            string connString = GetConnectionString("ConnectionString");
            //如果没有配置
            if (string.IsNullOrEmpty(connString))
            {
                string connectString = null;
                try
                {
                    //2015 5 15 从注册表获取
                    RegistryKey local = Registry.CurrentUser;
                    RegistryKey run = local.CreateSubKey(@"System\SalaryCalculation");
                    connectString = YiKang.Common.ConvertBytesToString((byte[])run.GetValue("Database"));
                    run.Close();
                    local.Close();

                    if (connectString.IndexOf(';') == -1) connectString = Decript(connectString);
                    SaveConnectString(connectString);
                }
                catch
                {

                }
                return connectString;
            }
            else
            {
                string connectString = connString;
                if (connectString.IndexOf(';') == -1) connectString = Decript(connectString);
                SaveConnectString(connectString);
                return connString;
            }
        }

        public static string GetConnectionString(string connectionName)
        {
            ConnectionStringSettings connSetting = ConfigurationManager.ConnectionStrings[connectionName];
            if (connSetting == null) return null;
            string connString = connSetting.ConnectionString;
            if (connString.IndexOf(';') == -1) connString = Decript(connString); //如果加密，必须先解密
            return connString;
        }
        #endregion

        #region GetConnection

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(ConnectString);
        }
        #endregion

        #region GetXpoSession

        static Session xpoSession = null;
        public static Session GetXpoSession()
        {
            if (HttpContext.Current == null)
            {
                if (xpoSession == null)
                {
                    if (Session.DefaultSession == null || Session.DefaultSession.Connection == null)
                    {
                        SqlConnection conn = MyHelper.GetConnection();
                        XpoDefault.DataLayer = CreateThreadSafeDataLayer(conn);
                        Session.DefaultSession.Connection = conn;
                    }
                    xpoSession = Session.DefaultSession;
                }
                return xpoSession;
            }
            else
            {
                if (HttpContext.Current.Session["XpoSession"] == null)
                {
                    xpoSession = CreateSession();
                    HttpContext.Current.Session["XpoSession"] = xpoSession;
                    return xpoSession;
                }
                else
                {
                    Session session = (Session)HttpContext.Current.Session["XpoSession"];
                    return session;
                }
            }
        }
        #endregion

        #region CreateThreadSafeDataLayer

        static ThreadSafeDataLayer CreateThreadSafeDataLayer(SqlConnection conn)
        {
            XPDictionary dict = new DevExpress.Xpo.Metadata.ReflectionDictionary();
            IDataStore store = XpoDefault.GetConnectionProvider(conn, AutoCreateOption.SchemaAlreadyExists);
            //注意：如果项目中的XPO对象不是集中在一个类库而是分散在多个类库的话，我们需要在这里从每一个
            //      类库中都任意抓取一个对象作为参数传递给 GetDataStoreSchema 方法
            dict.GetDataStoreSchema(
                typeof(Hwagain.Components.BaseData).Assembly,
                typeof(YiKang.RBACS.AccessService).Assembly
                );

            return new ThreadSafeDataLayer(dict, store);
        }
        #endregion

        #region GetThreadSafeDataLayer

        static IDataLayer GetThreadSafeDataLayer(SqlConnection conn)
        {
            IDataStore dataStore = XpoDefault.GetConnectionProvider(conn, AutoCreateOption.DatabaseAndSchema);
            XPDictionary dict = new ReflectionDictionary();

            IDataLayer dataLayer = new ThreadSafeDataLayer(dict, dataStore);
            return dataLayer;
        }
        #endregion

        #region CreateSession

        public static Session CreateSession()
        {
            Session session;
            try
            {
                SqlConnection conn = GetConnection();
                XpoDefault.DataLayer = XpoDefault.GetDataLayer(conn, AutoCreateOption.DatabaseAndSchema);
                session = new Session(XpoDefault.DataLayer);
                return session;
            }
            catch (Exception e)
            {
                Common.WriteLog(Environment.CurrentDirectory + "\\DownloadDebug.log", e.ToString());
                return null;
            }
        }
        #endregion

        #region XpoSession

        public static Session XpoSession
        {
            get
            {
                return GetXpoSession();
            }
        }
        #endregion

        #region HrSession

        static Session hrSession = new Session();
        public static Session HrSession
        {
            get
            {
                return hrSession;
            }
            set
            {
                hrSession = value;
            }
        }
        #endregion

        #region ConnectString

        static string connString = null;
        public static string ConnectString
        {
            get
            {
                if (string.IsNullOrEmpty(connString)) connString = GetConnectionString();
                return connString;
            }
            set { connString = value; }
        }
        #endregion

        #region MinFactoryHandGradeNumber

        static int minFactoryHandGradeNumber = 0;
        public static int MinFactoryHandGradeNumber
        {
            get
            {
                if (minFactoryHandGradeNumber == 0)
                    minFactoryHandGradeNumber = Convert.ToInt32(ConfigurationManager.AppSettings["MinFactoryHandGradeNumber"]);

                return minFactoryHandGradeNumber;
            }
            set { minFactoryHandGradeNumber = value; }
        }
        #endregion

        #region GetPsConnectionString

        public static string GetPsConnectionString()
        {
            ConnectionStringSettings connSetting = ConfigurationManager.ConnectionStrings["PSConnectionString"];
            if (connSetting != null)
            {
                string connString = connSetting.ConnectionString;
                if (connString != null && connString.IndexOf(';') == -1) connString = Decript(connString); //如果加密，必须先解密
                return connString;
            }
            else
                return "";
        }
        #endregion

        #region SetProperty

        //设置属性
        public static void SetProperty(object targetObject, string propertyName, object propertyValue)
        {
            targetObject.GetType().InvokeMember(propertyName,
                BindingFlags.Public |
                BindingFlags.Instance |
                BindingFlags.SetProperty,
                null,
                targetObject, new object[] { propertyValue },
                System.Globalization.CultureInfo.CurrentCulture);
        }
        #endregion

        #region GetProperty

        public static object GetProperty(object targetObject, string propertyName)
        {
            return targetObject.GetType().InvokeMember(propertyName,
                BindingFlags.Public |
                BindingFlags.Instance |
                BindingFlags.SetProperty,
                null,
                targetObject,
                null,
                System.Globalization.CultureInfo.CurrentCulture);
        }
        #endregion

        #region RemoveSpecialChar

        //将特殊字符转化为中文字符
        public static string RemoveSpecialChar(string str)
        {
            str = str.Replace(@"""", "");
            str = str.Replace("~", "");
            str = str.Replace(">", "");
            str = str.Replace("<", "");
            str = str.Replace("?", "");
            str = str.Replace("'", "");
            str = str.Replace(":", "");
            str = str.Replace(",", "");
            str = str.Replace(";", "");
            str = str.Replace("|", "");
            str = str.Replace("}", "");
            str = str.Replace("{", "");
            str = str.Replace("]", "");
            str = str.Replace("[", "");
            str = str.Replace("@", "");
            str = str.Replace("!", "");
            str = str.Replace("#", "");
            str = str.Replace("$", "");
            str = str.Replace("%", "");
            str = str.Replace("^", "");
            str = str.Replace("&", "");
            str = str.Replace("*", "");
            str = str.Replace("(", "（");
            str = str.Replace(")", "）");
            str = str.Replace("_", "");
            str = str.Replace("+", "");
            str = str.Replace("\\", "");
            str = str.Replace("/", "");
            str = str.Replace("＃", "");
            str = str.Replace("＼", "");
            str = str.Replace("／", "");
            str = str.Replace("\r", "").Replace("\n", "");
            return str;
        }
        #endregion

        #region RemoveNumber

        //删除姓名中的数字
        public static string RemoveNumber(string str)
        {
            str = str.Replace("1", "");
            str = str.Replace("2", "");
            str = str.Replace("3", "");
            str = str.Replace("4", "");
            str = str.Replace("5", "");
            str = str.Replace("6", "");
            str = str.Replace("7", "");
            str = str.Replace("8", "");
            str = str.Replace("9", "");
            str = str.Replace("0", "");
            
            return str;
        }
        #endregion

        #region LookAndFeel

        public static string LookAndFeel
        {
            get
            {
                return GetSetting("LookAndFeel");
            }
            set
            {
                UpdateSetting("LookAndFeel", value);
            }
        }
        #endregion

        #region 当前时间

        static DateTime server_time = DateTime.Now;
        public static DateTime 当前时间
        {
            get
            {
                return server_time;
            }
        }
        #endregion

        #region GetServerTime

        public static DateTime GetServerTime()
        {
            string sql = "select GetDate()";
            SqlDataReader reader = YiKang.Data.SqlHelper.ExecuteReader(MyHelper.GetConnection(), System.Data.CommandType.Text, sql);
            reader.Read();
            DateTime time = (DateTime)reader[0];
            return time;
        }
        #endregion

        #region UpdateTime

        static DateTime lastGetServerTime = DateTime.MinValue;
        public static void UpdateTime()
        {
            TimeSpan ts = DateTime.Now - lastGetServerTime;
            if (ts.TotalMinutes <= -5 || ts.TotalMinutes >= 5)
            {
                server_time = GetServerTime();
                timeOffset = server_time - DateTime.Now;
                lastGetServerTime = DateTime.Now;
            }
        }
        #endregion

        #region WriteLog

        //写日志
        public static void WriteLog(LogType logType, string title, string detail)
        {
            List<string> ipList = GetLocalIp();
            Log log = new Log();
            log.DateAndTime = DateTime.Now;
            log.Address = ipList[0];
            log.Username = AccessController.CurrentUser.姓名;
            log.Title = title;
            log.LogType = (byte)logType;
            log.Detail = detail;
            log.Save();
        }
        #endregion

        #region TryConnectDatabase

        public static bool TryConnectDatabase()
        {
            string connString = GetConnectionString();
            return TryConnectDatabase(connString);
        }

        public static bool TryConnectDatabase(string connectString)
        {
            try
            {
                string sql = "select GetDate()";
                if (connectString.IndexOf(';') == -1) connectString = Decript(connectString); //如果加密，必须先解密
                SqlConnection conn = new SqlConnection(connectString);
                SqlDataReader reader = YiKang.Data.SqlHelper.ExecuteReader(conn, System.Data.CommandType.Text, sql);
                reader.Read();
                reader.Close();

                //写进注册表
                RegistryKey local = Registry.CurrentUser;
                RegistryKey run = local.CreateSubKey(@"System\SalaryCalculation");
                run.SetValue("Database", YiKang.Common.ConvertStringToBytes(Encrypt(connectString)));
                run.Close();
                local.Close();

                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region GetPrevMonth1Day

        public static DateTime GetPrevMonth1Day()
        {
            DateTime day = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            return day.AddMonths(-1);
        }
        #endregion

        #region GetComputerId

        static string GetComputerId()
        {
            if (COMPUTER_ID != null) return COMPUTER_ID;

            string cpuInfo = "";//cpu序列号
            ManagementClass cimobject = new ManagementClass("Win32_Processor");
            ManagementObjectCollection moc = cimobject.GetInstances();
            foreach (ManagementObject mo in moc)
            {
                cpuInfo = mo.Properties["ProcessorId"].Value.ToString();
            }
            //获取硬盘ID
            string HDid = "";
            ManagementClass cimobject1 = new ManagementClass("Win32_DiskDrive");
            ManagementObjectCollection moc1 = cimobject1.GetInstances();
            foreach (ManagementObject mo in moc1)
            {
                HDid = (string)mo.Properties["Model"].Value;
            }

            //获取网卡硬件地址
            string netId = "";
            ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection moc2 = mc.GetInstances();
            foreach (ManagementObject mo in moc2)
            {
                if ((bool)mo["IPEnabled"] == true)
                    netId = mo["MacAddress"].ToString();
                mo.Dispose();
            }

            //主板
            string strbNumber = "";
            ManagementObjectSearcher mos = new ManagementObjectSearcher("select * from Win32_baseboard");
            foreach (ManagementObject mo in mos.Get())
            {
                strbNumber = mo["SerialNumber"].ToString();
                break;
            }

            string computerId = cpuInfo + HDid + netId + strbNumber;
            if (computerId == "")
                COMPUTER_ID = string.Empty;
            else
            {
                try
                {
                    string str = computerId + MY_SALT;
                    byte[] bytes = Encoding.Default.GetBytes(str);
                    COMPUTER_ID =  Convert.ToBase64String(bytes);
                }
                catch
                {
                    COMPUTER_ID = string.Empty;
                }
            }
            return COMPUTER_ID;
        }
        #endregion

        #region ConvertMonthToChinese
        //将月数转化为中文表示
        public static string ConvertMonthToChinese(int monthNum)
        {
            string workAgeStr = "";
            int workAge = monthNum;
            int workAge_month = 0;
            int workAge_year = workAge / 12;
            workAge_month = workAge % 12;
            if (workAge_year > 0)
            {
                string year = "  " + workAge_year.ToString();
                workAgeStr = year.Substring(year.Length - 2) +"年";
            }
            if (workAge_month > 0)
            {
                string month = "  " + workAge_month.ToString();
                workAgeStr += month.Substring(month.Length - 2) + "个月";
            }
            return workAgeStr == "" ? "不足一个月" : workAgeStr; ;
        }
        #endregion
    }
}
