using PersonalManager.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace PersonalManager.ViewModels
{
    internal class HubViewModel : INotifyPropertyChanged
    {
        public string _displayText = "Initial Text";
        public string DisplayText
        {
            get => _displayText;
            set
            {
                _displayText = value;
                OnPropertyChanged();
            }
        }
        public ICommand ChangeTextCommand { get; }

        public HubViewModel() {
            ChangeTextCommand = new RelayCommand(ChangeText);
        }
        public void ChangeText()
        {
            DisplayText = "Changed Text";
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
