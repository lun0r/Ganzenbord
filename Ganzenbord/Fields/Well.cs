using System;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Ganzenbord
{
    internal class Well : Field
    {
        public Image SpecialImage { get; set; }
        public Player PlayerInWell { get; set; }

        public Well(int number, int x, int y)
            : base(number, x, y)
        {
            SpecialImage = new Image();
            SpecialImage.Source = new BitmapImage(new Uri($"/Images/well.png", UriKind.Relative));
            Grid.Children.Insert(1, SpecialImage);
        }

        public override int ReturnMove(Player player)
        {
            player.SkipTurn = 9999;

            if (PlayerInWell != null)
            {
                PlayerInWell.SkipTurn = 0;
            }
            PlayerInWell = player;

            return player.CurrentBoardPosition;
        }

        public override string ToString()
        {
            return $"You fell in the well, wait for the next sucker to use as a ladder and escape";
        }
    }
}