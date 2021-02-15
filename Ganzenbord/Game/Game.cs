using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

namespace Ganzenbord
{
    public class Game : INotifyPropertyChanged
    {
        public PlayerFactory _playerFactory;
        private readonly Dice _dice;
        private readonly BoardData boardData;
        public Board Board;
        public static Game game;

        private List<Player> _playerList;

        public List<Player> PlayerList
        {
            get { return _playerList; }
            set
            {
                _playerList = value;
                OnPropertyChanged();
            }
        }

        private int currentPlayer = 0;

        public Game(Grid boardGrid)
        {
            boardData = BoardData.GetBoardData();
            _playerFactory = new PlayerFactory();
            PlayerList = _playerFactory.GetPlayerList();
            _dice = new Dice();
            Board = new Board(boardGrid);
            game = this;
        }

        public static Game GetGameInstance()
        {
            return game;
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

            if (CP.SkipTurn > 0 || CP == Well.PlayerInWell)
            {
                boardData.PlaySidebar.UpdateDisplay($"Sorry {CP.Name}, je moet een beurt overslaan!", BindedProp.FIELDMESSAGE);
                MessageBox.Show($"Sorry {CP.Name}, je moet een beurt overslaan!");
                CP.SkipTurn--;
            }
            else
            {
                CP.Move(newFieldPos);

                boardData.PlaySidebar.UpdateDisplay($"{CP.Name} heeft {CP.Dice1 + CP.Dice2} geworpen, en zet aan", BindedProp.FIELDMESSAGE);
                MessageBox.Show($"{CP.Name} heeft {CP.Dice1 + CP.Dice2} geworpen, en zet aan");
                Board.UpdateField(CP);

                MakeMove(CP);
            }

            if (CP.CurrentBoardPosition == 63)
            {
                boardData.PlaySidebar.UpdateDisplay($"{CP.Name} has won the game !!!", BindedProp.FIELDMESSAGE);
                return true;
            }

            currentPlayer = currentPlayer == PlayerList.Count - 1 ? 0 : currentPlayer + 1; // select next player in list
            boardData.PlaySidebar.ImagePath = PlayerList[currentPlayer].AvatarPath;

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
                boardData.PlaySidebar.UpdateDisplay(currentField.ToString(), BindedProp.FIELDMESSAGE);

                MessageBox.Show(currentField.ToString());

                currentPlayer.Move(desiredPosition);
                Board.UpdateField(currentPlayer);
            } while (specialIsHit);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}