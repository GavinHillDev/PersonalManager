using PersonalManager.PageClasses;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace PersonalManager.Windows
{
    /// <summary>
    /// Interaction logic for Test.xaml
    /// </summary>
    public partial class Test : Page
    {
        public Test()
        {
            InitializeComponent();
            object block = parentGrid.FindName("TextBlockOne");
            //textbox = block;
            TextBox test = block as TextBox;
            HubWindow.returnDate(test);
            DateTimer(test);

        }

        public static void DateTimer(TextBox test)
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += (s, e) =>
            {
                HubWindow.returnDate(test);
            };
            timer.Start();

        }
        private void MainCalendarDateSelected(object sender, SelectionChangedEventArgs e)
        {
            Mouse.Capture(null);
            var calendar = sender as Calendar;
            //if (calendar.SelectedDate.HasValue)
            //{
            //    CalendarPa window = new CalendarPage();
            //    window.Owner = this;
            //    bool? result = window.ShowDialog();
            //    //object block = parentGrid.FindName("ListBlock");
            //    //TextBlock test = block as TextBlock;
            //    //test.Text = calendar.SelectedDate.Value.ToString();

            //}
           
        }
    }
    
}
