using NUnit.Framework;
using Ganzenbord;
using System.Threading;

namespace Ganzenbord.UnitTest
{
    [Apartment(ApartmentState.STA)]
    public class Field9Test
    {
        Player _player;
        Field9 _field9;

        [SetUp]
        public void Setup()
        {
            _player = new Player("", "", PawnColor.BLUE);
            _field9 = new Field9(1, 1, 1);
        }
        [TestCase(6, 3, false, 53)]
        [TestCase(5, 4, false, 26)]
        [TestCase(5, 4, true, 18)]
        [TestCase(1, 1, true, 11)]
        public void Method_WhenCalledUpon_ExpectedResult(int dice1, int dice2, bool hasDied, int expectedResult)
        {
            //arrange
            _player.Dice1 = dice1;
            _player.Dice2 = dice2;
            _player.HasDied = hasDied;
            _player.CurrentBoardPosition = 9;

            //act
            int result = _field9.ReturnMove(_player);

            //assert
            Assert.That(expectedResult == result);
        }
    }
}