using NUnit.Framework;
using Ganzenbord;

namespace Ganzenbord.UnitTest
{
    internal class DiceTest
    {
        private Dice _dice;

        [SetUp]
        public void Setup()
        {
            _dice = new Dice();
        }

        [Test]
        public void DiceRoll_WhenCalledUpon_ProvidesRandom()
        {
            int result = _dice.Roll();

            Assert.That(result <= 6 || result >= 1);
        }
    }
}