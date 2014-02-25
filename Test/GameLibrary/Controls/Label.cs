namespace GameLibrary.Controls
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class Label : Control
    {
        public Label()
        {
            this.TabStop = false;
        }

        public override void Update(GameTime gameTime)
        {
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(this.SpriteFont, this.Text, this.Position, this.Color);
        }

        public override void HandleInput(PlayerIndex playerIndex)
        {
        }
    }
}
