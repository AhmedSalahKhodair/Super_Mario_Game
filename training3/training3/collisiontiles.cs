using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
namespace training3
{
    class Collisiontiles :tiles
    {
        public Collisiontiles(int i, Rectangle newrectangle)
        {
            texture = Content.Load<Texture2D>("images/tile" + i);
            this.Rectangle = newrectangle;
        }
    }
}
