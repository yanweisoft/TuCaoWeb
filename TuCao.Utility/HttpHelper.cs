using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Text;
using System.Web;

namespace TuCao.Utility
{
    public class HttpHelper
    {
        /// <summary>
        /// 模拟Post
        /// </summary>
        /// <param name="url">请求的url</param>
        /// <param name="content">请求的内容</param>
        /// <param name="headers">header里加入的内容</param>
        /// <param name="encode">编码，如果传null，默认是的是UTF8编码</param>
        /// <returns>请求返回的信息</returns>
        public static string Post(string url, NameValueCollection content, NameValueCollection headers, Encoding encode)
        {
            string remoteInfo;
            Encoding encoding = encode ?? Encoding.UTF8;
            var webClientObj = new WebClient {Encoding = encoding};
            if (headers != null)
                webClientObj.Headers.Add(headers);
            try
            {
                byte[] byRemoteInfo = webClientObj.UploadValues(url, "POST", content ?? new NameValueCollection());
                remoteInfo = encoding.GetString(byRemoteInfo);
            }
            catch (Exception ex)
            {
                remoteInfo = ex.ToString();
            }
            return remoteInfo;
        }

        /// <summary>
        /// 模拟Post(调用搜索的接口)
        /// </summary>
        /// <param name="url">请求的url</param>
        /// <param name="json">拼装的json</param>
        /// <param name="encode">编码格式</param>
        /// <returns></returns>
        public static string Post(string url,string json, Encoding encode)
        {
            string remoteInfo;
            try
            {
                Encoding encoding = encode ?? Encoding.UTF8;
                var client = new WebClient {Encoding = encoding};
                byte[] bytes = Encoding.UTF8.GetBytes(json);
                byte[] result = client.UploadData(url, "POST", bytes);
                remoteInfo = encoding.GetString(result);
            }
            catch (Exception ex)
            {
                 remoteInfo = ex.ToString();
            }
            return remoteInfo;
        }


        /// <summary>  
        /// 创建POST方式的HTTP请求  
        /// </summary>  
        /// <param name="url">请求的URL</param>  
        /// <param name="parameters">随同请求POST的参数名称及参数值字典</param>  
        /// <param name="requestEncoding">发送HTTP请求时所用的编码</param>  
        /// <param name="cookie">随同HTTP请求发送的Cookie信息，如果不需要身份验证可以为空</param>  
        /// <returns></returns>  
        public static string CreatePostHttpResponse(string url, IDictionary<string, string> parameters,
                                                    Encoding requestEncoding, Cookie cookie)
        {
            if (string.IsNullOrEmpty(url))
            {
                throw new ArgumentNullException("url");
            }
            if (requestEncoding == null)
            {
                throw new ArgumentNullException("requestEncoding");
            }
            var request = System.Net.WebRequest.Create(url) as HttpWebRequest;
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";


            if (cookie != null)
            {
                request.CookieContainer = new CookieContainer();
                request.CookieContainer.Add(cookie);
            }
            //如果需要POST数据  
            if (!(parameters == null || parameters.Count == 0))
            {
                var buffer = new StringBuilder();
                int i = 0;
                foreach (string key in parameters.Keys)
                {
                    if (i > 0)
                    {
                        buffer.AppendFormat("&{0}={1}", key, parameters[key]);
                    }
                    else
                    {
                        buffer.AppendFormat("{0}={1}", key, parameters[key]);
                    }
                    i++;
                }
                byte[] data = requestEncoding.GetBytes(buffer.ToString());
                using (Stream stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }
            }
            HttpWebResponse response = (HttpWebResponse) request.GetResponse();
            Stream responseStream = response.GetResponseStream();
            StreamReader streamReader = new StreamReader(responseStream, requestEncoding);
            string retString = streamReader.ReadToEnd();
            streamReader.Close();
            if (responseStream != null) responseStream.Close();
            return retString;
        }



        /// <summary>
        /// 模拟Get
        /// </summary>
        /// <param name="url">请求的url</param>
        /// <param name="content">请求的内容</param>
        /// <param name="headers">header里加入的内容</param>
        /// <param name="encode">编码，如果传null，默认是的是UTF8编码</param>
        /// <returns>请求返回的信息</returns>
        public static string Get(string url, NameValueCollection content, NameValueCollection headers, Encoding encode)
        {
            string remoteInfo = string.Empty;

            var webClientObj = new WebClient {Encoding = encode ?? Encoding.UTF8};
            webClientObj.Headers.Add(headers);

            try
            {
                webClientObj.QueryString.Add(content);
                return webClientObj.DownloadString(url);
            }
            catch (Exception ex)
            {
                remoteInfo = ex.ToString();
            }
            return remoteInfo;
        }
    }
}