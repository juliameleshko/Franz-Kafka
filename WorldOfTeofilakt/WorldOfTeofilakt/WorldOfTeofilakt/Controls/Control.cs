using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WorldOfTeofilakt.Controls
{
    public abstract class Control
    {
        //Fields
        protected string name;
        protected Vector2 size;
        protected Vector2 position;
        protected Color color;

        public Control()
        { 
        }
        
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public Vector2 Size
        {
            get { return size; }
            set { size = value; }
        }

        public Vector2 Position
        {
            get { return position; }
            set
            {
                position = value;
                position.Y = (int)position.Y;
            }
        }

        public Color Color
        {
            get { return color; }
            set { color = value; }
        }


      //  public abstract void Update(GameTime gameTime);
        public abstract void Draw(SpriteBatch spriteBatch);
       // public abstract void HandleInput(PlayerIndex playerIndex);
    }
}
