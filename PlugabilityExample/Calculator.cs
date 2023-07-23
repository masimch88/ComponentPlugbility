using PlugabilityExample.Plugins;

namespace PlugabilityExample
{
    public class Calculator
    {
        protected readonly IPlugin _plugin;

        public Calculator(IPlugin plugin)
        {
            _plugin = plugin;
        }

        public virtual int Compute(int x, int y)
        {
            return _plugin.Process(x, y);
        }
    }
}
