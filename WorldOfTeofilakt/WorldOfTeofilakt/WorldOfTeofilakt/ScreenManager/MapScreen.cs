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

        List<Character> characters = new List<Character>();
        
        public MapScreen(GraphicsDevice device, TeofilaktGame game)
            : base(device, game, "Map")
        {
        }

        public override bool Init()
        {
            
            //TeofilaktGame.player = new Hero("Hero", Game.Content.Load<Texture2D>(@"Characters\ninja_boy_little"),
            //                  new Vector2(Game.Window.ClientBounds.Width / 2, Game.Window.ClientBounds.Height / 2), TeofilaktGame.genderOfPlayer);
            
           

            Enemy homeWork1 = new Enemy(null, Game.Content.Load<Texture2D>(@"Characters\home_work"), new Vector2(30f, 400f));
            Enemy homeWork2 = new Enemy(null, Game.Content.Load<Texture2D>(@"Characters\boss"), new Vector2(300f, 400f));
            Enemy homeWork3 = new Enemy(null, Game.Content.Load<Texture2D>(@"Characters\armor_little"), new Vector2(10f, 300f));
            
            characters.Add(homeWork1);
            characters.Add(homeWork2);
            characters.Add(homeWork3);

            
           // TeofilaktGame.player.HeroKnowledges.Add(Knowledges.IKhowArrays, 1);
          //  TeofilaktGame.player.HeroKnowledges.Add(Knowledges.IKnowLoops, 1);

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

            foreach (var character in characters)
            {
                character.Draw(Game.spriteBatch);
            }


            TeofilaktGame.player.DrawStats(Game.spriteBatch, StatFont, new Vector2(5, 0), Color.White);

            TeofilaktGame.player.Draw(Game.spriteBatch);
           // homeWork1.Draw(_game.spriteBatch);


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

            //while testing go to Start Menu when click with mouse
            if (Game.PreviousMouseState.LeftButton == ButtonState.Released
             && Game.CurrentMouseState.LeftButton == ButtonState.Pressed)
            {

                SCREEN_MANAGER.goto_screen("StartMenu");
   
            }
          
            KeyboardState KS = Keyboard.GetState();

            //Move player
            TeofilaktGame.player.Move(KS);

            //Check for collision with other characters
            foreach (var character in characters)
            {
                bool check = TeofilaktGame.player.CheckCollision(character);

                if (character is Enemy && check)
                {
                    SCREEN_MANAGER.goto_screen("StartMenu");
                    break;
                }
            }

            base.Update(gameTime);
        }
    }
}
