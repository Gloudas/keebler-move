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

namespace Max_Keebler_s_Big_Move
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D playerTexture, platformTexture, bulletTexture;
        public int canvasHeight, canvasWidth;
        KeyboardState keyboard = Keyboard.GetState();
        KeyboardState oldState;
        Player player;
        Platform myPlatform;
        List<Platform> Platforms;
        List<Bullet> Bullets;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            canvasHeight = graphics.GraphicsDevice.Viewport.Height;
            canvasWidth = graphics.GraphicsDevice.Viewport.Width;
            player = new Player(new Vector2(canvasWidth / 4, canvasHeight-80), this);
            Platforms = new List<Platform>();
            Bullets = new List<Bullet>();
            for (int i = 0; i < 5; i++)
            {
                Platform platform = new Platform((i * (canvasWidth / 3)), (canvasHeight - 20));
                Platforms.Add(platform);
            }
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
            playerTexture = Content.Load<Texture2D>(@"Player");
            platformTexture = Content.Load<Texture2D>(@"Platform1");
            bulletTexture = Content.Load<Texture2D>(@"bullet");
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
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
            keyboard = Keyboard.GetState();
            player.Update(gameTime, keyboard);

            if(keyboard.IsKeyDown(Keys.X))
            {
                if (!oldState.IsKeyDown(Keys.X))
                {
                    Bullet newBullet = new Bullet(player);
                    Bullets.Add(newBullet);
                }
            }
            List<Bullet> removeBullets = new List<Bullet>();
            foreach(Bullet curBullet in Bullets)
            {
                curBullet.Update();
                if (curBullet.position.X > canvasWidth)
                {
                    removeBullets.Add(curBullet);
                }
            }
            foreach (Bullet remove in removeBullets)
            {
                Bullets.Remove(remove);
            }
            foreach(Platform myPlatform in Platforms)
            {
                myPlatform.Update();
                if (myPlatform.isCollidingLeft(player.playerRect) &&
                    myPlatform.isCollidingTop(player.playerRect))
                {
                    if (player.playerPos.Y == (canvasHeight - 60))
                    {
                        myPlatform.onCollisionLeft(player);
                    }
                    else
                    {
                        myPlatform.onCollisionTop(player);
                    }

                    
                    /*if ((player.playerPos.Y+60) > (myPlatform.position.Y + 15))
                    {
                        myPlatform.onCollisionLeft(player);
                    }
                    else
                    {
                        myPlatform.onCollisionTop(player);
                    }*/
                }
                else if (myPlatform.isCollidingTop(player.playerRect))
                {
                    myPlatform.onCollisionTop(player);
                }
                else if (myPlatform.isCollidingLeft(player.playerRect))
                {
                    myPlatform.onCollisionLeft(player);
                }    
                else if(myPlatform.outOfBounds())
                {
                    Random rand = new Random();
                    myPlatform.position.X = canvasWidth;
                    myPlatform.position.Y = rand.Next(canvasHeight-200, canvasHeight-10);
                }
            }
            oldState = keyboard;

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            spriteBatch.Draw(playerTexture, player.playerPos, Color.White);
            foreach (Bullet bullet in Bullets)
            {
                spriteBatch.Draw(bulletTexture, bullet.position, Color.White);
            }
            foreach (Platform platform in Platforms)
            {
                spriteBatch.Draw(platformTexture, platform.position, Color.White);
            }
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
