using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WorldOfTeofilakt
{
    public class Screen
    {
        public const string Logo = "WORLD OF TEOFILAKT";

        private SpriteFont logoFont;
        private SpriteFont menuFont;
        
        /// <summary>
        /// Screen Constructor
        /// </summary>
        /// <param name="name">Must be unique since when you use ScreenManager is per name</param>
        public Screen(GraphicsDevice device, TeofilaktGame game, string name )
        {
            Name = name;
            Device = device;
            this.Game = game;
        }

        ~Screen()
        {
        }

        public string Name { get; set; }
        protected GraphicsDevice Device { get; set; }
        protected TeofilaktGame Game { get; set; }
        protected SpriteFont sfStandart { get; set; }
        protected SpriteFont MenuFont
        {
            get { return menuFont; }
            private set { menuFont = value; }
        }

        protected SpriteFont LogoFont
        {
            get { return logoFont; }
            private set { logoFont = value; }
        }
        

        /// <summary>
        /// Virtual Function that's called when entering a Screen
        /// override it and add your own initialization code
        /// </summary>
        /// <returns></returns>
        public virtual bool Init()
        {
            LogoFont = Game.Content.Load<SpriteFont>(@"Fonts\logofont");
            MenuFont = Game.Content.Load<SpriteFont>(@"Fonts\menufont");
            return true;
        }

        /// <summary>
        /// Virtual Function that's called when exiting a Screen
        /// override it and add your own shutdown code
        /// </summary>
        /// <returns></returns>
        public virtual void Shutdown()
        {
        }

        /// <summary>
        /// Override it to have access to elapsed time
        /// </summary>
        /// <param name="elapsed">GameTime</param>
        public virtual void Update(GameTime gameTime) 
        {

        }

        public virtual void Draw(GameTime gameTime)
        {

        }

    }

}
