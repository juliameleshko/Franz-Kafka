namespace WorldOfTeofilakt.Interfaces
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public interface ICharacter
    {
        bool IsActive { get; set; }
        string Name { get; set; }
        Texture2D Image { get; set; }
        Rectangle CharacterBounds { get; }
        Vector2 Position { get; set; }
        Color Color { get; set; }

        void Draw(SpriteBatch spriteBatch);
    }
}