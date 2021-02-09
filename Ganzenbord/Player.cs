using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace Ganzenbord
{
    internal class Player
    {
        public string Name { get; set; }
        public int BoardPosition { get; set; } = 0;
        public Image Avatar { get; set; }

        public Player(string name, Image avatar)
        {
            Name = name;
            Avatar = avatar;
        }

        public int Move(int diceTotal)
        {
            if (BoardPosition + diceTotal >= 63)
            {
                BoardPosition += diceTotal;
            }
            else
            {
                BoardPosition = 63 + (63 - (BoardPosition + diceTotal));
            }
            return BoardPosition;
        }
    }
}