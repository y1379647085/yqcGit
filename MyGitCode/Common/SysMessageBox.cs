using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraEditors;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace ExtendMethods
{
    public class SysMessageBox : Singleton<SysMessageBox>
    {
        private string _caption;
        public void Show(string message, string caption)
        {
            if (string.IsNullOrEmpty(caption))
                _caption = "提示";
            else
                _caption = caption;
        }

        public void Show(string message, string caption, int timeout)
        {
            if(string.IsNullOrEmpty(caption))
                _caption = "提示";
            else
                _caption = caption;
            StartKiller(timeout);
            XtraMessageBox.Show(message,caption);
        }

        public void Show(string message,string caption,DialogResult dr)
        {
             if(string.IsNullOrEmpty(caption))
                _caption = "提示";
            else
                _caption = caption;
            XtraMessageBox.Show(message,caption,MessageBoxButtons.OK);
        }


        private void StartKiller(int timeout)
        {
            Timer timer = new Timer();
            timer.Interval = timeout;
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
        }
        private void timer_Tick(object sender,EventArgs e)
        {
            KillMessageBox();
            //停止timer
            ((Timer)sender).Stop();
        }

        private void KillMessageBox()
        {
            //按照MessageBox的标题，找到MessageBox的窗口
            IntPtr ptr = FindWindow(null,_caption);
            if (ptr != IntPtr.Zero)
            {
                PostMessage(ptr,WM_CLOSE,IntPtr.Zero,IntPtr.Zero);
            }
        }

        [DllImport("user32.dll", EntryPoint = "FindWindow", CharSet = CharSet.Auto)]
        private extern static IntPtr FindWindow(string lpClassName, string lpWindwName);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int PostMessage(IntPtr hWnd, int mes, IntPtr wParm, IntPtr lParm);
        public const int WM_CLOSE = 0x10;
    }
}
