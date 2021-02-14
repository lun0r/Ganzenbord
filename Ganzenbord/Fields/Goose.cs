using System;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Ganzenbord
{
    internal class Goose : Field
    {
        public int GooseFollowsXPositions { get; set; }
        public Image SpecialImage { get; set; }

        public Goose(int number, int x, int y)
            : base(number, x, y)
        {
            SpecialImage = new Image
            {
                Source = new BitmapImage(new Uri($"/Images/goose.png", UriKind.Relative))
            };
            Grid.Children.Insert(1, SpecialImage);
        }

        public override int ReturnMove(Player player)
        {
            GooseFollowsXPositions = player.Dice1 + player.Dice2;

            if (player.IsReversed)
            {
                return player.CurrentBoardPosition - GooseFollowsXPositions;
            }
            else
            {
                return player.CurrentBoardPosition + GooseFollowsXPositions;
            }
        }

        public override string ToString()
        {
            return $"I am a Goose, i will hunt you for {GooseFollowsXPositions} tiles.";
        }
    }
}