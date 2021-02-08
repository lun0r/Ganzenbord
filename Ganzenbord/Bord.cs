using System;
using System.Collections.Generic;
using System.Text;

namespace Ganzenbord
{
    internal class Bord
    {
        public Field[,] BordGrid { get; set; }

        public Bord()
        {
            BordGrid = new Field[8, 8];
        }
    }
}