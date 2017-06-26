using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Design;
using mario_game.Managers;
using mario_game.Helper_classes;
namespace mario_game.screens
{
    class menu_screen : screen
    {
        sprites menulogo;
        Title_manager tilemanager;
        public menu_screen()
            : base()
        {
            Texture2D manualofpicture = content_manager.get_instance().textures["Capture3"];
            menulogo = new sprites(manualofpicture, new Vector2(150, 0));
            tilemanager = new Title_manager();
            tilemanager.addtile(content_manager.get_instance().textures["images/tree"], new Vector2(3, 9));
            tilemanager.addtile(content_manager.get_instance().textures["images/char"], new Vector2(6, 7));
            tilemanager.addtile(content_manager.get_instance().textures["images/download (1)"], new Vector2(9, 7));
            tilemanager.addtile(content_manager.get_instance().textures["images/tree2"], new Vector2(15, 2));
            tilemanager.addtile(content_manager.get_instance().textures["images/coin3"], new Vector2(12, 1));
            tilemanager.addtile(content_manager.get_instance().textures["images/coin3"], new Vector2(5, 1));
            for (int i = 0; i < 44; i++)
            {
                tilemanager.addtile(content_manager.get_instance().textures["images/tile"], new Vector2(i, 44 / 4));
                tilemanager.addtile(content_manager.get_instance().textures["images/tile"], new Vector2(i, (44 / 4) - 1));
            }
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            menulogo.Draw(spriteBatch);
            tilemanager.Draw(spriteBatch);
        }
    }
}