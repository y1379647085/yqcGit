using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThreadStudy
{
    class Program
    {
        delegate void AsyncFoo(int i);
        static bool done;
      
        static object locker=new object();
        //static void Main(string[] args)
        //{
        //    //var thread = new Thread(Go);
        //    ////Task t = new Task(Go);
        //    ////thread.Interrupt

        //    //thread.Start();
        //    ////Go();
        //    PrintCurrThreadInfo("Main()");
        //    for (int i = 0; i < 10; i++)
        //    {
        //        PostAsync();
        //    }
        //    Console.ReadLine();
        //}
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        static void Go(Object object1)
        {
            lock (locker)
                if (!done) { done = true; Console.WriteLine("Done"); }
        }
        ///<summary>
        /// 输出当前线程的信息
        ///</summary>
        ///<param name="name">方法名称</param>

        static void PrintCurrThreadInfo(string name)
        {
            Console.WriteLine("Thread Id of " + name + " is: " + Thread.CurrentThread.ManagedThreadId + ", current thread is "
            + (Thread.CurrentThread.IsThreadPoolThread ? "" : "not ")
            + "thread pool thread.");
        }
        ///<summary>
        /// 测试方法，Sleep一定时间
        ///</summary>
        ///<param name="i">Sleep的时间</param>
        static void Foo(int i)
        {
            PrintCurrThreadInfo("Foo()");
            Thread.Sleep(i);
        }
        ///<summary>
        /// 投递一个异步调用
        ///</summary>
        static void PostAsync()
        {
            AsyncFoo caller = new AsyncFoo(Foo);
            caller.BeginInvoke(1000, new AsyncCallback(FooCallBack), caller);
        }
        static void FooCallBack(IAsyncResult ar)
        {
            PrintCurrThreadInfo("FooCallBack()");
            AsyncFoo caller = (AsyncFoo)ar.AsyncState;
            caller.EndInvoke(ar);

        } 
    }
}
