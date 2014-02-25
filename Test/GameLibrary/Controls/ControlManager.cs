namespace GameLibrary.Controls
{
    using System.Collections.Generic;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    public class ControlManager : List<Control>
    {
        private int selectedControl = 0;

        public ControlManager(SpriteFont spriteFont)
            : base()
        {
            ControlManager.SpriteFont = spriteFont;
        }

        public ControlManager(SpriteFont spriteFont, int capacity)
            : base(capacity)
        {
            ControlManager.SpriteFont = spriteFont;
        }

        public ControlManager(SpriteFont spriteFont, IEnumerable<Control> collection)
            : base(collection)
        {
            ControlManager.SpriteFont = spriteFont;
        }

        public static SpriteFont SpriteFont { get; private set; }

        public void Update(GameTime gameTime, PlayerIndex playerIndex)
        {
            if (this.Count == 0)
            {
                return;
            }

            foreach (Control ctrl in this)
            {
                if (ctrl.Enabled)
                {
                    ctrl.Update(gameTime);
                }

                if (ctrl.HasFocus)
                {
                    ctrl.HandleInput(playerIndex);
                }
            }

            if (InputHandler.KeyPressed(Keys.Up))
            {
                PreviousControl();
            }

            if (InputHandler.KeyPressed(Keys.Down))
            {
                NextControl();
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Control ctrl in this)
            {
                if (ctrl.Visible)
                {
                    ctrl.Draw(spriteBatch);
                }
            }
        }

        public void NextControl()
        {
            if (this.Count == 0)
            {
                return;
            }

            int currentControl = this.selectedControl;

            this[this.selectedControl].HasFocus = false;

            do
            {
                this.selectedControl++;

                if (this.selectedControl == this.Count)
                {
                    this.selectedControl = 0;
                }

                if (this[this.selectedControl].TabStop && this[this.selectedControl].Enabled)
                {
                    break;
                }
            } while (currentControl != selectedControl);

            this[this.selectedControl].HasFocus = true;
        }

        public void PreviousControl()
        {
            if (this.Count == 0)
            {
                return;
            }

            int currentControl = selectedControl;

            this[this.selectedControl].HasFocus = false;

            do
            {
                this.selectedControl--;

                if (this.selectedControl < 0)
                {
                    this.selectedControl = this.Count - 1;
                }

                if (this[this.selectedControl].TabStop && this[this.selectedControl].Enabled)
                {
                    break;
                }
            } while (currentControl != this.selectedControl);

            this[this.selectedControl].HasFocus = true;
        }
    }
}
