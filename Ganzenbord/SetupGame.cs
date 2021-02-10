using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Ganzenbord
{
    public class SetupGame : INotifyPropertyChanged
    {
        private int _prop;
        static private SetupGame setupGameWindow;

        public int Prop
        {
            get { return _prop; }
            set
            {
                if (_prop != value)
                {
                    _prop = value;
                    OnPropertyChanged();
                }
            }
        }

        public SetupGame()
        {
            Prop = 30;
        }

        static public SetupGame GetSetupWindow()
        {
            if (setupGameWindow == null)
            {
                setupGameWindow = new SetupGame();
            }
            return setupGameWindow;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}