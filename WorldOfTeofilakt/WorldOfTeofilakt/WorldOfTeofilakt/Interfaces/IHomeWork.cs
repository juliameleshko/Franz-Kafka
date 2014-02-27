namespace WorldOfTeofilakt.Interfaces
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System.Collections.Generic;
    using WorldOfTeofilakt.Items;

    public interface IHomeWork
    {
        uint TakenTime { get; set; }
        Knowledges? MustKnowledge { get; set; }
        Knowledges WonKnowledge { get; set; }
        IDictionary<Abilities, int> MustAbilities { get; set; }

        void DrawStats(SpriteBatch spriteBatch, SpriteFont font, Vector2 position, Color color);
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> ec77d8c7d50f3bf6093a178ba0c0518b13a48b52
