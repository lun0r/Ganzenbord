using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Ganzenbord
{
    public class Player
    {
        public string Name { get; set; }
        public int NewBoardPosition { get; set; } = 0;
        public int OldBoardPosition { get; set; } = 0;
        public Image Avatar { get; set; }
        public BitmapImage Pion { get; set; }
        public int Dice1 { get; set; }
        public int Dice2 { get; set; }

        public Player(string name, Image avatar, BitmapImage pion)
        {
            Name = name;
            Avatar = avatar;
            Pion = pion;
        }

        public void Move(int newFieldPos)
        {
            OldBoardPosition = NewBoardPosition;

            NewBoardPosition = newFieldPos;
        }
    }
}