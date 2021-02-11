using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Ganzenbord
{
    internal class PlaySidebar : INotifyPropertyChanged
    {
        private int _propPlay;
        private string _videoPath;

        public int PropPlay
        {
            get { return _propPlay; }
            set
            {
                if (_propPlay != value)
                {
                    _propPlay = value;
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

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}