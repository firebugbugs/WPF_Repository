using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPF_PPT.Views;

namespace WPF_PPT
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class UI_Home : Window
    {
        public UI_Home()
        {
            InitializeComponent();
        }

        private void Enter_PPT(object sender, MouseButtonEventArgs e)
        {
            Thread thread_enter = new Thread(Thread_EnterPPT);
            thread_enter.IsBackground = true;
            thread_enter.Name = "thread_enter";
            thread_enter.Start();
        }

        private void Enter_PPT_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Down)
            {
                Thread thread_enter = new Thread(Thread_EnterPPT);
                thread_enter.IsBackground = true;
                thread_enter.Name = "thread_enter";
                thread_enter.Start();
            }
        }

        UI_01 window_window1 = new UI_01();
        private void Thread_EnterPPT()
        {
            Dispatcher.Invoke(new Action(() => window_window1.Opacity = 0));
            Dispatcher.Invoke(new Action(() => window_window1.Show()));
            for (float i = 0; i < 1; i = (float)(i + 0.01))
            {
                Dispatcher.Invoke(new Action(() => window_window1.Opacity = i));
                Thread.Sleep(10);
            }
            Dispatcher.Invoke(new Action(() => this.Close()));

        }
    }
}
