using System;
using System.Collections.Generic;
using System.Text;

namespace Ganzenbord
{
    internal class Board
    {
        public Field[,] BoardGrid { get; set; }

        public Board()
        {
            BoardGrid = new Field[8, 8];
        }
    }
}