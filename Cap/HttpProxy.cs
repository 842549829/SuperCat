using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Cap
{
    public sealed class HttpProxy : IDisposable
    {
        TcpListener listener;
        bool running;

        public void Start(int port)
        {
            listener = new TcpListener(port);
            ThreadPool.QueueUserWorkItem((o) => { Listener(); }, null);
        }

        private void Listener()
        {
            listener.Start();
            running = true;
            while (running)
            {
                var socket = this.listener.AcceptSocket();
                ThreadPool.QueueUserWorkItem((o) =>
                {
                    ParseAndTransfer(o);
                }, socket);
            }
        }

        private void ParseAndTransfer(object o)
        {
            try
            {
                #region 读取请求消息
                var socket = o as Socket;
                var byteArray = new byte[1024];
                int bytes = socket.Receive(byteArray, 1024, 0);
                string requestContent = Encoding.UTF8.GetString(byteArray);
                var hostName = requestContent.Substring(requestContent.IndexOf(":") + 3);
                hostName = hostName.Substring(0, hostName.IndexOf("/"));
                #endregion

                #region 请求转发
                IPHostEntry remoteHost = Dns.Resolve(hostName);
                IPEndPoint remoteIP = new IPEndPoint(remoteHost.AddressList.FirstOrDefault(), 80);//HTTP为80端口
                Socket transSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                transSocket.Connect(remoteIP);
                var requestBytes = Encoding.UTF8.GetBytes(requestContent);
                transSocket.Send(requestBytes, requestBytes.Length, 0);
                #endregion                
                
                #region 响应拦截
                var mem = new MemoryStream();                
                var responseBytes = new byte[2048];
                var responseLength = transSocket.Receive(responseBytes, 2048, 0);
                mem.Write(responseBytes, 0, responseLength);
                //var response = Encoding.UTF8.GetString(responseBytes, 0, responseLength);
                //var response = Encoding.UTF8.GetString(responseBytes, 0, responseLength); //Encoding.UTF8.GetString(ZipHelper.Decompress(responseBytes));
                while (responseLength > 0)
                {
                    responseLength = transSocket.Receive(responseBytes, responseBytes.Length, 0);
                    mem.Write(responseBytes, 0, responseLength);
                    //response += Encoding.UTF8.GetString(ZipHelper.Decompress(responseBytes));
                }

                transSocket.Shutdown(SocketShutdown.Both);
                transSocket.Close();
                var m =new byte[mem.Length];
                 mem.Read(m,0,m.Length);
                 var response =  Encoding.UTF8.GetString(ZipHelper.Decompress(m));
                #endregion

                #region 响应转发
                var transBytes = Encoding.UTF8.GetBytes(response);
                socket.Send(transBytes, transBytes.Length, 0);
                socket.Close();
                socket.Dispose();
                #endregion
            }
            catch { }

        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
