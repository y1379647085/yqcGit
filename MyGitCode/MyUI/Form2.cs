using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyUI
{
    public partial class Form2 : Form
    {
        private BackgroundWorker _demoBGwoker = new BackgroundWorker();
                
        public Form2()
        {
            InitializeComponent();
            //别忘了设置滚动条。
            progressBar1.Maximum = 100;
            _demoBGwoker.WorkerReportsProgress = true;
            _demoBGwoker.WorkerSupportsCancellation = true;
        }

        private void _demoBGwoker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            var msg = e.UserState.ToString();
        }

        private void _demoBGwoker_DoWork(object sender, DoWorkEventArgs e)
        {
            int endNo = 0;
            if (e.Argument != null)
            {
                endNo = (int)e.Argument;
            }
            int sum = 0;
            for (int i = 0; i <= endNo; i++)
            {
                sum += i;
                string message = "Current sum is: " + sum.ToString();
                //ReportProgress 方法把信息传递给 ProcessChanged 事件处理函数。
                //第一个参数类型为 int，表示执行进度。
                //如果有更多的信息需要传递，可以使用 ReportProgress 的第二个参数。
                //这里我们给第二个参数传进去一条消息。
                _demoBGwoker.ReportProgress(i, message);
                Thread.Sleep(600);
                if (_demoBGwoker.CancellationPending)
                {
                    e.Cancel = true;
                    break;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //_demoBGwoker.ProgressChanged += _demoBGwoker_ProgressChanged;
            //_demoBGwoker.DoWork += _demoBGwoker_DoWork;
            //_demoBGwoker.RunWorkerAsync(100);
            //AbstactClass abs2 = new AbstractClass3();
            //VirtualClassFather virtualClass = new VirtualClass();
            //virtualClass.CreateNode();
            //var delegateclass = new BeginInvokeClass();
            //BeginInvokeClass.start();
            //ChildClass1 child = new ChildClass1("1", "2d");
            //child.CheckTest();
            var list=new ConcreteList();
            var iterator = list.GetIterator();
            while (iterator.MoveNext())
            {
                int i = (int) iterator.GetCurrent();
                Console.WriteLine(i.ToString());
                iterator.Next();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            _demoBGwoker.CancelAsync();
        }
    }
}
