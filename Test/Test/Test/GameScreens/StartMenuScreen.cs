namespace Test.GameScreens
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Input;

    using GameLibrary;

    public class StartMenuScreen : BaseGameState
    {
        public StartMenuScreen(Game game, GameStateManager manager)
            : base(game, manager)
        {
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            if (InputHandler.KeyReleased(Keys.Escape))
            {
                Game.Exit();
            }

            base.Draw(gameTime);
        }
    }
}
