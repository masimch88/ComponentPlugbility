using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlugabilityExample.Plugins;
using System;

namespace PlugabilityExample.Tests.Plugins
{
    [TestClass]
    public class DividerTests
    {
        private Divider _sut;

        [TestInitialize]
        public void TestInitialize()
        {
            _sut = new Divider();
        }

        [TestMethod]
        [DataRow(4, 2, 2, "Divides correctly when both parameters are positive")]
        [DataRow(-4, -2, 2, "Divides correctly when both parameters are negative")]
        [DataRow(-4, 2, -2, "---")]
        [DataRow(4, -2, -2, "---")]
        [DataRow(default, 2, 0, "---")]
        public void Process_DataDrivenTest(int x, int y, int expected, string message)
        {
            // arrange
            // act
            int actual = _sut.Process(x, y);

            // assert
            Assert.AreEqual(expected, actual, $"Assertion that \"{message}\" failed." );
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void Process_WhenSecondParamterHasDefaultValue_ThrowException()
        {
            // arrange
            int x = 5;
            int y = default;

            // act
            _sut.Process(x, y);
        }

    }
}
