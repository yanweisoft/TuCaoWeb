using System;
using System.Web;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace TuCao.Utility
{
    /// <summary>
    /// 扩展方法
    /// </summary>
    public  static class Extensions
    {
        /// <summary>
        /// 判断对象是否为null或DBNull
        /// </summary>
        /// <param name="o">对象</param>
        /// <returns>true\false</returns>
        public static bool IsEmpty(this object o)
        {
            if (o == null)
            {
                return true;
            }
            if (o == DBNull.Value)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 将对象转换为字符串
        /// </summary>
        /// <remarks>
        /// 通常用于从数据库里查询第一行第一列的值
        /// </remarks>
        /// <param name="o">对象</param>
        /// <param name="defaultValue">默认字符串</param>
        /// <returns>字符串</returns>
        public static string SafeConvertToString(this object o, string defaultValue="")
        {
            if (o.IsEmpty())
            {
                return defaultValue;
            }
            return Convert.ToString(o);
        }

        /// <summary>
        /// 将对象转换为字符串
        /// </summary>
        /// <remarks>
        /// 通常用于从数据库里查询第一行第一列的值
        /// </remarks>
        /// <param name="o">对象</param>
        /// <returns>字符串</returns>
        public static string SafeConvertToString(this object o)
        {
            return o.SafeConvertToString(string.Empty);
        }

        /// <summary>
        /// 将对象转换为整型
        /// </summary>
        /// <remarks>
        /// 通常用于从数据库里查询第一行第一列的值
        /// </remarks>
        /// <param name="o">对象</param>
        /// <param name="defaultValue">默认整型值</param>
        /// <returns>转换后的整型数</returns>
        public static int SafeConvertToInt(this object o, int defaultValue=0)
        {
            if (o.IsEmpty())
            {
                return defaultValue;
            }
            try
            {
                return Convert.ToInt32(o);
            }
            catch
            {
                return defaultValue;
            }
        }
        /// <summary>
        /// 将对象转换为Bool型
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="o">对象</param>
        /// <param name="defaultValue">默认Bool型值</param>
        /// <returns></returns>
        public static bool SafeConvertToBoolean(this object o, bool defaultValue = false)
        {
            if (o.IsEmpty())
            {
                return defaultValue;
            }
            try
            {
                return Convert.ToBoolean(o);
            }
            catch
            {
                return defaultValue;
            }
        }

        /// <summary>
        /// 将对象转换为整型
        /// </summary>
        /// <remarks>
        /// 通常用于从数据库里查询第一行第一列的值
        /// </remarks>
        /// <param name="o">对象</param>
        /// <returns>转换后的整型数</returns>
        public static int SafeConvertToInt(this object o)
        {
            return o.SafeConvertToInt(0);
        }

        /// <summary>
        /// 将对象转换为长整型
        /// </summary>
        /// <remarks>
        /// 通常用于从数据库里查询第一行第一列的值
        /// </remarks>
        /// <param name="o">对象</param>
        /// <param name="defaultValue">默认长整型值</param>
        /// <returns>转换后的长整型数</returns>
        public static long SafeConvertToBigInt(this object o, long defaultValue=0)
        {
            if (o.IsEmpty())
            {
                return defaultValue;
            }
            try
            {
                return Convert.ToInt64(o);
            }
            catch
            {
                return defaultValue;
            }
        }

        /// <summary>
        /// 将对象转换为长整型
        /// </summary>
        /// <remarks>
        /// 通常用于从数据库里查询第一行第一列的值
        /// </remarks>
        /// <param name="o">对象</param>
        /// <returns>转换后的长整形数</returns>
        public static long SafeConvertToBigInt(this object o)
        {
            return o.SafeConvertToBigInt(0);
        }

        /// <summary>
        /// 得到字符串长度（1个中文字符占两个长度）
        /// </summary>
        /// <param name="s">字符串</param>
        /// <returns>字符串长度（1个中文字符占两个长度）</returns>
        public static int GetLength(this string s)
        {
            return StringHelper.GetLength(s);
        }

        /// <summary>
        /// 得到Request指定参数字符类型值（GET）
        /// </summary>
        /// <param name="request">Http请求</param>
        /// <param name="parameterName">参数名</param>
        /// <returns>字符串</returns>
        public static string GetQueryString(this HttpRequestBase request, string parameterName)
        {
            return WebRequest.GetRequestValue(request, parameterName, RequestMethod.Get);
        }

        /// <summary>
        /// 得到Request指定参数字符类型值（Form）
        /// </summary>
        /// <param name="request">Http请求</param>
        /// <param name="parameterName">参数名</param>
        /// <returns>字符串</returns>
        public static string GetFormString(this HttpRequestBase request, string parameterName)
        {
            return WebRequest.GetRequestValue(request, parameterName, RequestMethod.Post);
        }
        /// <summary>
        /// 得到Request指定参数字符类型值（Form）
        /// </summary>
        /// <param name="request">Http请求</param>
        /// <param name="parameterName">参数名</param>
        /// <param name="defaultString">为参数不存在时指定默认值</param>
        /// <returns>字符串</returns>
        public static string GetFormString(this HttpRequestBase request, string parameterName, string defaultString="")
        {
            if (string.IsNullOrEmpty(WebRequest.GetRequestValue(request, parameterName, RequestMethod.Post)))
            {
                return defaultString;
            }
            return WebRequest.GetRequestValue(request, parameterName, RequestMethod.Post);
        }

        /// <summary>
        /// 得到Request指定参数字符类型值（GET）
        /// </summary>
        /// <param name="request">Http请求</param>
        /// <param name="parameterName">参数名</param>
        /// <param name="defaultValue">默认整型值</param>
        /// <returns>整型值</returns>
        public static int GetQueryInt(this HttpRequestBase request, string parameterName, int defaultValue=0)
        {
            return WebRequest.GetRequestValue(request, parameterName, RequestMethod.Get).SafeConvertToInt(defaultValue);
        }

        /// <summary>
        /// 得到Request指定参数字符类型值（Form|Post）
        /// </summary>
        /// <param name="request">Http请求</param>
        /// <param name="parameterName">参数名</param>
        /// <param name="defaultValue">默认整型值</param>
        /// <returns>整型值</returns>
        public static int GetFormInt(this HttpRequestBase request, string parameterName, int defaultValue=0)
        {
            return WebRequest.GetRequestValue(request, parameterName, RequestMethod.Post).SafeConvertToInt(defaultValue);
        }

        /// <summary>
        /// 得到Request指定参数字符类型值（GET）
        /// </summary>
        /// <param name="request">Http请求</param>
        /// <param name="parameterName">参数名</param>
        /// <param name="defaultValue">默认长整型值</param>
        /// <returns>整型值</returns>
        public static long GetQueryBigInt(this HttpRequestBase request, string parameterName, long defaultValue=0)
        {
            return WebRequest.GetRequestValue(request, parameterName, RequestMethod.Get).SafeConvertToBigInt(defaultValue);
        }

        /// <summary>
        /// 得到Request指定参数字符类型值（Form|Post）
        /// </summary>
        /// <param name="request">Http请求</param>
        /// <param name="parameterName">参数名</param>
        /// <param name="defaultValue">默认长整型值</param>
        /// <returns>长整型值</returns>
        public static long GetFormBigInt(this HttpRequestBase request, string parameterName, long defaultValue=0)
        {
            return WebRequest.GetRequestValue(request, parameterName, RequestMethod.Post).SafeConvertToBigInt(defaultValue);
        }
       
        /// <summary>
        /// 将当前对象序列化为字节流
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static byte[] Serialize(this object o)
        {
            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();
            bf.Serialize(ms, o);

            return ms.ToArray();
        }

        /// <summary>
        /// 将指定的字节流反序列化
        /// </summary>
        /// <param name="o"></param>
        /// <param name="bytes">要反序列化的字节流</param>
        /// <returns></returns>
        public static object Deserialize(this object o, byte[] bytes)
        {
            BinaryFormatter bf = new BinaryFormatter();
            return bf.Deserialize(new MemoryStream(bytes));
        }
        /// <summary>
        /// 将object转成日期格式
        /// </summary>
        /// <param name="expression">要转换的值</param>
        /// <returns>返回转换后的值</returns>
        public static DateTime SafeConvertToDateTime(this object expression)
        {
            DateTime rtime = Convert.ToDateTime("1900-1-1 00:00:00");
            if (expression != null)
            {
                DateTime.TryParse(expression.ToString(), out rtime);
            }
            return rtime;
        }
    }
}
