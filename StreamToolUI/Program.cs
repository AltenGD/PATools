using osu.Framework;
using osu.Framework.Platform;
using StreamToolUI.Main;

namespace StreamToolUI
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            using (Game game = new StreamGame())
            {
                using (GameHost host = Host.GetSuitableHost("PAStreamTool"))
                {
                    host.Run(game);
                }
            }
        }
    }
}
