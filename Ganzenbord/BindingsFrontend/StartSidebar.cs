using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Media;

namespace Ganzenbord
{
    internal class StartSidebar : INotifyPropertyChanged
    {
        private string _avatarPath;
        private string _name;
        private ObservableCollection<Pawn> _pownColor;

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
            get { return _pownColor; }
            set
            {
                if (_pownColor != value)
                {
                    _pownColor = value;
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

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}