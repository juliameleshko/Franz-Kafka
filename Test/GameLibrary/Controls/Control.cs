namespace GameLibrary.Controls
{
    using System;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public abstract class Control
    {
        public event EventHandler Selected;

        protected Vector2 position;

        public Control()
        {
            this.Color = Color.White;
            this.Enabled = true;
            this.Visible = true;
            this.SpriteFont = ControlManager.SpriteFont;
        }

        public string Name { get; set; }

        public string Text { get; set; }

        public Vector2 Size { get; set; }

        public Vector2 Position
        {
            get { return this.position; }
            set
            {
                position = value;
                position.Y = (int)position.Y;
            }
        }

        public object Value { get; set; }

        public bool HasFocus { get; set; }

        public bool Enabled { get; set; }

        public bool Visible { get; set; }

        public bool TabStop { get; set; }

        public SpriteFont SpriteFont { get; set; }

        public Color Color { get; set; }

        public string Type { get; set; }

        public abstract void Update(GameTime gameTime);
        public abstract void Draw(SpriteBatch spriteBatch);
        public abstract void HandleInput(PlayerIndex playerIndex);

        protected virtual void OnSelected(EventArgs e)
        {
            if (this.Selected != null)
            {
                this.Selected(this, e);
            }
        }
    }
}
