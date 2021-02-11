using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Ganzenbord
{
    public class Player
    {
        readonly private Dice dice;
        public string Name { get; set; }
        public int NewBoardPosition { get; set; } = 0;
        public int OldBoardPosition { get; set; } = 0;
        public Image Avatar { get; set; }
        public BitmapImage Pion { get; set; }

        public Player(string name, Image avatar, BitmapImage pion)
        {
            Name = name;
            Avatar = avatar;
            Pion = pion;

            dice = new Dice();
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
                NewBoardPosition = 126 - (NewBoardPosition + diceTotal);
            }
            return NewBoardPosition;
        }

        public int RollDice()
        {
            return dice.Roll();
        }
    }
}