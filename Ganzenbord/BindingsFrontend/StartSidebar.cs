using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;

namespace Ganzenbord
{
    public class StartSidebar : INotifyPropertyChanged
    {
        private string _name;
        private ObservableCollection<Pawn> _pawnColor;
        private string _avatarPath;

        public string Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged();
                }
            }
        }

        public ObservableCollection<Pawn> PawnColor
        {
            get { return _pawnColor; }
            set
            {
                if (_pawnColor != value)
                {
                    _pawnColor = value;
                    OnPropertyChanged();
                }
            }
        }

        public string AvatarPath
        {
            get { return _avatarPath; }
            set
            {
                if (_avatarPath != value)
                {
                    _avatarPath = value;
                    OnPropertyChanged();
                }
            }
        }

        public StartSidebar()
        {
            _avatarPath = "/avatar.png";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}