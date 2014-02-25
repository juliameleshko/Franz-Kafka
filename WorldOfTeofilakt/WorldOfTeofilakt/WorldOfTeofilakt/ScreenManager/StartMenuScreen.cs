using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using WorldOfTeofilakt.Controls;
using Microsoft.Xna.Framework.Content;

namespace WorldOfTeofilakt
{
    class StartMenuScreen : Screen
    {
       
        //Fields
        private MenuComponent menuComponent;
       // private Vector2 logoPosition = new Vector2(150f, 100f);
      //  private Color logoColor = Color.Yellow;
        private Texture2D backgroundImage;

        //Constructors
        public StartMenuScreen(GraphicsDevice device, TeofilaktGame game)
            : base(device, game, "StartMenu")
        {
        }

        public override bool Init()
        {
            backgroundImage = Game.Content.Load<Texture2D>(@"Backgrounds\mainmenu");

            //Start menu
            string[] menuItems = { "Start Game", "Exit Game" };
            menuComponent = new MenuComponent(Game, Game.spriteBatch, Game.Content.Load<SpriteFont>(@"Fonts\menufont"), menuItems);
            Game.Components.Add(menuComponent);

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
            menuComponent.Draw(gameTime);

           // Game.spriteBatch.DrawString(LogoFont, Logo, logoPosition, logoColor);

            

            base.Draw(gameTime);

            Game.spriteBatch.End();
        }

        public override void Update(GameTime gameTime)
        {

            if (Keyboard.GetState().IsKeyDown(Keys.Enter))
                {
                    if (menuComponent.SelectedIndex == 0)
                    {
                        SCREEN_MANAGER.goto_screen("ChooseHero");
                    }
                    if (menuComponent.SelectedIndex == 1)
                    {
                        Game.Exit();
                    }
                }


            base.Update(gameTime);
        }

    }
}


