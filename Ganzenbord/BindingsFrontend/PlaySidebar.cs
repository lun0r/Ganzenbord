using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace Ganzenbord
{
    public class PlaySidebar : INotifyPropertyChanged
    {
        private string _diceRolled;

        private string _videoPath;

        private string _currentTurn;
        private List<Player> _playerList;

        public List<Player> PlayerList
        {
            get { return _playerList; }
            set
            {
                _playerList = value;
                OnPropertyChanged();
            }
        }

        public PlaySidebar()
        {
            PlayerList = new List<Player>();
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

        public string VideoPath
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

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
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
                    VideoPath = message;
                    break;

                case BindedProp.CURRENTTURN:
                    CurrentTurn = message;
                    break;

                default:
                    break;
            }
        }
    }
}