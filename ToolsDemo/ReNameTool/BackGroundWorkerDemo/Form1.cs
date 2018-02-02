using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BackGroundWorkerDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            backgroundWorker1.WorkerReportsProgress = true;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            //BackgroundWorker bgWorker = sender as BackgroundWorker;
            //int endNumber = 0;
            //if (e.Argument != null)
            //{
            //    endNumber = (int)e.Argument;
            //}

            //int sum = 0;
            //for (int i = 0; i <endNumber; i++)
            //{
            //    sum += i;
            //    var dr = _dtResult.Rows[i];
            //    if (dr[2].ToString() == dr[3].ToString())
            //    {
            //        continue;
            //    }

            //    var path = dr[0].ToString().Substring(0, dr[0].ToString().LastIndexOf("\\"));
            //    File.Move(dr[0].ToString(), path + "\\" + dr[3].ToString());
            //    string message = "Current sum is: " + sum.ToString();
            //    //ReportProgress 方法把信息传递给 ProcessChanged 事件处理函数。
            //    //第一个参数类型为 int，表示执行进度。
            //    //如果有更多的信息需要传递，可以使用 ReportProgress 的第二个参数。
            //    //这里我们给第二个参数传进去一条消息。
            //    bgWorker.ReportProgress(i, message);


            //}
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            ////修改进度条的显示。
            //this.progressBar1.Value = e.ProgressPercentage;

            ////如果有更多的信息需要传递，可以使用 e.UserState 传递一个自定义的类型。
            ////这是一个 object 类型的对象，您可以通过它传递任何类型。
            ////我们仅把当前 sum 的值通过 e.UserState 传回，并通过显示在窗口上。
            //string message = e.UserState.ToString();
            //this.labelControl1.Text = message;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //XtraMessageBox.Show("保存成功");
        }
    }
}
