using System;
using System.Security.Cryptography;
using System.Text;

namespace TuCao.Utility
{
    /// <summary>
    /// 加密类
    /// </summary>
    public class EncryptHelper
    {
        /// <summary>
        /// 3Des加密
        /// </summary>
        /// <param name="encryptString">需要加密的字符串</param>
        /// <param name="secretKey">密钥</param>
        /// <returns>加密后的字符串</returns>
        public static string Encrypt3Des(string encryptString, string secretKey)
        {
            var des = new TripleDESCryptoServiceProvider();

            des.Key = ASCIIEncoding.ASCII.GetBytes(secretKey);
            des.Mode = CipherMode.ECB;

            ICryptoTransform desEncrypt = des.CreateEncryptor();

            byte[] Buffer = ASCIIEncoding.ASCII.GetBytes(encryptString);
            return Convert.ToBase64String(desEncrypt.TransformFinalBlock(Buffer, 0, Buffer.Length));
        }

        /// <summary>
        /// 3Des解密
        /// </summary>
        /// <param name="decryptString">需要解密的字符串</param>
        /// <param name="secretKey">密钥</param>
        /// <returns>解密后的字符串</returns>
        public static string Decrypt3Des(string decryptString, string secretKey)
        {
            var des = new TripleDESCryptoServiceProvider();
            des.Key = des.Key = ASCIIEncoding.ASCII.GetBytes(secretKey);
            des.Mode = CipherMode.ECB;
            des.Padding = System.Security.Cryptography.PaddingMode.PKCS7;

            ICryptoTransform desDecrypt = des.CreateDecryptor();

            string result = "";
            try
            {
                byte[] Buffer = Convert.FromBase64String(decryptString);
                result = ASCIIEncoding.ASCII.GetString(desDecrypt.TransformFinalBlock(Buffer, 0, Buffer.Length));
            }
            catch
            {

            }
            return result;
        }

        /// <summary>
        /// 32位md5
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string GetBigMd5(string str)
        {
            string cl = str;
            string pwd = "";
            MD5 md5 = MD5.Create();

            byte[] s = md5.ComputeHash(Encoding.UTF8.GetBytes(cl));

            for (int i = 0; i < s.Length; i++)
            {
                pwd = pwd + s[i].ToString("x2");
            }

            return pwd;
        }
        /// <summary>
        /// 16位MD5
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string GetSmallMd5(string str)
        {
            var md5 = new MD5CryptoServiceProvider();
            string t2 = BitConverter.ToString(md5.ComputeHash(UTF8Encoding.Default.GetBytes(str)), 4, 8);
            t2 = t2.Replace("-", "");
            return t2;
        }

        /// <summary>
        /// SHA256加密(自定义编码)
        /// </summary>
        /// <param name="text">明文</param>
        /// <param name="key"></param>
        /// <param name="encode">编码</param>
        /// <returns></returns>
        public static string ToHmacSha256(string text, string key, Encoding encode)
        {

            using (HMACSHA256 sha256Hasher = new HMACSHA256(encode.GetBytes(key)))
            {
                byte[] hashedDataBytes = sha256Hasher.ComputeHash(encode.GetBytes(text));
                return ArrayToString(hashedDataBytes);
            }
        }

        private static string ArrayToString(byte[] bytes)
        {
            StringBuilder enText = new StringBuilder();
            foreach (byte iByte in bytes)
            {
                enText.AppendFormat("{0:X2}", iByte);
            }
            return enText.ToString();
        }

        public static string Base64Encrypt(string text, Encoding encode)
        {

            byte[] bytes = encode.GetBytes(text);
            try
            {
                return Convert.ToBase64String(bytes);
            }
            catch
            {
                return "";
            }
        }

        public static string Base64Decrypt(string text, Encoding encode)
        {
            try
            {
                byte[] bytes = Convert.FromBase64String(text);
                return encode.GetString(bytes);
            }
            catch
            {
                return text;
            }
        }
    }
}
