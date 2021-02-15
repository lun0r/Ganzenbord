using System.Collections.Generic;
using System.Windows;

namespace Ganzenbord
{
    public class PlayerFactory
    {
        private readonly List<Player> _playerList;

        private readonly BoardData _boardData;
        private List<Pawn> _pawnList;

        public PlayerFactory()
        {
            _playerList = new List<Player>(); ;
            _boardData = BoardData.GetBoardData();
            _pawnList = new List<Pawn>();
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

        public List<Player> GetPlayerList()
        {
            return _playerList;
        }

        private void MakeNewPlayer(string name, string avatar, PawnColor pawn)
        {
            Player player = new Player(name, avatar, pawn);
            _playerList.Add(player);
        }

        public void ShowPlayers(Board board)
        {
        }

        public void AddPlayer(int index, Board board)
        {
            var name = _boardData.StartSidebar.Name;
            var img = _boardData.StartSidebar.AvatarPath;

            PawnColor color = _pawnList[index].PawnColor;

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

            //  TO FIX: _boardData.StartSidebar.PawnColor.RemoveAt(index);
            MakeNewPlayer(name, img, color);
        }
    }
}