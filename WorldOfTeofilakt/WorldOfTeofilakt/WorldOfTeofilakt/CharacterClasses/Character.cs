namespace WorldOfTeofilakt.CharacterClasses
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using WorldOfTeofilakt.Interfaces;

    public abstract class Character : ICharacter
    {
        //Fields
       // private Rectangle characterBounds;

       //Constructors
        public Character(string name, Texture2D image, Vector2 position)
        {
            this.Name = name;
            this.Image = image;
            this.Position = position;
            Color = Color.White;
            this.IsActive = true;
        }
        
        //Properties
        public bool IsActive { get; set; }
        public string Name { get; set; }
        public Texture2D Image { get; set; }
        public Rectangle CharacterBounds
        {
            get
            {
                return new Rectangle((int)Position.X, (int)Position.Y, Image.Width, Image.Height);
            }
        }

        public Vector2 Position { get; set; }
        public Color Color { get; set; }

        //Methods
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.Image, this.Position, this.Color);
        }
    }
}
