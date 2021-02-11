using System;

namespace Ganzenbord
{
    internal class Dice
    {
        private readonly Random rnd;

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