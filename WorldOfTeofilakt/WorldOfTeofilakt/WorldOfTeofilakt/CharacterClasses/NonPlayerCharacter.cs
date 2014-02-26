namespace WorldOfTeofilakt.CharacterClasses
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    class NonPlayerCharacter : Character
    {
        private NonPlayerCharacterTypes type;
        
        public NonPlayerCharacter(string name, Texture2D image, Vector2 position, NonPlayerCharacterTypes type)
            :base(name, image, position)
        {
            this.type = type;
        }
    }
}
