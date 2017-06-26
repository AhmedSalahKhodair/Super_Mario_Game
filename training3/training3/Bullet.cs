using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace training3
{
    public class Bullet
    {
        public Rectangle boundingBox;
        public Texture2D texture;
        public Vector2 origin, bulletposition;
        public bool isVisible;
        public float speed;

        public Bullet(Texture2D newTexture)
        {
            speed = 7;
            texture = newTexture;
            isVisible = false;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, bulletposition, Color.White);
        }
    }
}
