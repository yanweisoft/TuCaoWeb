using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace TuCao.Utility
{
    public class ImageDomainHelper
    {
        /// <summary>
        /// 得到图片的前缀（http://i{0}.autoimg.cn/album/feed）
        /// </summary>
        /// <param name="imageUrl"></param>
        /// <returns></returns>
        public static string GetFeedImageUrl(string imageUrl)
        {
            if (string.IsNullOrEmpty(imageUrl))
                return string.Empty;
            if (imageUrl.StartsWith("http://"))
                return imageUrl;
            string fileName = Path.GetFileName(imageUrl);
            int r = 0, b = 0;
            while ((r += 4) < fileName.Length)
            {
                b ^= fileName[r];
            }
            b %= 2;
            string domain = string.Format(ConfigFileHelper.NewFeedImagePreUrl, b);

            return string.Concat(domain, imageUrl);
        }

        public static string GetTempHeadImageUrl(string imageUrl)
        {
            if (string.IsNullOrEmpty(imageUrl))
                return string.Empty;
            if (imageUrl.StartsWith("http://"))
                return imageUrl;
            string fileName = Path.GetFileName(imageUrl);
            int r = 0, b = 0;
            while ((r += 4) < fileName.Length)
            {
                b ^= fileName[r];
            }
            b %= 2;
            string domain = string.Format(ConfigFileHelper.NewTempImagePreUrl, b);

            return string.Concat(domain, imageUrl);
        }

        public static string GetHeadImageUrl(string headImageUrl)
        {
            if (string.IsNullOrEmpty(headImageUrl))
                return string.Empty;
            if (headImageUrl.StartsWith("http://"))
                return headImageUrl;
            string fileName = Path.GetFileName(headImageUrl);
            int r = 0, b = 0;
            while ((r += 4) < fileName.Length)
            {
                b ^= fileName[r];
            }
            b %= 2;
            string domain= string.Format(ConfigFileHelper.NewHeadImageImagePreUrl, b);
            return string.Concat(domain, headImageUrl);
        }

        public static string GetCarProductImageUrl(string carImageUrl)
        {
            if (string.IsNullOrEmpty(carImageUrl))
                return string.Empty;

            string fileName = Path.GetFileName(carImageUrl);
            int r = 0, b = 0;
            while ((r += 4) < fileName.Length)
            {
                b ^= fileName[r];
            }
            b %= 2;
            string domain = string.Format(ConfigFileHelper.CarProductImageDomian, b);

            return carImageUrl.Replace("http://img.autohome.com.cn", domain).Replace("http://www.autoimg.cn", domain);
        }
        public static string GetSeriesLogoPreUrl(string imageUrl)
        {
            if (string.IsNullOrEmpty(imageUrl))
                return string.Empty;
            if (imageUrl.StartsWith("http://"))
                return imageUrl;
            string fileName = Path.GetFileName(imageUrl);
            int r = 0, b = 0;
            while ((r += 4) < fileName.Length)
            {
                b ^= fileName[r];
            }
            b %= 2;
            string domain = string.Format(ConfigFileHelper.SeriesLogoPreUrl, b);
            domain += "/";
            return string.Concat(domain, imageUrl);
        }
    }
}
