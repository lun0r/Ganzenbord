using System;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Ganzenbord
{
    internal class YellowWon : Field
    {
        public Image SpecialImage { get; set; }

        public YellowWon(int number, int x, int y)
            : base(number, x, y)
        {
        }

        public override int[] ReturnMove(Player player)
        {
            int[] output = new int[] { 0, 0 };
            return output;
        }

        public override void UpdateBoardPosition(Player player)
        {
            throw new System.NotImplementedException();
        }
    }
}