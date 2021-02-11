using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Ganzenbord
{
    internal class StartSidebar : INotifyPropertyChanged
    {
        private int _propStart;

        public int PropStart
        {
            get { return _propStart; }
            set
            {
                if (_propStart != value)
                {
                    _propStart = value;
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