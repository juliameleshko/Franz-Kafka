<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using WorldOfTeofilakt.Items;
using WorldOfTeofilakt.Interfaces;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace WorldOfTeofilakt.CharacterClasses
{
=======
﻿namespace WorldOfTeofilakt.CharacterClasses
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System.Collections.Generic;
    using WorldOfTeofilakt.Interfaces;
    using WorldOfTeofilakt.Items;

>>>>>>> ec77d8c7d50f3bf6093a178ba0c0518b13a48b52
    public class Boss : Enemy, IBoss
    {
        private IDictionary<Knowledges, int> bossKnowledges;

        public Boss(string name, Texture2D image, Vector2 position, IDictionary<Knowledges, int> bossKnowledges)
            : base(name, image, position)
        {
            this.bossKnowledges = bossKnowledges;
        }

        public IDictionary<Knowledges, int> BossKnowledges
        {
            get
            {
                return bossKnowledges;
            }
            set
            {
                bossKnowledges = value;
            }
        }

        //Methods
        public void DrawStats(SpriteBatch spriteBatch, SpriteFont font, Vector2 position, Color color)
        { }

        public int CalculatePower()
        {
            int power = 1;

            foreach (var knowledge in bossKnowledges)
            {
                power *= knowledge.Value;
            }

            return power;
        }
    }
}
