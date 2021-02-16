using System;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Ganzenbord
{
    public class Well : Field
    {
        public Image SpecialImage { get; set; }
        public static Player PlayerInWell { get; set; }
        public Player CurrentPlayer { get; set; }

        public Well(int number, int x, int y)
            : base(number, x, y)
        {
            SpecialImage = new Image
            {
                Source = Board.SetImage("well.png")
            };
            Grid.Children.Insert(1, SpecialImage);
        }

        public override int ReturnMove(Player player)
        {
            CurrentPlayer = player;
            PlayerInWell = player;

            return player.CurrentBoardPosition;
        }

        public override string ToString()
        {
            return $"{CurrentPlayer.Name} fell in the well, wait for the next sucker!";
        }
    }
}