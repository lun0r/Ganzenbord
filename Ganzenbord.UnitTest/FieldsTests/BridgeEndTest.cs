using NUnit.Framework;
using Ganzenbord;

namespace Ganzenbord.UnitTest
{
    public class BridgeEndTest
    {
        Player _player;
        BridgeEnd _bridge;

        [SetUp]
        public void Setup()
        {
            _player = new Player("", "", PawnColor.BLUE);
            _bridge = new BridgeEnd(1, 1, 1);
        }
        [TestCase(1, 1, false, 10, 20)]
        public void Method_WhenCalledUpon_ExpectedResult(int dice1, int dice2, bool isReversed, int currentBoardPosition, int expectedResult)
        {
            //arrange
            _player.Dice1 = dice1;
            _player.Dice2 = dice2;
            _player.CurrentBoardPosition = currentBoardPosition;
            _player.IsReversed = isReversed;

            //act
            int result = _bridge.ReturnMove(_player);

            //assert
            Assert.That(result == expectedResult);
        }
    }