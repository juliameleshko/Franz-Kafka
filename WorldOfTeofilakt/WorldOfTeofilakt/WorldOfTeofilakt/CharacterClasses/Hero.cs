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


using WorldOfTeofilakt.Interfaces;
using WorldOfTeofilakt.Items;

namespace WorldOfTeofilakt.CharacterClasses
{
    public class Hero : Character, IMovable
    {
        //Constants
        private const float speed = 5f;

        //Fields
        private bool isMale;
        private Vector2 velocity;
        private Vector2 movementSpeed;
        private uint preciousTime;
        private Dictionary<Abilities, uint> heroAbilities;
        private Dictionary<Knowledges, uint> heroKnowledges;

        //Constructors
        public Hero(string name, Texture2D image, Vector2 position, bool isMale, uint preciousTime)
            : base(name, image, position)
        {
            this.IsMale = isMale;
            this.Velocity = Vector2.Zero;
            this.MovementSpeed = new Vector2(speed, speed);
            this.PreciousTime = preciousTime;

            this.HeroAbilities = new Dictionary<Abilities,uint>();
            this.HeroAbilities.Add(Abilities.BrainPower, 0);
            this.HeroAbilities.Add(Abilities.Motivation, 0);
            this.HeroAbilities.Add(Abilities.Patience, 0);
            this.HeroAbilities.Add(Abilities.WorkDedication, 0);

            this.HeroKnowledges = new Dictionary<Knowledges, uint>();
        }

        //Properties
        public bool IsMale
        {
            get { return isMale; }
            set { isMale = value; }
        }

        public Dictionary<Abilities, uint> HeroAbilities
        {
            get { return heroAbilities; }
            set { heroAbilities = value; }
        }

        public Dictionary<Knowledges, uint> HeroKnowledges
        {
            get { return heroKnowledges; }
            set { heroKnowledges = value; }
        }

        public uint PreciousTime
        {
            get { return preciousTime; }
            set { preciousTime = value; }
        }
        //Properties from IMovable
        public Vector2 Velocity
        {
            get { return velocity; }
            set { velocity = value; }
        }

        public Vector2 MovementSpeed
        {
            get { return movementSpeed; }
            set { movementSpeed = value; }
        }

     
        //Methods from IMovable
        public void Move(KeyboardState keyBoardState)
        {
            keyBoardState = Keyboard.GetState();

            this.Velocity = Vector2.Zero;

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


        public void DrawStats(SpriteBatch spriteBatch, SpriteFont font, Vector2 position,Color color)
        {

            spriteBatch.DrawString(font, "PRECIOUS TIME: " + this.PreciousTime.ToString() + "\nABILITIES ", position, color);
            position.Y += 35;

            //draw abilities
            foreach (var ability in this.HeroAbilities)
            {
                spriteBatch.DrawString(font, ability.Key.ToString() + ": ", position, color);
                spriteBatch.DrawString(font, ability.Value.ToString(), new Vector2(position.X + 130, position.Y), color);
                position.Y += font.LineSpacing;
            }

            // draw knowledges
            position.Y += 10;
            spriteBatch.DrawString(font, "KNOWLEDGES", position, color);
            position.Y += 20;

            if (this.HeroKnowledges.Count !=0)
            {
                foreach (var knowledge in this.HeroKnowledges)
                {
                    spriteBatch.DrawString(font, knowledge.Key.ToString(), position, color);
     
                    position.Y += font.LineSpacing;
                }
            }
            else
            {
                spriteBatch.DrawString(font, "You have not yet!", position, color);
            }
            

        }


    }
}
