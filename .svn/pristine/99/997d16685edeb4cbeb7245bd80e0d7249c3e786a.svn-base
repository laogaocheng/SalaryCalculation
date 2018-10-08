using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace Hwagain.Components
{
    //监视器，主要用于处理一起定时或者周期性触发的事件

    public class Watcher
    {
        readonly static Timer timer = new Timer();
        static bool isBusy = false;     
        //启动
        public static void Start()
        {
            timer.Interval = 30 * 1000; //30秒检查一次
            timer.Elapsed += ExuteTask;
            timer.Start();
        }
        public static void Stop()
        {
            timer.Stop();
        }

        #region ExuteTask

        static void ExuteTask(object sender, ElapsedEventArgs args)
        {
            if (!isBusy)
            {
                isBusy = true;
                foreach (WatcherTask task in tasks)
                {
                    try
                    {
                        task.Do();
                    }
                    catch (Exception e)
                    {
                        YiKang.Common.WriteToEventLog(e.ToString());
                    }
                }
                isBusy = false;
            }
        }
        #endregion

        #region 任务列表

        static readonly List<WatcherTask> tasks = new List<WatcherTask>();
        public static List<WatcherTask> 任务列表
        {
            get
            {
                return tasks;
            }
        }
        #endregion
    }
    public delegate void Command();
    //监视任务
    public class WatcherTask
    {
        public event Command Excute;
        
        #region Do

        public void Do()
        {
            TimeSpan ts = DateTime.Now - lastExcuteTime;
            if (Excute != null && ts.TotalMinutes > interval)
            {
                Excute();
                lastExcuteTime = DateTime.Now;
            }
        }
        #endregion

        #region 名称

        private string _名称;
        public string Name
        {
            get { return _名称; }
            set
            {
                _名称 = value;
            }
        }
        #endregion

        #region 上次执行时间
        
        private DateTime lastExcuteTime = DateTime.MinValue;
        public DateTime 上次执行时间
        {
            get { return lastExcuteTime; }
            set
            {
                lastExcuteTime = value;
            }
        }
        #endregion

        #region 间隔分钟数
        //默认四个小时
        int interval = 60 * 4;
        public int Interval
        {
            get
            {
                return interval;
            }
            set
            {
                interval = value;
            }
        }
        #endregion
    }
}
