namespace GameLibrary
{
    using System;
    using System.Collections.Generic;

    using Microsoft.Xna.Framework;

    public abstract partial class GameState : DrawableGameComponent
    {
        public GameState(Game game, GameStateManager manager)
            : base(game)
        {
            StateManager = manager;
            this.Components = new List<GameComponent>();
            this.Tag = this;
        }

        public List<GameComponent> Components { get; private set; }

        public GameState Tag { get; private set; }

        protected GameStateManager StateManager { get; private set; }

        public override void Initialize()
        {

            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            foreach (GameComponent component in this.Components)
            {
                if (component.Enabled)
                {
                    component.Update(gameTime);
                }
            }

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            DrawableGameComponent drawableComponent;

            foreach (GameComponent component in this.Components)
            {
                if (component is DrawableGameComponent)
                {
                    drawableComponent = component as DrawableGameComponent;

                    if (drawableComponent.Visible)
                    {
                        drawableComponent.Draw(gameTime);
                    }
                }
            }

            base.Draw(gameTime);
        }

        internal protected virtual void StateChange(object sender, EventArgs e)
        {
            if (StateManager.CurrentState == Tag)
            {
                Show();
            }
            else
            {
                Hide();
            }
        }

        protected virtual void Show()
        {
            this.Visible = true;
            this.Enabled = true;

            foreach (GameComponent component in this.Components)
            {
                component.Enabled = true;

                if (component is DrawableGameComponent)
                {
                    ((DrawableGameComponent)component).Visible = true;
                }
            }
        }

        protected virtual void Hide()
        {
            this.Visible = false;
            this.Enabled = false;

            foreach (GameComponent component in this.Components)
            {
                component.Enabled = false;

                if (component is DrawableGameComponent)
                {
                    ((DrawableGameComponent)component).Visible = false;
                }
            }
        }
    }
}
