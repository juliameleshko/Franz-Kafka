namespace Test.GameScreens
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;

    using GameLibrary;
    using GameLibrary.Controls;

    public abstract partial class BaseGameState : GameState
    {
        protected GameMain gameRef;

        protected ControlManager controlManager;

        protected PlayerIndex playerIndexInControl;

        public BaseGameState(Game game, GameStateManager manager)
            : base(game, manager)
        {
            gameRef = (GameMain)game;

            playerIndexInControl = PlayerIndex.One;
        }

        protected override void LoadContent()
        {
            ContentManager Content = Game.Content;

            SpriteFont menuFont = Content.Load<SpriteFont>(@"Fonts\ControlFont");
            controlManager = new ControlManager(menuFont);

            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }
}
