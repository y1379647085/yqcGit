using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;
using System.Xml;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;

namespace ExtendMethods
{
    public class XmlHelper
    {
        /// <summary>
        /// 序列化对象到XML
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filePath"></param>
        /// <param name="obj"></param>
        public static void SerializeToXml<T>(string filePath, T obj)
        {
            try
            {
                using (var writer = new StreamWriter(filePath))
                {
                    var xs = new XmlSerializer(typeof(T));
                    xs.Serialize(writer, obj);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 反序列化XML文件到具体的实体类对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static T DeserializeFromXml<T>(string filePath)
        {
            try
            {if (!File.Exists(filePath))
                    throw new ArgumentException(filePath + " not Exists");
                using (var reader = new StreamReader(filePath))
                {
                    var xs = new XmlSerializer(typeof(T));
                    var ret = (T)xs.Deserialize(reader);
                    return ret;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 将对象序列化成xml字符串。
        /// </summary>
        /// <typeparam name="T">对象类型。</typeparam>
        /// <param name="obj">对象。</param>
        /// <returns>返回xml字符串。</returns>
        public static string SerializeToXmlString<T>(T obj)
        {
            using (var ms = new MemoryStream())
            {
                var xmlWs = new XmlWriterSettings
                {
                    Encoding = Encoding.UTF8,
                    NewLineChars = "\r\n",
                    Indent = true,
                    IndentChars = "  "
                };
                using (var writer = XmlWriter.Create(ms, xmlWs))
                {
                    var xs = new XmlSerializer(typeof(T));
                    xs.Serialize(writer,obj);
                    writer.Close();
                    ms.Position = 0;
                    using (var reader = new StreamReader(ms))
                    {
                        return reader.ReadToEnd();
                    }
                }
            }
        }

        /// <summary>
        /// 将xml字符串反序列化成对象。
        /// </summary>
        /// <typeparam name="T">对象类型。</typeparam>
        /// <param name="xmlString">xml字符串。</param>
        /// <returns>返回对象。</returns>
        public static T DeserializeFromXmlString<T>(string xmlString)
        {
            var byteArray = Encoding.UTF8.GetBytes(xmlString);
            if (byteArray.Length < 1) return default(T);
            using (var ms = new MemoryStream(byteArray))
            {
                var xs = new XmlSerializer(typeof(T));
                using (var reader = new StreamReader(ms, Encoding.UTF8))
                {
                    return (T)xs.Deserialize(reader);
                }
            }
        }

        /// <summary>
        /// 将对象序列化为二进制数组
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static byte[] SerializeObject(object obj)
        {
            if (obj == null) return null;
            using (var ms = new MemoryStream())
            {
                new BinaryFormatter().Serialize(ms,obj);
                return ms.ToArray();
            }
        }

        /// <summary>
        /// 将二进制数组反序列化为对象
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static object DeserializeObject(byte[] bytes)
        {
            if (bytes == null || bytes.Length == 0) return null;
            using (var ms = new MemoryStream(bytes) { Position = 0 })
            {
                return new BinaryFormatter().Deserialize(ms);
            }
        }

        /// <summary>
        /// 反序列化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="objArray"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public static bool Deserialize<T>(byte[] objArray, out T result)
        {
            result = default(T);
            if (objArray == null || objArray.Length <= 0)
            {
                return false;
            }
            try
            {
                using (var ms = new MemoryStream(objArray))
                {
                    var bf = new BinaryFormatter();
                    result = (T)bf.Deserialize(ms);
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 对象转换为Json
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static string ObjectToJson(object item)
        {
            try
            {
                if (item == null)
                    return "";
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(item.GetType());
                MemoryStream ms = new MemoryStream();
                serializer.WriteObject(ms, item);
                StringBuilder sb = new StringBuilder();
                sb.Append(Encoding.UTF8.GetString(ms.ToArray()));
                ms.Close();
                return sb.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Json转换为对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="jsonString"></param>
        /// <returns></returns>
        public static T JsonToObject<T>(string jsonString)
        {
            try
            {
                if (string.IsNullOrEmpty(jsonString))
                    return default(T);
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(T));
                MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(jsonString));
                T jsonObject = (T)ser.ReadObject(ms);
                ms.Close();
                return jsonObject;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
