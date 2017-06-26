using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace mario_game.Helper_classes
{
    class sprites
    {
        Texture2D _texture;
        Vector2 _position;
        Rectangle _bounds;
        public sprites(Texture2D texture, Vector2 postion)
        {
            _texture = texture;
            _position = postion;
            _bounds = _texture.Bounds;
        }
        public void Draw(SpriteBatch spritbatch)
        {
            spritbatch.Draw(_texture, _position,_bounds ,Color.White);
        }
    }
}
