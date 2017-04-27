using System;
using System.ServiceModel;
using System.Text.RegularExpressions;
using System.Threading;

namespace Qunau.SuperCat
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public sealed class CatService : ICat
    {
        private static readonly System.Collections.Concurrent.ConcurrentQueue<string> requests = new System.Collections.Concurrent.ConcurrentQueue<string>();
        private static readonly AutoResetEvent waitHandler = new AutoResetEvent(false);
        private static readonly AutoResetEvent requestHandler = new AutoResetEvent(false);
        private static System.Collections.Concurrent.ConcurrentDictionary<string, string> results = new System.Collections.Concurrent.ConcurrentDictionary<string, string>();
        private static readonly object asynObj = new object();

        static CatService()
        {
            ThreadPool.QueueUserWorkItem((o) =>
            {
                while (true)
                {
                    try
                    {
                        if (requests.Count == 0)
                        {
                            requestHandler.WaitOne();
                        }

                        var flight = string.Empty;
                        if (!requests.TryDequeue(out flight))
                        {
                            continue;
                        }

                        var result = new Cat(flight, FrmMain.MonitorProcess).Catch();
                        var match = Regex.Match(result, "flightNo\":\"(?<value>.*?)\"");
                        if (match.Success)
                        {
                            var f = match.Groups["value"].Value.Trim();
                            results.AddOrUpdate(f, result, (x, y) => y);

                            waitHandler.Set();
                        }
                    }
                    catch { }
                }
            }, null);
        }

        public static string WaitOne(string flight, int times = 3)
        {
            if (times == 0)
            {
                return string.Empty;
            }

            waitHandler.WaitOne(1000);
            var result = string.Empty;
            if (results.TryGetValue(flight, out result))
            {
                return result;
            }

            return WaitOne(flight, --times);
        }

        public string QueryBeforeFlight(string flight)
        {
            try
            {
                lock (asynObj)
                {
                    var result = new Cat(flight, FrmMain.MonitorProcess).Catch();
                    Qunau.NetFrameWork.Common.Write.LogService.SaveLog("前序航班", flight, result);
                    return result;
                }

                //requests.Enqueue(flight);
                //requestHandler.Set();
                //return WaitOne(flight, 3);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
