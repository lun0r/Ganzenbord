using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Ganzenbord
{
    internal class Game
    {
        private readonly ObservableCollection<Field> boardList = new ObservableCollection<Field>();

        private MainWindow _frontend;
        private Dice _dice;

        public Game(MainWindow frontend)
        {
            _frontend = frontend;
            _dice = new Dice();
            SetUpBoard();

            Test();
        }

        private void SetUpBoard()
        {
            CreateBoardList();
            MakeFieldNumbers();
            FillBoardGrid();
            SetBoardImgAndSpecials();
        }

        private void CreateBoardList()
        {
            int counter = 0;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Field field = new Field(counter, i, j);

                    boardList.Add(field);

                    counter++;
                }
            }
        }

        private void MakeFieldNumbers()
        {
            int counter = 0;
            int a = 8;
            int b = 0;

            while (counter < 64)
            {
                for (int i = b; i < a; i++)
                {
                    boardList.Where(x => x.X == i).Where(x => x.Y == b).FirstOrDefault().Number = counter;
                    counter++;
                }
                for (int i = b + 1; i < a - 1; i++)
                {
                    boardList.Where(x => x.X == a - 1).Where(x => x.Y == i).FirstOrDefault().Number = counter;
                    counter++;
                }
                for (int i = a - 1; i > b; i--)
                {
                    boardList.Where(x => x.X == i).Where(x => x.Y == a - 1).FirstOrDefault().Number = counter;
                    counter++;
                }
                for (int i = a - 1; i > b; i--)
                {
                    boardList.Where(x => x.X == b).Where(x => x.Y == i).FirstOrDefault().Number = counter;
                    counter++;
                }
                a--;
                b++;
            }
        }

        private void FillBoardGrid()
        {
            foreach (var field in boardList)
            {
                field.Label1.Content = field.Number;
                field.Label2.Content = field.Special;

                _frontend.BordGrid.Children.Add(field.Grid);

                Grid.SetRow(field.Grid, field.X);
                Grid.SetColumn(field.Grid, field.Y);
            }
        }

        private void SetBoardImgAndSpecials()
        {
            //TODO
            //add special props - images

            boardList[6].Special = "bounce";
        }

        public void RunGame()
        {
            Player player1 = new Player("player1", null);

            int roll1 = player1.RollDice();
            int roll2 = player1.RollDice();

            player1.Pion = new BitmapImage(new Uri("/Images/playerBlue.png", UriKind.Relative));

            //Test();
            //Field field = boardList[1];
            //Test2(player1);

            UpdateField(player1);
        }

        private void Test()
        {
            _frontend.textboxje.Text = "jawadedada";
            boardList.Where(x => x.Number == 8).FirstOrDefault().Label2.Content = "test";
            boardList.Where(x => x.Number == 63).FirstOrDefault().Background.Source = new BitmapImage(new Uri("/Images/63.jpg", UriKind.Relative));
            boardList.Where(x => x.Number == 62).FirstOrDefault().Background.Source = new BitmapImage(new Uri("/Images/rightunder.jpg", UriKind.Relative));
            BitmapImage test = new BitmapImage(new Uri("/Images/playerBlue.png", UriKind.Relative));

            boardList.Where(x => x.Number == 62).FirstOrDefault().GamePiece.Source = test;
            boardList.Where(x => x.Number == 63).FirstOrDefault().GamePiece.Source = test;
        }

        private void UpdateField(Player player)
        {
            //boardList.Where(x => x.Number == 5).FirstOrDefault().Label2.Content = "nr5";

            //boardList.Where(x => x == field).FirstOrDefault().Background.Source = field.Background.Source;

            player.OldBoardPosition = 63;
            player.NewBoardPosition = 53;
            boardList.Where(x => x.Number == player.OldBoardPosition).FirstOrDefault().GamePiece.Source = null;
            boardList.Where(x => x.Number == player.NewBoardPosition).FirstOrDefault().GamePiece.Source = player.Pion;
        }
    }
}