using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PlugabilityExample;
using PlugabilityExample.Plugins;
using System;

namespace PlugabilityExample.Tests
{
    [TestClass]
    public class CalculatorTests
    {
        [TestMethod]
        public void Compute_CalledOnce()
        {
            var mp = new MockPlugin(1213);

            var calc = new Calculator(mp);

            calc.Compute(0, 0);

            Assert.AreEqual(1, mp.ProcessMethodCallCount);
        }

        [TestMethod]
        public void Compute_CorrectParamsPassed()
        {
            var mp = new MockPlugin(3342);

            var calc = new Calculator(mp);

            calc.Compute(12, 14);

            Assert.AreEqual(12, mp.X, "Assertion on value of x parameter failed.");
            Assert.AreEqual(14, mp.Y, "Assertion on value of y parameter failed.");
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void Compute_CorrectReturnsCorrectValue()
        {
            var mp = new MockPlugin(-1245656, new DivideByZeroException());
            var calc = new Calculator(mp);

            var actual = calc.Compute(-2, -3);

            Assert.AreEqual(actual, -1245656);
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void Compute_CorrectReturnsCorrectDivideByZeroException()
        {
            var mp = new MockPlugin(-1245656, new DivideByZeroException());
            var calc = new Calculator(mp);
            calc.Compute(-2, -3);
        }

        private class MockPlugin : IPlugin
        {
            private int _returnValue;
            private readonly Exception _ex;

            public MockPlugin(int returnValue, Exception ex = null)
            {
                _returnValue = returnValue;
                _ex = ex;
            }

            public int ProcessMethodCallCount { get; private set; } = 0;

            public int X { get; private set; }

            public int Y { get; private set; }

            public int Process(int x, int y)
            {
                if(_ex !=  null)
                {
                    throw _ex;
                }

                ProcessMethodCallCount++;

                X = x;
                Y = y;

                return _returnValue;
            }
        }
    }

    [TestClass]
    public class CalculatorTestsUsingMockingFramework
    {
        private Mock<IPlugin> _pluginMock = new();
        private Calculator _calc;

        [TestInitialize]
        public void TestInitialize()
        {
            _pluginMock = new Mock<IPlugin>();
            _calc = new Calculator(_pluginMock.Object);
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
    }
}
