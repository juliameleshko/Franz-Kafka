namespace WorldOfTeofilakt.CharacterClasses
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System.Collections.Generic;
    using WorldOfTeofilakt.Interfaces;
    using WorldOfTeofilakt.Items;

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
