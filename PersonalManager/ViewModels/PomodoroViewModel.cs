using PersonalManager.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

namespace PersonalManager.ViewModels
{
    internal class PomodoroViewModel:INotifyPropertyChanged
    {
        //Button Test
        private string _displayText = "Please enter Study time and break length";
        public string _baseStudyTime = "0";
        DispatcherTimer timer = new DispatcherTimer();
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
                return this._baseStudyTime;
            }
            set
            {
                if (!string.Equals(this._baseStudyTime, value))
                {
                    this._baseStudyTime = value;
                    OnPropertyChanged();
                }
                
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
            ChangeTextCommand = new RelayCommand(timeFormatString);
           // ChangeTextCommand = new RelayCommand(DateTimer);
        }
        public void DateTimer(int hrs, int mins)
        {
            int secondInterval = 0;
            int minuteInterval = 0;
            int hours = hrs;
            int seconds = 0;
            int minutes = mins;
            bool isFinished = false;

            if (hours == 0 && minutes == 0 || isFinished == true)
            {
                DisplayText = "Timer Finished";
                timer.Stop();
            }
            if (hours != 0 || minutes != 0 && isFinished == false)
            {
                timer.Interval = TimeSpan.FromSeconds(1);
                timer.Tick += (s, e) =>
                {
                
 
 
                    if (minutes > 0)
                    {
                        secondInterval += 1;
                        
                        if (secondInterval == 60)
                        {
                            minutes -= 1;
                            secondInterval = 0;
                        }
                    }
 
                    if (hours > 0)
                    {
                        minuteInterval += 1;
                        if (minuteInterval == 60)
                        {
                            hours -= 1;
                            minuteInterval = 0;
                        }
                    }
                    
                    //Implement Break and Timer Restart

 
                     DisplayText = $"{secondInterval.ToString()} : {minuteInterval.ToString()}";
                    //DisplayText = $"{hours.ToString()} : {minutes.ToString()}";

                    if (secondInterval == 0 && minuteInterval == 0)
                    {
                        DisplayText = "Timer Finished";
                        isFinished = true;
                    }
                 };
                timer.Start();
            }
           

        }
 
        public void timeFormatString()
        {
            if (this._baseStudyTime == null)
            {
                //Stop from moving forward
            }
            int time = Int32.Parse(this._baseStudyTime);
            int hours = 0;
            int minutes = 0;
            int seconds;

            if (time % 60 == 0)
            {
                hours = time / 60;

            }
            if (time % 60 != 0)
            {
                hours = time / 60;
                minutes = time - (hours * 60);
            }
          DateTimer(hours, minutes);
         // DisplayText = $"{ hours.ToString()} : {minutes.ToString()}";
            //Study Time > Hours, Minutes, Seconds
            //Break Time > If Any countdown until then



            //if (timer % 60 == 0)
            //{
            //    minutes = (timer / 60);
            //    DisplayText = minutes.ToString();
            //}
            

             
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

    }
}
