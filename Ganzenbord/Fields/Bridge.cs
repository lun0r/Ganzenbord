using System;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Ganzenbord
{
    internal class Bridge : Field
    {
        public Image SpecialImage { get; set; }

        public Bridge(int number, int x, int y)
            : base(number, x, y)
        {
            SpecialImage = new Image();
            SpecialImage.Source = new BitmapImage(new Uri($"/Images/bridge.png", UriKind.Relative));
            Grid.Children.Insert(1, SpecialImage);
        }

        public override int[] ReturnMove(Player player)
        {
            int[] output = new int[] { 12, 1 };
            return output;
        }
    }
}