using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
namespace training3
{
    public class Camera2
    {
        private Matrix transform;
        public Matrix Transform
        {
            get { return transform; }
        }
        private Vector2 center;
        private Viewport viewport;
        public Camera2(Viewport newviewport) 
        {
            viewport = newviewport;
        }
        public void Update(Vector2 position,int xoffset,int yoffset)
        {

            if (position.X < viewport.Width / 2)
                center.X = viewport.Width / 2;
            else if (position.X > xoffset- (viewport.Width / 2))
                center.X = xoffset - viewport.Width / 2;
            else 
                center.X = position.X;
            if (position.Y < viewport.Height / 2)
                center.Y = viewport.Height / 2;
            else if (position.Y >yoffset- viewport.Height / 2)
                center.Y = yoffset - viewport.Height / 2;
            else
                center.Y = position.Y;
            transform = Matrix.CreateTranslation(new Vector3(-center.X + (viewport.Width/2), -center.Y + (viewport.Height / 2), 0));
        }
    }
}
