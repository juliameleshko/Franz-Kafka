namespace WorldOfTeofilakt.Interfaces
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Input;

    public interface IMovable
    {
         Vector2 Velocity { get; set; }
         Vector2 MovementSpeed { get; set; }

         void Move(KeyboardState keyBoardState);
    }
}
