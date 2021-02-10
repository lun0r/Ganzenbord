using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace Ganzenbord
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window

    {
        private readonly Game _game;

        public SetupGame SetGame { get; set; }
        public UserInteractionWindow SetUI { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;

            SetGame = SetupGame.GetSetupWindow();
            SetUI = UserInteractionWindow.GetUserInteractionWindow();

            _game = new Game(this);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _game.TestRun();
        }
    }
}