namespace PlugabilityExample.Plugins
{
    public class Subtractor : IPlugin
    {
        public int Process(int x, int y)
        {
            return x - y;
        }
    }

    public class Exponenter : IPlugin
    {
        public int Process(int x, int y)
        {
            return (int)Math.Pow(x, y);
        }
    }
}
