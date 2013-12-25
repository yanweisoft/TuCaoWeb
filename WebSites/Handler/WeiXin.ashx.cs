using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TuCao.Utility;
using System.IO;
using System.Net;
using System.Text;
using System.Xml;
namespace WebSites.Handler
{
    /// <summary>
    /// WeiXin 的摘要说明
    /// </summary>
    public class WeiXin : IHttpHandler
    {

        HttpContext context = null;
        string postStr = "";
        public const string mytoken = "mytoken";
        public void ProcessRequest(HttpContext param_context)
        {
            context = param_context;
            context.Response.ContentType = "text/plain";
            #region 验证
            valid();
            #endregion

            if (context.Request.HttpMethod.ToLower() == "post")
            {
                Stream s = context.Request.InputStream;
                byte[] b = new byte[s.Length];
                s.Read(b, 0, (int)s.Length);
                postStr = Encoding.UTF8.GetString(b);
                if (!string.IsNullOrEmpty(postStr))
                {
                    responseMsg(postStr);
                }
            }

            //context.Response.Write("Hello World");
        }




        /// <summary>
        /// 验证是否成为开发者
        /// </summary>
        public void valid()
        {
            var echostr = RequestQueryString.GetQueryString("echoStr");
            if (checkSignature() && !string.IsNullOrEmpty(echostr))
            {
                context.Response.Write(echostr);
                context.Response.End();//推送...不然微信平台无法验证token
            }

        }

        /// <summary>
        /// 验证签名
        /// </summary>
        /// <returns></returns>
        public bool checkSignature()
        {
            var signature = RequestQueryString.GetQueryString("signature");
            var timestamp = RequestQueryString.GetQueryString("timestamp"); ;
            var nonce = RequestQueryString.GetQueryString("nonce"); ;
            var token = mytoken;
            string[] ArrTmp = { token, timestamp, nonce };
            Array.Sort(ArrTmp);     //字典排序
            string tmpStr = string.Join("", ArrTmp);
            tmpStr = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(tmpStr, "SHA1");
            tmpStr = tmpStr.ToLower();
            if (tmpStr == signature)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void responseMsg(string postStr)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(postStr);
            WriteLog("responseMsg:--------------" + postStr);
            XmlElement rootElement = doc.DocumentElement;

            XmlNode MsgType = rootElement.SelectSingleNode("doc");




        }


        private int ConvertDateTimeInt(DateTime time)
        {
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
            return (int)(time - startTime).TotalSeconds;
        }

        private void WriteLog(string strMemo)
        {
            string filename = "d:/logs/log.txt";
            if (!System.IO.Directory.Exists("d:/logs/"))
            {
                System.IO.Directory.CreateDirectory("d:/logs/");
            }

            StreamWriter sr = null;
            try
            {
                if (!System.IO.File.Exists(filename))
                {
                    sr = System.IO.File.CreateText(filename);
                }
                else
                {
                    sr = System.IO.File.AppendText(filename);
                }

                sr.WriteLine(strMemo);
            }
            catch (Exception ex)
            {


            }
            finally
            {
                if (sr != null)
                {
                    sr.Close();
                }
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}