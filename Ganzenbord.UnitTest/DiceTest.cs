using NUnit.Framework;
using Ganzenbord;
using System.Collections.Generic;

namespace Ganzenbord.UnitTest
{
    public class DiceTest
    {
        private Dice _dice;
        private Field _field;

        [SetUp]
        public void Setup()
        {
            _dice = new Dice();
            _field = new Field(1, 1, 1);
        }

        [Test]
        public void DiceRoll_WhenCalledUpon_ProvidesRandom()
        {
            int result = _dice.Roll();

            Assert.That(result <= 6 || result >= 1);
        }


    }

    public class GooseTest
    {
        Player _player;
        Goose _goose;


        [SetUp]
        public void Setup()
        {
            _player = new Player("","",PawnColor.BLUE);
           
            _goose = new Goose(1,1,1);
            
        }

        [TestCase(5,5,false,10,20)]
        public void ReturnMove_WhenCalledUpon_ProvidesNewPosition(int dice1, int dice2, bool isReversed, int currentBoardPosition, int expectedResult )
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