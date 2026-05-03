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
        private string _displayText = "Please enter Study time and break length";
        public string _baseStudyTime = "0";
        public string _baseBreakTime = "1";
        public string _baseRepeatCycle = "0";
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
        public string RepeatCycle
        {
            get
            {
                return this._baseRepeatCycle;
            }
            set
            {
                if (!string.Equals(this._baseRepeatCycle, value))
                {
                    this._baseRepeatCycle = value;
                    OnPropertyChanged();
                }

            }
        }
         
        public string BreakTime
        {
            get
            {
                return this._baseBreakTime;
            }
            set
            {
                if (!string.Equals(this._baseBreakTime, value))
                {
                    this._baseBreakTime = value;
                    OnPropertyChanged();
                }

            }
        }

        public ICommand ChangeTextCommand { get; }
        public PomodoroViewModel() 
        {
            ChangeTextCommand = new RelayCommand(timeFormatString);
        }
        public void DateTimer(int hrs, int mins)
        {
            int secondInterval = 0;
            int minuteInterval = 0;
            int hours = hrs;
            int seconds = 60;
            int minutes = mins;
            int displayMinute = mins;
            bool isFinished = false;
            int breakTime = Int32.Parse(this._baseBreakTime);
            int repeatCycle = Int32.Parse(this._baseRepeatCycle);

            if (repeatCycle == 0 || isFinished == true)
            {
                DisplayText = "Timer Finished after break";
                timer.Stop();
            }
            if (hours != 0 || minutes != 0 && repeatCycle > 0 && isFinished == false)
            {
                timer.Interval = TimeSpan.FromSeconds(1);
                timer.Tick += (s, e) =>
                {
                
 
 
                    if (minutes > 0)
                    {
                        if (secondInterval == 0)
                        {
                            displayMinute -= 1;
                        }
                        secondInterval += 1;
                        seconds -= 1;
 
                        if (secondInterval == 60)
                        {
                            minutes -= 1;
                            secondInterval = 0;
                            seconds = 60;
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

                    
                     DisplayText = $" MB {hours.ToString()} : {displayMinute.ToString()} : {seconds.ToString()}";
                    

                    if (hours == 0 && minutes == 0 && repeatCycle > 0)
                    {
                        isFinished = true;
                        timer.Stop();
                        breakTimer();
                        
                    }
                    if (repeatCycle == 0 && hours == 0 && minutes == 0)
                    {
                        DisplayText = "Timer Finished";
                        timer.Stop();
                    }
                };
                timer.Start();
            }
           

        }
        public void breakTimer()
        {
            int breaklength = Int32.Parse(this._baseBreakTime);
            int breakTimer = 0;
            int seconds  = 60;
            int displayMinute = breaklength;
            System.Diagnostics.Debug.WriteLine("Break");
            DispatcherTimer break_timer = new DispatcherTimer();
            break_timer.Interval = TimeSpan.FromSeconds(1);
            break_timer.Tick += (s, e) =>
            {
               System.Diagnostics.Debug.WriteLine("Break In Timer");
               if (breaklength > 0)
                    {
                    if (breakTimer == 0)
                    {
                        displayMinute -= 1;
                    }
                    breakTimer += 1;
                        seconds -= 1;
                        if (breakTimer == 60)
                        {
                            breaklength -= 1;
                            breakTimer = 0;
                            seconds = 60;
                        }
                    }
                DisplayText = $"{displayMinute} : {seconds}";
               if (breaklength == 0) 
               {
                   
                   break_timer.Stop();
                   RepeatChecker();
                   timeFormatString();
               }
           };
           break_timer.Start();

        }
        public void RepeatChecker()
        {
            int _rCycle = Int32.Parse(this._baseRepeatCycle);
            if (_rCycle > 0)
            {
                _rCycle -= 1;
                this._baseRepeatCycle = _rCycle.ToString();
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
         

             
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

    }
}
