using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using mario_game.screens;
namespace mario_game.Managers
{
    class Title_manager
    {
        ArrayList ntiles;

        public Title_manager()
        {
            ntiles = new ArrayList();
        }
        public void addtile(Texture2D text,Vector2 pos)
        {
            ntiles.Add(new Tile(text,pos));
        }
        public void Draw(SpriteBatch spritebatch)
        {
            foreach(Tile tile in ntiles)
            {
                spritebatch.Draw(tile.texture, new Vector2(tile.position.X * 42, tile.position.Y * 42),Color.White);
            }
        }
    }
    class Tile
    {
        public Texture2D texture;
        public Vector2 position;
        public Tile(Texture2D text,Vector2 pos)
        {
            texture = text;
            position = pos;
        }
    }
}
