using System;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Ganzenbord
{
    internal class Prison : Field
    {
        public Image SpecialImage { get; set; }

        public Prison(int number, int x, int y)
            : base(number, x, y)
        {
            SpecialImage = new Image
            {
                Source = new BitmapImage(new Uri($"/Images/prison.png", UriKind.Relative))
            };
            Grid.Children.Insert(1, SpecialImage);
        }

        public override int ReturnMove(Player player)
        {
            player.SkipTurn = 3;

            return player.CurrentBoardPosition;
        }

        public override string ToString()
        {
            return $"You are naughty, spend three turns in prison";
        }
    }
}