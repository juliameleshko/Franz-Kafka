namespace WorldOfTeofilakt.CharacterClasses
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using WorldOfTeofilakt.Interfaces;

    public class Enemy : Character
    {
        public Enemy(string name, Texture2D image, Vector2 position)
            :base(name, image, position)
        {
            this.Name = name;
        }
    }
}
