using Microsoft.Win32;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Linq;

namespace Ganzenbord
{
    public partial class MainWindow : Window

    {
        private readonly BoardData _boardData;
        private Game _game;
        private bool gameOver = false;

        public MainWindow()
        {
            InitializeComponent();
            _boardData = BoardData.GetBoardData();
            DataContext = _boardData;
            _game = new Game(BoardGrid);
            PlayersListView.ItemsSource = _game.PlayerList;
        }

        private void BtnDice_Click(object sender, RoutedEventArgs e)
        {
            if (gameOver)
            {
                throwDice.IsEnabled = false;
                _boardData.PlaySidebar.DiceRolled = "Won!!!";

                gameOver = false;
            }
            else
            {
                gameOver = _game.Run();
            }
        }

        private void BtnStartGame_Click(object sender, RoutedEventArgs e)
        {
            _boardData.PlaySidebar.PlayerList = _game.PlayerList;
            SidePanelSetup.Visibility = Visibility.Hidden;
            SidePanelPlaying.Visibility = Visibility.Visible;
            _boardData.PlaySidebar.UpdateDisplay(_game.PlayerList[0].Name, BindedProp.CURRENTTURN);
            _boardData.PlaySidebar.VideoPath = _game.PlayerList[0].AvatarPath;
        }

        private void BtnQuit_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void BtnSelectAvatar_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new OpenFileDialog();
            bool? result = dlg.ShowDialog();

            if ((bool)result)
            {
                dlg.DefaultExt = ".png";
                dlg.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";
                string filename = dlg.FileName;
                ImgAvatarPrev.Source = new BitmapImage(new Uri(filename));
                _boardData.StartSidebar.AvatarPath = filename;
            }
        }

        private void BtnAddPlayer_Click(object sender, RoutedEventArgs e)
        {
            if (_game.PlayerList.Exists(x => x.Name == _boardData.StartSidebar.Name))
            {
                MessageBox.Show("This name was already picked.");
            }
            else if (_boardData.StartSidebar.Name == null)
            {
                MessageBox.Show("Please enter a name.");
            }
            else
            {
                int index = DropDwnPickColor.SelectedIndex;
                _game._playerFactory.AddPlayer(index, _game.Board);
            }
        }

        private void select_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (CBSelectTheme.SelectedIndex != 0) // TODO remove check on zero
            {
                _game.Board.ChangeTheme(CBSelectTheme.SelectedIndex, _game.PlayerList);
            }
        }
    }
}