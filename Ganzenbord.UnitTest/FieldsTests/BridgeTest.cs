using NUnit.Framework;
using Ganzenbord;
using System.Threading;

namespace Ganzenbord.UnitTest
{
    [Apartment(ApartmentState.STA)]
    public class BridgeTest
    {
        private Player _player;
        Bridge _bridge;

        [SetUp]
        public void Setup()
        {
            _bridge = new Bridge(1, 1, 1);
            _player = new Player("", "", PawnColor.BLUE);
        }
        [Test]
        public void Method_WhenCalledUpon_ExpectedResult()
        {
            //arrange
            _player.CurrentBoardPosition = 6;

            //act
            int result = _bridge.ReturnMove(_player);

            //assert
            Assert.That(12 == result);
        }
    }
}