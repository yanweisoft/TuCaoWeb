using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace TuCao.Utility
{
    /// <summary>
    /// XML实用类
    /// </summary>
    public static class XmlLib
    {
        /// <summary>
        /// XML反序列成对象
        /// </summary>
        /// <param name="type">要序列化成对象的类型</param>
        /// <param name="filename">XML文件路径</param>
        /// <returns></returns>
        public static object Deserialize(Type type, string filename)
        {
            FileStream fs = null;
            try
            {
                // open the stream
                fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
                var serializer = new XmlSerializer(type);
                return serializer.Deserialize(fs);
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (fs != null)
                    fs.Close();
            }
        }

        /// <summary>
        /// XML字符串反序列成对象
        /// </summary>
        /// <param name="xml">XML字符串</param>
        /// <param name="type">要序列化成对象的类型</param>
        /// <returns></returns>
        public static object Deserialize(string xml, Type type)
        {
            xml = xml.Replace("<?xml version=\"1.0\" encoding=\"utf-16\"?>", "");
            MemoryStream ms = null;
            try
            {
                // open the stream
                ms = new MemoryStream(Encoding.Unicode.GetBytes("<?xml version=\"1.0\" encoding=\"utf-16\"?>" + xml));
                var serializer = new XmlSerializer(type);
                return serializer.Deserialize(ms);
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (ms != null)
                    ms.Close();
            }
        }

        /// <summary>
        /// 将对象序列化成XML
        /// </summary>
        /// <param name="o">对象</param>
        /// <param name="filename">指定文件</param>
        public static void Serialize(object o, string filename)
        {
            var serializer = new XmlSerializer(o.GetType());

            // Create an XmlSerializerNamespaces object.
            var ns = new XmlSerializerNamespaces();

            // Add two namespaces with prefixes.
            ns.Add("xsd", "http://www.w3.org/2001/XMLSchema");
            ns.Add("xsi", "http://www.w3.org/2001/XMLSchema-instance");

            // Create an XmlTextWriter using a FileStream.
            Stream fs = new FileStream(filename, FileMode.Create);
            XmlWriter writer = new XmlTextWriter(fs, new UnicodeEncoding());

            // Serialize using the XmlTextWriter.
            serializer.Serialize(writer, o, ns);
            writer.Close();
            fs.Close();
        }

        /// <summary>
        /// 将对象序列化成XML字符串
        /// </summary>
        /// <param name="o">对象</param>
        /// <returns>XML字符串</returns>
        public static string Serialize(object o)
        {
            var serializer = new XmlSerializer(o.GetType());

            // Create an XmlSerializerNamespaces object.
            var ns = new XmlSerializerNamespaces();
            // Add two namespaces with prefixes.
            ns.Add("xsd", "http://www.w3.org/2001/XMLSchema");
            ns.Add("xsi", "http://www.w3.org/2001/XMLSchema-instance");

            var sb = new StringBuilder();
            serializer.Serialize(XmlWriter.Create(sb), o, ns);

            return sb.ToString().Replace("<?xml version=\"1.0\" encoding=\"utf-16\"?>", "");
        }
    }
}
