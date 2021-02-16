using NUnit.Framework;
using Ganzenbord;
using System.Threading;

namespace Ganzenbord.UnitTest
{
    [Apartment(ApartmentState.STA)]
    public class PrisonTest
        //nog testen: of na 3 beurten wel verplaatst
    {
        Player _player;
        Prison _prison;

        [SetUp]
        public void Setup()
        {
            _player = new Player("", "", PawnColor.BLUE);
            _prison = new Prison(1, 1, 1);
        }
        [Test]

        public void Method_WhenCalled_ExpectedResult()
        {
            //arrange
            _player.CurrentBoardPosition = 19;
            _player.SkipTurn = 0;

            //act
            int result = _prison.ReturnMove(_player);

            //assert
            Assert.That(19 == result);
        }

        [Test]
        public void ReturnMove_WhenCalled_SkipThreeTurns()
        {
            //arrange
            _player.CurrentBoardPosition = 19;
            _player.SkipTurn = 0;

            //act
            _prison.ReturnMove(_player);

            //assert
            Assert.That(_player.SkipTurn == 3);
        }
    }
}