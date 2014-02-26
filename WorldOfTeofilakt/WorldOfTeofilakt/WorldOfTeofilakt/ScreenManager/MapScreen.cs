using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

using WorldOfTeofilakt.CharacterClasses;
using WorldOfTeofilakt.Items;

namespace WorldOfTeofilakt
{
    public class MapScreen : Screen
    {
        private Texture2D backgroundImage;
        
        public MapScreen(GraphicsDevice device, TeofilaktGame game)
            : base(device, game, "Map")
        {
        }

        public override bool Init()
        {
            backgroundImage = Game.Content.Load<Texture2D>(@"Backgrounds\gamebackground");

            return base.Init();
        }

        public override void Shutdown()
        {
            base.Shutdown();
        }

        public override void Draw(GameTime gameTime)
        {
            Device.Clear(Color.Coral);

            Game.spriteBatch.Begin();

            Game.spriteBatch.Draw(backgroundImage, Game.ScreenRectangle, Color.White);

            foreach (var character in TeofilaktGame.activeCharacters)
            {
                if (character.IsActive)
                {
                    character.Draw(Game.spriteBatch); 
                }
                
            }

            TeofilaktGame.player.DrawStats(Game.spriteBatch, StatFont, new Vector2(5, 0), Color.White);
            TeofilaktGame.player.Draw(Game.spriteBatch);


            Game.spriteBatch.End();

            base.Draw(gameTime);
        }

        public override void Update(GameTime gameTime)
        {

            //Set image of player depending on gender
            if (TeofilaktGame.player.IsMale)
            {
                TeofilaktGame.player.Image = Game.Content.Load<Texture2D>(@"Characters\ninja_boy_little");

            }
            else
            {
                TeofilaktGame.player.Image = Game.Content.Load<Texture2D>(@"Characters\ninja_girl_little");
            }

            //Move player
            KeyboardState KS = Keyboard.GetState();            
            TeofilaktGame.player.Move(KS);

            //Check for collision with other characters
            foreach (var character in TeofilaktGame.activeCharacters)
            {
                bool check = TeofilaktGame.player.CheckCollision(character);
              
                if (character is Enemy && check && character.IsActive)
                {
                    
                    if (character is HomeWork)
                    {
                        TeofilaktGame.homeWorkInDuel = (HomeWork)character;
                        SCREEN_MANAGER.goto_screen("Duel");
                    }
                    else if (character is Boss)
                    {
                        SCREEN_MANAGER.goto_screen("FinalDuel");
                    }
                                    
                    
                    TeofilaktGame.player.Position = new Vector2(5, 300);
                    break;
                }
            }

            if (Game.PreviousMouseState.LeftButton == ButtonState.Released
                  && Game.CurrentMouseState.LeftButton == ButtonState.Pressed
                 )
            {
                SCREEN_MANAGER.goto_screen("Shop");

            }
            base.Update(gameTime);
        }
    }
}
