using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyUI
{
    public class BeginInvokeClass
    {
        private delegate int Dothread();
        static Dothread dothread = new Dothread(work);

        public static void start()
        {
            AsyncCallback backCall = new AsyncCallback(backcall);
            dothread.BeginInvoke(backCall, "我是异步调用的parameter");//第一个参数是调用work方法的参数，第二个是回调函数，第三个是需要传到回调函数里的参数可以是Object类型
        }
        /// <summary>
        ///这个是委托调用程序
        /// </summary>
        private static int work()
        {
            System.Windows.Forms.MessageBox.Show("我是委托调用程序");
            return 999;

        }
        /// <summary>
        /// 回调函数
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        private static void backcall(IAsyncResult parameter)
        {
            int result = dothread.EndInvoke(parameter);
            System.Windows.Forms.MessageBox.Show("这是一个回调函数");
            System.Windows.Forms.MessageBox.Show(result.ToString());
            System.Windows.Forms.MessageBox.Show(parameter.AsyncState.ToString());


        }
    }

}