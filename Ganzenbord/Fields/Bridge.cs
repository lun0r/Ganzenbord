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
            SpecialImage = new Image
            {
                Source = Board.SetImage("bridge.png")
            };

            Grid.Children.Insert(1, SpecialImage);
        }

        public override int ReturnMove(Player player)
        {
            return 12;
        }

        public override string ToString()
        {
            return "You arrived at the bridge, you move to position 12.";
        }
    }
}