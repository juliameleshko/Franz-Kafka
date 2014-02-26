﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using WorldOfTeofilakt.Items;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace WorldOfTeofilakt.CharacterClasses
{
    public class HomeWork : Enemy
    {
        private uint takenTime;
        private Knowledges? mustKnowledge;
        private Knowledges wonKnowledge;
        private IDictionary<Abilities, int> mustAbilities;

        public HomeWork(string name, Texture2D image, Vector2 position,uint takenTime,
               Knowledges? mustKnowledge, Knowledges wonKnowledge, IDictionary<Abilities, int> mustAbilities)
            : base(name, image, position)
        {
            this.TakenTime = takenTime;
            this.MustKnowledge = mustKnowledge;
            this.WonKnowledge = wonKnowledge;
            this.MustAbilities = mustAbilities;
        }
        
        public uint TakenTime
        {
            get { return takenTime; }
            set { takenTime = value; }
        }

        public Knowledges? MustKnowledge
        {
            get { return mustKnowledge; }
            set { mustKnowledge = value; }
        }

        public Knowledges WonKnowledge
        {
            get { return wonKnowledge; }
            set { wonKnowledge = value; }
        }

        public IDictionary<Abilities, int> MustAbilities
        {
            get { return mustAbilities; }
            set { mustAbilities = value; }
        }

        //Methods

        public void DrawStats(SpriteBatch spriteBatch, SpriteFont font, Vector2 position, Color color)
        {
            spriteBatch.DrawString(font, this.Name, position, color);
            position.Y += font.LineSpacing;
            spriteBatch.DrawString(font, this.TakenTime.ToString(), position, color);
            position.Y += font.LineSpacing;

            foreach (var ability in this.MustAbilities)
            {
                spriteBatch.DrawString(font, ability.Key.ToString() + ": ", position, color);
                spriteBatch.DrawString(font, ability.Value.ToString(), new Vector2(position.X + 130, position.Y), color);
                position.Y += font.LineSpacing;
            }

            spriteBatch.DrawString(font, this.MustKnowledge == null ? "" : this.MustKnowledge.ToString(), position, color);
            position.Y += font.LineSpacing;
            spriteBatch.DrawString(font, this.WonKnowledge.ToString(), position, color);
        }
    }
}