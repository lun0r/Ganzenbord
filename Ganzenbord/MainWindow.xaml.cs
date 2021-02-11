using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Ganzenbord
{
    public partial class MainWindow : Window

    {
        private readonly Game _game;

        private bool test = true;
        private BoardData boardData;

        public MainWindow()
        {
            InitializeComponent();
            boardData = new BoardData();
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _game.TestRun();

            if (test)
            {
                boardData.PlaySidebar.VideoPath = "../../../Images/test.mp4";
            }
            else
            {
                boardData.PlaySidebar.VideoPath = "../../../Images/0.jpg";
            }
            test = !test;
        }

        private void ButtonDice_Click(object sender, RoutedEventArgs e)
        {
            mePlayer.Play();

            TimeSpan test = new TimeSpan(0, 0, 3);

            if (mePlayer.Position > test)
            {
                mePlayer.Stop();
            }
        }
    }
}