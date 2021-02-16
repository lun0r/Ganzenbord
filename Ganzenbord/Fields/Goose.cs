using System;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Ganzenbord
{
    public class Goose : Field
    {
        public int GooseFollowsXPositions { get; set; }
        public Image SpecialImage { get; set; }
        public Player CurrentPlayer { get; set; }

        public Goose(int number, int x, int y)
            : base(number, x, y)
        {
            SpecialImage = new Image
            {
                Source = Board.SetImage("goose.png")
            };
            Grid.Children.Insert(1, SpecialImage);
        }

        public override int ReturnMove(Player player)
        {
            CurrentPlayer = player;
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
            return $"{CurrentPlayer.Name} hit a Goose, he will chase you for {GooseFollowsXPositions} tiles!";
        }
    }
}