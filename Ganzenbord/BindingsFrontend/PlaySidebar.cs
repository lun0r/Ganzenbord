using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Ganzenbord
{
    internal class PlaySidebar
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

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}