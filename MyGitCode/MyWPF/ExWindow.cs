using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace MyWPF
{
    public class ExWindow:Window
    {
        public ExWindow()
        {
            Loaded+=new RoutedEventHandler(ExWindow_Loaded);
        }
        void ExWindow_Loaded(object sender,RoutedEventArgs e)
        {
            try
            {
                Owner = Application.Current.MainWindow;
            }
            catch
            { }
        }
    }
}
