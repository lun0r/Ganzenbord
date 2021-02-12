﻿using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace Ganzenbord
{
    internal class PlaySidebar : INotifyPropertyChanged
    {
        private string _diceRolled;

        private string _videoPath;

        private string _currentTurn;

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

        public void UpdateDisplay(string message, BINDEDPROP propToBindTo)
        {
            switch (propToBindTo)
            {
                case BINDEDPROP.Default:
                    MessageBox.Show("Error");
                    break;

                case BINDEDPROP.DiceRolled:
                    DiceRolled = message;
                    break;

                case BINDEDPROP.VideoPath:
                    VideoPath = message;
                    break;

                case BINDEDPROP.CurrentTurn:
                    CurrentTurn = message;
                    break;

                default:
                    break;
            }
        }
    }
}