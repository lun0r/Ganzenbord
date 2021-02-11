using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Ganzenbord
{
    public class Player
    {
        public string Name { get; set; }
        public int CurrentBoardPosition { get; set; }
        public int OldBoardPosition { get; set; }
        public Image Avatar { get; set; }
        public BitmapImage Pion { get; set; }
        public int Dice1 { get; set; }
        public int Dice2 { get; set; }
        public bool HasDied { get; set; } = false;
        public bool IsReversed { get; set; } = false;
        public int SkipTurn { get; set; }

        public Player(string name, Image avatar, BitmapImage pion)
        {
            Name = name;
            Avatar = avatar;
            Pion = pion;
        }

        public void Move(int newFieldPos)
        {
            if (newFieldPos > 63)
            {
                newFieldPos = 63 - (newFieldPos - 63);
            }

            OldBoardPosition = CurrentBoardPosition;

            CurrentBoardPosition = newFieldPos;
        }
    }
}