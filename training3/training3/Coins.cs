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
    public sealed class Coins
    {

        #region coins declarations
        public Texture2D coin;
        private Rectangle[] rcoin = new Rectangle[43];
        private Vector2[] coinpos = new Vector2[43];
        bool setposition = false;
        #endregion
        private static volatile Coins instance;
        private static object syncRoot = new Object();
        private Coins() { }
        public static Coins Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new Coins();
                    }
                }

                return instance;
            }
        }
        public void Initialize()
        {
            for (int i = 0; i < 43; i++)
            {
                rcoin[i] = new Rectangle();
            }
        }
        public void Load(ContentManager content)
        {
            coin = content.Load<Texture2D>("images/coin3");
        }
        public void Update(GameTime gametime, ref SoundEffect sound4, ref float currentscore, ref Rectangle rectangle)
        {
            if (!setposition)
            {
                #region coins positions
                coinpos[0] = new Vector2(207, 165);
                coinpos[1] = new Vector2(320, 165);
                coinpos[2] = new Vector2(380, 110);
                coinpos[3] = new Vector2(440, 165);
                coinpos[4] = new Vector2(670, 85);
                coinpos[5] = new Vector2(850, 50);
                coinpos[6] = new Vector2(1200, 50);
                coinpos[7] = new Vector2(1400, 50);
                coinpos[8] = new Vector2(1625, 330);
                coinpos[9] = new Vector2(2008, 290);
                coinpos[10] = new Vector2(2040, 250);
                coinpos[11] = new Vector2(2082, 210);
                coinpos[12] = new Vector2(2127, 170);
                coinpos[13] = new Vector2(2172, 130);
                coinpos[14] = new Vector2(2280, 90);
                coinpos[15] = new Vector2(2490, 90);
                coinpos[16] = new Vector2(2650, 90);
                coinpos[17] = new Vector2(2545, 332);
                coinpos[18] = new Vector2(3400, 332);
                coinpos[19] = new Vector2(3722, 90);
                coinpos[20] = new Vector2(6095, 70);
                coinpos[21] = new Vector2(6070, 90);
                coinpos[22] = new Vector2(6060, 120);
                coinpos[23] = new Vector2(6080, 145);
                coinpos[24] = new Vector2(6113, 148);
                coinpos[25] = new Vector2(6132, 120);
                coinpos[26] = new Vector2(6120, 90);
                coinpos[27] = new Vector2(6215, 60);
                coinpos[28] = new Vector2(6190, 80);
                coinpos[29] = new Vector2(6185, 110);
                coinpos[30] = new Vector2(6200, 135);
                coinpos[31] = new Vector2(6240, 135);
                coinpos[32] = new Vector2(6252, 110);
                coinpos[33] = new Vector2(6247, 76);
                coinpos[34] = new Vector2(6325, 50);
                coinpos[35] = new Vector2(6300, 70);
                coinpos[36] = new Vector2(6295, 100);
                coinpos[37] = new Vector2(6310, 125);
                coinpos[38] = new Vector2(6350, 125);
                coinpos[39] = new Vector2(6362, 100);
                coinpos[40] = new Vector2(6357, 66);
                coinpos[41] = new Vector2(6315, 155);
                coinpos[42] = new Vector2(6315, 185);
                #endregion
                setposition = true;
            }
            #region coinsRectangles
            for (int i = 0; i < 43; i++)
            {
                rcoin[i] = new Rectangle((int)coinpos[i].X, (int)coinpos[i].Y, coin.Width, coin.Height);
            }
            #endregion
            #region coinsTouch
            for (int i = 0; i < 43; i++)
            {
                if (rcoin[i].Intersects(rectangle))
                {
                    coinpos[i].X *= -10;
                    currentscore += 20;
                    sound4.Play();
                }
            }
            #endregion
        }
        public void Draw(SpriteBatch spritbatch)
        {
            for (int i = 0; i < 43; i++)
            {
                spritbatch.Draw(coin, rcoin[i], Color.White);
            }
        }
    }
}
