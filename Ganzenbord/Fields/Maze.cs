using System;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Ganzenbord
{
    internal class Maze : Field
    {
        public Image SpecialImage { get; set; }

        public Maze(int number, int x, int y)
            : base(number, x, y)
        {
            SpecialImage = new Image
            {
                Source = new BitmapImage(new Uri($"/Images/maze.png", UriKind.Relative))
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