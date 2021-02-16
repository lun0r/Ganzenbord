using System;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Ganzenbord
{
    public class BridgeEnd : Field
    {
        public Image SpecialImage { get; set; }

        public BridgeEnd(int number, int x, int y)
            : base(number, x, y)
        {
            SpecialImage = new Image
            {
                Source = Board.SetImage("bridge.png")
            };
            SpecialImage.Opacity = 0.7;
            Grid.Children.Insert(1, SpecialImage);
        }

        public override int ReturnMove(Player player)
        {
            return base.ReturnMove(player);
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}