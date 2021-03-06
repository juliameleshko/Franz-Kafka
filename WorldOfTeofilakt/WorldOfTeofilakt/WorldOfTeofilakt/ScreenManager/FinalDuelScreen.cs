﻿namespace WorldOfTeofilakt
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using WorldOfTeofilakt.Controls;

    public class FinalDuelScreen : Screen
    {

        private const string titleText = "";

        //Fields
        private Color titleTextColor = Color.White;
        private Vector2 titleTextPosition = new Vector2(200f, 50f);

        private PictureBox yesButton;
        private PictureBox noButton;

        private Texture2D backgroundImage;

        public FinalDuelScreen(GraphicsDevice device, TeofilaktGame game)
            : base(device, game, "FinalDuel")
        { }

        public override bool Init()
        {
            backgroundImage = Game.Content.Load<Texture2D>(@"Backgrounds\finalduelscreen");

            //Vector2 yesButtonPos = new Vector2(400f, 200f);
            //yesButton = new PictureBox(Game.Content.Load<Texture2D>(@"Controls\Yes"), yesButtonPos);
            //Vector2 noButtonPos = new Vector2(600f, 200f);
            //noButton = new PictureBox(Game.Content.Load<Texture2D>(@"Controls\No"), noButtonPos);

            return base.Init();
        }

        public override void Shutdown()
        {
            base.Shutdown();
        }

        public override void Draw(GameTime gameTime)
        {
            Device.Clear(Color.LightGreen);

            Game.spriteBatch.Begin();

            Game.spriteBatch.Draw(backgroundImage, Game.ScreenRectangle, Color.White);

            //Draw
            TeofilaktGame.player.DrawStats(Game.spriteBatch, StatFont, new Vector2(5, 0), Color.White);
          //  TeofilaktGame.homeWorkInDuel.DrawStats(Game.spriteBatch, StatFont, new Vector2(400, 0), Color.White);
          //  Game.spriteBatch.Draw(yesButton.Image, yesButton.Position, Color.White);
          //  Game.spriteBatch.Draw(noButton.Image, noButton.Position, Color.White);

            base.Draw(gameTime);

            Game.spriteBatch.End();
        }

        public override void Update(GameTime gameTime)
        {

            ////Login when press Yes button
            //if (Game.PreviousMouseState.LeftButton == ButtonState.Released
            //     && Game.CurrentMouseState.LeftButton == ButtonState.Pressed
            //     && yesButton.SourceRectangle.Contains(Game.MousePosition))
            //{

            //    TeofilaktGame.player.DuelWithHomeWork(TeofilaktGame.homeWorkInDuel);

            //    SCREEN_MANAGER.goto_screen("Map");
            //}
            ////Logic button NO
            //else if (Game.PreviousMouseState.LeftButton == ButtonState.Released
            //     && Game.CurrentMouseState.LeftButton == ButtonState.Pressed
            //     && noButton.SourceRectangle.Contains(Game.MousePosition))
            //{

            //    SCREEN_MANAGER.goto_screen("Map");

            //}

            base.Update(gameTime);
        }
    }
}
