using System;
using System.Collections.Generic;
using System.Text;

namespace Ganzenbord
{
    public class Field9 : Goose
    {
        private int ReturnValue { get; set; }
        public Player CurrentPlayer { get; set; }

        public Field9(int number, int x, int y)
            : base(number, x, y)
        {
            ReturnValue = 0;
        }

        public override int ReturnMove(Player player)
        {
            if (!player.HasDied)
            {
                CurrentPlayer = player;
                if (player.Dice1 == 5 || player.Dice1 == 4 && player.Dice2 == 5 || player.Dice2 == 4)
                {
                    ReturnValue = 26;
                    return 26;
                }
                else if (player.Dice1 == 6 || player.Dice1 == 3 && player.Dice2 == 6 || player.Dice2 == 3)
                {
                    ReturnValue = 53;
                    return 53;
                }
                ReturnValue = 0;
            }

            return base.ReturnMove(player);
        }

        public override string ToString()
        {
            if (CurrentPlayer.Dice1 + CurrentPlayer.Dice2 == 9)
            {
                if (CurrentPlayer.HasDied)
                {
                    return $"{CurrentPlayer.Name} died, revived and threw nine. Lucky!";
                }

                return $"{CurrentPlayer.Name} rolled \"9\" on the first move, you move to {ReturnValue}.";
            }
            return base.ToString();
        }
    }
}