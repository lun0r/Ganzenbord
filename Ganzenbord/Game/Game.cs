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
        public BoardData boardData;
        public Board _board;
        private readonly List<Player> PlayerList;
        private int currentPlayer = 0;
        public int counter = 0;

        private Player PlayerPlaying { get; set; }

        public Game()
        {
            _board = new Board();
            boardData = BoardData.GetBoardData();
            _dice1 = new Dice();
            _dice2 = new Dice();
            PlayerList = new List<Player>();
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

            UpdateDisplay("hallo pieter1", "hallo kobe1");
        }

        public void RollDice()
        {
            PlayerList[currentPlayer].Dice1 = _dice1.Roll();
            PlayerList[currentPlayer].Dice2 = _dice1.Roll();
        }

        public void Run()
        {
            RollDice();
            UpdateDisplay("hallo pieter", "hallo kobe");

            string CurentTurn = PlayerList[currentPlayer].Name;
            string DiceRolled = $"Dice :{PlayerList[currentPlayer].Dice1} Dice : {PlayerList[currentPlayer].Dice2}";

            UpdateDisplay(DiceRolled, CurentTurn);
            currentPlayer = currentPlayer == PlayerList.Count - 1 ? 0 : currentPlayer + 1;
        }

        public void UpdateDisplay(string diceRolled, string currentTurn)
        {
            boardData.PlaySidebar.CurrentTurn = currentTurn;
            boardData.PlaySidebar.DiceRolled = diceRolled;
        }
    }
}