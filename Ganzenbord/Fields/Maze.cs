using System;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Ganzenbord
{
    public class Maze : Field
    {
        public Image SpecialImage { get; set; }

        public Maze(int number, int x, int y)
            : base(number, x, y)
        {
            SpecialImage = new Image
            {
                Source = Board.SetImage("maze.png")
            };
            Grid.Children.Insert(1, SpecialImage);
        }

        public override int ReturnMove(Player player)
        {
            return 39;
        }

        public override string ToString()
        {
            return $"You lost your way in the maze, return to position 39.";
        }
    }
}