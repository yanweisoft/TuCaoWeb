using System.Text.RegularExpressions;

namespace TuCao.Utility
{
    public static class StringExtensions
    {
        /// <summary>
        /// 将\n替换为<br/>
        /// </summary>
        /// <param name="stringObj">字符串对象</param>
        /// <returns></returns>
        public static string ReplaceNToBr(this string stringObj)
        {
            if (stringObj == null)
            {
                return null;
            }
            else
            {
                return stringObj.Replace("\n", "<br/>");
            }
        }
        /// <summary>
        /// 将\n替换为nbsp;
        /// </summary>
        /// <param name="stringObj">字符串对象</param>
        /// <returns></returns>
        public static string ReplaceNToSpace(this string stringObj)
        {
            if (stringObj == null)
            {
                return null;
            }
            else
            {
                return stringObj.Replace("\n", " ");
            }
        }
        /// <summary>
        /// HTML代码转义
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string HtmlEncode(this string value)
        {
            if (value != null)
            {
                value = Regex.Replace(value, @"/&/g", "&amp;");
                value = Regex.Replace(value, @"/>/g", "&gt;");
                value = Regex.Replace(value, @"/</g", "&lt;");
                value = Regex.Replace(value, @"/""/g", "&quot;");
                value = Regex.Replace(value, @"/'/g", "&#39;");
                value = Regex.Replace(value, @"/\t/g", "&#9;");
                value = Regex.Replace(value, @"/\\/g", "&#92;");
            }
            return value;
        }
    }
}
