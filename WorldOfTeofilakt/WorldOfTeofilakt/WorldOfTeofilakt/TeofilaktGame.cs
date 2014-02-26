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
using WorldOfTeofilakt.Items;

namespace WorldOfTeofilakt
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class TeofilaktGame : Microsoft.Xna.Framework.Game
    {
        //Screen
        public const int screenWidth = 1024;
        public const int screenHeight = 680;
        public readonly Rectangle ScreenRectangle;

        //Main Charachters
        public const int playerInitialPosX = 450;
        public const int playerInitialPosY = 250;
        public static Hero player;
        public static HomeWork homeWorkInDuel;
        public static IList<Character> activeCharacters;
        public static Boss bgCoder;
        
        //XNA
        GraphicsDeviceManager graphics;
        public SpriteBatch spriteBatch;

        //Mouse
        public MouseState CurrentMouseState { get; set; }
        public MouseState PreviousMouseState { get; set; }
        public Point MousePosition { get; set; }

       
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
            
            //Initiate characters
            player = new Hero("Hero", Content.Load<Texture2D>(@"Characters\ninja_boy_little"),
                                  new Vector2(playerInitialPosX, playerInitialPosY), true, 100);

            bgCoder = new Boss("BGCoder", Content.Load<Texture2D>(@"Characters\BGcoder"),
                               new Vector2(Window.ClientBounds.Width-200, Window.ClientBounds.Height / 2), null);


            activeCharacters = new List<Character>();
            Dictionary<Abilities, int> introHMAbilities = new Dictionary<Abilities, int>();
            introHMAbilities.Add(Abilities.BrainPower, 3);
            introHMAbilities.Add(Abilities.Motivation, 3);
            introHMAbilities.Add(Abilities.Patience, 3);
            introHMAbilities.Add(Abilities.WorkDedication, 3);


            NonPlayerCharacter shopAbilities = new NonPlayerCharacter("Shop of Abilities", Content.Load<Texture2D>(@"Characters\shopicon"),
                               new Vector2(10, 300), NonPlayerCharacterTypes.Shop);

            HomeWork introHW = new HomeWork("Intro HW", Content.Load<Texture2D>(@"Characters\homework1"), new Vector2(500f, 0f), 2, null, Knowledges.IKnowConsole, introHMAbilities);
            HomeWork typesAndVarHW = new HomeWork("Data types and Varaibles", Content.Load<Texture2D>(@"Characters\homework2"), new Vector2(300f, 500f), 2, Knowledges.IKnowConsole, Knowledges.IKnowTypes, introHMAbilities);
            HomeWork operatorsHW = new HomeWork("Operators", Content.Load<Texture2D>(@"Characters\homework3"), new Vector2(50f, 500f), 2, Knowledges.IKnowTypes, Knowledges.IKnowOperators, introHMAbilities);
            HomeWork conditionsHW = new HomeWork("Conditions", Content.Load<Texture2D>(@"Characters\homework4"), new Vector2(200f, 0f), 2, Knowledges.IKnowOperators, Knowledges.IKnowConditions, introHMAbilities);
            HomeWork loopsHW = new HomeWork("Loops", Content.Load<Texture2D>(@"Characters\homework5"), new Vector2(750f, 30f), 2, Knowledges.IKnowConditions, Knowledges.IKnowLoops, introHMAbilities);
            HomeWork classesHW = new HomeWork("Classes", Content.Load<Texture2D>(@"Characters\homework6"), new Vector2(600f, 500f), 2, Knowledges.IKnowLoops, Knowledges.IKnowClasses, introHMAbilities);

            activeCharacters.Add(introHW);
            activeCharacters.Add(typesAndVarHW);
            activeCharacters.Add(operatorsHW);
            activeCharacters.Add(conditionsHW);
            activeCharacters.Add(loopsHW);
            activeCharacters.Add(classesHW);
            activeCharacters.Add(bgCoder);
            activeCharacters.Add(shopAbilities);

            //Initiate screns
            SCREEN_MANAGER.add_screen(new StartMenuScreen(GraphicsDevice,this));
            SCREEN_MANAGER.add_screen(new ChooseHeroScreen(GraphicsDevice, this));
            SCREEN_MANAGER.add_screen(new MapScreen(GraphicsDevice, this));
            SCREEN_MANAGER.add_screen(new ShopScreen(GraphicsDevice, this));
            SCREEN_MANAGER.add_screen(new DuelScreen(GraphicsDevice, this));
            SCREEN_MANAGER.add_screen(new FinalDuelScreen(GraphicsDevice, this));

            SCREEN_MANAGER.goto_screen("StartMenu");
           // SCREEN_MANAGER.goto_screen("Map");


            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

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
