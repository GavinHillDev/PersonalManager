using PersonalManager.PageClasses;
using System.Runtime.CompilerServices;
using System.Text;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using static System.Net.Mime.MediaTypeNames;

using PersonalManager.Pages;
namespace PersonalManager
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
           MainFrame.Navigate(new HubPage());
        }

        private void GoHome(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new HubPage());
        }
        private void PomodoroPage(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new PomodoroPage());
        }

        //private void GoHub(object sender, RoutedEventArgs e)
        //{
        //    //MainFrame.Navigate(new HubPage());
        //}

    }
}
