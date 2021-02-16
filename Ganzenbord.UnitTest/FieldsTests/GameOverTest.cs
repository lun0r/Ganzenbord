using NUnit.Framework;
using Ganzenbord;
using System.Threading;

namespace Ganzenbord.UnitTest
{
    [Apartment(ApartmentState.STA)]
    public class GameOverTest
    {
        Player _player;
        GameOver _gameOver;

        [SetUp]
        public void Setup()
        {
            _player = new Player("", "", PawnColor.BLUE);
            _gameOver = new GameOver(1, 1, 1);
        }
        [Test]
        public void ReturnMove_WhenCalled_ReturnField63()
        {
            //arrange
            _player.CurrentBoardPosition = 63;
            
            //act
            int result = _gameOver.ReturnMove(_player);

            //assert
            Assert.That(63 == result);
        }
    }
}