using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Ganzenbord
{
    internal class Game
    {
        private MainWindow _frontend;
        private Dice _dice;
        public Board _board;

        public Game(MainWindow frontend)
        {
            _frontend = frontend;
            _dice = new Dice();
            _board = new Board(frontend);
            _board.SetUpBoard();
        }

        public void RunGame()
        {
            BitmapImage Pion = new BitmapImage(new Uri("/Images/playerBlue.png", UriKind.Relative));
            Player player1 = new Player("player1", null, Pion);

            int roll1 = player1.RollDice();
            int roll2 = player1.RollDice();

            //Test();
            //Field field = boardList[1];
            //Test2(player1);

            _board.UpdateField(player1);
        }
    }
}