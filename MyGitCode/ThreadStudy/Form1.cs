using DevExpress.XtraEditors;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Threading;

namespace ThreadStudy
{
    public partial class Form1 : Form
    {
        int maxThread = 100;
        public Form1()
        {
            InitializeComponent();
        }

        private void sbtnThread_Click(object sender, EventArgs e)
        {
            int i = 0;
            string j = "0";
            //Console.WriteLine(i == j);
            Console.WriteLine(i.Equals(j));
            //Console.WriteLine(i.Equals(j));
            // new Thread(o =>
            // {
            //     var time = TestTask();
            //     this.BeginInvoke(
            //         new Action<SimpleButton, int>(OutputInfo), sender as SimpleButton, time);
            // })
            // { IsBackground = true }
            //.Start();
        }

        private void sbtnThreadPool_Click(object sender, EventArgs e)
        {
            ThreadPool.QueueUserWorkItem(o =>
            {
                var time = TestTask();
                this.BeginInvoke(
                    new Action<SimpleButton, int>(OutputInfo), sender as SimpleButton, time);
            });
        }

        private void sbtnTask_Click(object sender, EventArgs e)
        {
            var t = new Task<int>(TestTask);
            t.ContinueWith(p=> {
                this.BeginInvoke(
                    new Action<SimpleButton, int>(OutputInfo), sender as SimpleButton, p.Result);
            });
            t.Start();
        }

        private async void sbtnAwait_Click(object sender, EventArgs e)
        {
            Task<int> t = new Task<int>(TestTask);
            t.Start();
            var time = await TestTaskAsync();
            OutputInfo(sender as SimpleButton, time);
        }

        /// <summary>
        /// 随机休眠模拟任务执行耗时
        /// </summary>
        /// <returns>任务消耗的时间(毫秒)</returns>
        int TestTask()
        {
            var rand = new Random();
            var time = rand.Next(100, 500);
            Thread.Sleep(time);
            return time;
        }
        /// <summary>
        /// 输出任务执行信息
        /// </summary>
        /// <param name="sender">按下的按钮</param>
        /// <param name="time">任务执行时间</param>
        void OutputInfo(SimpleButton sender, int time)
        {
            OutInfo.Text += $"\"{sender.Text}\"任务用时{time}毫秒！\r\n";
        }

        async Task<int> TestTaskAsync()
        {
            Task<int> t = new Task<int>(TestTask);
            t.Start();
            return await t;
        }

        void OutputInfo1()
        {
            //OutInfo.Text += $"\"{sender.Text}\"任务用时{time}毫秒！\n";
        }

        private void threadTest_Click(object sender, EventArgs e)
        {
            var time = AsyncTest(new Action(() => sbtnThreadPool_Click(sbtnThread, null)));
            ShowTestResult(sender, time);
        }

        private double AsyncTest(Action action)
        {
            var start = DateTime.Now;
            for (int i = 0; i < maxThread; i++)
            {
                action();
            }
            var ts = DateTime.Now - start;
            return ts.TotalMilliseconds;
        }

        /// <summary>
        /// 输出测试结果
        /// </summary>
        /// <param name="sender">按下的按钮</param>
        /// <param name="time">测试耗费时间</param>
        void ShowTestResult(object sender, double time)
        {
            var bt = sender as SimpleButton;
            if (bt == null) return;

            OutInfo.Text += $"{bt.Text}测试：启动{maxThread}个任务，共耗时：{time}毫秒！\n";
        }

        private void threadpoolTest_Click(object sender, EventArgs e)
        {
            var time = AsyncTest(new Action(() => sbtnThreadPool_Click(sbtnThreadPool, null)));
            ShowTestResult(sender, time);
        }

        private void taskTest_Click(object sender, EventArgs e)
        {
            var time = AsyncTest(new Action(() => sbtnTask_Click(sbtnTask, null)));
            ShowTestResult(sender, time);
        }

        private void awaitTest_Click(object sender, EventArgs e)
        {
            var time = AsyncTest(new Action(() => sbtnAwait_Click(sbtnAwait, null)));
            ShowTestResult(sender, time);
        }
    }

    public struct Test
    {
        public string testString { get; set; }
    }

    public class TestClass
    {
        private string name="123";
    }
}
