using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace Qunau.SuperCat
{
    internal sealed class Cat
    {
        public string Flight { get; set; }

        public Process MonitorProcess { get; set; }

        public Cat(string flight, Process monitorProcess)
        {
            this.Flight = flight;
            this.MonitorProcess = monitorProcess;
        }

        public string Catch()
        {
            var window = this.MonitorProcess.MainWindowHandle;
            if (window != IntPtr.Zero)
            {
                // 给最后一层的句柄，发送鼠标点击，激活文本框
                List<IntPtr> childHwndList = Api.GetChildHandles(window, "Qt5QWindowIcon", "");
                var x = Config.FlightX;
                var y = Config.FlightY;
                Api.SetForegroundWindow(window);
                Thread.Sleep(200);
                Api.PostMessage(childHwndList[0], Api.WM_LBUTTONDOWN, 1, x + (y << 16));
                Api.PostMessage(childHwndList[0], Api.WM_LBUTTONUP, 0, x + (y << 16));
                Thread.Sleep(500);

                for (int i = 0; i < 10; i++)
                {
                    Api.SendMessageEx(childHwndList[0], Api.WM_KEYDOWN, (int)ConsoleKey.Backspace, 1);
                    Api.SendMessageEx(childHwndList[0], Api.WM_KEYUP, (int)ConsoleKey.Backspace, 1);
                    Thread.Sleep(50);
                }

                Thread.Sleep(50 * 10);
                foreach (var item in this.Flight)
                {
                    /* 其他模拟器
                    //Api.PostMessage(window, Api.WM_KEYDOWN, item, 1);
                    //Api.PostMessage(window, Api.WM_KEYUP, item, 1);
                    //Api.PostMessage(window, Api.WM_CHAR, item, 1);
                    */
                    Api.SendMessageEx(childHwndList[0], Api.WM_KEYDOWN, item, 1);
                    Api.SendMessageEx(childHwndList[0], Api.WM_KEYUP, item, 1);
                    Thread.Sleep(50);
                }

                Thread.Sleep(1000);
                x = Config.SearchX;
                y = Config.SearchY;
                Thread.Sleep(100);
                Api.PostMessage(window, Api.WM_LBUTTONDOWN, 1, x + (y << 16));
                Api.PostMessage(window, Api.WM_LBUTTONUP, 0, x + (y << 16));

                // 这里需要同步等待网络抓包
                var result = NetwrokFactory.WaitOne(Flight, 5);
                Thread.Sleep(2500);
                x = Config.BackX;
                y = Config.BackY;
                for (int i = 0; i < 2; i++)
                {
                    Api.PostMessage(childHwndList[0], Api.WM_LBUTTONDOWN, 1, x + (y << 16));
                    Api.PostMessage(childHwndList[0], Api.WM_LBUTTONUP, 0, x + (y << 16));
                    Thread.Sleep(100);
                }
                Thread.Sleep(1500);
                return result;
            }

            return "获取失败，队列没有正确返回数据！";
        }
    }
}
