using PersonalManager.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

namespace PersonalManager.ViewModels
{
    internal class PomodoroViewModel:INotifyPropertyChanged
    {
        //Button Test
        private string _displayText = "Please enter Study time and break length";
        public int _baseStudyTime = 0;
        public string DisplayText
        {
            get { return _displayText; }
            set
            {
                _displayText = value;
                OnPropertyChanged();
            }
        }

        public string StudyTime
        {
            get
            {
                return _baseStudyTime.ToString();
            }
            set
            {
                StudyTime = value;
                OnPropertyChanged();
            }
        }

        //public string BreakTime
        //{
        //    get
        //    {

        //    }
        //    set
        //    {
        //        OnPropertyChanged();
        //    }
        //}

        public ICommand ChangeTextCommand { get; }
        public PomodoroViewModel() 
        {
            ChangeTextCommand = new RelayCommand(DateTimer);
        }
        public void DateTimer()
        {
            int currentTime = 0;
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += (s, e) =>
            {
                currentTime += 1;
                timeFormatString(currentTime);
                 //DisplayText = currentTime.ToString();
            };
            timer.Start();

        }
        public void timeFormatString(int timer)
        {
            int minutes = 0;
            int seconds;
            if (timer % 20 == 0)
            {
                minutes = (timer / 20);
                DisplayText = minutes.ToString();
            }
            

             
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

    }
}
