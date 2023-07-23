namespace PlugabilityExample.Plugins
{
    public class Divider : IPlugin
    {
        public int Process(int x, int y)
        {
            return x / y;
        }
    }
}
