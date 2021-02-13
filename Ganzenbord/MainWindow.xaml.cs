using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

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
            System.Windows.Application.Current.Shutdown();
        }
    }
}