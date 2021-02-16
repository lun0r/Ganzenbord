using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Ganzenbord
{
    public class GameOver : Field
    {
        public Image SpecialImage { get; set; }
        private Player Champion { get; set; }

        public GameOver(int number, int x, int y)
            : base(number, x, y)
        {
        }

        public override int ReturnMove(Player player)
        {
            Champion = player;

            return 63;
        }

        public override string ToString()
        {
            return $"{Champion}: Well done !";
        }
    }
}