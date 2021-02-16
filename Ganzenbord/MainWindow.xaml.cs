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
        private readonly Game _game;
        private bool gameOver = false;
        private static MainWindow _thisInstance;

        public MainWindow()
        {
            InitializeComponent();
            _boardData = BoardData.GetBoardData();
            this.DataContext = _boardData;
            _game = new Game(BoardGrid);
            _thisInstance = this;
        }

        public static void EnableDiceButton()
        {
            _thisInstance.throwDice.IsEnabled = true;
            _thisInstance.DiceRolled.Clear();
        }

        public static void SetGameOver()
        {
            _thisInstance.gameOver = true;
        }

        private void BtnDice_Click(object sender, RoutedEventArgs e)
        {
            throwDice.IsEnabled = false;
            if (gameOver)
            {
                MessageBox.Show("The game is over, press 'RESTART' for a new game!");
                _thisInstance.throwDice.IsEnabled = false;
            }
            else
            {
                _game.Run();
            }
        }

        private void BtnStartGame_Click(object sender, RoutedEventArgs e)
        {
            if (_game.PlayerList.Count < 2)
            {
                MessageBox.Show("You need at least 2 players");
            }
            else
            {
                SidePanelSetup.Visibility = Visibility.Hidden;
                SidePanelSetupBorder.Visibility = Visibility.Hidden;
                SidePanelPlaying.Visibility = Visibility.Visible;
                SidePanelPlayingBorder.Visibility = Visibility.Visible;
                _boardData.PlaySidebar.UpdateDisplay(_game.PlayerList[0].Name, BindedProp.CURRENTTURN);
                _boardData.PlaySidebar.ImagePath = _game.PlayerList[0].AvatarPath;
            }
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
            _game._playerFactory.AddPlayer(DropDwnPickColor.SelectedIndex, _game.Board);
        }

        private void Select_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (_game != null)
            {
                _game.Board.ChangeTheme(CBSelectTheme.SelectedIndex, _game.PlayerList);
            }
        }
    }
}