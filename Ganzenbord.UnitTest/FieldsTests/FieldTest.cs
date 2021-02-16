using NUnit.Framework;
using Ganzenbord;
using System.Threading;

namespace Ganzenbord.UnitTest
{
    [Apartment(ApartmentState.STA)]
    public class FieldTest
    {
        Player _player;
        Field _field;

        [SetUp]
        public void Setup()
        {
            _player = new Player("", "", PawnColor.BLUE);
            _field = new Field(1, 1, 1);
        }
        [TestCase(5, 5)]
        [TestCase(7, 7)]
        public void ReturnMove_WhenCalled_ReturnCurrentPosition(int currentBoardPosition, int expectedResult)
        {
            //arrange
          
            _player.CurrentBoardPosition = currentBoardPosition;
            

            //act
            int result = _field.ReturnMove(_player);

            //assert
            Assert.That(expectedResult == result);
        }
    }

}