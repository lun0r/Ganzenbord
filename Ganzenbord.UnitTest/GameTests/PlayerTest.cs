using NUnit.Framework;
using Ganzenbord;

namespace Ganzenbord.UnitTest
{
    public class PlayerTests
    {
        private Player _player;

        [SetUp]
        public void Setup()
        {
            _player = new Player("TestPlayer", null, PawnColor.GREEN);
        }

        [TestCase(60, 60)]
        [TestCase(65, 61)]
        public void Move_WhenCalled_ChangeCurrentPosition(int NewPosition, int expectedResult)
        {
            _player.Move(NewPosition);
            int result = _player.CurrentBoardPosition;

            Assert.That(result == expectedResult);
        }

        [TestCase(75, true)]
        public void Move_WhenCalledAndReversed_ChangeCurrentPosition(int NewPosition, bool expectedresult)
        {
            _player.IsReversed = true;
            _player.Move(NewPosition);

            Assert.That(expectedresult);
        }
    }
}