using System.Web;

namespace TuCao.Utility
{
    /// <summary>
    /// web请求操作的公共方法
    /// </summary>
    public sealed class WebRequest
    {
        /// <summary>
        /// 得到Request指定参数字符类型值
        /// </summary>
        /// <param name="request">Http请求</param>
        /// <param name="parameterName">参数名</param>
        /// <param name="method">传递方式，GET|POST</param>
        /// <returns>字符串</returns>
        public static string GetRequestValue(HttpRequestBase request, string parameterName, RequestMethod method)
        {
            string result;
            switch (method)
            {
                case RequestMethod.Get:
                    result = request.QueryString[parameterName];
                    break;
                case RequestMethod.Post:
                    result = request.Form[parameterName];
                    break;
                default:
                    result = request[parameterName];
                    break;
            }
            //过滤敏感符号
            return result ?? string.Empty;
        }
    }
}
