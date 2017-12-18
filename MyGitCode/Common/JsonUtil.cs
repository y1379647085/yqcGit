using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ExtendMethods
{
    public class JsonUtil
    {
        /// <summary>
        /// Json序列化对象到指定文件。
        /// </summary>
        /// <param name="filePath">文件路径。</param>
        /// <param name="value">实体类对象。</param>
        /// <param name="formatting">格式化选项。</param>
        /// <returns></returns>
        public static bool SerializeToFile(string filePath,object value,Formatting formatting=Formatting.Indented)
        {
            try
            {
                using (var writer = new StreamWriter(filePath))
                {
                    var text = JsonConvert.SerializeObject(value, formatting);
                    writer.Write(text);
                }
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        /// <summary>
        /// Json序列化对象为字符串。
        /// </summary>
        /// <param name="value">实体类对象。</param>
        /// <param name="formatting">格式化选项。</param>
        /// <returns></returns>
        public static string SerializeToString(object value,Formatting formatting=Formatting.Indented)
        {
            try
            {
                return JsonConvert.SerializeObject(value, formatting);
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// 从指定文件反序列对象，读取字符串时ReadAllText的默认编码参数为Encoding.Default。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filePath">文件路径。</param>
        /// <returns></returns>
        public static T DeserializeFromFile<T>(string filePath)
        {
            if (!File.Exists(filePath)) return default(T);
            var text = File.ReadAllText(filePath, Encoding.Default);
            return (T) JsonConvert.DeserializeObject(text, typeof (T));
        }
        /// <summary>
        /// 从指定字符串反序列对象。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">Json字符串。</param>
        /// <returns></returns>
        public static T DeserializeFromString<T>(string value)
        {
            return (T)JsonConvert.DeserializeObject(value, typeof(T));
        }
    }
}
