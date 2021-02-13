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
        private readonly Game _game;

        private readonly BoardData boardData;
        private bool gameOver = false;

        public MainWindow()
        {
            InitializeComponent();
            boardData = BoardData.GetBoardData();
            DataContext = boardData;
            _game = new Game();

            FillBoardGrid();
            _game.StartGame();
            //DropDwnPickColor.ItemsSource = _game.PlayerList;
            DropDwnPickColor.ItemsSource = typeof(Colors).GetProperties();
        }

        private void FillBoardGrid()
        {
            List<Field> boardList = _game._board.CreateNewBoard();

            foreach (var field in boardList)
            {
                if (field.Number != 0)
                {
                    field.FieldNumber.Content = field.Number;
                }

                BoardGrid.Children.Add(field.Grid);

                Grid.SetRow(field.Grid, field.X);
                Grid.SetColumn(field.Grid, field.Y);
            }
        }

        private void ButtonDice_Click(object sender, RoutedEventArgs e)
        {
            if (gameOver)
            {
                throwDice.IsEnabled = false;
                boardData.PlaySidebar.DiceRolled = "Won!!!";

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
            _game.StartGame();
            boardData.PlaySidebar.UpdateDisplay(_game.PlayerList[0].Name, BindedProp.CURRENTTURN);
        }

        private void BtnQuit_Click(object sender, RoutedEventArgs e)
        {
            //System.Windows.Application.Current.Shutdown();

            //OpenFileDialog openFileDialog = new OpenFileDialog();
            //if (openFileDialog.ShowDialog() == true)
            //    boardData.PlaySidebar.UpdateDisplay(File.ReadAllText(openFileDialog.FileName), BindedProp.CURRENTTURN);

            var dlg = new OpenFileDialog();

            dlg.DefaultExt = ".png";
            dlg.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";

            // Display OpenFileDialog by calling ShowDialog method
            Nullable<bool> result = dlg.ShowDialog();

            // Get the selected file name and display in a TextBox
            if (result == true)
            {
                // Open document
                string filename = dlg.FileName;
                //boardData.PlaySidebar.UpdateDisplay(filename, BindedProp.CURRENTTURN);
                boardData.PlaySidebar.VideoPath = filename;
                //testimg.Source = new BitmapImage(new Uri(filename));
            }
        }
    }
}