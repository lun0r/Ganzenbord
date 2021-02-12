using System;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Ganzenbord
{
    internal class Death : Field
    {
        public Image SpecialImage { get; set; }

        public Death(int number, int x, int y)
            : base(number, x, y)
        {
            SpecialImage = new Image();
            SpecialImage.Source = new BitmapImage(new Uri($"/Images/death.png", UriKind.Relative));
            Grid.Children.Insert(1, SpecialImage);
        }

        public override int ReturnMove(Player player)
        {
            player.HasDied = true;
            return 0;
        }

        public override string ToString()
        {
            return "You died, go back to start.";
        }
    }
}