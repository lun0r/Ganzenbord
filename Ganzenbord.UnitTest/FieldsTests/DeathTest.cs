using NUnit.Framework;
using Ganzenbord;
using System.Threading;

namespace Ganzenbord.UnitTest
{
    [Apartment(ApartmentState.STA)]
    public class DeathTest
    {
        private Player _player;
        private Death _death;

        [SetUp]
        public void Setup()
        {
            _player = new Player("", "", PawnColor.BLUE);
            _death = new Death(1, 1, 1);
        }

        [Test]
        public void Method_WhenCalledUpon_ExpectedResult()
        {
            //arrange
            _player.HasDied = false;

            //act
            int result = _death.ReturnMove(_player);
            

            //assert
            Assert.That(result == 0 && _player.HasDied == true);
        }
    }
}