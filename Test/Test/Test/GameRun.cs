using System;

namespace Test
{
#if WINDOWS || XBOX
    static class GameRun
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            using (GameMain game = new GameMain())
            {
                game.Run();
            }
        }
    }
#endif
}

