using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlugabilityExample.Plugins;

namespace PlugabilityExample.Tests.Plugins
{
    [TestClass]
    public class AdderTests
    {
        [TestMethod]
        public void Process_WhenBothParamtersPositive_AddsCorrectly()
        {
            // arrange
            var adder =  new Adder();

            int x = 5;
            int y = 6;
            int expected = 11;

            // act
            int actual = adder.Process(x, y);

            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Process_WhenBothParamtersNegative_AddsCorrectly()
        {
            // arrange
            var adder = new Adder();

            int x = -5;
            int y = -6;
            int expected = -11;

            // act
            int actual = adder.Process(x, y);

            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Process_WhenFirstParamterIsNegative_AddsCorrectly()
        {
            // arrange
            var adder = new Adder();

            int x = -5;
            int y = 6;
            int expected = 1;

            // act
            int actual = adder.Process(x, y);

            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Process_WhenSecondParamterIsNegative_AddsCorrectly()
        {
            // arrange
            var adder = new Adder();

            int x = 5;
            int y = -6;
            int expected = -1;

            // act
            int actual = adder.Process(x, y);

            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Process_WhenFirstParamterHasDefaultValue_ReturnSecondParameter()
        {
            // arrange
            var adder = new Adder();

            int x = default;
            int y = 6;
            int expected = 6;

            // act
            int actual = adder.Process(x, y);

            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Process_WhenSecondParamterHasDefaultValue_ReturnFirstParameter()
        {
            // arrange
            var adder = new Adder();

            int x = 5;
            int y = default;
            int expected = 5;

            // act
            int actual = adder.Process(x, y);

            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Process_WhenFirstPositiveParamterGreaterThanSecond_AddsCorrectly()
        {
            // arrange
            var adder = new Adder();

            int x = 5;
            int y = 2;
            int expected = 7;

            // act
            int actual = adder.Process(x, y);

            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Process_WhenFirstNegativeParamterGreaterThanSecond_AddsCorrectly()
        {
            // arrange
            var adder = new Adder();

            int x = -5;
            int y = 2;
            int expected = -3;

            // act
            int actual = adder.Process(x, y);

            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Process_WhenSecondPositiveParamterGreaterThanFirst_AddsCorrectly()
        {
            // arrange
            var adder = new Adder();

            int x = 2;
            int y = 5;
            int expected = 7;

            // act
            int actual = adder.Process(x, y);

            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Process_WhenSecondNegativeParamterGreaterThanSecond_AddsCorrectly()
        {
            // arrange
            var adder = new Adder();

            int x = 2;
            int y = -5;
            int expected = -3;

            // act
            int actual = adder.Process(x, y);

            // assert
            Assert.AreEqual(expected, actual);
        }

    }
}
