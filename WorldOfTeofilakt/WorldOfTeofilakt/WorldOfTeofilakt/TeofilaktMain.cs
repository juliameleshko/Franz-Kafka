using System;

namespace WorldOfTeofilakt
{
#if WINDOWS || XBOX
    static class TeofilaktMain
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (TeofilaktGame game = new TeofilaktGame())
            {
                game.Run();
            }
        }
    }
#endif
}

