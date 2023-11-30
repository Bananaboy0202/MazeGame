using mazegame3._0;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;


namespace mazegame3
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        SpriteFont TimeFont;
        Maze mazewalls;
        Maze mazefloor;
        MainCharacter hero;
        Camera2D gamecamera;
        Vector2 CameraOffSet;
        Enemy1 firstenemy;

        Maze TheMaze;

        

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

            hero = new MainCharacter();
            firstenemy = new Enemy1();
            mazefloor = new Maze(100,100);
            mazewalls = new Maze(100,100);
            gamecamera = new Camera2D(GraphicsDevice.Viewport);
            CameraOffSet = new Vector2(GraphicsDevice.Viewport.Width / 2, GraphicsDevice.Viewport.Height / 2);
            TheMaze = new Maze(100, 60);

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
            hero.LoadContent(Content);
            firstenemy.LoadContent(Content);
            TheMaze.floor = Content.Load<Texture2D>(@"floor");
            TheMaze.wall = Content.Load<Texture2D>(@"wall");
            
            TimeFont = Content.Load<SpriteFont>(@"TimeFont");
            
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            gamecamera.Pos = hero.location - CameraOffSet;
            gamecamera.Update();


            // TODO: Add your update logic 

            



            base.Update(gameTime);
            hero.Update(gameTime);
            firstenemy.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            bool mazedrawn = false;
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin(transformMatrix: gamecamera.Transform);

            
            if (mazedrawn == false)
            {
                TheMaze.Draw(spriteBatch, graphics);
                mazedrawn = true;
            }
            
            hero.Draw(spriteBatch);
            firstenemy.Draw(spriteBatch);
            spriteBatch.DrawString(TimeFont, "Currently survived for " + (int)gameTime.TotalGameTime.TotalSeconds + " seconds", new Vector2(570, 0), Color.DarkRed);
            base.Draw(gameTime);
            
            


            spriteBatch.End();
        }
    }
}
