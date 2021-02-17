using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

namespace Ganzenbord
{
    public class PlaySidebar : INotifyPropertyChanged
    {
        private string _diceRolled;
        private string _videoPath;
        private string _currentTurn;
        private string _fieldMessage;

        private ObservableCollection<string> _listOfMessages;

        public ObservableCollection<string> ListOfMessages
        {
            get { return _listOfMessages; }
            set
            {
                if (_listOfMessages != value)
                {
                    _listOfMessages = value;
                    OnPropertyChanged();
                }
            }
        }

        public string DiceRolled
        {
            get { return _diceRolled; }
            set
            {
                if (_diceRolled != value)
                {
                    _diceRolled = value;
                    OnPropertyChanged();
                }
            }
        }

        public string ImagePath
        {
            get { return _videoPath; }
            set
            {
                if (_videoPath != value)
                {
                    _videoPath = value;
                    OnPropertyChanged();
                }
            }
        }

        public string CurrentTurn
        {
            get { return _currentTurn; }
            set
            {
                if (_currentTurn != value)
                {
                    _currentTurn = value;

                    OnPropertyChanged();
                }
            }
        }

        public string FieldMessage
        {
            get { return _fieldMessage; }
            set
            {
                if (_fieldMessage != null)
                {
                    ListOfMessages.Insert(0, _fieldMessage);
                }

                _fieldMessage = value;

                OnPropertyChanged();
            }
        }

        public PlaySidebar()
        {
            ListOfMessages = new ObservableCollection<string>();

            string startMessage = $"Roll the dice to start the game!";
            FieldMessage = startMessage;
            ImagePath = "/avatar.png";
        }

        public void UpdateDisplay(string message, BindedProp propToBindTo)
        {
            switch (propToBindTo)
            {
                case BindedProp.DEFAULT:
                    MessageBox.Show("Error");
                    break;

                case BindedProp.DICEROLLED:
                    DiceRolled = message;
                    break;

                case BindedProp.VIDEOPATH:
                    ImagePath = message;
                    break;

                case BindedProp.CURRENTTURN:
                    CurrentTurn = message;
                    break;

                case BindedProp.FIELDMESSAGE:
                    FieldMessage = message;

                    break;

                default:
                    break;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}