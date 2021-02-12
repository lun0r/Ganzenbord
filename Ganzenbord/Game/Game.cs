using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

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
            var CP = PlayerList[currentPlayer];
            string CurentTurn = CP.Name;
            string DiceRolled = $"Dice :{CP.Dice1} Dice : {CP.Dice2}";

            if (CP.SkipTurn <= 0)
            {
                CP.IsReversed = false;

                int ToMove = CP.CurrentBoardPosition + CP.Dice1 + CP.Dice2;

                bool SpecialIsHit = true;
                CP.IsReversed = ToMove > 63;
                CP.Move(ToMove);
                _board.UpdateField(CP);
                UpdateDisplay(DiceRolled, CurentTurn);
                MessageBox.Show($"{CP.Name} is  vertrokken...");
                do
                {
                    int[] output = _board.BoardList.FirstOrDefault(x => x.Number == CP.CurrentBoardPosition).ReturnMove(CP);
                    if (output[1] == 1)
                    {
                        MessageBox.Show($"{CP.Name} staat op ne special!");
                        CP.IsReversed = output[0] > 63 ? true : false;
                        CP.Move(output[0]);
                        _board.UpdateField(CP);
                        UpdateDisplay(DiceRolled, CurentTurn);
                        MessageBox.Show($"{CP.Name} is vertrokken van de special..");
                    }
                    else if (output[1] == 2)
                    {
                        MessageBox.Show($"{CP.Name} zit in de put!");
                        foreach (var player in PlayerList)
                        {
                            if (player.SkipTurn > 4 && player != CP)
                            {
                                MessageBox.Show($"{player.Name} is vrij!");
                                player.SkipTurn = 0;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show($"{CP.Name} blijft staan!");
                    }

                    SpecialIsHit = output[1] == 0 || output[1] == 2 ? false : true;
                } while (SpecialIsHit);
            }
            else
            {
                MessageBox.Show($"Sorry {CP.Name}, je moet een beurt overslaan!");
                CP.SkipTurn--;
            }
            currentPlayer = currentPlayer == PlayerList.Count - 1 ? 0 : currentPlayer + 1; // select next player in list
            UpdateDisplay(DiceRolled, CurentTurn);

            // TO ADD: special fields geven event-zinnetje weer , bvb gans: "Oh nee, een Gans achtervolgt je, ga X aantal plaatsen voorruit!!"
        }

        public void UpdateDisplay(string diceRolled, string currentTurn)
        {
            boardData.PlaySidebar.CurrentTurn = currentTurn;
            boardData.PlaySidebar.DiceRolled = diceRolled;
        }
    }
}