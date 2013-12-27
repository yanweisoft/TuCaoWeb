using System;
using System.Text.RegularExpressions;

namespace TuCao.Utility
{
    public sealed class Txt
    {
        #region 验证字符串

        /// <summary>
        /// 判断用户名是否正确： 不能全是数字，不能带@
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <returns></returns>
        public static bool IfUserName(string userName)
        {
            Regex re = new Regex(@"(?=^[0-9a-zA-Z]{6,20}$)\w*[a-zA-Z]+\w*");
            if (re.IsMatch(userName))
                return true;
            return false;
        }

        /// <summary>
        /// 判断参数是否电话号码
        /// </summary>
        /// <param name="PhoneText"></param>
        /// <returns></returns>
        public static bool IfPhoneFormat(string PhoneText)
        {
            string strRegex = "^1[1-9]{1}[0-9]{9}$";
            Regex re = new Regex(strRegex);
            if (re.IsMatch(PhoneText))
                return true;
            return false;
        }
        public static bool istel(string uid)
        {
            uid = uid.Trim();
            //			if (uid.Length<4)
            //			{
            //				return false;
            //			}

            string chk = "-_0123456789";
            int i, j;
            for (i = 0; i < uid.Length; i++)
            {
                string ch = uid.Substring(i, 1);
                for (j = 0; j < chk.Length; j++)
                {
                    if (chk.IndexOf(ch) >= 0)
                    {
                        break;
                    }
                }
                if (j == chk.Length)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// 判断参数是否URL
        /// </summary>
        /// <param name="UrlText"></param>
        /// <returns></returns>
        public static bool IfUrlFormat(string UrlText)
        {
            string strRegex = @"^http://([\w-]+\.)+[\w-]+(/[\w-./?%&=]*)?$";

            Regex re = new Regex(strRegex);
            if (re.IsMatch(UrlText))
                return true;
            return false;
        }

        /// <summary>
        /// 判断参数是否邮政编码
        /// </summary>
        /// <param name="PostText"></param>
        /// <returns></returns>
        public static bool IfPostFormat(string PostText)
        {
            string strRegex = @"^\d{6}$";

            Regex re = new Regex(strRegex);
            if (re.IsMatch(PostText))
                return true;
            return false;
        }

        /// <summary>
        /// 判断参数是否邮件
        /// </summary>
        /// <param name="EmailText"></param>
        /// <returns></returns>
        public static bool IfMailFormat(string EmailText)
        {

            string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            Regex re = new Regex(strRegex);
            if (re.IsMatch(EmailText))
                return true;
            return false;
        }

        /// <summary>
        /// 判断参数是否时间
        /// </summary>
        /// <param name="DateText"></param>
        /// <returns></returns>
        public static bool IfDateFormat(string DateText)
        {
            string strRegex = @"^((((1[6-9]|[2-9]\d)\d{2})-(0?[13578]|1[02])-(0?[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})-(0?[13456789]|1[012])-(0?[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})-0?2-(0?[1-9]|1\d|2[0-8]))|(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))-0?2-29-))$";
            Regex re = new Regex(strRegex);
            if (re.IsMatch(DateText))
                return true;
            return false;
        }

        /// <summary>
        /// 判断参数是否时间日期
        /// </summary>
        /// <param name="DateTimeText"></param>
        /// <returns></returns>
        public static bool IfDateTimeFormat(string DateTimeText)
        {
            string strRegex = @"^((((1[6-9]|[2-9]\d)\d{2})-(0?[13578]|1[02])-(0?[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})-(0?[13456789]|1[012])-(0?[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})-0?2-(0?[1-9]|1\d|2[0-8]))|(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))-0?2-29-)) (20|21|22|23|[0-1]?\d):[0-5]?\d:[0-5]?\d$";
            Regex re = new Regex(strRegex);
            if (re.IsMatch(DateTimeText))
                return true;
            return false;
        }


        /// <summary>
        /// 判断参数是否汉字
        /// </summary>
        /// <param name="InputText"></param>
        /// <returns></returns>
        public static bool IfChinaChar(string InputText)
        {
            string strRegex = @"[\u4e00-\u9fa5]{0,}$";

            Regex re = new Regex(strRegex);
            if (re.IsMatch(InputText))
                return true;
            return false;
        }

        /// <summary>
        /// 判断参数是否数字
        /// </summary>
        /// <param name="InputText"></param>
        /// <returns></returns>
        public static bool IfNumeric(string InputText)
        {
            if (InputText == null || InputText.Trim().Length == 0)
                return false;
            string strRegex = @"^[-]{0,1}\d+$";

            Regex re = new Regex(strRegex);
            if (re.IsMatch(InputText))
                return true;
            return false;
        }

        public static bool IfIDCrd(string InputText)
        {
            bool result = false;
            if (InputText == null || InputText.Trim().Length == 0)
                return result;
            string strRegex = @"^(\d{17}(\d{1}|x{1}|X{1}))|(\d{15})$";

            Regex re = new Regex(strRegex);
            if (re.IsMatch(InputText))
                result = true;
            return result;
        }
        #endregion

        #region 加工处理字符串
        /// <summary>
        /// 字符串的MD5加密
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string MD5(string str)
        {
            str = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(str, "md5");
            return str;
        }

        /// <summary>
        /// 截短字串的函数
        /// </summary>
        /// <param name="mText">要加工的字串</param>
        /// <param name="byteCount">长度</param>
        /// <returns>被加工过的字串</returns>
        public static string CutTitle(string mText, int byteCount)
        {
            return CutTitle(mText, byteCount, false);
        }
        /// <summary>
        /// 截短字串的函数
        /// </summary>
        /// <param name="mText">要加工的字串</param>
        /// <param name="byteCount">长度</param>
        /// <param name="isContainChar">是否包含省略号</param>
        /// <returns>被加工过的字串</returns>
        public static string CutTitle(string mText, int byteCount, bool isContainChar)
        {
            if (string.IsNullOrEmpty(mText))
            {
                return mText;
            }
            if (byteCount < 1) return mText;

            if (Regex.Replace(mText, "[\u4e00-\u9fa5]", "zz", RegexOptions.IgnoreCase).Length <= byteCount)
            {
                return mText;
            }

            for (int i = mText.Length; i >= 0; i--)
            {
                mText = mText.Substring(0, i);
                if (Regex.Replace(mText, "[\u4e00-\u9fa5]", "zz", RegexOptions.IgnoreCase).Length <= byteCount)
                {
                    return isContainChar == true ? mText + "…" : mText;
                }
            }
            return "";
        }
        /// <summary>
        /// 获取字符串的长度，Byte数
        /// </summary>
        /// <param name="oString"></param>
        /// <returns></returns>
        public static int StrLen(string oString)
        {
            byte[] strArray = System.Text.Encoding.Default.GetBytes(oString);
            int res = strArray.Length;
            return res;
        }
        #endregion

        #region 过滤字符串
        /// <summary>
        /// html decode
        /// </summary>
        /// <param name="str">string</param>
        /// <returns></returns>
        public static string Decode(string str)
        {
            str = System.Web.HttpContext.Current.Server.HtmlDecode(str.Trim());
            return str;
        }
        public static string Encode(string str)
        {
            str = System.Web.HttpContext.Current.Server.HtmlEncode(str.Trim());
            return str;
        }
        /// <summary>
        /// 去除非法字串
        /// </summary>
        /// <param name="strChar">原字串</param>
        /// <returns>过滤过的字串</returns>
        public static string ReplaceBadChar(string strChar)
        {
            //if (strChar == null || strChar.Trim() == "")
            //{
            //    return "";
            //}
            //else
            //{
            //    //				strChar = Regex.Replace(strChar,@"<script[^>]*?>.*?</script>","",RegexOptions.IgnoreCase);
            //    //				strChar = Regex.Replace(strChar,@"<iframe[^>]*?>.*?</iframe>","",RegexOptions.IgnoreCase);
            //    strChar = Regex.Replace(strChar, @"(<meta(.[^>]*)>)", "", RegexOptions.IgnoreCase);
            //    strChar = strChar.Replace("'", "''");
            //    //				return strChar.Trim();

            //    string regexstr = @"(?i)<script([^>])*>(\w|\W)*?</script([^>])*>";//@"<script.*</script>";
            //    strChar = Regex.Replace(strChar, regexstr, string.Empty, RegexOptions.IgnoreCase);
            //    strChar = Regex.Replace(strChar, "<script([^>])*?>", string.Empty, RegexOptions.IgnoreCase);
            //    strChar = Regex.Replace(strChar, "</script>", string.Empty, RegexOptions.IgnoreCase);

            //    regexstr = @" href *= *[\s\S]*?script *:.+?""";
            //    //strChar = Regex.Replace(strChar, regexstr, string.Empty, RegexOptions.IgnoreCase);

            //    regexstr = @" on\w+?="".+?"" ";
            //    strChar = Regex.Replace(strChar, regexstr, " ", RegexOptions.IgnoreCase);

            //    regexstr = @"(?i)<iframe([^>])*>(\w|\W)*</iframe([^>])*>";//@"<script.*</script>";
            //    strChar = Regex.Replace(strChar, regexstr, string.Empty, RegexOptions.IgnoreCase);
            //    strChar = Regex.Replace(strChar, "<iframe([^>])*>", string.Empty, RegexOptions.IgnoreCase);
            //    strChar = Regex.Replace(strChar, "</iframe>", string.Empty, RegexOptions.IgnoreCase);
            //    //
            //    //				strChar = strChar.Replace("!", "");
            //    //				strChar = strChar.Replace("@", "");
            //    //				strChar = strChar.Replace("#", "");
            //    //				strChar = strChar.Replace("$", "");
            //    //				strChar = strChar.Replace("%", "");
            //    //				strChar = strChar.Replace("^", "");
            //    //				strChar = strChar.Replace("&", "");
            //    //				strChar = strChar.Replace("*", "");
            //    //				strChar = strChar.Replace("(", "");
            //    //				strChar = strChar.Replace(")", "");
            //    //				strChar = strChar.Replace("_", "");
            //    //				strChar = strChar.Replace("+", "");
            //    //				strChar = strChar.Replace("|", "");
            //    //				strChar = strChar.Replace("?", "");
            //    //				strChar = strChar.Replace("/", "");
            //    //				strChar = strChar.Replace(".", "");
            //    //				strChar = strChar.Replace(">", "");
            //    //				strChar = strChar.Replace("<", "");
            //    //				strChar = strChar.Replace("{", "");
            //    //				strChar = strChar.Replace("}", "");
            //    //				strChar = strChar.Replace("[", "");
            //    //				strChar = strChar.Replace("]", "");
            //    //				strChar = strChar.Replace("-", "");
            //    //				strChar = strChar.Replace("=", "");
            //    //				strChar = strChar.Replace(",", "");

            return strChar;
        }

        #endregion

        #region 转换类型
        /// <summary>
        /// True转换为1，false转换为0
        /// </summary>
        /// <param name="str">bool</param>
        /// <returns>string</returns>
        public static string CBitToString(bool str)
        {
            string result = "0";
            if (str)
                result = "1";
            return result;
        }

        /// <summary>
        /// 1转换为true，0转换为false
        /// </summary>
        /// <param name="str">bool</param>
        /// <returns>string</returns>
        public static int CBoolToInt(bool str)
        {
            int result = 0;
            if (str)
                result = 1;
            return result;
        }
        /// <summary>
        /// 1转换为true，0转换为false
        /// </summary>
        /// <param name="str">bool</param>
        /// <returns>string</returns>
        public static bool CIntToBool(int str)
        {
            bool result = false;
            if (str == 1)
                result = true;
            return result;
        }
        /// <summary>
        /// 转换日期形变量到字符串，并去掉默认显示时间
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static string CDateToString(DateTime time)
        {
            string result = time.ToString().Replace("0001-1-1 0:00:00", "").Replace("1900-1-1 0:00:00", "");
            return result;
        }
        /// <summary>
        /// 转换字符串到数字类型,默认返回0
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static int CStringToint(string str)
        {
            int result = 0;
            if (str == null || str.Length == 0 || !IfNumeric(str))
                return result;
            result = Convert.ToInt32(str);
            return result;
        }
        /// <summary>
        /// 转换字符串到bool类型
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static bool CStringToBool(string str)
        {
            bool result = false;
            if (str == null || str.Length == 0 || !IfNumeric(str))
                return result;
            if (str == "0")
                result = false;
            else
                result = true;
            return result;
        }
        /// <summary>
        /// 转换字符串到日期形变量,默认返回1900-1-1 0:00:00
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static DateTime CStringToDate(string str)
        {
            DateTime result = Convert.ToDateTime("1900-1-1 0:00:00");
            if (str == null || str.Length == 0 || !IfDateTimeFormat(str))
                return result;
            result = Convert.ToDateTime(str);
            return result;
        }
        #endregion

        /// <summary>
        /// 去除html编辑器的非法字符
        /// </summary>
        /// <param name="strChar">原字串</param>
        /// <returns>过滤过的字串</returns>
        public static string ReplaceHtmlChar(string strChar)
        {
            if (strChar == null || strChar.Trim() == "")
            {
                return "";
            }
            else
            {
                strChar = Regex.Replace(strChar, @"<script[^>]*?>.*?</script>", "", RegexOptions.IgnoreCase);
                strChar = Regex.Replace(strChar, @"<iframe[^>]*?>.*?</iframe>", "", RegexOptions.IgnoreCase);
                strChar = Regex.Replace(strChar, @"(<meta(.[^>]*)>)", "", RegexOptions.IgnoreCase);
                strChar = strChar.Replace("'", "''");
                return strChar.Trim();
            }
        }

        /// <summary>
        /// 转换日期格式1900-1-1 0:00:00到1900-1-1格式
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static string GetShortTime(string str)
        {
            string t = string.Empty;
            try
            {
                DateTime dt = Convert.ToDateTime(str);
                t = dt.ToShortDateString();
            }
            catch
            {
                t = "1900-01-01";
            }
            return t;
        }


        public static string HtmlDecode(string str)
        {
            str = str.Replace("<br>", "\n");
            str = str.Replace("&gt;", ">");
            str = str.Replace("&lt;", "<");
            str = str.Replace("&nbsp;", " ");
            str = str.Replace("&quot;", "\"");
            return str;
        }

        /// <summary>
        /// 转换HTML代码
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string HtmlEncode(string str)
        {
            str = str.Replace("\n", "<br>");
            str = str.Replace(">", "&gt;");
            str = str.Replace("<", "&lt;");
            str = str.Replace(" ", "&nbsp;");
            str = str.Replace("\"", "&quot;");
            return str;
        }

        public static bool IsId(string uid)
        {
            uid = uid.Trim();
            //			if (uid.Length<4)
            //			{
            //				return false;
            //			}

            string chk = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ_0123456789";
            int i, j;
            for (i = 0; i < uid.Length; i++)
            {
                string ch = uid.Substring(i, 1);
                for (j = 0; j < chk.Length; j++)
                {
                    if (chk.IndexOf(ch) >= 0)
                    {
                        break;
                    }
                }
                if (j == chk.Length)
                {
                    return false;
                }
            }

            return true;
        }


        /// <summary>
        /// 获取字符的长度
        /// </summary>
        /// <param name="mText">最短长度</param>
        /// <param name="startLen">最长长度</param>
        /// <param name="endLen">返回值</param>
        /// <returns></returns>
        public static bool GetStringLen(string mText, int startLen, int endLen)
        {
            if (System.Text.Encoding.Default.GetByteCount(mText) < startLen || System.Text.Encoding.Default.GetByteCount(mText) > endLen)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static string CutTime(string str)
        {
            string result = "";
            string[] time = str.Split('-');
            for (int i = 1; i < time.Length; i++)
            {
                result += time[i] + "-";
            }
            if (result.Length > 0)
            {
                return result.Substring(0, result.Length - 1);
            }
            else
            {
                return result;
            }
        }
        public static int GetTBNum()
        {
            Random rand = new Random();
            DateTime dt = DateTime.Now;
            string randstr = rand.Next(100).ToString().PadLeft(3, '0');

            string all = dt.Hour.ToString().PadLeft(2, '0') + dt.Minute.ToString().PadLeft(2, '0') + dt.Second.ToString().PadLeft(2, '0') + randstr;
            return Convert.ToInt32(all);
        }


    }
}
