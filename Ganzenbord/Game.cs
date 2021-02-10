using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Ganzenbord
{
    internal class Game
    {
        private readonly List<Player> PlayerList = new List<Player>();

        public Board _board;

        public Game(MainWindow frontend)
        {
            _board = new Board(frontend);

            _board.SetUpBoard();
        }

        private void MakeNewPlayer(string name, Image avatar, BitmapImage pion)
        {
            Player player = new Player(name, avatar, pion);
            PlayerList.Add(player);
        }

        public void TestRun()
        {
            if (PlayerList.Count < 1)
            {
                MakeNewPlayer("Dries", null, new BitmapImage(new Uri("/Images/playerBlue.png", UriKind.Relative)));
                MakeNewPlayer("Kobe", null, new BitmapImage(new Uri("/Images/playerRed.png", UriKind.Relative)));
                MakeNewPlayer("Pieter", null, new BitmapImage(new Uri("/Images/playerYellow.png", UriKind.Relative)));
            }

            for (int i = 0; i < PlayerList.Count; i++)
            {
                int rolled1 = PlayerList[i].RollDice();

                PlayerList[i].Move(rolled1);
                _board.UpdateField(PlayerList[i]);
            }
        }
    }
}