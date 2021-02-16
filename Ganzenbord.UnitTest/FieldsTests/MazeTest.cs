using NUnit.Framework;
using Ganzenbord;
using System.Threading;

namespace Ganzenbord.UnitTest
{
    [Apartment(ApartmentState.STA)]
    public class MazeTest
    {
        private Player _player;
        Maze _maze;

        [SetUp]
        public void Setup()
        {
            _maze = new Maze(1, 1, 1);
            _player = new Player("", "", PawnColor.BLUE);
        }
        [Test]
        public void Method_WhenCalled_ExpectedResult()
        {
            //arrange
            _player.CurrentBoardPosition = 42;

            //act
            int result = _maze.ReturnMove(_player);

            //assert
            Assert.That(39 == result);
        }
    }

}