using System;
using System.Collections.Generic;

using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace Ganzenbord
{
    public class Board
    {
        public static Theme ChosenTheme { get; set; } = Theme.CARCASONNE;
        public List<Field> BoardList { get; set; }
        private Grid _grid;

        public Board(Grid boardGrid)
        {
            FillBoardGrid(boardGrid);
            _grid = boardGrid;
        }

        public void ChangeTheme(int index, List<Player> playerList)
        {
            ChosenTheme = (Theme)index;

            FillBoardGrid(_grid);
            foreach (var player in playerList)
            {
                UpdateField(player);
            }
        }

        public List<Field> CreateNewBoard()
        {
            BoardList = new List<Field>();
            SetSpiral();

            return BoardList;
        }

        private void SetSpiral()
        {
            int counter = 0;
            int a = 8;
            int b = 0;

            while (counter < 64)
            {
                for (int i = b; i < a; i++)
                {
                    Field currentField = MakeField(counter, i, b);
                    BoardList.Add(currentField);

                    if (counter == 0)
                    {
                        currentField.Background.Source = SetImage("0.jpg"); ;
                    }
                    else if (i == a - 1)
                    {
                        currentField.Background.Source = SetImage("leftunder.jpg");
                    }
                    else
                    {
                        currentField.Background.Source = SetImage("vertical.jpg");
                    }

                    counter++;
                }
                for (int i = b + 1; i < a - 1; i++)
                {
                    Field currentField = MakeField(counter, a - 1, i);

                    BoardList.Add(currentField);

                    currentField.Background.Source = SetImage("horizontal.jpg");

                    counter++;
                }
                for (int i = a - 1; i > b; i--)
                {
                    Field currentField = MakeField(counter, i, a - 1);

                    BoardList.Add(currentField);
                    if (i == a - 1)
                    {
                        currentField.Background.Source = SetImage("rightunder.jpg");
                    }
                    else
                    {
                        currentField.Background.Source = SetImage("vertical.jpg");
                    }
                    counter++;
                }
                for (int i = a - 1; i > b; i--)
                {
                    Field currentField = MakeField(counter, b, i);

                    BoardList.Add(currentField);

                    if (b + 1 == a - 1)
                    {
                        currentField.Background.Source = SetImage("63.jpg");
                    }
                    else if (i == b + 1)
                    {
                        currentField.Background.Source = SetImage("lefttop.jpg");
                    }
                    else if (i == a - 1)
                    {
                        currentField.Background.Source = SetImage("righttop.jpg");
                    }
                    else
                    {
                        currentField.Background.Source = SetImage("horizontal.jpg");
                    }
                    counter++;
                }
                a--;
                b++;
            }
        }

        private Field MakeField(int counter, int x, int y)
        {
            Field currentField;

            switch (counter)
            {
                case 5:
                case 14:
                case 18:
                case 23:
                case 27:
                case 32:
                case 36:
                case 41:
                case 45:
                case 50:
                case 54:
                case 59:
                    currentField = new Goose(counter, x, y);
                    break;

                case 9:
                    currentField = new Field9(counter, x, y);
                    break;

                case 6:
                    currentField = new Bridge(counter, x, y);
                    break;

                case 19:
                    currentField = new Inn(counter, x, y);
                    break;

                case 31:
                    currentField = new Well(counter, x, y);
                    break;

                case 42:
                    currentField = new Maze(counter, x, y);
                    break;

                case 52:
                    currentField = new Prison(counter, x, y);
                    break;

                case 58:
                    currentField = new Death(counter, x, y);
                    break;

                case 63:
                    currentField = new GameOver(counter, x, y);
                    break;

                default:
                    currentField = new Field(counter, x, y);
                    break;
            }

            return currentField;
        }

        private void FillBoardGrid(Grid boardGrid)
        {
            List<Field> boardList = CreateNewBoard();

            foreach (var field in boardList)
            {
                if (field.Number != 0)
                {
                    field.FieldNumber.Content = field.Number;
                }

                boardGrid.Children.Add(field.Grid);

                Grid.SetRow(field.Grid, field.X);
                Grid.SetColumn(field.Grid, field.Y);
            }
        }

        public static BitmapImage SetImage(string path)
        {
            return new BitmapImage(new Uri($"/{ChosenTheme}/{path}", UriKind.Relative));
        }

        public void UpdateField(Player player)
        {
            switch (player.Pawn)
            {
                case PawnColor.DEFAULT:
                    break;

                case PawnColor.RED:
                    BoardList.FirstOrDefault(x => x.Number == player.OldBoardPosition).Red.Visibility = Visibility.Collapsed;
                    BoardList.FirstOrDefault(x => x.Number == player.CurrentBoardPosition).Red.Visibility = Visibility.Visible;
                    break;

                case PawnColor.GREEN:
                    BoardList.FirstOrDefault(x => x.Number == player.OldBoardPosition).Green.Visibility = Visibility.Collapsed;
                    BoardList.FirstOrDefault(x => x.Number == player.CurrentBoardPosition).Green.Visibility = Visibility.Visible;
                    break;

                case PawnColor.BLUE:
                    BoardList.FirstOrDefault(x => x.Number == player.OldBoardPosition).Blue.Visibility = Visibility.Collapsed;
                    BoardList.FirstOrDefault(x => x.Number == player.CurrentBoardPosition).Blue.Visibility = Visibility.Visible;
                    break;

                case PawnColor.PURPLE:
                    BoardList.FirstOrDefault(x => x.Number == player.OldBoardPosition).Purple.Visibility = Visibility.Collapsed;
                    BoardList.FirstOrDefault(x => x.Number == player.CurrentBoardPosition).Purple.Visibility = Visibility.Visible;
                    break;

                case PawnColor.ORANGE:
                    BoardList.FirstOrDefault(x => x.Number == player.OldBoardPosition).Orange.Visibility = Visibility.Collapsed;
                    BoardList.FirstOrDefault(x => x.Number == player.CurrentBoardPosition).Orange.Visibility = Visibility.Visible;
                    break;

                case PawnColor.YELLOW:
                    BoardList.FirstOrDefault(x => x.Number == player.OldBoardPosition).Yellow.Visibility = Visibility.Collapsed;
                    BoardList.FirstOrDefault(x => x.Number == player.CurrentBoardPosition).Yellow.Visibility = Visibility.Visible;
                    break;

                default:
                    break;
            }
        }
    }
}