using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PlugabilityExample.Plugins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlugabilityExample.Tests
{
    [TestClass]
    public class CalculatorWithLoggingTests
    {
        private Mock<IPlugin> _pluginMock = new();
        private CalculatorWithLogging _calc;
        private IConsoleIO _console;

        [TestInitialize]
        public void TestInitialize()
        {
            _pluginMock = new Mock<IPlugin>();
            _console = new ConsoleIO();
            _calc = new CalculatorWithLogging(_pluginMock.Object, _console);
        }

        [TestMethod]
        public void Compute_CalledOnce()
        {
            _calc.Compute(0, 0);
            _pluginMock.Verify(c => c.Process(It.IsAny<int>(), It.IsAny<int>()), Times.Exactly(1));
        }

        [TestMethod]
        public void Compute_CorrectParamsPassed()
        {
            _calc.Compute(12, 14);
            _pluginMock.Verify(c => c.Process(12, 14), Times.Once);
        }

        [TestMethod]
        public void Compute_CorrectReturnsCorrectValue()
        {
            _pluginMock.Setup(c => c.Process(It.IsAny<int>(), It.IsAny<int>())).Returns(-456789);
            var actual = _calc.Compute(0, 0);

            Assert.AreEqual(actual, -456789);
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void Compute_CorrectReturnsCorrectDivideByZeroException()
        {
            _pluginMock.Setup(c => c.Process(It.IsAny<int>(), It.IsAny<int>())).Throws<DivideByZeroException>();
            _calc.Compute(0, 0);
        }

        [TestMethod]
        public void Compute_CorrectLogging()
        {
            var dividerPluginMock = new Mock<Divider>();
            var calc = new CalculatorWithLogging(dividerPluginMock.Object, _console);
            const int x = 12;
            const int y = 2;
            const int result = 14;
            var expected = $"Calling Divider.Process({x}, {y}) returned {result}";
            var mockConsoleIO = new Mock<IConsoleIO>();


            _pluginMock.Setup(c => c.Process(x, y));
            var actual = _calc.Compute(x, y);

            mockConsoleIO.Verify(t => t.WriteLine(expected), Times.Once());
        }
    }
}
