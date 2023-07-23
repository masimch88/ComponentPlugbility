namespace PlugabilityExample.Plugins
{
    public class Adder : IPlugin
    {
        public int Process(int x, int y)
        {
            return x + y;
        }
    }
}
