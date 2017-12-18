using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExtendMethods
{
    /// <summary>
    /// 经典排序算法类
    /// </summary>
    class ClassicalSortMethod
    {
        /// <summary>
        /// 冒泡排序
        /// </summary>
        /// <param name="listValue">需要排序的数列</param>
        public static int[] BubbleSort(int[] listValue)
        {
            int i, j, temp;
            for (i = 0; i < listValue.Length; i++)
            {
                var exchange = false;//交换标志
                for (j = listValue.Length - 2; j >= i; j--)
                {
                    if (listValue[j + 1] < listValue[j])
                    {
                        temp = listValue[j + 1];
                        listValue[j + 1] = listValue[j];
                        listValue[j] = temp;
                        exchange = true; //发生了交换，故将交换标志置为真 
                    }                
                }
                if (!exchange) //本趟排序未发生交换，提前终止算法 
                {
                    break;
                }
            }
            return listValue;
        }

        /// <summary>
        /// 插入排序
        /// </summary>
        /// <param name="list">需要排序的数列</param>
        /// <returns></returns>
        public static int[] InsertSort(int[] list)
        {
            for(int i=1;i<list.Length;i++)
            {
                int t = list[i];
                int j=i;
                while((j>0)&&(list[j-1])>t)
                {
                    list[j] = list[j - 1];
                    j--;
                }
                list[j] = t;
            }
            return list;
        }


        public static int[] SelectSort(int[] list)
        {
            for (int i = 0; i < list.Length-1; i++)
            {
                var min = i;
                for (int j = i + 1; j < list.Length; j++)
                {
                    if (list[j] < list[min])
                    {
                        min = j;
                    }
                }
                int t = list[min];
                list[min] = list[i];
                list[i] = t;
            }
            return list;
        }


        public static void Recursive()
        {

        }
    }
}
