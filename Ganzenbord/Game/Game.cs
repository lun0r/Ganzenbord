using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace Ganzenbord
{
    internal class Game
    {
        private readonly List<Player> PlayerList = new List<Player>();

        public Board _board;

        public int counter = 0;

        private Player PlayerPlaying { get; set; }

        public Game()
        {
            _board = new Board();

            MakeNewPlayer("Dries", null, new BitmapImage(new Uri("/Images/playerBlue.png", UriKind.Relative)));
            MakeNewPlayer("Kobe", null, new BitmapImage(new Uri("/Images/playerRed.png", UriKind.Relative)));
            MakeNewPlayer("Pieter", null, new BitmapImage(new Uri("/Images/playerYellow.png", UriKind.Relative)));
        }

        private void MakeNewPlayer(string name, Image avatar, BitmapImage pion)
        {
            Player player = new Player(name, avatar, pion);
            PlayerList.Add(player);
        }

        public void TestRun()
        {
        }
    }
}