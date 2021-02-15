﻿using NUnit.Framework;
using Ganzenbord;
using System.Collections.Generic;

namespace Ganzenbord.UnitTest
{
    public class GameTest
    {
        
        private Field _field;

        [SetUp]
        public void Setup()
        {
           
            _field = new Field(1, 1, 1);
        }

        [Test]
        public void Method_WhenCalledUpon_ExpectedResult(int expectedResult)
        {
            //arrange

            //act
            int result;

            //assert
            Assert.That(result == expectedResult);
        }


    }



}