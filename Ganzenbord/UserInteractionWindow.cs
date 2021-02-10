using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Ganzenbord
{
    public class UserInteractionWindow : INotifyPropertyChanged
    {
        private int _boundNumber;

        public int BoundNumber
        {
            get { return _boundNumber; }
            set
            {
                if (_boundNumber != value)
                {
                    _boundNumber = value;
                    OnPropertyChanged();
                }
            }
        }

        static private UserInteractionWindow userInteractionWindow;

        public UserInteractionWindow()
        {
            BoundNumber = 50;
        }

        static public UserInteractionWindow GetUserInteractionWindow()
        {
            if (userInteractionWindow == null)
            {
                userInteractionWindow = new UserInteractionWindow();
            }
            return userInteractionWindow;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}