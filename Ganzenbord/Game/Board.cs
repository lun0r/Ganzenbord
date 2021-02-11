using System;
using System.Collections.Generic;

using System.Linq;

using System.Windows.Media.Imaging;

namespace Ganzenbord
{
    public class Board
    {
        public List<Field> BoardList { get; set; }

        public List<Field> CreateNewBoard()
        {
            BoardList = new List<Field>();
            SetSpiral();
            SetSpecials();
            //FillBoardGrid();

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
                    //Field currentField = new Field(counter, i, b);
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

                    //Field currentField = new Field(counter, a - 1, i);

                    BoardList.Add(currentField);

                    currentField.Background.Source = SetImage("horizontal.jpg");

                    counter++;
                }
                for (int i = a - 1; i > b; i--)
                {
                    Field currentField = MakeField(counter, i, a - 1);

                    //Field currentField = new Field(counter, i, a - 1);

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

                    //Field currentField = new Field(counter, b, i);
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

        public Field MakeField(int counter, int x, int y)
        {
            Field currentField = null;

            switch (counter)
            {
                case 5:
                case 9:
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

                default:
                    currentField = new Field(counter, x, y);
                    break;
            }

            return currentField;
        }

        private BitmapImage SetImage(string path)
        {
            return new BitmapImage(new Uri($"/Images/{path}", UriKind.Relative));
        }

        private void SetSpecials()
        {
            foreach (Field field in BoardList)
            {
            }
        }

        public void UpdateField(Player player)
        {
            BoardList.FirstOrDefault(x => x.Number == player.OldBoardPosition).GamePiece.Source = null;
            BoardList.FirstOrDefault(x => x.Number == player.NewBoardPosition).GamePiece.Source = player.Pion;
        }
    }
}