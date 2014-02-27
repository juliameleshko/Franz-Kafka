namespace WorldOfTeofilakt.Interfaces
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public interface ICharacter
    {
        bool IsActive { get; set; }
        string Name { get; set; }
        Texture2D Image { get; set; }
<<<<<<< HEAD
        Rectangle CharacterBounds { get; }
=======
        Rectangle CharacterBounds { get;}
>>>>>>> ec77d8c7d50f3bf6093a178ba0c0518b13a48b52
        Vector2 Position { get; set; }
        Color Color { get; set; }

        void Draw(SpriteBatch spriteBatch);
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> ec77d8c7d50f3bf6093a178ba0c0518b13a48b52
