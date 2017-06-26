using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;
namespace training3
{
    public sealed class world
    {
        
        #region declarations
        Coins coins = Coins.Instance;
        public Monsters monster = Monsters.Instance;
        public Texture2D texture;
        public Vector2 position = new Vector2(40, 335);
        private Vector2 velocity;
        protected Rectangle rectangle;
        private bool hasjumped = false;
        protected float currentscore;
        public Texture2D kal3a;
        public Vector2 kal3apos = new Vector2(37, 209);
        public Rectangle rkal3a;
        public Texture2D kal3a2;
        public Vector2 kal3apos2 = new Vector2(6480, 232);
        public Rectangle rkal3a2;
        public bool playerdie = false;
        protected SoundEffect sound4;
        Texture2D bulletTexture;
        public float bulletDelay;
        public List<Bullet> bulletList;
        Rectangle bulletrectangle;
        #endregion
        private static volatile world instance;
        private static object syncRoot = new Object();
        private world() 
        {
            bulletList = new List<Bullet>();
            bulletDelay = 1;
        }
        public static world Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new world();
                    }
                }

                return instance;
            }
        }
        public void Initialize()
        {
            rectangle = new Rectangle();
            currentscore = 0;
        }
        public Vector2 Position
        {
            get { return position; }
        }
        public float Score
        {
            get { return currentscore; }
            set { currentscore = value; }
        }
        public void Load(ContentManager content)
        {
            coins.Load(content);
            monster.Load(content);
            texture = content.Load<Texture2D>("images/stand");
            kal3a = content.Load<Texture2D>("images/kal3a");
            kal3a2 = content.Load<Texture2D>("images/kale3a2");
            sound4 = content.Load<SoundEffect>("sounds effect/mario coin");
            bulletTexture = content.Load<Texture2D>("images/playerbullet");         
        }
        public void Update(GameTime gametime, SoundEffect sound, Game1 game1)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.LeftAlt)&&!playerdie)
            {
                Shoot();
            }
            UpdateBullets();
            monster.Update(gametime,ref currentscore,ref rectangle,ref position,ref playerdie);
            coins.Update(gametime, ref sound4, ref currentscore, ref rectangle);
            position += velocity;
            Input(gametime, sound);
            if (velocity.Y < 10)
            {
                velocity.Y += 0.4f;
            }
            rectangle = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);
            rkal3a = new Rectangle((int)kal3apos.X, (int)kal3apos.Y, kal3a.Width, kal3a.Height);
            rkal3a2 = new Rectangle((int)kal3apos2.X, (int)kal3apos2.Y, kal3a2.Width, kal3a2.Height);
            game1.Window.Title = "Score : " + currentscore.ToString();
        }
        private void Input(GameTime gametime, SoundEffect sound)
        {
            if (!playerdie)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Right))
                {
                    velocity.X = (float)gametime.ElapsedGameTime.TotalMilliseconds / 5;
                }
                else if (Keyboard.GetState().IsKeyDown(Keys.Left))
                {
                    velocity.X = -(float)gametime.ElapsedGameTime.TotalMilliseconds / 5;
                }
                else velocity.X = 0f;
                if (Keyboard.GetState().IsKeyDown(Keys.Space) && hasjumped == false)
                {
                    position.Y -= 3f;
                    velocity.Y = -8f;
                    hasjumped = true;
                    sound.Play();
                }
            }
        }
        public void collision(Rectangle newrectangle, int xoffset, int yoffset)
        {
            if (rectangle.TouchTopOf(newrectangle))
            {
                rectangle.Y = newrectangle.Y - rectangle.Height;
                velocity.Y = 0f;
                hasjumped = false;
            }
            if (rectangle.TouchLeftOf(newrectangle))
            {
                position.X = newrectangle.X - rectangle.Width - 3;
            }
            if (rectangle.TouchRightOf(newrectangle))
            {
                position.X = newrectangle.X + newrectangle.Width + 3;
            }
            if (rectangle.TouchBottomOf(newrectangle))
            {
                velocity.Y = 1f;
            }
            if (position.X < 0) position.X = 0;
            if (position.X > xoffset - rectangle.Width) position.X = xoffset - rectangle.Width;
            if (position.Y < 0) position.Y = 0;
            if (position.Y > yoffset - rectangle.Height) position.Y = yoffset - rectangle.Height;
        }
        public void Draw(SpriteBatch spritbatch)
        {
            spritbatch.Draw(kal3a, rkal3a, Color.White);
            spritbatch.Draw(kal3a2, rkal3a2, Color.White);
            spritbatch.Draw(texture, rectangle, Color.White);
            coins.Draw(spritbatch);
            monster.Draw(spritbatch);
            foreach (Bullet b in bulletList)
            {
                b.Draw(spritbatch);
            }
        }
        public void Shoot()
        {
            if (bulletDelay >= 0)
            {
                bulletDelay--;
            }
            if (bulletDelay <= 0)
            {
                Bullet newBullet = new Bullet(bulletTexture);
                newBullet.bulletposition = new Vector2(position.X + 32 - newBullet.texture.Width / 2, position.Y + 2);
                newBullet.isVisible = true;
                if (bulletList.Count < 1)
                {
                    bulletList.Add(newBullet);
                }
            }
            if (bulletDelay == 0)
            {
                bulletDelay = 1;
            }
        }
        public void UpdateBullets()
        {
            foreach (Bullet b in bulletList)
            {
                b.bulletposition.X = b.bulletposition.X + b.speed;
                bulletrectangle = new Rectangle((int)b.bulletposition.X, (int)b.bulletposition.Y, bulletTexture.Width, bulletTexture.Height);
                if (bulletrectangle.Intersects(monster.rmons[0])) { monster.monspos[0].Y *= -1; b.isVisible = false; currentscore += 2; }
                else if (bulletrectangle.Intersects(monster.rmons[1])) { monster.monspos[1].Y *= -1; b.isVisible = false; currentscore += 2; }
                else if (bulletrectangle.Intersects(monster.rmons[2])) { monster.monspos[2].Y *= -1; b.isVisible = false; currentscore += 2; }
                else if (bulletrectangle.Intersects(monster.rmons[3])) { monster.monspos[3].Y *= -1; b.isVisible = false; currentscore += 2; }
                else if (bulletrectangle.Intersects(monster.rmons[4])) { monster.monspos[4].Y *= -1; b.isVisible = false; currentscore += 2; }
                else if (bulletrectangle.Intersects(monster.rmons[5])) { monster.monspos[5].Y *= -1; b.isVisible = false; currentscore += 2; }
                else if (bulletrectangle.Intersects(monster.rmons[6])) { monster.monspos[6].Y *= -1; b.isVisible = false; currentscore += 2; }
                else if (bulletrectangle.Intersects(monster.rmons[7])) { monster.monspos[7].Y *= -1; b.isVisible = false; currentscore += 2; }
                else if (bulletrectangle.Intersects(monster.rmons[8])) { monster.monspos[8].Y *= -1; b.isVisible = false; currentscore += 2; }
                else if (bulletrectangle.Intersects(monster.rmons[9])) { monster.monspos[9].Y *= -1; b.isVisible = false; currentscore += 2; }
                else if (bulletrectangle.Intersects(monster.rmons[10])) { monster.monspos[10].Y *= -1; b.isVisible = false; currentscore += 2; }
                if (b.bulletposition.X - position.X > 300)
                {
                    b.isVisible = false; //if hit the right side, hide it
                }
            }
            for (int i = 0; i < bulletList.Count; i++)
            {
                if (!bulletList[i].isVisible)
                {
                    bulletList.RemoveAt(i);
                    i--;
                }
            }
        }
    }
}