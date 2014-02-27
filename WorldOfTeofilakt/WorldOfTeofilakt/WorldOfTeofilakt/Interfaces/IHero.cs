namespace WorldOfTeofilakt.Interfaces
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System.Collections.Generic;
    using WorldOfTeofilakt.CharacterClasses;
    using WorldOfTeofilakt.Items;

    public interface IHero
    {
        bool IsMale { get; set; }
        Dictionary<Abilities, uint> HeroAbilities { get; set; }
        Dictionary<Knowledges, uint> HeroKnowledges { get; set; }
        uint PreciousTime { get; set; }

        bool CheckCollision(Character otherCharacter);
        void DrawStats(SpriteBatch spriteBatch, SpriteFont font, Vector2 position, Color color);
        void DuelWithHomeWork(HomeWork homework);
    }
}