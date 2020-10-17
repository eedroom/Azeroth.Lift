using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;
namespace Gutop.Portal.Util
{
    public class LogHelper: Gutop.Entity.Autofac.ISingleton
    {
        Guid id = Guid.NewGuid();
        static System.Collections.Concurrent.ConcurrentQueue<Gutop.Entity.Log> lstLogInfo = new System.Collections.Concurrent.ConcurrentQueue<Gutop.Entity.Log>();
        static object logInfoLock = new object();
        static int initFlag = 0;
        static bool LogHelperEnable = bool.Parse(System.Configuration.ConfigurationManager.AppSettings["LogHelper:Enable"]);
        Bll.Bll bll;
        string logFolder;
        public LogHelper()
        {
            this.bll =Autofac.Integration.Mvc.AutofacDependencyResolver.Current.RequestLifetimeScope.Resolve<Bll.Bll>();
            this.logFolder = System.IO.Path.Combine(System.Web.HttpRuntime.AppDomainAppPath, "gutoplog");
        }
        

        public  void Add(Gutop.Entity.Log entity)
        {
            if (!LogHelperEnable)
                return;
            lstLogInfo.Enqueue(entity);
        }

        public void StartPersist()
        {
            if (System.Threading.Interlocked.Exchange(ref initFlag, 1) != 0)
                return;//已经执行过下面的代码了，避免因为调用多次这个方法就启动多个线程处理日志数据
            if (!LogHelperEnable)
                return;
            System.Threading.ThreadPool.QueueUserWorkItem(x =>
            {
                while (true)
                {
                    if (lstLogInfo.Count <= 0)
                    {
                        System.Threading.Thread.Sleep(6 * 1000);
                        continue;
                    }
                    List<Gutop.Entity.Log> lst = new List<Gutop.Entity.Log>();
                    Gutop.Entity.Log tmp;
                    while (lst.Count < 50 &&lstLogInfo.TryDequeue(out tmp))
                    {
                        lst.Add(tmp);
                    }
                    try
                    {
                        this.bll.Add<Entity.Log>(lst);
                    }
                    catch (Exception ex)
                    {
                        //最后办法，写入本机文件中，或者windows事件日志中
                        System.IO.File.WriteAllText(System.IO.Path.Combine(this.logFolder, DateTime.Now.ToString("yyyyMMddHHmmss")), ex.ToString());
                        //System.Diagnostics.EventLog.WriteEntry好像需要在IIS把应用程序用localsystem用户运行
                        //System.Diagnostics.EventLog.WriteEntry("Gutop", "LogInfoHelper执行StartPersist保存日志信息到数据发送异常;异常明细信息如下" + ex.ToString(), System.Diagnostics.EventLogEntryType.Error);
                    }
                }
            });
        }
    }
}