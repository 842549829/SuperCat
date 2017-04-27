using Dongger.Windows.Forms;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;
using System.Windows.Forms;

namespace Qunau.SuperCat
{
    public partial class FrmMain : DForm
    {
        public FrmMain()
        {
            InitializeComponent();
            this.msgHandler = ShowMessage;
        }

        private ServiceHost host;

        private readonly Action<string> msgHandler;

        public static Process MonitorProcess { get; private set; }

        private void ShowMessage(string msg)
        {
            if (this.rtxtMessage.InvokeRequired)
            {
                this.rtxtMessage.Invoke(msgHandler, msg);
                return;
            }

            if (this.rtxtMessage.Lines.Length > 200)
            {
                this.rtxtMessage.Clear();
            }

            this.rtxtMessage.AppendText(string.Format("{0}    {1}", DateTime.Now.ToString("yy-MM-dd HH:mm:ss"), msg));
            this.rtxtMessage.AppendText(Environment.NewLine);
        }

        private void btnChoiceProcess_Click(object sender, EventArgs e)
        {
            var frm = new FrmChoiceProcess();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                MonitorProcess = frm.Result;
                ShowMessage(string.Format("已选择监测进程（PID：{0}   进程名称：{1}   主窗口标题：{2}）", MonitorProcess.Id, MonitorProcess.ProcessName, MonitorProcess.MainWindowTitle));
            }
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            if (this.bgwTest.IsBusy)
            {
                ShowMessage("正在繁忙中~~~");
                return;
            }

            bgwTest.RunWorkerAsync(txtFlightNo.Text);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            HttpProxy.Start();
            ShowMessage("HTTP代理服务已经启动！");

            host = new ServiceHost(typeof(CatService));
            host.Opened += delegate
            {
                ShowMessage("WCF服务已经启动！");
            };
            host.Open();
        }

        private void bgwTest_DoWork(object sender, DoWorkEventArgs e)
        {
            Cat cat = new Cat(e.Argument.ToString(), MonitorProcess);
            e.Result = cat.Catch();
        }

        private void bgwTest_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ShowMessage(e.Result.ToString());
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (host != null)
            {
                host.Close();
            }
            HttpProxy.Stop();
            Application.ExitThread();
        }
    }
}
