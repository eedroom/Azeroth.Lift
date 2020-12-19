using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gutop.Bll
{
    public class Log:Model.Autofac.ISingleton
    {
        static System.Collections.Concurrent.ConcurrentQueue<Gutop.Model.Entity.Log> lstLogInfo = 
            new System.Collections.Concurrent.ConcurrentQueue<Gutop.Model.Entity.Log>();
        static object logLock = new object();
        static int initFlag = 0;
        static bool enable = bool.Parse(System.Configuration.ConfigurationManager.AppSettings["LogHelper:Enable"]);


        public void Add(Gutop.Model.Entity.Log entity)
        {
            if (!enable)
                return;
            lstLogInfo.Enqueue(entity);
        }

        public void StartSaveAsync(string logFolder) {
            if (System.Threading.Interlocked.Exchange(ref initFlag, 1) != 0)
                return;//已经执行过下面的代码了，避免因为调用多次这个方法就启动多个线程处理日志数据
            if (!enable)
                return;
            System.Threading.ThreadPool.QueueUserWorkItem(x =>
            {
                List<Gutop.Model.Entity.Log> lst = new List<Gutop.Model.Entity.Log>(50);
                Gutop.Model.Entity.Log tmp;
                while (true)
                {
                    if (lstLogInfo.Count <= 0)
                    {
                        System.Threading.Thread.Sleep(10 * 1000);
                        continue;
                    }
                    lst.Clear();
                    while (lst.Count < 50 && lstLogInfo.TryDequeue(out tmp))
                    {
                        lst.Add(tmp);
                    }
                    try
                    {
                        using (var db=new Model.Entity.DbContext())
                        {
                            db.Log.AddRange(lst);
                            db.SaveChanges();
                        }
                    }
                    catch (Exception ex)
                    {
                        //最后办法，写入本机文件中，或者windows事件日志中
                        System.IO.File.WriteAllText(System.IO.Path.Combine(logFolder, DateTime.Now.ToString("yyyyMMddHHmmss")), ex.ToString());
                        //System.Diagnostics.EventLog.WriteEntry好像需要在IIS把应用程序用localsystem用户运行
                        //System.Diagnostics.EventLog.WriteEntry("Gutop", "LogInfoHelper执行StartPersist保存日志信息到数据发送异常;异常明细信息如下" + ex.ToString(), System.Diagnostics.EventLogEntryType.Error);
                    }
                }
            });
        }
    }
}
