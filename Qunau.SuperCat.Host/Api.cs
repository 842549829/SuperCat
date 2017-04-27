using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Qunau.SuperCat
{
    internal class Api
    {
        //获取窗口标题
        [DllImport("user32", SetLastError = true)]
        public static extern int GetWindowText(
            IntPtr hWnd,//窗口句柄
            StringBuilder lpString,//标题
            int nMaxCount //最大值
            );

        //获取类的名字
        [DllImport("user32.dll")]
        public static extern int GetClassName(
            IntPtr hWnd,//句柄
            StringBuilder lpString, //类名
            int nMaxCount //最大值
            );

        //根据坐标获取窗口句柄
        [DllImport("user32")]
        public static extern IntPtr WindowFromPoint(
        Point Point  //坐标
        );

        // 根据类名找窗体句柄
        [DllImport("user32.dll", EntryPoint = "FindWindow")]
        public static extern IntPtr FindWindow(string IpClassName, string IpWindowName);

        // 根据类名找窗体句柄扩展
        [DllImport("user32.dll", EntryPoint = "FindWindowEx")]
        public static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);

        // 发送消息
        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, string lParam);

        // 发送消息
        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        public static extern int SendMessageEx(IntPtr hwnd, int wMsg, int wParam, int lParam);

        // 发送消息
        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        public static extern int SendMessageSB(IntPtr hwnd, int wMsg, int wParam, StringBuilder lParam);

        // 
        [DllImport("user32.dll", EntryPoint = "GetWindowLong")]
        public static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        // 获取子菜单
        [DllImport("user32.dll", EntryPoint = "GetSubMenu")]
        public static extern IntPtr GetSubMenu(IntPtr hMenu, int nPos);

        // 获取菜单
        [DllImport("user32.dll", EntryPoint = "GetMenu")]
        public static extern IntPtr GetMenu(IntPtr hWnd);

        // 异步发送消息
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool PostMessage(IntPtr hWnd, uint Msg, int wParam, int lParam);

        [DllImport("user32.dll")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);
        [DllImport("user32.dll")]
        public static extern  uint MapVirtualKey(uint uCode, uint uMapType);
        [DllImport("user32.dll")]
        public static extern uint VkKeyScan(char ch);
        /// <summary>
        /// 文本输入常量
        /// </summary>
        public const int WM_SETTEXT = 0x000C;

        /// <summary>
        /// 点击常量
        /// </summary>
        public const int BM_CLICK = 0xF5;

        /// <summary>
        /// 选择下拉列表常量
        /// </summary>
        public const int CB_SELECTSTRING = 0x014D;

        /// <summary>
        /// 执行命令常量
        /// </summary>
        public const int WM_COMMAND = 0x0111;

        /// <summary>
        /// 展开下拉列表ComboBox常量
        /// </summary>
        public const int CB_SHOWDROPDOWN = 0x014F;

        /// <summary>
        /// 选中指定的option项常量
        /// </summary>
        public const int CB_SETCURSEL = 0x014E;

        /// <summary>
        /// 设置获得焦点常量
        /// </summary>
        public const int WM_SETFOCUS = 0x0007;

        /// <summary>
        /// 键盘按下常量
        /// </summary>
        public const int WM_KEYDOWN = 0x0100;

        /// <summary>
        /// 键盘按起常量
        /// </summary>
        public const int WM_KEYUP = 0x0101;

        /// <summary>
        /// 虚拟键盘常量
        /// </summary>
        public const int VK_RETURN = 0xD;

        /// <summary>
        /// 鼠标左键按下常量
        /// </summary>
        public const int WM_LBUTTONDOWN = 0x0201;

        /// <summary>
        /// 鼠标左键按起常量
        /// </summary>
        public const int WM_LBUTTONUP = 0x0202;

        public const int WM_MOUSEACTIVATE = 0x0021;
        public const int WM_CHAR = 0x102;  

        /// <summary>
        /// 类
        /// </summary>
        public static StringBuilder myClassName = new StringBuilder(256);

        /// <summary>
        /// 标题
        /// </summary>
        public static StringBuilder myTitle = new StringBuilder(256);

        /// <summary>
        /// 窗体所有子句柄集合
        /// </summary>
        public static List<IntPtr> mainChildHwndList = new List<IntPtr>();

        /// <summary>
        /// 窗体类名
        /// </summary>
        public const string formClassName = "WindowsForms10.Window.8.app";

        /// <summary>
        /// 编辑文本框类名
        /// </summary>
        public const string editTextClassName = "WindowsForms10.EDIT.app";

        /// <summary>
        /// 下拉列表类名
        /// </summary>
        public const string comboboxClassName = "WindowsForms10.COMBOBOX.app";

        /// <summary>
        /// 按钮类名
        /// </summary>
        public const string buttonClassName = "WindowsForms10.BUTTON.app";

        /// <summary>
        /// 消息框类名
        /// </summary>
        public const string messageBoxClassName = "#32770";

        /// <summary>
        /// TMsgForm
        /// </summary>
        public const string tMsgForm = "TMsgForm";

        /// <summary>
        /// TButton
        /// </summary>
        public const string tButton = "TButton";

        /// <summary>
        /// 子窗口句柄
        /// </summary>
        /// <param name="hwndParent">父窗口句柄</param>
        /// <param name="hwndChildAfter">前一个同目录级同名窗口句柄</param>
        /// <param name="lpszClass">类名</param>
        /// <returns></returns>
        public static IntPtr GetChildHandle(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass)
        {
            return FindWindowEx(hwndParent, hwndChildAfter, lpszClass, null);
        }

        /// <summary>
        /// 全部子窗口句柄
        /// </summary>
        /// <param name="hwndParent">父窗口句柄</param>
        /// <param name="className">类名</param>
        /// <returns></returns>
        public static List<IntPtr> GetChildHandles(IntPtr hwndParent)
        {
            List<IntPtr> resultList = new List<IntPtr>();
            List<IntPtr> childs = new List<IntPtr>();
            for (IntPtr hwndClient = GetChildHandle(hwndParent, IntPtr.Zero, null); hwndClient != IntPtr.Zero; hwndClient = GetChildHandle(hwndParent, hwndClient, null))
            {
                childs.Add(hwndClient);
            }

            resultList.AddRange(childs);
            foreach (var item in childs)
            {
                resultList.AddRange(GetChildHandles(item));
            }

            return resultList;
        }

        /// <summary>
        /// 全部子窗口句柄
        /// </summary>
        /// <param name="hwndParent">父窗口句柄</param>
        /// <param name="className">类名 null 表示不限类名</param>
        /// <param name="title">标题  null 表示不限标题</param>
        /// <returns>result</returns>
        public static List<IntPtr> GetChildHandles(IntPtr hwndParent, string className, string title)
        {
            List<IntPtr> resultList = GetChildHandles(hwndParent);
            for (int i = resultList.Count - 1; i >= 0; i--)
            {

                if (className != null)
                {
                    GetClassName(resultList[i], myClassName, myClassName.Capacity);//得到窗口的类名
                    if (myClassName.ToString() != className)
                    {
                        resultList.RemoveAt(i);
                        continue;
                    }
                }

                if (title != null)
                {
                    GetWindowText(resultList[i], myTitle, myTitle.Capacity);//得到窗口的标题
                    if (myTitle.ToString() != title)
                    {
                        resultList.RemoveAt(i);
                        continue;
                    }
                }
            }

            return resultList;
        }


        /// <summary>
        /// 获取指定句柄
        /// </summary>
        /// <param name="className">类名 null 表示不限类名</param>
        /// <param name="title">标题  null 表示不限标题</param>
        /// <returns>result</returns>
        public static List<IntPtr> GetChildHandles(List<IntPtr> childhWndList, string className, string title)
        {
            List<IntPtr> resultList = new List<IntPtr>();
            foreach (var item in childhWndList)
            {
                if (className != null)
                {
                    GetClassName(item, myClassName, myClassName.Capacity);//得到窗口的类名
                    if (myClassName.ToString() != className)
                    {
                        continue;
                    }
                }

                if (title != null)
                {
                    GetWindowText(item, myTitle, myTitle.Capacity);//得到窗口的标题
                    if (myTitle.ToString() != title)
                    {
                        continue;
                    }
                }

                resultList.Add(item);
            }

            return resultList;
        }
    }
}
