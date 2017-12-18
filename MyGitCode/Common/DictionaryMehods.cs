using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExtendMethods
{
    /// <summary>
    /// 字典类
    /// </summary>
    public class DictionaryMehods
    {
        /// <summary>
        /// 使用委托事件对字典进行排序
        /// </summary>
        /// <param name="dic">字典</param>
        /// <returns>排序后的字典</returns>
        public Dictionary<string, int> DictionarySort(Dictionary<string, int> dic)
        {
            List<KeyValuePair<string, int>> listDic = new List<KeyValuePair<string, int>>(dic);
            listDic.Sort((s1, s2) => s2.Value.CompareTo(s1.Value));
            dic.Clear();
            foreach (KeyValuePair<string, int> kvp in listDic)
            {
                dic.Add(kvp.Key,kvp.Value);
            }
            return dic;
            
        }
        /// <summary>
        /// 使用linq排序对字典进行排序。
        /// </summary>
        /// <param name="dic">字典。</param>
        /// <returns>排序后的字典。</returns>
        public Dictionary<string, int> DictionarySortByLinq(Dictionary<string, int> dic)
        {
            dic = (from entry in dic
                   orderby entry.Value descending
                   select entry).ToDictionary(pair => pair.Key, pair => pair.Value);
            return dic;
        }

        /// <summary>
        /// 检测字典中的重复值。
        /// </summary>
        /// <param name="dicField">字典。</param>
        /// <returns>检测的重复值集合结果，key是重复的值，key对应的是一个重复值字典集合。</returns>
        public IEnumerable<IGrouping<string,KeyValuePair<int,string>>> DuplicateDetection(Dictionary<int, string> dicField)
        {
            if (dicField == null || dicField.Count == 0)
                return null;
            var duplicateValues = dicField.GroupBy(x => x.Value).Where(x => x.Count() > 1);
            return duplicateValues;
        }

        /// <summary>
        /// 检测字点中的重复值。
        /// </summary>
        /// <param name="dicField">字典。</param>
        /// <returns>检测的重复值集合结果，key是重复的值，key对应的是一个重复值字典集合。</returns>
        public Dictionary<string,int> GetDuplicateValueCount(Dictionary<int, string> dicField)
        {
            if (dicField == null || dicField.Count == 0)
                return null;
            var duplicateValues = dicField.GroupBy(x => x.Value).Where(x => x.Count() > 1);
            return duplicateValues.ToDictionary(groupValue => groupValue.Key, groupValue => groupValue.ToList().Count);
        }
    }
}
