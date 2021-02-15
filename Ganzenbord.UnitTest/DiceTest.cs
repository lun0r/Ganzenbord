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


    public class FieldTest
    {
        Player _player;
        Field9 _field;

        [SetUp]
        public void Setup()
        {
            _player = new Player("", "", PawnColor.BLUE);
            _field = new Field9(1, 1, 1);
        }
        [TestCase(1, 1, false, 10, 20)]
        public void Method_WhenCalledUpon_ExpectedResult(int dice1, int dice2, bool isReversed, int currentBoardPosition, int expectedResult)
        {
            //arrange
            _player.Dice1 = dice1;
            _player.Dice2 = dice2;
            _player.CurrentBoardPosition = currentBoardPosition;
            _player.IsReversed = isReversed;

            //act
            int result = _field.ReturnMove(_player);

            //assert
            Assert.That(result == expectedResult);
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
        [TestCase(1,1,false,10,20)]
        public void Method_WhenCalledUpon_ExpectedResult(int dice1, int dice2, bool isReversed, int currentBoardPosition, int expectedResult)
        {
            //arrange
            _player.Dice1 = dice1;
            _player.Dice2 = dice2;
            _player.CurrentBoardPosition = currentBoardPosition;
            _player.IsReversed = isReversed;

            //act
            int result = _field9.ReturnMove(_player);

            //assert
            Assert.That(result == expectedResult);
        }
    }

    public class BridgeTest
    {
        Player _player;
        Field9 _bridge;

        [SetUp]
        public void Setup()
        {
            _player = new Player("", "", PawnColor.BLUE);
            _bridge = new Field9(1, 1, 1);
        }
        [TestCase(1, 1, false, 10, 20)]
        public void Method_WhenCalledUpon_ExpectedResult(int dice1, int dice2, bool isReversed, int currentBoardPosition, int expectedResult)
        {
            //arrange
            _player.Dice1 = dice1;
            _player.Dice2 = dice2;
            _player.CurrentBoardPosition = currentBoardPosition;
            _player.IsReversed = isReversed;

            //act
            int result = _bridge.ReturnMove(_player);

            //assert
            Assert.That(result == expectedResult);
        }
    }
    public class DeathTest
    {
        Player _player;
        Field9 _death;

        [SetUp]
        public void Setup()
        {
            _player = new Player("", "", PawnColor.BLUE);
            _death = new Field9(1, 1, 1);
        }
        [TestCase(1, 1, false, 10, 20)]
        public void Method_WhenCalledUpon_ExpectedResult(int dice1, int dice2, bool isReversed, int currentBoardPosition, int expectedResult)
        {
            //arrange
            _player.Dice1 = dice1;
            _player.Dice2 = dice2;
            _player.CurrentBoardPosition = currentBoardPosition;
            _player.IsReversed = isReversed;

            //act
            int result = _death.ReturnMove(_player);

            //assert
            Assert.That(result == expectedResult);
        }
    }
   
    public class InnTest
    {
        Player _player;
        Field9 _inn;

        [SetUp]
        public void Setup()
        {
            _player = new Player("", "", PawnColor.BLUE);
            _inn = new Field9(1, 1, 1);
        }
        [TestCase(1, 1, false, 10, 20)]
        public void Method_WhenCalledUpon_ExpectedResult(int dice1, int dice2, bool isReversed, int currentBoardPosition, int expectedResult)
        {
            //arrange
            _player.Dice1 = dice1;
            _player.Dice2 = dice2;
            _player.CurrentBoardPosition = currentBoardPosition;
            _player.IsReversed = isReversed;

            //act
            int result = _inn.ReturnMove(_player);

            //assert
            Assert.That(result == expectedResult);
        }
    }
    public class MazeTest
    {
        Player _player;
        Field9 _maze;

        [SetUp]
        public void Setup()
        {
            _player = new Player("", "", PawnColor.BLUE);
            _maze = new Field9(1, 1, 1);
        }
        [TestCase(1, 1, false, 10, 20)]
        public void Method_WhenCalledUpon_ExpectedResult(int dice1, int dice2, bool isReversed, int currentBoardPosition, int expectedResult)
        {
            //arrange
            _player.Dice1 = dice1;
            _player.Dice2 = dice2;
            _player.CurrentBoardPosition = currentBoardPosition;
            _player.IsReversed = isReversed;

            //act
            int result = _maze.ReturnMove(_player);

            //assert
            Assert.That(result == expectedResult);
        }
    }

    public class PrisonTest
    {
        Player _player;
        Field9 _prison;

        [SetUp]
        public void Setup()
        {
            _player = new Player("", "", PawnColor.BLUE);
            _prison = new Field9(1, 1, 1);
        }
        [TestCase(1, 1, false, 10, 20)]
        public void Method_WhenCalledUpon_ExpectedResult(int dice1, int dice2, bool isReversed, int currentBoardPosition, int expectedResult)
        {
            //arrange
            _player.Dice1 = dice1;
            _player.Dice2 = dice2;
            _player.CurrentBoardPosition = currentBoardPosition;
            _player.IsReversed = isReversed;

            //act
            int result = _prison.ReturnMove(_player);

            //assert
            Assert.That(result == expectedResult);
        }
    }
    public class WellTest
    {
        Player _player;
        Field9 _well;

        [SetUp]
        public void Setup()
        {
            _player = new Player("", "", PawnColor.BLUE);
            _well = new Field9(1, 1, 1);
        }
        [TestCase(1, 1, false, 10, 20)]
        public void Method_WhenCalledUpon_ExpectedResult(int dice1, int dice2, bool isReversed, int currentBoardPosition, int expectedResult)
        {
            //arrange
            _player.Dice1 = dice1;
            _player.Dice2 = dice2;
            _player.CurrentBoardPosition = currentBoardPosition;
            _player.IsReversed = isReversed;

            //act
            int result = _well.ReturnMove(_player);

            //assert
            Assert.That(result == expectedResult);
        }
    }
    public class GameOverTest
    {
        Player _player;
        Field9 _gameOver;

        [SetUp]
        public void Setup()
        {
            _player = new Player("", "", PawnColor.BLUE);
            _gameOver = new Field9(1, 1, 1);
        }
        [TestCase(1, 1, false, 10, 20)]
        public void Method_WhenCalledUpon_ExpectedResult(int dice1, int dice2, bool isReversed, int currentBoardPosition, int expectedResult)
        {
            //arrange
            _player.Dice1 = dice1;
            _player.Dice2 = dice2;
            _player.CurrentBoardPosition = currentBoardPosition;
            _player.IsReversed = isReversed;

            //act
            int result = _gameOver.ReturnMove(_player);

            //assert
            Assert.That(result == expectedResult);
        }
    }
}