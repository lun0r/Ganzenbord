using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Ganzenbord
{
    internal class PlayerFactory
    {
        private readonly List<Player> _playerList;

        private readonly BoardData _boardData;
        private Pawn _pawn = new Pawn();

        public PlayerFactory()
        {
            _playerList = new List<Player>(); ;
            _boardData = BoardData.GetBoardData();

            //_pawnColors = new string[] { "Red", "Green", "Blue", "Purple", "Orange", "Yellow" };

            //_boardData.StartSidebar.PropStart = @"C:\Users\1\Pictures\4_Jobs_That_Require_a_Background_in_Computers.jpeg";

            //_boardData.StartSidebar.DropDown = _playerList;
        }

        public List<Player> GetPlayerList()
        {
            //MakeNewPlayer("Dries", null, PawnColor.ORANGE);
            //MakeNewPlayer("Kobe", null, PawnColor.BLUE);
            //MakeNewPlayer("Pieter", null, PawnColor.YELLOW);
            //MakeNewPlayer("Michiel", null, PawnColor.GREEN);

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

            List<Pawn> pawnList = _pawn.GetPawns();
            PawnColor color = pawnList[index].PawnColor;

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

            MakeNewPlayer(name, img, color);
        }
    }
}