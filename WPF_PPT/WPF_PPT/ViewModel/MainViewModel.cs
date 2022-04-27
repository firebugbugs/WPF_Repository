using DevExpress.Utils.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using WPF_PPT.Common;
using WPF_PPT.Views;
using WPFDevelopers.Controls;

namespace WPF_PPT.ViewModel
{
    public class MainViewModel : NotifyBase
    {
        public MainViewModel()
        {
            
            #region 初始化：窗体切换
            this.NavChangedCommand = new Common.CommandBase();
            this.NavChangedCommand.DoExecute = new Action<object>(DoNavChanged);
            this.NavChangedCommand.DoCanExecute = new Func<object, bool>((o) => true);
            DoNavChanged("UserView_01");
            #endregion

            #region 初始化：关闭窗体
            this.CloseWindowCommand = new Common.CommandBase();
            this.CloseWindowCommand.DoExecute = new Action<object>((o) =>
            {
                (o as Window).Close();
            });
            this.CloseWindowCommand.DoCanExecute = new Func<object, bool>((o) => { return true; });
            #endregion

            #region 截图
            this.Screenshot = new Common.CommandBase();
            this.Screenshot.DoExecute = new Action<object>(DoScreenshot);
            this.Screenshot.DoCanExecute = new Func<object, bool>((o) => true);
            #endregion

            #region 打开关于
            this.OpenAbout = new Common.CommandBase();
            this.OpenAbout.DoExecute = new Action<object>(DoOpenAbout);
            this.OpenAbout.DoCanExecute = new Func<object, bool>((o) => true);
            #endregion
        }

        #region 窗体切换
        private FrameworkElement _mainContent;
        public FrameworkElement MainContent 
        {
            get { return _mainContent; }
            set { _mainContent = value; this.DoNotify(); }
        }

        public Common.CommandBase NavChangedCommand { get; set; }

        private void DoNavChanged(object obj)
        {
            Type type = Type.GetType("WPF_PPT.View." + obj.ToString());
            ConstructorInfo cti = type.GetConstructor(System.Type.EmptyTypes);
            this.MainContent = (FrameworkElement)cti.Invoke(null);
        }
        #endregion

        #region 关闭窗体
        public Common.CommandBase CloseWindowCommand { get; set; }
        #endregion

        #region 截图
        public Common.CommandBase Screenshot { get; set; }
        
        private void DoScreenshot(object obj)
        {
            var screenCut = new ScreenCut();
            Thread thread1 = new Thread(new ThreadStart(Thread1));
            thread1.Start();
            void Thread1()
            {
                Thread.Sleep(300);
                App.Current.Dispatcher.Invoke((Action)(() =>
                {
                    screenCut.ShowDialog();
                }));
            }
        }
        #endregion

        #region 打开关于
        public Common.CommandBase OpenAbout { get; set; }

        private void DoOpenAbout(object obj)
        {
            UI_About window = new UI_About();
            Thread thread1 = new Thread(new ThreadStart(Thread1));
            thread1.Start();
            void Thread1()
            {
                App.Current.Dispatcher.Invoke((Action)(() =>
                {
                    window.ShowDialog();
                }));
                
            }
            
        }
        #endregion

       
    }
}
