using Qunau.Infrastructure.WCF;
using System;
using System.Collections.Generic;


namespace Qunau.SuperCat
{
    public static class CatServiceHelper
    {
        /// <summary>
        /// 本地代理
        /// </summary>
        private static ICat client = null;

        /// <summary>
        /// 多线程同步锁
        /// </summary>
        private readonly static object asynObj = new object();

        /// <summary>
        /// 代理实例
        /// <remarks>
        /// 这里之所以做成静态单例模式，是因为呀，没必要创建N个代理，这个真实代理，有一个就好，反正不会一直建立连接
        /// </remarks>
        /// </summary>
        /// <value>The instance.</value>
        private static ICat Instance
        {
            get
            {
                if (client == null)
                {
                    lock (asynObj)
                    {
                        if (client == null)
                        {
                            string configPath = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "WCFConfig\\CatService.config";
                            client = ServiceProxyFactory.Create<ICat>(configPath, "CatServiceEndpoint");
                        }
                    }
                }

                return client;
            }
        }

        public static string QueryBeforeFlight(string flight)
        {
            return Instance.QueryBeforeFlight(flight);
        }
    }
}
