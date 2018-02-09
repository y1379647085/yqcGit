using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyUI
{
    class Test
    {
        public void SetValue()
        {
            //ToDo
        }
        public void SetValue1()
        {
            //ToDo
        }
    }

    class BaseClassTest
    {
        public string P1;
        public string P2;
        public BaseClassTest(string p1,string p2)
        {
            P1 = p1;
            P2 = p2;
        }
    }

    class ChildClass1:BaseClassTest
    {
        public ChildClass1(string p1, string p2) : base(p1, p2)
        {
        }
        public void Test1()
        {
            Test();
        }
        public  int CheckTest()
        {
            Form1 frm1 = null;
            try
            {
                frm1=new Form1();
                //Test();
                return frm1.GetTempNum();

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            finally
            {
                frm1.Dispose();
            }
        }
        public virtual void Test()
        {
            try
            {
                var s = P1 + P2;
                string s1 = null;
                s1.ToString();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                //throw;
            }
         
        }
    }
    class ChildClass2 : ChildClass1
    {
        public Dictionary<string, string> _users { get; } = new Dictionary<string, string>()

        {

            ["users"] = "Venkat Baggu Blog",

            ["Features"] = "Whats new in C# 6"

        };
        public ChildClass2(string p1, string p2) : base(p1, p2)
        {
        }
        //public new void Test1()
        //{
        //    Test();
        //}
        public override void Test()
        {
            
            try
            {
                var s = P1 + P2;
                double d;
                double.TryParse(s,out d);
                d.ToString();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }          
        }

       
    }
    public static class TestClass1
    {
    }
}
