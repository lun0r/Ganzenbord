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

        public bool Run()
        {
            RollDice();
            Player CP = PlayerList[currentPlayer];
            CP.IsReversed = false;

            string DiceRolled = $"Dice:  {CP.Dice1}  |  {CP.Dice2}";
            int newFieldPos = CP.CurrentBoardPosition + CP.Dice1 + CP.Dice2;

            if (CP.SkipTurn > 0)
            {
                MessageBox.Show($"Sorry {CP.Name}, je moet een beurt overslaan!");
                CP.SkipTurn--;
            }
            else
            {
                CP.Move(newFieldPos);
                boardData.PlaySidebar.UpdateDisplay(DiceRolled, BindedProp.DICEROLLED);
                boardData.PlaySidebar.UpdateDisplay(CP.Name, BindedProp.CURRENTTURN);
                MessageBox.Show($"{CP.Name} heeft {CP.Dice1 + CP.Dice2} geworpen, en zet aan");
                _board.UpdateField(CP);

                MakeMove(CP);
            }

            if (CP.CurrentBoardPosition == 63)
            {
                boardData.PlaySidebar.UpdateDisplay(DiceRolled, BindedProp.DICEROLLED);
                boardData.PlaySidebar.UpdateDisplay(CP.Name, BindedProp.CURRENTTURN);
                MessageBox.Show($"---Game over--- {CP.Name} Won!!!");
                return true;
            }
            currentPlayer = currentPlayer == PlayerList.Count - 1 ? 0 : currentPlayer + 1; // select next player in list

            return false;
        }

        public void RollDice()
        {
            PlayerList[currentPlayer].Dice1 = _dice.Roll();
            PlayerList[currentPlayer].Dice2 = _dice.Roll();
        }

        private void MakeMove(Player currentPlayer)
        {
            bool specialIsHit;
            string DiceRolled = $"Dice:  {currentPlayer.Dice1}  |  {currentPlayer.Dice2}";

            do
            {
                boardData.PlaySidebar.UpdateDisplay(DiceRolled, BindedProp.DICEROLLED);
                boardData.PlaySidebar.UpdateDisplay(currentPlayer.Name, BindedProp.CURRENTTURN);

                Field currentField = _board.BoardList.FirstOrDefault(x => x.Number == currentPlayer.CurrentBoardPosition);
                int desiredPosition = currentField.ReturnMove(currentPlayer);

                specialIsHit = desiredPosition != currentPlayer.CurrentBoardPosition;

                MessageBox.Show(currentField.ToString());

                currentPlayer.Move(desiredPosition);
                _board.UpdateField(currentPlayer);
            } while (specialIsHit);
        }
    }
}