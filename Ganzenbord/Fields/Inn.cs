using System;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Ganzenbord
{
    internal class Inn : Field
    {
        public Image SpecialImage { get; set; }

        public Inn(int number, int x, int y)
            : base(number, x, y)
        {
            SpecialImage = new Image
            {
                Source = Board.SetImage("inn.png")
            };
            Grid.Children.Insert(1, SpecialImage);
        }

        public override int ReturnMove(Player player)
        {
            player.SkipTurn = 1;
            return player.CurrentBoardPosition;
        }

        public override string ToString()
        {
            return "You will spend the night in the inn, Skip one turn";
        }
    }
}