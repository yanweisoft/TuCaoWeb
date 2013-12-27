using System;
using System.Text;
using System.Text.RegularExpressions;
namespace TuCao.Utility
{
    ///<summary>
    /// 字符串操作的公共方法
    ///</summary>
    public sealed class StringHelper
    {
        /// <summary>
        /// 得到字符串长度（1个中文字符占两个长度）
        /// </summary>
        /// <param name="s">字符串</param>
        /// <returns>字符串长度（1个中文字符占两个长度）</returns>
        public static int GetLength(string s)
        {
            return Encoding.Default.GetByteCount(s);
        }
        /// <summary>
        /// 根据给定长度截取子串
        /// </summary>
        /// <param name="stringObject">字符串</param>
        /// <param name="maxLength">截取的最大长度</param>
        /// <param name="isAddMore">超长是否加"..."</param>
        public static string InterceptSubString(string stringObject, int maxLength, bool isAddMore)
        {
            if (stringObject == null)
            {
                stringObject = string.Empty;
            }
            if (stringObject == string.Empty)
            {
                return stringObject;
            }
            if (isAddMore)
            {
                maxLength = maxLength - 3;
                if (maxLength < 0)
                {
                    maxLength = 0;
                }
            }
            else
            {
                if (maxLength < 0)
                {
                    maxLength = 0;
                }
            }

            int stringObjectLength = 0;
            for (int i = 0; i < stringObject.Length; i++)
            {
                if (Convert.ToInt32(Convert.ToChar(stringObject.Substring(i, 1))) < Convert.ToInt32(Convert.ToChar(128)))
                {
                    stringObjectLength += 1;
                }
                else
                {
                    stringObjectLength += 2;
                }
                if (stringObjectLength > maxLength)
                {
                    break;
                }
            }
            if (stringObjectLength > maxLength)
            {
                int wordNum = 0;
                int digit = 0;
                for (int i = 0; i < stringObject.Length; i++)
                {
                    if (Convert.ToInt32(Convert.ToChar(stringObject.Substring(i, 1))) < Convert.ToInt32(Convert.ToChar(128)))
                    {
                        digit += 1;
                    }
                    else
                    {
                        digit += 2;
                    }
                    wordNum++;
                    if (digit >= maxLength)
                    {
                        break;
                    }
                }
                if (digit > maxLength)
                {
                    wordNum = wordNum - 1;
                    if (wordNum < 0)
                    {
                        wordNum = 0;
                    }
                }
                stringObject = stringObject.Substring(0, wordNum);
                if (isAddMore)
                {
                    stringObject += "...";
                }

                return stringObject;
            }
            else
            {
                return stringObject;
            }
        }



        /// <summary>
        /// 清除HTML所有格式
        /// </summary>
        /// <param name="strHtml"></param>
        /// <returns></returns>
        public static string ClearHtml(string strHtml)
        {
            if (strHtml != "")
            {
                Regex regex = null;
                Match match = null;
                regex = new Regex(@"<\/?[^>]*>", RegexOptions.IgnoreCase);
                for (match = regex.Match(strHtml); match.Success; match = match.NextMatch())
                {
                    strHtml = strHtml.Replace(match.Groups[0].ToString(), "");
                }
            }
            return strHtml;
        }

        
    }
}
