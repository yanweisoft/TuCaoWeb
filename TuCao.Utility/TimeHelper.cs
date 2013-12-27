using System;

namespace TuCao.Utility
{
    /// <summary>
    /// 时间操作类
    /// </summary>
    public class TimeHelper
    {
        /// <summary>
        /// UnixTime-->Datetime
        /// </summary>
        /// <param name="unixTime"></param>
        /// <returns></returns>
        public static DateTime ConvertIntDateTime(long unixTime)
        {
            DateTime time = System.DateTime.MinValue;
            DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            time = startTime.AddSeconds(unixTime);
            return time;
        }

        /// <summary>
        /// Datetime-->UnixTime
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static long ConvertDateTimeInt(DateTime time)
        {
            double intResult = 0;
            DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            intResult = (time - startTime).TotalSeconds;
            return (long)intResult;
        }

        /// <summary>
        /// 得到时间轴
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static string GetTimeline(DateTime time)
        {
            TimeSpan span = DateTime.Now - time;
            string retrunInfo;
            if (span.TotalSeconds < 60)
            {
                //小于60秒
                int second = (int)span.TotalSeconds;
                retrunInfo = second < 15 ? "刚刚发布" : string.Concat(second, "秒前");
            }
            else if (span.TotalSeconds < 3600)
            {
                //1小时之内
                retrunInfo = string.Concat((int)span.TotalMinutes, "分钟前");
            }
            else if (time.Date == DateTime.Now.Date)
            {
                retrunInfo = string.Concat("今天 ", time.ToString("HH:mm"));
            }
            else if (time.Year == DateTime.Now.Year)
            {
                //昨天到去年一月一日
                retrunInfo = time.ToString("M月d日 H:mm");
            }
            else
            {
                retrunInfo = time.ToString("yyyy-M-d H:mm");
            }
            return retrunInfo;
        }
    }
}
