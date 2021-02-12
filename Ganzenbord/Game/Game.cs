using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Ganzenbord
{
    internal class Game
    {
        readonly private Dice _dice;
        public BoardData boardData;
        public Board _board;
        private readonly List<Player> PlayerList;

        private int currentPlayer = 0;

        public Game()
        {
            _board = new Board();
            boardData = BoardData.GetBoardData();
            _dice = new Dice();
            PlayerList = new List<Player>();
        }

        private void MakeNewPlayer(string name, Image avatar, PawnColor pawn)
        {
            Player player = new Player(name, avatar, pawn);
            PlayerList.Add(player);
        }

        public void StartGame()
        {
            MakeNewPlayer("Dries", null, PawnColor.ORANGE);
            MakeNewPlayer("Kobe", null, PawnColor.BLUE);
            MakeNewPlayer("Pieter", null, PawnColor.YELLOW);
            MakeNewPlayer("Michiel", null, PawnColor.GREEN);

            _board.BoardList[0].Orange.Visibility = Visibility.Visible;
            _board.BoardList[0].Blue.Visibility = Visibility.Visible;
            _board.BoardList[0].Yellow.Visibility = Visibility.Visible;
            _board.BoardList[0].Green.Visibility = Visibility.Visible;
        }

        public void Run()
        {
            RollDice();
            Player CP = PlayerList[currentPlayer];

            string DiceRolled = $"Dice:{CP.Dice1} | {CP.Dice2}";
            int newFieldPos = CP.CurrentBoardPosition + CP.Dice1 + CP.Dice2;
            CP.IsReversed = false;

            if (CP.SkipTurn <= 0)
            {
                CP.IsReversed = newFieldPos > 63;
                CP.Move(newFieldPos);
                _board.UpdateField(CP);
                boardData.PlaySidebar.UpdateDisplay(DiceRolled, BindedProp.DICEROLLED);
                boardData.PlaySidebar.UpdateDisplay(CP.Name, BindedProp.CURRENTTURN);
                MessageBox.Show($"{CP.Name} is vertrokken...");

                MakeMove(CP);
            }
            else
            {
                MessageBox.Show($"Sorry {CP.Name}, je moet een beurt overslaan!");
                CP.SkipTurn--;
            }
            currentPlayer = currentPlayer == PlayerList.Count - 1 ? 0 : currentPlayer + 1; // select next player in list
        }

        public void RollDice()
        {
            PlayerList[currentPlayer].Dice1 = _dice.Roll();
            PlayerList[currentPlayer].Dice2 = _dice.Roll();
        }

        private void MakeMove(Player currentPlayer)
        {
            bool specialIsHit = true;
            var CP = currentPlayer;
            string DiceRolled = $"Dice:{CP.Dice1} | {CP.Dice2}";

            do
            {
                boardData.PlaySidebar.UpdateDisplay(DiceRolled, BindedProp.DICEROLLED);
                boardData.PlaySidebar.UpdateDisplay(CP.Name, BindedProp.CURRENTTURN);

                Field currentField = _board.BoardList.FirstOrDefault(x => x.Number == CP.CurrentBoardPosition);
                int NummerOmNaarToeTeGaan = currentField.ReturnMove(CP);

                specialIsHit = NummerOmNaarToeTeGaan != CP.CurrentBoardPosition;

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
            } while (specialIsHit);
        }
    }
}