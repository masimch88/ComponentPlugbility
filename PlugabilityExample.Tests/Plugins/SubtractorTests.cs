using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlugabilityExample.Plugins;

namespace PlugabilityExample.Tests.Plugins
{
    [TestClass]
    public class SubtractorTests
    {
        [TestMethod]
        public void Process_WhenBothParamtersPositive_SubtractsCorrectly()
        {
            // arrange
            var subtractor =  new Subtractor();

            int x = 15;
            int y = 6;
            int expected = 9;

            // act
            int actual = subtractor.Process(x, y);

            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Process_WhenBothParamtersNegative_SubtractsCorrectly()
        {
            // arrange
            var subtractor = new Subtractor();

            int x = -5;
            int y = -6;
            int expected = 1;

            // act
            int actual = subtractor.Process(x, y);

            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Process_WhenFirstParamterIsNegative_SubtractsCorrectly()
        {
            // arrange
            var subtractor = new Subtractor();

            int x = -5;
            int y = 6;
            int expected = -11;

            // act
            int actual = subtractor.Process(x, y);

            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Process_WhenSecondParamterIsNegative_SubtractsCorrectly()
        {
            // arrange
            var subtractor = new Subtractor();

            int x = 4;
            int y = -2;
            int expected = 6;

            // act
            int actual = subtractor.Process(x, y);

            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Process_WhenFirstParamterHasDefaultValue_ReturnResultWithNegativeSign()
        {
            // arrange
            var subtractor = new Subtractor();

            int x = default;
            int y = 2;
            int expected = -2;

            // act
            int actual = subtractor.Process(x, y);

            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Process_WhenSecondParamterHasDefaultValue_ReturnFirstParameter()
        {
            // arrange
            var subtractor = new Subtractor();

            int x = 25;
            int y = default;
            int expected = 25;

            // act
            int actual = subtractor.Process(x, y);

            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Process_WhenFirstPositiveParamterGreaterThanSecond_SubtractsCorrectly()
        {
            // arrange
            var subtractor = new Subtractor();

            int x = 5;
            int y = 2;
            int expected = 3;

            // act
            int actual = subtractor.Process(x, y);

            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Process_WhenFirstNegativeParamterGreaterThanSecond_SubtractsCorrectly()
        {
            // arrange
            var subtractor = new Subtractor();

            int x = -5;
            int y = 2;
            int expected = -7;

            // act
            int actual = subtractor.Process(x, y);

            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Process_WhenSecondPositiveParamterGreaterThanFirst_SubtractsCorrectly()
        {
            // arrange
            var subtractor = new Subtractor();

            int x = -2;
            int y = 5;
            int expected = -7;

            // act
            int actual = subtractor.Process(x, y);

            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Process_WhenSecondNegativeParamterLessThanFirst_SubtractsCorrectly()
        {
            // arrange
            var subtractor = new Subtractor();

            int x = 2;
            int y = -5;
            int expected = 7;

            // act
            int actual = subtractor.Process(x, y);

            // assert
            Assert.AreEqual(expected, actual);
        }

    }
}
