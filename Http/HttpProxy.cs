using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Http
{
    public class HttpProxy
    {
        HttpListener listener;

        public void Start(int port)
        {
            listener = new HttpListener();
            listener.Prefixes.Add("http://192.168.10.87:8000/");
            listener.Start();
            ThreadPool.QueueUserWorkItem(o =>
            {
                try
                {
                    while (true)
                    {
                        var request = listener.GetContext();
                        try
                        {
                            Process(request);
                        }
                        catch (Exception ex)
                        {
                        }
                    }
                }
                catch (Exception ex)
                {
                }
            }, null);
        }

        private byte[] GetBytesFromStream(Stream stream)
        {
            byte[] result;
            byte[] buffer = new byte[256];

            BinaryReader reader = new BinaryReader(stream);
            MemoryStream memoryStream = new MemoryStream();

            int count = 0;
            while (true)
            {
                count = reader.Read(buffer, 0, buffer.Length);
                memoryStream.Write(buffer, 0, count);

                if (count == 0)
                    break;
            }

            result = memoryStream.ToArray();
            memoryStream.Close();
            reader.Close();
            stream.Close();

            return result;
        }

        private string GetPortFromQueryString(HttpListenerContext context)
        {
            var replacePortStr = context.Request.QueryString["__port__"];
            int replacePort;

            if (!string.IsNullOrWhiteSpace(replacePortStr))
            {
                if (int.TryParse(replacePortStr, out replacePort))
                {
                    replacePortStr = ":" + replacePort;
                }
            }
            else
            {
                replacePortStr = string.Empty;
            }
            return replacePortStr;
        }

        private void Process(HttpListenerContext context)
        {
            string rawUrl = context.Request.Url.ToString();
            string beforeRewriteUrl = rawUrl.Replace(":8000", string.Empty);
            HttpWebRequest request = HttpWebRequest.Create(beforeRewriteUrl) as HttpWebRequest;
            SetCookies(request, context);

            request.UserAgent = context.Request.UserAgent;
            request.Method = context.Request.HttpMethod;
            request.ContentType = context.Request.ContentType;
            //request.ContentLength = context.Request.ContentLength64;
            if (context.Request.HasEntityBody)
            {
                using (System.IO.Stream body = context.Request.InputStream)
                {
                    byte[] requestdata = GetBytesFromStream(body);
                    request.ContentLength = requestdata.Length;
                    Stream s = request.GetRequestStream();
                    s.Write(requestdata, 0, requestdata.Length);
                    s.Close();
                }
            }
            //request processing
            WebResponse response = request.GetResponse() as HttpWebResponse;
            var result = GetBytesFromStream(response.GetResponseStream());
            context.Response.ContentType = response.ContentType;
            context.Response.AppendHeader("Set-Cookie", response.Headers.Get("Set-Cookie"));
            var contentEncoding = (response.Headers["Content-Encoding"] ?? "").Trim().ToLower();//压缩类型
            result = Decompress(result, contentEncoding);
            response.Close();
            try
            {
                //response
                byte[] buffer = result;
                buffer = ReplaceAndAppend(buffer, context.Response.ContentType, beforeRewriteUrl);
                context.Response.ContentLength64 = buffer.Length;
                context.Response.OutputStream.Write(buffer, 0, buffer.Length);
                context.Response.OutputStream.Close();

            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }
        }
        private ContentType GetContentType(string txt, bool isHtml = false)
        {
            var result = new ContentType { IsTextType = false };
            //text/html; charset=utf-8
            //application/x-javascript
            var contentTypeRegex = @"\s*?(?<TypeName>[a-zA-Z0-9\\-]+?)/(?<SubTypeName>[a-zA-Z0-9\\-]+);\s*?charset\s*?=\s*?(?<charset>[a-zA-Z0-9\\-]+)";
            if (!string.IsNullOrWhiteSpace(txt))
            {
                var match = Regex.Match(txt, contentTypeRegex, RegexOptions.IgnoreCase);
                if (!match.Success && !isHtml)
                {
                    contentTypeRegex = @"\s*?(?<TypeName>[a-zA-Z0-9\\-]+?)/(?<SubTypeName>[a-zA-Z0-9\\-]+)(;\s*?charset\s*?=\s*?(?<charset>[a-zA-Z0-9\\-]+))?";
                    match = Regex.Match(txt, contentTypeRegex, RegexOptions.IgnoreCase);
                }
                if (match.Success)
                {
                    result.TypeName = match.Groups["TypeName"].Value.Trim().ToLower();
                    result.SubTypeName = match.Groups["SubTypeName"].Value.Trim().ToLower();
                    result.Charset = match.Groups["charset"].Value;
                    if (string.IsNullOrWhiteSpace(result.Charset))
                    {
                        result.Charset = "utf-8";
                    }
                    result.Charset = result.Charset.Trim().ToLower();
                    if (result.TypeName == "text")
                    {
                        result.IsTextType = true;
                    }
                    else if (result.TypeName == "application" && (result.SubTypeName.Contains("json") || result.SubTypeName.Contains("javascript")))
                    {
                        result.IsTextType = true;
                    }
                }
            }
            return result;
        }
        /// <summary>
        /// 根据配置，替换和追加内容，然后返回改变后的buffer字节数据
        /// </summary>
        /// <param name="buffer">要替换和追加文本的字节数组</param>
        /// <param name="contentType">buffer的类型，如text/html; charset=utf-8</param>
        /// <param name="url">buffer来源地址</param>
        /// <returns></returns>
        public byte[] ReplaceAndAppend(byte[] buffer, string contentType, string url)
        {

            var encoding = Encoding.UTF8;
            var ct = GetContentType(contentType);
            if (ct.IsTextType)
            {
                encoding = Encoding.GetEncoding(ct.Charset);
                var text = encoding.GetString(buffer);
                ContentType result = GetContentType(text, true);
                if (!string.IsNullOrWhiteSpace(result.Charset))
                {
                    if (result.Charset != ct.Charset)
                    {
                        encoding = Encoding.GetEncoding(result.Charset);
                        text = encoding.GetString(buffer);
                    }
                }

                buffer = encoding.GetBytes(text);
            }
            System.Diagnostics.Debug.WriteLineIf(!ct.IsTextType, url + " 不是文本类型，直接返回");
            return buffer;
        }

        /// <summary>
        /// gzip或deflate解压
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="contentEncoding"></param>
        /// <returns></returns>
        private byte[] Decompress(byte[] buffer, string contentEncoding)
        {
            if (!string.IsNullOrWhiteSpace(contentEncoding))
            {
                if (contentEncoding == "gzip")
                {
                    var gzip = new GZipStream(new MemoryStream(buffer), CompressionMode.Decompress);
                    return GetBytesFromStream(gzip);
                }
                else if (contentEncoding == "deflate")
                {
                    var deflate = new DeflateStream(new MemoryStream(buffer), CompressionMode.Decompress);
                    return GetBytesFromStream(deflate);
                }
            }
            return buffer;
        }
        private void SetCookies(HttpWebRequest request, HttpListenerContext context)
        {
            try
            {
                var host = new Uri(request.RequestUri.ToString()).Host;//www.baidu.com
                var index = host.IndexOf('.');
                var domain = host.Substring(index);// .baidu.com
                request.CookieContainer = new CookieContainer();
                for (int i = 0; i < context.Request.Cookies.Count; i++)
                {
                    var c = context.Request.Cookies[i];
                    c.Domain = domain;
                    request.CookieContainer.Add(c);
                }
            }
            catch (Exception err)
            {
                Console.WriteLine(err.ToString());
            }
        }
        class ContentType
        {
            public string Charset { get; set; }
            public string TypeName { get; set; }
            public string SubTypeName { get; set; }
            /// <summary>
            /// 是不是文本类型
            /// </summary>
            public bool IsTextType { get; set; }
        }
    }
}
