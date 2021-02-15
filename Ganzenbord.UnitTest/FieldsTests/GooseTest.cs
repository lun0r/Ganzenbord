using NUnit.Framework;
using Ganzenbord;

namespace Ganzenbord.UnitTest
{

    public class GooseTest
    {
        Player _player;
        Goose _goose;

        [SetUp]
        public void Setup()
        {
            _player = new Player("", "", PawnColor.BLUE);
            _goose = new Goose(1, 1, 1);

        }

        [TestCase(5, 5, false, 10, 20)]
        public void ReturnMove_WhenCalledUpon_ProvidesNewPosition(int dice1, int dice2, bool isReversed, int currentBoardPosition, int expectedResult)
        {
            //arrange
            _player.Dice1 = dice1;
            _player.Dice2 = dice2;
            _player.CurrentBoardPosition = currentBoardPosition;
            _player.IsReversed = isReversed;

            //act
            int result = _goose.ReturnMove(_player);

            //assert
            Assert.That(result == expectedResult);
        }
    }

}