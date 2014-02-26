namespace WorldOfTeofilakt
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    using WorldOfTeofilakt.Controls;
    using WorldOfTeofilakt.Items;

    class ShopScreen : Screen
    {
        private const string titleText = "  HERE YOU CAN BUY ABILITIES\nYour precious TIME units are: ";

        //Fields
        private Color titleTextColor = Color.DarkTurquoise;
        private Vector2 titleTextPosition = new Vector2(320f, 120f);

        private PictureBox brainPowerButton;
        private PictureBox motivationButton;
        private PictureBox patienceButton;
        private PictureBox workDedicationButton;
        private PictureBox goodLuckButton;

        private Texture2D backgroundImage;

        public ShopScreen(GraphicsDevice device, TeofilaktGame game)
            : base(device, game, "Shop")
        { }

        public override bool Init()
        {
            backgroundImage = Game.Content.Load<Texture2D>(@"Backgrounds\shop");
 			
 			Vector2 brainPowerButtonPos = new Vector2(400f, 280f);
            Vector2 motivationButtonPos = new Vector2(brainPowerButtonPos.X, brainPowerButtonPos.Y + 70);
            Vector2 patienceButtonPos = new Vector2(brainPowerButtonPos.X, motivationButtonPos.Y + 70);
            Vector2 workDedicationButtonPos = new Vector2(brainPowerButtonPos.X, patienceButtonPos.Y + 70);
            Vector2 goodLuckButtonButtonPos = new Vector2(brainPowerButtonPos.X - 350, workDedicationButtonPos.Y + 20);

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
            Device.Clear(Color.Black);

            Game.spriteBatch.Begin();

            Game.spriteBatch.Draw(backgroundImage, Game.ScreenRectangle, Color.White);

            //Draw buttons and title
            Game.spriteBatch.DrawString(MenuFont, titleText + TeofilaktGame.player.PreciousTime.ToString(), titleTextPosition, titleTextColor);

            Game.spriteBatch.Draw(brainPowerButton.Image, brainPowerButton.Position, Color.DarkTurquoise);
            Game.spriteBatch.DrawString(MenuFont, TeofilaktGame.player.HeroAbilities[Abilities.BrainPower].ToString(), new Vector2(brainPowerButton.Position.X + brainPowerButton.Image.Width + 40, brainPowerButton.Position.Y), Color.DarkTurquoise);

            Game.spriteBatch.Draw(motivationButton.Image, motivationButton.Position, Color.DarkTurquoise);
            Game.spriteBatch.DrawString(MenuFont, TeofilaktGame.player.HeroAbilities[Abilities.Motivation].ToString(), new Vector2(motivationButton.Position.X + motivationButton.Image.Width + 40, motivationButton.Position.Y), Color.DarkTurquoise);

            Game.spriteBatch.Draw(patienceButton.Image, patienceButton.Position, Color.DarkTurquoise);
            Game.spriteBatch.DrawString(MenuFont, TeofilaktGame.player.HeroAbilities[Abilities.Patience].ToString(), new Vector2(patienceButton.Position.X + patienceButton.Image.Width + 40, patienceButton.Position.Y), Color.DarkTurquoise);

            Game.spriteBatch.Draw(workDedicationButton.Image, workDedicationButton.Position, Color.DarkTurquoise);
            Game.spriteBatch.DrawString(MenuFont, TeofilaktGame.player.HeroAbilities[Abilities.WorkDedication].ToString(), new Vector2(workDedicationButton.Position.X + workDedicationButton.Image.Width + 40, workDedicationButton.Position.Y), Color.DarkTurquoise);

            Game.spriteBatch.Draw(goodLuckButton.Image, goodLuckButton.Position, Color.DarkTurquoise);

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
                if (TeofilaktGame.player.PreciousTime > 0)
                {
                    TeofilaktGame.player.HeroAbilities[Abilities.BrainPower]++;
                    TeofilaktGame.player.PreciousTime--;
                }
            }
            else if (Game.PreviousMouseState.RightButton == ButtonState.Released
                 && Game.CurrentMouseState.RightButton == ButtonState.Pressed
                 && brainPowerButton.SourceRectangle.Contains(Game.MousePosition))
            {
                if (TeofilaktGame.player.HeroAbilities[Abilities.BrainPower] > 0)
                {
                    TeofilaktGame.player.HeroAbilities[Abilities.BrainPower]--;
                    TeofilaktGame.player.PreciousTime++;
                }

            }
            //motivation
            else if (Game.PreviousMouseState.LeftButton == ButtonState.Released
                 && Game.CurrentMouseState.LeftButton == ButtonState.Pressed
                 && motivationButton.SourceRectangle.Contains(Game.MousePosition))
            {
                if (TeofilaktGame.player.PreciousTime > 0)
                {
                    TeofilaktGame.player.HeroAbilities[Abilities.Motivation]++;
                    TeofilaktGame.player.PreciousTime--;
                }
            }

            else if (Game.PreviousMouseState.RightButton == ButtonState.Released
                 && Game.CurrentMouseState.RightButton == ButtonState.Pressed
                 && motivationButton.SourceRectangle.Contains(Game.MousePosition))
            {
                if (TeofilaktGame.player.HeroAbilities[Abilities.Motivation] > 0)
                {
                    TeofilaktGame.player.HeroAbilities[Abilities.Motivation]--;
                    TeofilaktGame.player.PreciousTime++;
                }
            }

            //patience
            else if (Game.PreviousMouseState.LeftButton == ButtonState.Released
                 && Game.CurrentMouseState.LeftButton == ButtonState.Pressed
                 && patienceButton.SourceRectangle.Contains(Game.MousePosition))
            {
                if (TeofilaktGame.player.PreciousTime > 0)
                {
                    TeofilaktGame.player.HeroAbilities[Abilities.Patience]++;
                    TeofilaktGame.player.PreciousTime--;
                }
            }
            else if (Game.PreviousMouseState.RightButton == ButtonState.Released
                 && Game.CurrentMouseState.RightButton == ButtonState.Pressed
                 && patienceButton.SourceRectangle.Contains(Game.MousePosition))
            {
                if (TeofilaktGame.player.HeroAbilities[Abilities.Patience] > 0)
                {
                    TeofilaktGame.player.HeroAbilities[Abilities.Patience]--;
                    TeofilaktGame.player.PreciousTime++;
                }
            }
            //workDedication
            else if (Game.PreviousMouseState.LeftButton == ButtonState.Released
                 && Game.CurrentMouseState.LeftButton == ButtonState.Pressed
                 && workDedicationButton.SourceRectangle.Contains(Game.MousePosition))
            {
                if (TeofilaktGame.player.PreciousTime > 0)
                {
                    TeofilaktGame.player.HeroAbilities[Abilities.WorkDedication]++;
                    TeofilaktGame.player.PreciousTime--;
                }
            }
            else if (Game.PreviousMouseState.RightButton == ButtonState.Released
                 && Game.CurrentMouseState.RightButton == ButtonState.Pressed
                 && workDedicationButton.SourceRectangle.Contains(Game.MousePosition))
            {
                if (TeofilaktGame.player.HeroAbilities[Abilities.WorkDedication] > 0)
                {
                    TeofilaktGame.player.HeroAbilities[Abilities.WorkDedication]--;
                    TeofilaktGame.player.PreciousTime++;
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
