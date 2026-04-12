using PersonalManager.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PersonalManager.ViewModels
{
    internal class PomodoroViewModel:INotifyPropertyChanged
    {
        //Button Test
        private string _displayText = "Before Change";

        public string DisplayText
        {
            get { return _displayText; }
            set
            {
                _displayText = value;
                OnPropertyChanged();
            }
        }
        public ICommand ChangeTextCommand { get; }
        public PomodoroViewModel() 
        {
            ChangeTextCommand = new RelayCommand(ChangeText);
        }
        public void ChangeText()
        {
            DisplayText = "Updated Text";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

    }
}
