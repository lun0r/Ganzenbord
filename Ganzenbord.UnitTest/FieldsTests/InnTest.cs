using NUnit.Framework;
using Ganzenbord;
using System.Threading;

namespace Ganzenbord.UnitTest
{
    [Apartment(ApartmentState.STA)]
    public class InnTest
        //nog testen: of na 1 beurt wel verplaatst
    {
        Player _player;
        Inn _inn;

        [SetUp]
        public void Setup()
        {
            _player = new Player("", "", PawnColor.BLUE);
            _inn = new Inn(1, 1, 1);
        }
        [Test]

        public void ReturnMove_WhenCalled_ReturnCurrentPosition()
        {
            //arrange
            _player.CurrentBoardPosition = 19;

            //act
            int result = _inn.ReturnMove(_player);

            //assert
            Assert.That(19 == result || _player.SkipTurn == 1);
        }

        [Test]
        public void ReturnMove_WhenCalled_SkipFirstTurn()
        {
            //arrange
            _player.CurrentBoardPosition = 19;
            _player.SkipTurn = 0;

            //act
            _inn.ReturnMove(_player);

            //assert
            Assert.That(_player.SkipTurn == 1);
        }
    }
}