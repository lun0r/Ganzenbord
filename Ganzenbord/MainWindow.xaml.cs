using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Ganzenbord
{
    public partial class MainWindow : Window

    {
        private readonly Game _game;

        private BoardData boardData;

        public MainWindow()
        {
            InitializeComponent();
            boardData = BoardData.GetBoardData();
            DataContext = boardData;
            _game = new Game();
            FillBoardGrid();
            //WrapPanel test = new WrapPanel
            //{
            //    HorizontalAlignment = HorizontalAlignment.Center;
            //VerticalAlignment = VerticalAlignment.Center;
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
            _game.Run();
        }

        private void StartGameClick(object sender, RoutedEventArgs e)
        {
            SidePanelSetup.Visibility = Visibility.Hidden;
            SidePanelPlaying.Visibility = Visibility.Visible;
            _game.StartGame();
        }
    }
}