using System;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Ganzenbord
{
    public class Prison : Field
    {
        public Image SpecialImage { get; set; }
        public Player CurrentPlayer { get; set; }

        public Prison(int number, int x, int y)
            : base(number, x, y)
        {
            SpecialImage = new Image
            {
                Source = Board.SetImage("prison.png")
            };
            Grid.Children.Insert(1, SpecialImage);
        }

        public override int ReturnMove(Player player)
        {
            CurrentPlayer = player;
            player.SkipTurn = 3;

            return player.CurrentBoardPosition;
        }

        public override string ToString()
        {
            return $"{CurrentPlayer.Name} was naughty and will skip 3 turns.";
        }
    }
}