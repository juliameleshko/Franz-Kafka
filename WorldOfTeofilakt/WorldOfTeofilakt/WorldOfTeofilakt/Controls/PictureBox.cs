using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace WorldOfTeofilakt.Controls
{
    class PictureBox : Control
    {
        //Fields
        Texture2D image;
        Rectangle sourceRect;
    //    Rectangle destRect;

        public PictureBox(Texture2D image, Vector2 position)
        {
            Image = image;
          //  DestinationRectangle = destination;
            this.Position = position;
            SourceRectangle = new Rectangle((int)Position.X, (int)Position.Y, image.Width, image.Height);
            Color = Color.White;
        }

        public Texture2D Image
        {
            get { return image; }
            set { image = value; }
        }

        public Rectangle SourceRectangle
        {
            get { return sourceRect; }
            set { sourceRect = value; }
        }

        //public Rectangle DestinationRectangle
        //{
        //    get { return destRect; }
        //    set { destRect = value; }
        //}

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(image, sourceRect, color);
        }

    }
}
