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
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        #region declaration
        Camera2 Camera;
        world world = world.Instance;
        map mop;
        SpriteFont font;
        SpriteFont font2;
        KeyboardState keyboard;
        Song sound;
        Song sound2;
        Song soundwin;
        //screen_manager Screenmanager;
        Vector2 buttonposition;
        Color buttoncolor;
        string buttontext;
        string over;
        string win;
        Vector2 overpos;
        Vector2 winpos;
        Vector2 scorepos;
        Texture2D gameover;
        float timer = 0;
        Texture2D titlescreen;
        Texture2D winscreen;
        SoundEffect sound3;
        bool reply = false;
        #endregion
        enum GameState {TitleScreen, Playing,wining,GameOver};
        GameState gamestate = GameState.TitleScreen;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        } 
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            this.IsMouseVisible = true;            
            #region Initialization
            
            mop = new map();
            overpos = new Vector2(335, 20);
            winpos = new Vector2(600,100);
            scorepos = new Vector2(480, 200);
            buttonposition = new Vector2(320, 420);
            buttoncolor = new Color(0, 0, 0);
            buttontext = "Press To Play ";
            over = "Game Over";
            win ="You Win";
            #endregion
            base.Initialize();
        }
        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            font = Content.Load<SpriteFont>("font/font1");
            font2 = Content.Load<SpriteFont>("font/font2");
            gameover = Content.Load<Texture2D>("images/gameover2");
            winscreen = Content.Load<Texture2D>("images/win");
            titlescreen = Content.Load<Texture2D>("images/start game");
            sound = Content.Load<Song>("sounds effect/mario die");
            sound2 = Content.Load<Song>("sounds effect/mario world");
            soundwin = Content.Load<Song>("sounds effect/mario win");
            sound3 = Content.Load<SoundEffect>("sounds effect/mario jump");
            Camera = new Camera2(GraphicsDevice.Viewport);
            tiles.Content = Content;
            mop.Generate(new int[,]{
               {2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
               {2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
               {2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,0,0,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,1,0,0,1,0,0,1,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
               {2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,0,0,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,2,0,0,2,0,0,2,0,0,2,0,0,2,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
               {2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,0,0,0,2,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,0,0,2,0,0,2,0,0,2,0,0,2,0,0,2,0,0,2,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
               {2,0,0,0,0,1,0,0,1,1,1,1,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,2,0,0,0,2,2,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,2,0,0,2,0,0,2,0,0,2,0,0,2,0,0,2,0,0,2,2,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
               {2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,2,2,0,0,0,2,2,2,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,2,2,0,0,2,0,0,2,0,0,2,0,0,2,0,0,2,0,0,2,2,2,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
               {2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,2,0,0,0,0,0,1,1,1,1,0,0,0,0,0,0,0,0,0,1,0,0,0,0,1,0,0,0,0,0,0,0,1,2,2,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,2,2,2,0,0,0,2,2,2,2,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,2,2,2,0,0,2,0,0,2,0,0,2,0,0,2,0,0,2,0,0,2,2,2,2,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
               {2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,2,2,0,0,0,0,0,1,1,1,1,0,0,0,0,0,0,0,0,1,2,0,0,0,0,2,1,0,0,0,0,0,1,2,2,2,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,2,2,2,2,0,0,0,2,2,2,2,2,1,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,2,2,2,2,0,0,2,0,0,2,0,0,2,0,0,2,0,0,2,0,0,2,2,2,2,2,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
               {2,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,2,2,2,2,1,1,1,1,1,2,2,2,2,1,1,0,0,1,1,1,1,2,2,1,1,1,1,2,2,1,1,1,1,1,2,2,2,2,2,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,1,1,1,2,2,2,2,2,2,0,0,0,2,2,2,2,2,2,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,1,0,0,1,0,0,1,0,0,1,0,0,1,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
               {2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,0,0,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,0,0,2,2,2,2,2,2,2,2,2,0,0,0,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,0,0,2,0,0,2,0,0,2,0,0,2,0,0,2,0,0,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2},
               {2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,0,0,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,0,0,2,2,2,2,2,2,2,2,2,0,0,0,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,0,0,2,0,0,2,0,0,2,0,0,2,0,0,2,0,0,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2},
               {2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,0,0,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,0,0,2,2,2,2,2,2,2,2,2,0,0,0,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,0,0,2,0,0,2,0,0,2,0,0,2,0,0,2,0,0,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2},
            },40);
            world.Load(Content);
        }
        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here 
        }
        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            KeyboardState keyState = Keyboard.GetState();
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed||keyState.IsKeyDown(Keys.Escape))
                this.Exit();
            MouseState mouse = Mouse.GetState();
            if (mouse.X < buttonposition.X || mouse.Y < buttonposition.Y || mouse.X > buttonposition.X + font.MeasureString(buttontext).X || mouse.Y > buttonposition.Y + font.MeasureString(buttontext).Y)
            {
                buttoncolor = new Color(0, 0, 0);
            }
            else
            {
                buttoncolor = new Color(4, 22, 233);
                if (gamestate == GameState.TitleScreen)
                {
                    if (keyState.IsKeyDown(Keys.Enter) || mouse.LeftButton == ButtonState.Pressed)
                    {
                        gamestate = GameState.Playing;
                        MediaPlayer.Stop();
                    }
                } 
                this.Window.Title = "Score : " + world.Score.ToString();
            }
            if (gamestate == GameState.Playing)
            {
                world.Update(gameTime,sound3,this);
                foreach (Collisiontiles tile in mop.Collisiontiles)
                {
                    world.collision(tile.Rectangle, mop.Width, mop.Height);
                    Camera.Update(world.Position, mop.Width, mop.Height);
                }
                #region mario sprites
                keyboard = Keyboard.GetState();
                if (keyboard.IsKeyDown(Keys.Right))
                    world.texture = Content.Load<Texture2D>("images/stand");
                if (keyboard.IsKeyDown(Keys.Left))
                    world.texture = Content.Load<Texture2D>("images/Standleft");
                if (keyboard.IsKeyDown(Keys.Right) && keyboard.IsKeyDown(Keys.Space))
                    world.texture = Content.Load<Texture2D>("images/Jumpright");
                if (keyboard.IsKeyDown(Keys.Left) && keyboard.IsKeyDown(Keys.Space))
                    world.texture = Content.Load<Texture2D>("images/Jumpleft");
                #endregion
                #region update monster die
                if (world.monster.monsterdie[0]==true)
                {
                    world.monster.monspos[0].Y -= 4;
                    world.monster.mons[0] = Content.Load<Texture2D>("images/die monster");
                }
                if (world.monster.monsterdie[1] == true)
                {
                    world.monster.monspos[1].Y -= 3;
                    world.monster.mons[1]= Content.Load<Texture2D>("images/die monster");
                }
                if (world.monster.monsterdie[2] == true)
                {
                    world.monster.monspos[2].Y -= 4;
                    world.monster.mons[2]= Content.Load<Texture2D>("images/die monster");
                }
                if (world.monster.monsterdie[3] == true)
                {
                    world.monster.monspos[3].Y -= 3;
                    world.monster.mons[3] = Content.Load<Texture2D>("images/die monster");
                }
                if (world.monster.monsterdie[4] == true)
                {
                    world.monster.monspos[4].Y -= 4;
                    world.monster.mons[4] = Content.Load<Texture2D>("images/die monster");
                }
                if (world.monster.monsterdie[5] == true)
                {
                    world.monster.monspos[5].Y -= 3;
                    world.monster.mons[5] = Content.Load<Texture2D>("images/die monster");
                }
                if (world.monster.monsterdie[6] == true)
                {
                    world.monster.monspos[6].Y -= 4;
                    world.monster.mons[6]= Content.Load<Texture2D>("images/die monster");
                }
                if (world.monster.monsterdie[7] == true)
                {
                    world.monster.monspos[7].Y -= 5;
                    world.monster.mons[7] = Content.Load<Texture2D>("images/die monster");
                }
                if (world.monster.monsterdie[8] == true)
                {
                    world.monster.monspos[8].Y -= 5;
                    world.monster.mons[8]= Content.Load<Texture2D>("images/die monster");
                }
                if (world.monster.monsterdie[9] == true)
                {
                    world.monster.monspos[9].Y -= 5;
                    world.monster.mons[9] = Content.Load<Texture2D>("images/die monster");
                }
                if (world.monster.monsterdie[10] == true)
                {
                    world.monster.monspos[10].Y -= 5;
                    world.monster.mons[10]= Content.Load<Texture2D>("images/die monster");
                }
                #endregion
                #region player die
                if (world.playerdie == true)
                {
                    MediaPlayer.Stop();
                    world.texture = Content.Load<Texture2D>("images/die");
                    if ((timer += (float)gameTime.ElapsedGameTime.TotalSeconds) > 2)
                    {
                        gamestate = GameState.GameOver;
                    }
                }
                #endregion
                #region player win
                if (world.position.X>6470  && keyState.IsKeyDown(Keys.Up))
                {
                    MediaPlayer.Stop();
                    MediaPlayer.Play(soundwin);
                    gamestate = GameState.wining;
                }
                #endregion
            }
            //TODO: Add your update logic here
            base.Update(gameTime);
        }
        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            if (gamestate == GameState.TitleScreen)
            {
                GraphicsDevice.Clear(Color.White);
                spriteBatch.Begin();
                spriteBatch.Draw(titlescreen, new Vector2(0,0), Color.White);
                spriteBatch.DrawString(font, buttontext, buttonposition, Color.White);
                spriteBatch.DrawString(font, buttontext, buttonposition, buttoncolor);
                if (MediaPlayer.State != MediaState.Playing)
                    MediaPlayer.Play(sound2);
            }
            if(gamestate == GameState.Playing)
            {
                this.IsMouseVisible = false;
                GraphicsDevice.Clear(Color.CornflowerBlue);
                spriteBatch.Begin(SpriteSortMode.Deferred,
                BlendState.AlphaBlend,
                null,null,null,null,
                Camera.Transform);
                mop.Draw(spriteBatch);
                world.Draw(spriteBatch);
                if (MediaPlayer.State != MediaState.Playing)
                    MediaPlayer.Play(sound2);
            }
            if (gamestate == GameState.GameOver)
            {
                spriteBatch.Begin();
                spriteBatch.Draw(gameover, Vector2.Zero, Color.White);
                if (MediaPlayer.State != MediaState.Playing && !reply)
                {
                    MediaPlayer.Play(sound);
                    reply = true;
                }
            }
            if(gamestate==GameState.wining)
            {
                spriteBatch.Begin();
                spriteBatch.Draw(winscreen,Vector2.Zero,Color.White);
                spriteBatch.DrawString(font2, win, winpos, Color.Black);
                spriteBatch.DrawString(font2,"Your Score Is : ",scorepos, Color.Black);
                spriteBatch.DrawString(font2,world.Score.ToString(), new Vector2(630,250), Color.Black);
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}