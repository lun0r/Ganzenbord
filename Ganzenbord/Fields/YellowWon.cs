using System;
using System.Windows.Controls;
using System.Windows.Media.Imaging;


namespace Ganzenbord
{
    class YellowWon : Field
    {
        public Image SpecialImage { get; set; }

        public YellowWon(int number, int x, int y)
            : base(number, x, y)
        {
            
        }

        public override int ReturnMove(Player player)
        {
            return 0;
        }

        public override void UpdateBoardPosition(Player player)
        {
            throw new System.NotImplementedException();
        }

    }
}
