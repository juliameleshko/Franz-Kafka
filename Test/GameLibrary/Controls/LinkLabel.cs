namespace GameLibrary.Controls
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    public class LinkLabel : Control
    {
        public LinkLabel()
        {
            this.TabStop = true;
            this.HasFocus = false;
            this.Position = Vector2.Zero;
            this.SelectedColor = Color.White;
        }

        public Color SelectedColor { get; set; }

        public override void Update(GameTime gameTime)
        {
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (this.HasFocus)
            {
                spriteBatch.DrawString(this.SpriteFont, this.Text, this.Position, this.SelectedColor);
            }
            else
            {
                spriteBatch.DrawString(this.SpriteFont, this.Text, this.Position, this.Color);
            }
        }

        public override void HandleInput(PlayerIndex playerIndex)
        {
            if (!this.HasFocus)
            {
                return;
            }

            if (InputHandler.KeyReleased(Keys.Enter))
            {
                base.OnSelected(null);
            }
        }
    }
}
