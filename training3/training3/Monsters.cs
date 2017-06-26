using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace training3
{
    public sealed class Monsters
    {
        #region monsters declarations
        public Texture2D[] mons=new Texture2D[11];
        public Vector2[] monspos= new Vector2[11];
        public Rectangle[] rmons=new Rectangle[11];
        public bool[] monsterdie = new bool[11];
        public int[] i = new int[11];
        #endregion
        private static volatile Monsters instance;
        private static object syncRoot = new Object();
        private Monsters()
        {
            for (int i = 0; i < 11; i++)
                monsterdie[i] = false;
            for (int g = 0; g < 11; g++)
                i[g] = 0;
            monspos[0] = new Vector2(600, 332);
            monspos[1] = new Vector2(970, 332);
            monspos[2] = new Vector2(880, 52);
            monspos[3] = new Vector2(1650, 332);
            monspos[4] = new Vector2(2280, 332);
            monspos[5] = new Vector2(2280, 332);
            monspos[6] = new Vector2(2280, 332);
            monspos[7] = new Vector2(3400, 332);
            monspos[8] = new Vector2(4500, 332);
            monspos[9] = new Vector2(4300, 332);
            monspos[10] = new Vector2(4400, 332);
        }
        public static Monsters Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new Monsters();
                    }
                }

                return instance;
            }
        }
        public void Load(ContentManager content)
        {
            #region loadmonsters
            for (int i = 0; i < 11;i++ )
                mons[i] = content.Load<Texture2D>("images/monster2");
            #endregion
        }
        public void Update(GameTime gametime, ref float currentscore, ref Rectangle rectangle,ref Vector2 position,ref bool playerdie)
        {
            #region update monsters
            for (int i = 0; i < 11; i++)
            {
                rmons[i] = new Rectangle((int)monspos[i].X, (int)monspos[i].Y, mons[i].Width, mons[i].Height);
            }
            #endregion
            #region monsters controle
            //monster 1 
            if (!monsterdie[0])
            {
                if (monspos[0].X <= 600 && monspos[0].X > 180 && i[0] == 0)
                {
                    monspos[0].X -= 2;
                    i[0] = 0;
                }
                if ((monspos[0].X == 180 || i[0] == 1) && monspos[0].X <= 600)
                {
                    monspos[0].X += 2;
                    i[0] = 1;
                    if (monspos[0].X == 600)
                        i[0] = 0;
                }
            }
            // monster 2
            if (!monsterdie[1])
            {
                if (monspos[1].X <= 970 && monspos[1].X > 800 && i[1] == 0)
                {
                    monspos[1].X -= 2;
                    i[1] = 0;
                }
                if ((monspos[1].X == 800 || i[1] == 1) && monspos[1].X <= 970)
                {
                    monspos[1].X += 2;
                    i[1] = 1;
                    if (monspos[1].X == 970)
                        i[1] = 0;
                }
            }
            //monster3
            if (!monsterdie[2])
            {
                if (monspos[2].X <= 1180 && monspos[2].X > 880 && i[2] == 0)
                {
                    monspos[2].X -= 2;
                    i[2] = 0;
                }
                if ((monspos[2].X == 880 || i[2] == 1) && monspos[2].X <= 1180)
                {
                    monspos[2].X += 2;
                    i[2] = 1;
                    if (monspos[2].X == 1180)
                        i[2] = 0;
                }
            }
            //monster 4
            if (!monsterdie[3])
            {
                if (monspos[3].X <= 1696 && monspos[3].X > 1570 && i[3] == 0)
                {
                    monspos[3].X -= 2;
                    i[3] = 0;
                }
                if ((monspos[3].X == 1570 || i[3] == 1) && monspos[3].X <= 1696)
                {
                    monspos[3].X += 2;
                    i[3] = 1;
                    if (monspos[3].X == 1696)
                        i[3] = 0;
                }
            }
            //monster 5 
            if (!monsterdie[4])
            {
                if (monspos[4].X <= 3200 && monspos[4].X > 2200 && i[4] == 0)
                {
                    monspos[4].X -= 2;
                    i[4] = 0;
                }
                if ((monspos[4].X == 2200 || i[4] == 1) && monspos[4].X <= 3200)
                {
                    monspos[4].X += 2;
                    i[4] = 1;
                    if (monspos[4].X == 3200)
                        i[4] = 0;
                }
            }
            // monster 6
            if (!monsterdie[5])
            {
                if (monspos[5].X <= 3270 && monspos[5].X > 2200 && i[5] == 0)
                {
                    monspos[5].X -= 2;
                    i[5] = 0;
                }
                if ((monspos[5].X == 2200 || i[5] == 1) && monspos[5].X <= 3270)
                {
                    monspos[5].X += 2;
                    i[5] = 1;
                    if (monspos[5].X == 3270)
                        i[5] = 0;
                }
            }
            // monster 7
            if (!monsterdie[6])
            {
                if (monspos[6].X <= 3300 && monspos[6].X > 2200 && i[6] == 0)
                {
                    monspos[6].X -= 2;
                    i[6] = 0;
                }
                if ((monspos[6].X == 2200 || i[6] == 1) && monspos[6].X <= 3300)
                {
                    monspos[6].X += 2;
                    i[6] = 1;
                    if (monspos[6].X == 3300)
                        i[6] = 0;
                }
            }
            //monster 8
            if (!monsterdie[7])
            {
                if (monspos[7].X <= 3490 && monspos[7].X > 3400 && i[7] == 0)
                {
                    monspos[7].X -= 2;
                    i[7] = 0;
                }
                if ((monspos[7].X == 3400 || i[7] == 1) && monspos[7].X <= 3490)
                {
                    monspos[7].X += 2;
                    i[7] = 1;
                    if (monspos[7].X == 3490)
                        i[7] = 0;
                }
            }
            //monster 9
            if (!monsterdie[8])
            {
                if (monspos[8].X <= 4600 && monspos[8].X > 4112 && i[8] == 0)
                {
                    monspos[8].X -= 2;
                    i[8] = 0;
                }
                if ((monspos[8].X == 4112 || i[8] == 1) && monspos[8].X <= 4600)
                {
                    monspos[8].X += 2;
                    i[8] = 1;
                    if (monspos[8].X == 4600)
                        i[8] = 0;
                }
            }
            //monster 10
            if (!monsterdie[9])
            {
                if (monspos[9].X <= 4600 && monspos[9].X > 4113 && i[9] == 0)
                {
                    monspos[9].X -= 1;
                    i[9] = 0;
                }
                if ((monspos[9].X == 4113 || i[9] == 1) && monspos[9].X <= 4600)
                {
                    monspos[9].X += 1;
                    i[9] = 1;
                    if (monspos[9].X == 4600)
                        i[9] = 0;
                }
            }
            //monster 11
            if (!monsterdie[10])
            {
                if (monspos[10].X <= 4601 && monspos[10].X > 4118 && i[10] == 0)
                {
                    monspos[10].X -= 3;
                    i[10] = 0;
                }
                if ((monspos[10].X == 4118 || i[10] == 1) && monspos[10].X <= 4601)
                {
                    monspos[10].X += 3;
                    i[10] = 1;
                    if (monspos[10].X == 4601)
                        i[10] = 0;
                }
            }
            #endregion
            #region touch monsters || player die
            if (position.Y > 350)
            {
                playerdie = true;
            }
            if (!monsterdie[0])
            {
                if (rmons[0].Intersects(rectangle))
                {
                    if (rectangle.TouchTopOf(rmons[0]))
                    {
                        monsterdie[0] = true;
                        currentscore += 5;
                    }
                    else if (rectangle.TouchLeftOf(rmons[0]) || rectangle.TouchRightOf(rmons[0]))
                    {
                        playerdie = true;
                    }
                }
            }
            if (!monsterdie[1])
            {
                if (rmons[1].Intersects(rectangle))
                {
                    if (rectangle.TouchTopOf(rmons[1]))
                    {
                        monsterdie[1] = true;
                        currentscore += 5;
                    }
                    else if (rectangle.TouchLeftOf(rmons[1]) || rectangle.TouchRightOf(rmons[1]))
                    {
                        playerdie = true;
                    }
                }
            }
            if (!monsterdie[2])
            {
                if (rmons[2].Intersects(rectangle))
                {
                    if (rectangle.TouchTopOf(rmons[2]))
                    {
                        monsterdie[2] = true;
                        currentscore += 5;
                    }
                    else if (rectangle.TouchLeftOf(rmons[2]) || rectangle.TouchRightOf(rmons[2]))
                    {
                        playerdie = true;
                    }
                }
            }
            if (!monsterdie[3])
            {
                if (rmons[3].Intersects(rectangle))
                {
                    if (rectangle.TouchTopOf(rmons[3]))
                    {
                        monsterdie[3] = true;
                        currentscore += 5;
                    }
                    else if (rectangle.TouchLeftOf(rmons[3]) || rectangle.TouchRightOf(rmons[3]))
                    {
                       playerdie = true;
                    }
                }
            }
            if (!monsterdie[4])
            {
                if (rmons[4].Intersects(rectangle))
                {
                    if (rectangle.TouchTopOf(rmons[4]))
                    {
                        monsterdie[4] = true;
                        currentscore += 5;
                    }
                    else if (rectangle.TouchLeftOf(rmons[4]) || rectangle.TouchRightOf(rmons[4]))
                    {
                       playerdie = true;
                    }
                }
            }
            if (!monsterdie[5])
            {
                if (rmons[5].Intersects(rectangle))
                {
                    if (rectangle.TouchTopOf(rmons[5]))
                    {
                        monsterdie[5] = true;
                        currentscore += 5;
                    }
                    else if (rectangle.TouchLeftOf(rmons[5]) || rectangle.TouchRightOf(rmons[5]))
                    {
                        playerdie = true;
                    }
                }
            }
            if (!monsterdie[6])
            {
                if (rmons[6].Intersects(rectangle))
                {
                    if (rectangle.TouchTopOf(rmons[6]))
                    {
                        monsterdie[6] = true;
                        currentscore += 5;
                    }
                    else if (rectangle.TouchRightOf(rmons[6]) || rectangle.TouchLeftOf(rmons[6]))
                    {
                        playerdie = true;
                    }
                }
            }
            if (!monsterdie[7])
            {
                if (rmons[7].Intersects(rectangle))
                {
                    if (rectangle.TouchTopOf(rmons[7]))
                    {
                        monsterdie[7] = true;
                        currentscore += 5;
                    }
                    else if (rectangle.TouchRightOf(rmons[7]) || rectangle.TouchLeftOf(rmons[7]))
                    {
                        playerdie = true;
                    }
                }
            }
            if (!monsterdie[8])
            {
                if (rmons[8].Intersects(rectangle))
                {
                    if (rectangle.TouchTopOf(rmons[8]))
                    {
                        monsterdie[8] = true;
                        currentscore += 5;
                    }
                    else if (rectangle.TouchRightOf(rmons[8]) || rectangle.TouchLeftOf(rmons[8]))
                    {
                        playerdie = true;
                    }
                }
            }
            if (!monsterdie[9])
            {
                if (rmons[9].Intersects(rectangle))
                {
                    if (rectangle.TouchTopOf(rmons[9]))
                    {
                        monsterdie[9] = true;
                        currentscore += 5;
                    }
                    else if (rectangle.TouchRightOf(rmons[9]) || rectangle.TouchLeftOf(rmons[9]))
                    {
                        playerdie = true;
                    }
                }
            }
            if (!monsterdie[10])
            {
                if (rmons[10].Intersects(rectangle))
                {
                    if (rectangle.TouchTopOf(rmons[10]))
                    {
                        monsterdie[10] = true;
                        currentscore += 5;
                    }
                    else if (rectangle.TouchRightOf(rmons[10]) || rectangle.TouchLeftOf(rmons[10]))
                    {
                        playerdie = true;
                    }
                }
            }
            #endregion
        }
        public void Draw(SpriteBatch spritbatch)
        {
            #region draw monsters
            for (int i = 0; i < 11; i++)
            {
                spritbatch.Draw(mons[i], monspos[i], Color.White);
            }
            #endregion
        }
    }
}
