using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Ganzenbord
{
    public partial class MainWindow : Window

    {
        private readonly BoardData _boardData;
        private Game _game;
        private bool gameOver = false;
        // private Pawn _pawn;

        public MainWindow()
        {
            InitializeComponent();
            _boardData = BoardData.GetBoardData();
            DataContext = _boardData;
            _game = new Game(BoardGrid);
            //_pawn = new Pawn();
            //_pawn.MakeSixPawns();

            //_boardData.StartSidebar.PawnColor = _pawn.GetPawns();

            //DropDwnPickColor.ItemsSource = _game.PlayerList;
            //DropDwnPickColor.ItemsSource = typeof(Colors).GetProperties();
        }

        private void ButtonDice_Click(object sender, RoutedEventArgs e)
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

        private void StartGameClick(object sender, RoutedEventArgs e)
        {
            SidePanelSetup.Visibility = Visibility.Hidden;
            SidePanelPlaying.Visibility = Visibility.Visible;
            _boardData.PlaySidebar.UpdateDisplay(_game.PlayerList[0].Name, BindedProp.CURRENTTURN);
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
            int index = DropDwnPickColor.SelectedIndex;
            _game._playerFactory.AddPlayer(index, _game.Board);
        }
    }
}