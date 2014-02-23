using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

using WorldOfTeofilakt.CharacterClasses;
using WorldOfTeofilakt.Controls;


namespace WorldOfTeofilakt
{
    public class ChooseHeroScreen : Screen
    {
        private const string chooseText = "CHOOSE GENDER OF HERO!";
        
        //Fields
        private Color chooseTextColor = Color.Yellow;
        private Vector2 chooseTextPosition = new Vector2(280f, 200f);

        private PictureBox maleButton;
        private Vector2 maleButtonPosition = new Vector2(380f, 315f);

        private PictureBox femaleButton;
        private Vector2 femaleButtonPosition = new Vector2(600f, 300f);

        public ChooseHeroScreen(GraphicsDevice device, TeofilaktGame game)
            : base(device, game, "ChooseHero")
        {
        }

        public override bool Init()
        {
            maleButton = new PictureBox(Game.Content.Load<Texture2D>(@"Characters\ninja_boy_little"), maleButtonPosition);
            femaleButton = new PictureBox(Game.Content.Load<Texture2D>(@"Characters\ninja_girl_little"), femaleButtonPosition);
            
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

            Game.spriteBatch.Draw(maleButton.Image, maleButton.Position, Color.White);
            Game.spriteBatch.Draw(femaleButton.Image, femaleButton.Position, Color.White);
            Game.spriteBatch.DrawString(MenuFont, chooseText, chooseTextPosition, chooseTextColor);

            base.Draw(gameTime);

            Game.spriteBatch.End();
        }

        public override void Update(GameTime gameTime)
        {

            if (Game.PreviousMouseState.LeftButton == ButtonState.Released
                 && Game.CurrentMouseState.LeftButton == ButtonState.Pressed
                 && maleButton.SourceRectangle.Contains(Game.MousePosition))
            {

                SCREEN_MANAGER.goto_screen("Map");
                TeofilaktGame.genderOfPlayer = true;
            }
            else if (Game.PreviousMouseState.LeftButton == ButtonState.Released
                 && Game.CurrentMouseState.LeftButton == ButtonState.Pressed
                 && femaleButton.SourceRectangle.Contains(Game.MousePosition))
            {
                SCREEN_MANAGER.goto_screen("Map");
                TeofilaktGame.genderOfPlayer = false;
            }

            base.Update(gameTime);
        }

    }
}
