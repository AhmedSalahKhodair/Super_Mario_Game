using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
namespace mario_game.Managers
{
    class content_manager
    {
        private static content_manager instance;
        ContentManager cm;

        public Dictionary<string, Texture2D> textures;

        private content_manager()
        {
            textures = new Dictionary<string, Texture2D>();
        }
        public static content_manager get_instance()
        {
            if (instance == null)
                instance = new content_manager();
            return instance;
        }
        public void loadtexture(ContentManager content)
        {
            cm = content;
            Addtexture("images/Capture3");
            Addtexture("images/tile");
            Addtexture("images/tree");
            Addtexture("images/char");
            Addtexture("images/download (1)");
            Addtexture("images/tree2");
            Addtexture("images/coin3");
        }
        public void Addtexture(string file,string name= "")
        {
            Texture2D newtexture = cm.Load<Texture2D>(file);
            if (name == "")
                textures.Add(file, newtexture);
            else
                textures.Add(name, newtexture);
        }
}
    }
