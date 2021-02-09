using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace Ganzenbord
{
    internal class Game
    {
        public Field[,] board;
        public ObservableCollection<Field> boardList = new ObservableCollection<Field>();

        public Game()
        {
            CreateBoardList();
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

            //add special props - images
            //boardList[6].Background.Source =
            boardList[6].Special = "bounce";

            MakeFieldNumbers();
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
                    /* old way ↓
                     * foreach (var list in boardList)
                     {
                         if (list.X == i && list.Y == b)
                         {
                             list.Number = counter;
                         }
                     }

                     board[i, b].Number = counter;
                    */
                }
                for (int i = b + 1; i < a - 1; i++)
                {
                    boardList.Where(x => x.X == a - 1).Where(x => x.Y == i).FirstOrDefault().Number = counter;
                    counter++;
                    /* old way ↓
                    foreach (var list in boardList)
                    {
                        if (list.X == a - 1 && list.Y == i)
                        {
                            list.Number = counter;
                        }
                    }
                    board[a - 1, i].Number = counter;
                    */
                }
                for (int i = a - 1; i > b; i--)
                {
                    boardList.Where(x => x.X == i).Where(x => x.Y == a - 1).FirstOrDefault().Number = counter;
                    counter++;
                    /* old way ↓
                    foreach (var list in boardList)
                    {
                        if (list.X == i && list.Y == a - 1)
                        {
                            list.Number = counter;
                        }
                    }
                    board[i, a - 1].Number = counter;
                    */
                }
                for (int i = a - 1; i > b; i--)
                {
                    boardList.Where(x => x.X == b).Where(x => x.Y == i).FirstOrDefault().Number = counter;
                    counter++;
                    /* old way ↓
                    foreach (var list in boardList)
                    {
                        if (list.X == b && list.Y == i)
                        {
                            list.Number = counter;
                        }
                    }
                    board[b, i].Number = counter;
                    */
                }
                a--;
                b++;
            }
        }
    }
}