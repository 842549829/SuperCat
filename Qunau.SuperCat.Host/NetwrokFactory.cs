using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Qunau.SuperCat
{
    public static class NetwrokFactory
    {
        private static System.Collections.Concurrent.ConcurrentDictionary<string, string> results = new System.Collections.Concurrent.ConcurrentDictionary<string, string>();
        private static AutoResetEvent waitHandler = new AutoResetEvent(false);
        public static void AddResponse(string result)
        {
            var match = Regex.Match(result, "flightNo\":\"(?<value>.*?)\"");
            if (match.Success)
            {
                var flight = match.Groups["value"].Value.Trim();
                results.AddOrUpdate(flight, result, (x, y) => y);

                waitHandler.Set();
            }
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
                var temp =string.Empty;
                results.TryRemove(flight, out temp);
                return result;
            }

            return WaitOne(flight, --times);
        }
    }
}
