using System.Windows;

namespace Ganzenbord
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Game _game;

        public MainWindow()
        {
            InitializeComponent();
            _game = new Game(this);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _game.RunGame();
        }
    }
}