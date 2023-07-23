using PlugabilityExample.Plugins;
using PlugabilityExample.Tests;
using System;

namespace PlugabilityExample
{
    public class CalculatorWithLogging : Calculator
    {
        private readonly ILogger[] _loggers;
        public CalculatorWithLogging(IPlugin plugin, params ILogger[] logger) : base(plugin)
{
            _loggers = logger;
        }

        public override int Compute(int x, int y)
        {
            int result = _plugin.Process(x, y);

            foreach(var logger in _loggers)
            {
                logger.Log($"Calling {_plugin.GetType().Name}.Process({x}, {y}) returned {result}");
            }

            return result;
        }
    }
}
