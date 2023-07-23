namespace PlugabilityExample.Plugins
{
    public class MaxFinder : IPlugin
    {
        public int Process(int x, int y)
        {
            if (x > y)
            {
                return x;
            }
            else
            {
                return y;
            }
        }
    }
}
