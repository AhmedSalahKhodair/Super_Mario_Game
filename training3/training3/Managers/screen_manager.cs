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
    class screen_manager
    {
        ArrayList Screens;
        screen currentscreen;
        public screen_manager()
        {
            Screens = new ArrayList();
            Screens.Add(new menu_screen());
            currentscreen = (screen)Screens[0];
        }
        public void Draw(SpriteBatch spritebatch)
        {
            currentscreen.Draw(spritebatch);
        }
    }
}