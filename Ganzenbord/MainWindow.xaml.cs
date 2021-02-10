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

        private BoardData boardData;

        //nieuw object maken ipv alles mee te geven aan datacontext
        public MainWindow()
        {
            InitializeComponent();
            boardData = new BoardData();
            DataContext = boardData;

            _game = new Game(this);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _game.TestRun();
        }
    }
}