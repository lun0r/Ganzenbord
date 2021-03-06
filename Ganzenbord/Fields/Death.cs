﻿using System;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Ganzenbord
{
    public class Death : Field
    {
        public Image SpecialImage { get; set; }
        public Player CurrentPlayer { get; set; }

        public Death(int number, int x, int y)
            : base(number, x, y)
        {
            SpecialImage = new Image
            {
                Source = Board.SetImage("death.png")
            };
            Grid.Children.Insert(1, SpecialImage);
        }

        public override int ReturnMove(Player player)
        {
            CurrentPlayer = player;
            player.HasDied = true;
            return 0;
        }

        public override string ToString()
        {
            return $"{CurrentPlayer.Name} has died. Roll the dice to start your turn! ";
        }
    }
}