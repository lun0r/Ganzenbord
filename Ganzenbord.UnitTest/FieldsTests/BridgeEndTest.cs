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
        [TestCase(12,12)]
        public void Method_WhenCalledUpon_ExpectedResult(int currentBoardPosition, int expectedResult)
        {
            //arrange
            _player.CurrentBoardPosition = currentBoardPosition;

            //act
            int result = _bridgeEnd.ReturnMove(_player);

            //assert
            Assert.That(expectedResult == result);
        }
    }
}