using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Linq;

namespace Ganzenbord
{
    public class PlayerFactory
    {
        private readonly List<Player> _playerList; //.Exists() werkt enkel op een list
        private readonly BoardData _boardData;
        private ObservableCollection<Pawn> _pawnList;

        public PlayerFactory()
        {
            _playerList = new List<Player>();
            _boardData = BoardData.GetBoardData();
            _pawnList = new ObservableCollection<Pawn>();
            MakePawnList();
        }

        private void MakePawnList()
        {
            _pawnList.Add(new Pawn("Red", PawnColor.RED));
            _pawnList.Add(new Pawn("Blue", PawnColor.BLUE));
            _pawnList.Add(new Pawn("Green", PawnColor.GREEN));
            _pawnList.Add(new Pawn("Yellow", PawnColor.YELLOW));
            _pawnList.Add(new Pawn("Purple", PawnColor.PURPLE));
            _pawnList.Add(new Pawn("Orange", PawnColor.ORANGE));

            _boardData.StartSidebar.PawnColor = _pawnList;
        }

        public IList<Player> GetPlayerList()
        {
            return _playerList;
        }

        private void MakeNewPlayer(string name, string avatar, PawnColor pawn)
        {
            Player player = new Player(name, avatar, pawn);
            _playerList.Add(player);
        }

        public void AddPlayer(int index, Board board)
        {
            var name = _boardData.StartSidebar.Name;
            var img = _boardData.StartSidebar.AvatarPath;

            bool validInput = CheckInputValid(index);

            if (validInput)
            {
                PutPlayerOnBoard(_pawnList[index].PawnColor, board);
                MakeNewPlayer(name, img, _pawnList[index].PawnColor);
                ClearScreen(index);
            }
        }

        private bool CheckInputValid(int index)
        {
            if (index < 0)
            {
                MessageBox.Show("Select a color");
                return false;
            }

            if (_playerList.Exists(x => x.Name == _boardData.StartSidebar.Name))
            {
                MessageBox.Show("This name was already picked.");
                return false;
            }
            else if (_boardData.StartSidebar.Name == null || _boardData.StartSidebar.Name == "")
            {
                MessageBox.Show("Please enter a name.");
                return false;
            }
            else
            {
                return true;
            }
        }

        private void ClearScreen(int index)
        {
            _boardData.StartSidebar.PawnColor.RemoveAt(index);
            _boardData.StartSidebar.Name = "";
            _boardData.StartSidebar.AvatarPath = "/avatar.png";
        }

        private void PutPlayerOnBoard(PawnColor color, Board board)
        {
            switch (color)
            {
                case PawnColor.RED:
                    board.BoardList[0].Red.Visibility = Visibility.Visible;

                    break;

                case PawnColor.GREEN:
                    board.BoardList[0].Green.Visibility = Visibility.Visible;
                    break;

                case PawnColor.BLUE:
                    board.BoardList[0].Blue.Visibility = Visibility.Visible;
                    break;

                case PawnColor.PURPLE:
                    board.BoardList[0].Purple.Visibility = Visibility.Visible;
                    break;

                case PawnColor.ORANGE:
                    board.BoardList[0].Orange.Visibility = Visibility.Visible;
                    break;

                case PawnColor.YELLOW:
                    board.BoardList[0].Yellow.Visibility = Visibility.Visible;
                    break;

                default:
                    break;
            }
        }
    }
}