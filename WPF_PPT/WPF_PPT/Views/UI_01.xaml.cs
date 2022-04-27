using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WPF_PPT.ViewModel;

namespace WPF_PPT.Views
{
    /// <summary>
    /// UI_01.xaml 的交互逻辑
    /// </summary>
    public partial class UI_01 : Window
    {
        public UI_01()
        {
            InitializeComponent();
            this.DataContext = new MainViewModel();
        }

    }
}
