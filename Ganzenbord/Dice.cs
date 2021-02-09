using System;
using System.Collections.Generic;
using System.Text;

namespace Ganzenbord
{
    internal class Dice
    {
        private Random rnd;

        public Dice()
        {
            rnd = new Random();
        }

        public int Roll()
        {
            return rnd.Next(1, 7);
        }
    }
}