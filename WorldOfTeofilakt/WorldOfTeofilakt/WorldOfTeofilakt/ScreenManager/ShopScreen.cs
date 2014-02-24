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
    class ShopScreen : Screen
    {
        private const string titleText = "  HERE YOU CAN BUY ABILITIES\nYour precious TIME units are: ";

        //Fields
        private Color titleTextColor = Color.White;
        private Vector2 titleTextPosition = new Vector2(200f, 50f);

        private PictureBox brainPowerButton;
        private PictureBox motivationButton;
        private PictureBox patienceButton;
        private PictureBox workDedicationButton;
        private PictureBox goodLuckButton;

        public ShopScreen(GraphicsDevice device, TeofilaktGame game)
            : base(device, game, "Shop")
        {
        }

        public override bool Init()
        {
            Vector2 brainPowerButtonPos = new Vector2(400f, 200f);
            Vector2 motivationButtonPos = new Vector2(brainPowerButtonPos.X, brainPowerButtonPos.Y + 70);
            Vector2 patienceButtonPos = new Vector2(brainPowerButtonPos.X, motivationButtonPos.Y + 70);
            Vector2 workDedicationButtonPos = new Vector2(brainPowerButtonPos.X, patienceButtonPos.Y + 70);
            Vector2 goodLuckButtonButtonPos = new Vector2(brainPowerButtonPos.X, workDedicationButtonPos.Y + 100);

            brainPowerButton = new PictureBox(Game.Content.Load<Texture2D>(@"Controls\BrainPower"), brainPowerButtonPos);
            motivationButton = new PictureBox(Game.Content.Load<Texture2D>(@"Controls\Motivation"), motivationButtonPos);
            patienceButton = new PictureBox(Game.Content.Load<Texture2D>(@"Controls\Patience"), patienceButtonPos);
            workDedicationButton = new PictureBox(Game.Content.Load<Texture2D>(@"Controls\WorkDedication"), workDedicationButtonPos);
            goodLuckButton = new PictureBox(Game.Content.Load<Texture2D>(@"Controls\GoodLuck"), goodLuckButtonButtonPos);
            
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

            //Draw buttons and title
            Game.spriteBatch.DrawString(MenuFont, titleText + TeofilaktGame.playerTime.ToString(), titleTextPosition, titleTextColor);
           
            Game.spriteBatch.Draw(brainPowerButton.Image, brainPowerButton.Position, Color.White);
            Game.spriteBatch.DrawString(MenuFont, TeofilaktGame.brainPower.ToString(), new Vector2(brainPowerButton.Position.X + brainPowerButton.Image.Width + 40, brainPowerButton.Position.Y), Color.White);

            Game.spriteBatch.Draw(motivationButton.Image, motivationButton.Position, Color.White);
            Game.spriteBatch.DrawString(MenuFont, TeofilaktGame.motivation.ToString(), new Vector2(motivationButton.Position.X + motivationButton.Image.Width + 40, motivationButton.Position.Y), Color.White);

            Game.spriteBatch.Draw(patienceButton.Image, patienceButton.Position, Color.White);
            Game.spriteBatch.DrawString(MenuFont, TeofilaktGame.patience.ToString(), new Vector2(patienceButton.Position.X + patienceButton.Image.Width + 40, patienceButton.Position.Y), Color.White);

            Game.spriteBatch.Draw(workDedicationButton.Image, workDedicationButton.Position, Color.White);
            Game.spriteBatch.DrawString(MenuFont, TeofilaktGame.workDedication.ToString(), new Vector2(workDedicationButton.Position.X + workDedicationButton.Image.Width + 40, workDedicationButton.Position.Y), Color.White);

            Game.spriteBatch.Draw(goodLuckButton.Image, goodLuckButton.Position, Color.White);

            base.Draw(gameTime);

            Game.spriteBatch.End();
        }

        public override void Update(GameTime gameTime)
        {

            //Change Abilities value
            //brain power
            if (Game.PreviousMouseState.LeftButton == ButtonState.Released
                 && Game.CurrentMouseState.LeftButton == ButtonState.Pressed
                 && brainPowerButton.SourceRectangle.Contains(Game.MousePosition))
            {
                if (TeofilaktGame.playerTime > 0)
                {
                    TeofilaktGame.brainPower++;
                    TeofilaktGame.playerTime--;
                }
            }
            else if (Game.PreviousMouseState.RightButton == ButtonState.Released
                 && Game.CurrentMouseState.RightButton == ButtonState.Pressed
                 && brainPowerButton.SourceRectangle.Contains(Game.MousePosition))
            {
                if (TeofilaktGame.brainPower > 0)
                {
                    TeofilaktGame.brainPower--;
                    TeofilaktGame.playerTime++;
                }

            }
            //motivation
            else if (Game.PreviousMouseState.LeftButton == ButtonState.Released
                 && Game.CurrentMouseState.LeftButton == ButtonState.Pressed
                 && motivationButton.SourceRectangle.Contains(Game.MousePosition))
            {
                if (TeofilaktGame.playerTime > 0)
                {
                    TeofilaktGame.motivation++;
                    TeofilaktGame.playerTime--;
                }
            }

            else if (Game.PreviousMouseState.RightButton == ButtonState.Released
                 && Game.CurrentMouseState.RightButton == ButtonState.Pressed
                 && motivationButton.SourceRectangle.Contains(Game.MousePosition))
            {
                if (TeofilaktGame.motivation > 0)
                {
                    TeofilaktGame.motivation--;
                    TeofilaktGame.playerTime++;
                }
            }

            //patience
            else if (Game.PreviousMouseState.LeftButton == ButtonState.Released
                 && Game.CurrentMouseState.LeftButton == ButtonState.Pressed
                 && patienceButton.SourceRectangle.Contains(Game.MousePosition))
            {
                if (TeofilaktGame.playerTime > 0)
                {
                    TeofilaktGame.patience++;
                    TeofilaktGame.playerTime--;
                }
            }
            else if (Game.PreviousMouseState.RightButton == ButtonState.Released
                 && Game.CurrentMouseState.RightButton == ButtonState.Pressed
                 && patienceButton.SourceRectangle.Contains(Game.MousePosition))
            {
                if (TeofilaktGame.patience > 0)
                {
                    TeofilaktGame.patience--;
                    TeofilaktGame.playerTime++;
                }
            }
            //workDedication
            else if (Game.PreviousMouseState.LeftButton == ButtonState.Released
                 && Game.CurrentMouseState.LeftButton == ButtonState.Pressed
                 && workDedicationButton.SourceRectangle.Contains(Game.MousePosition))
            {
                if (TeofilaktGame.playerTime > 0)
                {
                    TeofilaktGame.workDedication++;
                    TeofilaktGame.playerTime--;
                }
            }
            else if (Game.PreviousMouseState.RightButton == ButtonState.Released
                 && Game.CurrentMouseState.RightButton == ButtonState.Pressed
                 && workDedicationButton.SourceRectangle.Contains(Game.MousePosition))
            {
                if (TeofilaktGame.workDedication > 0)
                {
                    TeofilaktGame.workDedication--;
                    TeofilaktGame.playerTime++;
                }
            }
            else if (Game.PreviousMouseState.LeftButton == ButtonState.Released
                 && Game.CurrentMouseState.LeftButton == ButtonState.Pressed
                 && goodLuckButton.SourceRectangle.Contains(Game.MousePosition))
            {

                SCREEN_MANAGER.goto_screen("Map");
                
            }


            base.Update(gameTime);
        }




    }
}
