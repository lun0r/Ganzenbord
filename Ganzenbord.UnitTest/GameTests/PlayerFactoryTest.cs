using NUnit.Framework;
using Ganzenbord;

namespace Ganzenbord.UnitTest
{
    public class PlayerFactoryTests
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
            int result = 0;

            //assert
            Assert.That(result == expectedResult);
        }


    }
}