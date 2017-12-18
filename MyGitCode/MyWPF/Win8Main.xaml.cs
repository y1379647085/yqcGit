using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MyWPF
{
    /// <summary>
    /// Win8Main.xaml 的交互逻辑
    /// </summary>
    public partial class Win8Main : Window
    {
        bool leftFlag = false;
        public Win8Main()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (leftFlag)
            {
                leftFlag = false;//释放鼠标后标注为false;
            }
        }

        private void itnMan_MouseEnter(object sender, MouseEventArgs e)
        {
            itnMan.Source = new BitmapImage(new Uri(@"Images\ut.png", UriKind.Relative));
        }
        private void itnMan_MouseLeave(object sender, MouseEventArgs e)
        {
            itnMan.Source = new BitmapImage(new Uri(@"Images\ut_.png", UriKind.Relative));
        }
        private void itnCal_MouseEnter(object sender, MouseEventArgs e)
        {
            itnCal.Source = new BitmapImage(new Uri(@"Images\mid.png", UriKind.Relative));
        }
        private void itnCal_MouseLeave(object sender, MouseEventArgs e)
        {            
            itnCal.Source = new BitmapImage(new Uri(@"Images\mid_.png", UriKind.Relative));
        }

        private void itnMix_MouseUp(object sender, MouseButtonEventArgs e)
        {
            itnMix.Source = new BitmapImage(new Uri(@"Images\sysbtn\min_normal.png", UriKind.Relative));
        }

        private void itnMix_MouseDown(object sender, MouseButtonEventArgs e)
        {
            itnMix.Source = new BitmapImage(new Uri(@"Images\sysbtn\min_down.png", UriKind.Relative));
            this.WindowState = WindowState.Minimized;
        }

        private void itnMix_MouseLeave(object sender, MouseEventArgs e)
        {
            itnMix.Source = new BitmapImage(new Uri(@"Images\sysbtn\min_normal.png", UriKind.Relative));
        }

        private void itnMix_MouseEnter(object sender, MouseEventArgs e)
        {
            itnMix.Source = new BitmapImage(new Uri(@"Images\sysbtn\min_highlight.png", UriKind.Relative));
        }

        private void itnInOut_MouseEnter(object sender, MouseEventArgs e)
        {
            itnInOut.Source = new BitmapImage(new Uri(@"Images\edit_.png", UriKind.Relative));
        }
        private void itnInOut_MouseLeave(object sender, MouseEventArgs e)
        {
            itnInOut.Source = new BitmapImage(new Uri(@"Images\edit.png", UriKind.Relative));
        }
        private void itnInOut_MouseDown(object sender, MouseButtonEventArgs e)
        {
            InOutWindow o_InOut = new InOutWindow();
            o_InOut.ShowDialog();
        }
        private void itnClose_MouseDown(object sender, MouseButtonEventArgs e)
        {
            itnClose.Source = new BitmapImage(new Uri(@"Images\sysbtn\close_down.png", UriKind.Relative));
            this.Close();
        }
        private void itnClose_MouseEnter(object sender, MouseEventArgs e)
        {
            itnClose.Source = new BitmapImage(new Uri(@"Images\sysbtn\close_highlight.png", UriKind.Relative));
        }

        private void itnClose_MouseLeave(object sender, MouseEventArgs e)
        {
            itnClose.Source = new BitmapImage(new Uri(@"Images\sysbtn\close_normal.png", UriKind.Relative));
        }
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);

            // 获取鼠标相对标题栏位置  
            Point position = e.GetPosition(this);

            // 如果鼠标位置在标题栏内，允许拖动  
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                if (position.X >= 0 && position.X < this.ActualWidth && position.Y >= 0 && position.Y < this.ActualHeight)
                {
                    this.DragMove();
                }
            }
        }
    }
}
