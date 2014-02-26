using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;


namespace WorldOfTeofilakt.CharacterClasses
{
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
