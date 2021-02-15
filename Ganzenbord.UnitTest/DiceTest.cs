using NUnit.Framework;
using Ganzenbord;

namespace Ganzenbord.UnitTest
{
    public class DiceTest
    {
        private Dice _dice;
        private Field _field;

        [SetUp]
        public void Setup()
        {
            _dice = new Dice();
            _field = new Field(1, 1, 1);
        }

        [Test]
        public void DiceRoll_WhenCalledUpon_ProvidesRandom()
        {
            int result = _dice.Roll();

            Assert.That(result <= 6 || result >= 1);
        }
    }
}