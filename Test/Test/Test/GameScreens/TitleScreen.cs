namespace Test.GameScreens
{
    using System;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;

    using GameLibrary;
    using GameLibrary.Controls;

    public class TitleScreen : BaseGameState
    {
        Texture2D backgroundImage;
        LinkLabel startLabel;

        public TitleScreen(Game game, GameStateManager manager)
            : base(game, manager)
        {
        }

        protected override void LoadContent()
        {
            ContentManager Content = gameRef.Content;

            backgroundImage = Content.Load<Texture2D>(@"Backgrounds\mainmenu");
            
            base.LoadContent();

            startLabel = new LinkLabel();
            startLabel.Position = new Vector2(350, 600);
            startLabel.Text = "Press ENTER to begin";
            startLabel.Color = Color.White;
            startLabel.TabStop = true;
            startLabel.HasFocus = true;
            startLabel.Selected += new EventHandler(startLabel_Selected);

            controlManager.Add(startLabel);
        }

        public override void Update(GameTime gameTime)
        {
            controlManager.Update(gameTime, PlayerIndex.One);

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            gameRef.SpriteBatch.Begin();

            base.Draw(gameTime);

            gameRef.SpriteBatch.Draw(backgroundImage, gameRef.ScreenRectangle, Color.White);

            controlManager.Draw(gameRef.SpriteBatch);

            gameRef.SpriteBatch.End();
        }

        private void startLabel_Selected(object sender, EventArgs e)
        {
            this.StateManager.PushState(gameRef.StartMenuScreen);
        }
    }
}
