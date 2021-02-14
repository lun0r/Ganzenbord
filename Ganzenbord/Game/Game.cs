using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Ganzenbord
{
    internal class Game
    {
        public PlayerFactory _playerFactory;
        private readonly Dice _dice;
        private readonly BoardData boardData;
        public Board Board;
        public List<Player> PlayerList;

        private int currentPlayer = 0;

        public Game(Grid boardGrid)
        {
            boardData = BoardData.GetBoardData();
            _playerFactory = new PlayerFactory();
            PlayerList = _playerFactory.GetPlayerList();
            _dice = new Dice();
            Board = new Board(boardGrid);
            //_playerFactory.ShowPlayers(_board);
        }

        private void RollDice()
        {
            PlayerList[currentPlayer].Dice1 = _dice.Roll();
            PlayerList[currentPlayer].Dice2 = _dice.Roll();
        }

        public bool Run()
        {
            Player CP = PlayerList[currentPlayer];
            CP.IsReversed = false;

            RollDice();
            string DiceRolled = $"Dice:  {CP.Dice1}  |  {CP.Dice2}";

            boardData.PlaySidebar.UpdateDisplay(DiceRolled, BindedProp.DICEROLLED);

            int newFieldPos = CP.CurrentBoardPosition + CP.Dice1 + CP.Dice2;

            if (CP.SkipTurn > 0)
            {
                MessageBox.Show($"Sorry {CP.Name}, je moet een beurt overslaan!");
                CP.SkipTurn--;
            }
            else
            {
                CP.Move(newFieldPos);

                MessageBox.Show($"{CP.Name} heeft {CP.Dice1 + CP.Dice2} geworpen, en zet aan");
                Board.UpdateField(CP);

                MakeMove(CP);
            }

            if (CP.CurrentBoardPosition == 63) return true;

            currentPlayer = currentPlayer == PlayerList.Count - 1 ? 0 : currentPlayer + 1; // select next player in list

            boardData.PlaySidebar.UpdateDisplay("", BindedProp.DICEROLLED);
            boardData.PlaySidebar.UpdateDisplay(PlayerList[currentPlayer].Name, BindedProp.CURRENTTURN);

            return false;
        }

        private void MakeMove(Player currentPlayer)
        {
            bool specialIsHit;

            do
            {
                Field currentField = Board.BoardList.FirstOrDefault(x => x.Number == currentPlayer.CurrentBoardPosition);
                int desiredPosition = currentField.ReturnMove(currentPlayer);

                specialIsHit = desiredPosition != currentPlayer.CurrentBoardPosition;

                MessageBox.Show(currentField.ToString());

                currentPlayer.Move(desiredPosition);
                Board.UpdateField(currentPlayer);
            } while (specialIsHit);
        }
    }
}