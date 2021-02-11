using System;
using System.Collections.Generic;
using System.Text;

namespace Ganzenbord
{
    internal class Field9 : Goose
    {
        public Field9(int number, int x, int y)
            : base(number, x, y)
        {
        }

        public override int[] ReturnMove(Player player)
        {
            if (!player.HasDied)
            {
                if (player.Dice1 == 5 || player.Dice1 == 4 && player.Dice2 == 5 || player.Dice2 == 4)
                {
                    return new int[] { 26, 1 };
                }
                else if (player.Dice1 == 6 || player.Dice1 == 3 && player.Dice2 == 6 || player.Dice2 == 3)
                {
                    return new int[] { 53, 1 };
                }
            }
            return base.ReturnMove(player);
        }
    }
}