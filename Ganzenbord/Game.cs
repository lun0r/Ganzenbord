using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            //MakeFieldNumbers();
        }

        private void CreateBoardList()
        {
            //for (int i = 0; i < 64; i++)
            //{
            //    Field field = new Field();
            //    field.Number = i;

            //    boardList[i] = field;
            //}
            int counter = 0;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Field field = new Field();
                    field.X = i;
                    field.Y = j;
                    field.Number = counter;
                    field.Special = ".";

                    //more props

                    boardList.Add(field);

                    counter++;
                }
            }

            //add special props
            boardList[6].Special = "bounce";

            MakeFieldNumbers();
        }

        private void CreateBoard()
        {
            board = new Field[8, 8];

            int counter = 0;

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Field field = new Field();
                    field.ListIndex = counter;
                    field.X = i;
                    field.Y = j;

                    board[i, j] = field;

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
                    foreach (var list in boardList)
                    {
                        if (list.X == i && list.Y == b)
                        {
                            list.Number = counter;
                        }
                    }

                    //board[i, b].Number = counter;

                    counter++;
                }
                for (int i = b + 1; i < a - 1; i++)
                {
                    foreach (var list in boardList)
                    {
                        if (list.X == a - 1 && list.Y == i)
                        {
                            list.Number = counter;
                        }
                    }
                    //board[a - 1, i].Number = counter;
                    counter++;
                }
                for (int i = a - 1; i > b; i--)
                {
                    foreach (var list in boardList)
                    {
                        if (list.X == i && list.Y == a - 1)
                        {
                            list.Number = counter;
                        }
                    }
                    //board[i, a - 1].Number = counter;
                    counter++;
                }
                for (int i = a - 1; i > b; i--)
                {
                    foreach (var list in boardList)
                    {
                        if (list.X == b && list.Y == i)
                        {
                            list.Number = counter;
                        }
                    }
                    //board[b, i].Number = counter;
                    counter++;
                }
                a--;
                b++;
            }
        }
    }
}