using System;
using System.Windows;
using System.Windows.Controls;

namespace Ganzenbord
{
    public class GameOver : Field
    {
        public Image SpecialImage { get; set; }
        public Player CurrentPlayer { get; set; }

        public GameOver(int number, int x, int y)
            : base(number, x, y)
        {
        }

        public override int ReturnMove(Player player)
        {
            CurrentPlayer = player;
            MessageBox.Show($"{player.Name} won !!!");

            return 63;
        }

        public override string ToString()
        {
            return $"Well done {CurrentPlayer.Name}! You Rock!";
        }
    }
}