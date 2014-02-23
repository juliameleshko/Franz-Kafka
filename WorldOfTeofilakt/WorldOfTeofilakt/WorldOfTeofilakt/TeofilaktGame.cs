using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using WorldOfTeofilakt.CharacterClasses;

namespace WorldOfTeofilakt
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class TeofilaktGame : Microsoft.Xna.Framework.Game
    {
        public static Hero player;
        public static bool genderOfPlayer;
        
        GraphicsDeviceManager graphics;
        public SpriteBatch spriteBatch;
        
        //MenuComponent menuComponent;

        public MouseState CurrentMouseState { get; set; }
        public MouseState PreviousMouseState { get; set; }
        public Point MousePosition { get; set; }

        const int screenWidth = 1024;
        const int screenHeight = 680;
        public readonly Rectangle ScreenRectangle;

        public TeofilaktGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferWidth = screenWidth;
            graphics.PreferredBackBufferHeight = screenHeight;

            ScreenRectangle = new Rectangle(
                0,
                0,
                screenWidth,
                screenHeight);
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            
            SCREEN_MANAGER.add_screen(new StartMenuScreen(GraphicsDevice,this));
            SCREEN_MANAGER.add_screen(new ChooseHeroScreen(GraphicsDevice, this));
            SCREEN_MANAGER.add_screen(new MapScreen(GraphicsDevice, this));

            SCREEN_MANAGER.goto_screen("StartMenu");


            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            //string[] menuItems = { "Start Game", "High Scores", "End Game" };
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

          //  menuComponent = new MenuComponent(this,spriteBatch,Content.Load<SpriteFont>("menufont"),menuItems);
          //  Components.Add(menuComponent);
            SCREEN_MANAGER.Init();

            CurrentMouseState = Mouse.GetState();
            PreviousMouseState = CurrentMouseState;

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {

            PreviousMouseState = CurrentMouseState;
            CurrentMouseState = Mouse.GetState();
            MousePosition = new Point(CurrentMouseState.X, CurrentMouseState.Y);
  
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here
          SCREEN_MANAGER.Update(gameTime);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
             SCREEN_MANAGER.Draw(gameTime);
            this.IsMouseVisible = true;
           
          //  spriteBatch.Begin();
         //   base.Draw(gameTime);
         //   spriteBatch.End();

        }
    }
}
