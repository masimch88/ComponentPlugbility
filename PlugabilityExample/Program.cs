// See https://aka.ms/new-console-template for more information
using PlugabilityExample;
using PlugabilityExample.Plugins;
using PlugabilityExample.Tests;

IPlugin plugin = new Adder();

ILogger consoleLogger = new ConsoleLogger();
ILogger fileLogger = new FileLogger(@"D:\GeeksTest\Logs\log.txt");



Calculator calc = new Calculator(plugin);
CalculatorWithLogging log = new CalculatorWithLogging(plugin );



log.Compute(12, 2);
calc.Compute(12, 2);