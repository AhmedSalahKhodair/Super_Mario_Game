using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
namespace training3
{
    class map
    {
        private List<Collisiontiles> collisiontiles = new List<Collisiontiles>();
        public List<Collisiontiles> Collisiontiles
        {
            get { return collisiontiles; }
        }
        private int width, height;
        public int Width
        {
            get { return width; }
        }
        public int Height
        {
            get { return height; }
        }
        public map() { }
        public void Generate(int[,] map, int size)
        {
            for (int x = 0; x < map.GetLength(1); x++)
            {
                for (int y = 0; y < map.GetLength(0); y++)
                {
                    int number = map[y, x];
                    if (number > 0)
                        collisiontiles.Add(new Collisiontiles(number, new Rectangle(x * size, y * size, size, size)));
                    width = (x+1) * size;
                    height = (y +1) * size;
                }
            }

        } 
        public void Draw(SpriteBatch spritebatch)
        {
            foreach (Collisiontiles tile in collisiontiles)
            {
                tile.Draw(spritebatch);
            }
        }
    }
}