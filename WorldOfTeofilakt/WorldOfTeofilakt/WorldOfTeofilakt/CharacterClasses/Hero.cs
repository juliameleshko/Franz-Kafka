using System;
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

namespace WorldOfTeofilakt.CharacterClasses
{
    public class Hero : Character
    {
        //Constants
        private const float speed = 5f;
        //Fields
        private Vector2 velocity;
        private Vector2 movementSpeed;
        private bool isMale;
        
        //Constructors
        public Hero(string name, Texture2D image, Vector2 position, bool isMale)
            : base(name, image, position)
        {
            this.IsMale = isMale;
            this.velocity = Vector2.Zero;
            this.movementSpeed = new Vector2(speed, speed);
        }

        //Properties
        public bool IsMale
        {
            get { return isMale; }
            set { isMale = value; }
        }

        //Methods
        public void Move(KeyboardState keyBoardState)
        {
            keyBoardState = Keyboard.GetState();

            this.velocity = Vector2.Zero;

            if (keyBoardState.IsKeyDown(Keys.Up))
            {
                this.velocity.Y = -movementSpeed.Y;
               
            }
            if (keyBoardState.IsKeyDown(Keys.Left))
            {
                this.velocity.X = -movementSpeed.X;
                
            }
            if (keyBoardState.IsKeyDown(Keys.Down))
            {
                this.velocity.Y = movementSpeed.Y;
               
            }
            if (keyBoardState.IsKeyDown(Keys.Right))
            {
                this.velocity.X = movementSpeed.X;
                
            }

            this.Position += this.velocity;

        }

        public bool CheckCollision(Character otherCharacter)
        {
            if (this.CharacterBounds.Intersects(otherCharacter.CharacterBounds))
            {
                return true;
            }
            else
            {
                return false;
            }
        
        }

    }
}
