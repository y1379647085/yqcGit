using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionStudy
{
    class Program
    {
        static void Main(string[] args)
        {
            Type t = typeof(RefClass);
            RefClass rc = new RefClass();
            rc.Test3 = 3;
            //FieldInfo[] finfos = t.GetFields(BindingFlags.NonPublic
            //    | BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
            ////MemberInfo[] minfos = t.GetMembers(BindingFlags.NonPublic
            ////    | BindingFlags.Instance | BindingFlags.Public
            ////    |BindingFlags.DeclaredOnly);
            ////foreach (MemberInfo minfo in minfos)
            ////{
            ////    Console.WriteLine(minfo.Name);
            ////}
            //foreach (FieldInfo finfo in finfos)
            //{
            //    finfo.SetValue(rc,100);
            //    Console.WriteLine("字段名称：{0} 字段类型：{1} rc中的值：{2}",
            //        finfo.Name,finfo.FieldType.ToString(),finfo.GetValue(rc));
            //}
            //Console.ReadKey();
            PropertyInfo[] finfos = t.GetProperties(BindingFlags.NonPublic|
                BindingFlags.Public|BindingFlags.Instance|BindingFlags.DeclaredOnly);
            foreach (PropertyInfo finfo in finfos)
            {
                MethodInfo getinfo = finfo.GetGetMethod(true);
                Console.WriteLine("get方法的名称{0} 返回值类型：{1} 参数数量{2} MSIL代码长度："
                   + " {3}局部变量数量：{4} ", getinfo.Name, getinfo.ReturnType.ToString(),
                   getinfo.GetParameters().Count(),
                   getinfo.GetMethodBody().GetILAsByteArray().Length,
                   getinfo.GetMethodBody().LocalVariables.Count);
                MethodInfo setinfo = finfo.GetSetMethod(true);
                Console.WriteLine("set方法的名称{0} 返回值类型：{1} 参数数量{2} MSIL代码长度："
                   + " {3}局部变量数量：{4} ", setinfo.Name, setinfo.ReturnType.ToString(),
                   setinfo.GetParameters().Count(),
                   setinfo.GetMethodBody().GetILAsByteArray().Length,
                   setinfo.GetMethodBody().LocalVariables.Count);
                setinfo.Invoke(rc, new object[] { 123 });
                object obj = getinfo.Invoke(rc, null);
                Console.WriteLine("方法名：{0} 内部值：{1}", finfo.Name, obj);

            }
            Console.ReadKey();
        }
    }
}
