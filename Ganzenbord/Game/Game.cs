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
        readonly private Dice _dice;
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

            _dice = new Dice();
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
        }

        public void RollDice()
        {
            PlayerList[currentPlayer].Dice1 = _dice.Roll();
            PlayerList[currentPlayer].Dice2 = _dice.Roll();
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
                boardData.PlaySidebar.UpdateDisplay(DiceRolled, PropToBindTo.DiceRolled);
                boardData.PlaySidebar.UpdateDisplay(CurentTurn, PropToBindTo.CurrentTurn);
                MessageBox.Show($"{CP.Name} is  vertrokken...");
                do
                {
                    boardData.PlaySidebar.UpdateDisplay(DiceRolled, PropToBindTo.DiceRolled);
                    boardData.PlaySidebar.UpdateDisplay(CurentTurn, PropToBindTo.CurrentTurn);

                    Field currentField = _board.BoardList.FirstOrDefault(x => x.Number == CP.CurrentBoardPosition);
                    int NummerOmNaarToeTeGaan = currentField.ReturnMove(CP);

                    SpecialIsHit = NummerOmNaarToeTeGaan != CP.CurrentBoardPosition;

                    if (NummerOmNaarToeTeGaan != CP.CurrentBoardPosition)
                    {
                        MessageBox.Show(currentField.ToString());

                        CP.Move(NummerOmNaarToeTeGaan);
                        _board.UpdateField(CP);
                    }
                    else if (CP.SkipTurn > 4) // de put
                    {
                        MessageBox.Show(currentField.ToString());
                    }
                    else
                    {
                        MessageBox.Show($"{CP.Name} blijft staan!");
                    }

                    //SpecialIsHit = WatBenIk == 0 || WatBenIk == 2 ? false : true;
                } while (SpecialIsHit);
            }
            else
            {
                MessageBox.Show($"Sorry {CP.Name}, je moet een beurt overslaan!");
                CP.SkipTurn--;
            }
            currentPlayer = currentPlayer == PlayerList.Count - 1 ? 0 : currentPlayer + 1; // select next player in list
        }
    }
}