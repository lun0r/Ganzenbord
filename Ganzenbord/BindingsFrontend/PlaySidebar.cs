using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Ganzenbord
{
    internal class PlaySidebar : INotifyPropertyChanged
    {
        private int _propPlay;

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

        private string _videoPath;

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

        public PlaySidebar()
        {
            //VideoPath = @"C:\Users\1\Desktop\test.mp4";
            VideoPath = "../../../Images/0.jpg";
            //VideoPath = "../../../Images/test.mp4";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}