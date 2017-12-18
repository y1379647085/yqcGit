using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ExtendMethods
{
    public class RegexClass
    {
        /// <summary>
        /// 从指定字符串中过滤出第一个数字
        /// </summary>
        /// <param name="source">源字符串</param>
        /// <returns>源字符串的第一个数字</returns>
        public static string GetFirstNumberByString(string source)
        {
            return Regex.Match(source, @"\d+").Groups[0].Value;
        }

        /// <summary>
        /// 从指定字符串中过滤出最后一个数字
        /// </summary>
        /// <param name="source">源字符串</param>
        /// <returns>源字符串的最后一个数字</returns>
        public static string GetLastNumberByString(string source)
        {
            var reg = Regex.Matches(source, @"\d+");
            return reg[reg.Count - 1].Value;
        }

        /// <summary>
        /// 从指定字符串中过滤出所有数字
        /// </summary>
        /// <param name="source">源字符串</param>
        /// <returns>源字符串的所有数字</returns>
        public static List<string> GetAllNumberByString(string source)
        {
            var reg = Regex.Matches(source, @"\d+");
            List<string> list = new List<string>();
            foreach (Match item in reg)
            {
                list.Add(item.Value);
            }

            return list;
        }

        /// <summary>
        /// 检车源字符串中是否包含数字
        /// </summary>
        /// <param name="source">源字符串</param>
        /// <returns>true:源字符串包含数字;false:源字符串不包含数字</returns>
        public static bool CheckNumberByString(string source)
        {
            return Regex.Match(source, @"\d").Success;
        }

        /// <summary>
        /// 判断字符串是否全部是数字且长度等于指定长度
        /// </summary>
        /// <param name="source">源字符串</param>
        /// <param name="length">指定长度</param>
        /// <returns>返回值</returns>
        public static bool CheckLengthByString(string source, int length)
        {
            Regex rg = new Regex(@"^\d{" + length + "}$");
            return rg.IsMatch(source);
        }

        /// <summary>
        /// 匹配邮箱是否合法
        /// </summary>
        /// <param name="source">待匹配字符串</param>
        /// <returns>匹配结果true是邮箱反之不是邮箱</returns>
        public static bool CheckEmailByString(string source)
        {
            Regex rg = new Regex("^\\s*([A-Za-z0-9_-]+(\\.\\w+)*@(\\w+\\.)+\\w{2,5})\\s*$", RegexOptions.IgnoreCase);
            return rg.IsMatch(source);
        }

        /// <summary>
        /// 匹配日期是否合法
        /// </summary>
        /// <param name="source">待匹配字符串</param>
        /// <returns>匹配结果true是日期反之不是日期</returns>
        public static bool CheckDateByString(string source)
        {
            Regex rg = new Regex(@"^(\d{4}[\/\-](0?[1-9]|1[0-2])[\/\-]((0?[1-9])|((1|2)[0-9])|30|31))|((0?[1-9]|1[0-2])[\/\-]((0?[1-9])|((1|2)[0-9])|30|31)[\/\-]\d{4})$");
            return rg.IsMatch(source);
        }

        /// <summary>
        /// 从字符串中获取第一个日期
        /// </summary>
        /// <param name="source">源字符串</param>
        /// <returns>源字符串中的第一个日期</returns>
        public static string GetFirstDateByString(string source)
        {
            return Regex.Match(source, @"(\d{4}[\/\-](0?[1-9]|1[0-2])[\/\-]((0?[1-9])|((1|2)[0-9])|30|31))|((0?[1-9]|1[0-2])[\/\-]((0?[1-9])|((1|2)[0-9])|30|31)[\/\-]\d{4})")
                .Groups[0].Value;
        }

        /// <summary>
        /// 从字符串中获取所有的日期
        /// </summary>
        /// <param name="source">源字符串</param>
        /// <returns>源字符串中的所有日期</returns>
        public static List<string> GetAllDateByString(string source)
        {
            var all = Regex.Matches(source, @"(\d{4}[\/\-](0?[1-9]|1[0-2])[\/\-]((0?[1-9])|((1|2)[0-9])|30|31))|((0?[1-9]|1[0-2])[\/\-]((0?[1-9])|((1|2)[0-9])|30|31)[\/\-]\d{4})");
            List<string> list = new List<string>();
            foreach (Match item in all)
            {
                list.Add(item.Value);
            }
            return list;
        }

        /// <summary>
        /// 检测密码复杂度是否达标：密码中必须包含字母、数字、特称字符，至少8个字符，最多16个字符。
        /// </summary>
        /// <param name="source">待匹配字符串</param>
        /// <returns>密码复杂度是否达标true是达标反之不达标</returns>
        public static bool CheckPasswordByString(string source)
        {
            Regex rg = new Regex(@"^(?=.*\d)(?=.*[a-zA-Z])(?=.*[^a-zA-Z0-9]).{8,16}$");
            return rg.IsMatch(source);
        }

        /// <summary>
        /// 匹配邮编是否合法
        /// </summary>
        /// <param name="source">待匹配字符串</param>
        /// <returns>邮编合法返回true,反之不合法</returns>
        public static bool CheckPostcodeByString(string source)
        {
            Regex rg = new Regex(@"^\d{6}$");
            return rg.IsMatch(source);
        }

        /// <summary>
        /// 匹配手机号码是否合法
        /// </summary>
        /// <param name="source">待匹配字符串</param>
        /// <returns>手机号码合法返回true,反之不合法</returns>
        public static bool CheckMobilephoneByString(string source)
        {
            Regex rg = new Regex(@"^[1]+[3,5,7,8]+\d{9}$");
            return rg.IsMatch(source);
        }

        /// <summary>
        /// 从字符串中获取手机号码
        /// </summary>
        /// <param name="source">源字符串</param>
        /// <returns>源字符串中手机号码</returns>
        public static string GetMobilephoneByString(string source)
        {
            return Regex.Match(source, @"[1]+[3,5,7,8]+\d{9}").Groups[0].Value;
        }

        /// <summary>
        /// 匹配身份证号码是否合法
        /// </summary>
        /// <param name="source">待匹配字符串</param>
        /// <returns>身份证号码合法返回true,反之不合法</returns>
        public static bool CheckIDCardByString(string source)
        {
            Regex rg = new Regex(@"^(^\d{15}$|^\d{18}$|^\d{17}(\d|X|x))$");
            return rg.IsMatch(source);
        }

        /// <summary>
        /// 从字符串中获取身份证号码
        /// </summary>
        /// <param name="source">源字符串</param>
        /// <returns>源字符串中身份证号码</returns>
        public static string GetIDCardByString(string source)
        {
            return Regex.Match(source, @"(^\d{15}$|^\d{18}$|^\d{17}(\d|X|x))").Groups[0].Value;
        }

        /// <summary>  
        /// 判断输入的字符串是否是一个超链接  
        /// </summary>  
        /// <param name="source"></param>  
        /// <returns></returns>  
        public static bool IsURL(string source)
        {
            string pattern = @"http://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?";  
            //string pattern = @"^[a-zA-Z]+://(\w+(-\w+)*)(\.(\w+(-\w+)*))*(\?\S*)?$";
            Regex regex = new Regex(pattern); 
            return regex.IsMatch(pattern);

        }  
    }
}
