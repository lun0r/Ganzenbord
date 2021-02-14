using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Media;

namespace Ganzenbord
{
    public class StartSidebar : INotifyPropertyChanged
    {
        private string _avatarPath;

        private List<Pawn> _pownColor;
        private string _name;

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

        public List<Pawn> PawnColor
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