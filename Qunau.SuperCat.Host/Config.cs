using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace Qunau.SuperCat
{
    internal static class Config
    {
        /// <summary>
        /// 文件监控
        /// </summary>
        private static FileSystemWatcher FileWatcher { get; set; }

        /// <summary>
        /// 初始化应用程序信息
        /// </summary>
        static Config()
        {
            try
            {
                FileWatcher = new FileSystemWatcher();
                FileWatcher.Path = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
                FileWatcher.Filter = "config.ini";
                FileWatcher.NotifyFilter = NotifyFilters.CreationTime | NotifyFilters.LastWrite | NotifyFilters.FileName;
                FileWatcher.EnableRaisingEvents = true;
                FileWatcher.Changed += fileWatcher_Changed;
            }
            catch { }

            InitConfig();
        }

        static void fileWatcher_Changed(object sender, FileSystemEventArgs e)
        {
            InitConfig();
        }

        /// <summary>
        /// 初始化配置信息
        /// </summary>
        private static void InitConfig()
        {
            try
            {
                var config_file = System.IO.Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase, "config.ini");
                if (File.Exists(config_file))
                {
                    var config = File.ReadAllText(config_file, Encoding.GetEncoding("gb2312"));
                    var matches = Regex.Matches(config, "(?<key>.*)=(?<value>.*)", RegexOptions.Multiline);
                    foreach (Match m in matches)
                    {
                        switch (m.Groups["key"].Value)
                        {
                            case "FlightX":
                                FlightX =Convert.ToInt32(m.Groups["value"].Value.Trim());
                                break;
                            case "FlightY":
                                FlightY = Convert.ToInt32(m.Groups["value"].Value.Trim());
                                break;
                            case "BackX":
                                BackX = Convert.ToInt32(m.Groups["value"].Value.Trim());
                                break;
                            case "BackY":
                                BackY = Convert.ToInt32(m.Groups["value"].Value.Trim());
                                break;
                            case "SearchX":
                                SearchX = Convert.ToInt32(m.Groups["value"].Value.Trim());
                                break;
                            case "SearchY":
                                SearchY = Convert.ToInt32(m.Groups["value"].Value.Trim());
                                break;
                            case "ProxyPort":
                                ProxyPort = Convert.ToInt32(m.Groups["value"].Value.Trim());
                                break;
                            case "ProxyAddress":
                                ProxyAddress = m.Groups["value"].Value.Trim();
                                break;
                        }
                    }
                }
            }
            catch
            {
            }
        }

        public static int FlightX { get; private set; }
        public static int FlightY { get; private set; }
        public static int BackX { get; private set; }
        public static int BackY { get; private set; }
        public static int SearchX { get; private set; }
        public static int SearchY { get; private set; }
        public static int ProxyPort { get; set; }
        public static string ProxyAddress { get; set; }
    }
}
