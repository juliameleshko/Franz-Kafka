using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;



namespace WorldOfTeofilakt.Interfaces
{
    public interface IMovable
    {
         Vector2 Velocity { get; set; }
         Vector2 MovementSpeed { get; set; }

         void Move(KeyboardState keyBoardState);

    }
}
