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
            CreateBoardList();
            SetSpiral();
            SetCorners();
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
                    Field currentField = new Field(counter, i, b);

                    BoardList.Add(currentField);

                    currentField.Background.Source = new BitmapImage(new Uri("/Images/vertical.jpg", UriKind.Relative));

                    counter++;
                }
                for (int i = b + 1; i < a - 1; i++)
                {
                    Field currentField = new Field(counter, a - 1, i);

                    BoardList.Add(currentField);
                    currentField.Background.Source = new BitmapImage(new Uri("/Images/horizontal.jpg", UriKind.Relative));

                    counter++;
                }
                for (int i = a - 1; i > b; i--)
                {
                    Field currentField = new Field(counter, i, a - 1);

                    BoardList.Add(currentField);
                    currentField.Background.Source = new BitmapImage(new Uri("/Images/vertical.jpg", UriKind.Relative));

                    counter++;
                }
                for (int i = a - 1; i > b; i--)
                {
                    Field currentField = new Field(counter, b, i);
                    BoardList.Add(currentField);

                    currentField.Background.Source = new BitmapImage(new Uri("/Images/horizontal.jpg", UriKind.Relative));

                    counter++;
                }
                a--;
                b++;
            }

            int aaa = 0;
        }

        private void SetCorners()
        {
            foreach (Field field in BoardList)
            {
                switch (field.Number)
                {
                    case 0:
                        field.Background.Source = new BitmapImage(new Uri("/Images/0.jpg", UriKind.Relative));
                        break;

                    case 63:
                        field.Background.Source = new BitmapImage(new Uri("/Images/63.jpg", UriKind.Relative));
                        break;

                    case 7:
                    case 33:
                    case 51:
                    case 61:
                        field.Background.Source = new BitmapImage(new Uri("/Images/leftunder.jpg", UriKind.Relative));
                        break;

                    case 14:
                    case 38:
                    case 54:
                    case 62:
                        field.Background.Source = new BitmapImage(new Uri("/Images/rightunder.jpg", UriKind.Relative));
                        break;

                    case 21:
                    case 43:
                    case 57:
                        field.Background.Source = new BitmapImage(new Uri("/Images/righttop.jpg", UriKind.Relative));
                        break;

                    case 27:
                    case 47:
                    case 59:
                        field.Background.Source = new BitmapImage(new Uri("/Images/lefttop.jpg", UriKind.Relative));
                        break;
                }
            }
        }

        private void SetSpecials()
        {
            foreach (Field field in BoardList)
            {
                switch (field.Number)
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

                        //field.SpecialImage.Source = new BitmapImage(new Uri("/Images/goose.png", UriKind.Relative));
                        //field.Special = SpecialFields.Goose;
                        break;
                }
            }
        }

        public void UpdateField(Player player)
        {
            BoardList.FirstOrDefault(x => x.Number == player.OldBoardPosition).GamePiece.Source = null;
            BoardList.FirstOrDefault(x => x.Number == player.NewBoardPosition).GamePiece.Source = player.Pion;
        }
    }
}