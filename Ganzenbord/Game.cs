using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace Ganzenbord
{
    internal class Game
    {
        public Field[,] board;

        public Game()
        {
            CreateBoard();
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
                    board[i, b].Number = counter;
                    counter++;
                }
                for (int i = b + 1; i < a - 1; i++)
                {
                    board[a - 1, i].Number = counter;
                    counter++;
                }
                for (int i = a - 1; i > b; i--)
                {
                    board[i, a - 1].Number = counter;
                    counter++;
                }
                for (int i = a - 1; i > b; i--)
                {
                    board[b, i].Number = counter;
                    counter++;
                }
                a--;
                b++;
            }
        }
    }
}