using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Ganzenbord
{
    internal class Game
    {
        readonly private Dice _dice1;
        readonly private Dice _dice2;

        private readonly List<Player> PlayerList = new List<Player>();

        public Board _board;

        public int counter = 0;

        private Player PlayerPlaying { get; set; }

        public Game()
        {
            _board = new Board();

            _dice1 = new Dice();
            _dice2 = new Dice();


        }

        private void MakeNewPlayer(string name, Image avatar, BitmapImage pion)
        {
            Player player = new Player(name, avatar, pion);
            PlayerList.Add(player);
        }

        public void TestRun()
        {

            if (PlayerPlaying == null)
            {
                PlayerPlaying = PlayerList[0];
            }
            else
            {
                //PlayerPlaying = PlayerList.Where(x => x.)
            }

            for (int i = 0; i < PlayerList.Count; i++)
            {
                int rolleddice1 = _dice1.Roll();
                int rolleddice2 = _dice2.Roll();

                PlayerList[i].Move(rolleddice1, rolleddice2);
                _board.UpdateField(PlayerList[i]);

                //for (int j = 0; j < rolled1; j++)
                //{
                //    PlayerList[i].OldBoardPosition = PlayerList[i].NewBoardPosition;
                //    PlayerList[i].NewBoardPosition++;

                //    _board.UpdateField(PlayerList[i]);
                //    Thread.Sleep(100);
                //}
            }
        }

        public void StartGame()
        {
            MakeNewPlayer("Dries", null, new BitmapImage(new Uri("/Images/playerBlue.png", UriKind.Relative)));
            MakeNewPlayer("Kobe", null, new BitmapImage(new Uri("/Images/playerRed.png", UriKind.Relative)));
            MakeNewPlayer("Pieter", null, new BitmapImage(new Uri("/Images/playerYellow.png", UriKind.Relative)));

            RollDice();
        }

        public void RollDice()
        { 
            StartSidebar.
        }

    }
}