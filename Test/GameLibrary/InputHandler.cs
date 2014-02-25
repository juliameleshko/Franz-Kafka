namespace GameLibrary
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Input;

    public class InputHandler : Microsoft.Xna.Framework.GameComponent
    {
        public InputHandler(Game game)
            : base(game)
        {
            CurrentKS = Keyboard.GetState();
        }

        public static KeyboardState CurrentKS { get; private set; }

        public static KeyboardState PreviousKS { get; private set; }

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            PreviousKS = CurrentKS;
            CurrentKS = Keyboard.GetState();

            base.Update(gameTime);
        }

        public static void Flush()
        {
            PreviousKS = CurrentKS;
        }

        public static bool KeyReleased(Keys key)
        {
            return CurrentKS.IsKeyUp(key) && PreviousKS.IsKeyDown(key);
        }

        public static bool KeyPressed(Keys key)
        {
            return CurrentKS.IsKeyDown(key) && PreviousKS.IsKeyUp(key);
        }

        public static bool KeyDown(Keys key)
        {
            return CurrentKS.IsKeyDown(key);
        }
    }
}
