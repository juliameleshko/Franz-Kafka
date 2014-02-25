namespace GameLibrary
{
    using System;
    using System.Collections.Generic;

    using Microsoft.Xna.Framework;

    public class GameStateManager : Microsoft.Xna.Framework.GameComponent
    {
        public event EventHandler OnStateChange;

        private const int StartDrawOrder = 5000;
        private const int DrawOrderInc = 100;

        private int drawOrder;

        private Stack<GameState> gameStates = new Stack<GameState>();

        public GameStateManager(Game game)
            : base(game)
        {
            drawOrder = StartDrawOrder;
        }

        public GameState CurrentState
        {
            get { return gameStates.Peek(); }
        }

        public override void Initialize()
        {

            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {

            base.Update(gameTime);
        }

        public void PopState()
        {
            if (gameStates.Count > 0)
            {
                RemoveState();
                drawOrder -= DrawOrderInc;

                if (OnStateChange != null)
                {
                    OnStateChange(this, null);
                }
            }
        }

        private void RemoveState()
        {
            GameState state = gameStates.Peek();

            OnStateChange -= state.StateChange;
            Game.Components.Remove(state);
            gameStates.Pop();
        }

        public void PushState(GameState newState)
        {
            drawOrder += DrawOrderInc;
            newState.DrawOrder = drawOrder;

            AddState(newState);

            if (OnStateChange != null)
            {
                OnStateChange(this, null);
            }
        }

        private void AddState(GameState newState)
        {
            gameStates.Push(newState);

            Game.Components.Add(newState);

            OnStateChange += newState.StateChange;
        }

        public void ChangeState(GameState newState)
        {
            while (gameStates.Count > 0)
            {
                RemoveState();
            }

            newState.DrawOrder = StartDrawOrder;
            drawOrder = StartDrawOrder;

            AddState(newState);

            if (OnStateChange != null)
            {
                OnStateChange(this, null);
            }
        }
    }
}
