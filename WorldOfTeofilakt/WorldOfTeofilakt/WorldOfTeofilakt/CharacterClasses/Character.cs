<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

using WorldOfTeofilakt.Interfaces;

namespace WorldOfTeofilakt.CharacterClasses
{
=======
﻿namespace WorldOfTeofilakt.CharacterClasses
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using WorldOfTeofilakt.Interfaces;

>>>>>>> ec77d8c7d50f3bf6093a178ba0c0518b13a48b52
    public abstract class Character : ICharacter
    {
        //Fields
       // private Rectangle characterBounds;

       //Constructors
        public Character(string name, Texture2D image, Vector2 position)
        {
            this.Name = name;
            this.Image = image;
            this.Position = position;
            Color = Color.White;
            this.IsActive = true;
        }
        
        //Properties
        public bool IsActive { get; set; }
        public string Name { get; set; }
        public Texture2D Image { get; set; }
        public Rectangle CharacterBounds
        {
            get
            {
                return new Rectangle((int)Position.X, (int)Position.Y, Image.Width, Image.Height);
            }
        }

        public Vector2 Position { get; set; }
        public Color Color { get; set; }

        //Methods
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.Image, this.Position, this.Color);
        }
    }
}
