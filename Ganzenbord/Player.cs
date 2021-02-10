using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Ganzenbord
{
    public class Player
    {
        private Random rnd;
        public string Name { get; set; }
        public int NewBoardPosition { get; set; } = 0;
        public int OldBoardPosition { get; set; } = 0;
        public Image Avatar { get; set; }
        public BitmapImage Pion { get; set; }

        public Player(string name, Image avatar, BitmapImage pion)
        {
            rnd = new Random();
            Name = name;
            Avatar = avatar;
            Pion = pion;
        }

        public int Move(int diceTotal)
        {
            OldBoardPosition = NewBoardPosition;

            if (NewBoardPosition + diceTotal <= 63)
            {
                NewBoardPosition += diceTotal;
            }
            else
            {
                NewBoardPosition = 63 + (63 - (NewBoardPosition + diceTotal));
            }
            return NewBoardPosition;
        }

        public int RollDice()
        {
            return rnd.Next(1, 7);
        }
    }
}