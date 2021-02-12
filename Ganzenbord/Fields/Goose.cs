using System;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Ganzenbord
{
    internal class Goose : Field
    {
        public Image SpecialImage { get; set; }

        public Goose(int number, int x, int y)
            : base(number, x, y)
        {
            SpecialImage = new Image();
            SpecialImage.Source = new BitmapImage(new Uri($"/Images/goose.png", UriKind.Relative));
            Grid.Children.Insert(1, SpecialImage);
        }

        public override int[] ReturnMove(Player player)
        {
            int[] output;
            if (player.IsReversed)
            {
                output = new int[] { player.CurrentBoardPosition - player.Dice1 - player.Dice2, 1 };
            }
            else
            {
                output = new int[] { player.CurrentBoardPosition + player.Dice1 + player.Dice2, 1 };
            }

            return output;
        }
    }
}