using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlugabilityExample.Plugins;

namespace PlugabilityExample.Tests.Plugins
{
    [TestClass]
    public class MaxFinderTests
    {
        [TestMethod]
        public void Process_WhenFirstParamtersGreater_FindMaximumCorrectly()
        {
            // arrange
            var maxFinder = new MaxFinder();

            int x = 15;
            int y = 6;
            int expected = 15;

            // act
            int actual = maxFinder.Process(x, y);

            // assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Process_WhenSecondParamtersGreater_FindMaximumCorrectly()
        {
            // arrange
            var maxFinder = new MaxFinder();

            int x = 15;
            int y = 16;
            int expected = 16;

            // act
            int actual = maxFinder.Process(x, y);

            // assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Process_WhenBothParamtersPositive_FindMaximumCorrectly()
        {
            // arrange
            var maxFinder =  new MaxFinder();

            int x = 15;
            int y = 6;
            int expected = 15;

            // act
            int actual = maxFinder.Process(x, y);

            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Process_WhenBothParamtersNegative_FindMaximumCorrectly()
        {
            // arrange
            var maxFinder = new MaxFinder();

            int x = -5;
            int y = -6;
            int expected = -5;

            // act
            int actual = maxFinder.Process(x, y);

            // assert
            Assert.AreEqual(expected, actual);
        }
       
                [TestMethod]
                public void Process_WhenFirstParamterIsNegative_FindMaximumCorrectly()
                {
                    // arrange
                    var maxFinder = new MaxFinder();

                    int x = -5;
                    int y = 6;
                    int expected = 6;

                    // act
                    int actual = maxFinder.Process(x, y);

                    // assert
                    Assert.AreEqual(expected, actual);
                }

           [TestMethod]
           public void Process_WhenSecondParamterIsNegative_FindMaximumCorrectly()
           {
               // arrange
               var maxFinder = new MaxFinder();

               int x = 4;
               int y = -2;
               int expected = 4;

               // act
               int actual = maxFinder.Process(x, y);

               // assert
               Assert.AreEqual(expected, actual);
           }
         
           [TestMethod]
           public void Process_WhenFirstParamterHasDefaultValue_ReturnSecondParameter()
           {
               // arrange
               var maxFinder = new MaxFinder();

               int x = default;
               int y = 2;
               int expected = 2;

               // act
               int actual = maxFinder.Process(x, y);

               // assert
               Assert.AreEqual(expected, actual);
           }
       
           [TestMethod]
           public void Process_WhenSecondParamterHasDefaultValue_ReturnFirstParameter()
           {
               // arrange
               var maxFinder = new MaxFinder();

               int x = 25;
               int y = default;
               int expected = 25;

               // act
               int actual = maxFinder.Process(x, y);

               // assert
               Assert.AreEqual(expected, actual);
           }

           [TestMethod]
           public void Process_WhenFirstNegativeParamterLessThanSecond_FindMaximumCorrectly()
           {
               // arrange
               var maxFinder = new MaxFinder();

               int x = -5;
               int y = 2;
               int expected = 2;

               // act
               int actual = maxFinder.Process(x, y);

               // assert
               Assert.AreEqual(expected, actual);
           }

           [TestMethod]
           public void Process_WhenSecondPositiveParamterGreaterThanFirst_FindMaximumCorrectly()
           {
               // arrange
               var maxFinder = new MaxFinder();

               int x = -2;
               int y = 5;
               int expected = 5;

               // act
               int actual = maxFinder.Process(x, y);

               // assert
               Assert.AreEqual(expected, actual);
           }

           [TestMethod]
           public void Process_WhenSecondNegativeParamterLessThanFirst_FindMaximumCorrectly()
           {
               // arrange
               var maxFinder = new MaxFinder();

               int x = 2;
               int y = -5;
               int expected = 2;

               // act
               int actual = maxFinder.Process(x, y);

               // assert
               Assert.AreEqual(expected, actual);
           }

    }
}
