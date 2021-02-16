using NUnit.Framework;
using Ganzenbord;
using System.Collections.Generic;
using System.Threading;

namespace Ganzenbord.UnitTest
{
    [Apartment(ApartmentState.STA)]
    public class DiceTest
    {
        private Dice _dice;

        [SetUp]
        public void Setup()
        {
            _dice = new Dice();
        }

        [Test]
        public void DiceRoll_WhenCalledUpon_ProvidesRandom()
        {
            //arrange

            //act
            int result = _dice.Roll();

            //assert
            Assert.That(result <= 6 || result >= 1);
        }


    }



}