using NUnit.Framework;
using Ganzenbord;
using System.Threading;

namespace Ganzenbord.UnitTest
{
    [Apartment(ApartmentState.STA)]
    public class BridgeEndTest
    {
        Player _player;
        BridgeEnd _bridgeEnd;

        [SetUp]
        public void Setup()
        {
            _player = new Player("", "", PawnColor.BLUE);
            _bridgeEnd = new BridgeEnd(1, 1, 1);
        }
        [Test]
        public void ReturnMove_WhenCalled_ReturnCurrentPosition()
        {
            //arrange
            _player.CurrentBoardPosition = 12;

            //act
            int result = _bridgeEnd.ReturnMove(_player);

            //assert
            Assert.That(12 == result);
        }
    }
}