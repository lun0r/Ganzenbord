using System;
using System.Collections.Generic;
using System.Text;

namespace Ganzenbord
{
    class Field9 : Goose
    {
        public Field9(int number, int x, int y)
            :base(number, x, y)
        {

        }

        public override int ReturnMove(Player player)
        {
            //klopt nog niet: 

            if (player.OldBoardPosition == 0 && player.NewBoardPosition == 0)
            {
                if (player.Dice1 == 5 || player.Dice1 == 4)
                {
                    UpdateBoardPosition(player);
                    return 26;
                }
                else if (player.Dice1 == 6 || player.Dice1 == 3)
                {
                    UpdateBoardPosition(player);
                    return 53;
                }
                
            }
            return base.ReturnMove(player);
        }

        public override void UpdateBoardPosition(Player player)
        {
            player.OldBoardPosition = player.NewBoardPosition;
            player.NewBoardPosition += player.Dice1 + player.Dice2;
        }
    }
}
