using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Ganzenbord
{
    internal class GameOver : Field
    {
        public Image SpecialImage { get; set; }

        public GameOver(int number, int x, int y)
            : base(number, x, y)
        {
        }

        public override int ReturnMove(Player player)
        {
            MessageBox.Show($"{player.Name} won !!!");
            return 63;
        }

        public override string ToString()
        {
            return "well done!";
        }
    }
}