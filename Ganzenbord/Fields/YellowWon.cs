using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Ganzenbord
{
    internal class YellowWon : Field
    {
        public Image SpecialImage { get; set; }

        public YellowWon(int number, int x, int y)
            : base(number, x, y)
        {
        }

        public override int ReturnMove(Player player)
        {
            MessageBox.Show($"{player.Name} won !!! Vuurwerk (9/10 Pieter) ");
            return player.CurrentBoardPosition;
        }
    }
}