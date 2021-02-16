using NUnit.Framework;
using Ganzenbord;
using System.Threading;

namespace Ganzenbord.UnitTest
{
    [Apartment(ApartmentState.STA)]
    public class GooseTest
    {
        private Player _player;
        private Goose _goose;

        [SetUp]
        public void Setup()
        {
            _player = new Player("", "", PawnColor.BLUE);
            _goose = new Goose(1, 1, 1);
        }

        [TestCase(5, 5, false, 10, 20)]
        [TestCase(5, 5, true, 10, 0)]
        public void ReturnMove_WhenCalled_GoToNewPosition(int dice1, int dice2, bool isReversed, int currentBoardPosition, int expectedResult)
        {
            //arrange
            _player.Dice1 = dice1;
            _player.Dice2 = dice2;
            _player.CurrentBoardPosition = currentBoardPosition;
            _player.IsReversed = isReversed;

            //act
            int result = _goose.ReturnMove(_player);

            //assert
            Assert.AreEqual(expectedResult, result); // result rechts, links verwacht.
        }
    }
}